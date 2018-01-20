using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000114 RID: 276
	public class BannerClient : AndroidJavaProxy, IBannerClient
	{
		// Token: 0x060006F1 RID: 1777 RVA: 0x0001DD54 File Offset: 0x0001C154
		public BannerClient() : base("com.google.unity.ads.UnityAdListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.bannerView = new AndroidJavaObject("com.google.unity.ads.Banner", new object[]
			{
				@static,
				this
			});
		}

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x060006F2 RID: 1778 RVA: 0x0001DDA4 File Offset: 0x0001C1A4
		// (remove) Token: 0x060006F3 RID: 1779 RVA: 0x0001DDDC File Offset: 0x0001C1DC
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000063 RID: 99
		// (add) Token: 0x060006F4 RID: 1780 RVA: 0x0001DE14 File Offset: 0x0001C214
		// (remove) Token: 0x060006F5 RID: 1781 RVA: 0x0001DE4C File Offset: 0x0001C24C
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000064 RID: 100
		// (add) Token: 0x060006F6 RID: 1782 RVA: 0x0001DE84 File Offset: 0x0001C284
		// (remove) Token: 0x060006F7 RID: 1783 RVA: 0x0001DEBC File Offset: 0x0001C2BC
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000065 RID: 101
		// (add) Token: 0x060006F8 RID: 1784 RVA: 0x0001DEF4 File Offset: 0x0001C2F4
		// (remove) Token: 0x060006F9 RID: 1785 RVA: 0x0001DF2C File Offset: 0x0001C32C
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000066 RID: 102
		// (add) Token: 0x060006FA RID: 1786 RVA: 0x0001DF64 File Offset: 0x0001C364
		// (remove) Token: 0x060006FB RID: 1787 RVA: 0x0001DF9C File Offset: 0x0001C39C
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x060006FC RID: 1788 RVA: 0x0001DFD2 File Offset: 0x0001C3D2
		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			this.bannerView.Call("create", new object[]
			{
				adUnitId,
				Utils.GetAdSizeJavaObject(adSize),
				(int)position
			});
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0001E000 File Offset: 0x0001C400
		public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
		{
			this.bannerView.Call("create", new object[]
			{
				adUnitId,
				Utils.GetAdSizeJavaObject(adSize),
				x,
				y
			});
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0001E038 File Offset: 0x0001C438
		public void LoadAd(AdRequest request)
		{
			this.bannerView.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request)
			});
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0001E059 File Offset: 0x0001C459
		public void ShowBannerView()
		{
			this.bannerView.Call("show", new object[0]);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0001E071 File Offset: 0x0001C471
		public void HideBannerView()
		{
			this.bannerView.Call("hide", new object[0]);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0001E089 File Offset: 0x0001C489
		public void DestroyBannerView()
		{
			this.bannerView.Call("destroy", new object[0]);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0001E0A1 File Offset: 0x0001C4A1
		public float GetHeightInPixels()
		{
			return this.bannerView.Call<float>("getHeightInPixels", new object[0]);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0001E0B9 File Offset: 0x0001C4B9
		public float GetWidthInPixels()
		{
			return this.bannerView.Call<float>("getWidthInPixels", new object[0]);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0001E0D1 File Offset: 0x0001C4D1
		public void SetPosition(AdPosition adPosition)
		{
			this.bannerView.Call("setPosition", new object[]
			{
				(int)adPosition
			});
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0001E0F2 File Offset: 0x0001C4F2
		public void SetPosition(int x, int y)
		{
			this.bannerView.Call("setPosition", new object[]
			{
				x,
				y
			});
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0001E11C File Offset: 0x0001C51C
		public string MediationAdapterClassName()
		{
			return this.bannerView.Call<string>("getMediationAdapterClassName", new object[0]);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0001E134 File Offset: 0x0001C534
		public void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x0001E154 File Offset: 0x0001C554
		public void onAdFailedToLoad(string errorReason)
		{
			if (this.OnAdFailedToLoad != null)
			{
				AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs
				{
					Message = errorReason
				};
				this.OnAdFailedToLoad(this, e);
			}
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x0001E188 File Offset: 0x0001C588
		public void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x0001E1A6 File Offset: 0x0001C5A6
		public void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x0001E1C4 File Offset: 0x0001C5C4
		public void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		// Token: 0x04000420 RID: 1056
		private AndroidJavaObject bannerView;
	}
}
