using System;
using System.Reflection;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000104 RID: 260
	public class InterstitialAd
	{
		// Token: 0x06000603 RID: 1539 RVA: 0x0001C8E4 File Offset: 0x0001ACE4
		public InterstitialAd(string adUnitId)
		{
			Type type = Type.GetType("GoogleMobileAds.GoogleMobileAdsClientFactory,Assembly-CSharp");
			MethodInfo method = type.GetMethod("BuildInterstitialClient", BindingFlags.Static | BindingFlags.Public);
			this.client = (IInterstitialClient)method.Invoke(null, null);
			this.client.CreateInterstitialAd(adUnitId);
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

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000604 RID: 1540 RVA: 0x0001C9A4 File Offset: 0x0001ADA4
		// (remove) Token: 0x06000605 RID: 1541 RVA: 0x0001C9DC File Offset: 0x0001ADDC
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06000606 RID: 1542 RVA: 0x0001CA14 File Offset: 0x0001AE14
		// (remove) Token: 0x06000607 RID: 1543 RVA: 0x0001CA4C File Offset: 0x0001AE4C
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06000608 RID: 1544 RVA: 0x0001CA84 File Offset: 0x0001AE84
		// (remove) Token: 0x06000609 RID: 1545 RVA: 0x0001CABC File Offset: 0x0001AEBC
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x0600060A RID: 1546 RVA: 0x0001CAF4 File Offset: 0x0001AEF4
		// (remove) Token: 0x0600060B RID: 1547 RVA: 0x0001CB2C File Offset: 0x0001AF2C
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x0600060C RID: 1548 RVA: 0x0001CB64 File Offset: 0x0001AF64
		// (remove) Token: 0x0600060D RID: 1549 RVA: 0x0001CB9C File Offset: 0x0001AF9C
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x0600060E RID: 1550 RVA: 0x0001CBD2 File Offset: 0x0001AFD2
		public void LoadAd(AdRequest request)
		{
			this.client.LoadAd(request);
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0001CBE0 File Offset: 0x0001AFE0
		public bool IsLoaded()
		{
			return this.client.IsLoaded();
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0001CBED File Offset: 0x0001AFED
		public void Show()
		{
			this.client.ShowInterstitial();
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0001CBFA File Offset: 0x0001AFFA
		public void Destroy()
		{
			this.client.DestroyInterstitial();
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0001CC07 File Offset: 0x0001B007
		public string MediationAdapterClassName()
		{
			return this.client.MediationAdapterClassName();
		}

		// Token: 0x040003FB RID: 1019
		private IInterstitialClient client;
	}
}
