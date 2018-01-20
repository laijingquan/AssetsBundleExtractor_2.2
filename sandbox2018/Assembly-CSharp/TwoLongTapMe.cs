using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class TwoLongTapMe : MonoBehaviour
{
	// Token: 0x06000208 RID: 520 RVA: 0x0000A0E0 File Offset: 0x000084E0
	private void OnEnable()
	{
		EasyTouch.On_LongTapStart2Fingers += this.On_LongTapStart2Fingers;
		EasyTouch.On_LongTap2Fingers += this.On_LongTap2Fingers;
		EasyTouch.On_LongTapEnd2Fingers += this.On_LongTapEnd2Fingers;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0000A131 File Offset: 0x00008531
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600020A RID: 522 RVA: 0x0000A139 File Offset: 0x00008539
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0000A144 File Offset: 0x00008544
	private void UnsubscribeEvent()
	{
		EasyTouch.On_LongTapStart2Fingers -= this.On_LongTapStart2Fingers;
		EasyTouch.On_LongTap2Fingers -= this.On_LongTap2Fingers;
		EasyTouch.On_LongTapEnd2Fingers -= this.On_LongTapEnd2Fingers;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0000A195 File Offset: 0x00008595
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
		this.startColor = base.gameObject.GetComponent<Renderer>().material.color;
	}

	// Token: 0x0600020D RID: 525 RVA: 0x0000A1BE File Offset: 0x000085BE
	private void On_LongTapStart2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.RandomColor();
		}
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0000A1DC File Offset: 0x000085DC
	private void On_LongTap2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.textMesh.text = gesture.actionTime.ToString("f2");
		}
	}

	// Token: 0x0600020F RID: 527 RVA: 0x0000A210 File Offset: 0x00008610
	private void On_LongTapEnd2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = this.startColor;
			this.textMesh.text = "Long tap me";
		}
	}

	// Token: 0x06000210 RID: 528 RVA: 0x0000A25E File Offset: 0x0000865E
	private void On_Cancel2Fingers(Gesture gesture)
	{
		this.On_LongTapEnd2Fingers(gesture);
	}

	// Token: 0x06000211 RID: 529 RVA: 0x0000A268 File Offset: 0x00008668
	private void RandomColor()
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
	}

	// Token: 0x040000DA RID: 218
	private TextMesh textMesh;

	// Token: 0x040000DB RID: 219
	private Color startColor;
}
