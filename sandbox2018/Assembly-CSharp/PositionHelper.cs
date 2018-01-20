using System;
using UnityEngine;

// Token: 0x02000193 RID: 403
public class PositionHelper
{
	// Token: 0x06000A74 RID: 2676 RVA: 0x0002D21C File Offset: 0x0002B61C
	public static void SetPosX(Transform tras, float XValue)
	{
		float worldPosX = PositionHelper.GetWorldPosX(XValue);
		Vector3 position = tras.position;
		tras.position = new Vector3(worldPosX, position.y, position.z);
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x0002D254 File Offset: 0x0002B654
	public static void SetPosY(Transform tras, float YValue)
	{
		float worldPosY = PositionHelper.GetWorldPosY(YValue);
		Vector3 position = tras.position;
		tras.position = new Vector3(position.x, worldPosY, position.z);
	}

	// Token: 0x06000A76 RID: 2678 RVA: 0x0002D28C File Offset: 0x0002B68C
	public static void SetPosValue(Transform tras, float Xvalue, float Yvalue)
	{
		Vector2 screenPos = new Vector2(Xvalue, Yvalue);
		PositionHelper.SetPos(tras, screenPos);
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x0002D2AC File Offset: 0x0002B6AC
	public static void SetPos(Transform tras, Vector2 screenPos)
	{
		Vector3 worldPos = PositionHelper.GetWorldPos(screenPos);
		tras.position = worldPos;
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x0002D2C8 File Offset: 0x0002B6C8
	public static bool IsPosOutOfScreen(Vector2 ScreenPos)
	{
		int num = 540;
		int num2 = 960;
		bool result = false;
		if (ScreenPos.x > (float)(num + 300) || ScreenPos.x < (float)(-(float)(num + 200)))
		{
			result = true;
		}
		else if (ScreenPos.y > (float)(num2 + 300) || ScreenPos.y < (float)(-(float)(num2 + 200)))
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x0002D33F File Offset: 0x0002B73F
	public static Vector2 GetPos(Transform tras)
	{
		return PositionHelper.GetScreenPos(tras);
	}

	// Token: 0x06000A7A RID: 2682 RVA: 0x0002D348 File Offset: 0x0002B748
	public static Vector2 ConvertToPos(float WorldPosX, float WorldPosY)
	{
		float x = WorldPosX * PositionHelper.WorldToScreenRate;
		float y = WorldPosY * PositionHelper.WorldToScreenRate;
		Vector2 result = new Vector2(x, y);
		return result;
	}

	// Token: 0x06000A7B RID: 2683 RVA: 0x0002D370 File Offset: 0x0002B770
	public static Vector2 ConvertToWorldPos(float ScreenPosX, float ScreenPosY)
	{
		float x = ScreenPosX * PositionHelper.ScreenToWorldToRate;
		float y = ScreenPosY * PositionHelper.ScreenToWorldToRate;
		Vector2 result = new Vector2(x, y);
		return result;
	}

	// Token: 0x06000A7C RID: 2684 RVA: 0x0002D398 File Offset: 0x0002B798
	private static Vector2 GetScreenPos(Transform tras)
	{
		float x = tras.position.x * PositionHelper.WorldToScreenRate;
		float y = tras.position.y * PositionHelper.WorldToScreenRate;
		Vector2 result = new Vector2(x, y);
		return result;
	}

	// Token: 0x06000A7D RID: 2685 RVA: 0x0002D3DC File Offset: 0x0002B7DC
	private static float GetScreenPosX(Transform tras)
	{
		return tras.position.x * PositionHelper.WorldToScreenRate;
	}

	// Token: 0x06000A7E RID: 2686 RVA: 0x0002D400 File Offset: 0x0002B800
	private static float GetScreenPosY(Transform tras)
	{
		return tras.position.y * PositionHelper.WorldToScreenRate;
	}

	// Token: 0x06000A7F RID: 2687 RVA: 0x0002D424 File Offset: 0x0002B824
	public static Vector3 GetWorldPos(Vector2 screenPos)
	{
		float x = screenPos.x * PositionHelper.ScreenToWorldToRate;
		float y = screenPos.y * PositionHelper.ScreenToWorldToRate;
		Vector3 result = new Vector3(x, y, 0f);
		return result;
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x0002D45C File Offset: 0x0002B85C
	private static float GetWorldPosX(float WorldPosX)
	{
		return WorldPosX * PositionHelper.ScreenToWorldToRate;
	}

	// Token: 0x06000A81 RID: 2689 RVA: 0x0002D474 File Offset: 0x0002B874
	private static float GetWorldPosY(float WorldPosY)
	{
		return WorldPosY * PositionHelper.ScreenToWorldToRate;
	}

	// Token: 0x04000632 RID: 1586
	private static float WorldToScreenRate = 67.5f;

	// Token: 0x04000633 RID: 1587
	private static float ScreenToWorldToRate = 0.0148148146f;
}
