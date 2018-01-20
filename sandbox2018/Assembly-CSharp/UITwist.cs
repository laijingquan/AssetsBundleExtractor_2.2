using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class UITwist : MonoBehaviour
{
	// Token: 0x0600024B RID: 587 RVA: 0x0000AE14 File Offset: 0x00009214
	public void OnEnable()
	{
		EasyTouch.On_Twist += this.On_Twist;
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0000AE27 File Offset: 0x00009227
	public void OnDestroy()
	{
		EasyTouch.On_Twist -= this.On_Twist;
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0000AE3C File Offset: 0x0000923C
	private void On_Twist(Gesture gesture)
	{
		if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
		{
			base.transform.Rotate(new Vector3(0f, 0f, gesture.twistAngle));
		}
	}
}
