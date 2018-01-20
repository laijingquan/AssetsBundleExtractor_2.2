using System;
using GoogleMobileAds.Api;
using UnityEngine;

// Token: 0x02000159 RID: 345
public class GoogleAdmobInterstitial : MonoBehaviour
{
	// Token: 0x170000A1 RID: 161
	// (get) Token: 0x060008D1 RID: 2257 RVA: 0x00025CCD File Offset: 0x000240CD
	public static GoogleAdmobInterstitial Instance
	{
		get
		{
			return GoogleAdmobInterstitial.instance;
		}
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x00025CD4 File Offset: 0x000240D4
	private void Awake()
	{
		if (GoogleAdmobInterstitial.instance == null)
		{
			GoogleAdmobInterstitial.instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			this.SetInterstitialID();
			this.LoadInterstitial();
		}
		else if (GoogleAdmobInterstitial.instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x00025D2E File Offset: 0x0002412E
	private void SetInterstitialID()
	{
		this._interstitialID = "ca-app-pub-3398049612144040/4059017408";
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x00025D3C File Offset: 0x0002413C
	private void LoadInterstitial()
	{
		this.DestroyInterstitial();
		Debug.Log("-------------------interstitialID " + this._interstitialID);
		this.m_interstitial = new InterstitialAd(this._interstitialID);
		AdRequest request = new AdRequest.Builder().Build();
		this.m_interstitial.OnAdLoaded += this.OnInterstitialLoad;
		this.m_interstitial.OnAdFailedToLoad += this.OnInterstitialFailedToLoad;
		this.m_interstitial.OnAdClosed += this.OnInterstitialClosed;
		this.m_interstitial.LoadAd(request);
		Debug.Log("Start Load Interstitial.");
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x00025DE0 File Offset: 0x000241E0
	public bool ShowInterstitial()
	{
		if (this.m_interstitial != null && this.m_interstitial.IsLoaded())
		{
			Debug.Log("Show Interstitial success");
			this.m_interstitial.Show();
			return true;
		}
		if (this.m_interstitial == null)
		{
			Debug.Log("Show Interstitial failed");
		}
		if (this.m_interstitial != null && !this.m_interstitial.IsLoaded())
		{
			Debug.Log("Show Interstitial Loaded failed");
		}
		return false;
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x00025E5A File Offset: 0x0002425A
	private void DestroyInterstitial()
	{
		if (this.m_interstitial != null)
		{
			this.m_interstitial.Destroy();
			this.m_interstitial = null;
			Debug.Log("Destroy Interstitial.");
		}
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x00025E83 File Offset: 0x00024283
	private void OnInterstitialLoad(object sender, EventArgs args)
	{
		Debug.Log("Load OnInterstitialLoad Finished.");
		this.m_failedLoadBannerViewCount = 0;
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x00025E98 File Offset: 0x00024298
	private void OnInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		this.m_failedLoadInterstitialCount++;
		Debug.Log(string.Concat(new object[]
		{
			"Load OnInterstitialLoad Failed. message = ",
			args.Message,
			" m_failedLoadInterstitialCount = ",
			this.m_failedLoadInterstitialCount
		}));
		if (this.m_failedLoadInterstitialCount < this.m_maxFailedLoadCount)
		{
			this.LoadInterstitial();
		}
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x00025F01 File Offset: 0x00024301
	private void OnInterstitialClosed(object sender, EventArgs args)
	{
		this.DestroyInterstitial();
		this.LoadInterstitial();
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x00025F0F File Offset: 0x0002430F
	private void OnDestroy()
	{
		this.DestroyInterstitial();
	}

	// Token: 0x04000578 RID: 1400
	private static GoogleAdmobInterstitial instance;

	// Token: 0x04000579 RID: 1401
	private string _interstitialID = string.Empty;

	// Token: 0x0400057A RID: 1402
	private int m_failedLoadBannerViewCount;

	// Token: 0x0400057B RID: 1403
	private InterstitialAd m_interstitial;

	// Token: 0x0400057C RID: 1404
	public int m_probabilityShowInterstitial = 75;

	// Token: 0x0400057D RID: 1405
	private int m_failedLoadInterstitialCount;

	// Token: 0x0400057E RID: 1406
	private int m_failedLoadRewardVedioCount;

	// Token: 0x0400057F RID: 1407
	public int m_maxFailedLoadCount = 3;
}
