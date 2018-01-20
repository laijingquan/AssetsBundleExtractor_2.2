using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001BC RID: 444
public class MaskLine2 : MonoBehaviour
{
	// Token: 0x06000B2F RID: 2863 RVA: 0x00032C3C File Offset: 0x0003103C
	private void Start()
	{
		this.spikeLine = new VectorLine("SpikeLine", new List<Vector3>(this.numberOfPoints), 2f, LineType.Continuous);
		float num = this.lineHeight / 2f;
		for (int i = 0; i < this.numberOfPoints; i++)
		{
			this.spikeLine.points3[i] = new Vector2(UnityEngine.Random.Range(-this.lineWidth / 2f, this.lineWidth / 2f), num);
			num -= this.lineHeight / (float)this.numberOfPoints;
		}
		this.spikeLine.color = this.lineColor;
		this.spikeLine.drawTransform = base.transform;
		this.spikeLine.SetMask(this.mask);
		this.startPos = base.transform.position;
	}

	// Token: 0x06000B30 RID: 2864 RVA: 0x00032D24 File Offset: 0x00031124
	private void Update()
	{
		this.t = Mathf.Repeat(this.t + Time.deltaTime, 360f);
		base.transform.position = new Vector2(this.startPos.x, this.startPos.y + Mathf.Cos(this.t) * 4f);
		this.spikeLine.Draw();
	}

	// Token: 0x040006C8 RID: 1736
	public int numberOfPoints = 100;

	// Token: 0x040006C9 RID: 1737
	public Color lineColor = Color.yellow;

	// Token: 0x040006CA RID: 1738
	public GameObject mask;

	// Token: 0x040006CB RID: 1739
	public float lineWidth = 9f;

	// Token: 0x040006CC RID: 1740
	public float lineHeight = 17f;

	// Token: 0x040006CD RID: 1741
	private VectorLine spikeLine;

	// Token: 0x040006CE RID: 1742
	private float t;

	// Token: 0x040006CF RID: 1743
	private Vector3 startPos;
}
