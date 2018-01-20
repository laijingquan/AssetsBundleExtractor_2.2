using System;
using System.Collections.Generic;

namespace com.adjust.sdk
{
	// Token: 0x0200001C RID: 28
	public class AdjustSessionFailure
	{
		// Token: 0x0600010E RID: 270 RVA: 0x000064D5 File Offset: 0x000048D5
		public AdjustSessionFailure()
		{
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000064E0 File Offset: 0x000048E0
		public AdjustSessionFailure(string jsonString)
		{
			JSONNode jsonnode = JSON.Parse(jsonString);
			if (jsonnode == null)
			{
				return;
			}
			this.Adid = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyAdid);
			this.Message = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyMessage);
			this.Timestamp = AdjustUtils.GetJsonString(jsonnode, AdjustUtils.KeyTimestamp);
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

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00006597 File Offset: 0x00004997
		// (set) Token: 0x06000111 RID: 273 RVA: 0x0000659F File Offset: 0x0000499F
		public string Adid { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000112 RID: 274 RVA: 0x000065A8 File Offset: 0x000049A8
		// (set) Token: 0x06000113 RID: 275 RVA: 0x000065B0 File Offset: 0x000049B0
		public string Message { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000114 RID: 276 RVA: 0x000065B9 File Offset: 0x000049B9
		// (set) Token: 0x06000115 RID: 277 RVA: 0x000065C1 File Offset: 0x000049C1
		public string Timestamp { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000116 RID: 278 RVA: 0x000065CA File Offset: 0x000049CA
		// (set) Token: 0x06000117 RID: 279 RVA: 0x000065D2 File Offset: 0x000049D2
		public bool WillRetry { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000065DB File Offset: 0x000049DB
		// (set) Token: 0x06000119 RID: 281 RVA: 0x000065E3 File Offset: 0x000049E3
		public Dictionary<string, object> JsonResponse { get; set; }

		// Token: 0x0600011A RID: 282 RVA: 0x000065EC File Offset: 0x000049EC
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

		// Token: 0x0600011B RID: 283 RVA: 0x00006629 File Offset: 0x00004A29
		public string GetJsonResponse()
		{
			return AdjustUtils.GetJsonResponseCompact(this.JsonResponse);
		}
	}
}
