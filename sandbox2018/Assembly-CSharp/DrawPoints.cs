using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C2 RID: 450
public class DrawPoints : MonoBehaviour
{
	// Token: 0x06000B43 RID: 2883 RVA: 0x00033550 File Offset: 0x00031950
	private void Start()
	{
		int num = this.numberOfDots * this.numberOfRings;
		Vector2[] collection = new Vector2[num];
		Color32[] array = new Color32[num];
		float b = 1f - 0.75f / (float)num;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = this.dotColor;
			this.dotColor *= b;
		}
		VectorLine vectorLine = new VectorLine("Dots", new List<Vector2>(collection), this.dotSize, LineType.Points);
		vectorLine.SetColors(new List<Color32>(array));
		for (int j = 0; j < this.numberOfRings; j++)
		{
			vectorLine.MakeCircle(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), (float)(Screen.height / (j + 2)), this.numberOfDots, this.numberOfDots * j);
		}
		vectorLine.Draw();
	}

	// Token: 0x040006E7 RID: 1767
	public float dotSize = 2f;

	// Token: 0x040006E8 RID: 1768
	public int numberOfDots = 100;

	// Token: 0x040006E9 RID: 1769
	public int numberOfRings = 8;

	// Token: 0x040006EA RID: 1770
	public Color dotColor = Color.cyan;
}
