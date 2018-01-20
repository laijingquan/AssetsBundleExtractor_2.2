using System;
using System.Collections.Generic;
using GoogleMobileAds.Api.Mediation;

namespace GoogleMobileAds.Api
{
	// Token: 0x020000FD RID: 253
	public class AdRequest
	{
		// Token: 0x060005B2 RID: 1458 RVA: 0x0001C100 File Offset: 0x0001A500
		private AdRequest(AdRequest.Builder builder)
		{
			this.TestDevices = new List<string>(builder.TestDevices);
			this.Keywords = new HashSet<string>(builder.Keywords);
			this.Birthday = builder.Birthday;
			this.Gender = builder.Gender;
			this.TagForChildDirectedTreatment = builder.ChildDirectedTreatmentTag;
			this.Extras = new Dictionary<string, string>(builder.Extras);
			this.MediationExtras = builder.MediationExtras;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x0001C176 File Offset: 0x0001A576
		// (set) Token: 0x060005B4 RID: 1460 RVA: 0x0001C17E File Offset: 0x0001A57E
		public List<string> TestDevices { get; private set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0001C187 File Offset: 0x0001A587
		// (set) Token: 0x060005B6 RID: 1462 RVA: 0x0001C18F File Offset: 0x0001A58F
		public HashSet<string> Keywords { get; private set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x0001C198 File Offset: 0x0001A598
		// (set) Token: 0x060005B8 RID: 1464 RVA: 0x0001C1A0 File Offset: 0x0001A5A0
		public DateTime? Birthday { get; private set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0001C1A9 File Offset: 0x0001A5A9
		// (set) Token: 0x060005BA RID: 1466 RVA: 0x0001C1B1 File Offset: 0x0001A5B1
		public Gender? Gender { get; private set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0001C1BA File Offset: 0x0001A5BA
		// (set) Token: 0x060005BC RID: 1468 RVA: 0x0001C1C2 File Offset: 0x0001A5C2
		public bool? TagForChildDirectedTreatment { get; private set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060005BD RID: 1469 RVA: 0x0001C1CB File Offset: 0x0001A5CB
		// (set) Token: 0x060005BE RID: 1470 RVA: 0x0001C1D3 File Offset: 0x0001A5D3
		public Dictionary<string, string> Extras { get; private set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x0001C1DC File Offset: 0x0001A5DC
		// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0001C1E4 File Offset: 0x0001A5E4
		public List<MediationExtras> MediationExtras { get; private set; }

		// Token: 0x040003D6 RID: 982
		public const string Version = "3.10.0";

		// Token: 0x040003D7 RID: 983
		public const string TestDeviceSimulator = "SIMULATOR";

		// Token: 0x020000FE RID: 254
		public class Builder
		{
			// Token: 0x060005C1 RID: 1473 RVA: 0x0001C1F0 File Offset: 0x0001A5F0
			public Builder()
			{
				this.TestDevices = new List<string>();
				this.Keywords = new HashSet<string>();
				this.Birthday = null;
				this.Gender = null;
				this.ChildDirectedTreatmentTag = null;
				this.Extras = new Dictionary<string, string>();
				this.MediationExtras = new List<MediationExtras>();
			}

			// Token: 0x17000053 RID: 83
			// (get) Token: 0x060005C2 RID: 1474 RVA: 0x0001C25C File Offset: 0x0001A65C
			// (set) Token: 0x060005C3 RID: 1475 RVA: 0x0001C264 File Offset: 0x0001A664
			internal List<string> TestDevices { get; private set; }

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x060005C4 RID: 1476 RVA: 0x0001C26D File Offset: 0x0001A66D
			// (set) Token: 0x060005C5 RID: 1477 RVA: 0x0001C275 File Offset: 0x0001A675
			internal HashSet<string> Keywords { get; private set; }

			// Token: 0x17000055 RID: 85
			// (get) Token: 0x060005C6 RID: 1478 RVA: 0x0001C27E File Offset: 0x0001A67E
			// (set) Token: 0x060005C7 RID: 1479 RVA: 0x0001C286 File Offset: 0x0001A686
			internal DateTime? Birthday { get; private set; }

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0001C28F File Offset: 0x0001A68F
			// (set) Token: 0x060005C9 RID: 1481 RVA: 0x0001C297 File Offset: 0x0001A697
			internal Gender? Gender { get; private set; }

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x060005CA RID: 1482 RVA: 0x0001C2A0 File Offset: 0x0001A6A0
			// (set) Token: 0x060005CB RID: 1483 RVA: 0x0001C2A8 File Offset: 0x0001A6A8
			internal bool? ChildDirectedTreatmentTag { get; private set; }

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x060005CC RID: 1484 RVA: 0x0001C2B1 File Offset: 0x0001A6B1
			// (set) Token: 0x060005CD RID: 1485 RVA: 0x0001C2B9 File Offset: 0x0001A6B9
			internal Dictionary<string, string> Extras { get; private set; }

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x060005CE RID: 1486 RVA: 0x0001C2C2 File Offset: 0x0001A6C2
			// (set) Token: 0x060005CF RID: 1487 RVA: 0x0001C2CA File Offset: 0x0001A6CA
			internal List<MediationExtras> MediationExtras { get; private set; }

			// Token: 0x060005D0 RID: 1488 RVA: 0x0001C2D3 File Offset: 0x0001A6D3
			public AdRequest.Builder AddKeyword(string keyword)
			{
				this.Keywords.Add(keyword);
				return this;
			}

			// Token: 0x060005D1 RID: 1489 RVA: 0x0001C2E3 File Offset: 0x0001A6E3
			public AdRequest.Builder AddTestDevice(string deviceId)
			{
				this.TestDevices.Add(deviceId);
				return this;
			}

			// Token: 0x060005D2 RID: 1490 RVA: 0x0001C2F2 File Offset: 0x0001A6F2
			public AdRequest Build()
			{
				return new AdRequest(this);
			}

			// Token: 0x060005D3 RID: 1491 RVA: 0x0001C2FA File Offset: 0x0001A6FA
			public AdRequest.Builder SetBirthday(DateTime birthday)
			{
				this.Birthday = new DateTime?(birthday);
				return this;
			}

			// Token: 0x060005D4 RID: 1492 RVA: 0x0001C309 File Offset: 0x0001A709
			public AdRequest.Builder SetGender(Gender gender)
			{
				this.Gender = new Gender?(gender);
				return this;
			}

			// Token: 0x060005D5 RID: 1493 RVA: 0x0001C318 File Offset: 0x0001A718
			public AdRequest.Builder AddMediationExtras(MediationExtras extras)
			{
				this.MediationExtras.Add(extras);
				return this;
			}

			// Token: 0x060005D6 RID: 1494 RVA: 0x0001C327 File Offset: 0x0001A727
			public AdRequest.Builder TagForChildDirectedTreatment(bool tagForChildDirectedTreatment)
			{
				this.ChildDirectedTreatmentTag = new bool?(tagForChildDirectedTreatment);
				return this;
			}

			// Token: 0x060005D7 RID: 1495 RVA: 0x0001C336 File Offset: 0x0001A736
			public AdRequest.Builder AddExtra(string key, string value)
			{
				this.Extras.Add(key, value);
				return this;
			}
		}
	}
}
