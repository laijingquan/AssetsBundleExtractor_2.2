using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

// Token: 0x02000141 RID: 321
public class DataTiles
{
	// Token: 0x1700007F RID: 127
	// (get) Token: 0x06000824 RID: 2084 RVA: 0x000229F9 File Offset: 0x00020DF9
	public Dictionary<int, DataTiles.ColorTile> colorRank
	{
		get
		{
			return this._colorRank;
		}
	}

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x06000825 RID: 2085 RVA: 0x00022A01 File Offset: 0x00020E01
	public Dictionary<string, DataTiles.DataTile> dataTileDic
	{
		get
		{
			return this._dataTileDic;
		}
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x00022A0C File Offset: 0x00020E0C
	public void Load(string name, JSONNode json)
	{
		this.TID = name;
		DataImage image = DataManager.Instance.dataImageGroup.GetImage(this.TID);
		this.price = image.price;
		this.canvasLength = image.canvasLength;
		this.tag = json["tag"];
		JSONNode jsonnode = json["colorRank"];
		int count = jsonnode.Count;
		for (int i = 1; i <= count; i++)
		{
			DataTiles.ColorTile colorTile = new DataTiles.ColorTile();
			colorTile.trueColor = new Color(0f, 0f, 0f, 1f);
			colorTile.greyColor = new Color(0f, 0f, 0f, 1f);
			colorTile.count = 0;
			string aKey = i + string.Empty;
			JSONNode jsonnode2 = jsonnode[aKey];
			colorTile.trueColor.r = (float)jsonnode2[0].AsInt / 255f;
			colorTile.trueColor.g = (float)jsonnode2[1].AsInt / 255f;
			colorTile.trueColor.b = (float)jsonnode2[2].AsInt / 255f;
			float greyscaleWeight = DataManager.Instance.dataConfig.greyscaleWeight;
			float greyscaleWeight2 = DataManager.Instance.dataConfig.greyscaleWeight2;
			float greyValue = ColorHelper.GetGreyValue(colorTile.trueColor, greyscaleWeight, greyscaleWeight2);
			colorTile.greyColor.r = greyValue;
			colorTile.greyColor.g = greyValue;
			colorTile.greyColor.b = greyValue;
			this._colorRank.Add(i, colorTile);
		}
		JSONNode jsonnode3 = json["dataList"];
		foreach (JSONNode jsonnode4 in jsonnode3.Childs)
		{
			DataTiles.DataTile dataTile = new DataTiles.DataTile();
			dataTile.Init();
			dataTile.indexX = jsonnode4[0].AsInt;
			dataTile.indexY = jsonnode4[1].AsInt;
			dataTile.colorIndex = JsonReader.Int(jsonnode4[2]);
			if (dataTile.colorIndex == 0)
			{
				dataTile.isWhite = true;
				dataTile.colorTile = new DataTiles.ColorTile();
				dataTile.colorTile.trueColor = Color.white;
				dataTile.colorTile.greyColor = Color.white;
			}
			else
			{
				this._colorRank.TryGetValue(dataTile.colorIndex, out dataTile.colorTile);
				this._colorRank[dataTile.colorIndex].count++;
			}
			string key = dataTile.indexX + "_" + dataTile.indexY;
			this._dataTileDic.Add(key, dataTile);
		}
	}

	// Token: 0x04000502 RID: 1282
	public string TID;

	// Token: 0x04000503 RID: 1283
	public int price;

	// Token: 0x04000504 RID: 1284
	public string tag;

	// Token: 0x04000505 RID: 1285
	public int canvasLength;

	// Token: 0x04000506 RID: 1286
	private Dictionary<int, DataTiles.ColorTile> _colorRank = new Dictionary<int, DataTiles.ColorTile>();

	// Token: 0x04000507 RID: 1287
	private Dictionary<string, DataTiles.DataTile> _dataTileDic = new Dictionary<string, DataTiles.DataTile>();

	// Token: 0x02000142 RID: 322
	public class ColorTile
	{
		// Token: 0x04000508 RID: 1288
		public int count;

		// Token: 0x04000509 RID: 1289
		public Color trueColor;

		// Token: 0x0400050A RID: 1290
		public Color greyColor;
	}

	// Token: 0x02000143 RID: 323
	public class DataTile
	{
		// Token: 0x06000829 RID: 2089 RVA: 0x00022D38 File Offset: 0x00021138
		public void Init()
		{
			this.isValid = true;
			this.isTouchRight = false;
			this.isWhite = false;
			this.isTouched = false;
			this.isTouchWrong = false;
		}

		// Token: 0x0400050B RID: 1291
		public bool isValid;

		// Token: 0x0400050C RID: 1292
		public bool isTouchRight;

		// Token: 0x0400050D RID: 1293
		public bool isWhite;

		// Token: 0x0400050E RID: 1294
		public bool isTouched;

		// Token: 0x0400050F RID: 1295
		public bool isTouchWrong;

		// Token: 0x04000510 RID: 1296
		public int wrongColorIndex;

		// Token: 0x04000511 RID: 1297
		public int indexX;

		// Token: 0x04000512 RID: 1298
		public int indexY;

		// Token: 0x04000513 RID: 1299
		public DataTiles.ColorTile colorTile;

		// Token: 0x04000514 RID: 1300
		public int colorIndex;
	}
}
