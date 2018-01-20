using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

// Token: 0x02000160 RID: 352
public class SubscriptionVipIOS : MonoBehaviour, IStoreListener
{
	// Token: 0x170000A4 RID: 164
	// (get) Token: 0x060008F7 RID: 2295 RVA: 0x00026660 File Offset: 0x00024A60
	public static SubscriptionVipIOS Instance
	{
		get
		{
			if (SubscriptionVipIOS._instance == null)
			{
				GameObject gameObject = new GameObject("SubscriptionVipIOS");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				SubscriptionVipIOS._instance = gameObject.AddComponent<SubscriptionVipIOS>();
			}
			return SubscriptionVipIOS._instance;
		}
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x0002669E File Offset: 0x00024A9E
	public void Init()
	{
		if (SubscriptionVipIOS.m_StoreController == null)
		{
			this.InitializePurchasing();
		}
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x000266B0 File Offset: 0x00024AB0
	public void InitializePurchasing()
	{
		if (this.IsInitialized())
		{
			return;
		}
		ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(), new IPurchasingModule[0]);
		configurationBuilder.AddProduct(SubscriptionVipIOS.kProductIDSubscription, ProductType.Subscription, new IDs
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

	// Token: 0x060008FA RID: 2298 RVA: 0x00026729 File Offset: 0x00024B29
	private bool IsInitialized()
	{
		return SubscriptionVipIOS.m_StoreController != null && SubscriptionVipIOS.m_StoreExtensionProvider != null;
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x00026743 File Offset: 0x00024B43
	public void BuySubscription()
	{
		this.BuyProductID(SubscriptionVipIOS.kProductIDSubscription);
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x00026750 File Offset: 0x00024B50
	private void BuyProductID(string productId)
	{
		try
		{
			if (this.IsInitialized())
			{
				Product product = SubscriptionVipIOS.m_StoreController.products.WithID(productId);
				if (product != null && product.availableToPurchase)
				{
					Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
					SubscriptionVipIOS.m_StoreController.InitiatePurchase(product);
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

	// Token: 0x060008FD RID: 2301 RVA: 0x000267F8 File Offset: 0x00024BF8
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
		}
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x00026830 File Offset: 0x00024C30
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

	// Token: 0x060008FF RID: 2303 RVA: 0x00026880 File Offset: 0x00024C80
	public void PayFailedCallBack()
	{
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x00026884 File Offset: 0x00024C84
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

	// Token: 0x06000901 RID: 2305 RVA: 0x00026910 File Offset: 0x00024D10
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
			IAppleExtensions extension = SubscriptionVipIOS.m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
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

	// Token: 0x06000902 RID: 2306 RVA: 0x0002699F File Offset: 0x00024D9F
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		Debug.Log("OnInitialized: PASS");
		SubscriptionVipIOS.m_StoreController = controller;
		SubscriptionVipIOS.m_StoreExtensionProvider = extensions;
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x000269B7 File Offset: 0x00024DB7
	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
		this.OnInitializeFailedCallBack();
	}

	// Token: 0x06000904 RID: 2308 RVA: 0x000269D4 File Offset: 0x00024DD4
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		if (string.Equals(args.purchasedProduct.definition.id, SubscriptionVipIOS.kProductIDSubscription, StringComparison.Ordinal))
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

	// Token: 0x06000905 RID: 2309 RVA: 0x00026A51 File Offset: 0x00024E51
	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
		this.PayFailedCallBack();
	}

	// Token: 0x0400059B RID: 1435
	private bool _isHadValid;

	// Token: 0x0400059C RID: 1436
	private static IStoreController m_StoreController;

	// Token: 0x0400059D RID: 1437
	private static IExtensionProvider m_StoreExtensionProvider;

	// Token: 0x0400059E RID: 1438
	private static string kProductIDSubscription = "pixel_cartoon_vip";

	// Token: 0x0400059F RID: 1439
	private string kAppleNoAdsProductID = "com.pixel.sandbox.cartoon.number.coloring.vip";

	// Token: 0x040005A0 RID: 1440
	private string kGooglePlayNoAdsProductID = string.Empty;

	// Token: 0x040005A1 RID: 1441
	private static SubscriptionVipIOS _instance;
}
