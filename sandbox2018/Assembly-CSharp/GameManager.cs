using System;
using UnityEngine;

// Token: 0x02000148 RID: 328
public class GameManager : MonoBehaviour
{
	// Token: 0x17000084 RID: 132
	// (get) Token: 0x0600083E RID: 2110 RVA: 0x000231BA File Offset: 0x000215BA
	public GameTilesLayer gameTilesLayer
	{
		get
		{
			return this._gameTilesLayer;
		}
	}

	// Token: 0x17000085 RID: 133
	// (get) Token: 0x0600083F RID: 2111 RVA: 0x000231C2 File Offset: 0x000215C2
	public GameTouchLayer gameTouchLayer
	{
		get
		{
			return this._gameTouchLayer;
		}
	}

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x06000840 RID: 2112 RVA: 0x000231CA File Offset: 0x000215CA
	public TileManager tileManager
	{
		get
		{
			return this._tileManager;
		}
	}

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x06000841 RID: 2113 RVA: 0x000231D2 File Offset: 0x000215D2
	public CameraController cameraController
	{
		get
		{
			return this._cameraController;
		}
	}

	// Token: 0x17000088 RID: 136
	// (get) Token: 0x06000842 RID: 2114 RVA: 0x000231DA File Offset: 0x000215DA
	public LevelManager levelManager
	{
		get
		{
			return this._levelManager;
		}
	}

	// Token: 0x17000089 RID: 137
	// (get) Token: 0x06000843 RID: 2115 RVA: 0x000231E2 File Offset: 0x000215E2
	public LevelDataManager levelDataManager
	{
		get
		{
			return this._levelDataManager;
		}
	}

	// Token: 0x1700008A RID: 138
	// (get) Token: 0x06000844 RID: 2116 RVA: 0x000231EA File Offset: 0x000215EA
	public TileGridManager tileGridManager
	{
		get
		{
			return this._tileGridManager;
		}
	}

	// Token: 0x1700008B RID: 139
	// (get) Token: 0x06000845 RID: 2117 RVA: 0x000231F2 File Offset: 0x000215F2
	public GameReplayLayer gameReplayLayer
	{
		get
		{
			return this._gameReplayLayer;
		}
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x000231FA File Offset: 0x000215FA
	private void Update()
	{
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x000231FC File Offset: 0x000215FC
	public void Init()
	{
		if (!this._isInit)
		{
			this._isInit = true;
			this._tileManager = base.gameObject.AddComponent<TileManager>();
			this._levelManager = base.gameObject.AddComponent<LevelManager>();
			this._levelDataManager = base.gameObject.AddComponent<LevelDataManager>();
			GameObject gameObject = GameObject.FindWithTag("MainCamera");
			this._cameraController = gameObject.AddComponent<CameraController>();
			this._cameraController.Init();
			this._tileGridManager = base.gameObject.AddComponent<TileGridManager>();
			this._tileGridManager.Init();
			GameObject gameObject2 = GameObject.Find("GameTouchLayer");
			this._gameTouchLayer = gameObject2.GetComponent<GameTouchLayer>();
			this._gameTouchLayer.Init();
			GameUIManager.Instance.Load();
			GameObject gameObject3 = GameObject.Find("GameReplayLayer");
			this._gameReplayLayer = gameObject3.GetComponent<GameReplayLayer>();
			GameObject gameObject4 = GameObject.Find("GameTilesLayer");
			this._gameTilesLayer = gameObject4.GetComponent<GameTilesLayer>();
			ColorButtonPoolManager.Instance.Load();
		}
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x000232F0 File Offset: 0x000216F0
	public void StartLevel(string TID)
	{
		GameUIManager.Instance.RefershDrawPen(TID);
		this.GameLevelInit(TID);
		GameUIManager.Instance.SetColorFinishUpdate(true);
		GameManager.Instance.gameTilesLayer.SetVisible(true);
		GameManager.Instance.gameReplayLayer.SetVisible(false);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x0002332F File Offset: 0x0002172F
	private void GameLevelInit(string TID)
	{
		this._gameTilesLayer.Init();
		this._tileManager.Init(TID);
		this._levelDataManager.Load(TID);
	}

	// Token: 0x1700008C RID: 140
	// (get) Token: 0x0600084A RID: 2122 RVA: 0x00023354 File Offset: 0x00021754
	public static GameManager Instance
	{
		get
		{
			if (GameManager._instance == null)
			{
				GameObject gameObject = new GameObject("GameManager");
				GameManager._instance = gameObject.AddComponent<GameManager>();
			}
			return GameManager._instance;
		}
	}

	// Token: 0x0400051B RID: 1307
	private GameTilesLayer _gameTilesLayer;

	// Token: 0x0400051C RID: 1308
	private GameTouchLayer _gameTouchLayer;

	// Token: 0x0400051D RID: 1309
	private TileManager _tileManager;

	// Token: 0x0400051E RID: 1310
	private CameraController _cameraController;

	// Token: 0x0400051F RID: 1311
	private LevelManager _levelManager;

	// Token: 0x04000520 RID: 1312
	private LevelDataManager _levelDataManager;

	// Token: 0x04000521 RID: 1313
	private TileGridManager _tileGridManager;

	// Token: 0x04000522 RID: 1314
	private GameReplayLayer _gameReplayLayer;

	// Token: 0x04000523 RID: 1315
	private bool _isInit;

	// Token: 0x04000524 RID: 1316
	private static GameManager _instance;
}
