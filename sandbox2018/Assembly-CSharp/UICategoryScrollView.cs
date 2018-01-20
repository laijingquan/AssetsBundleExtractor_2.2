using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200017A RID: 378
public class UICategoryScrollView : MonoBehaviour
{
	// Token: 0x060009E2 RID: 2530 RVA: 0x0002AAD8 File Offset: 0x00028ED8
	public void Init()
	{
		GameObject gameObject = base.transform.Find("Viewport/Grid").gameObject;
		int amount = DataManager.Instance.dataDirectoryGroup.amount;
		if (!DailyManager.Instance.isExpired)
		{
			this.AddCell(gameObject, 0);
		}
		for (int i = 1; i < amount; i++)
		{
			this.AddCell(gameObject, i);
		}
	}

	// Token: 0x060009E3 RID: 2531 RVA: 0x0002AB3C File Offset: 0x00028F3C
	private void AddCell(GameObject grid, int index)
	{
		RectTransform component = grid.GetComponent<RectTransform>();
		GameObject gameObject = ResourceHelper.Load(UICategoryScrollView.CATEGORY_CELL_PATH);
		gameObject.transform.SetParent(component);
		gameObject.transform.localScale = Vector3.one;
		UICategroyCell component2 = gameObject.GetComponent<UICategroyCell>();
		component2.Init(base.transform.GetComponent<ScrollRect>(), index);
	}

	// Token: 0x060009E4 RID: 2532 RVA: 0x0002AB90 File Offset: 0x00028F90
	private void Update()
	{
	}

	// Token: 0x04000603 RID: 1539
	private static string CATEGORY_CELL_PATH = "Prefabs/UI/UICategoryCell";
}
