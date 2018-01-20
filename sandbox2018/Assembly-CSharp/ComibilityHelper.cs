using System;
using UnityEngine;

// Token: 0x0200018E RID: 398
public class ComibilityHelper
{
	// Token: 0x06000A62 RID: 2658 RVA: 0x0002CEB4 File Offset: 0x0002B2B4
	public static float GetAspectRadio()
	{
		float num = (float)Screen.height * 1f / (float)Screen.width;
		return 1.77777779f / num;
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x0002CEDE File Offset: 0x0002B2DE
	public static bool IsWideScreen()
	{
		return ComibilityHelper.GetAspectRadio() > 1.3f;
	}
}
