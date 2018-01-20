using System;
using UnityEngine;

// Token: 0x0200019E RID: 414
public class Trace
{
	// Token: 0x06000AC7 RID: 2759 RVA: 0x0002ECC4 File Offset: 0x0002D0C4
	public static void trace(object msg, Trace.CHANNEL channel = Trace.CHANNEL.NORMAL)
	{
		bool flag = false;
		for (int i = 0; i < Trace.ACTIVE_CHANNEL.Length; i++)
		{
			if (Trace.ACTIVE_CHANNEL[i] == channel)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Debug.Log(string.Concat(new object[]
			{
				"[",
				channel,
				"]\t",
				msg
			}));
		}
	}

	// Token: 0x04000643 RID: 1603
	private static Trace.CHANNEL[] ACTIVE_CHANNEL = new Trace.CHANNEL[]
	{
		Trace.CHANNEL.NORMAL,
		Trace.CHANNEL.FIGHTING,
		Trace.CHANNEL.HTTP,
		Trace.CHANNEL.UI,
		Trace.CHANNEL.IO,
		Trace.CHANNEL.INTEGRATION,
		Trace.CHANNEL.DYNAMIC_DATACONFIG
	};

	// Token: 0x0200019F RID: 415
	public enum CHANNEL
	{
		// Token: 0x04000645 RID: 1605
		NORMAL,
		// Token: 0x04000646 RID: 1606
		FIGHTING,
		// Token: 0x04000647 RID: 1607
		HTTP,
		// Token: 0x04000648 RID: 1608
		UI,
		// Token: 0x04000649 RID: 1609
		IO,
		// Token: 0x0400064A RID: 1610
		INTEGRATION,
		// Token: 0x0400064B RID: 1611
		DYNAMIC_DATACONFIG
	}
}
