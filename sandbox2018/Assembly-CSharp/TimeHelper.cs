using System;
using UnityEngine;

// Token: 0x0200019C RID: 412
public class TimeHelper
{
	// Token: 0x170000AF RID: 175
	// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x0002E8F0 File Offset: 0x0002CCF0
	public static float deltaTime
	{
		get
		{
			float num = 60f;
			if (AppConfig.USE_FIXED_FRAMERATE)
			{
				return Time.timeScale / num;
			}
			return Time.deltaTime;
		}
	}

	// Token: 0x170000B0 RID: 176
	// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x0002E91C File Offset: 0x0002CD1C
	public static float unscaledDeltaTime
	{
		get
		{
			float num = 60f;
			if (AppConfig.USE_FIXED_FRAMERATE)
			{
				return 1f / num;
			}
			return Time.unscaledDeltaTime;
		}
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x0002E948 File Offset: 0x0002CD48
	public static long GetTimestamp(DateTime cTime)
	{
		return Convert.ToInt64((cTime - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
	}

	// Token: 0x06000AB7 RID: 2743 RVA: 0x0002E97A File Offset: 0x0002CD7A
	public static long GetCurrentRealTimestamp()
	{
		return TimeHelper.GetTimestamp(DateTime.UtcNow);
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x0002E988 File Offset: 0x0002CD88
	public static float GetLeftSecondsToEndTimestamp(long endTime)
	{
		long currentRealTimestamp = TimeHelper.GetCurrentRealTimestamp();
		float b = (float)(endTime - currentRealTimestamp) / 1000f;
		return Mathf.Max(0f, b);
	}

	// Token: 0x06000AB9 RID: 2745 RVA: 0x0002E9B4 File Offset: 0x0002CDB4
	public static bool IsNewDaily(string str)
	{
		TimeHelper.DateDay dateTimeByStr = TimeHelper.GetDateTimeByStr(str);
		TimeHelper.DateDay today = TimeHelper.GetToday();
		return dateTimeByStr.Year == today.Year && dateTimeByStr.Month == today.Month && dateTimeByStr.Day >= today.Day && dateTimeByStr.Day < today.Day + 1;
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x0002EA18 File Offset: 0x0002CE18
	public static bool IsLessThanToday(string str)
	{
		TimeHelper.DateDay today = TimeHelper.GetToday();
		TimeHelper.DateDay dateTimeByStr = TimeHelper.GetDateTimeByStr(str);
		DateTime cTime = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0, 0);
		long timestamp = TimeHelper.GetTimestamp(cTime);
		DateTime cTime2 = new DateTime(dateTimeByStr.Year, dateTimeByStr.Month, dateTimeByStr.Day, 0, 0, 0, 0);
		long timestamp2 = TimeHelper.GetTimestamp(cTime2);
		return timestamp2 < timestamp;
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x0002EA88 File Offset: 0x0002CE88
	public static TimeHelper.DateDay GetDateTimeByStr(string str)
	{
		TimeHelper.DateDay dateDay = new TimeHelper.DateDay();
		string[] array = str.Split(new char[]
		{
			'-'
		});
		dateDay.Year = int.Parse(array[0]);
		dateDay.Month = int.Parse(array[1]);
		dateDay.Day = int.Parse(array[2]);
		return dateDay;
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x0002EAD8 File Offset: 0x0002CED8
	public static string MaxDateDayStr(string str1, string str2)
	{
		TimeHelper.DateDay dateTimeByStr = TimeHelper.GetDateTimeByStr(str1);
		TimeHelper.DateDay dateTimeByStr2 = TimeHelper.GetDateTimeByStr(str2);
		DateTime cTime = new DateTime(dateTimeByStr.Year, dateTimeByStr.Month, dateTimeByStr.Day, 0, 0, 0, 0);
		long timestamp = TimeHelper.GetTimestamp(cTime);
		DateTime cTime2 = new DateTime(dateTimeByStr2.Year, dateTimeByStr2.Month, dateTimeByStr2.Day, 0, 0, 0, 0);
		long timestamp2 = TimeHelper.GetTimestamp(cTime2);
		if (timestamp > timestamp2)
		{
			return str1;
		}
		return str2;
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x0002EB48 File Offset: 0x0002CF48
	public static TimeHelper.DateDay GetToday()
	{
		return new TimeHelper.DateDay(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
	}

	// Token: 0x06000ABE RID: 2750 RVA: 0x0002EB84 File Offset: 0x0002CF84
	public static string GetTodayStr()
	{
		TimeHelper.DateDay today = TimeHelper.GetToday();
		return string.Concat(new object[]
		{
			today.Year,
			"-",
			today.Month,
			"-",
			today.Day
		});
	}

	// Token: 0x06000ABF RID: 2751 RVA: 0x0002EBDC File Offset: 0x0002CFDC
	public static bool IsExpiredDay(string str)
	{
		TimeHelper.DateDay today = TimeHelper.GetToday();
		TimeHelper.DateDay dateTimeByStr = TimeHelper.GetDateTimeByStr(str);
		return today.Year >= dateTimeByStr.Year && today.Month >= dateTimeByStr.Month && today.Day > dateTimeByStr.Day;
	}

	// Token: 0x06000AC0 RID: 2752 RVA: 0x0002EC2C File Offset: 0x0002D02C
	public static void SynchronizeTimestampScaled()
	{
		if (TimeHelper._timestampAtFrameStart == 0L)
		{
			TimeHelper._timestampAtFrameStart = TimeHelper.GetCurrentRealTimestamp();
		}
		else
		{
			TimeHelper._timestampAtFrameStart += (long)(TimeHelper.deltaTime * 1000f);
		}
	}

	// Token: 0x06000AC1 RID: 2753 RVA: 0x0002EC60 File Offset: 0x0002D060
	public static long GetCurrentTimestampScaled()
	{
		Assert.assert(TimeHelper._timestampAtFrameStart > 0L, "unknown");
		return TimeHelper._timestampAtFrameStart;
	}

	// Token: 0x06000AC2 RID: 2754 RVA: 0x0002EC7A File Offset: 0x0002D07A
	public static void SetTimeScale(float scale)
	{
		Assert.assert(scale > 0f, "unknown");
		Time.timeScale = scale;
	}

	// Token: 0x0400063F RID: 1599
	private static long _timestampAtFrameStart;

	// Token: 0x0200019D RID: 413
	public class DateDay
	{
		// Token: 0x06000AC4 RID: 2756 RVA: 0x0002EC96 File Offset: 0x0002D096
		public DateDay()
		{
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0002EC9E File Offset: 0x0002D09E
		public DateDay(int y, int m, int d)
		{
			this.Year = y;
			this.Month = m;
			this.Day = d;
		}

		// Token: 0x04000640 RID: 1600
		public int Year;

		// Token: 0x04000641 RID: 1601
		public int Month;

		// Token: 0x04000642 RID: 1602
		public int Day;
	}
}
