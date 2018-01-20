using System;
using System.Reflection;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200010A RID: 266
	public class DummyClient : IBannerClient, IInterstitialClient, IRewardBasedVideoAdClient, IAdLoaderClient, INativeExpressAdClient, IMobileAdsClient
	{
		// Token: 0x14000040 RID: 64
		// (add) Token: 0x0600065C RID: 1628 RVA: 0x0001D67C File Offset: 0x0001BA7C
		// (remove) Token: 0x0600065D RID: 1629 RVA: 0x0001D6B4 File Offset: 0x0001BAB4
		public event EventHandler<EventArgs> OnAdLoaded;

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x0600065E RID: 1630 RVA: 0x0001D6EC File Offset: 0x0001BAEC
		// (remove) Token: 0x0600065F RID: 1631 RVA: 0x0001D724 File Offset: 0x0001BB24
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x06000660 RID: 1632 RVA: 0x0001D75C File Offset: 0x0001BB5C
		// (remove) Token: 0x06000661 RID: 1633 RVA: 0x0001D794 File Offset: 0x0001BB94
		public event EventHandler<EventArgs> OnAdOpening;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x06000662 RID: 1634 RVA: 0x0001D7CC File Offset: 0x0001BBCC
		// (remove) Token: 0x06000663 RID: 1635 RVA: 0x0001D804 File Offset: 0x0001BC04
		public event EventHandler<EventArgs> OnAdStarted;

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06000664 RID: 1636 RVA: 0x0001D83C File Offset: 0x0001BC3C
		// (remove) Token: 0x06000665 RID: 1637 RVA: 0x0001D874 File Offset: 0x0001BC74
		public event EventHandler<EventArgs> OnAdClosed;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06000666 RID: 1638 RVA: 0x0001D8AC File Offset: 0x0001BCAC
		// (remove) Token: 0x06000667 RID: 1639 RVA: 0x0001D8E4 File Offset: 0x0001BCE4
		public event EventHandler<Reward> OnAdRewarded;

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06000668 RID: 1640 RVA: 0x0001D91C File Offset: 0x0001BD1C
		// (remove) Token: 0x06000669 RID: 1641 RVA: 0x0001D954 File Offset: 0x0001BD54
		public event EventHandler<EventArgs> OnAdLeavingApplication;

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x0600066A RID: 1642 RVA: 0x0001D98C File Offset: 0x0001BD8C
		// (remove) Token: 0x0600066B RID: 1643 RVA: 0x0001D9C4 File Offset: 0x0001BDC4
		public event EventHandler<CustomNativeEventArgs> OnCustomNativeTemplateAdLoaded;

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x0001D9FA File Offset: 0x0001BDFA
		// (set) Token: 0x0600066D RID: 1645 RVA: 0x0001DA01 File Offset: 0x0001BE01
		public string UserId
		{
			get
			{
				return "UserId";
			}
			set
			{
			}
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0001DA03 File Offset: 0x0001BE03
		public void Initialize(string appId)
		{
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0001DA05 File Offset: 0x0001BE05
		public void SetApplicationMuted(bool muted)
		{
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0001DA07 File Offset: 0x0001BE07
		public void SetApplicationVolume(float volume)
		{
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0001DA09 File Offset: 0x0001BE09
		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0001DA0B File Offset: 0x0001BE0B
		public void CreateBannerView(string adUnitId, AdSize adSize, int positionX, int positionY)
		{
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0001DA0D File Offset: 0x0001BE0D
		public void LoadAd(AdRequest request)
		{
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0001DA0F File Offset: 0x0001BE0F
		public void ShowBannerView()
		{
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0001DA11 File Offset: 0x0001BE11
		public void HideBannerView()
		{
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0001DA13 File Offset: 0x0001BE13
		public void DestroyBannerView()
		{
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0001DA15 File Offset: 0x0001BE15
		public float GetHeightInPixels()
		{
			return 0f;
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0001DA1C File Offset: 0x0001BE1C
		public float GetWidthInPixels()
		{
			return 0f;
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0001DA23 File Offset: 0x0001BE23
		public void SetPosition(AdPosition adPosition)
		{
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001DA25 File Offset: 0x0001BE25
		public void SetPosition(int x, int y)
		{
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0001DA27 File Offset: 0x0001BE27
		public void CreateInterstitialAd(string adUnitId)
		{
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0001DA29 File Offset: 0x0001BE29
		public bool IsLoaded()
		{
			return true;
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0001DA2C File Offset: 0x0001BE2C
		public void ShowInterstitial()
		{
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0001DA2E File Offset: 0x0001BE2E
		public void DestroyInterstitial()
		{
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0001DA30 File Offset: 0x0001BE30
		public void CreateRewardBasedVideoAd()
		{
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0001DA32 File Offset: 0x0001BE32
		public void SetUserId(string userId)
		{
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0001DA34 File Offset: 0x0001BE34
		public void LoadAd(AdRequest request, string adUnitId)
		{
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0001DA36 File Offset: 0x0001BE36
		public void DestroyRewardBasedVideoAd()
		{
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0001DA38 File Offset: 0x0001BE38
		public void ShowRewardBasedVideoAd()
		{
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0001DA3A File Offset: 0x0001BE3A
		public void CreateAdLoader(AdLoader.Builder builder)
		{
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0001DA3C File Offset: 0x0001BE3C
		public void Load(AdRequest request)
		{
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0001DA3E File Offset: 0x0001BE3E
		public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position)
		{
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001DA40 File Offset: 0x0001BE40
		public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, int positionX, int positionY)
		{
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0001DA42 File Offset: 0x0001BE42
		public void SetAdSize(AdSize adSize)
		{
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001DA44 File Offset: 0x0001BE44
		public void ShowNativeExpressAdView()
		{
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001DA46 File Offset: 0x0001BE46
		public void HideNativeExpressAdView()
		{
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0001DA48 File Offset: 0x0001BE48
		public void DestroyNativeExpressAdView()
		{
			Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0001DA63 File Offset: 0x0001BE63
		public string MediationAdapterClassName()
		{
			return null;
		}
	}
}
