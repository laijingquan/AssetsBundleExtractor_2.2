using System;
using UnityEngine;

// Token: 0x02000172 RID: 370
public class MainUIManager : MonoBehaviour
{
	// Token: 0x060009C2 RID: 2498 RVA: 0x0002A489 File Offset: 0x00028889
	private void Awake()
	{
		if (MainUIManager.instance == null)
		{
			MainUIManager.instance = this;
		}
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x0002A4A4 File Offset: 0x000288A4
	public void Load()
	{
		Transform transform = ResourceHelper.LoadUI("Prefabs/UI/UIMainPanel", base.transform);
		this._mainPanel = transform.GetComponent<UIMainPanel>();
		this._mainPanel.Init();
	}

	// Token: 0x060009C4 RID: 2500 RVA: 0x0002A4D9 File Offset: 0x000288D9
	public void SetMenuPanelVisible(bool isVisible)
	{
		this._mainPanel.gameObject.SetActive(isVisible);
	}

	// Token: 0x060009C5 RID: 2501 RVA: 0x0002A4EC File Offset: 0x000288EC
	public void ShowRatePanel(Action onClosedCallback)
	{
		Transform transform = ResourceHelper.LoadUI("Prefabs/UI/UIRatePanel", base.transform);
		UIRatePanel component = transform.GetComponent<UIRatePanel>();
		component.Init(onClosedCallback);
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x0002A518 File Offset: 0x00028918
	public void ShowVipPanel()
	{
		string name = "Prefabs/UI/UIVIPPanel";
		if (ComibilityHelper.IsWideScreen())
		{
			name = "Prefabs/UI/UIVipPanelWidescreen";
		}
		Transform transform = ResourceHelper.LoadUI(name, base.transform);
		this._vipPanel = transform.GetComponent<UIVipPanel>();
		this._vipPanel.Init();
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x0002A55F File Offset: 0x0002895F
	public void ClosedVipPanel()
	{
		if (this._vipPanel != null)
		{
			this._vipPanel.Close();
			this._vipPanel = null;
		}
	}

	// Token: 0x060009C8 RID: 2504 RVA: 0x0002A584 File Offset: 0x00028984
	public void ShowLoading()
	{
		Transform transform = ResourceHelper.LoadUI("Prefabs/UI/UILoadingPanel", base.transform);
		UILoadingPanel component = transform.GetComponent<UILoadingPanel>();
		component.Init();
	}

	// Token: 0x060009C9 RID: 2505 RVA: 0x0002A5AF File Offset: 0x000289AF
	public void ShowCategoryDetialPanel(int categoryIndex)
	{
		this._mainPanel.ShowCategroyDetialPanel(categoryIndex);
	}

	// Token: 0x170000AC RID: 172
	// (get) Token: 0x060009CA RID: 2506 RVA: 0x0002A5BD File Offset: 0x000289BD
	public static MainUIManager Instance
	{
		get
		{
			return MainUIManager.instance;
		}
	}

	// Token: 0x040005E7 RID: 1511
	private const string UI_MAIN_PANEL = "Prefabs/UI/UIMainPanel";

	// Token: 0x040005E8 RID: 1512
	private const string UI_VIP_PANEL = "Prefabs/UI/UIVIPPanel";

	// Token: 0x040005E9 RID: 1513
	private const string UI_VIP_PANEL_WIDESCREEN = "Prefabs/UI/UIVipPanelWidescreen";

	// Token: 0x040005EA RID: 1514
	private const string UI_LOADING_PANEL = "Prefabs/UI/UILoadingPanel";

	// Token: 0x040005EB RID: 1515
	private const string UI_DETIAL_PANEL = "Prefabs/UI/UICategoryDetialPanel";

	// Token: 0x040005EC RID: 1516
	private const string UI_RATE_PANEL = "Prefabs/UI/UIRatePanel";

	// Token: 0x040005ED RID: 1517
	private UIMainPanel _mainPanel;

	// Token: 0x040005EE RID: 1518
	private UIVipPanel _vipPanel;

	// Token: 0x040005EF RID: 1519
	private static MainUIManager instance;
}
