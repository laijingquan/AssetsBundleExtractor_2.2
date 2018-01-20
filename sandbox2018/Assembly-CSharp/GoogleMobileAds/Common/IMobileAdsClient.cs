using System;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200010F RID: 271
	public interface IMobileAdsClient
	{
		// Token: 0x060006BD RID: 1725
		void Initialize(string appId);

		// Token: 0x060006BE RID: 1726
		void SetApplicationVolume(float volume);

		// Token: 0x060006BF RID: 1727
		void SetApplicationMuted(bool muted);
	}
}
