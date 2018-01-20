using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020001A3 RID: 419
public class CaptureMainEditor : MonoBehaviour
{
	// Token: 0x06000AD5 RID: 2773 RVA: 0x0002EEFE File Offset: 0x0002D2FE
	private void Start()
	{
		this.Init();
		base.StartCoroutine(this.Capture());
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x0002EF14 File Offset: 0x0002D314
	private IEnumerator Capture()
	{
		string name = CaptureSceneDataEditor.Instance.pictureName;
		this.InitPicture(name);
		yield return new WaitForEndOfFrame();
		CaptureScreenHelper.CaptureCameraEditor(name);
		yield return null;
		SceneManager.LoadScene("CaptureStartEditor");
		yield break;
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x0002EF30 File Offset: 0x0002D330
	private void Init()
	{
		DataManager.Instance.LoadData();
		GameObject gameObject = GameObject.FindWithTag("MainCamera");
		this._cameraController = gameObject.AddComponent<CameraController>();
		this._cameraController.Init();
		GameObject gameObject2 = new GameObject("TileLayer");
		this._tileLayer = gameObject2.transform;
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x0002EF80 File Offset: 0x0002D380
	private float GetCameraSizeWidthHalf()
	{
		float num = (float)Screen.width;
		float num2 = (float)Screen.height;
		float orthographicSize = GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize;
		float num3 = (float)Screen.width * 1f / (float)Screen.height;
		float num4 = orthographicSize * 2f * num3;
		return num4 * 0.5f;
	}

	// Token: 0x06000AD9 RID: 2777 RVA: 0x0002EFDC File Offset: 0x0002D3DC
	public void InitPicture(string TID)
	{
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
				Transform transform = ResourceHelper.Load(CaptureMainEditor.TILE_REPLAY_PATH).transform;
				transform.transform.SetParent(this._tileLayer);
				TileReplay component = transform.GetComponent<TileReplay>();
				component.Init(dataTile);
				component.transform.position -= new Vector3(num4, num4, 0f);
			}
			this._tileLayer.localScale = new Vector2(num3, num3);
		}
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x0002F114 File Offset: 0x0002D514
	private void Update()
	{
	}

	// Token: 0x0400064F RID: 1615
	private static string TILE_REPLAY_PATH = "Prefabs/TileReplay";

	// Token: 0x04000650 RID: 1616
	private CameraController _cameraController;

	// Token: 0x04000651 RID: 1617
	private Transform _tileLayer;
}
