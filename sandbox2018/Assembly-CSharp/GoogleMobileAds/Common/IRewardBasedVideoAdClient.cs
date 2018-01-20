using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x02000111 RID: 273
	public interface IRewardBasedVideoAdClient
	{
		// Token: 0x14000059 RID: 89
		// (add) Token: 0x060006D1 RID: 1745
		// (remove) Token: 0x060006D2 RID: 1746
		event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400005A RID: 90
		// (add) Token: 0x060006D3 RID: 1747
		// (remove) Token: 0x060006D4 RID: 1748
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x060006D5 RID: 1749
		// (remove) Token: 0x060006D6 RID: 1750
		event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x060006D7 RID: 1751
		// (remove) Token: 0x060006D8 RID: 1752
		event EventHandler<EventArgs> OnAdStarted;

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x060006D9 RID: 1753
		// (remove) Token: 0x060006DA RID: 1754
		event EventHandler<Reward> OnAdRewarded;

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x060006DB RID: 1755
		// (remove) Token: 0x060006DC RID: 1756
		event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x060006DD RID: 1757
		// (remove) Token: 0x060006DE RID: 1758
		event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x060006DF RID: 1759
		void CreateRewardBasedVideoAd();

		// Token: 0x060006E0 RID: 1760
		void LoadAd(AdRequest request, string adUnitId);

		// Token: 0x060006E1 RID: 1761
		bool IsLoaded();

		// Token: 0x060006E2 RID: 1762
		string MediationAdapterClassName();

		// Token: 0x060006E3 RID: 1763
		void ShowRewardBasedVideoAd();
	}
}
