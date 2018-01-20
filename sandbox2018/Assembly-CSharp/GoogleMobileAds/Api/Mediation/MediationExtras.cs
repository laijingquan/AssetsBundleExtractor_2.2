using System;
using System.Collections.Generic;

namespace GoogleMobileAds.Api.Mediation
{
	// Token: 0x02000105 RID: 261
	public abstract class MediationExtras
	{
		// Token: 0x06000618 RID: 1560 RVA: 0x0001CC96 File Offset: 0x0001B096
		public MediationExtras()
		{
			this.Extras = new Dictionary<string, string>();
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x0001CCA9 File Offset: 0x0001B0A9
		// (set) Token: 0x0600061A RID: 1562 RVA: 0x0001CCB1 File Offset: 0x0001B0B1
		public Dictionary<string, string> Extras { get; protected set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600061B RID: 1563
		public abstract string AndroidMediationExtraBuilderClassName { get; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600061C RID: 1564
		public abstract string IOSMediationExtraBuilderClassName { get; }
	}
}
