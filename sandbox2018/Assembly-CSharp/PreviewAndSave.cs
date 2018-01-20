using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000022 RID: 34
public class PreviewAndSave : MonoBehaviour
{
	// Token: 0x0600014C RID: 332 RVA: 0x000071A1 File Offset: 0x000055A1
	private void Start()
	{
		this.snapShot = UnityEngine.Object.FindObjectOfType<CaptureAndSave>();
	}

	// Token: 0x0600014D RID: 333 RVA: 0x000071B0 File Offset: 0x000055B0
	private void OnEnable()
	{
		CaptureAndSaveEventListener.onError += this.OnError;
		CaptureAndSaveEventListener.onSuccess += this.OnSuccess;
		CaptureAndSaveEventListener.onScreenShotInvoker = (CaptureAndSaveEventListener.OnScreenShot)Delegate.Combine(CaptureAndSaveEventListener.onScreenShotInvoker, new CaptureAndSaveEventListener.OnScreenShot(this.OnScreenShot));
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00007200 File Offset: 0x00005600
	private void OnDisable()
	{
		CaptureAndSaveEventListener.onError -= this.OnError;
		CaptureAndSaveEventListener.onSuccess -= this.OnSuccess;
		CaptureAndSaveEventListener.onScreenShotInvoker = (CaptureAndSaveEventListener.OnScreenShot)Delegate.Remove(CaptureAndSaveEventListener.onScreenShotInvoker, new CaptureAndSaveEventListener.OnScreenShot(this.OnScreenShot));
	}

	// Token: 0x0600014F RID: 335 RVA: 0x0000724F File Offset: 0x0000564F
	private void OnError(string error)
	{
		Debug.Log("Error : " + error);
	}

	// Token: 0x06000150 RID: 336 RVA: 0x00007261 File Offset: 0x00005661
	private void OnSuccess(string msg)
	{
		Debug.Log("Success : " + msg);
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00007273 File Offset: 0x00005673
	private void OnScreenShot(Texture2D tex2D)
	{
		this.tex = tex2D;
	}

	// Token: 0x06000152 RID: 338 RVA: 0x0000727C File Offset: 0x0000567C
	private void OnGUI()
	{
		if (GUI.Button(new Rect(0f, 5f, 150f, 50f), "Get Screenshot"))
		{
			this.snapShot.GetFullScreenShot(ImageType.JPG);
		}
		if (this.tex != null && GUI.Button(new Rect(160f, 5f, 150f, 50f), "Save"))
		{
			this.snapShot.SaveTextureToGallery(this.tex, ImageType.JPG);
		}
		if (this.tex != null)
		{
			GUI.Label(new Rect(0f, 60f, (float)Screen.width, (float)Screen.height), this.tex);
		}
		if (GUI.Button(new Rect((float)(Screen.width - 120), 10f, 100f, 40f), "Next"))
		{
			SceneManager.LoadScene(0);
		}
	}

	// Token: 0x0400008F RID: 143
	public Texture2D watermark;

	// Token: 0x04000090 RID: 144
	private Texture2D tex;

	// Token: 0x04000091 RID: 145
	private CaptureAndSave snapShot;
}
