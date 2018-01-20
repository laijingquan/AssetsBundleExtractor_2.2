using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200017D RID: 381
public class UIColorCellButton : MonoBehaviour
{
	// Token: 0x060009F7 RID: 2551 RVA: 0x0002B09C File Offset: 0x0002949C
	public void Init(int index, Color c)
	{
		this._colorIndex = index;
		Color selectColor = ColorHelper.GetSelectColor(c);
		Color numberColor = ColorHelper.GetNumberColor(c);
		Image component = base.transform.GetComponent<Image>();
		component.color = c;
		this._selected = base.transform.Find("Selected").GetComponent<Image>();
		this._finish = base.transform.Find("Finish").GetComponent<Image>();
		this._number = base.transform.Find("Number").GetComponent<Text>();
		this._button = base.gameObject.GetComponent<Button>();
		if (index > 0)
		{
			this._selected.color = selectColor;
			this._finish.color = numberColor;
			this._number.color = numberColor;
			this._number.text = index + string.Empty;
		}
		this.SetFinishVisible(false);
		this.SetSelectedVisible(false);
		this._button.onClick.AddListener(delegate
		{
			this.OnClick(base.gameObject);
		});
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x0002B1A8 File Offset: 0x000295A8
	public void SetFinishVisible(bool isVisible)
	{
		this._finish.gameObject.SetActive(isVisible);
		this._number.gameObject.SetActive(!isVisible);
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x0002B1CF File Offset: 0x000295CF
	public void SetSelectedVisible(bool isVisible)
	{
		this._selected.gameObject.SetActive(isVisible);
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x0002B1E4 File Offset: 0x000295E4
	public void OnClick(GameObject go)
	{
		Debug.Log("On Click" + this._colorIndex);
		GameUIManager.Instance.SetUIButtonSelected(this._colorIndex);
		GameUIManager.Instance.selectedPenColor = this._colorIndex;
		GameManager.Instance.tileManager.SetHighLight(this._colorIndex);
		GameManager.Instance.gameTouchLayer.SetDragEnabled(true);
	}

	// Token: 0x060009FB RID: 2555 RVA: 0x0002B250 File Offset: 0x00029650
	public void SetUpdateFinish(bool b)
	{
		this._isUpdateFinish = b;
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x0002B259 File Offset: 0x00029659
	public void Reset()
	{
		this._isUpdateFinish = false;
		if (this._button != null)
		{
			this._button.onClick.RemoveAllListeners();
		}
		this._isUpdateFinish = false;
		this._isSelelctedOnce = false;
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x0002B294 File Offset: 0x00029694
	private void Update()
	{
		if (this._isUpdateFinish && this._colorIndex > 0)
		{
			bool flag = GameManager.Instance.levelDataManager.IsColorFinish(this._colorIndex);
			if (flag)
			{
				this.SetFinishVisible(true);
				if (GameUIManager.Instance.selectedPenColor == this._colorIndex && !this._isSelelctedOnce)
				{
					this._isSelelctedOnce = true;
				}
			}
			else
			{
				this._isSelelctedOnce = false;
				this.SetFinishVisible(false);
			}
		}
	}

	// Token: 0x0400060E RID: 1550
	private int _colorIndex;

	// Token: 0x0400060F RID: 1551
	private Image _selected;

	// Token: 0x04000610 RID: 1552
	private Text _number;

	// Token: 0x04000611 RID: 1553
	private Image _finish;

	// Token: 0x04000612 RID: 1554
	private Button _button;

	// Token: 0x04000613 RID: 1555
	private bool _isUpdateFinish;

	// Token: 0x04000614 RID: 1556
	private bool _isSelelctedOnce;
}
