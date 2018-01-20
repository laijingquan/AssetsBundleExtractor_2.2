using System;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000119 RID: 281
	public class RewardBasedVideoAdClient : AndroidJavaProxy, IRewardBasedVideoAdClient
	{
		// Token: 0x06000747 RID: 1863 RVA: 0x0001EB98 File Offset: 0x0001CF98
		public RewardBasedVideoAdClient() : base("com.google.unity.ads.UnityRewardBasedVideoAdListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.androidRewardBasedVideo = new AndroidJavaObject("com.google.unity.ads.RewardBasedVideo", new object[]
			{
				@static,
				this
			});
		}

		// Token: 0x14000071 RID: 113
		// (add) Token: 0x06000748 RID: 1864 RVA: 0x0001ECDC File Offset: 0x0001D0DC
		// (remove) Token: 0x06000749 RID: 1865 RVA: 0x0001ED14 File Offset: 0x0001D114
		public event EventHandler<EventArgs> OnAdLoaded = delegate
		{
		};

		// Token: 0x14000072 RID: 114
		// (add) Token: 0x0600074A RID: 1866 RVA: 0x0001ED4C File Offset: 0x0001D14C
		// (remove) Token: 0x0600074B RID: 1867 RVA: 0x0001ED84 File Offset: 0x0001D184
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad = delegate
		{
		};

		// Token: 0x14000073 RID: 115
		// (add) Token: 0x0600074C RID: 1868 RVA: 0x0001EDBC File Offset: 0x0001D1BC
		// (remove) Token: 0x0600074D RID: 1869 RVA: 0x0001EDF4 File Offset: 0x0001D1F4
		public event EventHandler<EventArgs> OnAdOpening = delegate
		{
		};

		// Token: 0x14000074 RID: 116
		// (add) Token: 0x0600074E RID: 1870 RVA: 0x0001EE2C File Offset: 0x0001D22C
		// (remove) Token: 0x0600074F RID: 1871 RVA: 0x0001EE64 File Offset: 0x0001D264
		public event EventHandler<EventArgs> OnAdStarted = delegate
		{
		};

		// Token: 0x14000075 RID: 117
		// (add) Token: 0x06000750 RID: 1872 RVA: 0x0001EE9C File Offset: 0x0001D29C
		// (remove) Token: 0x06000751 RID: 1873 RVA: 0x0001EED4 File Offset: 0x0001D2D4
		public event EventHandler<EventArgs> OnAdClosed = delegate
		{
		};

		// Token: 0x14000076 RID: 118
		// (add) Token: 0x06000752 RID: 1874 RVA: 0x0001EF0C File Offset: 0x0001D30C
		// (remove) Token: 0x06000753 RID: 1875 RVA: 0x0001EF44 File Offset: 0x0001D344
		public event EventHandler<Reward> OnAdRewarded = delegate
		{
		};

		// Token: 0x14000077 RID: 119
		// (add) Token: 0x06000754 RID: 1876 RVA: 0x0001EF7C File Offset: 0x0001D37C
		// (remove) Token: 0x06000755 RID: 1877 RVA: 0x0001EFB4 File Offset: 0x0001D3B4
		public event EventHandler<EventArgs> OnAdLeavingApplication = delegate
		{
		};

		// Token: 0x06000756 RID: 1878 RVA: 0x0001EFEA File Offset: 0x0001D3EA
		public void CreateRewardBasedVideoAd()
		{
			this.androidRewardBasedVideo.Call("create", new object[0]);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0001F002 File Offset: 0x0001D402
		public void LoadAd(AdRequest request, string adUnitId)
		{
			this.androidRewardBasedVideo.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request),
				adUnitId
			});
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0001F027 File Offset: 0x0001D427
		public bool IsLoaded()
		{
			return this.androidRewardBasedVideo.Call<bool>("isLoaded", new object[0]);
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0001F03F File Offset: 0x0001D43F
		public void ShowRewardBasedVideoAd()
		{
			this.androidRewardBasedVideo.Call("show", new object[0]);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0001F057 File Offset: 0x0001D457
		public void DestroyRewardBasedVideoAd()
		{
			this.androidRewardBasedVideo.Call("destroy", new object[0]);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0001F06F File Offset: 0x0001D46F
		public string MediationAdapterClassName()
		{
			return this.androidRewardBasedVideo.Call<string>("getMediationAdapterClassName", new object[0]);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0001F087 File Offset: 0x0001D487
		private void onAdLoaded()
		{
			if (this.OnAdLoaded != null)
			{
				this.OnAdLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0001F0A8 File Offset: 0x0001D4A8
		private void onAdFailedToLoad(string errorReason)
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

		// Token: 0x0600075E RID: 1886 RVA: 0x0001F0DC File Offset: 0x0001D4DC
		private void onAdOpened()
		{
			if (this.OnAdOpening != null)
			{
				this.OnAdOpening(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0001F0FA File Offset: 0x0001D4FA
		private void onAdStarted()
		{
			if (this.OnAdStarted != null)
			{
				this.OnAdStarted(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0001F118 File Offset: 0x0001D518
		private void onAdClosed()
		{
			if (this.OnAdClosed != null)
			{
				this.OnAdClosed(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0001F138 File Offset: 0x0001D538
		private void onAdRewarded(string type, float amount)
		{
			if (this.OnAdRewarded != null)
			{
				Reward e = new Reward
				{
					Type = type,
					Amount = (double)amount
				};
				this.OnAdRewarded(this, e);
			}
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0001F174 File Offset: 0x0001D574
		private void onAdLeftApplication()
		{
			if (this.OnAdLeavingApplication != null)
			{
				this.OnAdLeavingApplication(this, EventArgs.Empty);
			}
		}

		// Token: 0x04000434 RID: 1076
		private AndroidJavaObject androidRewardBasedVideo;
	}
}
