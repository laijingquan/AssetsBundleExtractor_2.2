using System;
using UnityEngine;

// Token: 0x0200017E RID: 382
public class UILoadingPanel : MonoBehaviour
{
	// Token: 0x06000A00 RID: 2560 RVA: 0x0002B32B File Offset: 0x0002972B
	public void Init()
	{
		this._isLoading = true;
	}

	// Token: 0x06000A01 RID: 2561 RVA: 0x0002B334 File Offset: 0x00029734
	private void Update()
	{
		if (this._isLoading)
		{
			base.transform.Find("Image").transform.Rotate(new Vector3(0f, 0f, -1f), 2.5f);
		}
	}

	// Token: 0x04000615 RID: 1557
	private bool _isLoading;
}
