using System;
using UnityEngine;

// Token: 0x0200016A RID: 362
public class TileReplay : MonoBehaviour
{
	// Token: 0x0600096C RID: 2412 RVA: 0x00028C34 File Offset: 0x00027034
	public void Init(DataTiles.DataTile dataTile)
	{
		this._dataTile = dataTile;
		this._renderer = base.GetComponent<SpriteRenderer>();
		float x = (float)dataTile.indexX * AppConfig.GRID_UNIT_LENGTH;
		float y = (float)dataTile.indexY * AppConfig.GRID_UNIT_LENGTH;
		base.transform.position = new Vector3(x, y, 0f);
		this._renderer.color = this._dataTile.colorTile.greyColor;
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x00028CA2 File Offset: 0x000270A2
	public void SetGrey()
	{
		this._renderer.color = this._dataTile.colorTile.greyColor;
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x00028CC0 File Offset: 0x000270C0
	public void SetColor(Color c, bool isRight)
	{
		if (isRight)
		{
			this._renderer.color = c;
		}
		else
		{
			float grid_opacity = DataManager.Instance.dataConfig.grid_opacity;
			this._renderer.color = ColorHelper.GenColorAlpha(c, grid_opacity);
		}
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x00028D06 File Offset: 0x00027106
	public void Reset()
	{
		base.transform.localPosition = new Vector2(10000f, 10000f);
		base.transform.localScale = Vector2.one;
	}

	// Token: 0x040005C6 RID: 1478
	private SpriteRenderer _renderer;

	// Token: 0x040005C7 RID: 1479
	private DataTiles.DataTile _dataTile;
}
