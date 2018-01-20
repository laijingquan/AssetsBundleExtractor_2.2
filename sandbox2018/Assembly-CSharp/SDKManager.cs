using System;
using SA.Common.Pattern;
using UnityEngine;

// Token: 0x0200015E RID: 350
public class SDKManager : MonoBehaviour
{
	// Token: 0x060008DD RID: 2269 RVA: 0x00025FB8 File Offset: 0x000243B8
	public void Init()
	{
		this.InitAdjust();
		this.InitAdmob();
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x00025FC6 File Offset: 0x000243C6
	private void InitAdjust()
	{
		ResourceHelper.Load("Prefabs/SDK/Adjust_Android");
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x00025FD3 File Offset: 0x000243D3
	private void InitAdmob()
	{
		ResourceHelper.Load("Prefabs/SDK/AdmobInterstitial");
		ResourceHelper.Load("Prefabs/SDK/AdmobBanner");
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x00025FEC File Offset: 0x000243EC
	public void UniShare(string TID)
	{
		UniShare component = GameObject.Find("UniShare").GetComponent<UniShare>();
		Texture2D texture2D = TextureHelper.LoadTextureByIO(TID);
		if (texture2D != null)
		{
			Debug.Log("UniShare tex " + TID);
			component.createdTexture = texture2D;
			component.ShareScreenshot();
		}
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x0002603C File Offset: 0x0002443C
	public void ShareInsgram(string TID)
	{
		Debug.Log("ShareInsgram " + TID);
		Texture2D texture2D = TextureHelper.LoadTextureByIO(TID);
		if (texture2D != null)
		{
			Singleton<SPInstagram>.Instance.Share(texture2D);
		}
	}

	// Token: 0x060008E2 RID: 2274 RVA: 0x00026078 File Offset: 0x00024478
	public void SaveToGallery(string TID)
	{
		Texture2D texture2D = TextureHelper.LoadTextureByIO(TID);
		if (texture2D != null)
		{
			CaptureAndSaveSDK.Instance.SaveToGallery(texture2D);
		}
	}

	// Token: 0x170000A2 RID: 162
	// (get) Token: 0x060008E3 RID: 2275 RVA: 0x000260A4 File Offset: 0x000244A4
	public static SDKManager Instance
	{
		get
		{
			if (SDKManager._instance == null)
			{
				GameObject gameObject = new GameObject("SDKManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				SDKManager._instance = gameObject.AddComponent<SDKManager>();
			}
			return SDKManager._instance;
		}
	}

	// Token: 0x0400058E RID: 1422
	private const string Adjust_Path_Android = "Prefabs/SDK/Adjust_Android";

	// Token: 0x0400058F RID: 1423
	private const string Adjust_Path_IOS = "Prefabs/SDK/Adjust_IOS";

	// Token: 0x04000590 RID: 1424
	private const string AdmobInterstitial_Path = "Prefabs/SDK/AdmobInterstitial";

	// Token: 0x04000591 RID: 1425
	private const string AdmobBanner_Path = "Prefabs/SDK/AdmobBanner";

	// Token: 0x04000592 RID: 1426
	private static SDKManager _instance;
}
