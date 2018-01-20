using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001AB RID: 427
public class Simple3D2 : MonoBehaviour
{
	// Token: 0x06000AF1 RID: 2801 RVA: 0x0002FDEC File Offset: 0x0002E1EC
	private void Start()
	{
		List<Vector3> points = VectorLine.BytesToVector3List(this.vectorCube.bytes);
		VectorLine line = new VectorLine(base.gameObject.name, points, 2f);
		VectorManager.ObjectSetup(base.gameObject, line, Visibility.Dynamic, Brightness.None);
	}

	// Token: 0x04000658 RID: 1624
	public TextAsset vectorCube;
}
