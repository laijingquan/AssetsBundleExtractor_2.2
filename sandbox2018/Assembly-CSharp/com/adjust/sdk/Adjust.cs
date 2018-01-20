using System;
using UnityEngine;

namespace com.adjust.sdk
{
	// Token: 0x02000009 RID: 9
	public class Adjust : MonoBehaviour
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00003E18 File Offset: 0x00002218
		private void Awake()
		{
			if (Adjust.instance != null)
			{
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
			if (!this.startManually)
			{
				AdjustConfig adjustConfig = new AdjustConfig(this.appToken, this.environment, this.logLevel == AdjustLogLevel.Suppress);
				adjustConfig.setLogLevel(this.logLevel);
				adjustConfig.setSendInBackground(this.sendInBackground);
				adjustConfig.setEventBufferingEnabled(this.eventBuffering);
				adjustConfig.setLaunchDeferredDeeplink(this.launchDeferredDeeplink);
				if (this.printAttribution)
				{
					adjustConfig.setEventSuccessDelegate(new Action<AdjustEventSuccess>(this.EventSuccessCallback), "Adjust");
					adjustConfig.setEventFailureDelegate(new Action<AdjustEventFailure>(this.EventFailureCallback), "Adjust");
					adjustConfig.setSessionSuccessDelegate(new Action<AdjustSessionSuccess>(this.SessionSuccessCallback), "Adjust");
					adjustConfig.setSessionFailureDelegate(new Action<AdjustSessionFailure>(this.SessionFailureCallback), "Adjust");
					adjustConfig.setDeferredDeeplinkDelegate(new Action<string>(this.DeferredDeeplinkCallback), "Adjust");
					adjustConfig.setAttributionChangedDelegate(new Action<AdjustAttribution>(this.AttributionChangedCallback), "Adjust");
				}
				Adjust.start(adjustConfig);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003F31 File Offset: 0x00002331
		private void OnApplicationPause(bool pauseStatus)
		{
			if (Adjust.instance == null)
			{
				return;
			}
			if (pauseStatus)
			{
				Adjust.instance.onPause();
			}
			else
			{
				Adjust.instance.onResume();
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003F60 File Offset: 0x00002360
		public static void start(AdjustConfig adjustConfig)
		{
			if (Adjust.instance != null)
			{
				Debug.Log("adjust: Error, SDK already started.");
				return;
			}
			if (adjustConfig == null)
			{
				Debug.Log("adjust: Missing config to start.");
				return;
			}
			Adjust.instance = new AdjustAndroid();
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK can only be used in Android, iOS, Windows Phone 8 or Windows Store apps.");
				return;
			}
			Adjust.eventSuccessDelegate = adjustConfig.getEventSuccessDelegate();
			Adjust.eventFailureDelegate = adjustConfig.getEventFailureDelegate();
			Adjust.sessionSuccessDelegate = adjustConfig.getSessionSuccessDelegate();
			Adjust.sessionFailureDelegate = adjustConfig.getSessionFailureDelegate();
			Adjust.deferredDeeplinkDelegate = adjustConfig.getDeferredDeeplinkDelegate();
			Adjust.attributionChangedDelegate = adjustConfig.getAttributionChangedDelegate();
			Adjust.instance.start(adjustConfig);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003FFF File Offset: 0x000023FF
		public static void trackEvent(AdjustEvent adjustEvent)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			if (adjustEvent == null)
			{
				Debug.Log("adjust: Missing event to track.");
				return;
			}
			Adjust.instance.trackEvent(adjustEvent);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004032 File Offset: 0x00002432
		public static void setEnabled(bool enabled)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			Adjust.instance.setEnabled(enabled);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004054 File Offset: 0x00002454
		public static bool isEnabled()
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return false;
			}
			return Adjust.instance.isEnabled();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00004076 File Offset: 0x00002476
		public static void setOfflineMode(bool enabled)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			Adjust.instance.setOfflineMode(enabled);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004098 File Offset: 0x00002498
		public static void sendFirstPackages()
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			Adjust.instance.sendFirstPackages();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000040B9 File Offset: 0x000024B9
		public static void addSessionPartnerParameter(string key, string value)
		{
			AdjustAndroid.addSessionPartnerParameter(key, value);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000040C2 File Offset: 0x000024C2
		public static void addSessionCallbackParameter(string key, string value)
		{
			AdjustAndroid.addSessionCallbackParameter(key, value);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000040CB File Offset: 0x000024CB
		public static void removeSessionPartnerParameter(string key)
		{
			AdjustAndroid.removeSessionPartnerParameter(key);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000040D3 File Offset: 0x000024D3
		public static void removeSessionCallbackParameter(string key)
		{
			AdjustAndroid.removeSessionCallbackParameter(key);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000040DB File Offset: 0x000024DB
		public static void resetSessionPartnerParameters()
		{
			AdjustAndroid.resetSessionPartnerParameters();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000040E2 File Offset: 0x000024E2
		public static void resetSessionCallbackParameters()
		{
			AdjustAndroid.resetSessionCallbackParameters();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000040E9 File Offset: 0x000024E9
		public static void setDeviceToken(string deviceToken)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			Adjust.instance.setDeviceToken(deviceToken);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000410B File Offset: 0x0000250B
		public static string getIdfa()
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return null;
			}
			return Adjust.instance.getIdfa();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000412D File Offset: 0x0000252D
		public static void setReferrer(string referrer)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			Adjust.instance.setReferrer(referrer);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000414F File Offset: 0x0000254F
		public static void getGoogleAdId(Action<string> onDeviceIdsRead)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			Adjust.instance.getGoogleAdId(onDeviceIdsRead);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004174 File Offset: 0x00002574
		public void GetNativeAttribution(string attributionData)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			if (Adjust.attributionChangedDelegate == null)
			{
				Debug.Log("adjust: Attribution changed delegate was not set.");
				return;
			}
			AdjustAttribution obj = new AdjustAttribution(attributionData);
			Adjust.attributionChangedDelegate(obj);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000041C0 File Offset: 0x000025C0
		public void GetNativeEventSuccess(string eventSuccessData)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			if (Adjust.eventSuccessDelegate == null)
			{
				Debug.Log("adjust: Event success delegate was not set.");
				return;
			}
			AdjustEventSuccess obj = new AdjustEventSuccess(eventSuccessData);
			Adjust.eventSuccessDelegate(obj);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000420C File Offset: 0x0000260C
		public void GetNativeEventFailure(string eventFailureData)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			if (Adjust.eventFailureDelegate == null)
			{
				Debug.Log("adjust: Event failure delegate was not set.");
				return;
			}
			AdjustEventFailure obj = new AdjustEventFailure(eventFailureData);
			Adjust.eventFailureDelegate(obj);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004258 File Offset: 0x00002658
		public void GetNativeSessionSuccess(string sessionSuccessData)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			if (Adjust.sessionSuccessDelegate == null)
			{
				Debug.Log("adjust: Session success delegate was not set.");
				return;
			}
			AdjustSessionSuccess obj = new AdjustSessionSuccess(sessionSuccessData);
			Adjust.sessionSuccessDelegate(obj);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000042A4 File Offset: 0x000026A4
		public void GetNativeSessionFailure(string sessionFailureData)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			if (Adjust.sessionFailureDelegate == null)
			{
				Debug.Log("adjust: Session failure delegate was not set.");
				return;
			}
			AdjustSessionFailure obj = new AdjustSessionFailure(sessionFailureData);
			Adjust.sessionFailureDelegate(obj);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000042ED File Offset: 0x000026ED
		public void GetNativeDeferredDeeplink(string deeplinkURL)
		{
			if (Adjust.instance == null)
			{
				Debug.Log("adjust: SDK not started. Start it manually using the 'start' method.");
				return;
			}
			if (Adjust.deferredDeeplinkDelegate == null)
			{
				Debug.Log("adjust: Deferred deeplink delegate was not set.");
				return;
			}
			Adjust.deferredDeeplinkDelegate(deeplinkURL);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004324 File Offset: 0x00002724
		private void AttributionChangedCallback(AdjustAttribution attributionData)
		{
			Debug.Log("Attribution changed!");
			if (attributionData.trackerName != null)
			{
				Debug.Log("trackerName " + attributionData.trackerName);
			}
			if (attributionData.trackerToken != null)
			{
				Debug.Log("trackerToken " + attributionData.trackerToken);
			}
			if (attributionData.network != null)
			{
				Debug.Log("network " + attributionData.network);
			}
			if (attributionData.campaign != null)
			{
				Debug.Log("campaign " + attributionData.campaign);
			}
			if (attributionData.adgroup != null)
			{
				Debug.Log("adgroup " + attributionData.adgroup);
			}
			if (attributionData.creative != null)
			{
				Debug.Log("creative " + attributionData.creative);
			}
			if (attributionData.clickLabel != null)
			{
				Debug.Log("clickLabel" + attributionData.clickLabel);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000441C File Offset: 0x0000281C
		private void EventSuccessCallback(AdjustEventSuccess eventSuccessData)
		{
			Debug.Log("Event tracked successfully!");
			if (eventSuccessData.Message != null)
			{
				Debug.Log("Message: " + eventSuccessData.Message);
			}
			if (eventSuccessData.Timestamp != null)
			{
				Debug.Log("Timestamp: " + eventSuccessData.Timestamp);
			}
			if (eventSuccessData.Adid != null)
			{
				Debug.Log("Adid: " + eventSuccessData.Adid);
			}
			if (eventSuccessData.EventToken != null)
			{
				Debug.Log("EventToken: " + eventSuccessData.EventToken);
			}
			if (eventSuccessData.JsonResponse != null)
			{
				Debug.Log("JsonResponse: " + eventSuccessData.GetJsonResponse());
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000044D4 File Offset: 0x000028D4
		private void EventFailureCallback(AdjustEventFailure eventFailureData)
		{
			Debug.Log("Event tracking failed!");
			if (eventFailureData.Message != null)
			{
				Debug.Log("Message: " + eventFailureData.Message);
			}
			if (eventFailureData.Timestamp != null)
			{
				Debug.Log("Timestamp: " + eventFailureData.Timestamp);
			}
			if (eventFailureData.Adid != null)
			{
				Debug.Log("Adid: " + eventFailureData.Adid);
			}
			if (eventFailureData.EventToken != null)
			{
				Debug.Log("EventToken: " + eventFailureData.EventToken);
			}
			Debug.Log("WillRetry: " + eventFailureData.WillRetry.ToString());
			if (eventFailureData.JsonResponse != null)
			{
				Debug.Log("JsonResponse: " + eventFailureData.GetJsonResponse());
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000045B0 File Offset: 0x000029B0
		private void SessionSuccessCallback(AdjustSessionSuccess sessionSuccessData)
		{
			Debug.Log("Session tracked successfully!");
			if (sessionSuccessData.Message != null)
			{
				Debug.Log("Message: " + sessionSuccessData.Message);
			}
			if (sessionSuccessData.Timestamp != null)
			{
				Debug.Log("Timestamp: " + sessionSuccessData.Timestamp);
			}
			if (sessionSuccessData.Adid != null)
			{
				Debug.Log("Adid: " + sessionSuccessData.Adid);
			}
			if (sessionSuccessData.JsonResponse != null)
			{
				Debug.Log("JsonResponse: " + sessionSuccessData.GetJsonResponse());
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004648 File Offset: 0x00002A48
		private void SessionFailureCallback(AdjustSessionFailure sessionFailureData)
		{
			Debug.Log("Session tracking failed!");
			if (sessionFailureData.Message != null)
			{
				Debug.Log("Message: " + sessionFailureData.Message);
			}
			if (sessionFailureData.Timestamp != null)
			{
				Debug.Log("Timestamp: " + sessionFailureData.Timestamp);
			}
			if (sessionFailureData.Adid != null)
			{
				Debug.Log("Adid: " + sessionFailureData.Adid);
			}
			Debug.Log("WillRetry: " + sessionFailureData.WillRetry.ToString());
			if (sessionFailureData.JsonResponse != null)
			{
				Debug.Log("JsonResponse: " + sessionFailureData.GetJsonResponse());
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004702 File Offset: 0x00002B02
		private void DeferredDeeplinkCallback(string deeplinkURL)
		{
			Debug.Log("Deferred deeplink reported!");
			if (deeplinkURL != null)
			{
				Debug.Log("Deeplink URL: " + deeplinkURL);
			}
			else
			{
				Debug.Log("Deeplink URL is null!");
			}
		}

		// Token: 0x0400000E RID: 14
		private const string errorMessage = "adjust: SDK not started. Start it manually using the 'start' method.";

		// Token: 0x0400000F RID: 15
		private static IAdjust instance;

		// Token: 0x04000010 RID: 16
		private static Action<string> deferredDeeplinkDelegate;

		// Token: 0x04000011 RID: 17
		private static Action<AdjustEventSuccess> eventSuccessDelegate;

		// Token: 0x04000012 RID: 18
		private static Action<AdjustEventFailure> eventFailureDelegate;

		// Token: 0x04000013 RID: 19
		private static Action<AdjustSessionSuccess> sessionSuccessDelegate;

		// Token: 0x04000014 RID: 20
		private static Action<AdjustSessionFailure> sessionFailureDelegate;

		// Token: 0x04000015 RID: 21
		private static Action<AdjustAttribution> attributionChangedDelegate;

		// Token: 0x04000016 RID: 22
		public bool startManually = true;

		// Token: 0x04000017 RID: 23
		public bool eventBuffering;

		// Token: 0x04000018 RID: 24
		public bool printAttribution = true;

		// Token: 0x04000019 RID: 25
		public bool sendInBackground;

		// Token: 0x0400001A RID: 26
		public bool launchDeferredDeeplink = true;

		// Token: 0x0400001B RID: 27
		public string appToken = "{Your App Token}";

		// Token: 0x0400001C RID: 28
		public AdjustLogLevel logLevel = AdjustLogLevel.Info;

		// Token: 0x0400001D RID: 29
		public AdjustEnvironment environment;
	}
}
