using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000182 RID: 386
public class UIRatePanel : MonoBehaviour
{
	// Token: 0x06000A16 RID: 2582 RVA: 0x0002B7A0 File Offset: 0x00029BA0
	public void Init(Action onPanelClosed)
	{
		base.GetComponent<RectTransform>().offsetMin = Vector2.zero;
		base.GetComponent<RectTransform>().offsetMax = Vector2.zero;
		Button component = base.transform.Find("ButtonClose").GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			this.CloseCallBack(base.gameObject);
		});
		Button component2 = base.transform.Find("ButtonSubmit").GetComponent<Button>();
		component2.onClick.AddListener(delegate
		{
			this.SubmitCallback(base.gameObject);
		});
		for (int i = 0; i < 5; i++)
		{
			string name = "MiddleImage/Star_" + i;
			Transform t = base.transform.Find(name);
			this._starList.Add(t);
			Button component3 = t.GetComponent<Button>();
			component3.onClick.AddListener(delegate
			{
				this.ButtonClick(t.gameObject);
			});
		}
		this._onPanelClosed = onPanelClosed;
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x0002B8A8 File Offset: 0x00029CA8
	public void ButtonClick(GameObject go)
	{
		string name = go.name;
		if (name != null)
		{
			if (!(name == "Star_0"))
			{
				if (!(name == "Star_1"))
				{
					if (!(name == "Star_2"))
					{
						if (!(name == "Star_3"))
						{
							if (name == "Star_4")
							{
								this.FillStar(5);
							}
						}
						else
						{
							this.FillStar(4);
						}
					}
					else
					{
						this.FillStar(3);
					}
				}
				else
				{
					this.FillStar(2);
				}
			}
			else
			{
				this.FillStar(1);
			}
		}
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x0002B954 File Offset: 0x00029D54
	private void FillStar(int starCount)
	{
		this._selectedStar = starCount;
		for (int i = 0; i < 5; i++)
		{
			if (i < starCount)
			{
				this._starList[i].Find("Selected").gameObject.SetActive(true);
			}
			else
			{
				this._starList[i].Find("Selected").gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x0002B9C8 File Offset: 0x00029DC8
	public void SubmitCallback(GameObject go)
	{
		if (this._selectedStar < 5)
		{
			this.CloseCallBack(base.gameObject);
		}
		else
		{
			PlayerManager.Instance.SetRate(true);
			Application.OpenURL("market://details?id=sandbox.coloring.number.pixel.art");
		}
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x0002B9FC File Offset: 0x00029DFC
	public void CloseCallBack(GameObject go)
	{
		base.transform.SetParent(null);
		UnityEngine.Object.Destroy(base.gameObject);
		if (this._onPanelClosed != null)
		{
			this._onPanelClosed();
		}
	}

	// Token: 0x04000620 RID: 1568
	private Action _onPanelClosed;

	// Token: 0x04000621 RID: 1569
	private List<Transform> _starList = new List<Transform>();

	// Token: 0x04000622 RID: 1570
	private int _selectedStar = 5;
}
