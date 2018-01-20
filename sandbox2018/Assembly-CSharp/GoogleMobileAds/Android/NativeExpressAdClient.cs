using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000118 RID: 280
	public class NativeExpressAdClient : AndroidJavaProxy, INativeExpressAdClient
	{
		// Token: 0x0600072F RID: 1839 RVA: 0x0001E764 File Offset: 0x0001CB64
		public NativeExpressAdClient() : base("com.google.unity.ads.UnityAdListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.nativeExpressAdView = new AndroidJavaObject("com.google.unity.ads.NativeExpressAd", new object[]
			{
				@static,
				this
			});
		}

		// Token: 0x1400006C RID: 108
		// (add) Token: 0x06000730 RID: 1840 RVA: 0x0001E7B4 File Offset: 0x0001CBB4
		// (remove) Token: 0x06000731 RID: 1841 RVA: 0x0001E7EC File Offset: 0x0001CBEC
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400006D RID: 109
		// (add) Token: 0x06000732 RID: 1842 RVA: 0x0001E824 File Offset: 0x0001CC24
		// (remove) Token: 0x06000733 RID: 1843 RVA: 0x0001E85C File Offset: 0x0001CC5C
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400006E RID: 110
		// (add) Token: 0x06000734 RID: 1844 RVA: 0x0001E894 File Offset: 0x0001CC94
		// (remove) Token: 0x06000735 RID: 1845 RVA: 0x0001E8CC File Offset: 0x0001CCCC
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400006F RID: 111
		// (add) Token: 0x06000736 RID: 1846 RVA: 0x0001E904 File Offset: 0x0001CD04
		// (remove) Token: 0x06000737 RID: 1847 RVA: 0x0001E93C File Offset: 0x0001CD3C
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000070 RID: 112
		// (add) Token: 0x06000738 RID: 1848 RVA: 0x0001E974 File Offset: 0x0001CD74
		// (remove) Token: 0x06000739 RID: 1849 RVA: 0x0001E9AC File Offset: 0x0001CDAC
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x0600073A RID: 1850 RVA: 0x0001E9E2 File Offset: 0x0001CDE2
		public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position)
		{
			this.nativeExpressAdView.Call("create", new object[]
			{
				adUnitId,
				Utils.GetAdSizeJavaObject(adSize),
				(int)position
			});
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0001EA10 File Offset: 0x0001CE10
		public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, int x, int y)
		{
			this.nativeExpressAdView.Call("create", new object[]
			{
				adUnitId,
				Utils.GetAdSizeJavaObject(adSize),
				x,
				y
			});
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0001EA48 File Offset: 0x0001CE48
		public void LoadAd(AdRequest request)
		{
			this.nativeExpressAdView.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request)
			});
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0001EA69 File Offset: 0x0001CE69
		public void SetAdSize(AdSize adSize)
		{
			this.nativeExpressAdView.Call("setAdSize", new object[]
			{
				Utils.GetAdSizeJavaObject(adSize)
			});
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0001EA8A File Offset: 0x0001CE8A
		public void ShowNativeExpressAdView()
		{
			this.nativeExpressAdView.Call("show", new object[0]);
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0001EAA2 File Offset: 0x0001CEA2
		public void HideNativeExpressAdView()
		{
			this.nativeExpressAdView.Call("hide", new object[0]);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0001EABA File Offset: 0x0001CEBA
		public void DestroyNativeExpressAdView()
		{
			this.nativeExpressAdView.Call("destroy", new object[0]);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0001EAD2 File Offset: 0x0001CED2
		public string MediationAdapterClassName()
		{
			return this.nativeExpressAdView.Call<string>("getMediationAdapterClassName", new object[0]);
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0001EAEA File Offset: 0x0001CEEA
		public void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0001EB08 File Offset: 0x0001CF08
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

		// Token: 0x06000744 RID: 1860 RVA: 0x0001EB3C File Offset: 0x0001CF3C
		public void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0001EB5A File Offset: 0x0001CF5A
		public void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0001EB78 File Offset: 0x0001CF78
		public void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		// Token: 0x0400042E RID: 1070
		private AndroidJavaObject nativeExpressAdView;
	}
}
