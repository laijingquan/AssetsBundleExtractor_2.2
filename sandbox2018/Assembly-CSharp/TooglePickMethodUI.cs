using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class TooglePickMethodUI : MonoBehaviour
{
	// Token: 0x060001EA RID: 490 RVA: 0x00009BD8 File Offset: 0x00007FD8
	public void SetPickMethod2Finger(bool value)
	{
		if (value)
		{
			EasyTouch.SetTwoFingerPickMethod(EasyTouch.TwoFingerPickMethod.Finger);
		}
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00009BE6 File Offset: 0x00007FE6
	public void SetPickMethod2Averager(bool value)
	{
		if (value)
		{
			EasyTouch.SetTwoFingerPickMethod(EasyTouch.TwoFingerPickMethod.Average);
		}
	}
}
