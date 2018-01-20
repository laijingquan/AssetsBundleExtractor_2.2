using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x02000110 RID: 272
	public interface INativeExpressAdClient
	{
		// Token: 0x14000054 RID: 84
		// (add) Token: 0x060006C0 RID: 1728
		// (remove) Token: 0x060006C1 RID: 1729
		event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x060006C2 RID: 1730
		// (remove) Token: 0x060006C3 RID: 1731
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x060006C4 RID: 1732
		// (remove) Token: 0x060006C5 RID: 1733
		event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x060006C6 RID: 1734
		// (remove) Token: 0x060006C7 RID: 1735
		event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x060006C8 RID: 1736
		// (remove) Token: 0x060006C9 RID: 1737
		event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x060006CA RID: 1738
		void CreateNativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position);

		// Token: 0x060006CB RID: 1739
		void CreateNativeExpressAdView(string adUnitId, AdSize adSize, int x, int y);

		// Token: 0x060006CC RID: 1740
		void LoadAd(AdRequest request);

		// Token: 0x060006CD RID: 1741
		void ShowNativeExpressAdView();

		// Token: 0x060006CE RID: 1742
		void HideNativeExpressAdView();

		// Token: 0x060006CF RID: 1743
		void DestroyNativeExpressAdView();

		// Token: 0x060006D0 RID: 1744
		string MediationAdapterClassName();
	}
}
