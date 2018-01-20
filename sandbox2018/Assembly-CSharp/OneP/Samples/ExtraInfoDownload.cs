using System;
using UnityEngine;

namespace OneP.Samples
{
	// Token: 0x0200012C RID: 300
	public class ExtraInfoDownload
	{
		// Token: 0x060007BE RID: 1982 RVA: 0x000209C5 File Offset: 0x0001EDC5
		public ExtraInfoDownload(WWW _www, float _timeDownload, int _retryTime)
		{
			this.www = _www;
			this.timeDownload = _timeDownload;
			this.retryTime = _retryTime;
		}

		// Token: 0x0400048C RID: 1164
		public WWW www;

		// Token: 0x0400048D RID: 1165
		public float timeDownload;

		// Token: 0x0400048E RID: 1166
		public int retryTime;
	}
}
