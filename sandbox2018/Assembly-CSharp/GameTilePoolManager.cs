using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000151 RID: 337
public class GameTilePoolManager : MonoBehaviour
{
	// Token: 0x06000897 RID: 2199 RVA: 0x00024FD4 File Offset: 0x000233D4
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

	// Token: 0x06000898 RID: 2200 RVA: 0x00025024 File Offset: 0x00023424
	public void Reset()
	{
		this._index = 0;
		for (int i = 0; i < this._maxCount; i++)
		{
			this._tiles[i].transform.localPosition = new Vector2(10000f, 10000f);
			this._tiles[i].transform.localScale = Vector2.one;
		}
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x0002509C File Offset: 0x0002349C
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

	// Token: 0x0600089A RID: 2202 RVA: 0x00025118 File Offset: 0x00023518
	private void InitTile()
	{
		Transform transform = ResourceHelper.Load(GameTilePoolManager.TILE_PATH).transform;
		transform.SetParent(base.transform);
		transform.transform.localPosition = new Vector2(10000f, 10000f);
		transform.transform.localScale = Vector2.one;
		this._tiles.Add(transform);
	}

	// Token: 0x1700009A RID: 154
	// (get) Token: 0x0600089B RID: 2203 RVA: 0x00025184 File Offset: 0x00023584
	public static GameTilePoolManager Instance
	{
		get
		{
			if (GameTilePoolManager._instance == null)
			{
				GameObject gameObject = new GameObject("GameTilePoolManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				GameTilePoolManager._instance = gameObject.AddComponent<GameTilePoolManager>();
			}
			return GameTilePoolManager._instance;
		}
	}

	// Token: 0x0400054F RID: 1359
	private static string TILE_PATH = "Prefabs/Tile";

	// Token: 0x04000550 RID: 1360
	private int ADD_COUNT = 225;

	// Token: 0x04000551 RID: 1361
	private int MAX_COUNT = 3600;

	// Token: 0x04000552 RID: 1362
	private int _index;

	// Token: 0x04000553 RID: 1363
	private int _maxCount;

	// Token: 0x04000554 RID: 1364
	private bool _isLoad;

	// Token: 0x04000555 RID: 1365
	private List<Transform> _tiles = new List<Transform>();

	// Token: 0x04000556 RID: 1366
	private static GameTilePoolManager _instance;
}
