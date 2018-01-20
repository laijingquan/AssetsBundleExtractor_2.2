using System;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x02000117 RID: 279
	public class MobileAdsClient : IMobileAdsClient
	{
		// Token: 0x06000729 RID: 1833 RVA: 0x0001E696 File Offset: 0x0001CA96
		private MobileAdsClient()
		{
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x0001E69E File Offset: 0x0001CA9E
		public static MobileAdsClient Instance
		{
			get
			{
				return MobileAdsClient.instance;
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0001E6A8 File Offset: 0x0001CAA8
		public void Initialize(string appId)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			androidJavaClass2.CallStatic("initialize", new object[]
			{
				@static,
				appId
			});
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0001E6F0 File Offset: 0x0001CAF0
		public void SetApplicationVolume(float volume)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			androidJavaClass.CallStatic("setAppVolume", new object[]
			{
				volume
			});
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0001E724 File Offset: 0x0001CB24
		public void SetApplicationMuted(bool muted)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.MobileAds");
			androidJavaClass.CallStatic("setAppMuted", new object[]
			{
				muted
			});
		}

		// Token: 0x0400042D RID: 1069
		private static MobileAdsClient instance = new MobileAdsClient();
	}
}
