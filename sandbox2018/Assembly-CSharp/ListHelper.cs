using System;
using System.Collections.Generic;

// Token: 0x02000191 RID: 401
public class ListHelper
{
	// Token: 0x06000A6A RID: 2666 RVA: 0x0002CFB0 File Offset: 0x0002B3B0
	public static List<T> Clone<T>(List<T> list) where T : ICloneable
	{
		Assert.assert(list.Count > 0, "ListHelper Clone error");
		List<T> list2 = new List<T>();
		foreach (T t in list)
		{
			list2.Add((T)((object)t.Clone()));
		}
		return list2;
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x0002D034 File Offset: 0x0002B434
	public static List<T> Concat<T>(List<T> a, List<T> b)
	{
		Assert.assert(a.Count > 0 && b.Count > 0, "ListHelper Concat error");
		List<T> list = new List<T>();
		foreach (T item in a)
		{
			list.Add(item);
		}
		foreach (T item2 in b)
		{
			list.Add(item2);
		}
		return list;
	}

	// Token: 0x06000A6C RID: 2668 RVA: 0x0002D0FC File Offset: 0x0002B4FC
	public static void Push<T>(List<T> destination, List<T> source)
	{
		foreach (T item in source)
		{
			destination.Add(item);
		}
	}

	// Token: 0x06000A6D RID: 2669 RVA: 0x0002D154 File Offset: 0x0002B554
	public static void Push<T>(List<T> destination, T[] source)
	{
		foreach (T item in source)
		{
			destination.Add(item);
		}
	}

	// Token: 0x06000A6E RID: 2670 RVA: 0x0002D188 File Offset: 0x0002B588
	public static void Push<T>(List<T> destination, List<T> source, int pos, int n)
	{
		for (int i = 0; i < n; i++)
		{
			destination.Add(source[pos++]);
		}
	}
}
