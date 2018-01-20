using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200014C RID: 332
public class LevelDataManager : MonoBehaviour
{
	// Token: 0x17000090 RID: 144
	// (get) Token: 0x06000856 RID: 2134 RVA: 0x0002377B File Offset: 0x00021B7B
	public List<PlayerManager.TileFillColor> tileFillColorList
	{
		get
		{
			return this._tileFillColorList;
		}
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x00023784 File Offset: 0x00021B84
	public void Load(string TID)
	{
		this._tileFillColorList.Clear();
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		dicDataTiles.TryGetValue(TID, out this._dataTiles);
		this._tileFillColorList = PlayerManager.Instance.GetFillColor(TID);
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x000237CC File Offset: 0x00021BCC
	public bool IsColorFinish(int colorIndex)
	{
		int num = 0;
		int count = this._dataTiles.colorRank[colorIndex].count;
		foreach (DataTiles.DataTile dataTile in this._dataTiles.dataTileDic.Values)
		{
			if (dataTile.colorIndex == colorIndex && dataTile.isTouchRight)
			{
				num++;
			}
		}
		return num >= count;
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x0002386C File Offset: 0x00021C6C
	public bool IsColorBlockFinish()
	{
		foreach (DataTiles.DataTile dataTile in this._dataTiles.dataTileDic.Values)
		{
			if (dataTile.colorIndex == 0 && dataTile.isTouchWrong)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x000238EC File Offset: 0x00021CEC
	public void AddColorFill(int i, int j, int c, int isTouchRight, int isEarser)
	{
		PlayerManager.TileFillColor item = PlayerManager.TileFillColor.Create(i, j, c, isTouchRight, isEarser);
		this._tileFillColorList.Add(item);
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x00023914 File Offset: 0x00021D14
	public bool IsAllFinish()
	{
		foreach (int colorIndex in this._dataTiles.colorRank.Keys)
		{
			bool flag = this.IsColorFinish(colorIndex);
			if (!flag)
			{
				return flag;
			}
		}
		return this.IsColorBlockFinish();
	}

	// Token: 0x04000530 RID: 1328
	private DataTiles _dataTiles;

	// Token: 0x04000531 RID: 1329
	private List<PlayerManager.TileFillColor> _tileFillColorList = new List<PlayerManager.TileFillColor>();
}
