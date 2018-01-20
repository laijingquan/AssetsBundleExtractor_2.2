using System;
using OneP.InfinityScrollView;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200017B RID: 379
public class UICategroyCell : MonoBehaviour
{
	// Token: 0x060009E7 RID: 2535 RVA: 0x0002ABA8 File Offset: 0x00028FA8
	public void Init(ScrollRect scRect, int categoryIndex)
	{
		this._categoryIndex = categoryIndex;
		Transform transform = base.transform.Find("ScrollView");
		this._nestedScrollRect = transform.GetComponent<NestedScrollRect>();
		this._nestedScrollRect.anotherScrollRect = scRect;
		this._infinityScrollView = transform.GetComponent<InfinityScrollView>();
		this._dataCategory = DataManager.Instance.dataDirectoryGroup.dataCategoryList[this._categoryIndex];
		this.InitTop();
		this.CreateThumbCell();
	}

	// Token: 0x060009E8 RID: 2536 RVA: 0x0002AC20 File Offset: 0x00029020
	private void InitTop()
	{
		Text component = base.transform.Find("TitleText").GetComponent<Text>();
		component.text = DataManager.Instance.dataLocalizationGroup.GetText(this._dataCategory.title);
		GameObject gameObject = ResourceHelper.Load(UICategroyCell.CATEGORY_ICON_PREFIX + this._dataCategory.title);
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localPosition = new Vector2(-448f, 383f);
		gameObject.transform.localScale = Vector2.one;
		Button component2 = base.transform.Find("ViewButton").GetComponent<Button>();
		component2.onClick.AddListener(delegate
		{
			this.OnShowAllCick(base.gameObject);
		});
		Text component3 = base.transform.Find("ViewButton").GetComponent<Text>();
		component3.text = DataManager.Instance.dataLocalizationGroup.GetText("view_all");
		if (this._categoryIndex == 0)
		{
		}
	}

	// Token: 0x060009E9 RID: 2537 RVA: 0x0002AD2C File Offset: 0x0002912C
	private void CreateThumbCell()
	{
		int amount = this._dataCategory.amount;
		int num = amount / 2;
		if (amount % 2 == 1)
		{
			num++;
		}
		this._infinityScrollView.categoryIndex = this._categoryIndex;
		this._infinityScrollView.initTotalNumber = amount;
		this._infinityScrollView.itemGenerate = 4;
		this._infinityScrollView.Setup(num);
		this._infinityScrollView.InternalReload();
	}

	// Token: 0x060009EA RID: 2538 RVA: 0x0002AD96 File Offset: 0x00029196
	public void OnShowAllCick(GameObject go)
	{
		MainUIManager.Instance.ShowCategoryDetialPanel(this._categoryIndex);
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x0002ADA8 File Offset: 0x000291A8
	private void Update()
	{
	}

	// Token: 0x04000604 RID: 1540
	private static string CATEGORY_ICON_PREFIX = "Prefabs/UI/CategoryIcon/";

	// Token: 0x04000605 RID: 1541
	private int _categoryIndex;

	// Token: 0x04000606 RID: 1542
	private DataCategory _dataCategory;

	// Token: 0x04000607 RID: 1543
	private UIDragEventSyn _dragEventSyn;

	// Token: 0x04000608 RID: 1544
	private InfinityScrollView _infinityScrollView;

	// Token: 0x04000609 RID: 1545
	private NestedScrollRect _nestedScrollRect;
}
