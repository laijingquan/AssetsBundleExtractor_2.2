using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001CC RID: 460
public class SplineFollow3D : MonoBehaviour
{
	// Token: 0x06000B69 RID: 2921 RVA: 0x000347BC File Offset: 0x00032BBC
	private IEnumerator Start()
	{
		List<Vector3> splinePoints = new List<Vector3>();
		int i = 1;
		object arg = "Sphere";
		int num;
		i = (num = i) + 1;
		GameObject obj = GameObject.Find(arg + num);
		while (obj != null)
		{
			splinePoints.Add(obj.transform.position);
			object arg2 = "Sphere";
			i = (num = i) + 1;
			obj = GameObject.Find(arg2 + num);
		}
		VectorLine line = new VectorLine("Spline", new List<Vector3>(this.segments + 1), 2f, LineType.Continuous);
		line.MakeSpline(splinePoints.ToArray(), this.segments, this.doLoop);
		line.Draw3D();
		do
		{
			for (float dist = 0f; dist < 1f; dist += Time.deltaTime * this.speed)
			{
				this.cube.position = line.GetPoint3D01(dist);
				yield return null;
			}
		}
		while (this.doLoop);
		yield break;
	}

	// Token: 0x04000718 RID: 1816
	public int segments = 250;

	// Token: 0x04000719 RID: 1817
	public bool doLoop = true;

	// Token: 0x0400071A RID: 1818
	public Transform cube;

	// Token: 0x0400071B RID: 1819
	public float speed = 0.05f;
}
