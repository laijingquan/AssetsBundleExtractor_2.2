using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

// Token: 0x02000161 RID: 353
public class SubscriptionVipTwo : MonoBehaviour, IStoreListener
{
	// Token: 0x170000A5 RID: 165
	// (get) Token: 0x06000909 RID: 2313 RVA: 0x00026ACC File Offset: 0x00024ECC
	public static SubscriptionVipTwo Instance
	{
		get
		{
			if (SubscriptionVipTwo._instance == null)
			{
				GameObject gameObject = new GameObject("SubscriptionVipTwo");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				SubscriptionVipTwo._instance = gameObject.AddComponent<SubscriptionVipTwo>();
			}
			return SubscriptionVipTwo._instance;
		}
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x00026B0A File Offset: 0x00024F0A
	public void Init()
	{
		if (SubscriptionVipTwo.m_StoreController == null)
		{
			this.InitializePurchasing();
		}
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x00026B1C File Offset: 0x00024F1C
	public void InitializePurchasing()
	{
		if (this.IsInitialized())
		{
			return;
		}
		ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(), new IPurchasingModule[0]);
		configurationBuilder.AddProduct(SubscriptionVipTwo.kProductIDSubscription, ProductType.Subscription, new IDs
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
		configurationBuilder.AddProduct(SubscriptionVipTwo.kProductIDViplifetime, ProductType.NonConsumable, new IDs
		{
			{
				this.kAppleNoAdsProductID,
				new string[]
				{
					"AppleAppStore"
				}
			},
			{
				this.kGooglePlayViplifetimeProductID,
				new string[]
				{
					"GooglePlay"
				}
			}
		});
		UnityPurchasing.Initialize(this, configurationBuilder);
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x00026BDD File Offset: 0x00024FDD
	private bool IsInitialized()
	{
		return SubscriptionVipTwo.m_StoreController != null && SubscriptionVipTwo.m_StoreExtensionProvider != null;
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x00026BF7 File Offset: 0x00024FF7
	public void BuySubscription2()
	{
		this.BuyProductID(SubscriptionVipTwo.kProductIDSubscription);
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x00026C04 File Offset: 0x00025004
	public void BuyLifeVip()
	{
		this.BuyProductID(SubscriptionVipTwo.kProductIDViplifetime);
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x00026C14 File Offset: 0x00025014
	private void BuyProductID(string productId)
	{
		try
		{
			if (this.IsInitialized())
			{
				Product product = SubscriptionVipTwo.m_StoreController.products.WithID(productId);
				if (product != null && product.availableToPurchase)
				{
					Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
					SubscriptionVipTwo.m_StoreController.InitiatePurchase(product);
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

	// Token: 0x06000910 RID: 2320 RVA: 0x00026CBC File Offset: 0x000250BC
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
			foreach (Product product in SubscriptionVipTwo.m_StoreController.products.all)
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

	// Token: 0x06000911 RID: 2321 RVA: 0x00026DF4 File Offset: 0x000251F4
	public void PaySubscriptionSuccessCallBack()
	{
		Debug.Log("订阅成功 SubscriptionVip2 ");
		PlayerManager.Instance.SetVip(1);
		if (SceneGameManager.Instance.CurrentTID.CompareTo(string.Empty) != 0)
		{
			MainUIManager.Instance.ClosedVipPanel();
			SceneGameManager.Instance.SwitchPanel(SceneGameManager.SCENEPANEL.GMAE);
		}
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x00026E44 File Offset: 0x00025244
	public void PayLifeVipSuccessCallBack()
	{
		Debug.Log("订阅成功LifeVip");
		PlayerManager.Instance.SetLifeVip(1);
		if (SceneGameManager.Instance.CurrentTID.CompareTo(string.Empty) != 0)
		{
			MainUIManager.Instance.ClosedVipPanel();
			SceneGameManager.Instance.SwitchPanel(SceneGameManager.SCENEPANEL.GMAE);
		}
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x00026E94 File Offset: 0x00025294
	public void PayFailedCallBack()
	{
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x00026E98 File Offset: 0x00025298
	private void OnInitializeFailedCallBack()
	{
		Debug.Log("-------------SubscriptionVipTwo Init 初始化订阅失败 ");
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

	// Token: 0x06000915 RID: 2325 RVA: 0x00026F24 File Offset: 0x00025324
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
			IAppleExtensions extension = SubscriptionVipTwo.m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
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

	// Token: 0x06000916 RID: 2326 RVA: 0x00026FB3 File Offset: 0x000253B3
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		SubscriptionVipTwo.m_StoreController = controller;
		SubscriptionVipTwo.m_StoreExtensionProvider = extensions;
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x00026FC1 File Offset: 0x000253C1
	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("---------------OnInitializeFailed InitializationFailureReason:" + error);
		this.OnInitializeFailedCallBack();
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x00026FE0 File Offset: 0x000253E0
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		if (string.Equals(args.purchasedProduct.definition.id, SubscriptionVipTwo.kProductIDSubscription, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			this.PaySubscriptionSuccessCallBack();
		}
		else if (string.Equals(args.purchasedProduct.definition.id, SubscriptionVipTwo.kProductIDViplifetime, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			this.PayLifeVipSuccessCallBack();
		}
		else
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
			this.PayFailedCallBack();
		}
		return PurchaseProcessingResult.Complete;
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x000270A7 File Offset: 0x000254A7
	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
		this.PayFailedCallBack();
	}

	// Token: 0x040005A3 RID: 1443
	private bool _isHadValid;

	// Token: 0x040005A4 RID: 1444
	private static IStoreController m_StoreController;

	// Token: 0x040005A5 RID: 1445
	private static IExtensionProvider m_StoreExtensionProvider;

	// Token: 0x040005A6 RID: 1446
	private static string kProductIDSubscription = "Cartoon Sandbox VIP";

	// Token: 0x040005A7 RID: 1447
	private string kGooglePlayNoAdsProductID = "sandbox.coloring.number.pixel.art.smallvip";

	// Token: 0x040005A8 RID: 1448
	private static string kProductIDViplifetime = "pixel_cartoon_viplifetime";

	// Token: 0x040005A9 RID: 1449
	private string kGooglePlayViplifetimeProductID = "sandbox.coloring.number.pixel.art.lifetime";

	// Token: 0x040005AA RID: 1450
	private string kAppleNoAdsProductID = string.Empty;

	// Token: 0x040005AB RID: 1451
	private static SubscriptionVipTwo _instance;
}
