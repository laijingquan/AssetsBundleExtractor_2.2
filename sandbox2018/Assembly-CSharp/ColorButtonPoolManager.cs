using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000150 RID: 336
public class ColorButtonPoolManager : MonoBehaviour
{
	// Token: 0x0600088F RID: 2191 RVA: 0x00024DB4 File Offset: 0x000231B4
	public void Reset()
	{
		this._index = 0;
		for (int i = 0; i < this._colorButtons.Count; i++)
		{
			this._colorButtons[i].transform.localPosition = new Vector2(10000f, 10000f);
			this._colorButtons[i].transform.localScale = Vector2.one;
			this._colorButtons[i].transform.SetParent(base.transform);
			UIColorCellButton component = this._colorButtons[i].GetComponent<UIColorCellButton>();
			component.Reset();
		}
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x00024E62 File Offset: 0x00023262
	public void SetActive(bool isActive)
	{
		base.gameObject.SetActive(isActive);
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x00024E70 File Offset: 0x00023270
	public Transform GetColorButton()
	{
		Transform transform = this._colorButtons[this._index];
		this._index++;
		transform.localScale = Vector2.one;
		return transform;
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x00024EB0 File Offset: 0x000232B0
	public void Load()
	{
		if (!this._isLoad)
		{
			this._isLoad = true;
			this._index = 0;
			for (int i = 0; i < this.COLOR_COUNT; i++)
			{
				this.InitTile();
			}
		}
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x00024EF4 File Offset: 0x000232F4
	private void InitTile()
	{
		Transform transform = ResourceHelper.Load(ColorButtonPoolManager.BUTTON_CELL_PATH).transform;
		transform.SetParent(base.transform);
		transform.transform.localPosition = new Vector2(10000f, 10000f);
		transform.transform.localScale = Vector2.one;
		this._colorButtons.Add(transform);
	}

	// Token: 0x17000099 RID: 153
	// (get) Token: 0x06000894 RID: 2196 RVA: 0x00024F60 File Offset: 0x00023360
	public static ColorButtonPoolManager Instance
	{
		get
		{
			if (ColorButtonPoolManager._instance == null)
			{
				GameObject gameObject = new GameObject("ColorButtonPoolManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				ColorButtonPoolManager._instance = gameObject.AddComponent<ColorButtonPoolManager>();
			}
			return ColorButtonPoolManager._instance;
		}
	}

	// Token: 0x04000549 RID: 1353
	private static string BUTTON_CELL_PATH = "Prefabs/UI/ColorCellButton";

	// Token: 0x0400054A RID: 1354
	private int COLOR_COUNT = 20;

	// Token: 0x0400054B RID: 1355
	private int _index;

	// Token: 0x0400054C RID: 1356
	private bool _isLoad;

	// Token: 0x0400054D RID: 1357
	private List<Transform> _colorButtons = new List<Transform>();

	// Token: 0x0400054E RID: 1358
	private static ColorButtonPoolManager _instance;
}
