using System;
using System.IO;
using UnityEngine;

// Token: 0x0200018C RID: 396
public class CaptureScreenHelper : MonoBehaviour
{
	// Token: 0x06000A59 RID: 2649 RVA: 0x0002CC34 File Offset: 0x0002B034
	public static Texture2D CaptureCamera(string pictureName)
	{
		Camera main = Camera.main;
		float y = (float)(Screen.height - Screen.width) * 0.5f;
		Rect source = new Rect(0f, y, (float)Screen.width, (float)Screen.width);
		Texture2D texture2D = new Texture2D((int)source.width, (int)source.height, TextureFormat.RGB24, false);
		texture2D.ReadPixels(source, 0, 0, false);
		texture2D.Apply();
		TextureUtility.ScaleBilinear(texture2D, 256, 256);
		byte[] bytes = texture2D.EncodeToPNG();
		string thumbPath = CaptureScreenHelper.GetThumbPath(pictureName);
		File.WriteAllBytes(thumbPath, bytes);
		return texture2D;
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x0002CCC5 File Offset: 0x0002B0C5
	public static string GetThumbPath(string TID)
	{
		return AppConfig.GAME_THUMB_PICTURE_PATH + TID + ".png";
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x0002CCD8 File Offset: 0x0002B0D8
	public static Texture2D CaptureCameraEditor(string pictureName)
	{
		Camera main = Camera.main;
		float y = (float)(Screen.height - Screen.width) * 0.5f;
		Rect source = new Rect(0f, y, (float)Screen.width, (float)Screen.width);
		Texture2D texture2D = new Texture2D((int)source.width, (int)source.height, TextureFormat.RGB24, false);
		texture2D.ReadPixels(source, 0, 0, false);
		texture2D.Apply();
		TextureUtility.ScaleBilinear(texture2D, 256, 256);
		byte[] bytes = texture2D.EncodeToPNG();
		string text = AppConfig.THUMB_PICTURE_FULL_PATH + pictureName + ".png";
		File.WriteAllBytes(text, bytes);
		Debug.Log(string.Format("截屏图片: {0}", text));
		return texture2D;
	}
}
