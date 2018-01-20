using System;
using GoogleMobileAds.Api;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200010B RID: 267
	public interface IAdLoaderClient
	{
		// Token: 0x14000048 RID: 72
		// (add) Token: 0x0600068D RID: 1677
		// (remove) Token: 0x0600068E RID: 1678
		event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x0600068F RID: 1679
		// (remove) Token: 0x06000690 RID: 1680
		event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded;

		// Token: 0x06000691 RID: 1681
		void LoadAd(AdRequest request);
	}
}
