using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B4 RID: 436
public class Ellipse2 : MonoBehaviour
{
	// Token: 0x06000B13 RID: 2835 RVA: 0x00031A08 File Offset: 0x0002FE08
	private void Start()
	{
		List<Vector2> points = new List<Vector2>(this.segments * 2 * this.numberOfEllipses);
		VectorLine vectorLine = new VectorLine("Line", points, this.lineTexture, 3f);
		for (int i = 0; i < this.numberOfEllipses; i++)
		{
			Vector2 v = new Vector2((float)UnityEngine.Random.Range(0, Screen.width), (float)UnityEngine.Random.Range(0, Screen.height));
			vectorLine.MakeEllipse(v, (float)UnityEngine.Random.Range(10, Screen.width / 2), (float)UnityEngine.Random.Range(10, Screen.height / 2), this.segments, i * (this.segments * 2));
		}
		vectorLine.Draw();
	}

	// Token: 0x0400069D RID: 1693
	public Texture lineTexture;

	// Token: 0x0400069E RID: 1694
	public int segments = 60;

	// Token: 0x0400069F RID: 1695
	public int numberOfEllipses = 10;
}
