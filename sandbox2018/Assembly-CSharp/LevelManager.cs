using System;
using UnityEngine;

// Token: 0x0200014D RID: 333
public class LevelManager : MonoBehaviour
{
	// Token: 0x17000091 RID: 145
	// (get) Token: 0x0600085D RID: 2141 RVA: 0x0002399C File Offset: 0x00021D9C
	public float picNormalUnitGridLength
	{
		get
		{
			return this._picNormalUnitGridLength;
		}
	}

	// Token: 0x17000092 RID: 146
	// (get) Token: 0x0600085E RID: 2142 RVA: 0x000239A4 File Offset: 0x00021DA4
	public float pictureMinScale
	{
		get
		{
			return this._pictureMinScale;
		}
	}

	// Token: 0x17000093 RID: 147
	// (get) Token: 0x0600085F RID: 2143 RVA: 0x000239AC File Offset: 0x00021DAC
	public float pictureMid1Scale
	{
		get
		{
			return this._pictureMid1Scale;
		}
	}

	// Token: 0x17000094 RID: 148
	// (get) Token: 0x06000860 RID: 2144 RVA: 0x000239B4 File Offset: 0x00021DB4
	public float pictureMid2Scale
	{
		get
		{
			return this._pictureMid2Scale;
		}
	}

	// Token: 0x17000095 RID: 149
	// (get) Token: 0x06000861 RID: 2145 RVA: 0x000239BC File Offset: 0x00021DBC
	public float pictureMaxScale
	{
		get
		{
			return this._pictureMaxScale;
		}
	}

	// Token: 0x17000096 RID: 150
	// (get) Token: 0x06000862 RID: 2146 RVA: 0x000239C4 File Offset: 0x00021DC4
	public float gridInitUnitLength
	{
		get
		{
			return this._gridInitUnitLength;
		}
	}

