using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200010E RID: 270
	public interface IInterstitialClient
	{
		// Token: 0x1400004F RID: 79
		// (add) Token: 0x060006AD RID: 1709
		// (remove) Token: 0x060006AE RID: 1710
		event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x060006AF RID: 1711
		// (remove) Token: 0x060006B0 RID: 1712
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x060006B1 RID: 1713
		// (remove) Token: 0x060006B2 RID: 1714
		event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x060006B3 RID: 1715
		// (remove) Token: 0x060006B4 RID: 1716
		event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x060006B5 RID: 1717
		// (remove) Token: 0x060006B6 RID: 1718
		event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x060006B7 RID: 1719
		void CreateInterstitialAd(string adUnitId);

		// Token: 0x060006B8 RID: 1720
		void LoadAd(AdRequest request);

		// Token: 0x060006B9 RID: 1721
		bool IsLoaded();

		// Token: 0x060006BA RID: 1722
		void ShowInterstitial();

		// Token: 0x060006BB RID: 1723
		void DestroyInterstitial();

		// Token: 0x060006BC RID: 1724
		string MediationAdapterClassName();
	}
}
