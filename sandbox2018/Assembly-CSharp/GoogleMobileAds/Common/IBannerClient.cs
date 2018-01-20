using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200010C RID: 268
	public interface IBannerClient
	{
		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06000692 RID: 1682
		// (remove) Token: 0x06000693 RID: 1683
		event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06000694 RID: 1684
		// (remove) Token: 0x06000695 RID: 1685
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x06000696 RID: 1686
		// (remove) Token: 0x06000697 RID: 1687
		event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06000698 RID: 1688
		// (remove) Token: 0x06000699 RID: 1689
		event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x0600069A RID: 1690
		// (remove) Token: 0x0600069B RID: 1691
		event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x0600069C RID: 1692
		void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position);

		// Token: 0x0600069D RID: 1693
		void CreateBannerView(string adUnitId, AdSize adSize, int x, int y);

		// Token: 0x0600069E RID: 1694
		void LoadAd(AdRequest request);

		// Token: 0x0600069F RID: 1695
		void ShowBannerView();

		// Token: 0x060006A0 RID: 1696
		void HideBannerView();

		// Token: 0x060006A1 RID: 1697
		void DestroyBannerView();

		// Token: 0x060006A2 RID: 1698
		float GetHeightInPixels();

		// Token: 0x060006A3 RID: 1699
		float GetWidthInPixels();

		// Token: 0x060006A4 RID: 1700
		void SetPosition(AdPosition adPosition);

		// Token: 0x060006A5 RID: 1701
		void SetPosition(int x, int y);

		// Token: 0x060006A6 RID: 1702
		string MediationAdapterClassName();
	}
}
