using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200003E RID: 62
public class TwoTapMe : MonoBehaviour
{
	// Token: 0x0600021B RID: 539 RVA: 0x0000A3FC File Offset: 0x000087FC
	private void OnEnable()
	{
		EasyTouch.On_SimpleTap2Fingers += this.On_SimpleTap2Fingers;
	}

	// Token: 0x0600021C RID: 540 RVA: 0x0000A40F File Offset: 0x0000880F
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600021D RID: 541 RVA: 0x0000A417 File Offset: 0x00008817
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600021E RID: 542 RVA: 0x0000A41F File Offset: 0x0000881F
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SimpleTap2Fingers -= this.On_SimpleTap2Fingers;
	}

	// Token: 0x0600021F RID: 543 RVA: 0x0000A432 File Offset: 0x00008832
	private void On_SimpleTap2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.RandomColor();
		}
	}

	// Token: 0x06000220 RID: 544 RVA: 0x0000A450 File Offset: 0x00008850
	private void RandomColor()
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
	}
}
