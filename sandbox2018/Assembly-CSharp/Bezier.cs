using System;
using UnityEngine;

// Token: 0x0200018A RID: 394
[Serializable]
public class Bezier
{
	// Token: 0x06000A51 RID: 2641 RVA: 0x0002CAE4 File Offset: 0x0002AEE4
	public Bezier(Vector3[] points)
	{
		this.points = points;
	}

	// Token: 0x06000A52 RID: 2642 RVA: 0x0002CAF4 File Offset: 0x0002AEF4
	public Vector3 GetPoint(float t)
	{
		Vector3 vector = default(Vector3);
		int num = this.points.Length;
		float f = 1f - t;
		float num2 = (float)(num - 1);
		float num3 = 0f;
		for (int i = 0; i < num; i++)
		{
			int num4 = (i != 0 && i != num - 1) ? (num - 1) : 1;
			vector += (float)num4 * this.points[i] * Mathf.Pow(f, num2) * Mathf.Pow(t, num3);
			num2 -= 1f;
			num3 += 1f;
		}
		return vector;
	}

	// Token: 0x0400062D RID: 1581
	public Vector3[] points;
}
