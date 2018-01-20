using System;
using UnityEngine;

// Token: 0x02000192 RID: 402
public class MathHelper
{
	// Token: 0x06000A70 RID: 2672 RVA: 0x0002D1C1 File Offset: 0x0002B5C1
	public static float Clip(float n, float low, float high)
	{
		if (n < low)
		{
			n = low;
		}
		else if (n > high)
		{
			n = high;
		}
		return n;
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x0002D1E0 File Offset: 0x0002B5E0
	public static void Swap(ref int a, ref int b)
	{
		int num = a;
		a = b;
		b = num;
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x0002D1F8 File Offset: 0x0002B5F8
	public static float GetDecimals(float f)
	{
		int num = Mathf.FloorToInt(f);
		return f - (float)num;
	}
}
