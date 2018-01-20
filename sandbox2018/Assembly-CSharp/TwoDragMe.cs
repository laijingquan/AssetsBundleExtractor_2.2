using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200003B RID: 59
public class TwoDragMe : MonoBehaviour
{
	// Token: 0x060001FD RID: 509 RVA: 0x00009E68 File Offset: 0x00008268
	private void OnEnable()
	{
		EasyTouch.On_DragStart2Fingers += this.On_DragStart2Fingers;
		EasyTouch.On_Drag2Fingers += this.On_Drag2Fingers;
		EasyTouch.On_DragEnd2Fingers += this.On_DragEnd2Fingers;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x060001FE RID: 510 RVA: 0x00009EB9 File Offset: 0x000082B9
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001FF RID: 511 RVA: 0x00009EC1 File Offset: 0x000082C1
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00009ECC File Offset: 0x000082CC
	private void UnsubscribeEvent()
	{
		EasyTouch.On_DragStart2Fingers -= this.On_DragStart2Fingers;
		EasyTouch.On_Drag2Fingers -= this.On_Drag2Fingers;
		EasyTouch.On_DragEnd2Fingers -= this.On_DragEnd2Fingers;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x06000201 RID: 513 RVA: 0x00009F1D File Offset: 0x0000831D
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
		this.startColor = base.gameObject.GetComponent<Renderer>().material.color;
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00009F48 File Offset: 0x00008348
	private void On_DragStart2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.RandomColor();
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			this.deltaPosition = touchToWorldPoint - base.transform.position;
		}
	}

	// Token: 0x06000203 RID: 515 RVA: 0x00009FA0 File Offset: 0x000083A0
	private void On_Drag2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			base.transform.position = touchToWorldPoint - this.deltaPosition;
			float swipeOrDragAngle = gesture.GetSwipeOrDragAngle();
			this.textMesh.text = swipeOrDragAngle.ToString("f2") + " / " + gesture.swipe.ToString();
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0000A02C File Offset: 0x0000842C
	private void On_DragEnd2Fingers(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = this.startColor;
			this.textMesh.text = "Drag me";
		}
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0000A07A File Offset: 0x0000847A
	private void On_Cancel2Fingers(Gesture gesture)
	{
		this.On_DragEnd2Fingers(gesture);
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0000A084 File Offset: 0x00008484
	private void RandomColor()
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
	}

	// Token: 0x040000D7 RID: 215
	private TextMesh textMesh;

	// Token: 0x040000D8 RID: 216
	private Vector3 deltaPosition;

	// Token: 0x040000D9 RID: 217
	private Color startColor;
}
