using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000175 RID: 373
public class ScrollViewFitHeight : MonoBehaviour
{
	// Token: 0x060009D4 RID: 2516 RVA: 0x0002A848 File Offset: 0x00028C48
	private void Start()
	{
		this._aspectRatioFitter = base.transform.GetComponent<AspectRatioFitter>();
		if (this._aspectRatioFitter != null)
		{
			float aspectRadio = ComibilityHelper.GetAspectRadio();
			float num = 1f;
			if (ComibilityHelper.IsWideScreen())
			{
				num = 1.05f;
			}
			this._aspectRatioFitter.aspectRatio = this._aspectRatioFitter.aspectRatio * aspectRadio * num;
		}
	}

	// Token: 0x040005F9 RID: 1529
	private AspectRatioFitter _aspectRatioFitter;
}