	// Token: 0x17000097 RID: 151
	// (get) Token: 0x06000863 RID: 2147 RVA: 0x000239CC File Offset: 0x00021DCC
	public float curPictureScaleRadio
	{
		get
		{
			return this.curPicureScale / this._pictureMinScale;
		}
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x000239DC File Offset: 0x00021DDC
	public void Init(DataTiles dataTiles)
	{
		this.isFirstTouch = false;
		this.scaleDrawRadio = 0f;
		this.scaleGreyRadio = 1f;
		float cameraSizeWidth = GameManager.Instance.cameraController.cameraSizeWidth;
		this._zoomMin = dataTiles.canvasLength;
		this._zoomFade = DataManager.Instance.dataConfig.zoomFade;
		this._zoomGrid = DataManager.Instance.dataConfig.zoomGrid;
		this._zoomMax = DataManager.Instance.dataConfig.zoomMax;
		this._picNormalUnitGridLength = (float)this._zoomMin * AppConfig.GRID_UNIT_LENGTH;
		this._pictureMinScale = cameraSizeWidth / this._picNormalUnitGridLength;
		this._pictureMid1Scale = (float)this._zoomMin * 1f / (float)this._zoomFade * this._pictureMinScale;
		this._pictureMid2Scale = (float)this._zoomMin * 1f / (float)this._zoomGrid * this._pictureMinScale;
		this._pictureMaxScale = (float)this._zoomMin * 1f / (float)this._zoomMax * this._pictureMinScale;
		this._gridInitUnitLength = cameraSizeWidth / (float)dataTiles.canvasLength;
		this.curPicureScale = this._pictureMinScale;
		this.curPictureMove = Vector2.zero;
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x00023B10 File Offset: 0x00021F10
	public void UpdateTouchZoom(float zoom)
	{
		Transform transform = GameManager.Instance.gameTilesLayer.transform;
		Vector3 localScale = transform.localScale;
		Vector3 localScale2 = new Vector3(localScale.x + zoom, localScale.y + zoom, 1f);
		if (localScale2.x <= this._pictureMinScale || localScale2.x >= this._pictureMaxScale)
		{
			Debug.Log("layer zoom out of boundary");
			return;
		}
		transform.localScale = localScale2;
		GameManager.Instance.levelManager.curPicureScale = transform.localScale.x;
		float gridCountFromScale = this.GetGridCountFromScale(GameManager.Instance.levelManager.curPicureScale);
		this.TileScaleFade(gridCountFromScale);
		if (zoom <= 0f)
		{
			this.AutoMove(zoom);
		}
		GameManager.Instance.tileGridManager.Draw();
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x00023BE8 File Offset: 0x00021FE8
	private void AutoMove(float zoom)
	{
		Transform transform = GameManager.Instance.gameTilesLayer.transform;
		Vector3 position = transform.position;
		float num = this.curPicureScale / this._pictureMinScale;
		float num2 = position.x;
		float num3 = position.y;
		float cameraSizeWidthHalf = GameManager.Instance.cameraController.cameraSizeWidthHalf;
		float cameraSizeHeightHalf = GameManager.Instance.cameraController.cameraSizeHeightHalf;
		float cameraSizeHeight = GameManager.Instance.cameraController.cameraSizeHeight;
		float num4 = (num != 1f) ? 0.01f : 0f;
		float num5 = -(cameraSizeWidthHalf * (num - 1f) + num4);
		float num6 = cameraSizeWidthHalf * (num - 1f) + num4;
		if (num5 >= -cameraSizeWidthHalf)
		{
			num2 -= Mathf.Abs(zoom);
		}
		if (num6 <= cameraSizeWidthHalf)
		{
			num2 += Mathf.Abs(zoom);
		}
		float num7 = cameraSizeHeightHalf;
		float num8 = AppConfig.GAME_BOTTOM_BOUNDARY_OFFSET * cameraSizeHeight;
		float num9 = -cameraSizeHeightHalf + num8;
		float num10 = this.curPictureMove.y + num * cameraSizeWidthHalf;
		float num11 = this.curPictureMove.y - num * cameraSizeWidthHalf;
		if (num10 <= num7)
		{
			num3 += Mathf.Abs(zoom);
		}
		if (num11 >= num9)
		{
			num3 -= Mathf.Abs(zoom);
		}
		transform.position = new Vector3(position.x, num3, 1f);
		Vector3 position2 = new Vector3(num2, num3, 1f);
		this.UpdateTouchDrag(position2);
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x00023D50 File Offset: 0x00022150
	public void UpdateTouchDrag(Vector3 position)
	{
		Transform transform = GameManager.Instance.gameTilesLayer.transform;
		Vector3 position2 = transform.position;
		float x = position.x;
		float y = position.y;
		float num = this.curPicureScale / this._pictureMinScale;
		float cameraSizeWidthHalf = GameManager.Instance.cameraController.cameraSizeWidthHalf;
		float cameraSizeHeightHalf = GameManager.Instance.cameraController.cameraSizeHeightHalf;
		float cameraSizeHeight = GameManager.Instance.cameraController.cameraSizeHeight;
		float num2 = (num != 1f) ? 0.01f : 0f;
		float num3 = -(cameraSizeWidthHalf * (num - 1f) + num2);
		float num4 = cameraSizeWidthHalf * (num - 1f) + num2;
		if (x >= num3 && x <= num4)
		{
			position2.x = x;
		}
		else if (x < num3)
		{
			position2.x = num3;
		}
		else if (x > num4)
		{
			position2.x = num4;
		}
		float num5 = cameraSizeHeightHalf;
		float num6 = AppConfig.GAME_BOTTOM_BOUNDARY_OFFSET * cameraSizeHeight;
		float num7 = -cameraSizeHeightHalf + num6;
		float num8 = this.curPictureMove.y + num * cameraSizeWidthHalf;
		float num9 = this.curPictureMove.y - num * cameraSizeWidthHalf;
		if (y <= 0f)
		{
			if (num8 >= num5 || Mathf.Abs(num8 - num5) <= 0.001f)
			{
				if (Mathf.Abs(y) <= Mathf.Abs(num * cameraSizeWidthHalf - Mathf.Abs(num5)))
				{
					position2.y = y;
				}
				else
				{
					position2.y = -Mathf.Abs(num * cameraSizeWidthHalf - Mathf.Abs(num5));
				}
			}
		}
		else if (num9 <= num7 || Mathf.Abs(num9 - num7) <= 0.001f)
		{
			if (Mathf.Abs(y) <= Mathf.Abs(num * cameraSizeWidthHalf - Mathf.Abs(num7)))
			{
				position2.y = y;
			}
			else
			{
				position2.y = Mathf.Abs(num * cameraSizeWidthHalf - Mathf.Abs(num7));
			}
		}
		transform.position = position2;
		GameManager.Instance.levelManager.curPictureMove = transform.transform.position - Vector3.zero;
		GameManager.Instance.tileGridManager.Draw();
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x00023F94 File Offset: 0x00022394
	public void MinZoom()
	{
		int zoomMin = this._zoomMin;
		float greyRatio = DataManager.Instance.dataConfig.greyRatio;
		float num = (1f - greyRatio) / (float)(this._zoomMin - this._zoomFade);
		float mainAlpha = 1f - num * (float)(this._zoomMin - zoomMin);
		GameManager.Instance.tileManager.SetMainAlpha(mainAlpha);
		GameManager.Instance.tileGridManager.SetAlpha(0f);
		GameManager.Instance.tileManager.SetNumberAlpha(0f);
		GameManager.Instance.tileManager.SetHighLightAlpha(0f);
		Transform transform = GameManager.Instance.gameTilesLayer.transform;
		transform.localScale = new Vector3(this._pictureMinScale, this._pictureMinScale, 1f);
		transform.position = Vector2.zero;
		GameManager.Instance.levelManager.curPicureScale = transform.localScale.x;
		this.scaleDrawRadio = 0f;
		this.scaleGreyRadio = mainAlpha;
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x000240A0 File Offset: 0x000224A0
	public void MaxZoom()
	{
		int zoomMax = this._zoomMax;
		float drawRatio = DataManager.Instance.dataConfig.drawRatio;
		float num = (1f - drawRatio) / (float)(this._zoomGrid - this._zoomMax);
		float num2 = 1f - num * (float)(zoomMax - this._zoomMax);
		Transform transform = GameManager.Instance.gameTilesLayer.transform;
		Vector3 localScale = transform.localScale;
		transform.localScale = new Vector3(this._pictureMaxScale, this._pictureMaxScale, 1f);
		GameManager.Instance.levelManager.curPicureScale = transform.localScale.x;
		GameManager.Instance.tileGridManager.Draw();
		GameManager.Instance.tileGridManager.SetAlpha(num2);
		GameManager.Instance.tileManager.SetNumberAlpha(num2);
		GameManager.Instance.tileManager.SetMainAlpha(0f);
		GameManager.Instance.tileManager.SetHighLightAlpha(num2);
		this.scaleDrawRadio = num2;
		this.scaleGreyRadio = 0f;
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x000241A8 File Offset: 0x000225A8
	private void TileScaleFade(float gridCount)
	{
		float greyRatio = DataManager.Instance.dataConfig.greyRatio;
		float drawRatio = DataManager.Instance.dataConfig.drawRatio;
		if (gridCount > (float)this._zoomFade)
		{
			float num = (1f - greyRatio) / (float)(this._zoomMin - this._zoomFade);
			float mainAlpha = 1f - num * ((float)this._zoomMin - gridCount);
			GameManager.Instance.tileManager.SetMainAlpha(mainAlpha);
			GameManager.Instance.tileGridManager.SetAlpha(0f);
			GameManager.Instance.tileManager.SetNumberAlpha(0f);
			GameManager.Instance.tileManager.SetHighLightAlpha(0f);
			this.scaleDrawRadio = 0f;
			this.scaleGreyRadio = mainAlpha;
		}
		else if (gridCount > (float)this._zoomGrid)
		{
			float num2 = greyRatio / (float)(this._zoomFade - this._zoomGrid);
			float mainAlpha2 = num2 * (gridCount - (float)this._zoomGrid);
			GameManager.Instance.tileManager.SetMainAlpha(mainAlpha2);
			float num3 = drawRatio / (float)(this._zoomFade - this._zoomGrid);
			float num4 = num3 * ((float)this._zoomFade - gridCount);
			GameManager.Instance.tileGridManager.SetAlpha(num4);
			GameManager.Instance.tileManager.SetNumberAlpha(num4);
			GameManager.Instance.tileManager.SetHighLightAlpha(num4);
			this.scaleDrawRadio = num4;
			this.scaleGreyRadio = mainAlpha2;
		}
		else if (gridCount >= (float)this._zoomMax)
		{
			float num5 = (1f - drawRatio) / (float)(this._zoomGrid - this._zoomMax);
			float num6 = 1f - num5 * (gridCount - (float)this._zoomMax);
			GameManager.Instance.tileManager.SetMainAlpha(0f);
			GameManager.Instance.tileGridManager.SetAlpha(num6);
			GameManager.Instance.tileManager.SetNumberAlpha(num6);
			GameManager.Instance.tileManager.SetHighLightAlpha(num6);
			this.scaleDrawRadio = num6;
			this.scaleGreyRadio = 0f;
		}
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x000243AC File Offset: 0x000227AC
	private float GetGridCountFromScale(float scale)
	{
		return this._pictureMinScale / scale * (float)this._zoomMin;
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x000243C0 File Offset: 0x000227C0
	public int GetCurGridCount()
	{
		float gridCountFromScale = this.GetGridCountFromScale(GameManager.Instance.levelManager.curPicureScale);
		return Mathf.CeilToInt(gridCountFromScale);
	}

	// Token: 0x0600086D RID: 2157 RVA: 0x000243E9 File Offset: 0x000227E9
	private void Update()
	{
	}

	// Token: 0x04000532 RID: 1330
	public bool isFirstTouch;

	// Token: 0x04000533 RID: 1331
	private float _picNormalUnitGridLength;

	// Token: 0x04000534 RID: 1332
	private float _pictureMinScale;

	// Token: 0x04000535 RID: 1333
	private float _pictureMid1Scale;

	// Token: 0x04000536 RID: 1334
	private float _pictureMid2Scale;

	// Token: 0x04000537 RID: 1335
	private float _pictureMaxScale;

	// Token: 0x04000538 RID: 1336
	private float _gridInitUnitLength;

	// Token: 0x04000539 RID: 1337
	public float curPicureScale;

	// Token: 0x0400053A RID: 1338
	public Vector2 curPictureMove;

	// Token: 0x0400053B RID: 1339
	public float scaleDrawRadio;

	// Token: 0x0400053C RID: 1340
	public float scaleGreyRadio;

	// Token: 0x0400053D RID: 1341
	private int _zoomMin;

	// Token: 0x0400053E RID: 1342
	private int _zoomFade;

	// Token: 0x0400053F RID: 1343
	private int _zoomGrid;

	// Token: 0x04000540 RID: 1344
	private int _zoomMax;
}
