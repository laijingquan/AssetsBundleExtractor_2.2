using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C9 RID: 457
public class SelectLine : MonoBehaviour
{
	// Token: 0x06000B60 RID: 2912 RVA: 0x0003425C File Offset: 0x0003265C
	private void Start()
	{
		this.lines = new VectorLine[this.numberOfLines];
		this.wasSelected = new bool[this.numberOfLines];
		for (int i = 0; i < this.numberOfLines; i++)
		{
			this.lines[i] = new VectorLine("SelectLine", new List<Vector2>(5), this.lineThickness, LineType.Continuous, Joins.Fill);
			this.SetPoints(i);
		}
	}

	// Token: 0x06000B61 RID: 2913 RVA: 0x000342CC File Offset: 0x000326CC
	private void SetPoints(int i)
	{
		for (int j = 0; j < this.lines[i].points2.Count; j++)
		{
			this.lines[i].points2[j] = new Vector2((float)UnityEngine.Random.Range(0, Screen.width), (float)UnityEngine.Random.Range(0, Screen.height - 20));
		}
		this.lines[i].Draw();
	}

	// Token: 0x06000B62 RID: 2914 RVA: 0x0003433C File Offset: 0x0003273C
	private void Update()
	{
		for (int i = 0; i < this.numberOfLines; i++)
		{
			int num;
			if (this.lines[i].Selected(Input.mousePosition, this.extraThickness, out num))
			{
				if (!this.wasSelected[i])
				{
					this.lines[i].SetColor(Color.green);
					this.wasSelected[i] = true;
				}
				if (Input.GetMouseButtonDown(0))
				{
					this.SetPoints(i);
				}
			}
			else if (this.wasSelected[i])
			{
				this.wasSelected[i] = false;
				this.lines[i].SetColor(Color.white);
			}
		}
	}

	// Token: 0x06000B63 RID: 2915 RVA: 0x000343F5 File Offset: 0x000327F5
	private void OnGUI()
	{
		GUI.Label(new Rect(10f, 10f, 800f, 30f), "Click a line to make a new line");
	}

	// Token: 0x0400070C RID: 1804
	public float lineThickness = 10f;

	// Token: 0x0400070D RID: 1805
	public int extraThickness = 2;

	// Token: 0x0400070E RID: 1806
	public int numberOfLines = 2;

	// Token: 0x0400070F RID: 1807
	private VectorLine[] lines;

	// Token: 0x04000710 RID: 1808
	private bool[] wasSelected;
}
