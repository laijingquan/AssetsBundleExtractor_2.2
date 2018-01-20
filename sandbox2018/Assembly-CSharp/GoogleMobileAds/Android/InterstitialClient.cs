using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000116 RID: 278
	public class InterstitialClient : AndroidJavaProxy, IInterstitialClient
	{
		// Token: 0x06000713 RID: 1811 RVA: 0x0001E2CC File Offset: 0x0001C6CC
		public InterstitialClient() : base("com.google.unity.ads.UnityAdListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.interstitial = new AndroidJavaObject("com.google.unity.ads.Interstitial", new object[]
			{
				@static,
				this
			});
		}

		// Token: 0x14000067 RID: 103
		// (add) Token: 0x06000714 RID: 1812 RVA: 0x0001E31C File Offset: 0x0001C71C
		// (remove) Token: 0x06000715 RID: 1813 RVA: 0x0001E354 File Offset: 0x0001C754
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000068 RID: 104
		// (add) Token: 0x06000716 RID: 1814 RVA: 0x0001E38C File Offset: 0x0001C78C
		// (remove) Token: 0x06000717 RID: 1815 RVA: 0x0001E3C4 File Offset: 0x0001C7C4
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000069 RID: 105
		// (add) Token: 0x06000718 RID: 1816 RVA: 0x0001E3FC File Offset: 0x0001C7FC
		// (remove) Token: 0x06000719 RID: 1817 RVA: 0x0001E434 File Offset: 0x0001C834
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400006A RID: 106
		// (add) Token: 0x0600071A RID: 1818 RVA: 0x0001E46C File Offset: 0x0001C86C
		// (remove) Token: 0x0600071B RID: 1819 RVA: 0x0001E4A4 File Offset: 0x0001C8A4
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400006B RID: 107
		// (add) Token: 0x0600071C RID: 1820 RVA: 0x0001E4DC File Offset: 0x0001C8DC
		// (remove) Token: 0x0600071D RID: 1821 RVA: 0x0001E514 File Offset: 0x0001C914
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x0600071E RID: 1822 RVA: 0x0001E54A File Offset: 0x0001C94A
		public void CreateInterstitialAd(string adUnitId)
		{
			this.interstitial.Call("create", new object[]
			{
				adUnitId
			});
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0001E566 File Offset: 0x0001C966
		public void LoadAd(AdRequest request)
		{
			this.interstitial.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request)
			});
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0001E587 File Offset: 0x0001C987
		public bool IsLoaded()
		{
			return this.interstitial.Call<bool>("isLoaded", new object[0]);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0001E59F File Offset: 0x0001C99F
		public void ShowInterstitial()
		{
			this.interstitial.Call("show", new object[0]);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0001E5B7 File Offset: 0x0001C9B7
		public void DestroyInterstitial()
		{
			this.interstitial.Call("destroy", new object[0]);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0001E5CF File Offset: 0x0001C9CF
		public string MediationAdapterClassName()
		{
			return this.interstitial.Call<string>("getMediationAdapterClassName", new object[0]);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0001E5E7 File Offset: 0x0001C9E7
		public void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0001E608 File Offset: 0x0001CA08
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

		// Token: 0x06000726 RID: 1830 RVA: 0x0001E63C File Offset: 0x0001CA3C
		public void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0001E65A File Offset: 0x0001CA5A
		public void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x0001E678 File Offset: 0x0001CA78
		public void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		// Token: 0x04000427 RID: 1063
		private AndroidJavaObject interstitial;
	}
}
