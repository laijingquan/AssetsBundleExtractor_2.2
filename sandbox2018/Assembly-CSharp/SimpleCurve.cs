using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001AF RID: 431
public class SimpleCurve : MonoBehaviour
{
	// Token: 0x06000B01 RID: 2817 RVA: 0x00030F04 File Offset: 0x0002F304
	private void Start()
	{
		if (this.curvePoints.Length != 4)
		{
			Debug.Log("Curve points array must have 4 elements only");
			return;
		}
		List<Vector2> points = new List<Vector2>(this.segments + 1);
		VectorLine vectorLine = new VectorLine("Curve", points, 2f, LineType.Continuous, Joins.Weld);
		vectorLine.MakeCurve(this.curvePoints, this.segments);
		vectorLine.Draw();
	}

	// Token: 0x0400066F RID: 1647
	public Vector2[] curvePoints;

	// Token: 0x04000670 RID: 1648
	public int segments = 50;
}
