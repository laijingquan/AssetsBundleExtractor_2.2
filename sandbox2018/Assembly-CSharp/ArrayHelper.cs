using System;

// Token: 0x02000188 RID: 392
public class ArrayHelper
{
	// Token: 0x06000A4A RID: 2634 RVA: 0x0002C920 File Offset: 0x0002AD20
	public static T[] Fill<T>(T[] source, T value, int count)
	{
		T[] array = new T[source.Length + count];
		ArrayHelper.Fill<T>(source, ref array, 0, source.Length);
		for (int i = 0; i < count; i++)
		{
			array[source.Length + i] = value;
		}
		return array;
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x0002C964 File Offset: 0x0002AD64
	public static void Fill<T>(T[] source, ref T[] destination, int at, int n)
	{
		for (int i = 0; i < n; i++)
		{
			destination[i + at] = source[i];
		}
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x0002C994 File Offset: 0x0002AD94
	public static T[] Clone<T>(T[] array) where T : ICloneable
	{
		Assert.assert(array.Length > 0, "ArrayHelper Clone error");
		T[] array2 = new T[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = (T)((object)array[i].Clone());
		}
		return array2;
	}

	// Token: 0x06000A4D RID: 2637 RVA: 0x0002C9F0 File Offset: 0x0002ADF0
	public static T[][] Clone<T>(T[][] array) where T : ICloneable
	{
		Assert.assert(array.Length > 0, "ArrayHelper Clone error");
		int num = array.Length;
		T[][] array2 = new T[num][];
		for (int i = 0; i < num; i++)
		{
			int num2 = array[i].Length;
			array2[i] = new T[num2];
			for (int j = 0; j < num2; j++)
			{
				array2[i][j] = (T)((object)array[i][j].Clone());
			}
		}
		return array2;
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x0002CA78 File Offset: 0x0002AE78
	public static T[] Concat<T>(T[] a, T[] b)
	{
		Assert.assert(a.Length > 0 && b.Length > 0, "ArrayHelper Concat error");
		int num = a.Length;
		int num2 = b.Length;
		T[] array = new T[num + num2];
		a.CopyTo(array, 0);
		b.CopyTo(array, num);
		return array;
	}
}
