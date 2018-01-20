using System;
using UnityEngine;

namespace com.adjust.sdk
{
	// Token: 0x0200000A RID: 10
	public class AdjustAndroid : IAdjust
	{
		// Token: 0x06000090 RID: 144 RVA: 0x00004738 File Offset: 0x00002B38
		public AdjustAndroid()
		{
			if (AdjustAndroid.ajcAdjust == null)
			{
				AdjustAndroid.ajcAdjust = new AndroidJavaClass("com.adjust.sdk.Adjust");
			}
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			this.ajoCurrentActivity = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004780 File Offset: 0x00002B80
		public void start(AdjustConfig adjustConfig)
		{
			AndroidJavaObject androidJavaObject = (adjustConfig.environment != AdjustEnvironment.Sandbox) ? new AndroidJavaClass("com.adjust.sdk.AdjustConfig").GetStatic<AndroidJavaObject>("ENVIRONMENT_PRODUCTION") : new AndroidJavaClass("com.adjust.sdk.AdjustConfig").GetStatic<AndroidJavaObject>("ENVIRONMENT_SANDBOX");
			bool? allowSuppressLogLevel = adjustConfig.allowSuppressLogLevel;
			AndroidJavaObject androidJavaObject2;
			if (allowSuppressLogLevel != null)
			{
				androidJavaObject2 = new AndroidJavaObject("com.adjust.sdk.AdjustConfig", new object[]
				{
					this.ajoCurrentActivity,
					adjustConfig.appToken,
					androidJavaObject,
					adjustConfig.allowSuppressLogLevel
				});
			}
			else
			{
				androidJavaObject2 = new AndroidJavaObject("com.adjust.sdk.AdjustConfig", new object[]
				{
					this.ajoCurrentActivity,
					adjustConfig.appToken,
					androidJavaObject
				});
			}
			AdjustAndroid.launchDeferredDeeplink = adjustConfig.launchDeferredDeeplink;
			AdjustLogLevel? logLevel = adjustConfig.logLevel;
			if (logLevel != null)
			{
				AndroidJavaObject @static;
				if (adjustConfig.logLevel.Value.uppercaseToString().Equals("SUPPRESS"))
				{
					@static = new AndroidJavaClass("com.adjust.sdk.LogLevel").GetStatic<AndroidJavaObject>("SUPRESS");
				}
				else
				{
					@static = new AndroidJavaClass("com.adjust.sdk.LogLevel").GetStatic<AndroidJavaObject>(adjustConfig.logLevel.Value.uppercaseToString());
				}
				if (@static != null)
				{
					androidJavaObject2.Call("setLogLevel", new object[]
					{
						@static
					});
				}
			}
			double? delayStart = adjustConfig.delayStart;
			if (delayStart != null)
			{
				androidJavaObject2.Call("setDelayStart", new object[]
				{
					adjustConfig.delayStart
				});
			}
			bool? eventBufferingEnabled = adjustConfig.eventBufferingEnabled;
			if (eventBufferingEnabled != null)
			{
				AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("java.lang.Boolean", new object[]
				{
					adjustConfig.eventBufferingEnabled.Value
				});
				androidJavaObject2.Call("setEventBufferingEnabled", new object[]
				{
					androidJavaObject3
				});
			}
			bool? sendInBackground = adjustConfig.sendInBackground;
			if (sendInBackground != null)
			{
				androidJavaObject2.Call("setSendInBackground", new object[]
				{
					adjustConfig.sendInBackground.Value
				});
			}
			if (adjustConfig.userAgent != null)
			{
				androidJavaObject2.Call("setUserAgent", new object[]
				{
					adjustConfig.userAgent
				});
			}
			if (!string.IsNullOrEmpty(adjustConfig.processName))
			{
				androidJavaObject2.Call("setProcessName", new object[]
				{
					adjustConfig.processName
				});
			}
			if (adjustConfig.defaultTracker != null)
			{
				androidJavaObject2.Call("setDefaultTracker", new object[]
				{
					adjustConfig.defaultTracker
				});
			}
			if (adjustConfig.attributionChangedDelegate != null)
			{
				this.onAttributionChangedListener = new AdjustAndroid.AttributionChangeListener(adjustConfig.attributionChangedDelegate);
				androidJavaObject2.Call("setOnAttributionChangedListener", new object[]
				{
					this.onAttributionChangedListener
				});
			}
			if (adjustConfig.eventSuccessDelegate != null)
			{
				this.onEventTrackingSucceededListener = new AdjustAndroid.EventTrackingSucceededListener(adjustConfig.eventSuccessDelegate);
				androidJavaObject2.Call("setOnEventTrackingSucceededListener", new object[]
				{
					this.onEventTrackingSucceededListener
				});
			}
			if (adjustConfig.eventFailureDelegate != null)
			{
				this.onEventTrackingFailedListener = new AdjustAndroid.EventTrackingFailedListener(adjustConfig.eventFailureDelegate);
				androidJavaObject2.Call("setOnEventTrackingFailedListener", new object[]
				{
					this.onEventTrackingFailedListener
				});
			}
			if (adjustConfig.sessionSuccessDelegate != null)
			{
				this.onSessionTrackingSucceededListener = new AdjustAndroid.SessionTrackingSucceededListener(adjustConfig.sessionSuccessDelegate);
				androidJavaObject2.Call("setOnSessionTrackingSucceededListener", new object[]
				{
					this.onSessionTrackingSucceededListener
				});
			}
			if (adjustConfig.sessionFailureDelegate != null)
			{
				this.onSessionTrackingFailedListener = new AdjustAndroid.SessionTrackingFailedListener(adjustConfig.sessionFailureDelegate);
				androidJavaObject2.Call("setOnSessionTrackingFailedListener", new object[]
				{
					this.onSessionTrackingFailedListener
				});
			}
			if (adjustConfig.deferredDeeplinkDelegate != null)
			{
				this.onDeferredDeeplinkListener = new AdjustAndroid.DeferredDeeplinkListener(adjustConfig.deferredDeeplinkDelegate);
				androidJavaObject2.Call("setOnDeeplinkResponseListener", new object[]
				{
					this.onDeferredDeeplinkListener
				});
			}
			androidJavaObject2.Call("setSdkPrefix", new object[]
			{
				"unity4.10.3"
			});
			AdjustAndroid.ajcAdjust.CallStatic("onCreate", new object[]
			{
				androidJavaObject2
			});
			AdjustAndroid.ajcAdjust.CallStatic("onResume", new object[0]);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004B8C File Offset: 0x00002F8C
		public void trackEvent(AdjustEvent adjustEvent)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.adjust.sdk.AdjustEvent", new object[]
			{
				adjustEvent.eventToken
			});
			double? revenue = adjustEvent.revenue;
			if (revenue != null)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject;
				string methodName = "setRevenue";
				object[] array = new object[2];
				int num = 0;
				double? revenue2 = adjustEvent.revenue;
				array[num] = revenue2.Value;
				array[1] = adjustEvent.currency;
				androidJavaObject2.Call(methodName, array);
			}
			if (adjustEvent.callbackList != null)
			{
				for (int i = 0; i < adjustEvent.callbackList.Count; i += 2)
				{
					string text = adjustEvent.callbackList[i];
					string text2 = adjustEvent.callbackList[i + 1];
					androidJavaObject.Call("addCallbackParameter", new object[]
					{
						text,
						text2
					});
				}
			}
			if (adjustEvent.partnerList != null)
			{
				for (int j = 0; j < adjustEvent.partnerList.Count; j += 2)
				{
					string text3 = adjustEvent.partnerList[j];
					string text4 = adjustEvent.partnerList[j + 1];
					androidJavaObject.Call("addPartnerParameter", new object[]
					{
						text3,
						text4
					});
				}
			}
			if (adjustEvent.transactionId != null)
			{
				androidJavaObject.Call("setOrderId", new object[]
				{
					adjustEvent.transactionId
				});
			}
			AdjustAndroid.ajcAdjust.CallStatic("trackEvent", new object[]
			{
				androidJavaObject
			});
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004CFA File Offset: 0x000030FA
		public bool isEnabled()
		{
			return AdjustAndroid.ajcAdjust.CallStatic<bool>("isEnabled", new object[0]);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004D11 File Offset: 0x00003111
		public void setEnabled(bool enabled)
		{
			AdjustAndroid.ajcAdjust.CallStatic("setEnabled", new object[]
			{
				enabled
			});
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004D31 File Offset: 0x00003131
		public void setOfflineMode(bool enabled)
		{
			AdjustAndroid.ajcAdjust.CallStatic("setOfflineMode", new object[]
			{
				enabled
			});
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004D51 File Offset: 0x00003151
		public void sendFirstPackages()
		{
			AdjustAndroid.ajcAdjust.CallStatic("sendFirstPackages", new object[0]);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004D68 File Offset: 0x00003168
		public void setDeviceToken(string deviceToken)
		{
			AdjustAndroid.ajcAdjust.CallStatic("setPushToken", new object[]
			{
				deviceToken
			});
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004D83 File Offset: 0x00003183
		public static void addSessionPartnerParameter(string key, string value)
		{
			if (AdjustAndroid.ajcAdjust == null)
			{
				AdjustAndroid.ajcAdjust = new AndroidJavaClass("com.adjust.sdk.Adjust");
			}
			AdjustAndroid.ajcAdjust.CallStatic("addSessionPartnerParameter", new object[]
			{
				key,
				value
			});
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004DBB File Offset: 0x000031BB
		public static void addSessionCallbackParameter(string key, string value)
		{
			if (AdjustAndroid.ajcAdjust == null)
			{
				AdjustAndroid.ajcAdjust = new AndroidJavaClass("com.adjust.sdk.Adjust");
			}
			AdjustAndroid.ajcAdjust.CallStatic("addSessionCallbackParameter", new object[]
			{
				key,
				value
			});
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004DF3 File Offset: 0x000031F3
		public static void removeSessionPartnerParameter(string key)
		{
			if (AdjustAndroid.ajcAdjust == null)
			{
				AdjustAndroid.ajcAdjust = new AndroidJavaClass("com.adjust.sdk.Adjust");
			}
			AdjustAndroid.ajcAdjust.CallStatic("removeSessionPartnerParameter", new object[]
			{
				key
			});
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004E27 File Offset: 0x00003227
		public static void removeSessionCallbackParameter(string key)
		{
			if (AdjustAndroid.ajcAdjust == null)
			{
				AdjustAndroid.ajcAdjust = new AndroidJavaClass("com.adjust.sdk.Adjust");
			}
			AdjustAndroid.ajcAdjust.CallStatic("removeSessionCallbackParameter", new object[]
			{
				key
			});
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004E5B File Offset: 0x0000325B
		public static void resetSessionPartnerParameters()
		{
			if (AdjustAndroid.ajcAdjust == null)
			{
				AdjustAndroid.ajcAdjust = new AndroidJavaClass("com.adjust.sdk.Adjust");
			}
			AdjustAndroid.ajcAdjust.CallStatic("resetSessionPartnerParameters", new object[0]);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004E8B File Offset: 0x0000328B
		public static void resetSessionCallbackParameters()
		{
			if (AdjustAndroid.ajcAdjust == null)
			{
				AdjustAndroid.ajcAdjust = new AndroidJavaClass("com.adjust.sdk.Adjust");
			}
			AdjustAndroid.ajcAdjust.CallStatic("resetSessionCallbackParameters", new object[0]);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004EBB File Offset: 0x000032BB
		public void onPause()
		{
			AdjustAndroid.ajcAdjust.CallStatic("onPause", new object[0]);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004ED2 File Offset: 0x000032D2
		public void onResume()
		{
			AdjustAndroid.ajcAdjust.CallStatic("onResume", new object[0]);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004EE9 File Offset: 0x000032E9
		public void setReferrer(string referrer)
		{
			AdjustAndroid.ajcAdjust.CallStatic("setReferrer", new object[]
			{
				referrer
			});
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004F04 File Offset: 0x00003304
		public void getGoogleAdId(Action<string> onDeviceIdsRead)
		{
			AdjustAndroid.DeviceIdsReadListener deviceIdsReadListener = new AdjustAndroid.DeviceIdsReadListener(onDeviceIdsRead);
			AdjustAndroid.ajcAdjust.CallStatic("getGoogleAdId", new object[]
			{
				this.ajoCurrentActivity,
				deviceIdsReadListener
			});
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004F3A File Offset: 0x0000333A
		public string getIdfa()
		{
			return null;
		}

		// Token: 0x0400001E RID: 30
		private const string sdkPrefix = "unity4.10.3";

		// Token: 0x0400001F RID: 31
		private static bool launchDeferredDeeplink = true;

		// Token: 0x04000020 RID: 32
		private static AndroidJavaClass ajcAdjust;

		// Token: 0x04000021 RID: 33
		private AndroidJavaObject ajoCurrentActivity;

		// Token: 0x04000022 RID: 34
		private AdjustAndroid.DeferredDeeplinkListener onDeferredDeeplinkListener;

		// Token: 0x04000023 RID: 35
		private AdjustAndroid.AttributionChangeListener onAttributionChangedListener;

		// Token: 0x04000024 RID: 36
		private AdjustAndroid.EventTrackingFailedListener onEventTrackingFailedListener;

		// Token: 0x04000025 RID: 37
		private AdjustAndroid.EventTrackingSucceededListener onEventTrackingSucceededListener;

		// Token: 0x04000026 RID: 38
		private AdjustAndroid.SessionTrackingFailedListener onSessionTrackingFailedListener;

		// Token: 0x04000027 RID: 39
		private AdjustAndroid.SessionTrackingSucceededListener onSessionTrackingSucceededListener;

		// Token: 0x0200000B RID: 11
		private class AttributionChangeListener : AndroidJavaProxy
		{
			// Token: 0x060000A4 RID: 164 RVA: 0x00004F45 File Offset: 0x00003345
			public AttributionChangeListener(Action<AdjustAttribution> pCallback) : base("com.adjust.sdk.OnAttributionChangedListener")
			{
				this.callback = pCallback;
			}

			// Token: 0x060000A5 RID: 165 RVA: 0x00004F5C File Offset: 0x0000335C
			public void onAttributionChanged(AndroidJavaObject attribution)
			{
				if (this.callback == null)
				{
					return;
				}
				AdjustAttribution adjustAttribution = new AdjustAttribution();
				adjustAttribution.trackerName = attribution.Get<string>(AdjustUtils.KeyTrackerName);
				adjustAttribution.trackerToken = attribution.Get<string>(AdjustUtils.KeyTrackerToken);
				adjustAttribution.network = attribution.Get<string>(AdjustUtils.KeyNetwork);
				adjustAttribution.campaign = attribution.Get<string>(AdjustUtils.KeyCampaign);
				adjustAttribution.adgroup = attribution.Get<string>(AdjustUtils.KeyAdgroup);
				adjustAttribution.creative = attribution.Get<string>(AdjustUtils.KeyCreative);
				adjustAttribution.clickLabel = attribution.Get<string>(AdjustUtils.KeyClickLabel);
				this.callback(adjustAttribution);
			}

			// Token: 0x04000028 RID: 40
			private Action<AdjustAttribution> callback;
		}

		// Token: 0x0200000C RID: 12
		private class DeferredDeeplinkListener : AndroidJavaProxy
		{
			// Token: 0x060000A6 RID: 166 RVA: 0x00004FFE File Offset: 0x000033FE
			public DeferredDeeplinkListener(Action<string> pCallback) : base("com.adjust.sdk.OnDeeplinkResponseListener")
			{
				this.callback = pCallback;
			}

			// Token: 0x060000A7 RID: 167 RVA: 0x00005014 File Offset: 0x00003414
			public bool launchReceivedDeeplink(AndroidJavaObject deeplink)
			{
				if (this.callback == null)
				{
					return AdjustAndroid.launchDeferredDeeplink;
				}
				string obj = deeplink.Call<string>("toString", new object[0]);
				this.callback(obj);
				return AdjustAndroid.launchDeferredDeeplink;
			}

			// Token: 0x04000029 RID: 41
			private Action<string> callback;
		}

		// Token: 0x0200000D RID: 13
		private class EventTrackingSucceededListener : AndroidJavaProxy
		{
			// Token: 0x060000A8 RID: 168 RVA: 0x00005055 File Offset: 0x00003455
			public EventTrackingSucceededListener(Action<AdjustEventSuccess> pCallback) : base("com.adjust.sdk.OnEventTrackingSucceededListener")
			{
				this.callback = pCallback;
			}

			// Token: 0x060000A9 RID: 169 RVA: 0x0000506C File Offset: 0x0000346C
			public void onFinishedEventTrackingSucceeded(AndroidJavaObject eventSuccessData)
			{
				if (this.callback == null)
				{
					return;
				}
				if (eventSuccessData == null)
				{
					return;
				}
				AdjustEventSuccess adjustEventSuccess = new AdjustEventSuccess();
				adjustEventSuccess.Adid = eventSuccessData.Get<string>(AdjustUtils.KeyAdid);
				adjustEventSuccess.Message = eventSuccessData.Get<string>(AdjustUtils.KeyMessage);
				adjustEventSuccess.Timestamp = eventSuccessData.Get<string>(AdjustUtils.KeyTimestamp);
				adjustEventSuccess.EventToken = eventSuccessData.Get<string>(AdjustUtils.KeyEventToken);
				try
				{
					AndroidJavaObject androidJavaObject = eventSuccessData.Get<AndroidJavaObject>(AdjustUtils.KeyJsonResponse);
					string jsonResponseString = androidJavaObject.Call<string>("toString", new object[0]);
					adjustEventSuccess.BuildJsonResponseFromString(jsonResponseString);
				}
				catch (Exception)
				{
				}
				this.callback(adjustEventSuccess);
			}

			// Token: 0x0400002A RID: 42
			private Action<AdjustEventSuccess> callback;
		}

		// Token: 0x0200000E RID: 14
		private class EventTrackingFailedListener : AndroidJavaProxy
		{
			// Token: 0x060000AA RID: 170 RVA: 0x00005124 File Offset: 0x00003524
			public EventTrackingFailedListener(Action<AdjustEventFailure> pCallback) : base("com.adjust.sdk.OnEventTrackingFailedListener")
			{
				this.callback = pCallback;
			}

			// Token: 0x060000AB RID: 171 RVA: 0x00005138 File Offset: 0x00003538
			public void onFinishedEventTrackingFailed(AndroidJavaObject eventFailureData)
			{
				if (this.callback == null)
				{
					return;
				}
				if (eventFailureData == null)
				{
					return;
				}
				AdjustEventFailure adjustEventFailure = new AdjustEventFailure();
				adjustEventFailure.Adid = eventFailureData.Get<string>(AdjustUtils.KeyAdid);
				adjustEventFailure.Message = eventFailureData.Get<string>(AdjustUtils.KeyMessage);
				adjustEventFailure.WillRetry = eventFailureData.Get<bool>(AdjustUtils.KeyWillRetry);
				adjustEventFailure.Timestamp = eventFailureData.Get<string>(AdjustUtils.KeyTimestamp);
				adjustEventFailure.EventToken = eventFailureData.Get<string>(AdjustUtils.KeyEventToken);
				try
				{
					AndroidJavaObject androidJavaObject = eventFailureData.Get<AndroidJavaObject>(AdjustUtils.KeyJsonResponse);
					string jsonResponseString = androidJavaObject.Call<string>("toString", new object[0]);
					adjustEventFailure.BuildJsonResponseFromString(jsonResponseString);
				}
				catch (Exception)
				{
				}
				this.callback(adjustEventFailure);
			}

			// Token: 0x0400002B RID: 43
			private Action<AdjustEventFailure> callback;
		}

		// Token: 0x0200000F RID: 15
		private class SessionTrackingSucceededListener : AndroidJavaProxy
		{
			// Token: 0x060000AC RID: 172 RVA: 0x00005200 File Offset: 0x00003600
			public SessionTrackingSucceededListener(Action<AdjustSessionSuccess> pCallback) : base("com.adjust.sdk.OnSessionTrackingSucceededListener")
			{
				this.callback = pCallback;
			}

			// Token: 0x060000AD RID: 173 RVA: 0x00005214 File Offset: 0x00003614
			public void onFinishedSessionTrackingSucceeded(AndroidJavaObject sessionSuccessData)
			{
				if (this.callback == null)
				{
					return;
				}
				if (sessionSuccessData == null)
				{
					return;
				}
				AdjustSessionSuccess adjustSessionSuccess = new AdjustSessionSuccess();
				adjustSessionSuccess.Adid = sessionSuccessData.Get<string>(AdjustUtils.KeyAdid);
				adjustSessionSuccess.Message = sessionSuccessData.Get<string>(AdjustUtils.KeyMessage);
				adjustSessionSuccess.Timestamp = sessionSuccessData.Get<string>(AdjustUtils.KeyTimestamp);
				try
				{
					AndroidJavaObject androidJavaObject = sessionSuccessData.Get<AndroidJavaObject>(AdjustUtils.KeyJsonResponse);
					string jsonResponseString = androidJavaObject.Call<string>("toString", new object[0]);
					adjustSessionSuccess.BuildJsonResponseFromString(jsonResponseString);
				}
				catch (Exception)
				{
				}
				this.callback(adjustSessionSuccess);
			}

			// Token: 0x0400002C RID: 44
			private Action<AdjustSessionSuccess> callback;
		}

		// Token: 0x02000010 RID: 16
		private class SessionTrackingFailedListener : AndroidJavaProxy
		{
			// Token: 0x060000AE RID: 174 RVA: 0x000052BC File Offset: 0x000036BC
			public SessionTrackingFailedListener(Action<AdjustSessionFailure> pCallback) : base("com.adjust.sdk.OnSessionTrackingFailedListener")
			{
				this.callback = pCallback;
			}

			// Token: 0x060000AF RID: 175 RVA: 0x000052D0 File Offset: 0x000036D0
			public void onFinishedSessionTrackingFailed(AndroidJavaObject sessionFailureData)
			{
				if (this.callback == null)
				{
					return;
				}
				if (sessionFailureData == null)
				{
					return;
				}
				AdjustSessionFailure adjustSessionFailure = new AdjustSessionFailure();
				adjustSessionFailure.Adid = sessionFailureData.Get<string>(AdjustUtils.KeyAdid);
				adjustSessionFailure.Message = sessionFailureData.Get<string>(AdjustUtils.KeyMessage);
				adjustSessionFailure.WillRetry = sessionFailureData.Get<bool>(AdjustUtils.KeyWillRetry);
				adjustSessionFailure.Timestamp = sessionFailureData.Get<string>(AdjustUtils.KeyTimestamp);
				try
				{
					AndroidJavaObject androidJavaObject = sessionFailureData.Get<AndroidJavaObject>(AdjustUtils.KeyJsonResponse);
					string jsonResponseString = androidJavaObject.Call<string>("toString", new object[0]);
					adjustSessionFailure.BuildJsonResponseFromString(jsonResponseString);
				}
				catch (Exception)
				{
				}
				this.callback(adjustSessionFailure);
			}

			// Token: 0x0400002D RID: 45
			private Action<AdjustSessionFailure> callback;
		}

		// Token: 0x02000011 RID: 17
		private class DeviceIdsReadListener : AndroidJavaProxy
		{
			// Token: 0x060000B0 RID: 176 RVA: 0x00005388 File Offset: 0x00003788
			public DeviceIdsReadListener(Action<string> pCallback) : base("com.adjust.sdk.OnDeviceIdsRead")
			{
				this.onPlayAdIdReadCallback = pCallback;
			}

			// Token: 0x060000B1 RID: 177 RVA: 0x0000539C File Offset: 0x0000379C
			public void onGoogleAdIdRead(string playAdId)
			{
				if (this.onPlayAdIdReadCallback == null)
				{
					return;
				}
				this.onPlayAdIdReadCallback(playAdId);
			}

			// Token: 0x060000B2 RID: 178 RVA: 0x000053B8 File Offset: 0x000037B8
			public void onGoogleAdIdRead(AndroidJavaObject ajoAdId)
			{
				if (ajoAdId == null)
				{
					string playAdId = null;
					this.onGoogleAdIdRead(playAdId);
					return;
				}
				this.onGoogleAdIdRead(ajoAdId.Call<string>("toString", new object[0]));
			}

			// Token: 0x0400002E RID: 46
			private Action<string> onPlayAdIdReadCallback;
		}
	}
}
