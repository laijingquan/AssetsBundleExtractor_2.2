using System;
using System.Collections;
using System.Collections.Generic;

namespace com.adjust.sdk
{
	// Token: 0x0200001E RID: 30
	public class AdjustUtils
	{
		// Token: 0x06000129 RID: 297 RVA: 0x0000677A File Offset: 0x00004B7A
		public static int ConvertLogLevel(AdjustLogLevel? logLevel)
		{
			if (logLevel == null)
			{
				return -1;
			}
			return (int)logLevel.Value;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00006794 File Offset: 0x00004B94
		public static int ConvertBool(bool? value)
		{
			if (value == null)
			{
				return -1;
			}
			if (value.Value)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000067B6 File Offset: 0x00004BB6
		public static double ConvertDouble(double? value)
		{
			if (value == null)
			{
				return -1.0;
			}
			return value.Value;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000067D8 File Offset: 0x00004BD8
		public static string ConvertListToJson(List<string> list)
		{
			if (list == null)
			{
				return null;
			}
			JSONArray jsonarray = new JSONArray();
			foreach (string aData in list)
			{
				jsonarray.Add(new JSONData(aData));
			}
			return jsonarray.ToString();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00006848 File Offset: 0x00004C48
		public static string GetJsonResponseCompact(Dictionary<string, object> dictionary)
		{
			string text = string.Empty;
			if (dictionary == null)
			{
				return text;
			}
			int num = 0;
			text += "{";
			foreach (KeyValuePair<string, object> keyValuePair in dictionary)
			{
				string text2 = keyValuePair.Value as string;
				if (text2 != null)
				{
					if (++num > 1)
					{
						text += ",";
					}
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						"\"",
						keyValuePair.Key,
						"\":\"",
						text2,
						"\""
					});
				}
				else
				{
					Dictionary<string, object> dictionary2 = keyValuePair.Value as Dictionary<string, object>;
					if (++num > 1)
					{
						text += ",";
					}
					text = text + "\"" + keyValuePair.Key + "\":";
					text += AdjustUtils.GetJsonResponseCompact(dictionary2);
				}
			}
			text += "}";
			return text;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00006978 File Offset: 0x00004D78
		public static string GetJsonString(JSONNode node, string key)
		{
			if (node == null)
			{
				return null;
			}
			JSONData jsondata = node[key] as JSONData;
			if (jsondata == null)
			{
				return null;
			}
			return jsondata.Value;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000069B4 File Offset: 0x00004DB4
		public static void WriteJsonResponseDictionary(JSONClass jsonObject, Dictionary<string, object> output)
		{
			IEnumerator enumerator = jsonObject.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					KeyValuePair<string, JSONNode> keyValuePair = (KeyValuePair<string, JSONNode>)obj;
					JSONClass asObject = keyValuePair.Value.AsObject;
					string key = keyValuePair.Key;
					if (asObject == null)
					{
						string value = keyValuePair.Value.Value;
						output.Add(key, value);
					}
					else
					{
						Dictionary<string, object> dictionary = new Dictionary<string, object>();
						output.Add(key, dictionary);
						AdjustUtils.WriteJsonResponseDictionary(asObject, dictionary);
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}

		// Token: 0x04000077 RID: 119
		public static string KeyAdid = "adid";

		// Token: 0x04000078 RID: 120
		public static string KeyMessage = "message";

		// Token: 0x04000079 RID: 121
		public static string KeyNetwork = "network";

		// Token: 0x0400007A RID: 122
		public static string KeyAdgroup = "adgroup";

		// Token: 0x0400007B RID: 123
		public static string KeyCampaign = "campaign";

		// Token: 0x0400007C RID: 124
		public static string KeyCreative = "creative";

		// Token: 0x0400007D RID: 125
		public static string KeyWillRetry = "willRetry";

		// Token: 0x0400007E RID: 126
		public static string KeyTimestamp = "timestamp";

		// Token: 0x0400007F RID: 127
		public static string KeyEventToken = "eventToken";

		// Token: 0x04000080 RID: 128
		public static string KeyClickLabel = "clickLabel";

		// Token: 0x04000081 RID: 129
		public static string KeyTrackerName = "trackerName";

		// Token: 0x04000082 RID: 130
		public static string KeyTrackerToken = "trackerToken";

		// Token: 0x04000083 RID: 131
		public static string KeyJsonResponse = "jsonResponse";
	}
}
