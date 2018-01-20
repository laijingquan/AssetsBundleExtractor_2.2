using System;
using System.IO;
using UnityEngine;

// Token: 0x02000199 RID: 409
public class TextureHelper : MonoBehaviour
{
	// Token: 0x06000A9C RID: 2716 RVA: 0x0002D964 File Offset: 0x0002BD64
	public static Texture2D LoadTextureByIO(string TID)
	{
		Texture2D texture2D = new Texture2D(0, 0);
		string thumbPath = CaptureScreenHelper.GetThumbPath(TID);
		if (!File.Exists(thumbPath))
		{
			return null;
		}
		FileStream fileStream = new FileStream(thumbPath, FileMode.Open, FileAccess.Read);
		fileStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, (int)fileStream.Length);
		fileStream.Close();
		fileStream.Dispose();
		int width = Screen.width;
		int width2 = Screen.width;
		texture2D = new Texture2D(width, width2);
		texture2D.LoadImage(array);
		return texture2D;
	}
}
