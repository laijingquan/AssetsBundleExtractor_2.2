using System;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine;

// Token: 0x0200019A RID: 410
public class TextureUtility
{
	// Token: 0x06000A9E RID: 2718 RVA: 0x0002D9F6 File Offset: 0x0002BDF6
	public static void ScalePoint(Texture2D tex, int newWidth, int newHeight)
	{
		TextureUtility.ThreadedScale(tex, newWidth, newHeight, false);
	}

	// Token: 0x06000A9F RID: 2719 RVA: 0x0002DA01 File Offset: 0x0002BE01
	public static void ScaleBilinear(Texture2D tex, int newWidth, int newHeight)
	{
		TextureUtility.ThreadedScale(tex, newWidth, newHeight, true);
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x0002DA0C File Offset: 0x0002BE0C
	private static void ThreadedScale(Texture2D tex, int newWidth, int newHeight, bool useBilinear)
	{
		TextureUtility.texColors = tex.GetPixels();
		TextureUtility.newColors = new Color[newWidth * newHeight];
		if (useBilinear)
		{
			TextureUtility.ratioX = 1f / ((float)newWidth / (float)(tex.width - 1));
			TextureUtility.ratioY = 1f / ((float)newHeight / (float)(tex.height - 1));
		}
		else
		{
			TextureUtility.ratioX = (float)tex.width / (float)newWidth;
			TextureUtility.ratioY = (float)tex.height / (float)newHeight;
		}
		TextureUtility.w = tex.width;
		TextureUtility.w2 = newWidth;
		int num = Mathf.Min(SystemInfo.processorCount, newHeight);
		int num2 = newHeight / num;
		TextureUtility.finishCount = 0;
		if (TextureUtility.mutex == null)
		{
			TextureUtility.mutex = new Mutex(false);
		}
		if (num > 1)
		{
			int i;
			TextureUtility.ThreadData threadData;
			for (i = 0; i < num - 1; i++)
			{
				threadData = new TextureUtility.ThreadData(num2 * i, num2 * (i + 1));
				ParameterizedThreadStart start = (!useBilinear) ? new ParameterizedThreadStart(TextureUtility.PointScale) : new ParameterizedThreadStart(TextureUtility.BilinearScale);
				Thread thread = new Thread(start);
				thread.Start(threadData);
			}
			threadData = new TextureUtility.ThreadData(num2 * i, newHeight);
			if (useBilinear)
			{
				TextureUtility.BilinearScale(threadData);
			}
			else
			{
				TextureUtility.PointScale(threadData);
			}
			while (TextureUtility.finishCount < num)
			{
				Thread.Sleep(1);
			}
		}
		else
		{
			TextureUtility.ThreadData obj = new TextureUtility.ThreadData(0, newHeight);
			if (useBilinear)
			{
				TextureUtility.BilinearScale(obj);
			}
			else
			{
				TextureUtility.PointScale(obj);
			}
		}
		tex.Resize(newWidth, newHeight);
		tex.SetPixels(TextureUtility.newColors);
		tex.Apply();
	}

	// Token: 0x06000AA1 RID: 2721 RVA: 0x0002DBA0 File Offset: 0x0002BFA0
	public static void BilinearScale(object obj)
	{
		TextureUtility.ThreadData threadData = (TextureUtility.ThreadData)obj;
		for (int i = threadData.start; i < threadData.end; i++)
		{
			int num = (int)Mathf.Floor((float)i * TextureUtility.ratioY);
			int num2 = num * TextureUtility.w;
			int num3 = (num + 1) * TextureUtility.w;
			int num4 = i * TextureUtility.w2;
			for (int j = 0; j < TextureUtility.w2; j++)
			{
				int num5 = (int)Mathf.Floor((float)j * TextureUtility.ratioX);
				float value = (float)j * TextureUtility.ratioX - (float)num5;
				TextureUtility.newColors[num4 + j] = TextureUtility.ColorLerpUnclamped(TextureUtility.ColorLerpUnclamped(TextureUtility.texColors[num2 + num5], TextureUtility.texColors[num2 + num5 + 1], value), TextureUtility.ColorLerpUnclamped(TextureUtility.texColors[num3 + num5], TextureUtility.texColors[num3 + num5 + 1], value), (float)i * TextureUtility.ratioY - (float)num);
			}
		}
		TextureUtility.mutex.WaitOne();
		TextureUtility.finishCount++;
		TextureUtility.mutex.ReleaseMutex();
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x0002DCDC File Offset: 0x0002C0DC
	public static void PointScale(object obj)
	{
		TextureUtility.ThreadData threadData = (TextureUtility.ThreadData)obj;
		for (int i = threadData.start; i < threadData.end; i++)
		{
			int num = (int)(TextureUtility.ratioY * (float)i) * TextureUtility.w;
			int num2 = i * TextureUtility.w2;
			for (int j = 0; j < TextureUtility.w2; j++)
			{
				TextureUtility.newColors[num2 + j] = TextureUtility.texColors[(int)((float)num + TextureUtility.ratioX * (float)j)];
			}
		}
		TextureUtility.mutex.WaitOne();
		TextureUtility.finishCount++;
		TextureUtility.mutex.ReleaseMutex();
	}

	// Token: 0x06000AA3 RID: 2723 RVA: 0x0002DD90 File Offset: 0x0002C190
	private static Color ColorLerpUnclamped(Color c1, Color c2, float value)
	{
		return new Color(c1.r + (c2.r - c1.r) * value, c1.g + (c2.g - c1.g) * value, c1.b + (c2.b - c1.b) * value, c1.a + (c2.a - c1.a) * value);
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x0002DE08 File Offset: 0x0002C208
	public static Texture2D LoadTexture(string filePath)
	{
		Texture2D texture2D = null;
		if (File.Exists(filePath))
		{
			byte[] data = File.ReadAllBytes(filePath);
			texture2D = new Texture2D(2, 2, TextureFormat.ARGB32, false);
			texture2D.LoadImage(data);
		}
		return texture2D;
	}

	// Token: 0x06000AA5 RID: 2725 RVA: 0x0002DE3C File Offset: 0x0002C23C
	public static void SaveScreenShotAsync(string path, Vector2 size)
	{
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x0002DE3E File Offset: 0x0002C23E
	public static void SaveScreenShotAsync(string path, Rect rect, Vector2 size)
	{
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x0002DE40 File Offset: 0x0002C240
	public static IEnumerator SaveScreenShot(string path, Vector2 size)
	{
		yield return null;
		yield break;
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x0002DE54 File Offset: 0x0002C254
	public static IEnumerator SaveScreenShot(string path, Rect rect, Vector2 size = default(Vector2))
	{
		yield return new WaitForEndOfFrame();
		Texture2D tex = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
		tex.ReadPixels(rect, 0, 0);
		tex.Apply();
		if (size != default(Vector2))
		{
			TextureUtility.ScaleBilinear(tex, (int)size.x, (int)size.y);
		}
		byte[] buffer = tex.EncodeToJPG(100);
		UnityEngine.Object.Destroy(tex);
		File.WriteAllBytes(path, buffer);
		yield break;
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x0002DE7D File Offset: 0x0002C27D
	public static Texture2D Copy(Texture2D tex)
	{
		return new Texture2D(tex.width, tex.height, tex.format, false);
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x0002DE98 File Offset: 0x0002C298
	public static Texture2D SetSepia(Texture2D tex)
	{
		Texture2D texture2D = TextureUtility.Copy(tex);
		Color[] pixels = tex.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			float a = pixels[i].a;
			float num = pixels[i].r * 0.299f + pixels[i].g * 0.587f + pixels[i].b * 0.114f;
			Color color = new Color(num, num, num);
			pixels[i] = new Color(color.r * 1f, color.g * 0.95f, color.b * 0.82f, a);
		}
		texture2D.SetPixels(pixels);
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x0002DF64 File Offset: 0x0002C364
	public static Texture2D SetGrayscale(Texture2D tex)
	{
		Texture2D texture2D = TextureUtility.Copy(tex);
		Color[] pixels = tex.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			float num = (pixels[i].r + pixels[i].g + pixels[i].b) / 3f;
			pixels[i] = new Color(num, num, num);
		}
		texture2D.SetPixels(pixels);
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x0002DFE4 File Offset: 0x0002C3E4
	public static Texture2D SetPixelate(Texture2D tex, int size)
	{
		Texture2D texture2D = TextureUtility.Copy(tex);
		Rect rect = new Rect(0f, 0f, (float)tex.width, (float)tex.height);
		int num = (int)rect.x;
		while ((float)num < rect.x + rect.width && num < tex.width)
		{
			int num2 = (int)rect.y;
			while ((float)num2 < rect.y + rect.height && num2 < tex.height)
			{
				int num3 = size / 2;
				int num4 = size / 2;
				while (num + num3 >= tex.width)
				{
					num3--;
				}
				while (num2 + num4 >= tex.height)
				{
					num4--;
				}
				Color pixel = tex.GetPixel(num + num3, num2 + num4);
				int num5 = num;
				while (num5 < num + size && num5 < tex.width)
				{
					int num6 = num2;
					while (num6 < num2 + size && num6 < tex.height)
					{
						texture2D.SetPixel(num5, num6, pixel);
						num6++;
					}
					num5++;
				}
				num2 += size;
			}
			num += size;
		}
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x0002E12C File Offset: 0x0002C52C
	public static Texture2D SetNegative(Texture2D tex)
	{
		Texture2D texture2D = TextureUtility.Copy(tex);
		Color[] pixels = tex.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			Color color = pixels[i];
			pixels[i] = new Color(1f - color.r, 1f - color.g, 1f - color.b);
		}
		texture2D.SetPixels(pixels);
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x0002E1B0 File Offset: 0x0002C5B0
	public static Texture2D SetFoggy(Texture2D tex)
	{
		Texture2D texture2D = TextureUtility.Copy(tex);
		for (int i = 1; i < tex.width - 1; i++)
		{
			for (int j = 1; j < tex.height - 1; j++)
			{
				int num = UnityEngine.Random.Range(0, 123456);
				int num2 = i + num % 19;
				int num3 = j + num % 19;
				if (num2 >= tex.width)
				{
					num2 = tex.width - 1;
				}
				if (num3 >= tex.height)
				{
					num3 = tex.height - 1;
				}
				Color pixel = tex.GetPixel(num2, num3);
				texture2D.SetPixel(i, j, pixel);
			}
		}
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x0002E260 File Offset: 0x0002C660
	public static Texture2D SetSoft(Texture2D tex)
	{
		Texture2D texture2D = TextureUtility.Copy(tex);
		int[] array = new int[]
		{
			1,
			2,
			1,
			2,
			4,
			2,
			1,
			2,
			1
		};
		for (int i = 1; i < tex.width - 1; i++)
		{
			for (int j = 1; j < tex.height - 1; j++)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				int num4 = 0;
				for (int k = -1; k <= 1; k++)
				{
					for (int l = -1; l <= 1; l++)
					{
						Color pixel = tex.GetPixel(i + l, j + k);
						num += pixel.r * (float)array[num4];
						num2 += pixel.g * (float)array[num4];
						num3 += pixel.b * (float)array[num4];
						num4++;
					}
				}
				num /= 16f;
				num2 /= 16f;
				num3 /= 16f;
				num = ((num <= 1f) ? num : 1f);
				num = ((num >= 0f) ? num : 0f);
				num2 = ((num2 <= 1f) ? num2 : 1f);
				num2 = ((num2 >= 0f) ? num2 : 0f);
				num3 = ((num3 <= 1f) ? num3 : 1f);
				num3 = ((num3 >= 0f) ? num3 : 0f);
				texture2D.SetPixel(i - 1, j - 1, new Color(num, num2, num3));
			}
		}
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x0002E424 File Offset: 0x0002C824
	public static Texture2D SetSharp(Texture2D tex)
	{
		Texture2D texture2D = TextureUtility.Copy(tex);
		int[] array = new int[]
		{
			-1,
			-1,
			-1,
			-1,
			9,
			-1,
			-1,
			-1,
			-1
		};
		for (int i = 1; i < tex.width - 1; i++)
		{
			for (int j = 1; j < tex.height - 1; j++)
			{
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				int num4 = 0;
				for (int k = -1; k <= 1; k++)
				{
					for (int l = -1; l <= 1; l++)
					{
						Color pixel = tex.GetPixel(i + l, j + k);
						num += pixel.r * (float)array[num4];
						num2 += pixel.g * (float)array[num4];
						num3 += pixel.b * (float)array[num4];
						num4++;
					}
				}
				num = ((num <= 1f) ? num : 1f);
				num = ((num >= 0f) ? num : 0f);
				num2 = ((num2 <= 1f) ? num2 : 1f);
				num2 = ((num2 >= 0f) ? num2 : 0f);
				num3 = ((num3 <= 1f) ? num3 : 1f);
				num3 = ((num3 >= 0f) ? num3 : 0f);
				texture2D.SetPixel(i - 1, j - 1, new Color(num, num2, num3));
			}
		}
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x0002E5CC File Offset: 0x0002C9CC
	public static Texture2D SetRelief(Texture2D tex)
	{
		Texture2D texture2D = TextureUtility.Copy(tex);
		for (int i = 0; i < tex.width - 1; i++)
		{
			for (int j = 0; j < tex.height - 1; j++)
			{
				Color pixel = tex.GetPixel(i, j);
				Color pixel2 = tex.GetPixel(i + 1, j + 1);
				float num = Mathf.Abs(pixel.r - pixel2.r + 0.5f);
				float num2 = Mathf.Abs(pixel.g - pixel2.g + 0.5f);
				float num3 = Mathf.Abs(pixel.b - pixel2.b + 0.5f);
				if (num > 1f)
				{
					num = 1f;
				}
				if (num < 0f)
				{
					num = 0f;
				}
				if (num2 > 1f)
				{
					num2 = 1f;
				}
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				if (num3 > 1f)
				{
					num3 = 1f;
				}
				if (num3 < 0f)
				{
					num3 = 0f;
				}
				texture2D.SetPixel(i, j, new Color(num, num2, num3));
			}
		}
		texture2D.Apply();
		return texture2D;
	}

	// Token: 0x04000635 RID: 1589
	private static Color[] texColors;

	// Token: 0x04000636 RID: 1590
	private static Color[] newColors;

	// Token: 0x04000637 RID: 1591
	private static int w;

	// Token: 0x04000638 RID: 1592
	private static float ratioX;

	// Token: 0x04000639 RID: 1593
	private static float ratioY;

	// Token: 0x0400063A RID: 1594
	private static int w2;

	// Token: 0x0400063B RID: 1595
	private static int finishCount;

	// Token: 0x0400063C RID: 1596
	private static Mutex mutex;

	// Token: 0x0200019B RID: 411
	public class ThreadData
	{
		// Token: 0x06000AB2 RID: 2738 RVA: 0x0002E718 File Offset: 0x0002CB18
		public ThreadData(int s, int e)
		{
			this.start = s;
			this.end = e;
		}

		// Token: 0x0400063D RID: 1597
		public int start;

		// Token: 0x0400063E RID: 1598
		public int end;
	}
}
