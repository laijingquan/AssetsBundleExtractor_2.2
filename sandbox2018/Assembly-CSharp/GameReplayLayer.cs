using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000164 RID: 356
public class GameReplayLayer : MonoBehaviour
{
	// Token: 0x170000A6 RID: 166
	// (get) Token: 0x06000928 RID: 2344 RVA: 0x0002738D File Offset: 0x0002578D
	public Dictionary<string, TileReplay> dicReplayTiles
	{
		get
		{
			return this._dicReplayTiles;
		}
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x00027395 File Offset: 0x00025795
	private void Load()
	{
		if (!this._isLoad)
		{
			this._isLoad = true;
			ReplayTilePoolManager.Instance.Load();
		}
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x000273B3 File Offset: 0x000257B3
	private Transform GetByPoolManager()
	{
		return ReplayTilePoolManager.Instance.GetTiles();
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x000273C0 File Offset: 0x000257C0
	public void InitLayer(string TID)
	{
		this.LayerScale(1f);
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		dicDataTiles.TryGetValue(TID, out this._dataTiles);
		if (this._dataTiles != null)
		{
			float pictureMinScale = GameManager.Instance.levelManager.pictureMinScale;
			float num = GameManager.Instance.cameraController.cameraSizeWidthHalf;
			num /= pictureMinScale;
			num -= 0.5f * AppConfig.GRID_UNIT_LENGTH;
			foreach (DataTiles.DataTile dataTile in this._dataTiles.dataTileDic.Values)
			{
				Transform byPoolManager = this.GetByPoolManager();
				byPoolManager.transform.SetParent(GameManager.Instance.gameReplayLayer.transform);
				TileReplay component = byPoolManager.GetComponent<TileReplay>();
				component.Init(dataTile);
				component.transform.position -= new Vector3(num, num, 0f);
				string key = dataTile.indexX + "_" + dataTile.indexY;
				this._dicReplayTiles.Add(key, component);
			}
			this.LayerScale(pictureMinScale);
		}
	}

	// Token: 0x0600092C RID: 2348 RVA: 0x00027518 File Offset: 0x00025918
	private void LayerScale(float scale)
	{
		base.transform.localScale = new Vector3(scale, scale, 1f);
	}

	// Token: 0x0600092D RID: 2349 RVA: 0x00027531 File Offset: 0x00025931
	public void SetVisible(bool isVisible)
	{
		base.gameObject.SetActive(isVisible);
		if (!isVisible)
		{
			this.ResetAllTiles();
		}
	}

	// Token: 0x0600092E RID: 2350 RVA: 0x0002754C File Offset: 0x0002594C
	public void Replay()
	{
		this.Load();
		this._dicReplayTiles.Clear();
		this._listFillColor.Clear();
		string currentTID = SceneGameManager.Instance.CurrentTID;
		this.InitLayer(currentTID);
		this.ResetGreyColor();
		base.StartCoroutine(this.ReplayCoroutine(currentTID));
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x0002759C File Offset: 0x0002599C
	private void ResetGreyColor()
	{
		foreach (TileReplay tileReplay in this._dicReplayTiles.Values)
		{
			tileReplay.SetGrey();
		}
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x000275FC File Offset: 0x000259FC
	private IEnumerator ReplayCoroutine(string TID)
	{
		this._listFillColor = PlayerManager.Instance.GetFillColor(TID);
		int fillCount = this._listFillColor.Count;
		for (int i = 0; i < fillCount; i++)
		{
			if (i % 2 == 0)
			{
				yield return new WaitForSeconds(0.02f);
			}
			PlayerManager.TileFillColor fillColor = this._listFillColor[i];
			string key = fillColor.indexX + "_" + fillColor.indexY;
			TileReplay tileReplay;
			this._dicReplayTiles.TryGetValue(key, out tileReplay);
			if (tileReplay != null)
			{
				Color c = Color.white;
				bool isRight = false;
				if (fillColor.colorIndex > 0)
				{
					DataTiles.ColorTile colorTile;
					this._dataTiles.colorRank.TryGetValue(fillColor.colorIndex, out colorTile);
					if (colorTile != null)
					{
						c = colorTile.trueColor;
					}
				}
				if (fillColor.isTouchRight == 0)
				{
					isRight = true;
				}
				tileReplay.SetColor(c, isRight);
				if (fillColor.isEarser == 0)
				{
					tileReplay.SetGrey();
				}
			}
		}
		yield break;
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x00027620 File Offset: 0x00025A20
	private void ResetAllTiles()
	{
		foreach (TileReplay tileReplay in this._dicReplayTiles.Values)
		{
			tileReplay.Reset();
		}
		this._dicReplayTiles.Clear();
		this._listFillColor.Clear();
		ReplayTilePoolManager.Instance.Reset();
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x000276A0 File Offset: 0x00025AA0
	public void StopPlay()
	{
		base.StopAllCoroutines();
	}

	// Token: 0x040005B1 RID: 1457
	private DataTiles _dataTiles;

	// Token: 0x040005B2 RID: 1458
	private Dictionary<string, TileReplay> _dicReplayTiles = new Dictionary<string, TileReplay>();

	// Token: 0x040005B3 RID: 1459
	private List<PlayerManager.TileFillColor> _listFillColor = new List<PlayerManager.TileFillColor>();

	// Token: 0x040005B4 RID: 1460
	private bool _isLoad;
}
