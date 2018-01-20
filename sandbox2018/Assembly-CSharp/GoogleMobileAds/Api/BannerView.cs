using System;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000100 RID: 256
	public class BannerView
	{
		// Token: 0x060005DE RID: 1502 RVA: 0x0001C3F4 File Offset: 0x0001A7F4
		public BannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildBannerClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (IBannerClient)method.Invoke(null, null);
			this.client.CreateBannerView(adUnitId, adSize, position);
			this.ConfigureBannerEvents();
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0001C448 File Offset: 0x0001A848
		public BannerView(string adUnitId, AdSize adSize, int x, int y)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildBannerClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (IBannerClient)method.Invoke(null, null);
			this.client.CreateBannerView(adUnitId, adSize, x, y);
			this.ConfigureBannerEvents();
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060005E0 RID: 1504 RVA: 0x0001C4A0 File Offset: 0x0001A8A0
		// (remove) Token: 0x060005E1 RID: 1505 RVA: 0x0001C4D8 File Offset: 0x0001A8D8
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060005E2 RID: 1506 RVA: 0x0001C510 File Offset: 0x0001A910
		// (remove) Token: 0x060005E3 RID: 1507 RVA: 0x0001C548 File Offset: 0x0001A948
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x060005E4 RID: 1508 RVA: 0x0001C580 File Offset: 0x0001A980
		// (remove) Token: 0x060005E5 RID: 1509 RVA: 0x0001C5B8 File Offset: 0x0001A9B8
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x060005E6 RID: 1510 RVA: 0x0001C5F0 File Offset: 0x0001A9F0
		// (remove) Token: 0x060005E7 RID: 1511 RVA: 0x0001C628 File Offset: 0x0001AA28
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x060005E8 RID: 1512 RVA: 0x0001C660 File Offset: 0x0001AA60
		// (remove) Token: 0x060005E9 RID: 1513 RVA: 0x0001C698 File Offset: 0x0001AA98
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x060005EA RID: 1514 RVA: 0x0001C6CE File Offset: 0x0001AACE
		public void LoadAd(AdRequest request)
		{
			this.client.LoadAd(request);
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0001C6DC File Offset: 0x0001AADC
		public void Hide()
		{
			this.client.HideBannerView();
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0001C6E9 File Offset: 0x0001AAE9
		public void Show()
		{
			this.client.ShowBannerView();
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0001C6F6 File Offset: 0x0001AAF6
		public void Destroy()
		{
			this.client.DestroyBannerView();
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0001C703 File Offset: 0x0001AB03
		public float GetHeightInPixels()
		{
			return this.client.GetHeightInPixels();
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0001C710 File Offset: 0x0001AB10
		public float GetWidthInPixels()
		{
			return this.client.GetWidthInPixels();
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0001C71D File Offset: 0x0001AB1D
		public void SetPosition(AdPosition adPosition)
		{
			this.client.SetPosition(adPosition);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0001C72B File Offset: 0x0001AB2B
		public void SetPosition(int x, int y)
		{
			this.client.SetPosition(x, y);
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0001C73C File Offset: 0x0001AB3C
		private void ConfigureBannerEvents()
		{
			this.client.OnAdLoaded += delegate(object sender, EventArgs args)
			{
				if (this.OnAdLoaded != null)
				{
					this.OnAdLoaded(this, args);
				}
			};
			this.client.OnAdFailedToLoad += delegate(object sender, AdFailedToLoadEventArgs args)
			{
				if (this.OnAdFailedToLoad != null)
				{
					this.OnAdFailedToLoad(this, args);
				}
			};
			this.client.OnAdOpening += delegate(object sender, EventArgs args)
			{
				if (this.OnAdOpening != null)
				{
					this.OnAdOpening(this, args);
				}
			};
			this.client.OnAdClosed += delegate(object sender, EventArgs args)
			{
				if (this.OnAdClosed != null)
				{
					this.OnAdClosed(this, args);
				}
			};
			this.client.OnAdLeavingApplication += delegate(object sender, EventArgs args)
			{
				if (this.OnAdLeavingApplication != null)
				{
					this.OnAdLeavingApplication(this, args);
				}
			};
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001C7BC File Offset: 0x0001ABBC
		public string MediationAdapterClassName()
		{
			return this.client.MediationAdapterClassName();
		}

		// Token: 0x040003EF RID: 1007
		private IBannerClient client;
	}
}
