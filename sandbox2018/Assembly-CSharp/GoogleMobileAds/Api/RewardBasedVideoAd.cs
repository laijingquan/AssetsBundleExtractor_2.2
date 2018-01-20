using System;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000109 RID: 265
	public class RewardBasedVideoAd
	{
		// Token: 0x0600063F RID: 1599 RVA: 0x0001D178 File Offset: 0x0001B578
		private RewardBasedVideoAd()
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildRewardBasedVideoAdClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (IRewardBasedVideoAdClient)method.Invoke(null, null);
			this.client.CreateRewardBasedVideoAd();
			this.client.OnAdLoaded += delegate(object sender, EventArgs args)
			{
				if (this.OnAdLoaded != null)
				{
					this.OnAdLoaded(this, args);
				}
			};
			this.client.OnAdFailedToLoad += delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
			this.client.OnAdOpening += delegate(object sender, EventArgs args)
			{
				if (this.OnAdOpening != null)
				{
					this.OnAdOpening(this, args);
				}
			};
			this.client.OnAdStarted += delegate(object sender, EventArgs args)
			{
				if (this.OnAdStarted != null)
				{
					this.OnAdStarted(this, args);
				}
			};
			this.client.OnAdClosed += delegate(object sender, EventArgs args)
			{
				if (this.OnAdClosed != null)
				{
					this.OnAdClosed(this, args);
				}
			};
			this.client.OnAdLeavingApplication += delegate(object sender, EventArgs args)
			{
				if (this.OnAdLeavingApplication != null)
				{
					this.OnAdLeavingApplication(this, args);
				}
			};
			this.client.OnAdRewarded += delegate(object sender, Reward args)
			{
				if (this.OnAdRewarded != null)
				{
					this.OnAdRewarded(this, args);
				}
			};
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0001D263 File Offset: 0x0001B663
		public static RewardBasedVideoAd Instance
		{
			get
			{
				return RewardBasedVideoAd.instance;
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x06000641 RID: 1601 RVA: 0x0001D26C File Offset: 0x0001B66C
		// (remove) Token: 0x06000642 RID: 1602 RVA: 0x0001D2A4 File Offset: 0x0001B6A4
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x06000643 RID: 1603 RVA: 0x0001D2DC File Offset: 0x0001B6DC
		// (remove) Token: 0x06000644 RID: 1604 RVA: 0x0001D314 File Offset: 0x0001B714
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06000645 RID: 1605 RVA: 0x0001D34C File Offset: 0x0001B74C
		// (remove) Token: 0x06000646 RID: 1606 RVA: 0x0001D384 File Offset: 0x0001B784
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x06000647 RID: 1607 RVA: 0x0001D3BC File Offset: 0x0001B7BC
		// (remove) Token: 0x06000648 RID: 1608 RVA: 0x0001D3F4 File Offset: 0x0001B7F4
		public event EventHandler<EventArgs> OnAdStarted;

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x06000649 RID: 1609 RVA: 0x0001D42C File Offset: 0x0001B82C
		// (remove) Token: 0x0600064A RID: 1610 RVA: 0x0001D464 File Offset: 0x0001B864
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x0600064B RID: 1611 RVA: 0x0001D49C File Offset: 0x0001B89C
		// (remove) Token: 0x0600064C RID: 1612 RVA: 0x0001D4D4 File Offset: 0x0001B8D4
		public event EventHandler<Reward> OnAdRewarded;

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x0600064D RID: 1613 RVA: 0x0001D50C File Offset: 0x0001B90C
		// (remove) Token: 0x0600064E RID: 1614 RVA: 0x0001D544 File Offset: 0x0001B944
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x0600064F RID: 1615 RVA: 0x0001D57A File Offset: 0x0001B97A
		public void LoadAd(AdRequest request, string adUnitId)
		{
			this.client.LoadAd(request, adUnitId);
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001D589 File Offset: 0x0001B989
		public bool IsLoaded()
		{
			return this.client.IsLoaded();
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001D596 File Offset: 0x0001B996
		public void Show()
		{
			this.client.ShowRewardBasedVideoAd();
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0001D5A3 File Offset: 0x0001B9A3
		public string MediationAdapterClassName()
		{
			return this.client.MediationAdapterClassName();
		}

		// Token: 0x0400040B RID: 1035
		private IRewardBasedVideoAdClient client;

		// Token: 0x0400040C RID: 1036
		private static readonly RewardBasedVideoAd instance = new RewardBasedVideoAd();
	}
}
