using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000170 RID: 368
public class GameUIManager : MonoBehaviour
{
	// Token: 0x0600099A RID: 2458 RVA: 0x00029599 File Offset: 0x00027999
	public void Load()
	{
		if (!this._isLoad)
		{
			this._isLoad = true;
			this._GameUICanvas = GameObject.Find("GameUICanvas/");
			this.InitGamePanel();
			this.InitOverPanel();
			this._isUpdateBtn = false;
		}
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x000295D0 File Offset: 0x000279D0
	private void InitGamePanel()
	{
		string text = "Prefabs/UI/UIGamePanel";
		if (ComibilityHelper.IsWideScreen())
		{
			text += "Widescreen";
		}
		this._gamePanel = ResourceHelper.LoadUI(text, this._GameUICanvas.transform).gameObject;
		this._gamePanel.SetActive(true);
		this._gamePanel.GetComponent<RectTransform>().offsetMin = Vector2.zero;
		this._gamePanel.GetComponent<RectTransform>().offsetMax = Vector2.zero;
		this.InitTop();
		this._loading = this._gamePanel.transform.Find("Loading");
		this._isLoading = false;
	}

	// Token: 0x0600099C RID: 2460 RVA: 0x00029673 File Offset: 0x00027A73
	public void SetGamePanelActive(bool b)
	{
		this._gamePanel.SetActive(b);
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x00029684 File Offset: 0x00027A84
	private void InitColorData(string TID)
	{
		this._listColor.Clear();
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		DataTiles dataTiles;
		dicDataTiles.TryGetValue(TID, out dataTiles);
		Dictionary<int, DataTiles.ColorTile> colorRank = dataTiles.colorRank;
		int count = colorRank.Count;
		for (int i = 1; i <= count; i++)
		{
			this._listColor.Add(colorRank[i].trueColor);
		}
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x000296F4 File Offset: 0x00027AF4
	public void RefershDrawPen(string TID)
	{
		this.InitColorData(TID);
		bool flag = PlayerManager.Instance.IsShowBanner();
		Transform transform = this._gamePanel.transform.Find("Bottom");
		Transform transform2 = this._gamePanel.transform.Find("Bottom_Banner");
		Transform transform3;
		Transform transform4;
		if (flag)
		{
			transform.gameObject.SetActive(false);
			transform2.gameObject.SetActive(true);
			this._bottomScrollView = transform2.Find("BottomScrollView");
			this._grid = this._bottomScrollView.Find("Viewport/Grid");
			transform3 = transform2.Find("EraserButton");
			transform4 = transform2.Find("BottomBarBg");
		}
		else
		{
			transform.gameObject.SetActive(true);
			transform2.gameObject.SetActive(false);
			this._bottomScrollView = transform.Find("BottomScrollView");
			this._grid = this._bottomScrollView.Find("Viewport/Grid");
			transform3 = transform.Find("EraserButton");
			transform4 = transform.Find("BottomBarBg");
		}
		ColorButtonPoolManager.Instance.Reset();
		this._listButton.Clear();
		UIColorCellButton component = transform3.GetComponent<UIColorCellButton>();
		component.Init(0, Color.white);
		this._listButton.Add(component);
		for (int i = 0; i < this._listColor.Count; i++)
		{
			UIColorCellButton item = this.AddColorButton(i + 1, this._listColor[i]);
			this._listButton.Add(item);
		}
		Button component2 = transform4.GetComponent<Button>();
		component2.onClick.AddListener(delegate
		{
			this.OnBottomBarBgButtonClick(base.gameObject);
		});
		this.selectedPenColor = 1;
		this.SetUIButtonSelected(this.selectedPenColor);
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x000298AC File Offset: 0x00027CAC
	public void SetColorFinishUpdate(bool b)
	{
		foreach (UIColorCellButton uicolorCellButton in this._listButton)
		{
			uicolorCellButton.SetUpdateFinish(b);
		}
		this._isUpdateBtn = b;
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x00029910 File Offset: 0x00027D10
	private void OnBottomBarBgButtonClick(GameObject go)
	{
		GameManager.Instance.gameTouchLayer.SetDragEnabled(true);
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x00029924 File Offset: 0x00027D24
	private UIColorCellButton AddColorButton(int colorIndex, Color c)
	{
		RectTransform component = this._grid.GetComponent<RectTransform>();
		Transform colorButton = ColorButtonPoolManager.Instance.GetColorButton();
		colorButton.SetParent(component);
		colorButton.localScale = Vector3.one;
		UIColorCellButton component2 = colorButton.GetComponent<UIColorCellButton>();
		component2.Init(colorIndex, c);
		return component2;
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x0002996C File Offset: 0x00027D6C
	public void InitTop()
	{
		this._backButton = this._gamePanel.transform.Find("BackButton").GetComponent<Button>();
		this._backButton.onClick.AddListener(delegate
		{
			this.OnBackClick(this._backButton.gameObject);
		});
		this._finishButton = this._gamePanel.transform.Find("FinishButton").GetComponent<Button>();
		this._finishButton.onClick.AddListener(delegate
		{
			this.OnFinishClick(this._finishButton.gameObject);
		});
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x000299F4 File Offset: 0x00027DF4
	private void OnBackClick(GameObject go)
	{
		bool flag = GameManager.Instance.levelDataManager.IsAllFinish();
		bool flag2 = PlayerManager.Instance.IsCanShowRate();
		if (flag && flag2)
		{
			long currentRealTimestamp = TimeHelper.GetCurrentRealTimestamp();
			PlayerManager.Instance.SetLastRateTime(currentRealTimestamp);
			MainUIManager.Instance.ShowRatePanel(new Action(this.OnGameBack));
		}
		else
		{
			this.OnGameBack();
		}
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x00029A5A File Offset: 0x00027E5A
	private void OnGameBack()
	{
		base.StartCoroutine(this.GameBack());
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x00029A6C File Offset: 0x00027E6C
	private IEnumerator GameBack()
	{
		yield return null;
		GameManager.Instance.levelManager.MinZoom();
		yield return new WaitForEndOfFrame();
		string TID = SceneGameManager.Instance.CurrentTID;
		Texture2D texture = CaptureScreenHelper.CaptureCamera(TID);
		ImagePoolManager.Instance.UpdateSprite(TID, texture);
		yield return null;
		PlayerManager.Instance.SaveLevelData(TID);
		PlayerManager.Instance.SetFillColor(TID, GameManager.Instance.levelDataManager.tileFillColorList);
		SceneGameManager.Instance.SwitchPanel(SceneGameManager.SCENEPANEL.MENU);
		yield break;
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x00029A80 File Offset: 0x00027E80
	public void SetLoading(bool b)
	{
		this._loading.gameObject.SetActive(b);
		this._isLoading = b;
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x00029A9A File Offset: 0x00027E9A
	private void OnFinishClick(GameObject go)
	{
		this.OnGameFinish();
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x00029AA2 File Offset: 0x00027EA2
	private void OnGameFinish()
	{
		base.StartCoroutine(this.FinishBack());
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x00029AB4 File Offset: 0x00027EB4
	private IEnumerator FinishBack()
	{
		this._gamePanel.SetActive(false);
		this._overPanel.SetActive(true);
		GameManager.Instance.levelManager.MinZoom();
		yield return new WaitForEndOfFrame();
		string TID = SceneGameManager.Instance.CurrentTID;
		Texture2D texture = CaptureScreenHelper.CaptureCamera(TID);
		ImagePoolManager.Instance.UpdateSprite(TID, texture);
		yield return null;
		PlayerManager.Instance.SaveLevelData(TID);
		PlayerManager.Instance.SetFillColor(TID, GameManager.Instance.levelDataManager.tileFillColorList);
		base.StartCoroutine(this.OnFinishDelay());
		yield break;
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x00029AD0 File Offset: 0x00027ED0
	private IEnumerator OnFinishDelay()
	{
		yield return null;
		GameManager.Instance.gameTilesLayer.SetVisible(false);
		GameManager.Instance.gameReplayLayer.SetVisible(true);
		GameManager.Instance.gameReplayLayer.Replay();
		yield break;
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x00029AE4 File Offset: 0x00027EE4
	public void SetTopButtonVisible(bool isVisible)
	{
		this._backButton.gameObject.SetActive(isVisible);
		this._finishButton.gameObject.SetActive(isVisible);
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x00029B08 File Offset: 0x00027F08
	public void SetUIButtonSelected(int index)
	{
		for (int i = 0; i < this._listButton.Count; i++)
		{
			this._listButton[i].SetSelectedVisible(false);
			if (index == i)
			{
				this._listButton[i].SetSelectedVisible(true);
			}
		}
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x00029B5C File Offset: 0x00027F5C
	public Color GetCurrentPenColor()
	{
		return this._listColor[this.selectedPenColor - 1];
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x00029B71 File Offset: 0x00027F71
	public Color GetPenColor(int index)
	{
		return this._listColor[index - 1];
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x00029B84 File Offset: 0x00027F84
	private bool IsShowTopButton()
	{
		float curPicureScale = GameManager.Instance.levelManager.curPicureScale;
		float pictureMinScale = GameManager.Instance.levelManager.pictureMinScale;
		return curPicureScale >= pictureMinScale - 0.001f && curPicureScale <= 1.3f * pictureMinScale;
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x00029BD0 File Offset: 0x00027FD0
	private void UpdateTopButtonVisible()
	{
		if (this.IsShowTopButton())
		{
			this._backButton.gameObject.SetActive(true);
			this._finishButton.gameObject.SetActive(true);
		}
		else
		{
			this._backButton.gameObject.SetActive(false);
			this._finishButton.gameObject.SetActive(false);
		}
		if (GameManager.Instance.levelDataManager.IsAllFinish())
		{
			this._finishButton.gameObject.SetActive(true);
			string currentTID = SceneGameManager.Instance.CurrentTID;
			PlayerManager.Instance.SetOnePictureFinish(currentTID, true);
		}
		else
		{
			string currentTID2 = SceneGameManager.Instance.CurrentTID;
			PlayerManager.Instance.SetOnePictureFinish(currentTID2, false);
		}
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x00029C8C File Offset: 0x0002808C
	private void Update()
	{
		if (this._isLoading)
		{
			this._loading.Find("Image").transform.Rotate(new Vector3(0f, 0f, -1f), 2.5f);
		}
		if (this._isUpdateBtn)
		{
			this.UpdateTopButtonVisible();
		}
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x00029CE8 File Offset: 0x000280E8
	private void InitOverPanel()
	{
		string text = "Prefabs/UI/UIOverPanel";
		if (ComibilityHelper.IsWideScreen())
		{
			text += "Widescreen";
		}
		this._overPanel = ResourceHelper.LoadUI(text, this._GameUICanvas.transform).gameObject;
		this._overPanel.SetActive(false);
		this._overPanel.GetComponent<RectTransform>().offsetMin = Vector2.zero;
		this._overPanel.GetComponent<RectTransform>().offsetMax = Vector2.zero;
		Button component = this._overPanel.transform.Find("BackButton").GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			this.OnOverBackClick(this._backButton.gameObject);
		});
		Button component2 = this._overPanel.transform.Find("ShareButton").GetComponent<Button>();
		component2.onClick.AddListener(delegate
		{
			this.OnShareClick(this._backButton.gameObject);
		});
		Button component3 = this._overPanel.transform.Find("SaveButton").GetComponent<Button>();
		component3.onClick.AddListener(delegate
		{
			this.OnSaveClick(this._backButton.gameObject);
		});
		Button component4 = this._overPanel.transform.Find("InsButton").GetComponent<Button>();
		component4.onClick.AddListener(delegate
		{
			this.OnInsClick(this._backButton.gameObject);
		});
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x00029E30 File Offset: 0x00028230
	private void OnShareClick(GameObject go)
	{
		Debug.Log("OnShareClick");
		GameManager.Instance.gameReplayLayer.StopPlay();
		GameManager.Instance.gameTilesLayer.SetVisible(true);
		GameManager.Instance.gameReplayLayer.SetVisible(false);
		string currentTID = SceneGameManager.Instance.CurrentTID;
		SDKManager.Instance.UniShare(currentTID);
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x00029E8C File Offset: 0x0002828C
	private void OnSaveClick(GameObject go)
	{
		Debug.Log("OnSaveClick");
		GameManager.Instance.gameReplayLayer.StopPlay();
		GameManager.Instance.gameTilesLayer.SetVisible(true);
		GameManager.Instance.gameReplayLayer.SetVisible(false);
		string currentTID = SceneGameManager.Instance.CurrentTID;
		SDKManager.Instance.SaveToGallery(currentTID);
		this.ShowSaveSuccess();
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x00029EF0 File Offset: 0x000282F0
	private void ShowSaveSuccess()
	{
		GameObject gameObject = ResourceHelper.Load("Prefabs/UI/UISaveTipsPanel");
		gameObject.transform.SetParent(this._GameUICanvas.transform);
		TransformHelper.TransformReset(gameObject.transform);
		UISaveTipsPanel component = gameObject.GetComponent<UISaveTipsPanel>();
		component.Init();
	}

	// Token: 0x060009B6 RID: 2486 RVA: 0x00029F38 File Offset: 0x00028338
	private void OnInsClick(GameObject go)
	{
		string currentTID = SceneGameManager.Instance.CurrentTID;
		SDKManager.Instance.ShareInsgram(currentTID);
		GameManager.Instance.gameReplayLayer.StopPlay();
		GameManager.Instance.gameTilesLayer.SetVisible(true);
		GameManager.Instance.gameReplayLayer.SetVisible(false);
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x00029F8C File Offset: 0x0002838C
	private void OnOverBackClick(GameObject go)
	{
		Debug.Log("OnOverBackClick");
		this._overPanel.SetActive(false);
		this._gamePanel.SetActive(true);
		bool flag = GameManager.Instance.levelDataManager.IsAllFinish();
		if (flag)
		{
			bool flag2 = PlayerManager.Instance.IsCanShowRate();
			if (flag2)
			{
				long currentRealTimestamp = TimeHelper.GetCurrentRealTimestamp();
				PlayerManager.Instance.SetLastRateTime(currentRealTimestamp);
				MainUIManager.Instance.ShowRatePanel(new Action(this.OnOverFinishCallback));
			}
			else
			{
				this.OnOverFinishCallback();
			}
		}
		else
		{
			GameManager.Instance.gameTilesLayer.SetVisible(true);
			GameManager.Instance.gameReplayLayer.SetVisible(false);
			this._overPanel.SetActive(false);
			this._gamePanel.SetActive(true);
		}
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x0002A051 File Offset: 0x00028451
	private void OnOverFinishCallback()
	{
		this._overPanel.SetActive(false);
		this._gamePanel.SetActive(true);
		SceneGameManager.Instance.SwitchPanel(SceneGameManager.SCENEPANEL.MENU);
	}

	// Token: 0x170000AB RID: 171
	// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0002A078 File Offset: 0x00028478
	public static GameUIManager Instance
	{
		get
		{
			if (GameUIManager._instance == null)
			{
				GameObject gameObject = new GameObject("GameUIManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				GameUIManager._instance = gameObject.AddComponent<GameUIManager>();
			}
			return GameUIManager._instance;
		}
	}

	// Token: 0x040005D2 RID: 1490
	private const string UI_GAME_PANEL = "Prefabs/UI/UIGamePanel";

	// Token: 0x040005D3 RID: 1491
	private const string UI_OVER_PANEL = "Prefabs/UI/UIOverPanel";

	// Token: 0x040005D4 RID: 1492
	public int selectedPenColor;

	// Token: 0x040005D5 RID: 1493
	private GameObject _GameUICanvas;

	// Token: 0x040005D6 RID: 1494
	private GameObject _gamePanel;

	// Token: 0x040005D7 RID: 1495
	private GameObject _overPanel;

	// Token: 0x040005D8 RID: 1496
	private Transform _bottomScrollView;

	// Token: 0x040005D9 RID: 1497
	private Transform _grid;

	// Token: 0x040005DA RID: 1498
	private List<UIColorCellButton> _listButton = new List<UIColorCellButton>();

	// Token: 0x040005DB RID: 1499
	private List<Color> _listColor = new List<Color>();

	// Token: 0x040005DC RID: 1500
	private Button _backButton;

	// Token: 0x040005DD RID: 1501
	private Button _finishButton;

	// Token: 0x040005DE RID: 1502
	private Transform _loading;

	// Token: 0x040005DF RID: 1503
	private bool _isLoading;

	// Token: 0x040005E0 RID: 1504
	private bool _isUpdateBtn;

	// Token: 0x040005E1 RID: 1505
	private bool _isLoad;

	// Token: 0x040005E2 RID: 1506
	private static GameUIManager _instance;

	// Token: 0x02000171 RID: 369
	public enum PixelUIPanel
	{
		// Token: 0x040005E4 RID: 1508
		MAIN_UI_PANEL,
		// Token: 0x040005E5 RID: 1509
		GAME_UI_PANEL,
		// Token: 0x040005E6 RID: 1510
		OVER_UI_PANEL
	}
}
