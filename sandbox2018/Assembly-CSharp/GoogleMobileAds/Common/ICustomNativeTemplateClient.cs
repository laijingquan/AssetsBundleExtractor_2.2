using System;
using System.Collections.Generic;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200010D RID: 269
	public interface ICustomNativeTemplateClient
	{
		// Token: 0x060006A7 RID: 1703
		string GetTemplateId();

		// Token: 0x060006A8 RID: 1704
		byte[] GetImageByteArray(string key);

		// Token: 0x060006A9 RID: 1705
		List<string> GetAvailableAssetNames();

		// Token: 0x060006AA RID: 1706
		string GetText(string key);

		// Token: 0x060006AB RID: 1707
		void PerformClick(string assetName);

		// Token: 0x060006AC RID: 1708
		void RecordImpression();
	}
}
