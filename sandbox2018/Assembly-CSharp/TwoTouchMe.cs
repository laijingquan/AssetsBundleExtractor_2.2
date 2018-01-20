using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200003F RID: 63
public class TwoTouchMe : MonoBehaviour
{
	// Token: 0x06000222 RID: 546 RVA: 0x0000A4AC File Offset: 0x000088AC
	private void OnEnable()
	{
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers += this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers += this.On_TouchUp2Fingers;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x06000223 RID: 547 RVA: 0x0000A4FD File Offset: 0x000088FD
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000224 RID: 548 RVA: 0x0000A505 File Offset: 0x00008905
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000225 RID: 549 RVA: 0x0000A510 File Offset: 0x00008910
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers -= this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers -= this.On_TouchUp2Fingers;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x06000226 RID: 550 RVA: 0x0000A561 File Offset: 0x00008961
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
		this.startColor = base.gameObject.GetComponent<Renderer>().material.color;
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0000A58A File Offset: 0x0000898A
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.RandomColor();
		}
	}

	// Token: 0x06000228 RID: 552 RVA: 0x0000A5A8 File Offset: 0x000089A8
	private void On_TouchDown2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.textMesh.text = "Down since :" + gesture.actionTime.ToString("f2");
		}
	}

	// Token: 0x06000229 RID: 553 RVA: 0x0000A5E8 File Offset: 0x000089E8
	private void On_TouchUp2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = this.startColor;
			this.textMesh.text = "Touch me";
		}
	}

	// Token: 0x0600022A RID: 554 RVA: 0x0000A636 File Offset: 0x00008A36
	private void On_Cancel2Fingers(Gesture gesture)
	{
		this.On_TouchUp2Fingers(gesture);
	}

	// Token: 0x0600022B RID: 555 RVA: 0x0000A640 File Offset: 0x00008A40
	private void RandomColor()
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
	}

	// Token: 0x040000DE RID: 222
	private TextMesh textMesh;

	// Token: 0x040000DF RID: 223
	private Color startColor;
}
