using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000034 RID: 52
public class Swipe : MonoBehaviour
{
	// Token: 0x060001C8 RID: 456 RVA: 0x000095E4 File Offset: 0x000079E4
	private void OnEnable()
	{
		EasyTouch.On_SwipeStart += this.On_SwipeStart;
		EasyTouch.On_Swipe += this.On_Swipe;
		EasyTouch.On_SwipeEnd += this.On_SwipeEnd;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x00009619 File Offset: 0x00007A19
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001CA RID: 458 RVA: 0x00009621 File Offset: 0x00007A21
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001CB RID: 459 RVA: 0x00009629 File Offset: 0x00007A29
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SwipeStart -= this.On_SwipeStart;
		EasyTouch.On_Swipe -= this.On_Swipe;
		EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0000965E File Offset: 0x00007A5E
	private void On_SwipeStart(Gesture gesture)
	{
		this.swipeText.text = "You start a swipe";
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00009670 File Offset: 0x00007A70
	private void On_Swipe(Gesture gesture)
	{
		Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(5f);
		this.trail.transform.position = touchToWorldPoint;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0000969C File Offset: 0x00007A9C
	private void On_SwipeEnd(Gesture gesture)
	{
		float swipeOrDragAngle = gesture.GetSwipeOrDragAngle();
		this.swipeText.text = string.Concat(new object[]
		{
			"Last swipe : ",
			gesture.swipe.ToString(),
			" /  vector : ",
			gesture.swipeVector.normalized,
			" / angle : ",
			swipeOrDragAngle.ToString("f2")
		});
	}

	// Token: 0x040000D1 RID: 209
	public GameObject trail;

	// Token: 0x040000D2 RID: 210
	public Text swipeText;
}
