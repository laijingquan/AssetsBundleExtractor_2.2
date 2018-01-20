using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000163 RID: 355
public class TestOptimize : MonoBehaviour
{
	// Token: 0x06000920 RID: 2336 RVA: 0x00027120 File Offset: 0x00025520
	private void Start()
	{
		this.Init();
		this.RefreshPicture("0001");
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x00027134 File Offset: 0x00025534
	private void Init()
	{
		DataManager.Instance.LoadData();
		GameObject gameObject = GameObject.FindWithTag("MainCamera");
		this._cameraController = gameObject.AddComponent<CameraController>();
		this._cameraController.Init();
		GameObject gameObject2 = GameObject.Find("TileLayer");
		this._tileLayer = gameObject2.transform;
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x00027184 File Offset: 0x00025584
	private float GetCameraSizeWidthHalf()
	{
		float num = (float)Screen.width;
		float num2 = (float)Screen.height;
		float orthographicSize = GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize;
		float num3 = (float)Screen.width * 1f / (float)Screen.height;
		float num4 = orthographicSize * 2f * num3;
		return num4 * 0.5f;
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x000271E0 File Offset: 0x000255E0
	public void RefreshPicture(string TID)
	{
		this._tileLayer.localScale = Vector2.one;
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		DataTiles dataTiles;
		dicDataTiles.TryGetValue(TID, out dataTiles);
		if (dataTiles != null)
		{
			float cameraSizeWidth = this._cameraController.cameraSizeWidth;
			float num = (float)dataTiles.canvasLength;
			float num2 = num * AppConfig.GRID_UNIT_LENGTH;
			float num3 = cameraSizeWidth / num2;
			float num4 = this._cameraController.cameraSizeWidthHalf;
			num4 /= num3;
			num4 -= 0.5f * AppConfig.GRID_UNIT_LENGTH;
			foreach (DataTiles.DataTile dataTile in dataTiles.dataTileDic.Values)
			{
				Transform transform = ResourceHelper.Load(TestOptimize.TILE_REPLAY_PATH).transform;
				transform.transform.SetParent(this._tileLayer);
				Tile component = transform.GetComponent<Tile>();
				component.transform.position -= new Vector3(num4, num4, 0f);
			}
			this._tileLayer.localScale = new Vector2(num3, num3);
		}
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x00027324 File Offset: 0x00025724
	public void RefershClick()
	{
		string tid = string.Format("{0:D4}", TestOptimize.pictureCount + 1);
		TestOptimize.pictureCount++;
		this.RefreshPicture(tid);
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x0002735B File Offset: 0x0002575B
	private void Update()
	{
	}

	// Token: 0x040005AD RID: 1453
	private static string TILE_REPLAY_PATH = "Prefabs/Tile";

	// Token: 0x040005AE RID: 1454
	private CameraController _cameraController;

	// Token: 0x040005AF RID: 1455
	private Transform _tileLayer;

	// Token: 0x040005B0 RID: 1456
	public static int pictureCount = 1;
}
