using System;
using UnityEngine;

// Token: 0x02000146 RID: 326
public class GameInit : MonoBehaviour
{
	// Token: 0x06000837 RID: 2103 RVA: 0x00023038 File Offset: 0x00021438
	private void Awake()
	{
		LanguageManager.Instance.Init();
		SDKManager.Instance.Init();
		DataManager.Instance.LoadData();
		DailyManager.Instance.Load();
		PlayerManager.Instance.SetStartGameTime();
		MainUIManager.Instance.Load();
		NumberPoolManager.Instance.Load();
		GameTilePoolManager.Instance.Load();
		GameManager.Instance.Init();
		SceneGameManager.Instance.SwitchPanel(SceneGameManager.SCENEPANEL.MENU);
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x000230AC File Offset: 0x000214AC
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && SceneGameManager.Instance.ScenePanel == SceneGameManager.SCENEPANEL.MENU)
		{
			this.OnGameKeyBack();
		}
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x000230DC File Offset: 0x000214DC
	private void OnGameKeyBack()
	{
		Debug.Log("Game Init 退出游戏");
		PlayerManager.Instance.SaveGameTime();
		Application.Quit();
	}
}
