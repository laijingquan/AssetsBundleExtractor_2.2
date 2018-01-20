using System;
using System.Collections.Generic;

namespace com.adjust.sdk
{
	// Token: 0x0200001D RID: 29
	public class AdjustSessionSuccess
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00006636 File Offset: 0x00004A36
		public AdjustSessionSuccess()
		{
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00006640 File Offset: 0x00004A40
		public AdjustSessionSuccess(string jsonString)
		{
			JSONNode jsonnode = JSON.Parse(jsonString);
			if (jsonnode == null)
			{
				return;
			}
			this.Adid = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyAdid);
			this.Message = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyMessage);
			this.Timestamp = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyTimestamp);
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

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600011E RID: 286 RVA: 0x000066E1 File Offset: 0x00004AE1
		// (set) Token: 0x0600011F RID: 287 RVA: 0x000066E9 File Offset: 0x00004AE9
		public string Adid { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000120 RID: 288 RVA: 0x000066F2 File Offset: 0x00004AF2
		// (set) Token: 0x06000121 RID: 289 RVA: 0x000066FA File Offset: 0x00004AFA
		public string Message { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00006703 File Offset: 0x00004B03
		// (set) Token: 0x06000123 RID: 291 RVA: 0x0000670B File Offset: 0x00004B0B
		public string Timestamp { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00006714 File Offset: 0x00004B14
		// (set) Token: 0x06000125 RID: 293 RVA: 0x0000671C File Offset: 0x00004B1C
		public Dictionary<string, object> JsonResponse { get; set; }

		// Token: 0x06000126 RID: 294 RVA: 0x00006728 File Offset: 0x00004B28
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

		// Token: 0x06000127 RID: 295 RVA: 0x00006765 File Offset: 0x00004B65
		public string GetJsonResponse()
		{
			return AdjustUtils.GetJsonResponseCompact(this.JsonResponse);
		}
	}
}
