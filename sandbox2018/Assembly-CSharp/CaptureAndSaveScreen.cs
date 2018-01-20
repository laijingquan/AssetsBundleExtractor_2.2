using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000021 RID: 33
public class CaptureAndSaveScreen : MonoBehaviour
{
	// Token: 0x06000145 RID: 325 RVA: 0x00006CE7 File Offset: 0x000050E7
	private void Start()
	{
		this.snapShot = UnityEngine.Object.FindObjectOfType<CaptureAndSave>();
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00006CF4 File Offset: 0x000050F4
	private void OnEnable()
	{
		CaptureAndSaveEventListener.onError += this.OnError;
		CaptureAndSaveEventListener.onSuccess += this.OnSuccess;
	}

	// Token: 0x06000147 RID: 327 RVA: 0x00006D18 File Offset: 0x00005118
	private void OnDisable()
	{
		CaptureAndSaveEventListener.onError += this.OnError;
		CaptureAndSaveEventListener.onSuccess += this.OnSuccess;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x00006D3C File Offset: 0x0000513C
	private void OnError(string error)
	{
		this.log = this.log + "\n" + error;
		Debug.Log("Error : " + error);
	}

	// Token: 0x06000149 RID: 329 RVA: 0x00006D65 File Offset: 0x00005165
	private void OnSuccess(string msg)
	{
		this.log = this.log + "\n" + msg;
		Debug.Log("Success : " + msg);
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00006D90 File Offset: 0x00005190
	private void OnGUI()
	{
		GUILayout.Label(this.log, new GUILayoutOption[0]);
		if (GUI.Button(new Rect(20f, 20f, 150f, 50f), "Save Full Screen"))
		{
			this.snapShot.CaptureAndSaveToAlbum(ImageType.JPG);
		}
		if (GUI.Button(new Rect(200f, 20f, 170f, 50f), "Save in double resolution"))
		{
			this.snapShot.CaptureAndSaveToAlbum(Screen.width * 2, Screen.height * 2, Camera.main, ImageType.JPG);
		}
		if (GUI.Button(new Rect(380f, 20f, 170f, 50f), "Save with watermark"))
		{
			this.snapShot.CaptureAndSaveToAlbum(Screen.width, Screen.height, Camera.main, ImageType.JPG, this.watermark, WatermarkAlignment.TOP_LEFT);
		}
		GUI.Label(new Rect(20f, 70f, 500f, 20f), "------------------------------------------------------------------------------------------------------------------------------");
		GUI.Label(new Rect(20f, 100f, 50f, 20f), "X : ");
		this.x = GUI.TextField(new Rect(80f, 100f, 50f, 20f), this.x);
		GUI.Label(new Rect(160f, 100f, 50f, 20f), "Y : ");
		this.y = GUI.TextField(new Rect(200f, 100f, 50f, 20f), this.y);
		GUI.Label(new Rect(20f, 130f, 50f, 20f), "Width : ");
		this.width = GUI.TextField(new Rect(80f, 130f, 50f, 20f), this.width);
		GUI.Label(new Rect(150f, 130f, 50f, 20f), "Height : ");
		this.height = GUI.TextField(new Rect(200f, 130f, 50f, 20f), this.height);
		if (GUI.Button(new Rect(20f, 160f, 150f, 50f), "Save Selected Screen") && int.Parse(this.width) > 0 && int.Parse(this.height) > 0)
		{
			this.snapShot.CaptureAndSaveToAlbum(int.Parse(this.x), int.Parse(this.y), int.Parse(this.width), int.Parse(this.height), ImageType.JPG);
		}
		if (GUI.Button(new Rect(200f, 160f, 250f, 50f), "Save Selected Screen with watermark") && int.Parse(this.width) > 0 && int.Parse(this.height) > 0)
		{
			this.snapShot.CaptureAndSaveToAlbum(int.Parse(this.x), int.Parse(this.y), int.Parse(this.width), int.Parse(this.height), ImageType.JPG, this.watermark, WatermarkAlignment.CENTER);
		}
		GUI.Label(new Rect(20f, 230f, 500f, 20f), "------------------------------------------------------------------------------------------------------------------------------");
		GUI.Label(new Rect(70f, 250f, 200f, 50f), "Click This Texture to Save");
		if (GUI.Button(new Rect(50f, 270f, 200f, 200f), this.tex) && this.tex != null)
		{
			this.snapShot.SaveTextureToGallery(this.tex, ImageType.JPG);
		}
		if (GUI.Button(new Rect((float)(Screen.width - 120), 10f, 100f, 40f), "Next"))
		{
			SceneManager.LoadScene(2);
		}
	}

	// Token: 0x04000087 RID: 135
	private string x = "0";

	// Token: 0x04000088 RID: 136
	private string y = "0";

	// Token: 0x04000089 RID: 137
	private string width = "0";

	// Token: 0x0400008A RID: 138
	private string height = "0";

	// Token: 0x0400008B RID: 139
	public Texture2D tex;

	// Token: 0x0400008C RID: 140
	public Texture2D watermark;

	// Token: 0x0400008D RID: 141
	private CaptureAndSave snapShot;

	// Token: 0x0400008E RID: 142
	private string log = "Log";
}
