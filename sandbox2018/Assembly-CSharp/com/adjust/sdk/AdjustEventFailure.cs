using System;
using System.Collections.Generic;

namespace com.adjust.sdk
{
	// Token: 0x02000018 RID: 24
	public class AdjustEventFailure
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00006127 File Offset: 0x00004527
		public AdjustEventFailure()
		{
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006130 File Offset: 0x00004530
		public AdjustEventFailure(string jsonString)
		{
			JSONNode jsonnode = JSON.Parse(jsonString);
			if (jsonnode == null)
			{
				return;
			}
			this.Adid = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyAdid);
			this.Message = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyMessage);
			this.Timestamp = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyTimestamp);
			this.EventToken = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyEventToken);
			this.WillRetry = Convert.ToBoolean(AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyWillRetry));
			JSONNode jsonnode2 = jsonnode[AdjustUtils.KeyJsonResponse];
			if (jsonnode2 == null)
			{
				return;
			}
			if (jsonnode2.AsObject == null)
			{
				return;
			}
			this.JsonResponse = new Dictionary<string, object>();
			AdjustUtils.WriteJsonResponseDictionary(jsonnode2.AsObject, this.JsonResponse);
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x000061F8 File Offset: 0x000045F8
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00006200 File Offset: 0x00004600
		public string Adid { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00006209 File Offset: 0x00004609
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00006211 File Offset: 0x00004611
		public string Message { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000621A File Offset: 0x0000461A
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00006222 File Offset: 0x00004622
		public string Timestamp { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000622B File Offset: 0x0000462B
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00006233 File Offset: 0x00004633
		public string EventToken { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000623C File Offset: 0x0000463C
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00006244 File Offset: 0x00004644
		public bool WillRetry { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000FA RID: 250 RVA: 0x0000624D File Offset: 0x0000464D
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00006255 File Offset: 0x00004655
		public Dictionary<string, object> JsonResponse { get; set; }

		// Token: 0x060000FC RID: 252 RVA: 0x00006260 File Offset: 0x00004660
		public void BuildJsonResponseFromString(string jsonResponseString)
		{
			JSONNode jsonnode = JSON.Parse(jsonResponseString);
			if (jsonnode == null)
			{
				return;
			}
			this.JsonResponse = new Dictionary<string, object>();
			AdjustUtils.WriteJsonResponseDictionary(jsonnode.AsObject, this.JsonResponse);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000629D File Offset: 0x0000469D
		public string GetJsonResponse()
		{
			return AdjustUtils.GetJsonResponseCompact(this.JsonResponse);
		}
	}
}
