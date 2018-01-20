using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000044 RID: 68
public class UIDrag : MonoBehaviour
{
	// Token: 0x0600023E RID: 574 RVA: 0x0000A9D0 File Offset: 0x00008DD0
	private void OnEnable()
	{
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchStart += this.On_TouchStart;
		EasyTouch.On_TouchUp += this.On_TouchUp;
		EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers += this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers += this.On_TouchUp2Fingers;
	}

	// Token: 0x0600023F RID: 575 RVA: 0x0000AA44 File Offset: 0x00008E44
	private void OnDestroy()
	{
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
		EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
		EasyTouch.On_TouchDown2Fingers -= this.On_TouchDown2Fingers;
		EasyTouch.On_TouchUp2Fingers -= this.On_TouchUp2Fingers;
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0000AAB8 File Offset: 0x00008EB8
	private void On_TouchStart(Gesture gesture)
	{
		if (gesture.isOverGui && this.drag && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)) && this.fingerId == -1)
		{
			this.fingerId = gesture.fingerIndex;
			base.transform.SetAsLastSibling();
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0000AB30 File Offset: 0x00008F30
	private void On_TouchDown(Gesture gesture)
	{
		if (this.fingerId == gesture.fingerIndex && this.drag && gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
		{
			base.transform.position += gesture.deltaPosition;
		}
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0000ABB6 File Offset: 0x00008FB6
	private void On_TouchUp(Gesture gesture)
	{
		if (this.fingerId == gesture.fingerIndex)
		{
			this.fingerId = -1;
		}
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0000ABD0 File Offset: 0x00008FD0
	private void On_TouchStart2Fingers(Gesture gesture)
	{
		if (gesture.isOverGui && this.drag && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)) && this.fingerId == -1)
		{
			base.transform.SetAsLastSibling();
		}
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0000AC3C File Offset: 0x0000903C
	private void On_TouchDown2Fingers(Gesture gesture)
	{
		if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
		{
			if (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform))
			{
				base.transform.position += gesture.deltaPosition;
			}
			this.drag = false;
		}
	}

	// Token: 0x06000245 RID: 581 RVA: 0x0000ACE0 File Offset: 0x000090E0
	private void On_TouchUp2Fingers(Gesture gesture)
	{
		if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
		{
			this.drag = true;
		}
	}

	// Token: 0x040000E2 RID: 226
	private int fingerId = -1;

	// Token: 0x040000E3 RID: 227
	private bool drag = true;
}
