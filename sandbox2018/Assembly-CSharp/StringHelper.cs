using System;
using System.IO;

// Token: 0x02000198 RID: 408
public class StringHelper
{
	// Token: 0x06000A97 RID: 2711 RVA: 0x0002D81C File Offset: 0x0002BC1C
	public static string ReadFromBytes(byte[] bytes)
	{
		MemoryStream memoryStream = new MemoryStream(bytes);
		StreamReader streamReader = new StreamReader(memoryStream);
		string result = streamReader.ReadToEnd();
		streamReader.Close();
		memoryStream.Close();
		return result;
	}

	// Token: 0x06000A98 RID: 2712 RVA: 0x0002D84C File Offset: 0x0002BC4C
	public static int[] ReadIntArrayFromString(string str, char split = '/')
	{
		if (str != null)
		{
			string[] array = str.Split(new char[]
			{
				split
			});
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = int.Parse(array[i]);
			}
			return array2;
		}
		return new int[0];
	}

	// Token: 0x06000A99 RID: 2713 RVA: 0x0002D8A0 File Offset: 0x0002BCA0
	public static float[] ReadFloatArrayFromString(string str, char split = '/')
	{
		if (str != null)
		{
			string[] array = str.Split(new char[]
			{
				split
			});
			float[] array2 = new float[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = float.Parse(array[i]);
			}
			return array2;
		}
		return new float[0];
	}

	// Token: 0x06000A9A RID: 2714 RVA: 0x0002D8F4 File Offset: 0x0002BCF4
	public static string GenerateCompleteDescription(string str, params object[] parameter)
	{
		if (str != null)
		{
			int num = parameter.Length;
			for (int i = 0; i < num; i++)
			{
				string text = parameter[i] + string.Empty;
				if (text != "0")
				{
					string oldValue = i + 1 + "%";
					str = str.Replace(oldValue, text);
				}
			}
		}
		return str;
	}
}
