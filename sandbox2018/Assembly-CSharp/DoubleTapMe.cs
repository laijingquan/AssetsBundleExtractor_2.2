using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class DoubleTapMe : MonoBehaviour
{
	// Token: 0x060001AE RID: 430 RVA: 0x00009147 File Offset: 0x00007547
	private void OnEnable()
	{
		EasyTouch.On_DoubleTap += this.On_DoubleTap;
	}

	// Token: 0x060001AF RID: 431 RVA: 0x0000915A File Offset: 0x0000755A
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00009162 File Offset: 0x00007562
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0000916A File Offset: 0x0000756A
	private void UnsubscribeEvent()
	{
		EasyTouch.On_DoubleTap -= this.On_DoubleTap;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00009180 File Offset: 0x00007580
	private void On_DoubleTap(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}
}
