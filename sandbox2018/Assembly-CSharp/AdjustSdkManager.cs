using System;
using com.adjust.sdk;
using UnityEngine;

// Token: 0x02000156 RID: 342
public class AdjustSdkManager : MonoBehaviour
{
	// Token: 0x060008B4 RID: 2228 RVA: 0x00025880 File Offset: 0x00023C80
	public void EventGroup1VipShow()
	{
		AdjustEvent adjustEvent = new AdjustEvent("c1gim7");
		Adjust.trackEvent(adjustEvent);
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x000258A0 File Offset: 0x00023CA0
	public void EventGroup1VipPay()
	{
		AdjustEvent adjustEvent = new AdjustEvent("45amzi");
		Adjust.trackEvent(adjustEvent);
	}

	// Token: 0x060008B6 RID: 2230 RVA: 0x000258C0 File Offset: 0x00023CC0
	public void EventGroup2VipShow()
	{
		AdjustEvent adjustEvent = new AdjustEvent("a46w9r");
		Adjust.trackEvent(adjustEvent);
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x000258E0 File Offset: 0x00023CE0
	public void EventGroup2VipPay1()
	{
		AdjustEvent adjustEvent = new AdjustEvent("1n465c");
		Adjust.trackEvent(adjustEvent);
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x00025900 File Offset: 0x00023D00
	public void EventGroup2VipPay2()
	{
		AdjustEvent adjustEvent = new AdjustEvent("jjcwb6");
		Adjust.trackEvent(adjustEvent);
	}

	// Token: 0x1700009E RID: 158
	// (get) Token: 0x060008B9 RID: 2233 RVA: 0x00025920 File Offset: 0x00023D20
	public static AdjustSdkManager Instance
	{
		get
		{
			if (AdjustSdkManager._instance == null)
			{
				GameObject gameObject = new GameObject("AdjustSdkManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				AdjustSdkManager._instance = gameObject.AddComponent<AdjustSdkManager>();
			}
			return AdjustSdkManager._instance;
		}
	}

	// Token: 0x0400056B RID: 1387
	private static AdjustSdkManager _instance;
}
