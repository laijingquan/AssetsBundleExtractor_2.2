using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000184 RID: 388
public class UIThumbCellBig : MonoBehaviour
{
	// Token: 0x06000A23 RID: 2595 RVA: 0x0002BCAC File Offset: 0x0002A0AC
	public void Init(string TID)
	{
		this._TID = TID;
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		DataTiles dataTiles;
		dicDataTiles.TryGetValue(this._TID, out dataTiles);
		if (dataTiles != null)
		{
			if (dataTiles.price == 0)
			{
				this._isVip = false;
			}
			else
			{
				this._isVip = true;
			}
		}
		this.AddThumb(this._TID);
		if (this._isVip)
		{
			this.AddThumbVip();
		}
		this._isFinish = PlayerManager.Instance.GetOnePictureFinish(this._TID);
		if (this._isFinish)
		{
			this.AddThumbFinish();
		}
		else
		{
			DataImage image = DataManager.Instance.dataImageGroup.GetImage(this._TID);
			if (image.isDailyNew)
			{
				this.AddThumbNew();
			}
		}
		Button component = base.gameObject.GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			this.OnCellClick(base.gameObject);
		});
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x0002BD98 File Offset: 0x0002A198
	private void AddThumb(string TID)
	{
		Image component = base.transform.Find("ContentImage").GetComponent<Image>();
		component.sprite = ImagePoolManager.Instance.GetSprite(TID);
		component.SetNativeSize();
		float width = component.rectTransform.rect.width;
		float num = AppConfig.UI_THUMB_BIG_LENGTH / width;
		component.transform.localScale = new Vector2(num, num);
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x0002BE08 File Offset: 0x0002A208
	private void AddThumbVip()
	{
		GameObject gameObject = ResourceHelper.Load("Prefabs/Thumbs/ThumbVip");
		gameObject.transform.SetParent(base.transform);
		Image component = gameObject.GetComponent<Image>();
		component.rectTransform.localScale = new Vector2(1f, 1f);
		component.rectTransform.localPosition = new Vector2(-200f, 220f);
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x0002BE78 File Offset: 0x0002A278
	private void AddThumbFinish()
	{
		GameObject gameObject = ResourceHelper.Load("Prefabs/Thumbs/ThumbFinish");
		gameObject.transform.SetParent(base.transform);
		gameObject.name = "ThumbFinish";
		Image component = gameObject.GetComponent<Image>();
		component.rectTransform.localScale = new Vector2(1f, 1f);
		component.rectTransform.localPosition = new Vector2(190f, 190f);
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x0002BEF4 File Offset: 0x0002A2F4
	private void AddThumbNew()
	{
		GameObject gameObject = ResourceHelper.Load("Prefabs/Thumbs/ThumbNew");
		gameObject.transform.SetParent(base.transform);
		gameObject.name = "ThumbNew";
		Image component = gameObject.GetComponent<Image>();
		component.rectTransform.localScale = new Vector2(1f, 1f);
		component.rectTransform.localPosition = new Vector2(172f, 172f);
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x0002BF70 File Offset: 0x0002A370
	private void LoadTexure(out Texture2D texture)
	{
		int width = Screen.width;
		int width2 = Screen.width;
		texture = new Texture2D(width, width2);
		string thumbPath = CaptureScreenHelper.GetThumbPath(this._TID);
		if (!File.Exists(thumbPath))
		{
			texture = null;
			return;
		}
		FileStream fileStream = new FileStream(thumbPath, FileMode.Open, FileAccess.Read);
		fileStream.Seek(0L, SeekOrigin.Begin);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, (int)fileStream.Length);
		fileStream.Close();
		fileStream.Dispose();
		texture.LoadImage(array);
	}

	// Token: 0x06000A29 RID: 2601 RVA: 0x0002BFF8 File Offset: 0x0002A3F8
	public void RefershImage(string TID)
	{
		this.AddThumb(TID);
		Transform transform = base.transform.Find("ThumbFinish");
		this._isFinish = PlayerManager.Instance.GetOnePictureFinish(this._TID);
		if (this._isFinish)
		{
			if (transform == null)
			{
				this.AddThumbFinish();
			}
			else
			{
				transform.gameObject.SetActive(true);
			}
		}
		else if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000A2A RID: 2602 RVA: 0x0002C080 File Offset: 0x0002A480
	private void OnCellClick(GameObject go)
	{
		SceneGameManager.Instance.CurrentTID = this._TID;
		SceneGameManager.Instance.ThumbCellBig = this;
		SceneGameManager.Instance.ThumbCellSmall = null;
		bool flag = PlayerManager.Instance.GetVip() || PlayerManager.Instance.GetLifeVip();
		if (this._isVip && !flag)
		{
			MainUIManager.Instance.ShowVipPanel();
			return;
		}
		PlayerManager.Instance.AddMyPictureList(this._TID);
		SceneGameManager.Instance.SwitchPanel(SceneGameManager.SCENEPANEL.GMAE);
	}

	// Token: 0x04000625 RID: 1573
	private string _TID;

	// Token: 0x04000626 RID: 1574
	private bool _isVip;

	// Token: 0x04000627 RID: 1575
	private bool _isFinish;
}
