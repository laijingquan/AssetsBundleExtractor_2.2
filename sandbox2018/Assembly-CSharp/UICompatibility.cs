using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000042 RID: 66
public class UICompatibility : MonoBehaviour
{
	// Token: 0x06000239 RID: 569 RVA: 0x0000A978 File Offset: 0x00008D78
	public void SetCompatibility(bool value)
	{
		EasyTouch.SetUICompatibily(value);
	}
}
