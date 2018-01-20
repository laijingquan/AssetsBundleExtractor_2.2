using System;
using UnityEngine;

// Token: 0x020001BA RID: 442
public class RotateAroundY : MonoBehaviour
{
	// Token: 0x06000B2A RID: 2858 RVA: 0x00032A3F File Offset: 0x00030E3F
	private void Update()
	{
		base.transform.Rotate(Vector3.up * Time.deltaTime * this.rotateSpeed);
	}

	// Token: 0x040006C0 RID: 1728
	public float rotateSpeed = 10f;
}
