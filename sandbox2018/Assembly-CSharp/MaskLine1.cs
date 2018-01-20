using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001BB RID: 443
public class MaskLine1 : MonoBehaviour
{
	// Token: 0x06000B2C RID: 2860 RVA: 0x00032A8C File Offset: 0x00030E8C
	private void Start()
	{
		this.rectLine = new VectorLine("Rects", new List<Vector3>(this.numberOfRects * 8), 2f);
		int num = 0;
		for (int i = 0; i < this.numberOfRects; i++)
		{
			this.rectLine.MakeRect(new Rect(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(0.25f, 3f), UnityEngine.Random.Range(0.25f, 2f)), num);
			num += 8;
		}
		this.rectLine.color = this.lineColor;
		this.rectLine.capLength = 1f;
		this.rectLine.drawTransform = base.transform;
		this.rectLine.SetMask(this.mask);
		this.startPos = base.transform.position;
	}

	// Token: 0x06000B2D RID: 2861 RVA: 0x00032B80 File Offset: 0x00030F80
	private void Update()
	{
		this.t = Mathf.Repeat(this.t + Time.deltaTime * this.moveSpeed, 360f);
		base.transform.position = new Vector2(this.startPos.x + Mathf.Sin(this.t) * 1.5f, this.startPos.y + Mathf.Cos(this.t) * 1.5f);
		this.rectLine.Draw();
	}

	// Token: 0x040006C1 RID: 1729
	public int numberOfRects = 30;

	// Token: 0x040006C2 RID: 1730
	public Color lineColor = Color.green;

	// Token: 0x040006C3 RID: 1731
	public GameObject mask;

	// Token: 0x040006C4 RID: 1732
	public float moveSpeed = 2f;

	// Token: 0x040006C5 RID: 1733
	private VectorLine rectLine;

	// Token: 0x040006C6 RID: 1734
	private float t;

	// Token: 0x040006C7 RID: 1735
	private Vector3 startPos;
}
