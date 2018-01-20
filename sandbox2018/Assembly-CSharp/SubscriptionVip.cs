using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

// Token: 0x0200015F RID: 351
public class SubscriptionVip : MonoBehaviour, IStoreListener
{
	// Token: 0x170000A3 RID: 163
	// (get) Token: 0x060008E5 RID: 2277 RVA: 0x00026100 File Offset: 0x00024500
	public static SubscriptionVip Instance
	{
		get
		{
			if (SubscriptionVip._instance == null)
			{
				GameObject gameObject = new GameObject("SubscriptionVip");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				SubscriptionVip._instance = gameObject.AddComponent<SubscriptionVip>();
			}
			return SubscriptionVip._instance;
		}
	}

	// Token: 0x060008E6 RID: 2278 RVA: 0x0002613E File Offset: 0x0002453E
	public void Init()
	{
		if (SubscriptionVip.m_StoreController == null)
		{
			this.InitializePurchasing();
		}
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x00026150 File Offset: 0x00024550
	public void InitializePurchasing()
	{
		if (this.IsInitialized())
		{
			return;
		}
		ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(), new IPurchasingModule[0]);
		configurationBuilder.AddProduct(SubscriptionVip.kProductIDSubscription, ProductType.Subscription, new IDs
		{
			{
				this.kAppleNoAdsProductID,
				new string[]
				{
					"AppleAppStore"
				}
			},
			{
				this.kGooglePlayNoAdsProductID,
				new string[]
				{
					"GooglePlay"
				}
			}
		});
		UnityPurchasing.Initialize(this, configurationBuilder);
	}

	// Token: 0x060008E8 RID: 2280 RVA: 0x000261C9 File Offset: 0x000245C9
	private bool IsInitialized()
	{
		return SubscriptionVip.m_StoreController != null && SubscriptionVip.m_StoreExtensionProvider != null;
	}

	// Token: 0x060008E9 RID: 2281 RVA: 0x000261E3 File Offset: 0x000245E3
	public void BuySubscription()
	{
		this.BuyProductID(SubscriptionVip.kProductIDSubscription);
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x000261F0 File Offset: 0x000245F0
	private void BuyProductID(string productId)
	{
		try
		{
			if (this.IsInitialized())
			{
				Product product = SubscriptionVip.m_StoreController.products.WithID(productId);
				if (product != null && product.availableToPurchase)
				{
					Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
					SubscriptionVip.m_StoreController.InitiatePurchase(product);
				}
				else
				{
					Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
				}
			}
			else
			{
				Debug.Log("BuyProductID FAIL. Not initialized.");
			}
		}
		catch (Exception arg)
		{
			Debug.Log("BuyProductID: FAIL. Exception during purchase. " + arg);
		}
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x00026298 File Offset: 0x00024698
	private void Update()
	{
		if (this._isHadValid)
		{
			return;
		}
		if (!PlayerManager.Instance.GetVip())
		{
			return;
		}
		if (this.IsInitialized())
		{
			this._isHadValid = true;
			foreach (Product product in SubscriptionVip.m_StoreController.products.all)
			{
				GooglePurchaseData googlePurchaseData = new GooglePurchaseData(product.receipt);
				if (product.hasReceipt && googlePurchaseData.json.productId.CompareTo(this.kGooglePlayNoAdsProductID) == 0)
				{
					long num = long.Parse(googlePurchaseData.json.purchaseTime);
					long currentRealTimestamp = TimeHelper.GetCurrentRealTimestamp();
					PlayerManager.Instance.SetSubscriptionTime(num);
					if (currentRealTimestamp - num >= AppConfig.SUBSCRIPTION_VALID_MILLISCEOND)
					{
						PlayerManager.Instance.SetVip(0);
						Debug.Log("超过有效期订阅");
					}
					else
					{
						Debug.Log("有效期内订阅");
					}
					Debug.Log(string.Concat(new object[]
					{
						"productId ",
						this.kGooglePlayNoAdsProductID,
						"curTime ",
						currentRealTimestamp,
						" purchaseTime ",
						num
					}));
				}
			}
		}
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x000263D0 File Offset: 0x000247D0
	public void PaySuccessCallBack()
	{
		Debug.Log("订阅成功 SubscriptionVip");
		PlayerManager.Instance.SetVip(1);
		if (SceneGameManager.Instance.CurrentTID.CompareTo(string.Empty) != 0)
		{
			MainUIManager.Instance.ClosedVipPanel();
			SceneGameManager.Instance.SwitchPanel(SceneGameManager.SCENEPANEL.GMAE);
		}
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x00026420 File Offset: 0x00024820
	public void PayFailedCallBack()
	{
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x00026424 File Offset: 0x00024824
	private void OnInitializeFailedCallBack()
	{
		Debug.Log("初始化订阅失败");
		long subscriptionTime = PlayerManager.Instance.GetSubscriptionTime();
		long currentRealTimestamp = TimeHelper.GetCurrentRealTimestamp();
		Debug.Log(string.Concat(new object[]
		{
			"OnInitializeFailedCallBack curTime ",
			currentRealTimestamp,
			" purchaseTime ",
			subscriptionTime
		}));
		if (currentRealTimestamp - subscriptionTime >= AppConfig.SUBSCRIPTION_VALID_MILLISCEOND)
		{
			PlayerManager.Instance.SetVip(0);
			Debug.Log("超过有效期订阅");
		}
		else
		{
			Debug.Log("有效期内订阅");
		}
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x000264B0 File Offset: 0x000248B0
	public void RestorePurchases()
	{
		if (!this.IsInitialized())
		{
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
		{
			Debug.Log("RestorePurchases started ...");
			IAppleExtensions extension = SubscriptionVip.m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			extension.RestoreTransactions(delegate(bool result)
			{
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
		else
		{
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}

	// Token: 0x060008F0 RID: 2288 RVA: 0x0002653F File Offset: 0x0002493F
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		Debug.Log("OnInitialized: PASS");
		SubscriptionVip.m_StoreController = controller;
		SubscriptionVip.m_StoreExtensionProvider = extensions;
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x00026557 File Offset: 0x00024957
	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
		this.OnInitializeFailedCallBack();
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x00026574 File Offset: 0x00024974
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		if (string.Equals(args.purchasedProduct.definition.id, SubscriptionVip.kProductIDSubscription, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			this.PaySuccessCallBack();
		}
		else
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
			this.PayFailedCallBack();
		}
		return PurchaseProcessingResult.Complete;
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000265F1 File Offset: 0x000249F1
	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
		this.PayFailedCallBack();
	}

	// Token: 0x04000593 RID: 1427
	private bool _isHadValid;

	// Token: 0x04000594 RID: 1428
	private static IStoreController m_StoreController;

	// Token: 0x04000595 RID: 1429
	private static IExtensionProvider m_StoreExtensionProvider;

	// Token: 0x04000596 RID: 1430
	private static string kProductIDSubscription = "pixel_cartoon_vip";

	// Token: 0x04000597 RID: 1431
	private string kGooglePlayNoAdsProductID = "sandbox.coloring.number.pixel.art.vip";

	// Token: 0x04000598 RID: 1432
	private string kAppleNoAdsProductID = string.Empty;

	// Token: 0x04000599 RID: 1433
	private static SubscriptionVip _instance;
}
