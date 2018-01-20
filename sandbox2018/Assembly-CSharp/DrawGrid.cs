using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B6 RID: 438
public class DrawGrid : MonoBehaviour
{
	// Token: 0x06000B17 RID: 2839 RVA: 0x00031D3F File Offset: 0x0003013F
	private void Start()
	{
		this.gridLine = new VectorLine("Grid", new List<Vector2>(), 1f);
		this.gridLine.alignOddWidthToPixels = true;
		this.MakeGrid();
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x00031D70 File Offset: 0x00030170
	private void OnGUI()
	{
		GUI.Label(new Rect(10f, 10f, 30f, 20f), this.gridPixels.ToString());
		this.gridPixels = (int)GUI.HorizontalSlider(new Rect(40f, 15f, 590f, 20f), (float)this.gridPixels, 5f, 200f);
		if (GUI.changed)
		{
			this.MakeGrid();
		}
	}

	// Token: 0x06000B19 RID: 2841 RVA: 0x00031DF4 File Offset: 0x000301F4
	private void MakeGrid()
	{
		int newCount = (Screen.width / this.gridPixels + 1 + (Screen.height / this.gridPixels + 1)) * 2;
		this.gridLine.Resize(newCount);
		int num = 0;
		for (int i = 0; i < Screen.width; i += this.gridPixels)
		{
			this.gridLine.points2[num++] = new Vector2((float)i, 0f);
			this.gridLine.points2[num++] = new Vector2((float)i, (float)(Screen.height - 1));
		}
		for (int j = 0; j < Screen.height; j += this.gridPixels)
		{
			this.gridLine.points2[num++] = new Vector2(0f, (float)j);
			this.gridLine.points2[num++] = new Vector2((float)(Screen.width - 1), (float)j);
		}
		this.gridLine.Draw();
		this.gridLine.color = Color.green;
	}

	// Token: 0x040006A6 RID: 1702
	public int gridPixels = 50;

	// Token: 0x040006A7 RID: 1703
	private VectorLine gridLine;
}
