using System;
using System.Collections.Generic;
using OneP.InfinityScrollView;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000185 RID: 389
public class UIThumbCellSmall : InfinityBaseItem
{
	// Token: 0x06000A2D RID: 2605 RVA: 0x0002C120 File Offset: 0x0002A520
	public override void Reload(InfinityScrollView _infinity, int _index)
	{
		base.Reload(_infinity, _index);
		this._categoryIndex = _infinity.categoryIndex;
		int initTotalNumber = _infinity.initTotalNumber;
		DataCategory dataCategory = DataManager.Instance.dataDirectoryGroup.dataCategoryList[this._categoryIndex];
		this._TID_0 = dataCategory.picList[base.Index * 2];
		this.AddThumb(this._TID_0, 0);
		if (_index * 2 + 1 < initTotalNumber)
		{
			this.item1.SetActive(true);
			this._TID_1 = dataCategory.picList[base.Index * 2 + 1];
			this.AddThumb(this._TID_1, 1);
		}
		else
		{
			this.item1.SetActive(false);
		}
	}

	// Token: 0x06000A2E RID: 2606 RVA: 0x0002C1DC File Offset: 0x0002A5DC
	private void AddThumb(string TID, int n)
	{
		GameObject gameObject = this.item0;
		if (n == 1)
		{
			gameObject = this.item1;
		}
		GameObject gameObject2 = gameObject.transform.Find("ThumbVip").gameObject;
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		DataTiles dataTiles;
		dicDataTiles.TryGetValue(TID, out dataTiles);
		if (dataTiles != null)
		{
			if (dataTiles.price == 0)
			{
				gameObject2.SetActive(false);
			}
			else
			{
				gameObject2.SetActive(true);
			}
		}
		GameObject gameObject3 = gameObject.transform.Find("ThumbFinish").gameObject;
		GameObject gameObject4 = gameObject.transform.Find("ThumbNew").gameObject;
		bool onePictureFinish = PlayerManager.Instance.GetOnePictureFinish(TID);
		if (onePictureFinish)
		{
			gameObject3.SetActive(true);
			gameObject4.SetActive(false);
		}
		else
		{
			gameObject3.SetActive(false);
			DataImage image = DataManager.Instance.dataImageGroup.GetImage(TID);
			if (image.isDailyNew)
			{
				gameObject4.SetActive(true);
			}
			else
			{
				gameObject4.SetActive(false);
			}
		}
		if (n == 0)
		{
			this.LoadImage0();
		}
		else
		{
			this.LoadImage1();
		}
	}

	// Token: 0x06000A2F RID: 2607 RVA: 0x0002C2FC File Offset: 0x0002A6FC
	private void LoadImage0()
	{
		Image component = this.item0.transform.Find("ContentImage").GetComponent<Image>();
		component.sprite = ImagePoolManager.Instance.GetSprite(this._TID_0);
		this.ResizeThumb(component);
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x0002C344 File Offset: 0x0002A744
	private void LoadImage1()
	{
		Image component = this.item1.transform.Find("ContentImage").GetComponent<Image>();
		component.sprite = ImagePoolManager.Instance.GetSprite(this._TID_1);
		this.ResizeThumb(component);
	}

	// Token: 0x06000A31 RID: 2609 RVA: 0x0002C38C File Offset: 0x0002A78C
	private void ResizeThumb(Image image)
	{
		image.SetNativeSize();
		float width = image.rectTransform.rect.width;
		float num = AppConfig.UI_THUMB_SMALL_LENGTH / width;
		image.transform.localScale = new Vector2(num, num);
	}

	// Token: 0x06000A32 RID: 2610 RVA: 0x0002C3D2 File Offset: 0x0002A7D2
	public void RefershImage(string TID, int n)
	{
		this.AddThumb(TID, n);
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x0002C3DC File Offset: 0x0002A7DC
	public void OnClick1()
	{
		this.OnClick(this._TID_0, 0);
		Debug.Log("click TID:" + this._TID_0);
	}

	// Token: 0x06000A34 RID: 2612 RVA: 0x0002C400 File Offset: 0x0002A800
	public void OnClick2()
	{
		this.OnClick(this._TID_1, 1);
		Debug.Log("click TID:" + this._TID_1);
	}

	// Token: 0x06000A35 RID: 2613 RVA: 0x0002C424 File Offset: 0x0002A824
	private void OnClick(string TID, int n)
	{
		SceneGameManager.Instance.CurrentTID = TID;
		SceneGameManager.Instance.ThumbCellBig = null;
		SceneGameManager.Instance.ThumbCellSmall = this;
		SceneGameManager.Instance.ThumbCellSmallIndex = n;
		bool flag = false;
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		DataTiles dataTiles;
		dicDataTiles.TryGetValue(TID, out dataTiles);
		if (dataTiles != null)
		{
			flag = (dataTiles.price != 0);
		}
		bool flag2 = PlayerManager.Instance.GetVip() || PlayerManager.Instance.GetLifeVip();
		if (flag && !flag2)
		{
			MainUIManager.Instance.ShowVipPanel();
			return;
		}
		PlayerManager.Instance.AddMyPictureList(TID);
		SceneGameManager.Instance.SwitchPanel(SceneGameManager.SCENEPANEL.GMAE);
	}

	// Token: 0x04000628 RID: 1576
	public GameObject item0;

	// Token: 0x04000629 RID: 1577
	public GameObject item1;

	// Token: 0x0400062A RID: 1578
	private int _categoryIndex;

	// Token: 0x0400062B RID: 1579
	private string _TID_0;

	// Token: 0x0400062C RID: 1580
	private string _TID_1;
}
