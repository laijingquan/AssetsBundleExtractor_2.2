using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200002A RID: 42
public class RTSCamera : MonoBehaviour
{
	// Token: 0x0600018C RID: 396 RVA: 0x000089FC File Offset: 0x00006DFC
	private void OnEnable()
	{
		EasyTouch.On_Swipe += this.On_Swipe;
		EasyTouch.On_Drag += this.On_Drag;
		EasyTouch.On_Twist += this.On_Twist;
		EasyTouch.On_Pinch += this.On_Pinch;
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00008A4D File Offset: 0x00006E4D
	private void On_Twist(Gesture gesture)
	{
		base.transform.Rotate(Vector3.up * gesture.twistAngle);
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00008A6A File Offset: 0x00006E6A
	private void OnDestroy()
	{
		EasyTouch.On_Swipe -= this.On_Swipe;
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_Twist -= this.On_Twist;
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00008A9F File Offset: 0x00006E9F
	private void On_Drag(Gesture gesture)
	{
		this.On_Swipe(gesture);
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00008AA8 File Offset: 0x00006EA8
	private void On_Swipe(Gesture gesture)
	{
		base.transform.Translate(Vector3.left * gesture.deltaPosition.x / (float)Screen.width);
		base.transform.Translate(Vector3.back * gesture.deltaPosition.y / (float)Screen.height);
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00008B0B File Offset: 0x00006F0B
	private void On_Pinch(Gesture gesture)
	{
		Camera.main.fieldOfView += gesture.deltaPinch * Time.deltaTime;
	}

	// Token: 0x040000BA RID: 186
	private Vector3 delta;
}
