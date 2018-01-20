using System;
using System.Collections.Generic;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x020000FA RID: 250
	public class AdLoader
	{
		// Token: 0x06000596 RID: 1430 RVA: 0x0001BE1C File Offset: 0x0001A21C
		private AdLoader(AdLoader.Builder builder)
		{
			this.AdUnitId = string.Copy(builder.AdUnitId);
			this.CustomNativeTemplateClickHandlers = new Dictionary<string, Action<CustomNativeTemplateAd, string>>(builder.CustomNativeTemplateClickHandlers);
			this.TemplateIds = new HashSet<string>(builder.TemplateIds);
			this.AdTypes = new HashSet<NativeAdType>(builder.AdTypes);
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildAdLoaderClient", BindingFlags.Static | BindingFlags.Public);
			this.adLoaderClient = (IAdLoaderClient)method.Invoke(null, new object[]
			{
				this
			});
			this.adLoaderClient.OnCustomNativeTemplateAdLoaded += delegate(object sender, CustomNativeEventArgs args)
			{
				if (this.OnCustomNativeTemplateAdLoaded != null)
				{
					this.OnCustomNativeTemplateAdLoaded(this, args);
				}
			};
			this.adLoaderClient.OnAdFailedToLoad += delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000597 RID: 1431 RVA: 0x0001BED8 File Offset: 0x0001A2D8
		// (remove) Token: 0x06000598 RID: 1432 RVA: 0x0001BF10 File Offset: 0x0001A310
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000599 RID: 1433 RVA: 0x0001BF48 File Offset: 0x0001A348
		// (remove) Token: 0x0600059A RID: 1434 RVA: 0x0001BF80 File Offset: 0x0001A380
		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded;

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x0001BFB6 File Offset: 0x0001A3B6
		// (set) Token: 0x0600059C RID: 1436 RVA: 0x0001BFBE File Offset: 0x0001A3BE
		public Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateClickHandlers { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0001BFC7 File Offset: 0x0001A3C7
		// (set) Token: 0x0600059E RID: 1438 RVA: 0x0001BFCF File Offset: 0x0001A3CF
		public string AdUnitId { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0001BFD8 File Offset: 0x0001A3D8
		// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0001BFE0 File Offset: 0x0001A3E0
		public HashSet<NativeAdType> AdTypes { get; private set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0001BFE9 File Offset: 0x0001A3E9
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0001BFF1 File Offset: 0x0001A3F1
		public HashSet<string> TemplateIds { get; private set; }

		// Token: 0x060005A3 RID: 1443 RVA: 0x0001BFFA File Offset: 0x0001A3FA
		public void LoadAd(AdRequest request)
		{
			this.adLoaderClient.LoadAd(request);
		}

		// Token: 0x040003C3 RID: 963
		private IAdLoaderClient adLoaderClient;

		// Token: 0x020000FB RID: 251
		public class Builder
		{
			// Token: 0x060005A6 RID: 1446 RVA: 0x0001C03C File Offset: 0x0001A43C
			public Builder(string adUnitId)
			{
				this.AdUnitId = adUnitId;
				this.AdTypes = new HashSet<NativeAdType>();
				this.TemplateIds = new HashSet<string>();
				this.CustomNativeTemplateClickHandlers = new Dictionary<string, Action<CustomNativeTemplateAd, string>>();
			}

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0001C06C File Offset: 0x0001A46C
			// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0001C074 File Offset: 0x0001A474
			internal string AdUnitId { get; private set; }

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0001C07D File Offset: 0x0001A47D
			// (set) Token: 0x060005AA RID: 1450 RVA: 0x0001C085 File Offset: 0x0001A485
			internal HashSet<NativeAdType> AdTypes { get; private set; }

			// Token: 0x1700004A RID: 74
			// (get) Token: 0x060005AB RID: 1451 RVA: 0x0001C08E File Offset: 0x0001A48E
			// (set) Token: 0x060005AC RID: 1452 RVA: 0x0001C096 File Offset: 0x0001A496
			internal HashSet<string> TemplateIds { get; private set; }

			// Token: 0x1700004B RID: 75
			// (get) Token: 0x060005AD RID: 1453 RVA: 0x0001C09F File Offset: 0x0001A49F
			// (set) Token: 0x060005AE RID: 1454 RVA: 0x0001C0A7 File Offset: 0x0001A4A7
			internal Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateClickHandlers { get; private set; }

			// Token: 0x060005AF RID: 1455 RVA: 0x0001C0B0 File Offset: 0x0001A4B0
			public AdLoader.Builder ForCustomNativeAd(string templateId)
			{
				this.TemplateIds.Add(templateId);
				this.AdTypes.Add(NativeAdType.CustomTemplate);
				return this;
			}

			// Token: 0x060005B0 RID: 1456 RVA: 0x0001C0CD File Offset: 0x0001A4CD
			public AdLoader.Builder ForCustomNativeAd(string templateId, Action<CustomNativeTemplateAd, string> callback)
			{
				this.TemplateIds.Add(templateId);
				this.CustomNativeTemplateClickHandlers[templateId] = callback;
				this.AdTypes.Add(NativeAdType.CustomTemplate);
				return this;
			}

			// Token: 0x060005B1 RID: 1457 RVA: 0x0001C0F7 File Offset: 0x0001A4F7
			public AdLoader Build()
			{
				return new AdLoader(this);
			}
		}
	}
}
