using System;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000106 RID: 262
	public class MobileAds
	{
		// Token: 0x0600061E RID: 1566 RVA: 0x0001CCC2 File Offset: 0x0001B0C2
		public static void Initialize(string appId)
		{
			MobileAds.client.Initialize(appId);
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0001CCCF File Offset: 0x0001B0CF
		public static void SetApplicationMuted(bool muted)
		{
			MobileAds.client.SetApplicationMuted(muted);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0001CCDC File Offset: 0x0001B0DC
		public static void SetApplicationVolume(float volume)
		{
			MobileAds.client.SetApplicationVolume(volume);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0001CCEC File Offset: 0x0001B0EC
		private static IMobileAdsClient GetMobileAdsClient()
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("MobileAdsInstance", BindingFlags.Static | BindingFlags.Public);
			return (IMobileAdsClient)method.Invoke(null, null);
		}

		// Token: 0x04000402 RID: 1026
		private static readonly IMobileAdsClient client = MobileAds.GetMobileAdsClient();
	}
}
