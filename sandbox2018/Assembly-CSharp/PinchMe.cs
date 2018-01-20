using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000037 RID: 55
public class PinchMe : MonoBehaviour
{
	// Token: 0x060001E0 RID: 480 RVA: 0x00009970 File Offset: 0x00007D70
	private void OnEnable()
	{
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_PinchIn += this.On_PinchIn;
		EasyTouch.On_PinchOut += this.On_PinchOut;
		EasyTouch.On_PinchEnd += this.On_PinchEnd;
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x000099C1 File Offset: 0x00007DC1
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x000099C9 File Offset: 0x00007DC9
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x000099D4 File Offset: 0x00007DD4
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_PinchIn -= this.On_PinchIn;
		EasyTouch.On_PinchOut -= this.On_PinchOut;
		EasyTouch.On_PinchEnd -= this.On_PinchEnd;
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00009A25 File Offset: 0x00007E25
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x00009A33 File Offset: 0x00007E33
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			EasyTouch.SetEnableTwist(false);
			EasyTouch.SetEnablePinch(true);
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00009A58 File Offset: 0x00007E58
	private void On_PinchIn(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			float num = Time.deltaTime * gesture.deltaPinch;
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = new Vector3(localScale.x - num, localScale.y - num, localScale.z - num);
			this.textMesh.text = "Delta pinch : " + gesture.deltaPinch.ToString();
		}
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00009AE8 File Offset: 0x00007EE8
	private void On_PinchOut(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			float num = Time.deltaTime * gesture.deltaPinch;
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = new Vector3(localScale.x + num, localScale.y + num, localScale.z + num);
			this.textMesh.text = "Delta pinch : " + gesture.deltaPinch.ToString();
		}
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x00009B78 File Offset: 0x00007F78
	private void On_PinchEnd(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
			EasyTouch.SetEnableTwist(true);
			this.textMesh.text = "Pinch me";
		}
	}

	// Token: 0x040000D5 RID: 213
	private TextMesh textMesh;
}
