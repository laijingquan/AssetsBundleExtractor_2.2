using System;

namespace com.adjust.sdk
{
	// Token: 0x0200001F RID: 31
	public interface IAdjust
	{
		// Token: 0x06000131 RID: 305
		bool isEnabled();

		// Token: 0x06000132 RID: 306
		void onPause();

		// Token: 0x06000133 RID: 307
		void onResume();

		// Token: 0x06000134 RID: 308
		void sendFirstPackages();

		// Token: 0x06000135 RID: 309
		void setEnabled(bool enabled);

		// Token: 0x06000136 RID: 310
		void setOfflineMode(bool enabled);

		// Token: 0x06000137 RID: 311
		void setDeviceToken(string deviceToken);

		// Token: 0x06000138 RID: 312
		void start(AdjustConfig adjustConfig);

		// Token: 0x06000139 RID: 313
		void trackEvent(AdjustEvent adjustEvent);

		// Token: 0x0600013A RID: 314
		string getIdfa();

		// Token: 0x0600013B RID: 315
		void setReferrer(string referrer);

		// Token: 0x0600013C RID: 316
		void getGoogleAdId(Action<string> onDeviceIdsRead);
	}
}
