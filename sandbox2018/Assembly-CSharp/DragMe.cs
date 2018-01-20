using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000032 RID: 50
public class DragMe : MonoBehaviour
{
	// Token: 0x060001B4 RID: 436 RVA: 0x000091F2 File Offset: 0x000075F2
	private void OnEnable()
	{
		EasyTouch.On_Drag += this.On_Drag;
		EasyTouch.On_DragStart += this.On_DragStart;
		EasyTouch.On_DragEnd += this.On_DragEnd;
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x00009227 File Offset: 0x00007627
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x0000922F File Offset: 0x0000762F
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00009237 File Offset: 0x00007637
	private void UnsubscribeEvent()
	{
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_DragStart -= this.On_DragStart;
		EasyTouch.On_DragEnd -= this.On_DragEnd;
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0000926C File Offset: 0x0000766C
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
		this.startColor = base.gameObject.GetComponent<Renderer>().material.color;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00009298 File Offset: 0x00007698
	private void On_DragStart(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.fingerIndex = gesture.fingerIndex;
			this.RandomColor();
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			this.deltaPosition = touchToWorldPoint - base.transform.position;
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x000092FC File Offset: 0x000076FC
	private void On_Drag(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject && this.fingerIndex == gesture.fingerIndex)
		{
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			base.transform.position = touchToWorldPoint - this.deltaPosition;
			float swipeOrDragAngle = gesture.GetSwipeOrDragAngle();
			this.textMesh.text = swipeOrDragAngle.ToString("f2") + " / " + gesture.swipe.ToString();
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00009398 File Offset: 0x00007798
	private void On_DragEnd(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = this.startColor;
			this.textMesh.text = "Drag me";
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x000093E8 File Offset: 0x000077E8
	private void RandomColor()
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
	}

	// Token: 0x040000CB RID: 203
	private TextMesh textMesh;

	// Token: 0x040000CC RID: 204
	private Color startColor;

	// Token: 0x040000CD RID: 205
	private Vector3 deltaPosition;

	// Token: 0x040000CE RID: 206
	private int fingerIndex;
}
