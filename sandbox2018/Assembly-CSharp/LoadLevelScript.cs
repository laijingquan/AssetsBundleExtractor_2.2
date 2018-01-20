using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000AF RID: 175
public class LoadLevelScript : MonoBehaviour
{
	// Token: 0x06000488 RID: 1160 RVA: 0x00014E5D File Offset: 0x0001325D
	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x00014E69 File Offset: 0x00013269
	public void LoadJoystickEvent()
	{
		SceneManager.LoadScene("Joystick-Event-Input");
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x00014E75 File Offset: 0x00013275
	public void LoadJoysticParameter()
	{
		SceneManager.LoadScene("Joystick-Parameter");
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x00014E81 File Offset: 0x00013281
	public void LoadDPadEvent()
	{
		SceneManager.LoadScene("DPad-Event-Input");
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x00014E8D File Offset: 0x0001328D
	public void LoadDPadClassicalTime()
	{
		SceneManager.LoadScene("DPad-Classical-Time");
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x00014E99 File Offset: 0x00013299
	public void LoadTouchPad()
	{
		SceneManager.LoadScene("TouchPad-Event-Input");
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x00014EA5 File Offset: 0x000132A5
	public void LoadButton()
	{
		SceneManager.LoadScene("Button-Event-Input");
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x00014EB1 File Offset: 0x000132B1
	public void LoadFPS()
	{
		SceneManager.LoadScene("FPS_Example");
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x00014EBD File Offset: 0x000132BD
	public void LoadThird()
	{
		SceneManager.LoadScene("ThirdPerson+Jump");
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x00014EC9 File Offset: 0x000132C9
	public void LoadThirddungeon()
	{
		SceneManager.LoadScene("ThirdPersonDungeon+Jump");
	}
}
