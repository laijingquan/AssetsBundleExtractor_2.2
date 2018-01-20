using System;
using com.adjust.sdk;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class ExampleGUI : MonoBehaviour
{
	// Token: 0x060000B4 RID: 180 RVA: 0x0000541C File Offset: 0x0000381C
	private void OnGUI()
	{
		if (this.showPopUp)
		{
			GUI.Window(0, new Rect((float)(Screen.width / 2 - 150), (float)(Screen.height / 2 - 65), 300f, 130f), new GUI.WindowFunction(this.showGUI), "Is SDK enabled?");
		}
		if (GUI.Button(new Rect(0f, (float)(Screen.height * 0 / this.numberOfButtons), (float)Screen.width, (float)(Screen.height / this.numberOfButtons)), this.txtManualLaunch) && !string.Equals(this.txtManualLaunch, "SDK Launched", StringComparison.OrdinalIgnoreCase))
		{
			AdjustConfig adjustConfig = new AdjustConfig("2fm9gkqubvpc", AdjustEnvironment.Sandbox);
			adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
			adjustConfig.setLogDelegate(delegate(string msg)
			{
				Debug.Log(msg);
			});
			adjustConfig.setSendInBackground(true);
			adjustConfig.setLaunchDeferredDeeplink(true);
			adjustConfig.setEventSuccessDelegate(new Action<AdjustEventSuccess>(this.EventSuccessCallback), "Adjust");
			adjustConfig.setEventFailureDelegate(new Action<AdjustEventFailure>(this.EventFailureCallback), "Adjust");
			adjustConfig.setSessionSuccessDelegate(new Action<AdjustSessionSuccess>(this.SessionSuccessCallback), "Adjust");
			adjustConfig.setSessionFailureDelegate(new Action<AdjustSessionFailure>(this.SessionFailureCallback), "Adjust");
			adjustConfig.setDeferredDeeplinkDelegate(new Action<string>(this.DeferredDeeplinkCallback), "Adjust");
			adjustConfig.setAttributionChangedDelegate(new Action<AdjustAttribution>(this.AttributionChangedCallback), "Adjust");
			Adjust.start(adjustConfig);
			this.isEnabled = true;
			this.txtManualLaunch = "SDK Launched";
		}
		if (GUI.Button(new Rect(0f, (float)(Screen.height / this.numberOfButtons), (float)Screen.width, (float)(Screen.height / this.numberOfButtons)), "Track Simple Event"))
		{
			AdjustEvent adjustEvent = new AdjustEvent("g3mfiw");
			Adjust.trackEvent(adjustEvent);
		}
		if (GUI.Button(new Rect(0f, (float)(Screen.height * 2 / this.numberOfButtons), (float)Screen.width, (float)(Screen.height / this.numberOfButtons)), "Track Revenue Event"))
		{
			AdjustEvent adjustEvent2 = new AdjustEvent("a4fd35");
			adjustEvent2.setRevenue(0.25, "EUR");
			Adjust.trackEvent(adjustEvent2);
		}
		if (GUI.Button(new Rect(0f, (float)(Screen.height * 3 / this.numberOfButtons), (float)Screen.width, (float)(Screen.height / this.numberOfButtons)), "Track Callback Event"))
		{
			AdjustEvent adjustEvent3 = new AdjustEvent("34vgg9");
			adjustEvent3.addCallbackParameter("key", "value");
			adjustEvent3.addCallbackParameter("foo", "bar");
			Adjust.trackEvent(adjustEvent3);
		}
		if (GUI.Button(new Rect(0f, (float)(Screen.height * 4 / this.numberOfButtons), (float)Screen.width, (float)(Screen.height / this.numberOfButtons)), "Track Partner Event"))
		{
			AdjustEvent adjustEvent4 = new AdjustEvent("w788qs");
			adjustEvent4.addPartnerParameter("key", "value");
			adjustEvent4.addPartnerParameter("foo", "bar");
			Adjust.trackEvent(adjustEvent4);
		}
		if (GUI.Button(new Rect(0f, (float)(Screen.height * 5 / this.numberOfButtons), (float)Screen.width, (float)(Screen.height / this.numberOfButtons)), this.txtSetOfflineMode))
		{
			if (string.Equals(this.txtSetOfflineMode, "Turn Offline Mode ON", StringComparison.OrdinalIgnoreCase))
			{
				Adjust.setOfflineMode(true);
				this.txtSetOfflineMode = "Turn Offline Mode OFF";
			}
			else
			{
				Adjust.setOfflineMode(false);
				this.txtSetOfflineMode = "Turn Offline Mode ON";
			}
		}
		if (GUI.Button(new Rect(0f, (float)(Screen.height * 6 / this.numberOfButtons), (float)Screen.width, (float)(Screen.height / this.numberOfButtons)), this.txtSetEnabled))
		{
			if (string.Equals(this.txtSetEnabled, "Disable SDK", StringComparison.OrdinalIgnoreCase))
			{
				Adjust.setEnabled(false);
				this.txtSetEnabled = "Enable SDK";
			}
			else
			{
				Adjust.setEnabled(true);
				this.txtSetEnabled = "Disable SDK";
			}
		}
		if (GUI.Button(new Rect(0f, (float)(Screen.height * 7 / this.numberOfButtons), (float)Screen.width, (float)(Screen.height / this.numberOfButtons)), "Is SDK Enabled?"))
		{
			this.isEnabled = Adjust.isEnabled();
			this.showPopUp = true;
		}
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00005874 File Offset: 0x00003C74
	private void showGUI(int windowID)
	{
		if (this.isEnabled)
		{
			GUI.Label(new Rect(65f, 40f, 200f, 30f), "Adjust SDK is ENABLED!");
		}
		else
		{
			GUI.Label(new Rect(65f, 40f, 200f, 30f), "Adjust SDK is DISABLED!");
		}
		if (GUI.Button(new Rect(90f, 75f, 120f, 40f), "OK"))
		{
			this.showPopUp = false;
		}
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00005906 File Offset: 0x00003D06
	public void handleGooglePlayId(string adId)
	{
		Debug.Log("Google Play Ad ID = " + adId);
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00005918 File Offset: 0x00003D18
	public void AttributionChangedCallback(AdjustAttribution attributionData)
	{
		Debug.Log("Attribution changed!");
		if (attributionData.trackerName != null)
		{
			Debug.Log("Tracker name " + attributionData.trackerName);
		}
		if (attributionData.trackerToken != null)
		{
			Debug.Log("Tracker token " + attributionData.trackerToken);
		}
		if (attributionData.network != null)
		{
			Debug.Log("Network " + attributionData.network);
		}
		if (attributionData.campaign != null)
		{
			Debug.Log("Campaign " + attributionData.campaign);
		}
		if (attributionData.adgroup != null)
		{
			Debug.Log("Adgroup " + attributionData.adgroup);
		}
		if (attributionData.creative != null)
		{
			Debug.Log("Creative " + attributionData.creative);
		}
		if (attributionData.clickLabel != null)
		{
			Debug.Log("Click label " + attributionData.clickLabel);
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00005A10 File Offset: 0x00003E10
	public void EventSuccessCallback(AdjustEventSuccess eventSuccessData)
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

	// Token: 0x060000B9 RID: 185 RVA: 0x00005AC8 File Offset: 0x00003EC8
	public void EventFailureCallback(AdjustEventFailure eventFailureData)
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

	// Token: 0x060000BA RID: 186 RVA: 0x00005BA4 File Offset: 0x00003FA4
	public void SessionSuccessCallback(AdjustSessionSuccess sessionSuccessData)
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

	// Token: 0x060000BB RID: 187 RVA: 0x00005C3C File Offset: 0x0000403C
	public void SessionFailureCallback(AdjustSessionFailure sessionFailureData)
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

	// Token: 0x060000BC RID: 188 RVA: 0x00005CF6 File Offset: 0x000040F6
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

	// Token: 0x0400002F RID: 47
	private int numberOfButtons = 8;

	// Token: 0x04000030 RID: 48
	private bool isEnabled;

	// Token: 0x04000031 RID: 49
	private bool showPopUp;

	// Token: 0x04000032 RID: 50
	private string txtSetEnabled = "Disable SDK";

	// Token: 0x04000033 RID: 51
	private string txtManualLaunch = "Manual Launch";

	// Token: 0x04000034 RID: 52
	private string txtSetOfflineMode = "Turn Offline Mode ON";
}
