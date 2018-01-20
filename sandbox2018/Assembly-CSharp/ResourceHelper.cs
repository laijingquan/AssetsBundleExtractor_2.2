using System;
using UnityEngine;

// Token: 0x02000195 RID: 405
public class ResourceHelper
{
	// Token: 0x06000A8B RID: 2699 RVA: 0x0002D5C0 File Offset: 0x0002B9C0
	public static Transform LoadUI(string name, Transform parent)
	{
		GameObject gameObject = ResourceHelper.Load(name);
		gameObject.transform.SetParent(parent);
		TransformHelper.TransformReset(gameObject.transform);
		return gameObject.transform;
	}

	// Token: 0x06000A8C RID: 2700 RVA: 0x0002D5F4 File Offset: 0x0002B9F4
	public static Sprite LoadSprite(string name)
	{
		Texture2D texture2D = (Texture2D)Resources.Load(name);
		return Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0.5f, 0.5f));
	}

	// Token: 0x06000A8D RID: 2701 RVA: 0x0002D644 File Offset: 0x0002BA44
	public static GameObject Load(string name)
	{
		UnityEngine.Object @object = Resources.Load(name);
		Assert.assert(@object != null, "wrong prefab path:" + name);
		return UnityEngine.Object.Instantiate(@object) as GameObject;
	}

	// Token: 0x06000A8E RID: 2702 RVA: 0x0002D67C File Offset: 0x0002BA7C
	public static Transform Instantiate(UnityEngine.Object prefab)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab) as GameObject;
		return gameObject.transform;
	}

	// Token: 0x06000A8F RID: 2703 RVA: 0x0002D69C File Offset: 0x0002BA9C
	public static byte[] QueryFileContent(string fileName)
	{
		byte[] array = null;
		int length = fileName.IndexOf(".");
		string path = fileName.Substring(0, length);
		object obj = Resources.Load(path);
		if (obj is TextAsset)
		{
			array = ((TextAsset)obj).bytes;
		}
		if (array == null)
		{
			Trace.trace("unsupport file type, name = " + fileName, Trace.CHANNEL.IO);
		}
		return array;
	}
}
