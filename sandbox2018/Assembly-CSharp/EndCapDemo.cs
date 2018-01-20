using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B5 RID: 437
public class EndCapDemo : MonoBehaviour
{
	// Token: 0x06000B15 RID: 2837 RVA: 0x00031AC0 File Offset: 0x0002FEC0
	private void Start()
	{
		VectorLine.SetEndCap("arrow", EndCap.Front, new Texture2D[]
		{
			this.lineTex,
			this.frontTex
		});
		VectorLine.SetEndCap("arrow2", EndCap.Both, new Texture2D[]
		{
			this.lineTex2,
			this.frontTex,
			this.backTex
		});
		VectorLine.SetEndCap("rounded", EndCap.Mirror, new Texture2D[]
		{
			this.lineTex3,
			this.capTex
		});
		VectorLine vectorLine = new VectorLine("Arrow", new List<Vector2>(50), 30f, LineType.Continuous, Joins.Weld);
		vectorLine.useViewportCoords = true;
		Vector2[] splinePoints = new Vector2[]
		{
			new Vector2(0.1f, 0.15f),
			new Vector2(0.3f, 0.5f),
			new Vector2(0.5f, 0.6f),
			new Vector2(0.7f, 0.5f),
			new Vector2(0.9f, 0.15f)
		};
		vectorLine.MakeSpline(splinePoints);
		vectorLine.endCap = "arrow";
		vectorLine.Draw();
		VectorLine vectorLine2 = new VectorLine("Arrow2", new List<Vector2>(50), 40f, LineType.Continuous, Joins.Weld);
		vectorLine2.useViewportCoords = true;
		splinePoints = new Vector2[]
		{
			new Vector2(0.1f, 0.85f),
			new Vector2(0.3f, 0.5f),
			new Vector2(0.5f, 0.4f),
			new Vector2(0.7f, 0.5f),
			new Vector2(0.9f, 0.85f)
		};
		vectorLine2.MakeSpline(splinePoints);
		vectorLine2.endCap = "arrow2";
		vectorLine2.continuousTexture = true;
		vectorLine2.Draw();
		new VectorLine("Rounded", new List<Vector2>
		{
			new Vector2(0.1f, 0.5f),
			new Vector2(0.9f, 0.5f)
		}, 20f)
		{
			useViewportCoords = true,
			endCap = "rounded"
		}.Draw();
	}

	// Token: 0x040006A0 RID: 1696
	public Texture2D lineTex;

	// Token: 0x040006A1 RID: 1697
	public Texture2D lineTex2;

	// Token: 0x040006A2 RID: 1698
	public Texture2D lineTex3;

	// Token: 0x040006A3 RID: 1699
	public Texture2D frontTex;

	// Token: 0x040006A4 RID: 1700
	public Texture2D backTex;

	// Token: 0x040006A5 RID: 1701
	public Texture2D capTex;
}
