using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000169 RID: 361
public class TileManager : MonoBehaviour
{
	// Token: 0x170000AA RID: 170
	// (get) Token: 0x06000958 RID: 2392 RVA: 0x000284C7 File Offset: 0x000268C7
	public Dictionary<string, Tile> dicGameTiles
	{
		get
		{
			return this._dicGameTiles;
		}
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x000284D0 File Offset: 0x000268D0
	public void Init(string TID)
	{
		this._TID = TID;
		this._dicGameTiles.Clear();
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		dicDataTiles.TryGetValue(TID, out this._dataTiles);
		if (this._dataTiles != null)
		{
			this.TrimTiles();
			this.LoadTiles();
			this.LoadFinish();
		}
		else
		{
			Debug.Log("Load DataTiles " + TID + " error");
		}
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x00028544 File Offset: 0x00026944
	public int GetCanvasLength()
	{
		if (this._dataTiles != null)
		{
			return this._dataTiles.canvasLength;
		}
		return 0;
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x0002855E File Offset: 0x0002695E
	private void TrimTiles()
	{
		GameManager.Instance.levelManager.Init(this._dataTiles);
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x00028578 File Offset: 0x00026978
	private void LoadTiles()
	{
		bool flag = false;
		Dictionary<string, DataTiles.DataTile> levelData = PlayerManager.Instance.GetLevelData(this._TID);
		if (levelData.Values.Count > 0)
		{
			flag = true;
		}
		if (this._dataTiles != null)
		{
			Dictionary<string, DataTiles.DataTile> dataTileDic = this._dataTiles.dataTileDic;
			for (int i = 0; i < this._dataTiles.canvasLength; i++)
			{
				for (int j = 0; j < this._dataTiles.canvasLength; j++)
				{
					string key = i + "_" + j;
					DataTiles.DataTile dataTile;
					dataTileDic.TryGetValue(key, out dataTile);
					if (dataTile == null)
					{
						dataTile = new DataTiles.DataTile();
						dataTile.indexX = i;
						dataTile.indexY = j;
						dataTile.isValid = false;
					}
					DataTiles.DataTile dataTile2;
					if (flag && levelData.TryGetValue(key, out dataTile2))
					{
						dataTile.isTouchRight = dataTile2.isTouchRight;
						dataTile.isTouchWrong = dataTile2.isTouchWrong;
						dataTile.wrongColorIndex = dataTile2.wrongColorIndex;
						dataTile.isTouched = dataTile2.isTouched;
					}
					this.GenTile(dataTile);
				}
			}
		}
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x0002869E File Offset: 0x00026A9E
	private Transform GetByPoolManager()
	{
		return GameTilePoolManager.Instance.GetTiles();
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x000286AC File Offset: 0x00026AAC
	private void GenTile(DataTiles.DataTile dataTile)
	{
		Transform byPoolManager = this.GetByPoolManager();
		byPoolManager.transform.SetParent(GameManager.Instance.gameTilesLayer.transform);
		Tile component = byPoolManager.GetComponent<Tile>();
		component.Init(ref dataTile);
		string key = dataTile.indexX + "_" + dataTile.indexY;
		this._dicGameTiles.Add(key, component);
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x00028718 File Offset: 0x00026B18
	private void LoadFinish()
	{
		float pictureMinScale = GameManager.Instance.levelManager.pictureMinScale;
		float num = GameManager.Instance.cameraController.cameraSizeWidthHalf;
		num /= pictureMinScale;
		num -= 0.5f * AppConfig.GRID_UNIT_LENGTH;
		foreach (Tile tile in this._dicGameTiles.Values)
		{
			tile.transform.position -= new Vector3(num, num, 0f);
		}
		GameManager.Instance.gameTilesLayer.LayerScale(pictureMinScale);
		GameManager.Instance.tileGridManager.Draw();
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x000287E8 File Offset: 0x00026BE8
	public void TileClick(Vector2 screenPos, bool bClickOrHold)
	{
		Vector2 vector = Camera.main.ScreenToWorldPoint(screenPos);
		float curPicureScale = GameManager.Instance.levelManager.curPicureScale;
		float picNormalUnitGridLength = GameManager.Instance.levelManager.picNormalUnitGridLength;
		vector.x -= GameManager.Instance.levelManager.curPictureMove.x;
		vector.y -= GameManager.Instance.levelManager.curPictureMove.y;
		int num = Mathf.FloorToInt((vector.x / curPicureScale + picNormalUnitGridLength * 0.5f) / AppConfig.GRID_UNIT_LENGTH);
		int num2 = Mathf.FloorToInt((vector.y / curPicureScale + picNormalUnitGridLength * 0.5f) / AppConfig.GRID_UNIT_LENGTH);
		string key = num + "_" + num2;
		Tile tile;
		this._dicGameTiles.TryGetValue(key, out tile);
		if (tile != null)
		{
			tile.TileClick(bClickOrHold);
		}
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x000288E8 File Offset: 0x00026CE8
	public void TileHoldOnceClickReset()
	{
		foreach (Tile tile in this._dicGameTiles.Values)
		{
			tile.isHoldClickOnce = false;
		}
	}

	// Token: 0x06000962 RID: 2402 RVA: 0x0002894C File Offset: 0x00026D4C
	public void SetMainAlpha(float setAlpha)
	{
		foreach (Tile tile in this._dicGameTiles.Values)
		{
			tile.SetMainAlpha(setAlpha);
		}
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x000289B0 File Offset: 0x00026DB0
	public void SetNumberAlpha(float setAlpha)
	{
		foreach (Tile tile in this._dicGameTiles.Values)
		{
			tile.SetNumberAlpha(setAlpha);
		}
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x00028A14 File Offset: 0x00026E14
	public void SetHighLight(int selectedNumber)
	{
		float grid_opacity = DataManager.Instance.dataConfig.grid_opacity;
		Color hightLight = new Color(1f, 1f, 1f, 0f);
		Color grid_selectColor = DataManager.Instance.dataConfig.grid_selectColor;
		grid_selectColor.a = grid_opacity;
		foreach (Tile tile in this._dicGameTiles.Values)
		{
			int colorNumber = tile.colorNumber;
			if (colorNumber == selectedNumber)
			{
				tile.SetHightLight(grid_selectColor);
			}
			else
			{
				tile.SetHightLight(hightLight);
			}
		}
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x00028AD8 File Offset: 0x00026ED8
	public void SetHighLightAlpha(float alpha)
	{
		foreach (Tile tile in this._dicGameTiles.Values)
		{
			tile.SetHighLightAlpha(alpha);
		}
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x00028B3C File Offset: 0x00026F3C
	public void DeleteAllTiles()
	{
		foreach (Tile tile in this._dicGameTiles.Values)
		{
			UnityEngine.Object.DestroyImmediate(tile.gameObject);
		}
		this._dicGameTiles.Clear();
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x00028BAC File Offset: 0x00026FAC
	public void ResetAllTile()
	{
		foreach (Tile tile in this._dicGameTiles.Values)
		{
			tile.Reset();
		}
		this._dicGameTiles.Clear();
		GameTilePoolManager.Instance.Reset();
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x00028C24 File Offset: 0x00027024
	private void Awake()
	{
	}

	// Token: 0x06000969 RID: 2409 RVA: 0x00028C26 File Offset: 0x00027026
	private void Start()
	{
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x00028C28 File Offset: 0x00027028
	private void Update()
	{
	}

	// Token: 0x040005C3 RID: 1475
	private DataTiles _dataTiles;

	// Token: 0x040005C4 RID: 1476
	private Dictionary<string, Tile> _dicGameTiles = new Dictionary<string, Tile>();

	// Token: 0x040005C5 RID: 1477
	private string _TID;
}
