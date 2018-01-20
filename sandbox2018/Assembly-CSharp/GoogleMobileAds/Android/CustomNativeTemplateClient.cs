using System;
using System.Collections.Generic;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000115 RID: 277
	internal class CustomNativeTemplateClient : ICustomNativeTemplateClient
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x0001E1E2 File Offset: 0x0001C5E2
		public CustomNativeTemplateClient(AndroidJavaObject customNativeAd)
		{
			this.customNativeAd = customNativeAd;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0001E1F1 File Offset: 0x0001C5F1
		public List<string> GetAvailableAssetNames()
		{
			return new List<string>(this.customNativeAd.Call<string[]>("getAvailableAssetNames", new object[0]));
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0001E20E File Offset: 0x0001C60E
		public string GetTemplateId()
		{
			return this.customNativeAd.Call<string>("getTemplateId", new object[0]);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0001E228 File Offset: 0x0001C628
		public byte[] GetImageByteArray(string key)
		{
			byte[] array = this.customNativeAd.Call<byte[]>("getImage", new object[]
			{
				key
			});
			if (array.Length == 0)
			{
				return null;
			}
			return array;
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0001E25C File Offset: 0x0001C65C
		public string GetText(string key)
		{
			string text = this.customNativeAd.Call<string>("getText", new object[]
			{
				key
			});
			if (text.Equals(string.Empty))
			{
				return null;
			}
			return text;
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0001E297 File Offset: 0x0001C697
		public void PerformClick(string assetName)
		{
			this.customNativeAd.Call("performClick", new object[]
			{
				assetName
			});
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0001E2B3 File Offset: 0x0001C6B3
		public void RecordImpression()
		{
			this.customNativeAd.Call("recordImpression", new object[0]);
		}

		// Token: 0x04000426 RID: 1062
		private AndroidJavaObject customNativeAd;
	}
}
