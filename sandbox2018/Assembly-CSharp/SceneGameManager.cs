using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200014A RID: 330
public class SceneGameManager : MonoBehaviour
{
	// Token: 0x06000850 RID: 2128 RVA: 0x00023408 File Offset: 0x00021808
	public void SwitchPanel(SceneGameManager.SCENEPANEL panel)
	{
		this.ScenePanel = panel;
		if (panel != SceneGameManager.SCENEPANEL.MENU)
		{
			if (panel == SceneGameManager.SCENEPANEL.GMAE)
			{
				MainUIManager.Instance.SetMenuPanelVisible(false);
				GameUIManager.Instance.SetGamePanelActive(true);
				bool flag = PlayerManager.Instance.IsShowBanner();
				if (flag)
				{
					AppConfig.GAME_BOTTOM_BOUNDARY_OFFSET = 0.15625f;
				}
				else
				{
					AppConfig.GAME_BOTTOM_BOUNDARY_OFFSET = 0.078125f;
				}
				if (flag)
				{
					GoogleAdmobBanner.Instance.ShowBanner();
				}
				GameManager.Instance.gameTilesLayer.SetVisible(true);
				ColorButtonPoolManager.Instance.SetActive(true);
				GameManager.Instance.tileManager.ResetAllTile();
				NumberPoolManager.Instance.Reset();
				GameManager.Instance.tileGridManager.Reset();
				GameManager.Instance.StartLevel(this.CurrentTID);
				if (!PlayerManager.Instance.GetVip() && !PlayerManager.Instance.GetLifeVip())
				{
					base.StartCoroutine(this.ShowInterstitial());
				}
			}
		}
		else
		{
			MainUIManager.Instance.SetMenuPanelVisible(true);
			GoogleAdmobBanner.Instance.HideBanner();
			GameUIManager.Instance.SetColorFinishUpdate(false);
			ColorButtonPoolManager.Instance.SetActive(false);
			GameManager.Instance.gameTilesLayer.SetVisible(false);
			GameUIManager.Instance.SetGamePanelActive(false);
			if (this.CurrentTID.CompareTo(string.Empty) != 0)
			{
				if (this.ThumbCellSmall != null)
				{
					this.ThumbCellSmall.RefershImage(this.CurrentTID, this.ThumbCellSmallIndex);
				}
				else if (this.ThumbCellBig != null)
				{
					this.ThumbCellBig.RefershImage(this.CurrentTID);
				}
			}
			Resources.UnloadUnusedAssets();
		}
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x000235BC File Offset: 0x000219BC
	private IEnumerator ShowInterstitial()
	{
		yield return new WaitForEndOfFrame();
		GoogleAdmobInterstitial.Instance.ShowInterstitial();
		yield break;
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x000235D0 File Offset: 0x000219D0
	public void SwitchScene(string name)
	{
		base.StartCoroutine(this.AsyncLoadScene(name));
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x000235E0 File Offset: 0x000219E0
	private IEnumerator AsyncLoadScene(string name)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(name);
		yield return async;
		yield break;
	}

	// Token: 0x1700008F RID: 143
	// (get) Token: 0x06000854 RID: 2132 RVA: 0x000235FC File Offset: 0x000219FC
	public static SceneGameManager Instance
	{
		get
		{
			if (SceneGameManager._instance == null)
			{
				GameObject gameObject = new GameObject("SceneGameManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				SceneGameManager._instance = gameObject.AddComponent<SceneGameManager>();
			}
			return SceneGameManager._instance;
		}
	}

	// Token: 0x04000527 RID: 1319
	public string CurrentTID = string.Empty;

	// Token: 0x04000528 RID: 1320
	public UIThumbCellBig ThumbCellBig;

	// Token: 0x04000529 RID: 1321
	public UIThumbCellSmall ThumbCellSmall;

	// Token: 0x0400052A RID: 1322
	public int ThumbCellSmallIndex;

	// Token: 0x0400052B RID: 1323
	public SceneGameManager.SCENEPANEL ScenePanel;

	// Token: 0x0400052C RID: 1324
	private static SceneGameManager _instance;

	// Token: 0x0200014B RID: 331
	public enum SCENEPANEL
	{
		// Token: 0x0400052E RID: 1326
		MENU,
		// Token: 0x0400052F RID: 1327
		GMAE
	}
}
