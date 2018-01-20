using System;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000108 RID: 264
	public class Reward : EventArgs
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x0001D153 File Offset: 0x0001B553
		// (set) Token: 0x0600063C RID: 1596 RVA: 0x0001D15B File Offset: 0x0001B55B
		public string Type { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x0001D164 File Offset: 0x0001B564
		// (set) Token: 0x0600063E RID: 1598 RVA: 0x0001D16C File Offset: 0x0001B56C
		public double Amount { get; set; }
	}
}
