using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200017F RID: 383
public class UIMainPanel : MonoBehaviour
{
	// Token: 0x06000A03 RID: 2563 RVA: 0x0002B37C File Offset: 0x0002977C
	public void Init()
	{
		base.GetComponent<RectTransform>().offsetMin = Vector2.zero;
		base.GetComponent<RectTransform>().offsetMax = Vector2.zero;
		this.InitBottomButton();
		this.InitCategoryScrollView();
		this.InitMyWorkPanel();
		this.InitCategroyDetialPanel();
		this.ShowTab(UIMainPanel.MAIN_TAB.eCategory);
	}

	// Token: 0x06000A04 RID: 2564 RVA: 0x0002B3C8 File Offset: 0x000297C8
	private void InitCategoryScrollView()
	{
		this._categoryScrollView = base.transform.Find("CategoryScrollView").GetComponent<UICategoryScrollView>();
		this._categoryScrollView.Init();
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x0002B3F0 File Offset: 0x000297F0
	private void InitMyWorkPanel()
	{
		this._myWorkPanel = base.transform.Find("UIMyWorkPanel").GetComponent<UIMyWorkPanel>();
		this._myWorkPanel.Init();
	}

	// Token: 0x06000A06 RID: 2566 RVA: 0x0002B418 File Offset: 0x00029818
	private void InitBottomButton()
	{
		this._allSelelctedImg = base.transform.Find("AllButton/Selected").gameObject;
		this._mySelectedImg = base.transform.Find("MyButton/Selected").gameObject;
		Button component = base.transform.Find("AllButton").GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			this.OnCategoryButtonClick(base.gameObject);
		});
		Button component2 = base.transform.Find("MyButton").GetComponent<Button>();
		component2.onClick.AddListener(delegate
		{
			this.OnMyButtonClick(base.gameObject);
		});
	}

	// Token: 0x06000A07 RID: 2567 RVA: 0x0002B4B5 File Offset: 0x000298B5
	private void OnCategoryButtonClick(GameObject go)
	{
		this.ShowTab(UIMainPanel.MAIN_TAB.eCategory);
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x0002B4BE File Offset: 0x000298BE
	private void OnMyButtonClick(GameObject go)
	{
		this.ShowTab(UIMainPanel.MAIN_TAB.eMyWork);
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x0002B4C7 File Offset: 0x000298C7
	public void InitCategroyDetialPanel()
	{
		this._categroyDetialPanel = base.transform.Find("UICategroyDetialPanel").GetComponent<UICategroyDetialPanel>();
		this._categroyDetialPanel.Init();
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x0002B4EF File Offset: 0x000298EF
	public void ShowCategroyDetialPanel(int categoryIndex)
	{
		this._categroyDetialPanel.Show(categoryIndex);
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x0002B500 File Offset: 0x00029900
	private void ShowTab(UIMainPanel.MAIN_TAB tab)
	{
		if (tab != UIMainPanel.MAIN_TAB.eCategory)
		{
			if (tab == UIMainPanel.MAIN_TAB.eMyWork)
			{
				this._allSelelctedImg.SetActive(false);
				this._categoryScrollView.gameObject.SetActive(false);
				this._mySelectedImg.SetActive(true);
				this._myWorkPanel.Show();
				this._categroyDetialPanel.Hide();
			}
		}
		else
		{
			this._allSelelctedImg.SetActive(true);
			this._categoryScrollView.gameObject.SetActive(true);
			this._mySelectedImg.SetActive(false);
			this._myWorkPanel.Hide();
			this._categroyDetialPanel.Hide();
		}
	}

	// Token: 0x04000616 RID: 1558
	private GameObject _allSelelctedImg;

	// Token: 0x04000617 RID: 1559
	private GameObject _mySelectedImg;

	// Token: 0x04000618 RID: 1560
	private UIMyWorkPanel _myWorkPanel;

	// Token: 0x04000619 RID: 1561
	private UICategoryScrollView _categoryScrollView;

	// Token: 0x0400061A RID: 1562
	private UICategroyDetialPanel _categroyDetialPanel;

	// Token: 0x02000180 RID: 384
	public enum MAIN_TAB
	{
		// Token: 0x0400061C RID: 1564
		eCategory,
		// Token: 0x0400061D RID: 1565
		eMyWork
	}
}
