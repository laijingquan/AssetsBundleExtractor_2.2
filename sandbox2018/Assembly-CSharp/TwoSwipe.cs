using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200003D RID: 61
public class TwoSwipe : MonoBehaviour
{
	// Token: 0x06000213 RID: 531 RVA: 0x0000A2C4 File Offset: 0x000086C4
	private void OnEnable()
	{
		EasyTouch.On_SwipeStart2Fingers += this.On_SwipeStart2Fingers;
		EasyTouch.On_Swipe2Fingers += this.On_Swipe2Fingers;
		EasyTouch.On_SwipeEnd2Fingers += this.On_SwipeEnd2Fingers;
	}

	// Token: 0x06000214 RID: 532 RVA: 0x0000A2F9 File Offset: 0x000086F9
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000215 RID: 533 RVA: 0x0000A301 File Offset: 0x00008701
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000216 RID: 534 RVA: 0x0000A309 File Offset: 0x00008709
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SwipeStart2Fingers -= this.On_SwipeStart2Fingers;
		EasyTouch.On_Swipe2Fingers -= this.On_Swipe2Fingers;
		EasyTouch.On_SwipeEnd2Fingers -= this.On_SwipeEnd2Fingers;
	}

	// Token: 0x06000217 RID: 535 RVA: 0x0000A33E File Offset: 0x0000873E
	private void On_SwipeStart2Fingers(Gesture gesture)
	{
		this.swipeData.text = "You start a swipe";
	}

	// Token: 0x06000218 RID: 536 RVA: 0x0000A350 File Offset: 0x00008750
	private void On_Swipe2Fingers(Gesture gesture)
	{
		Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(5f);
		this.trail.transform.position = touchToWorldPoint;
	}

	// Token: 0x06000219 RID: 537 RVA: 0x0000A37C File Offset: 0x0000877C
	private void On_SwipeEnd2Fingers(Gesture gesture)
	{
		float swipeOrDragAngle = gesture.GetSwipeOrDragAngle();
		this.swipeData.text = string.Concat(new object[]
		{
			"Last swipe : ",
			gesture.swipe.ToString(),
			" /  vector : ",
			gesture.swipeVector.normalized,
			" / angle : ",
			swipeOrDragAngle.ToString("f2")
		});
	}

	// Token: 0x040000DC RID: 220
	public GameObject trail;

	// Token: 0x040000DD RID: 221
	public Text swipeData;
}
