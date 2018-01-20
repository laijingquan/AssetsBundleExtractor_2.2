using System;
using UnityEngine;

// Token: 0x02000138 RID: 312
public class CameraController : MonoBehaviour
{
	// Token: 0x1700006C RID: 108
	// (get) Token: 0x060007F1 RID: 2033 RVA: 0x00021F03 File Offset: 0x00020303
	public float cameraSizeWidth
	{
		get
		{
			return this._cameraSizeWidth;
		}
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x060007F2 RID: 2034 RVA: 0x00021F0B File Offset: 0x0002030B
	public float cameraSizeHeight
	{
		get
		{
			return this._cameraSizeHeight;
		}
	}

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x060007F3 RID: 2035 RVA: 0x00021F13 File Offset: 0x00020313
	public float cameraSizeWidthHalf
	{
		get
		{
			return this._cameraSizeWidthHalf;
		}
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x060007F4 RID: 2036 RVA: 0x00021F1B File Offset: 0x0002031B
	public float cameraSizeHeightHalf
	{
		get
		{
			return this._cameraSizeHeightHalf;
		}
	}

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x060007F5 RID: 2037 RVA: 0x00021F23 File Offset: 0x00020323
	public float screenWidth
	{
		get
		{
			return this._screenWidth;
		}
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x060007F6 RID: 2038 RVA: 0x00021F2B File Offset: 0x0002032B
	public float screenHeight
	{
		get
		{
			return this._screenHeight;
		}
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x060007F7 RID: 2039 RVA: 0x00021F33 File Offset: 0x00020333
	public float aspectRatio
	{
		get
		{
			return this._aspectRatio;
		}
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x00021F3B File Offset: 0x0002033B
	public void Init()
	{
		this._screenWidth = (float)Screen.width;
		this._screenHeight = (float)Screen.height;
		this.AdjustCameraWidth();
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x00021F5C File Offset: 0x0002035C
	private void AdjustCameraWidth()
	{
		float orthographicSize = base.GetComponent<Camera>().orthographicSize;
		this._aspectRatio = (float)Screen.width * 1f / (float)Screen.height;
		float num = orthographicSize * 2f * this._aspectRatio;
		this._cameraSizeWidthHalf = num * 0.5f;
		this._cameraSizeHeightHalf = orthographicSize;
		this._cameraSizeWidth = this._cameraSizeWidthHalf * 2f;
		this._cameraSizeHeight = this._cameraSizeHeightHalf * 2f;
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x00021FD5 File Offset: 0x000203D5
	private void Update()
	{
	}

	// Token: 0x040004DC RID: 1244
	public static float CAMERA_DESIGN_WIDTH = 9f;

	// Token: 0x040004DD RID: 1245
	public static float CAMERA_DESIGN_HEIGHT = 16f;

	// Token: 0x040004DE RID: 1246
	private float _cameraSizeWidth;

	// Token: 0x040004DF RID: 1247
	private float _cameraSizeHeight;

	// Token: 0x040004E0 RID: 1248
	private float _cameraSizeWidthHalf;

	// Token: 0x040004E1 RID: 1249
	private float _cameraSizeHeightHalf;

	// Token: 0x040004E2 RID: 1250
	private float _screenWidth;

	// Token: 0x040004E3 RID: 1251
	private float _screenHeight;

	// Token: 0x040004E4 RID: 1252
	private float _aspectRatio;
}
