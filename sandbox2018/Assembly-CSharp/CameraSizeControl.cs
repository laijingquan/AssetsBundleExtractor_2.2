using System;
using UnityEngine;

// Token: 0x0200018B RID: 395
public class CameraSizeControl : MonoBehaviour
{
	// Token: 0x170000AD RID: 173
	// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0002CBC3 File Offset: 0x0002AFC3
	public float expectScreenWidth2
	{
		get
		{
			return this._expectScreenWidth2;
		}
	}

	// Token: 0x170000AE RID: 174
	// (get) Token: 0x06000A55 RID: 2645 RVA: 0x0002CBCB File Offset: 0x0002AFCB
	public float expectScreenHeight2
	{
		get
		{
			return this._expectScreenHeight2;
		}
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x0002CBD4 File Offset: 0x0002AFD4
	public void Init()
	{
		float num = (float)Screen.width / (float)Screen.height;
		Camera component = base.GetComponent<Camera>();
		this._expectScreenWidth2 = component.orthographicSize / this.designAspectHeight * this.designAspectWidth;
		this._expectScreenHeight2 = this._expectScreenWidth2 / num;
		component.orthographicSize = this._expectScreenHeight2;
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x0002CC2A File Offset: 0x0002B02A
	private void Update()
	{
	}

	// Token: 0x0400062E RID: 1582
	public float designAspectWidth = 16f;

	// Token: 0x0400062F RID: 1583
	public float designAspectHeight = 9f;

	// Token: 0x04000630 RID: 1584
	private float _expectScreenWidth2;

	// Token: 0x04000631 RID: 1585
	private float _expectScreenHeight2;
}
