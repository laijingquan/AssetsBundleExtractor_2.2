using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000030 RID: 48
public class MutliFingersScreenTouch : MonoBehaviour
{
	// Token: 0x060001AA RID: 426 RVA: 0x000090CE File Offset: 0x000074CE
	private void OnEnable()
	{
		EasyTouch.On_TouchStart += this.On_TouchStart;
	}

	// Token: 0x060001AB RID: 427 RVA: 0x000090E1 File Offset: 0x000074E1
	private void OnDestroy()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
	}

	// Token: 0x060001AC RID: 428 RVA: 0x000090F4 File Offset: 0x000074F4
	private void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickedObject == null)
		{
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(5f);
			UnityEngine.Object.Instantiate<GameObject>(this.touchGameObject, touchToWorldPoint, Quaternion.identity).GetComponent<FingerTouch>().InitTouch(gesture.fingerIndex);
		}
	}

	// Token: 0x040000CA RID: 202
	public GameObject touchGameObject;
}
