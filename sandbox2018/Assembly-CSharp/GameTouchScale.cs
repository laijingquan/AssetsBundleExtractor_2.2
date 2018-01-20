using System;
using System.Collections;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200016F RID: 367
public class GameTouchScale : MonoBehaviour
{
	// Token: 0x06000990 RID: 2448 RVA: 0x00029314 File Offset: 0x00027714
	private void OnEnable()
	{
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_PinchIn += this.On_PinchIn;
		EasyTouch.On_PinchOut += this.On_PinchOut;
		EasyTouch.On_PinchEnd += this.On_PinchEnd;
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x00029365 File Offset: 0x00027765
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x0002936D File Offset: 0x0002776D
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x00029378 File Offset: 0x00027778
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_PinchIn -= this.On_PinchIn;
		EasyTouch.On_PinchOut -= this.On_PinchOut;
		EasyTouch.On_PinchEnd -= this.On_PinchEnd;
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x000293C9 File Offset: 0x000277C9
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			EasyTouch.SetEnableTwist(false);
			EasyTouch.SetEnablePinch(true);
			GameManager.Instance.gameTouchLayer.SetDragEnabled(false);
		}
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x00029400 File Offset: 0x00027800
	private void On_PinchIn(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			float num = Time.deltaTime * gesture.deltaPinch * 0.6f;
			GameManager.Instance.levelManager.UpdateTouchZoom(-num);
		}
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x00029448 File Offset: 0x00027848
	private void On_PinchOut(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			GameManager.Instance.levelManager.isFirstTouch = true;
			float zoom = Time.deltaTime * gesture.deltaPinch * 0.6f;
			GameManager.Instance.levelManager.UpdateTouchZoom(zoom);
		}
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x0002949E File Offset: 0x0002789E
	private void On_PinchEnd(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			EasyTouch.SetEnableTwist(true);
			base.StartCoroutine(this.DelayTouchEnabled());
		}
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x000294CC File Offset: 0x000278CC
	private IEnumerator DelayTouchEnabled()
	{
		yield return new WaitForSeconds(0.1f);
		GameManager.Instance.gameTouchLayer.SetDragEnabled(true);
		yield break;
	}
}
