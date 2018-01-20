using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200002F RID: 47
public class FingerTouch : MonoBehaviour
{
	// Token: 0x060001A1 RID: 417 RVA: 0x00008E0C File Offset: 0x0000720C
	private void OnEnable()
	{
		EasyTouch.On_TouchStart += this.On_TouchStart;
		EasyTouch.On_TouchUp += this.On_TouchUp;
		EasyTouch.On_Swipe += this.On_Swipe;
		EasyTouch.On_Drag += this.On_Drag;
		EasyTouch.On_DoubleTap += this.On_DoubleTap;
		this.textMesh = base.GetComponentInChildren<TextMesh>();
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00008E7C File Offset: 0x0000727C
	private void OnDestroy()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
		EasyTouch.On_Swipe -= this.On_Swipe;
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_DoubleTap -= this.On_DoubleTap;
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00008EE0 File Offset: 0x000072E0
	private void On_Drag(Gesture gesture)
	{
		if (gesture.pickedObject.transform.IsChildOf(base.gameObject.transform) && this.fingerId == gesture.fingerIndex)
		{
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			base.transform.position = touchToWorldPoint - this.deltaPosition;
		}
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00008F4C File Offset: 0x0000734C
	private void On_Swipe(Gesture gesture)
	{
		if (this.fingerId == gesture.fingerIndex)
		{
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(base.transform.position);
			base.transform.position = touchToWorldPoint - this.deltaPosition;
		}
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00008F94 File Offset: 0x00007394
	private void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickedObject != null && gesture.pickedObject.transform.IsChildOf(base.gameObject.transform))
		{
			this.fingerId = gesture.fingerIndex;
			this.textMesh.text = this.fingerId.ToString();
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			this.deltaPosition = touchToWorldPoint - base.transform.position;
		}
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00009028 File Offset: 0x00007428
	private void On_TouchUp(Gesture gesture)
	{
		if (gesture.fingerIndex == this.fingerId)
		{
			this.fingerId = -1;
			this.textMesh.text = string.Empty;
		}
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00009052 File Offset: 0x00007452
	public void InitTouch(int ind)
	{
		this.fingerId = ind;
		this.textMesh.text = this.fingerId.ToString();
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00009078 File Offset: 0x00007478
	private void On_DoubleTap(Gesture gesture)
	{
		if (gesture.pickedObject != null && gesture.pickedObject.transform.IsChildOf(base.gameObject.transform))
		{
			UnityEngine.Object.DestroyImmediate(base.transform.gameObject);
		}
	}

	// Token: 0x040000C7 RID: 199
	private TextMesh textMesh;

	// Token: 0x040000C8 RID: 200
	public Vector3 deltaPosition = Vector2.zero;

	// Token: 0x040000C9 RID: 201
	public int fingerId = -1;
}
