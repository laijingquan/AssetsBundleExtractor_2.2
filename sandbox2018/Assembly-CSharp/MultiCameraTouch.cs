using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000027 RID: 39
public class MultiCameraTouch : MonoBehaviour
{
	// Token: 0x0600017D RID: 381 RVA: 0x00008832 File Offset: 0x00006C32
	private void OnEnable()
	{
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchUp += this.On_TouchUp;
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00008856 File Offset: 0x00006C56
	private void OnDestroy()
	{
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
	}

	// Token: 0x0600017F RID: 383 RVA: 0x0000887C File Offset: 0x00006C7C
	private void On_TouchDown(Gesture gesture)
	{
		if (gesture.pickedObject != null)
		{
			this.label.text = "You touch : " + gesture.pickedObject.name + " on camera : " + gesture.pickedCamera.name;
		}
	}

	// Token: 0x06000180 RID: 384 RVA: 0x000088CA File Offset: 0x00006CCA
	private void On_TouchUp(Gesture gesture)
	{
		this.label.text = string.Empty;
	}

	// Token: 0x040000B6 RID: 182
	public Text label;
}
