using System;
using UnityEngine;

// Token: 0x02000166 RID: 358
public class Tile : MonoBehaviour
{
	// Token: 0x170000A7 RID: 167
	// (get) Token: 0x06000938 RID: 2360 RVA: 0x000278FC File Offset: 0x00025CFC
	public DataTiles.DataTile dataTile
	{
		get
		{
			return this._dataTile;
		}
	}

	// Token: 0x170000A8 RID: 168
	// (get) Token: 0x06000939 RID: 2361 RVA: 0x00027904 File Offset: 0x00025D04
	public int colorNumber
	{
		get
		{
			return this._colorNumber;
		}
	}

	// Token: 0x170000A9 RID: 169
	// (set) Token: 0x0600093A RID: 2362 RVA: 0x0002790C File Offset: 0x00025D0C
	public bool isHoldClickOnce
	{
		set
		{
			this._isHoldClickOnce = value;
		}
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x00027918 File Offset: 0x00025D18
	public void Init(ref DataTiles.DataTile dataTile)
	{
		this._dataTile = dataTile;
		this._colorNumber = this._dataTile.colorIndex;
		this._isHoldClickOnce = false;
		float x = (float)this._dataTile.indexX * AppConfig.GRID_UNIT_LENGTH;
		float y = (float)this._dataTile.indexY * AppConfig.GRID_UNIT_LENGTH;
		base.transform.position = new Vector3(x, y, 0f);
		this._mainRenderer = base.GetComponent<SpriteRenderer>();
		this._highLightRenderer = base.transform.Find("HighLight").GetComponent<SpriteRenderer>();
		this._highLightRenderer.sortingOrder = 0;
		this._highLightRenderer.color = new Color(0f, 0f, 0f, 0f);
		if (this._dataTile.colorIndex == 0)
		{
			this._highLightRenderer.gameObject.SetActive(false);
		}
		else
		{
			this._highLightRenderer.gameObject.SetActive(true);
		}
		if (!this._dataTile.isWhite)
		{
			this.AddNumber();
		}
		if (this._dataTile.isTouchRight)
		{
			this.SetRightColor();
		}
		else if (this._dataTile.isTouchWrong)
		{
			Color penColor = GameUIManager.Instance.GetPenColor(this._dataTile.wrongColorIndex);
			this.SetWrongColor(penColor);
		}
		else
		{
			this.SetGreyColor();
		}
	}

	// Token: 0x0600093C RID: 2364 RVA: 0x00027A79 File Offset: 0x00025E79
	public void SetRightColor()
	{
		this.SetTrueColor();
		this.SetNumberAlpha(0f);
		this.SetHighLightAlphaNormal(0f);
	}

	// Token: 0x0600093D RID: 2365 RVA: 0x00027A98 File Offset: 0x00025E98
	public void SetWrongColor(Color c)
	{
		if (this._dataTile.isValid)
		{
			float grid_opacity = DataManager.Instance.dataConfig.grid_opacity;
			this._mainRenderer.color = ColorHelper.GenColorAlpha(c, grid_opacity);
			float scaleDrawRadio = GameManager.Instance.levelManager.scaleDrawRadio;
			this.SetNumberAlpha(scaleDrawRadio);
		}
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x00027AF0 File Offset: 0x00025EF0
	public void SetEarserColor()
	{
		float scaleDrawRadio = GameManager.Instance.levelManager.scaleDrawRadio;
		float scaleGreyRadio = GameManager.Instance.levelManager.scaleGreyRadio;
		this.SetGreyColor();
		this.SetMainAlpha(scaleGreyRadio);
		this.SetNumberAlpha(scaleDrawRadio);
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x00027B31 File Offset: 0x00025F31
	public void SetHighLightColor()
	{
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x00027B34 File Offset: 0x00025F34
	private void AddNumber()
	{
		if (this._dataTile.isValid)
		{
			Transform number = NumberPoolManager.Instance.GetNumber(this._colorNumber);
			this._numberRenderer = number.GetComponent<SpriteRenderer>();
			this._numberRenderer.sortingOrder = 0;
			number.SetParent(base.transform);
			number.localScale = new Vector2(AppConfig.NUMBER_IMG_SCALE, AppConfig.NUMBER_IMG_SCALE);
			number.localPosition = Vector3.zero;
			this.SetNumberAlpha(0f);
		}
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x00027BB8 File Offset: 0x00025FB8
	public void TileClick(bool bClickOrHold)
	{
		int selectedPenColor = GameUIManager.Instance.selectedPenColor;
		int isTouchRight = 0;
		int isEarser;
		if (selectedPenColor == 0)
		{
			isEarser = 0;
			this.EarserClick();
		}
		else
		{
			isEarser = 1;
			if (selectedPenColor == this._colorNumber)
			{
				this.RightClick();
				isTouchRight = 0;
			}
			else
			{
				this.WrongClick();
				isTouchRight = 1;
			}
		}
		if (bClickOrHold)
		{
			GameManager.Instance.levelDataManager.AddColorFill(this._dataTile.indexX, this._dataTile.indexY, selectedPenColor, isTouchRight, isEarser);
		}
		else if (!this._isHoldClickOnce)
		{
			this._isHoldClickOnce = true;
			GameManager.Instance.levelDataManager.AddColorFill(this._dataTile.indexX, this._dataTile.indexY, selectedPenColor, isTouchRight, isEarser);
		}
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x00027C77 File Offset: 0x00026077
	public void RightClick()
	{
		this._dataTile.isTouched = true;
		this._dataTile.isTouchRight = true;
		this._dataTile.isTouchWrong = false;
		this.SetRightColor();
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x00027CA4 File Offset: 0x000260A4
	public void WrongClick()
	{
		Color currentPenColor = GameUIManager.Instance.GetCurrentPenColor();
		this._dataTile.isTouched = true;
		this._dataTile.isTouchRight = false;
		this._dataTile.isTouchWrong = true;
		this._dataTile.wrongColorIndex = GameUIManager.Instance.selectedPenColor;
		this.SetWrongColor(currentPenColor);
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x00027CFC File Offset: 0x000260FC
	public void EarserClick()
	{
		this._dataTile.isTouched = false;
		this._dataTile.isTouchRight = false;
		this._dataTile.isTouchWrong = false;
		this.SetEarserColor();
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x00027D28 File Offset: 0x00026128
	public void SetTrueColor()
	{
		if (this._dataTile.isValid)
		{
			this._mainRenderer.color = this._dataTile.colorTile.trueColor;
		}
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x00027D55 File Offset: 0x00026155
	public void SetGreyColor()
	{
		if (this._dataTile.isValid)
		{
			this._mainRenderer.color = this._dataTile.colorTile.greyColor;
		}
	}

	// Token: 0x06000947 RID: 2375 RVA: 0x00027D84 File Offset: 0x00026184
	public void SetMainAlpha(float alpha)
	{
		if (this._dataTile.isTouched)
		{
			return;
		}
		if (this._dataTile.isValid)
		{
			Color color = this._mainRenderer.color;
			color.a = alpha;
			this._mainRenderer.color = color;
		}
	}

	// Token: 0x06000948 RID: 2376 RVA: 0x00027DD4 File Offset: 0x000261D4
	public void SetNumberAlpha(float alpha)
	{
		if (this._dataTile.isTouchRight)
		{
			alpha = 0f;
		}
		if (this._dataTile.isValid && !this._dataTile.isWhite && this._numberRenderer != null)
		{
			Color color = this._numberRenderer.color;
			color.a = alpha;
			this._numberRenderer.color = color;
		}
	}

	// Token: 0x06000949 RID: 2377 RVA: 0x00027E4C File Offset: 0x0002624C
	public void SetHighLightAlpha(float alpha)
	{
		if (this._dataTile.isTouchRight)
		{
			return;
		}
		if (GameUIManager.Instance.selectedPenColor == this._colorNumber)
		{
			Color grid_selectColor = DataManager.Instance.dataConfig.grid_selectColor;
			float grid_opacity = DataManager.Instance.dataConfig.grid_opacity;
			grid_selectColor.a = grid_opacity * alpha;
			this._highLightRenderer.color = grid_selectColor;
		}
	}

	// Token: 0x0600094A RID: 2378 RVA: 0x00027EB8 File Offset: 0x000262B8
	public void SetHighLightAlphaNormal(float alpha)
	{
		Color color = this._highLightRenderer.color;
		color.a = alpha;
		this._highLightRenderer.color = color;
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x00027EE8 File Offset: 0x000262E8
	public void SetHightLight(Color c)
	{
		if (this._dataTile.isTouchRight)
		{
			return;
		}
		float scaleDrawRadio = GameManager.Instance.levelManager.scaleDrawRadio;
		c.a *= scaleDrawRadio;
		this._highLightRenderer.color = c;
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x00027F34 File Offset: 0x00026334
	public void Reset()
	{
		this._mainRenderer.transform.localScale = Vector2.one;
		this._mainRenderer.color = Color.white;
		this._highLightRenderer.transform.localScale = Vector2.one;
		this._highLightRenderer.color = new Color(0f, 0f, 0f, 0f);
		base.transform.localScale = Vector2.one;
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x00027FBE File Offset: 0x000263BE
	private void Update()
	{
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x00027FC0 File Offset: 0x000263C0
	private void OnDestroy()
	{
	}

	// Token: 0x040005B5 RID: 1461
	private DataTiles.DataTile _dataTile;

	// Token: 0x040005B6 RID: 1462
	private SpriteRenderer _mainRenderer;

	// Token: 0x040005B7 RID: 1463
	private SpriteRenderer _highLightRenderer;

	// Token: 0x040005B8 RID: 1464
	private SpriteRenderer _numberRenderer;

	// Token: 0x040005B9 RID: 1465
	private int _colorNumber;

	// Token: 0x040005BA RID: 1466
	private bool _isHoldClickOnce;
}
