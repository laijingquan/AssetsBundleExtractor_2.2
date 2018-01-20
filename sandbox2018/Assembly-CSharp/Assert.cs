using System;

// Token: 0x02000189 RID: 393
public class Assert
{
	// Token: 0x06000A50 RID: 2640 RVA: 0x0002CACB File Offset: 0x0002AECB
	public static void assert(bool condition, string msg = "unknown")
	{
		if (AppConfig.DEBUGGING && !condition)
		{
			throw new Exception(msg);
		}
	}
}
