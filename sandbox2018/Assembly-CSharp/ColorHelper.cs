using System;
using UnityEngine;

// Token: 0x0200018D RID: 397
public class ColorHelper : MonoBehaviour
{
	// Token: 0x06000A5D RID: 2653 RVA: 0x0002CD8C File Offset: 0x0002B18C
	public static float GetGreyValue(Color c, float k1, float k2)
	{
		return (c.r * 0.299f + c.g * 0.587f + c.b * 0.114f) * k1 + k2;
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x0002CDBC File Offset: 0x0002B1BC
	public static Color GetSelectColor(Color c)
	{
		float num = c.r * 0.299f + c.g * 0.587f + c.b * 0.114f;
		if (num <= 0.753f)
		{
			return c;
		}
		return new Color(c.r, c.g - 0.275f, c.b, 1f);
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x0002CE28 File Offset: 0x0002B228
	public static Color GetNumberColor(Color c)
	{
		float num = c.r * 0.299f + c.g * 0.587f + c.b * 0.114f;
		if (num <= 0.753f)
		{
			return Color.white;
		}
		return Color.black;
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x0002CE78 File Offset: 0x0002B278
	public static Color GenColorAlpha(Color c, float a)
	{
		Color result = new Color(c.r, c.g, c.b, c.a * a);
		return result;
	}
}
