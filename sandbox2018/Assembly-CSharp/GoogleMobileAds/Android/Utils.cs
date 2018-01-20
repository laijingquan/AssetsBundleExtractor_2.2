using System;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Api.Mediation;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	// Token: 0x0200011A RID: 282
	internal class Utils
	{
		// Token: 0x0600076B RID: 1899 RVA: 0x0001F1A8 File Offset: 0x0001D5A8
		public static AndroidJavaObject GetAdSizeJavaObject(AdSize adSize)
		{
			if (adSize.IsSmartBanner)
			{
				return new AndroidJavaClass("com.google.android.gms.ads.AdSize").GetStatic<AndroidJavaObject>("SMART_BANNER");
			}
			return new AndroidJavaObject("com.google.android.gms.ads.AdSize", new object[]
			{
				adSize.Width,
				adSize.Height
			});
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0001F204 File Offset: 0x0001D604
		public static AndroidJavaObject GetAdRequestJavaObject(AdRequest request)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.android.gms.ads.AdRequest$Builder", new object[0]);
			foreach (string text in request.Keywords)
			{
				androidJavaObject.Call<AndroidJavaObject>("addKeyword", new object[]
				{
					text
				});
			}
			foreach (string text2 in request.TestDevices)
			{
				if (text2 == "SIMULATOR")
				{
					string @static = new AndroidJavaClass("com.google.android.gms.ads.AdRequest").GetStatic<string>("DEVICE_ID_EMULATOR");
					androidJavaObject.Call<AndroidJavaObject>("addTestDevice", new object[]
					{
						@static
					});
				}
				else
				{
					androidJavaObject.Call<AndroidJavaObject>("addTestDevice", new object[]
					{
						text2
					});
				}
			}
			if (request.Birthday != null)
			{
				DateTime valueOrDefault = request.Birthday.GetValueOrDefault();
				AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.util.Date", new object[]
				{
					valueOrDefault.Year,
					valueOrDefault.Month,
					valueOrDefault.Day
				});
				androidJavaObject.Call<AndroidJavaObject>("setBirthday", new object[]
				{
					androidJavaObject2
				});
			}
			if (request.Gender != null)
			{
				int? num = null;
				Gender valueOrDefault2 = request.Gender.GetValueOrDefault();
				if (valueOrDefault2 != Gender.Unknown)
				{
					if (valueOrDefault2 != Gender.Male)
					{
						if (valueOrDefault2 == Gender.Female)
						{
							num = new int?(new AndroidJavaClass("com.google.android.gms.ads.AdRequest").GetStatic<int>("GENDER_FEMALE"));
						}
					}
					else
					{
						num = new int?(new AndroidJavaClass("com.google.android.gms.ads.AdRequest").GetStatic<int>("GENDER_MALE"));
					}
				}
				else
				{
					num = new int?(new AndroidJavaClass("com.google.android.gms.ads.AdRequest").GetStatic<int>("GENDER_UNKNOWN"));
				}
				if (num != null)
				{
					androidJavaObject.Call<AndroidJavaObject>("setGender", new object[]
					{
						num
					});
				}
			}
			if (request.TagForChildDirectedTreatment != null)
			{
				androidJavaObject.Call<AndroidJavaObject>("tagForChildDirectedTreatment", new object[]
				{
					request.TagForChildDirectedTreatment.GetValueOrDefault()
				});
			}
			androidJavaObject.Call<AndroidJavaObject>("setRequestAgent", new object[]
			{
				"unity-3.10.0"
			});
			AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("android.os.Bundle", new object[0]);
			foreach (KeyValuePair<string, string> keyValuePair in request.Extras)
			{
				androidJavaObject3.Call("putString", new object[]
				{
					keyValuePair.Key,
					keyValuePair.Value
				});
			}
			androidJavaObject3.Call("putString", new object[]
			{
				"is_unity",
				"1"
			});
			AndroidJavaObject androidJavaObject4 = new AndroidJavaObject("com.google.android.gms.ads.mediation.admob.AdMobExtras", new object[]
			{
				androidJavaObject3
			});
			androidJavaObject.Call<AndroidJavaObject>("addNetworkExtras", new object[]
			{
				androidJavaObject4
			});
			foreach (MediationExtras mediationExtras in request.MediationExtras)
			{
				AndroidJavaObject androidJavaObject5 = new AndroidJavaObject(mediationExtras.AndroidMediationExtraBuilderClassName, new object[0]);
				AndroidJavaObject androidJavaObject6 = new AndroidJavaObject("java.util.HashMap", new object[0]);
				foreach (KeyValuePair<string, string> keyValuePair2 in mediationExtras.Extras)
				{
					androidJavaObject6.Call<string>("put", new object[]
					{
						keyValuePair2.Key,
						keyValuePair2.Value
					});
				}
				AndroidJavaObject androidJavaObject7 = androidJavaObject5.Call<AndroidJavaObject>("buildExtras", new object[]
				{
					androidJavaObject6
				});
				if (androidJavaObject7 != null)
				{
					androidJavaObject.Call<AndroidJavaObject>("addNetworkExtrasBundle", new object[]
					{
						androidJavaObject5.Call<AndroidJavaClass>("getAdapterClass", new object[0]),
						androidJavaObject7
					});
				}
			}
			return androidJavaObject.Call<AndroidJavaObject>("build", new object[0]);
		}

		// Token: 0x04000443 RID: 1091
		public const string AdListenerClassName = "com.google.android.gms.ads.AdListener";

		// Token: 0x04000444 RID: 1092
		public const string AdRequestClassName = "com.google.android.gms.ads.AdRequest";

		// Token: 0x04000445 RID: 1093
		public const string AdRequestBuilderClassName = "com.google.android.gms.ads.AdRequest$Builder";

		// Token: 0x04000446 RID: 1094
		public const string AdSizeClassName = "com.google.android.gms.ads.AdSize";

		// Token: 0x04000447 RID: 1095
		public const string AdMobExtrasClassName = "com.google.android.gms.ads.mediation.admob.AdMobExtras";

		// Token: 0x04000448 RID: 1096
		public const string PlayStorePurchaseListenerClassName = "com.google.android.gms.ads.purchase.PlayStorePurchaseListener";

		// Token: 0x04000449 RID: 1097
		public const string MobileAdsClassName = "com.google.android.gms.ads.MobileAds";

		// Token: 0x0400044A RID: 1098
		public const string BannerViewClassName = "com.google.unity.ads.Banner";

		// Token: 0x0400044B RID: 1099
		public const string InterstitialClassName = "com.google.unity.ads.Interstitial";

		// Token: 0x0400044C RID: 1100
		public const string RewardBasedVideoClassName = "com.google.unity.ads.RewardBasedVideo";

		// Token: 0x0400044D RID: 1101
		public const string NativeExpressAdViewClassName = "com.google.unity.ads.NativeExpressAd";

		// Token: 0x0400044E RID: 1102
		public const string NativeAdLoaderClassName = "com.google.unity.ads.NativeAdLoader";

		// Token: 0x0400044F RID: 1103
		public const string UnityAdListenerClassName = "com.google.unity.ads.UnityAdListener";

		// Token: 0x04000450 RID: 1104
		public const string UnityRewardBasedVideoAdListenerClassName = "com.google.unity.ads.UnityRewardBasedVideoAdListener";

		// Token: 0x04000451 RID: 1105
		public const string UnityAdLoaderListenerClassName = "com.google.unity.ads.UnityAdLoaderListener";

		// Token: 0x04000452 RID: 1106
		public const string PluginUtilsClassName = "com.google.unity.ads.PluginUtils";

		// Token: 0x04000453 RID: 1107
		public const string UnityActivityClassName = "com.unity3d.player.UnityPlayer";

		// Token: 0x04000454 RID: 1108
		public const string BundleClassName = "android.os.Bundle";

		// Token: 0x04000455 RID: 1109
		public const string DateClassName = "java.util.Date";
	}
}
