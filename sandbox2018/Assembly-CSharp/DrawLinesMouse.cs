using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B1 RID: 433
public class DrawLinesMouse : MonoBehaviour
{
	// Token: 0x06000B0A RID: 2826 RVA: 0x000314C4 File Offset: 0x0002F8C4
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
		if (this.line3D)
		{
			this.line = new VectorLine("DrawnLine3D", new List<Vector3>(), texture, width, LineType.Continuous, Joins.Weld);
		}
		else
		{
			this.line = new VectorLine("DrawnLine", new List<Vector2>(), texture, width, LineType.Continuous, Joins.Weld);
		}
		this.line.endPointsUpdate = 2;
		if (this.useEndCap)
		{
			this.line.endCap = "RoundCap";
		}
		this.sqrMinPixelMove = this.minPixelMove * this.minPixelMove;
	}

	// Token: 0x06000B0B RID: 2827 RVA: 0x0003159C File Offset: 0x0002F99C
	private void Update()
	{
		Vector3 mousePos = this.GetMousePos();
		if (Input.GetMouseButtonDown(0))
		{
			if (this.line3D)
			{
				this.line.points3.Clear();
				this.line.Draw3D();
			}
			else
			{
				this.line.points2.Clear();
				this.line.Draw();
			}
			this.previousPosition = Input.mousePosition;
			if (this.line3D)
			{
				this.line.points3.Add(mousePos);
			}
			else
			{
				this.line.points2.Add(mousePos);
			}
			this.canDraw = true;
		}
		else if (Input.GetMouseButton(0) && (Input.mousePosition - this.previousPosition).sqrMagnitude > (float)this.sqrMinPixelMove && this.canDraw)
		{
			this.previousPosition = Input.mousePosition;
			int count;
			if (this.line3D)
			{
				this.line.points3.Add(mousePos);
				count = this.line.points3.Count;
				this.line.Draw3D();
			}
			else
			{
				this.line.points2.Add(mousePos);
				count = this.line.points2.Count;
				this.line.Draw();
			}
			if (count >= this.maxPoints)
			{
				this.canDraw = false;
			}
		}
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x00031718 File Offset: 0x0002FB18
	private Vector3 GetMousePos()
	{
		Vector3 mousePosition = Input.mousePosition;
		if (this.line3D)
		{
			mousePosition.z = this.distanceFromCamera;
			return Camera.main.ScreenToWorldPoint(mousePosition);
		}
		return mousePosition;
	}

	// Token: 0x0400067D RID: 1661
	public Texture2D lineTex;

	// Token: 0x0400067E RID: 1662
	public int maxPoints = 5000;

	// Token: 0x0400067F RID: 1663
	public float lineWidth = 4f;

	// Token: 0x04000680 RID: 1664
	public int minPixelMove = 5;

	// Token: 0x04000681 RID: 1665
	public bool useEndCap;

	// Token: 0x04000682 RID: 1666
	public Texture2D capLineTex;

	// Token: 0x04000683 RID: 1667
	public Texture2D capTex;

	// Token: 0x04000684 RID: 1668
	public float capLineWidth = 20f;

	// Token: 0x04000685 RID: 1669
	public bool line3D;

	// Token: 0x04000686 RID: 1670
	public float distanceFromCamera = 1f;

	// Token: 0x04000687 RID: 1671
	private VectorLine line;

	// Token: 0x04000688 RID: 1672
	private Vector3 previousPosition;

	// Token: 0x04000689 RID: 1673
	private int sqrMinPixelMove;

	// Token: 0x0400068A RID: 1674
	private bool canDraw;
}
