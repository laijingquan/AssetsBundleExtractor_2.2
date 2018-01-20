using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000020 RID: 32
public class CaptureAndSaveCamera : MonoBehaviour
{
	// Token: 0x0600013E RID: 318 RVA: 0x00006B06 File Offset: 0x00004F06
	private void Start()
	{
		this.snapShot = UnityEngine.Object.FindObjectOfType<CaptureAndSave>();
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00006B13 File Offset: 0x00004F13
	private void OnEnable()
	{
		CaptureAndSaveEventListener.onError += this.OnError;
		CaptureAndSaveEventListener.onSuccess += this.OnSuccess;
	}

	// Token: 0x06000140 RID: 320 RVA: 0x00006B37 File Offset: 0x00004F37
	private void OnDisable()
	{
		CaptureAndSaveEventListener.onError += this.OnError;
		CaptureAndSaveEventListener.onSuccess += this.OnSuccess;
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00006B5B File Offset: 0x00004F5B
	private void OnError(string error)
	{
		this.log = this.log + "\n" + error;
		Debug.Log("Error : " + error);
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00006B84 File Offset: 0x00004F84
	private void OnSuccess(string msg)
	{
		this.log = this.log + "\n" + msg;
		Debug.Log("Success : " + msg);
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00006BB0 File Offset: 0x00004FB0
	private void OnGUI()
	{
		GUILayout.Label(this.log, new GUILayoutOption[0]);
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 210), (float)(Screen.height - 120), 200f, 120f), "Save in double resolution"))
		{
			this.snapShot.CaptureAndSaveToAlbum(Screen.width * 2, Screen.height * 2, Camera.main, ImageType.JPG);
		}
		if (GUI.Button(new Rect((float)(Screen.width / 2 + 30), (float)(Screen.height - 120), 200f, 120f), "Save with watermark"))
		{
			this.snapShot.CaptureAndSaveToAlbum(Screen.width, Screen.height, Camera.main, ImageType.JPG, this.watermark, WatermarkAlignment.BOTTOM_RIGHT);
		}
		if (GUI.Button(new Rect((float)(Screen.width - 120), 10f, 100f, 40f), "Next"))
		{
			SceneManager.LoadScene(1);
		}
	}

	// Token: 0x04000084 RID: 132
	public Texture2D watermark;

	// Token: 0x04000085 RID: 133
	private CaptureAndSave snapShot;

	// Token: 0x04000086 RID: 134
	private string log = "Log:\n";
}
