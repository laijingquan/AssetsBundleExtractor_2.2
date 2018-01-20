using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000039 RID: 57
public class TwistMe : MonoBehaviour
{
	// Token: 0x060001ED RID: 493 RVA: 0x00009BFC File Offset: 0x00007FFC
	private void OnEnable()
	{
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_Twist += this.On_Twist;
		EasyTouch.On_TwistEnd += this.On_TwistEnd;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x00009C4D File Offset: 0x0000804D
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00009C55 File Offset: 0x00008055
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x00009C60 File Offset: 0x00008060
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_Twist -= this.On_Twist;
		EasyTouch.On_TwistEnd -= this.On_TwistEnd;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00009CB1 File Offset: 0x000080B1
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00009CBF File Offset: 0x000080BF
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			EasyTouch.SetEnableTwist(true);
			EasyTouch.SetEnablePinch(false);
		}
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00009CE4 File Offset: 0x000080E4
	private void On_Twist(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.transform.Rotate(new Vector3(0f, 0f, gesture.twistAngle));
			this.textMesh.text = "Delta angle : " + gesture.twistAngle.ToString();
		}
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00009D4D File Offset: 0x0000814D
	private void On_TwistEnd(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			EasyTouch.SetEnablePinch(true);
			base.transform.rotation = Quaternion.identity;
			this.textMesh.text = "Twist me";
		}
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00009D8B File Offset: 0x0000818B
	private void On_Cancel2Fingers(Gesture gesture)
	{
		EasyTouch.SetEnablePinch(true);
		base.transform.rotation = Quaternion.identity;
		this.textMesh.text = "Twist me";
	}

	// Token: 0x040000D6 RID: 214
	private TextMesh textMesh;
}
