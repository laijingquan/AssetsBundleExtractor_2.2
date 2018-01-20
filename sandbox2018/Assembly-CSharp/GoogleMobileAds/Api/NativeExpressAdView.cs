using System;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000107 RID: 263
	public class NativeExpressAdView
	{
		// Token: 0x06000623 RID: 1571 RVA: 0x0001CD2C File Offset: 0x0001B12C
		public NativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildNativeExpressAdClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (INativeExpressAdClient)method.Invoke(null, null);
			this.client.CreateNativeExpressAdView(adUnitId, adSize, position);
			this.ConfigureNativeExpressAdEvents();
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0001CD80 File Offset: 0x0001B180
		public NativeExpressAdView(string adUnitId, AdSize adSize, int x, int y)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildNativeExpressAdClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (INativeExpressAdClient)method.Invoke(null, null);
			this.client.CreateNativeExpressAdView(adUnitId, adSize, x, y);
			this.ConfigureNativeExpressAdEvents();
		}

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000625 RID: 1573 RVA: 0x0001CDD8 File Offset: 0x0001B1D8
		// (remove) Token: 0x06000626 RID: 1574 RVA: 0x0001CE10 File Offset: 0x0001B210
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06000627 RID: 1575 RVA: 0x0001CE48 File Offset: 0x0001B248
		// (remove) Token: 0x06000628 RID: 1576 RVA: 0x0001CE80 File Offset: 0x0001B280
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06000629 RID: 1577 RVA: 0x0001CEB8 File Offset: 0x0001B2B8
		// (remove) Token: 0x0600062A RID: 1578 RVA: 0x0001CEF0 File Offset: 0x0001B2F0
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x0600062B RID: 1579 RVA: 0x0001CF28 File Offset: 0x0001B328
		// (remove) Token: 0x0600062C RID: 1580 RVA: 0x0001CF60 File Offset: 0x0001B360
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x0600062D RID: 1581 RVA: 0x0001CF98 File Offset: 0x0001B398
		// (remove) Token: 0x0600062E RID: 1582 RVA: 0x0001CFD0 File Offset: 0x0001B3D0
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x0600062F RID: 1583 RVA: 0x0001D006 File Offset: 0x0001B406
		public void LoadAd(AdRequest request)
		{
			this.client.LoadAd(request);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0001D014 File Offset: 0x0001B414
		public void Hide()
		{
			this.client.HideNativeExpressAdView();
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0001D021 File Offset: 0x0001B421
		public void Show()
		{
			this.client.ShowNativeExpressAdView();
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001D02E File Offset: 0x0001B42E
		public void Destroy()
		{
			this.client.DestroyNativeExpressAdView();
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0001D03C File Offset: 0x0001B43C
		private void ConfigureNativeExpressAdEvents()
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

		// Token: 0x06000634 RID: 1588 RVA: 0x0001D0BC File Offset: 0x0001B4BC
		public string MediationAdapterClassName()
		{
			return this.client.MediationAdapterClassName();
		}

		// Token: 0x04000403 RID: 1027
		private INativeExpressAdClient client;
	}
}
