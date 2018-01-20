using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001BE RID: 446
public class Orbit : MonoBehaviour
{
	// Token: 0x06000B35 RID: 2869 RVA: 0x00032F28 File Offset: 0x00031328
	private void Start()
	{
		VectorLine vectorLine = new VectorLine("OrbitLine", new List<Vector3>(this.orbitLineResolution), 2f, LineType.Continuous);
		vectorLine.material = this.lineMaterial;
		vectorLine.MakeCircle(Vector3.zero, Vector3.up, Vector3.Distance(base.transform.position, Vector3.zero));
		vectorLine.Draw3DAuto();
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x00032F88 File Offset: 0x00031388
	private void Update()
	{
		base.transform.RotateAround(Vector3.zero, Vector3.up, this.orbitSpeed * Time.deltaTime);
		base.transform.Rotate(Vector3.up * this.rotateSpeed * Time.deltaTime);
	}

	// Token: 0x040006D2 RID: 1746
	public float orbitSpeed = -45f;

	// Token: 0x040006D3 RID: 1747
	public float rotateSpeed = 200f;

	// Token: 0x040006D4 RID: 1748
	public int orbitLineResolution = 150;

	// Token: 0x040006D5 RID: 1749
	public Material lineMaterial;
}
