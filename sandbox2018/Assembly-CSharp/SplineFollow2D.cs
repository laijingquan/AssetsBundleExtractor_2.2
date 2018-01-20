using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001CB RID: 459
public class SplineFollow2D : MonoBehaviour
{
	// Token: 0x06000B67 RID: 2919 RVA: 0x00034550 File Offset: 0x00032950
	private IEnumerator Start()
	{
		List<Vector2> splinePoints = new List<Vector2>();
		int i = 1;
		object arg = "Sphere";
		int num;
		i = (num = i) + 1;
		GameObject obj = GameObject.Find(arg + num);
		while (obj != null)
		{
			splinePoints.Add(Camera.main.WorldToScreenPoint(obj.transform.position));
			object arg2 = "Sphere";
			i = (num = i) + 1;
			obj = GameObject.Find(arg2 + num);
		}
		VectorLine line = new VectorLine("Spline", new List<Vector2>(this.segments + 1), 2f, LineType.Continuous);
		line.MakeSpline(splinePoints.ToArray(), this.segments, this.loop);
		line.Draw();
		do
		{
			for (float dist = 0f; dist < 1f; dist += Time.deltaTime * this.speed)
			{
				Vector2 splinePoint = line.GetPoint01(dist);
				this.cube.position = Camera.main.ScreenToWorldPoint(new Vector3(splinePoint.x, splinePoint.y, 10f));
				yield return null;
			}
		}
		while (this.loop);
		yield break;
	}

	// Token: 0x04000714 RID: 1812
	public int segments = 250;

	// Token: 0x04000715 RID: 1813
	public bool loop = true;

	// Token: 0x04000716 RID: 1814
	public Transform cube;

	// Token: 0x04000717 RID: 1815
	public float speed = 0.05f;
}
