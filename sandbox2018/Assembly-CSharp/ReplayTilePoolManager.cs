using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000155 RID: 341
public class ReplayTilePoolManager : MonoBehaviour
{
	// Token: 0x060008AD RID: 2221 RVA: 0x0002567C File Offset: 0x00023A7C
	public void Reset()
	{
		this._index = 0;
		for (int i = 0; i < this._maxCount; i++)
		{
			this._tiles[i].transform.localPosition = new Vector2(10000f, 10000f);
			this._tiles[i].transform.localScale = Vector2.one;
		}
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x000256F4 File Offset: 0x00023AF4
	public Transform GetTiles()
	{
		if (this._index >= this._maxCount)
		{
			int add_COUNT = this.ADD_COUNT;
			for (int i = 0; i < add_COUNT; i++)
			{
				this.InitTile();
			}
			this._maxCount += add_COUNT;
		}
		Transform transform = this._tiles[this._index];
		this._index++;
		transform.localScale = Vector2.one;
		return transform;
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x00025770 File Offset: 0x00023B70
	public void Load()
	{
		if (!this._isLoad)
		{
			this._isLoad = true;
			this._maxCount = this.MAX_COUNT;
			this._index = 0;
			for (int i = 0; i < this._maxCount; i++)
			{
				this.InitTile();
			}
		}
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x000257C0 File Offset: 0x00023BC0
	private void InitTile()
	{
		Transform transform = ResourceHelper.Load(ReplayTilePoolManager.TILE_PATH).transform;
		transform.SetParent(base.transform);
		transform.transform.localPosition = new Vector2(10000f, 10000f);
		transform.transform.localScale = Vector2.one;
		this._tiles.Add(transform);
	}

	// Token: 0x1700009D RID: 157
	// (get) Token: 0x060008B1 RID: 2225 RVA: 0x0002582C File Offset: 0x00023C2C
	public static ReplayTilePoolManager Instance
	{
		get
		{
			if (ReplayTilePoolManager._instance == null)
			{
				GameObject gameObject = new GameObject("ReplayTilePoolManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				ReplayTilePoolManager._instance = gameObject.AddComponent<ReplayTilePoolManager>();
			}
			return ReplayTilePoolManager._instance;
		}
	}

	// Token: 0x04000563 RID: 1379
	private static string TILE_PATH = "Prefabs/TileReplay";

	// Token: 0x04000564 RID: 1380
	private int ADD_COUNT = 225;

	// Token: 0x04000565 RID: 1381
	private int MAX_COUNT = 3600;

	// Token: 0x04000566 RID: 1382
	private int _index;

	// Token: 0x04000567 RID: 1383
	private int _maxCount;

	// Token: 0x04000568 RID: 1384
	private bool _isLoad;

	// Token: 0x04000569 RID: 1385
	private List<Transform> _tiles = new List<Transform>();

	// Token: 0x0400056A RID: 1386
	private static ReplayTilePoolManager _instance;
}
