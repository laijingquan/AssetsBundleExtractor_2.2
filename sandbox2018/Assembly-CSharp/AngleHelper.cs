using System;

// Token: 0x02000187 RID: 391
public class AngleHelper
{
	// Token: 0x06000A46 RID: 2630 RVA: 0x0002C8D5 File Offset: 0x0002ACD5
	public static float LimitAngleIn0_360(float angle)
	{
		return (angle % 360f + 360f) % 360f;
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x0002C8EA File Offset: 0x0002ACEA
	public static float LimitAngleInNPI_PI(float angle)
	{
		angle = AngleHelper.LimitAngleIn0_360(angle);
		if (angle > 180f)
		{
			angle -= 360f;
		}
		return angle;
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x0002C909 File Offset: 0x0002AD09
	public static float AngleToRadius(float angle)
	{
		return angle / 180f * 3.14159274f;
	}
}
