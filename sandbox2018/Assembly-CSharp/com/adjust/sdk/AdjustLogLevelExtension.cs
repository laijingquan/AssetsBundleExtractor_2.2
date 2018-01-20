using System;

namespace com.adjust.sdk
{
	// Token: 0x0200001B RID: 27
	public static class AdjustLogLevelExtension
	{
		// Token: 0x0600010C RID: 268 RVA: 0x00006408 File Offset: 0x00004808
		public static string lowercaseToString(this AdjustLogLevel AdjustLogLevel)
		{
			switch (AdjustLogLevel)
			{
			case AdjustLogLevel.Verbose:
				return "verbose";
			case AdjustLogLevel.Debug:
				return "debug";
			case AdjustLogLevel.Info:
				return "info";
			case AdjustLogLevel.Warn:
				return "warn";
			case AdjustLogLevel.Error:
				return "error";
			case AdjustLogLevel.Assert:
				return "assert";
			case AdjustLogLevel.Suppress:
				return "suppress";
			default:
				return "unknown";
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00006470 File Offset: 0x00004870
		public static string uppercaseToString(this AdjustLogLevel AdjustLogLevel)
		{
			switch (AdjustLogLevel)
			{
			case AdjustLogLevel.Verbose:
				return "VERBOSE";
			case AdjustLogLevel.Debug:
				return "DEBUG";
			case AdjustLogLevel.Info:
				return "INFO";
			case AdjustLogLevel.Warn:
				return "WARN";
			case AdjustLogLevel.Error:
				return "ERROR";
			case AdjustLogLevel.Assert:
				return "ASSERT";
			case AdjustLogLevel.Suppress:
				return "SUPPRESS";
			default:
				return "unknown";
			}
		}
	}
}
