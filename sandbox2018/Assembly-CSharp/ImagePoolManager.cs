using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000152 RID: 338
public class ImagePoolManager : MonoBehaviour
{
	// Token: 0x0600089E RID: 2206 RVA: 0x000251E4 File Offset: 0x000235E4
	public void Load()
	{
		int pictureAmount = DataManager.Instance.dataConfig.pictureAmount;
		for (int i = 0; i < pictureAmount; i++)
		{
			string text = string.Format("{0:D4}", i + 1);
			Sprite value = this.CreateSprite(text);
			this._imageDic.Add(text, value);
		}
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x0002523C File Offset: 0x0002363C
	private Sprite CreateSprite(string TID)
	{
		string thumbPath = CaptureScreenHelper.GetThumbPath(TID);
		Texture2D texture2D;
		if (!File.Exists(thumbPath))
		{
			texture2D = (Texture2D)Resources.Load("Thumbs/Thumb_" + TID);
		}
		else
		{
			int width = Screen.width;
			int width2 = Screen.width;
			texture2D = new Texture2D(width, width2);
			FileStream fileStream = new FileStream(thumbPath, FileMode.Open, FileAccess.Read);
			fileStream.Seek(0L, SeekOrigin.Begin);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Close();
			fileStream.Dispose();
			texture2D.LoadImage(array);
		}
		return Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f));
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x00025314 File Offset: 0x00023714
	public void UpdateSprite(string TID, Texture2D texture)
	{
		if (this._imageDic.Remove(TID))
		{
			Sprite value = Sprite.Create(texture, new Rect(0f, 0f, (float)texture.width, (float)texture.height), new Vector2(0.5f, 0.5f));
			this._imageDic.Add(TID, value);
		}
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x00025374 File Offset: 0x00023774
	public Sprite GetSprite(string TID)
	{
		Sprite sprite;
		this._imageDic.TryGetValue(TID, out sprite);
		if (sprite == null)
		{
			sprite = this.CreateSprite(TID);
			this._imageDic.Add(TID, sprite);
		}
		return sprite;
	}

	// Token: 0x1700009B RID: 155
	// (get) Token: 0x060008A2 RID: 2210 RVA: 0x000253B4 File Offset: 0x000237B4
	public static ImagePoolManager Instance
	{
		get
		{
			if (ImagePoolManager._instance == null)
			{
				GameObject gameObject = new GameObject("ImagePoolManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				ImagePoolManager._instance = gameObject.AddComponent<ImagePoolManager>();
			}
			return ImagePoolManager._instance;
		}
	}

	// Token: 0x04000557 RID: 1367
	private Dictionary<string, Sprite> _imageDic = new Dictionary<string, Sprite>();

	// Token: 0x04000558 RID: 1368
	private static ImagePoolManager _instance;
}
