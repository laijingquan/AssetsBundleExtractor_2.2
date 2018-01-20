using System;

namespace GoogleMobileAds.Api
{
	// Token: 0x020000FF RID: 255
	public class AdSize
	{
		// Token: 0x060005D8 RID: 1496 RVA: 0x0001C346 File Offset: 0x0001A746
		public AdSize(int width, int height)
		{
			this.isSmartBanner = false;
			this.width = width;
			this.height = height;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001C363 File Offset: 0x0001A763
		private AdSize(bool isSmartBanner) : this(0, 0)
		{
			this.isSmartBanner = isSmartBanner;
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x0001C374 File Offset: 0x0001A774
		public int Width
		{
			get
			{
				return this.width;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x0001C37C File Offset: 0x0001A77C
		public int Height
		{
			get
			{
				return this.height;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x0001C384 File Offset: 0x0001A784
		public bool IsSmartBanner
		{
			get
			{
				return this.isSmartBanner;
			}
		}

		// Token: 0x040003E6 RID: 998
		private bool isSmartBanner;

		// Token: 0x040003E7 RID: 999
		private int width;

		// Token: 0x040003E8 RID: 1000
		private int height;

		// Token: 0x040003E9 RID: 1001
		public static readonly AdSize Banner = new AdSize(320, 50);

		// Token: 0x040003EA RID: 1002
		public static readonly AdSize MediumRectangle = new AdSize(300, 250);

		// Token: 0x040003EB RID: 1003
		public static readonly AdSize IABBanner = new AdSize(468, 60);

		// Token: 0x040003EC RID: 1004
		public static readonly AdSize Leaderboard = new AdSize(728, 90);

		// Token: 0x040003ED RID: 1005
		public static readonly AdSize SmartBanner = new AdSize(true);

		// Token: 0x040003EE RID: 1006
		public static readonly int FullWidth = -1;
	}
}
