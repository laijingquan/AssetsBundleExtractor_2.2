using System;
using UnityEngine;

// Token: 0x02000196 RID: 406
public class RotationHelper
{
	// Token: 0x06000A91 RID: 2705 RVA: 0x0002D700 File Offset: 0x0002BB00
	public static float getFaceToRotation(Vector2 StartDir, Vector2 EndDir)
	{
		float degreeFromZero = RotationHelper.getDegreeFromZero(StartDir);
		float degreeFromZero2 = RotationHelper.getDegreeFromZero(EndDir);
		return degreeFromZero2 - degreeFromZero;
	}

	// Token: 0x06000A92 RID: 2706 RVA: 0x0002D720 File Offset: 0x0002BB20
	public static float getDegreeFromZero(Vector2 Dir)
	{
		if (Dir.x == 0f && Dir.y > 0f)
		{
			return 0f;
		}
		Vector2 from = new Vector2(0f, 1f);
		float num = Vector2.Angle(from, Dir);
		if (from.x < Dir.x)
		{
			num *= -1f;
			num = 360f + num;
		}
		return num;
	}

	// Token: 0x06000A93 RID: 2707 RVA: 0x0002D792 File Offset: 0x0002BB92
	public static void SetRotation(Transform tra, float tAngel)
	{
		tra.localEulerAngles = new Vector3(0f, 0f, tAngel);
	}

	// Token: 0x06000A94 RID: 2708 RVA: 0x0002D7AC File Offset: 0x0002BBAC
	public static Vector2 RotateVec2(Vector2 StartDir, float tAngel)
	{
		Vector3 point = new Vector3(StartDir.x, StartDir.y, 0f);
		Vector3 vector = Quaternion.AngleAxis(tAngel, new Vector3(0f, 0f, 1f)) * point;
		Vector2 result = new Vector2(vector.x, vector.y);
		return result;
	}
}
