using System;
using UnityEngine;

// Token: 0x020001A2 RID: 418
public static class Vibration
{
	// Token: 0x06000ACD RID: 2765 RVA: 0x0002EDE1 File Offset: 0x0002D1E1
	public static void Vibrate()
	{
		if (Vibration.isAndroid())
		{
			Vibration.vibrator.Call("vibrate", new object[0]);
		}
		else
		{
			Handheld.Vibrate();
		}
	}

	// Token: 0x06000ACE RID: 2766 RVA: 0x0002EE0C File Offset: 0x0002D20C
	public static void Vibrate(long milliseconds)
	{
		if (Vibration.isAndroid())
		{
			Vibration.vibrator.Call("vibrate", new object[]
			{
				milliseconds
			});
		}
		else
		{
			Handheld.Vibrate();
		}
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x0002EE40 File Offset: 0x0002D240
	public static void Vibrate(long[] pattern, int repeat)
	{
		if (Vibration.isAndroid())
		{
			Vibration.vibrator.Call("vibrate", new object[]
			{
				pattern,
				repeat
			});
		}
		else
		{
			Handheld.Vibrate();
		}
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x0002EE78 File Offset: 0x0002D278
	public static bool HasVibrator()
	{
		return Vibration.isAndroid();
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x0002EE7F File Offset: 0x0002D27F
	public static void Cancel()
	{
		if (Vibration.isAndroid())
		{
			Vibration.vibrator.Call("cancel", new object[0]);
		}
	}

	// Token: 0x06000AD2 RID: 2770 RVA: 0x0002EEA0 File Offset: 0x0002D2A0
	private static bool isAndroid()
	{
		return true;
	}

	// Token: 0x0400064C RID: 1612
	public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

	// Token: 0x0400064D RID: 1613
	public static AndroidJavaObject currentActivity = Vibration.unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

	// Token: 0x0400064E RID: 1614
	public static AndroidJavaObject vibrator = Vibration.currentActivity.Call<AndroidJavaObject>("getSystemService", new object[]
	{
		"vibrator"
	});
}
