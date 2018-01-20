using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000025 RID: 37
public class MultiLayerTouch : MonoBehaviour
{
	// Token: 0x06000172 RID: 370 RVA: 0x0000855C File Offset: 0x0000695C
	private void OnEnable()
	{
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchUp += this.On_TouchUp;
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00008580 File Offset: 0x00006980
	private void OnDestroy()
	{
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
	}

	// Token: 0x06000174 RID: 372 RVA: 0x000085A4 File Offset: 0x000069A4
	private void On_TouchDown(Gesture gesture)
	{
		if (gesture.pickedObject != null)
		{
			if (!EasyTouch.GetAutoUpdatePickedObject())
			{
				this.label.text = string.Concat(new object[]
				{
					"Picked object from event : ",
					gesture.pickedObject.name,
					" : ",
					gesture.position
				});
			}
			else
			{
				this.label.text = string.Concat(new object[]
				{
					"Picked object from event : ",
					gesture.pickedObject.name,
					" : ",
					gesture.position
				});
			}
		}
		else if (!EasyTouch.GetAutoUpdatePickedObject())
		{
			this.label.text = "Picked object from event :  none";
		}
		else
		{
			this.label.text = "Picked object from event : none";
		}
		this.label2.text = string.Empty;
		if (!EasyTouch.GetAutoUpdatePickedObject())
		{
			GameObject currentPickedObject = gesture.GetCurrentPickedObject(false);
			if (currentPickedObject != null)
			{
				this.label2.text = "Picked object from GetCurrentPickedObject : " + currentPickedObject.name;
			}
			else
			{
				this.label2.text = "Picked object from GetCurrentPickedObject : none";
			}
		}
	}

	// Token: 0x06000175 RID: 373 RVA: 0x000086E7 File Offset: 0x00006AE7
	private void On_TouchUp(Gesture gesture)
	{
		this.label.text = string.Empty;
		this.label2.text = string.Empty;
	}

	// Token: 0x040000B4 RID: 180
	public Text label;

	// Token: 0x040000B5 RID: 181
	public Text label2;
}
