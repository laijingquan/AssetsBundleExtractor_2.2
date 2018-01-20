using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B3 RID: 435
public class Ellipse1 : MonoBehaviour
{
	// Token: 0x06000B11 RID: 2833 RVA: 0x0003197C File Offset: 0x0002FD7C
	private void Start()
	{
		List<Vector2> points = new List<Vector2>(this.segments + 1);
		VectorLine vectorLine = new VectorLine("Line", points, this.lineTexture, 3f, LineType.Continuous);
		vectorLine.MakeEllipse(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), this.xRadius, this.yRadius, this.segments, this.pointRotation);
		vectorLine.Draw();
	}

	// Token: 0x04000698 RID: 1688
	public Texture lineTexture;

	// Token: 0x04000699 RID: 1689
	public float xRadius = 120f;

	// Token: 0x0400069A RID: 1690
	public float yRadius = 120f;

	// Token: 0x0400069B RID: 1691
	public int segments = 60;

	// Token: 0x0400069C RID: 1692
	public float pointRotation;
}
