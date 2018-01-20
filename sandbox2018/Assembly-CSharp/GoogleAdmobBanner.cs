using System;
using GoogleMobileAds.Api;
using UnityEngine;

// Token: 0x02000158 RID: 344
public class GoogleAdmobBanner : MonoBehaviour
{
	// Token: 0x170000A0 RID: 160
	// (get) Token: 0x060008C4 RID: 2244 RVA: 0x00025A36 File Offset: 0x00023E36
	public static GoogleAdmobBanner Instance
	{
		get
		{
			return GoogleAdmobBanner.instance;
		}
	}

	// Token: 0x060008C5 RID: 2245 RVA: 0x00025A40 File Offset: 0x00023E40
	private void Awake()
	{
		if (GoogleAdmobBanner.instance == null)
		{
			GoogleAdmobBanner.instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			if (ComibilityHelper.IsWideScreen())
			{
				this.m_bannerPosition = AdPosition.Top;
			}
			this.SetBannerID();
			if (PlayerManager.Instance.IsShowBanner())
			{
				this.LoadBanner();
				this.HideBanner();
			}
		}
		else if (GoogleAdmobBanner.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x00025AC0 File Offset: 0x00023EC0
	private void SetBannerID()
	{
		this._bannerID = "ca-app-pub-3398049612144040/2681059389";
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x00025AD0 File Offset: 0x00023ED0
	private void LoadBanner()
	{
		Debug.Log("-------------------_bannerID " + this._bannerID);
		this.DestroyBanner();
		this.m_bannerView = new BannerView(this._bannerID, AdSize.Banner, this.m_bannerPosition);
		AdRequest request = new AdRequest.Builder().Build();
		this.m_bannerView.OnAdLoaded += this.OnBannerViewLoad;
		this.m_bannerView.OnAdFailedToLoad += this.OnBannerFailedToLoad;
		this.m_bannerView.OnAdClosed += this.OnBannerClosed;
		this.m_bannerView.LoadAd(request);
		Debug.Log("Start Load Banner View.");
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x00025B7C File Offset: 0x00023F7C
	public void ShowBanner()
	{
		if (this.m_bannerView != null)
		{
			this.m_bannerView.Show();
			Debug.Log("Show Banner View.");
		}
		else
		{
			this.LoadBanner();
		}
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x00025BA9 File Offset: 0x00023FA9
	private void Update()
	{
		if (SceneGameManager.Instance.ScenePanel != SceneGameManager.SCENEPANEL.GMAE)
		{
			this.HideBanner();
		}
	}

	// Token: 0x060008CA RID: 2250 RVA: 0x00025BC1 File Offset: 0x00023FC1
	public void HideBanner()
	{
		if (this.m_bannerView != null)
		{
			this.m_bannerView.Hide();
		}
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x00025BD9 File Offset: 0x00023FD9
	public void DestroyBanner()
	{
		if (this.m_bannerView != null)
		{
			this.m_bannerView.Destroy();
			this.m_bannerView = null;
			Debug.Log("Destroy Banner View.");
		}
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x00025C02 File Offset: 0x00024002
	private void OnBannerViewLoad(object sender, EventArgs args)
	{
		Debug.Log("Load Banner View Finished.");
		this.m_failedLoadBannerViewCount = 0;
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x00025C18 File Offset: 0x00024018
	private void OnBannerFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		this.m_failedLoadBannerViewCount++;
		Debug.Log(string.Concat(new object[]
		{
			"Load Banner View Failed. message = ",
			args.Message,
			" m_failedLoadBannerViewCount = ",
			this.m_failedLoadBannerViewCount
		}));
		if (this.m_failedLoadBannerViewCount < this.m_maxFailedLoadCount)
		{
			this.LoadBanner();
		}
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x00025C81 File Offset: 0x00024081
	private void OnBannerClosed(object sender, EventArgs args)
	{
		Debug.Log("Closed Banner View.");
		this.DestroyBanner();
		this.LoadBanner();
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x00025C99 File Offset: 0x00024099
	private void OnDestroy()
	{
		this.DestroyBanner();
		Debug.Log("On Banner Destroy.");
	}

	// Token: 0x0400056E RID: 1390
	private static GoogleAdmobBanner instance;

	// Token: 0x0400056F RID: 1391
	private AdPosition m_bannerPosition = AdPosition.Bottom;

	// Token: 0x04000570 RID: 1392
	private string _bannerID = string.Empty;

	// Token: 0x04000571 RID: 1393
	private BannerView m_bannerView;

	// Token: 0x04000572 RID: 1394
	private int m_failedLoadBannerViewCount;

	// Token: 0x04000573 RID: 1395
	public int m_probabilityShowInterstitial = 75;

	// Token: 0x04000574 RID: 1396
	private int m_failedLoadInterstitialCount;

	// Token: 0x04000575 RID: 1397
	private int m_failedLoadRewardVedioCount;

	// Token: 0x04000576 RID: 1398
	public int m_maxFailedLoadCount = 3;

	// Token: 0x04000577 RID: 1399
	public Action OnRewardVideo;
}
