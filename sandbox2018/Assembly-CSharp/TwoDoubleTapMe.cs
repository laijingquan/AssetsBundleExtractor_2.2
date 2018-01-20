using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200003A RID: 58
public class TwoDoubleTapMe : MonoBehaviour
{
	// Token: 0x060001F7 RID: 503 RVA: 0x00009DBB File Offset: 0x000081BB
	private void OnEnable()
	{
		EasyTouch.On_DoubleTap2Fingers += this.On_DoubleTap2Fingers;
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00009DCE File Offset: 0x000081CE
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00009DD6 File Offset: 0x000081D6
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00009DDE File Offset: 0x000081DE
	private void UnsubscribeEvent()
	{
		EasyTouch.On_DoubleTap2Fingers -= this.On_DoubleTap2Fingers;
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00009DF4 File Offset: 0x000081F4
	private void On_DoubleTap2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}
}
