using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public static class ComponentExtensions
{
	// Token: 0x0600049D RID: 1181 RVA: 0x00015249 File Offset: 0x00013649
	public static RectTransform rectTransform(this Component cp)
	{
		return cp.transform as RectTransform;
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x00015256 File Offset: 0x00013656
	public static float Remap(this float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
}
