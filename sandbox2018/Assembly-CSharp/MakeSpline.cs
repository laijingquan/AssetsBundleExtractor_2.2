using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001CA RID: 458
public class MakeSpline : MonoBehaviour
{
	// Token: 0x06000B65 RID: 2917 RVA: 0x00034434 File Offset: 0x00032834
	private void Start()
	{
		List<Vector3> list = new List<Vector3>();
		int num = 1;
		GameObject gameObject = GameObject.Find("Sphere" + num++);
		while (gameObject != null)
		{
			list.Add(gameObject.transform.position);
			gameObject = GameObject.Find("Sphere" + num++);
		}
		if (this.usePoints)
		{
			VectorLine vectorLine = new VectorLine("Spline", new List<Vector3>(this.segments + 1), 2f, LineType.Points);
			vectorLine.MakeSpline(list.ToArray(), this.segments, this.loop);
			vectorLine.Draw();
		}
		else
		{
			VectorLine vectorLine2 = new VectorLine("Spline", new List<Vector3>(this.segments + 1), 2f, LineType.Continuous);
			vectorLine2.MakeSpline(list.ToArray(), this.segments, this.loop);
			vectorLine2.Draw3D();
		}
	}

	// Token: 0x04000711 RID: 1809
	public int segments = 250;

	// Token: 0x04000712 RID: 1810
	public bool loop = true;

	// Token: 0x04000713 RID: 1811
	public bool usePoints;
}
