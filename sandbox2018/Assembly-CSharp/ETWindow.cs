using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class ETWindow : MonoBehaviour
{
	// Token: 0x0600022D RID: 557 RVA: 0x0000A69C File Offset: 0x00008A9C
	private void OnEnable()
	{
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchStart += this.On_TouchStart;
	}

	// Token: 0x0600022E RID: 558 RVA: 0x0000A6C0 File Offset: 0x00008AC0
	private void OnDestroy()
	{
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchStart -= this.On_TouchStart;
	}

	// Token: 0x0600022F RID: 559 RVA: 0x0000A6E4 File Offset: 0x00008AE4
	private void On_TouchStart(Gesture gesture)
	{
		this.drag = false;
		if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
		{
			base.transform.SetAsLastSibling();
			this.drag = true;
		}
	}

	// Token: 0x06000230 RID: 560 RVA: 0x0000A748 File Offset: 0x00008B48
	private void On_TouchDown(Gesture gesture)
	{
		if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)) && this.drag)
		{
			base.transform.position += gesture.deltaPosition;
		}
	}

	// Token: 0x040000E0 RID: 224
	private bool drag;
}
