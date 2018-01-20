using System;
using System.Collections.Generic;

// Token: 0x02000194 RID: 404
public class RandomHelper
{
	// Token: 0x06000A84 RID: 2692 RVA: 0x0002D4A8 File Offset: 0x0002B8A8
	public static void SetSeed(int seed)
	{
		RandomHelper.random = new Random(seed);
	}

	// Token: 0x06000A85 RID: 2693 RVA: 0x0002D4B8 File Offset: 0x0002B8B8
	public static float Range01()
	{
		return (float)RandomHelper.random.NextDouble();
	}

	// Token: 0x06000A86 RID: 2694 RVA: 0x0002D4D4 File Offset: 0x0002B8D4
	public static float Range(float minInclude, float maxExclude)
	{
		float num = (float)RandomHelper.random.NextDouble();
		float num2 = maxExclude - minInclude;
		return minInclude + num * num2;
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x0002D4F8 File Offset: 0x0002B8F8
	public static void Shuffle(ref int[] numbers)
	{
		int num = numbers.Length;
		for (int i = 0; i < num; i++)
		{
			int num2 = RandomHelper.random.Next(num);
			int num3 = numbers[i];
			numbers[i] = numbers[num2];
			numbers[num2] = num3;
		}
	}

	// Token: 0x06000A88 RID: 2696 RVA: 0x0002D53C File Offset: 0x0002B93C
	public static void Shuffle(ref List<int> numbers)
	{
		int count = numbers.Count;
		for (int i = 0; i < count; i++)
		{
			int index = RandomHelper.random.Next(count);
			int value = numbers[i];
			numbers[i] = numbers[index];
			numbers[index] = value;
		}
	}

	// Token: 0x04000634 RID: 1588
	private static Random random = new Random(DateTime.Now.Millisecond);
}
