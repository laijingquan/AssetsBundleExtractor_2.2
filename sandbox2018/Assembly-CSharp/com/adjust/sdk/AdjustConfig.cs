using System;

namespace com.adjust.sdk
{
	// Token: 0x02000014 RID: 20
	public class AdjustConfig
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x00005EFE File Offset: 0x000042FE
		public AdjustConfig(string appToken, AdjustEnvironment environment)
		{
			this.sceneName = string.Empty;
			this.processName = string.Empty;
			this.appToken = appToken;
			this.environment = environment;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00005F2A File Offset: 0x0000432A
		public AdjustConfig(string appToken, AdjustEnvironment environment, bool allowSuppressLogLevel)
		{
			this.sceneName = string.Empty;
			this.processName = string.Empty;
			this.appToken = appToken;
			this.environment = environment;
			this.allowSuppressLogLevel = new bool?(allowSuppressLogLevel);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005F62 File Offset: 0x00004362
		public void setLogLevel(AdjustLogLevel logLevel)
		{
			this.logLevel = new AdjustLogLevel?(logLevel);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00005F70 File Offset: 0x00004370
		public void setDefaultTracker(string defaultTracker)
		{
			this.defaultTracker = defaultTracker;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00005F79 File Offset: 0x00004379
		public void setLaunchDeferredDeeplink(bool launchDeferredDeeplink)
		{
			this.launchDeferredDeeplink = launchDeferredDeeplink;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00005F82 File Offset: 0x00004382
		public void setSendInBackground(bool sendInBackground)
		{
			this.sendInBackground = new bool?(sendInBackground);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00005F90 File Offset: 0x00004390
		public void setEventBufferingEnabled(bool eventBufferingEnabled)
		{
			this.eventBufferingEnabled = new bool?(eventBufferingEnabled);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005F9E File Offset: 0x0000439E
		public void setDelayStart(double delayStart)
		{
			this.delayStart = new double?(delayStart);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00005FAC File Offset: 0x000043AC
		public void setUserAgent(string userAgent)
		{
			this.userAgent = userAgent;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00005FB5 File Offset: 0x000043B5
		public void setDeferredDeeplinkDelegate(Action<string> deferredDeeplinkDelegate, string sceneName = "Adjust")
		{
			this.deferredDeeplinkDelegate = deferredDeeplinkDelegate;
			this.sceneName = sceneName;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00005FC5 File Offset: 0x000043C5
		public Action<string> getDeferredDeeplinkDelegate()
		{
			return this.deferredDeeplinkDelegate;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005FCD File Offset: 0x000043CD
		public void setAttributionChangedDelegate(Action<AdjustAttribution> attributionChangedDelegate, string sceneName = "Adjust")
		{
			this.attributionChangedDelegate = attributionChangedDelegate;
			this.sceneName = sceneName;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00005FDD File Offset: 0x000043DD
		public Action<AdjustAttribution> getAttributionChangedDelegate()
		{
			return this.attributionChangedDelegate;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005FE5 File Offset: 0x000043E5
		public void setEventSuccessDelegate(Action<AdjustEventSuccess> eventSuccessDelegate, string sceneName = "Adjust")
		{
			this.eventSuccessDelegate = eventSuccessDelegate;
			this.sceneName = sceneName;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005FF5 File Offset: 0x000043F5
		public Action<AdjustEventSuccess> getEventSuccessDelegate()
		{
			return this.eventSuccessDelegate;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005FFD File Offset: 0x000043FD
		public void setEventFailureDelegate(Action<AdjustEventFailure> eventFailureDelegate, string sceneName = "Adjust")
		{
			this.eventFailureDelegate = eventFailureDelegate;
			this.sceneName = sceneName;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000600D File Offset: 0x0000440D
		public Action<AdjustEventFailure> getEventFailureDelegate()
		{
			return this.eventFailureDelegate;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00006015 File Offset: 0x00004415
		public void setSessionSuccessDelegate(Action<AdjustSessionSuccess> sessionSuccessDelegate, string sceneName = "Adjust")
		{
			this.sessionSuccessDelegate = sessionSuccessDelegate;
			this.sceneName = sceneName;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00006025 File Offset: 0x00004425
		public Action<AdjustSessionSuccess> getSessionSuccessDelegate()
		{
			return this.sessionSuccessDelegate;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000602D File Offset: 0x0000442D
		public void setSessionFailureDelegate(Action<AdjustSessionFailure> sessionFailureDelegate, string sceneName = "Adjust")
		{
			this.sessionFailureDelegate = sessionFailureDelegate;
			this.sceneName = sceneName;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000603D File Offset: 0x0000443D
		public Action<AdjustSessionFailure> getSessionFailureDelegate()
		{
			return this.sessionFailureDelegate;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00006045 File Offset: 0x00004445
		public void setProcessName(string processName)
		{
			this.processName = processName;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000604E File Offset: 0x0000444E
		public void setLogDelegate(Action<string> logDelegate)
		{
			this.logDelegate = logDelegate;
		}

		// Token: 0x0400003D RID: 61
		internal double? delayStart;

		// Token: 0x0400003E RID: 62
		internal string appToken;

		// Token: 0x0400003F RID: 63
		internal string sceneName;

		// Token: 0x04000040 RID: 64
		internal string userAgent;

		// Token: 0x04000041 RID: 65
		internal string defaultTracker;

		// Token: 0x04000042 RID: 66
		internal bool? sendInBackground;

		// Token: 0x04000043 RID: 67
		internal bool? eventBufferingEnabled;

		// Token: 0x04000044 RID: 68
		internal bool? allowSuppressLogLevel;

		// Token: 0x04000045 RID: 69
		internal bool launchDeferredDeeplink;

		// Token: 0x04000046 RID: 70
		internal AdjustLogLevel? logLevel;

		// Token: 0x04000047 RID: 71
		internal AdjustEnvironment environment;

		// Token: 0x04000048 RID: 72
		internal Action<string> deferredDeeplinkDelegate;

		// Token: 0x04000049 RID: 73
		internal Action<AdjustEventSuccess> eventSuccessDelegate;

		// Token: 0x0400004A RID: 74
		internal Action<AdjustEventFailure> eventFailureDelegate;

		// Token: 0x0400004B RID: 75
		internal Action<AdjustSessionSuccess> sessionSuccessDelegate;

		// Token: 0x0400004C RID: 76
		internal Action<AdjustSessionFailure> sessionFailureDelegate;

		// Token: 0x0400004D RID: 77
		internal Action<AdjustAttribution> attributionChangedDelegate;

		// Token: 0x0400004E RID: 78
		internal string processName;

		// Token: 0x0400004F RID: 79
		internal Action<string> logDelegate;
	}
}
