using System;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000113 RID: 275
	public class AdLoaderClient : AndroidJavaProxy, IAdLoaderClient
	{
		// Token: 0x060006E6 RID: 1766 RVA: 0x0001DAA0 File Offset: 0x0001BEA0
		public AdLoaderClient(AdLoader unityAdLoader) : base("com.google.unity.ads.UnityAdLoaderListener")
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			this.adLoader = new AndroidJavaObject("com.google.unity.ads.NativeAdLoader", new object[]
			{
				@static,
				unityAdLoader.AdUnitId,
				this
			});
			this.CustomNativeTemplateCallbacks = unityAdLoader.CustomNativeTemplateClickHandlers;
			if (unityAdLoader.AdTypes.Contains(NativeAdType.CustomTemplate))
			{
				foreach (string text in unityAdLoader.TemplateIds)
				{
					this.adLoader.Call("configureCustomNativeTemplateAd", new object[]
					{
						text,
						this.CustomNativeTemplateCallbacks.ContainsKey(text)
					});
				}
			}
			this.adLoader.Call("create", new object[0]);
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x0001DBA0 File Offset: 0x0001BFA0
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x0001DBA8 File Offset: 0x0001BFA8
		private Dictionary<string, Action<CustomNativeTemplateAd, string>> CustomNativeTemplateCallbacks { get; set; }

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x060006E9 RID: 1769 RVA: 0x0001DBB4 File Offset: 0x0001BFB4
		// (remove) Token: 0x060006EA RID: 1770 RVA: 0x0001DBEC File Offset: 0x0001BFEC
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x060006EB RID: 1771 RVA: 0x0001DC24 File Offset: 0x0001C024
		// (remove) Token: 0x060006EC RID: 1772 RVA: 0x0001DC5C File Offset: 0x0001C05C
		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded;

		// Token: 0x060006ED RID: 1773 RVA: 0x0001DC92 File Offset: 0x0001C092
		public void LoadAd(AdRequest request)
		{
			this.adLoader.Call("loadAd", new object[]
			{
				Utils.GetAdRequestJavaObject(request)
			});
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0001DCB4 File Offset: 0x0001C0B4
		public void onCustomTemplateAdLoaded(AndroidJavaObject ad)
		{
			if (this.OnCustomNativeTemplateAdLoaded != null)
			{
				CustomNativeEventArgs e = new CustomNativeEventArgs
				{
					nativeAd = new CustomNativeTemplateAd(new CustomNativeTemplateClient(ad))
				};
				this.OnCustomNativeTemplateAdLoaded(this, e);
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0001DCF4 File Offset: 0x0001C0F4
		private void onAdFailedToLoad(string errorReason)
		{
			AdFailedToLoadEventArgs e = new AdFailedToLoadEventArgs
			{
				Message = errorReason
			};
			this.OnAdFailedToLoad(this, e);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001DD20 File Offset: 0x0001C120
		public void onCustomClick(AndroidJavaObject ad, string assetName)
		{
			CustomNativeTemplateAd customNativeTemplateAd = new CustomNativeTemplateAd(new CustomNativeTemplateClient(ad));
			this.CustomNativeTemplateCallbacks[customNativeTemplateAd.GetCustomTemplateId()](customNativeTemplateAd, assetName);
		}

		// Token: 0x0400041C RID: 1052
		private AndroidJavaObject adLoader;
	}
}
