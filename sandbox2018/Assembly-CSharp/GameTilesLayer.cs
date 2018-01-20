using System;
using UnityEngine;

// Token: 0x02000165 RID: 357
public class GameTilesLayer : MonoBehaviour
{
	// Token: 0x06000934 RID: 2356 RVA: 0x000278A1 File Offset: 0x00025CA1
	public void Init()
	{
		base.transform.localScale = Vector2.one;
		base.transform.localPosition = Vector2.zero;
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x000278CD File Offset: 0x00025CCD
	public void LayerScale(float scale)
	{
		base.transform.localScale = new Vector3(scale, scale, 1f);
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x000278E6 File Offset: 0x00025CE6
	public void SetVisible(bool isVisible)
	{
		base.gameObject.SetActive(isVisible);
	}
}
