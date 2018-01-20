using System;

namespace com.adjust.sdk
{
	// Token: 0x02000016 RID: 22
	public static class AdjustEnvironmentExtension
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x00006057 File Offset: 0x00004457
		public static string lowercaseToString(this AdjustEnvironment adjustEnvironment)
		{
			if (adjustEnvironment == AdjustEnvironment.Sandbox)
			{
				return "sandbox";
			}
			if (adjustEnvironment != AdjustEnvironment.Production)
			{
				return "unknown";
			}
			return "production";
		}
	}
}
