using System;
using LitJson;
using UnityEngine;

// Token: 0x0200013A RID: 314
public class DataConfig
{
	// Token: 0x06000803 RID: 2051 RVA: 0x0002214B File Offset: 0x0002054B
	public void Init()
	{
		this.Load("config");
	}

	// Token: 0x06000804 RID: 2052 RVA: 0x00022158 File Offset: 0x00020558
	private void Load(string name)
	{
		string fileName = "DataConfig/" + name + ".json";
		byte[] bytes = ResourceHelper.QueryFileContent(fileName);
		string aJSON = StringHelper.ReadFromBytes(bytes);
		JSONNode jsonnode = JSON.Parse(aJSON);
		this.pictureAmount = JsonReader.Int(jsonnode, "pictureAmount");
		this.greyscaleWeight = JsonReader.Float(jsonnode, "greyscaleWeight");
		this.greyscaleWeight2 = JsonReader.Float(jsonnode, "greyscaleWeight2");
		this.zoomFade = JsonReader.Int(jsonnode, "zoomFade");
		this.zoomGrid = JsonReader.Int(jsonnode, "zoomGrid");
		this.zoomMax = JsonReader.Int(jsonnode, "zoomMax");
		this.greyRatio = JsonReader.Float(jsonnode, "greyRatio");
		this.drawRatio = JsonReader.Float(jsonnode, "drawRatio");
		this.swipeMax = JsonReader.Int(jsonnode, "swipeMax");
		this.grid_opacity = JsonReader.Float(jsonnode, "grid_opacity");
		this.grid_selectColor = new Color(0f, 0f, 0f, 1f);
		JSONNode jsonnode2 = jsonnode["grid_selectColor"];
		this.grid_selectColor.r = (float)jsonnode2[0].AsInt / 255f;
		this.grid_selectColor.g = (float)jsonnode2[1].AsInt / 255f;
		this.grid_selectColor.b = (float)jsonnode2[2].AsInt / 255f;
	}

	// Token: 0x040004E7 RID: 1255
	public int pictureAmount;

	// Token: 0x040004E8 RID: 1256
	public float greyscaleWeight;

	// Token: 0x040004E9 RID: 1257
	public float greyscaleWeight2;

	// Token: 0x040004EA RID: 1258
	public int zoomFade;

	// Token: 0x040004EB RID: 1259
	public int zoomGrid;

	// Token: 0x040004EC RID: 1260
	public int zoomMax;

	// Token: 0x040004ED RID: 1261
	public float greyRatio;

	// Token: 0x040004EE RID: 1262
	public float drawRatio;

	// Token: 0x040004EF RID: 1263
	public int swipeMax;

	// Token: 0x040004F0 RID: 1264
	public float grid_opacity;

	// Token: 0x040004F1 RID: 1265
	public Color grid_selectColor;
}
