using System;
using System.Collections.Generic;

namespace com.adjust.sdk
{
	// Token: 0x02000013 RID: 19
	public class AdjustAttribution
	{
		// Token: 0x060000BE RID: 190 RVA: 0x00005D2F File Offset: 0x0000412F
		public AdjustAttribution()
		{
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00005D38 File Offset: 0x00004138
		public AdjustAttribution(string jsonString)
		{
			JSONNode jsonnode = JSON.Parse(jsonString);
			if (jsonnode == null)
			{
				return;
			}
			this.trackerName = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyTrackerName);
			this.trackerToken = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyTrackerToken);
			this.network = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyNetwork);
			this.campaign = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyCampaign);
			this.adgroup = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyAdgroup);
			this.creative = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyCreative);
			this.clickLabel = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyClickLabel);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00005DD8 File Offset: 0x000041D8
		public AdjustAttribution(Dictionary<string, string> dicAttributionData)
		{
			if (dicAttributionData == null)
			{
				return;
			}
			this.trackerName = AdjustAttribution.TryGetValue(dicAttributionData, AdjustUtils.KeyTrackerName);
			this.trackerToken = AdjustAttribution.TryGetValue(dicAttributionData, AdjustUtils.KeyTrackerToken);
			this.network = AdjustAttribution.TryGetValue(dicAttributionData, AdjustUtils.KeyNetwork);
			this.campaign = AdjustAttribution.TryGetValue(dicAttributionData, AdjustUtils.KeyCampaign);
			this.adgroup = AdjustAttribution.TryGetValue(dicAttributionData, AdjustUtils.KeyAdgroup);
			this.creative = AdjustAttribution.TryGetValue(dicAttributionData, AdjustUtils.KeyCreative);
			this.clickLabel = AdjustAttribution.TryGetValue(dicAttributionData, AdjustUtils.KeyClickLabel);
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00005E69 File Offset: 0x00004269
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00005E71 File Offset: 0x00004271
		public string network { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00005E7A File Offset: 0x0000427A
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00005E82 File Offset: 0x00004282
		public string adgroup { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00005E8B File Offset: 0x0000428B
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00005E93 File Offset: 0x00004293
		public string campaign { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00005E9C File Offset: 0x0000429C
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00005EA4 File Offset: 0x000042A4
		public string creative { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00005EAD File Offset: 0x000042AD
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00005EB5 File Offset: 0x000042B5
		public string clickLabel { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00005EBE File Offset: 0x000042BE
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00005EC6 File Offset: 0x000042C6
		public string trackerName { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00005ECF File Offset: 0x000042CF
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00005ED7 File Offset: 0x000042D7
		public string trackerToken { get; set; }

		// Token: 0x060000CF RID: 207 RVA: 0x00005EE0 File Offset: 0x000042E0
		private static string TryGetValue(Dictionary<string, string> dic, string key)
		{
			string result;
			if (dic.TryGetValue(key, out result))
			{
				return result;
			}
			return null;
		}
	}
}
