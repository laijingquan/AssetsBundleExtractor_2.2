using System;
using UnityEngine;

// Token: 0x020001BF RID: 447
public class RotateViewpoint : MonoBehaviour
{
	// Token: 0x06000B38 RID: 2872 RVA: 0x00032FEE File Offset: 0x000313EE
	private void Update()
	{
		base.transform.RotateAround(Vector3.zero, Vector3.right, this.rotateSpeed * Time.deltaTime);
	}

	// Token: 0x040006D6 RID: 1750
	public float rotateSpeed = 5f;
}
