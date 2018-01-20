using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000045 RID: 69
public class UIPinch : MonoBehaviour
{
	// Token: 0x06000247 RID: 583 RVA: 0x0000AD38 File Offset: 0x00009138
	public void OnEnable()
	{
		EasyTouch.On_Pinch += this.On_Pinch;
	}

	// Token: 0x06000248 RID: 584 RVA: 0x0000AD4B File Offset: 0x0000914B
	public void OnDestroy()
	{
		EasyTouch.On_Pinch -= this.On_Pinch;
	}

	// Token: 0x06000249 RID: 585 RVA: 0x0000AD60 File Offset: 0x00009160
	private void On_Pinch(Gesture gesture)
	{
		if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x + gesture.deltaPinch * Time.deltaTime, base.transform.localScale.y + gesture.deltaPinch * Time.deltaTime, base.transform.localScale.z);
		}
	}
}
