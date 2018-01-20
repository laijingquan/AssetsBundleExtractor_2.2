using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class TapMe : MonoBehaviour
{
	// Token: 0x060001D0 RID: 464 RVA: 0x0000971C File Offset: 0x00007B1C
	private void OnEnable()
	{
		EasyTouch.On_SimpleTap += this.On_SimpleTap;
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x0000972F File Offset: 0x00007B2F
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00009737 File Offset: 0x00007B37
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x0000973F File Offset: 0x00007B3F
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SimpleTap -= this.On_SimpleTap;
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x00009754 File Offset: 0x00007B54
	private void On_SimpleTap(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}
}
