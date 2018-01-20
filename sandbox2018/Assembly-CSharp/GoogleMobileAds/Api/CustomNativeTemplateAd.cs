using System;
using System.Collections.Generic;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000102 RID: 258
	public class CustomNativeTemplateAd
	{
		// Token: 0x060005FC RID: 1532 RVA: 0x0001C864 File Offset: 0x0001AC64
		internal CustomNativeTemplateAd(ICustomNativeTemplateClient client)
		{
			this.client = client;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0001C873 File Offset: 0x0001AC73
		public List<string> GetAvailableAssetNames()
		{
			return this.client.GetAvailableAssetNames();
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0001C880 File Offset: 0x0001AC80
		public string GetCustomTemplateId()
		{
			return this.client.GetTemplateId();
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0001C890 File Offset: 0x0001AC90
		public Texture2D GetTexture2D(string key)
		{
			byte[] imageByteArray = this.client.GetImageByteArray(key);
			if (imageByteArray == null)
			{
				return null;
			}
			return Utils.GetTexture2DFromByteArray(imageByteArray);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0001C8B8 File Offset: 0x0001ACB8
		public string GetText(string key)
		{
			return this.client.GetText(key);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001C8C6 File Offset: 0x0001ACC6
		public void PerformClick(string assetName)
		{
			this.client.PerformClick(assetName);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0001C8D4 File Offset: 0x0001ACD4
		public void RecordImpression()
		{
			this.client.RecordImpression();
		}

		// Token: 0x040003F6 RID: 1014
		private ICustomNativeTemplateClient client;
	}
}
