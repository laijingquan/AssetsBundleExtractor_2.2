using System;
using UnityEngine;

// Token: 0x020001C5 RID: 453
public class CameraZoom : MonoBehaviour
{
	// Token: 0x06000B4E RID: 2894 RVA: 0x00033B6C File Offset: 0x00031F6C
	private void Update()
	{
		base.transform.Translate(Vector3.forward * this.zoomSpeed * Input.GetAxis("Mouse ScrollWheel"));
		base.transform.Translate(Vector3.forward * this.keyZoomSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
	}

	// Token: 0x040006FB RID: 1787
	public float zoomSpeed = 10f;

	// Token: 0x040006FC RID: 1788
	public float keyZoomSpeed = 20f;
}
