using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B2 RID: 434
public class DrawLinesTouch : MonoBehaviour
{
	// Token: 0x06000B0E RID: 2830 RVA: 0x00031780 File Offset: 0x0002FB80
	private void Start()
	{
		Texture2D texture;
		float width;
		if (this.useEndCap)
		{
			VectorLine.SetEndCap("RoundCap", EndCap.Mirror, new Texture2D[]
			{
				this.capLineTex,
				this.capTex
			});
			texture = this.capLineTex;
			width = this.capLineWidth;
		}
		else
		{
			texture = this.lineTex;
			width = this.lineWidth;
		}
		this.line = new VectorLine("DrawnLine", new List<Vector2>(), texture, width, LineType.Continuous, Joins.Weld);
		this.line.endPointsUpdate = 2;
		if (this.useEndCap)
		{
			this.line.endCap = "RoundCap";
		}
		this.sqrMinPixelMove = this.minPixelMove * this.minPixelMove;
	}

	// Token: 0x06000B0F RID: 2831 RVA: 0x00031830 File Offset: 0x0002FC30
	private void Update()
	{
		if (Input.touchCount > 0)
		{
			this.touch = Input.GetTouch(0);
			if (this.touch.phase == TouchPhase.Began)
			{
				this.line.points2.Clear();
				this.line.Draw();
				this.previousPosition = this.touch.position;
				this.line.points2.Add(this.touch.position);
				this.canDraw = true;
			}
			else if (this.touch.phase == TouchPhase.Moved && (this.touch.position - this.previousPosition).sqrMagnitude > (float)this.sqrMinPixelMove && this.canDraw)
			{
				this.previousPosition = this.touch.position;
				this.line.points2.Add(this.touch.position);
				if (this.line.points2.Count >= this.maxPoints)
				{
					this.canDraw = false;
				}
				this.line.Draw();
			}
		}
	}

	// Token: 0x0400068B RID: 1675
	public Texture2D lineTex;

	// Token: 0x0400068C RID: 1676
	public int maxPoints = 5000;

	// Token: 0x0400068D RID: 1677
	public float lineWidth = 4f;

	// Token: 0x0400068E RID: 1678
	public int minPixelMove = 5;

	// Token: 0x0400068F RID: 1679
	public bool useEndCap;

	// Token: 0x04000690 RID: 1680
	public Texture2D capLineTex;

	// Token: 0x04000691 RID: 1681
	public Texture2D capTex;

	// Token: 0x04000692 RID: 1682
	public float capLineWidth = 20f;

	// Token: 0x04000693 RID: 1683
	private VectorLine line;

	// Token: 0x04000694 RID: 1684
	private Vector2 previousPosition;

	// Token: 0x04000695 RID: 1685
	private int sqrMinPixelMove;

	// Token: 0x04000696 RID: 1686
	private bool canDraw;

	// Token: 0x04000697 RID: 1687
	private Touch touch;
}
