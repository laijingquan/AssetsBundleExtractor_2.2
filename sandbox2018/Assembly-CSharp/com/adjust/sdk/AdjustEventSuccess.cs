using System;
using System.Collections.Generic;

namespace com.adjust.sdk
{
	// Token: 0x02000019 RID: 25
	public class AdjustEventSuccess
	{
		// Token: 0x060000FE RID: 254 RVA: 0x000062AA File Offset: 0x000046AA
		public AdjustEventSuccess()
		{
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000062B4 File Offset: 0x000046B4
		public AdjustEventSuccess(string jsonString)
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

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00006366 File Offset: 0x00004766
		// (set) Token: 0x06000101 RID: 257 RVA: 0x0000636E File Offset: 0x0000476E
		public string Adid { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00006377 File Offset: 0x00004777
		// (set) Token: 0x06000103 RID: 259 RVA: 0x0000637F File Offset: 0x0000477F
		public string Message { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00006388 File Offset: 0x00004788
		// (set) Token: 0x06000105 RID: 261 RVA: 0x00006390 File Offset: 0x00004790
		public string Timestamp { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00006399 File Offset: 0x00004799
		// (set) Token: 0x06000107 RID: 263 RVA: 0x000063A1 File Offset: 0x000047A1
		public string EventToken { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000108 RID: 264 RVA: 0x000063AA File Offset: 0x000047AA
		// (set) Token: 0x06000109 RID: 265 RVA: 0x000063B2 File Offset: 0x000047B2
		public Dictionary<string, object> JsonResponse { get; set; }

		// Token: 0x0600010A RID: 266 RVA: 0x000063BC File Offset: 0x000047BC
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

		// Token: 0x0600010B RID: 267 RVA: 0x000063F9 File Offset: 0x000047F9
		public string GetJsonResponse()
		{
			return AdjustUtils.GetJsonResponseCompact(this.JsonResponse);
		}
	}
}
