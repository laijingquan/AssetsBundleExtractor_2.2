using System;
using UnityEngine;

// Token: 0x020001AD RID: 429
public class CurvePointControl : MonoBehaviour
{
	// Token: 0x06000AF5 RID: 2805 RVA: 0x000300F1 File Offset: 0x0002E4F1
	private void OnMouseDrag()
	{
		base.transform.position = DrawCurve.cam.ScreenToViewportPoint(Input.mousePosition);
		DrawCurve.use.UpdateLine(this.objectNumber, Input.mousePosition, base.gameObject);
	}

	// Token: 0x04000659 RID: 1625
	public int objectNumber;

	// Token: 0x0400065A RID: 1626
	public GameObject controlObject;

	// Token: 0x0400065B RID: 1627
	public GameObject controlObject2;
}
