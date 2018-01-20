using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200017C RID: 380
public class UICategroyDetialPanel : MonoBehaviour
{
	// Token: 0x060009EF RID: 2543 RVA: 0x0002ADCC File Offset: 0x000291CC
	public void Init()
	{
		Button component = base.transform.Find("BackButton").GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			this.OnBackCick(base.gameObject);
		});
		this.Hide();
		this._categroyIcon = null;
	}

	// Token: 0x060009F0 RID: 2544 RVA: 0x0002AE14 File Offset: 0x00029214
	public void Show(int categoryIndex)
	{
		base.gameObject.SetActive(true);
		DataCategory dataCategory = DataManager.Instance.dataDirectoryGroup.dataCategoryList[categoryIndex];
		Text component = base.transform.Find("TitleText").GetComponent<Text>();
		component.text = DataManager.Instance.dataLocalizationGroup.GetText(dataCategory.title);
		if (this._categroyIcon != null)
		{
			this._categroyIcon.transform.SetParent(null);
			UnityEngine.Object.Destroy(this._categroyIcon);
		}
		this._categroyIcon = ResourceHelper.Load(UICategroyDetialPanel.CATEGORY_ICON_PREFIX + dataCategory.title);
		Transform parent = base.transform.Find("IconPosition");
		this._categroyIcon.transform.SetParent(parent);
		this._categroyIcon.transform.localPosition = Vector2.zero;
		this._categroyIcon.transform.localScale = Vector2.one;
		GameObject gameObject = base.transform.Find("MyScrollView").gameObject;
		List<string> picList = dataCategory.picList;
		if (picList.Count > 0)
		{
			this._grid = gameObject.transform.Find("Viewport/Grid").gameObject;
			foreach (string tid in picList)
			{
				this.AddCell(this._grid, tid);
			}
		}
	}

	// Token: 0x060009F1 RID: 2545 RVA: 0x0002AFAC File Offset: 0x000293AC
	private void AddCell(GameObject grid, string TID)
	{
		RectTransform component = grid.GetComponent<RectTransform>();
		GameObject gameObject = ResourceHelper.Load(UICategroyDetialPanel.CELL_PATH);
		gameObject.transform.SetParent(component);
		gameObject.transform.localScale = Vector3.one;
		UIThumbCellBig component2 = gameObject.GetComponent<UIThumbCellBig>();
		component2.Init(TID);
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x0002AFF5 File Offset: 0x000293F5
	private void OnBackCick(GameObject go)
	{
		this.Hide();
	}

	// Token: 0x060009F3 RID: 2547 RVA: 0x0002B000 File Offset: 0x00029400
	public void Hide()
	{
		if (this._grid != null)
		{
			UIThumbCellBig[] componentsInChildren = this._grid.GetComponentsInChildren<UIThumbCellBig>();
			for (int i = componentsInChildren.Length - 1; i >= 0; i--)
			{
				componentsInChildren[i].transform.SetParent(null);
				UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
			}
			this._grid = null;
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x0400060A RID: 1546
	private static string CELL_PATH = "Prefabs/UI/UIThumbCellBig";

	// Token: 0x0400060B RID: 1547
	private static string CATEGORY_ICON_PREFIX = "Prefabs/UI/CategoryIcon/";

	// Token: 0x0400060C RID: 1548
	private GameObject _grid;

	// Token: 0x0400060D RID: 1549
	private GameObject _categroyIcon;
}
