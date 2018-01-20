using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000026 RID: 38
public class MultiLayerUI : MonoBehaviour
{
	// Token: 0x06000177 RID: 375 RVA: 0x00008711 File Offset: 0x00006B11
	public void SetAutoSelect(bool value)
	{
		EasyTouch.SetEnableAutoSelect(value);
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00008719 File Offset: 0x00006B19
	public void SetAutoUpdate(bool value)
	{
		EasyTouch.SetAutoUpdatePickedObject(value);
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00008724 File Offset: 0x00006B24
	public void Layer1(bool value)
	{
		LayerMask mask = EasyTouch.Get3DPickableLayer();
		if (value)
		{
			mask |= 256;
		}
		else
		{
			mask = ~mask;
			mask = ~(mask | 256);
		}
		EasyTouch.Set3DPickableLayer(mask);
	}

	// Token: 0x0600017A RID: 378 RVA: 0x0000877C File Offset: 0x00006B7C
	public void Layer2(bool value)
	{
		LayerMask mask = EasyTouch.Get3DPickableLayer();
		if (value)
		{
			mask |= 512;
		}
		else
		{
			mask = ~mask;
			mask = ~(mask | 512);
		}
		EasyTouch.Set3DPickableLayer(mask);
	}

	// Token: 0x0600017B RID: 379 RVA: 0x000087D4 File Offset: 0x00006BD4
	public void Layer3(bool value)
	{
		LayerMask mask = EasyTouch.Get3DPickableLayer();
		if (value)
		{
			mask |= 1024;
		}
		else
		{
			mask = ~mask;
			mask = ~(mask | 1024);
		}
		EasyTouch.Set3DPickableLayer(mask);
	}
}
