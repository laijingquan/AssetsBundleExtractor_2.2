using System;
using GoogleMobileAds.Android;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace GoogleMobileAds
{
	// Token: 0x0200011B RID: 283
	public class GoogleMobileAdsClientFactory
	{
		// Token: 0x0600076E RID: 1902 RVA: 0x0001F6D4 File Offset: 0x0001DAD4
		public static IBannerClient BuildBannerClient()
		{
			return new BannerClient();
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0001F6DB File Offset: 0x0001DADB
		public static IInterstitialClient BuildInterstitialClient()
		{
			return new InterstitialClient();
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0001F6E2 File Offset: 0x0001DAE2
		public static IRewardBasedVideoAdClient BuildRewardBasedVideoAdClient()
		{
			return new RewardBasedVideoAdClient();
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0001F6E9 File Offset: 0x0001DAE9
		public static IAdLoaderClient BuildAdLoaderClient(AdLoader adLoader)
		{
			return new AdLoaderClient(adLoader);
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0001F6F1 File Offset: 0x0001DAF1
		public static INativeExpressAdClient BuildNativeExpressAdClient()
		{
			return new NativeExpressAdClient();
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0001F6F8 File Offset: 0x0001DAF8
		public static IMobileAdsClient MobileAdsInstance()
		{
			return MobileAdsClient.Instance;
		}
	}
}
