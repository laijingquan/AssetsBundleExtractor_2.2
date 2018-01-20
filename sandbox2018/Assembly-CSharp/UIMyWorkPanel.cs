using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000181 RID: 385
public class UIMyWorkPanel : MonoBehaviour
{
	// Token: 0x06000A0F RID: 2575 RVA: 0x0002B5D0 File Offset: 0x000299D0
	public void Init()
	{
		this.Hide();
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x0002B5D8 File Offset: 0x000299D8
	public void Show()
	{
		GameObject gameObject = base.transform.Find("MyScrollView").gameObject;
		List<string> myPictureList = PlayerManager.Instance.GetMyPictureList();
		if (myPictureList.Count > 0)
		{
			this._grid = gameObject.transform.Find("Viewport/Grid").gameObject;
			foreach (string tid in myPictureList)
			{
				this.AddCell(this._grid, tid);
			}
		}
		Text component = base.transform.Find("TitleText").GetComponent<Text>();
		component.text = DataManager.Instance.dataLocalizationGroup.GetText("my_work");
		base.gameObject.SetActive(true);
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x0002B6BC File Offset: 0x00029ABC
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

	// Token: 0x06000A12 RID: 2578 RVA: 0x0002B72C File Offset: 0x00029B2C
	private void AddCell(GameObject grid, string TID)
	{
		RectTransform component = grid.GetComponent<RectTransform>();
		GameObject gameObject = ResourceHelper.Load(UIMyWorkPanel.CELL_PATH);
		gameObject.transform.SetParent(component);
		gameObject.transform.localScale = Vector3.one;
		UIThumbCellBig component2 = gameObject.GetComponent<UIThumbCellBig>();
		component2.Init(TID);
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x0002B775 File Offset: 0x00029B75
	private void Update()
	{
	}

	// Token: 0x0400061E RID: 1566
	private static string CELL_PATH = "Prefabs/UI/UIThumbCellBig";

	// Token: 0x0400061F RID: 1567
	private GameObject _grid;
}
