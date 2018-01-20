using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000041 RID: 65
public class GlobalEasyTouchEvent : MonoBehaviour
{
	// Token: 0x06000232 RID: 562 RVA: 0x0000A7C8 File Offset: 0x00008BC8
	private void OnEnable()
	{
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchUp += this.On_TouchUp;
		EasyTouch.On_OverUIElement += this.On_OverUIElement;
		EasyTouch.On_UIElementTouchUp += this.On_UIElementTouchUp;
	}

	// Token: 0x06000233 RID: 563 RVA: 0x0000A81C File Offset: 0x00008C1C
	private void OnDestroy()
	{
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
		EasyTouch.On_OverUIElement -= this.On_OverUIElement;
		EasyTouch.On_UIElementTouchUp -= this.On_UIElementTouchUp;
	}

	// Token: 0x06000234 RID: 564 RVA: 0x0000A870 File Offset: 0x00008C70
	private void On_TouchDown(Gesture gesture)
	{
		Debug.Log("ok");
		this.statText.transform.SetAsFirstSibling();
		if (gesture.pickedUIElement != null)
		{
			this.statText.text = "You touch UI Element : " + gesture.pickedUIElement.name + " (from gesture event)";
		}
		if (!gesture.isOverGui && gesture.pickedObject == null)
		{
			this.statText.text = "You touch an empty area";
		}
		if (gesture.pickedObject != null && !gesture.isOverGui)
		{
			this.statText.text = "You touch a 3D Object";
		}
	}

	// Token: 0x06000235 RID: 565 RVA: 0x0000A925 File Offset: 0x00008D25
	private void On_OverUIElement(Gesture gesture)
	{
		this.statText.text = "You touch UI Element : " + gesture.pickedUIElement.name + " (from On_OverUIElement event)";
	}

	// Token: 0x06000236 RID: 566 RVA: 0x0000A94C File Offset: 0x00008D4C
	private void On_UIElementTouchUp(Gesture gesture)
	{
		this.statText.text = string.Empty;
	}

	// Token: 0x06000237 RID: 567 RVA: 0x0000A95E File Offset: 0x00008D5E
	private void On_TouchUp(Gesture gesture)
	{
		this.statText.text = string.Empty;
	}

	// Token: 0x040000E1 RID: 225
	public Text statText;
}
