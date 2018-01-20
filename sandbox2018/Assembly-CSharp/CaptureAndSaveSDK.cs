using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
public class CaptureAndSaveSDK : MonoBehaviour
{
	// Token: 0x1700009F RID: 159
	// (get) Token: 0x060008BB RID: 2235 RVA: 0x00025966 File Offset: 0x00023D66
	public static CaptureAndSaveSDK Instance
	{
		get
		{
			return CaptureAndSaveSDK.instance;
		}
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x0002596D File Offset: 0x00023D6D
	private void Awake()
	{
		if (CaptureAndSaveSDK.instance == null)
		{
			CaptureAndSaveSDK.instance = this;
		}
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x00025985 File Offset: 0x00023D85
	private void Start()
	{
		this._snapShot = UnityEngine.Object.FindObjectOfType<CaptureAndSave>();
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x00025992 File Offset: 0x00023D92
	private void OnEnable()
	{
		CaptureAndSaveEventListener.onError += this.OnError;
		CaptureAndSaveEventListener.onSuccess += this.OnSuccess;
	}

	// Token: 0x060008BF RID: 2239 RVA: 0x000259B6 File Offset: 0x00023DB6
	private void OnDisable()
	{
		CaptureAndSaveEventListener.onError += this.OnError;
		CaptureAndSaveEventListener.onSuccess += this.OnSuccess;
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x000259DA File Offset: 0x00023DDA
	private void OnError(string error)
	{
		Debug.Log("Error : " + error);
	}

	// Token: 0x060008C1 RID: 2241 RVA: 0x000259EC File Offset: 0x00023DEC
	private void OnSuccess(string msg)
	{
		Debug.Log("Success : " + msg);
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x000259FE File Offset: 0x00023DFE
	public void SaveToGallery(Texture2D tex)
	{
		this._snapShot.SaveTextureToGallery(tex, ImageType.PNG);
	}

	// Token: 0x0400056C RID: 1388
	private static CaptureAndSaveSDK instance;

	// Token: 0x0400056D RID: 1389
	private CaptureAndSave _snapShot;
}
