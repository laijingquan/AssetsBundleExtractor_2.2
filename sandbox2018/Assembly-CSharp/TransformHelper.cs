using System;
using UnityEngine;

// Token: 0x020001A0 RID: 416
public class TransformHelper
{
	// Token: 0x06000ACA RID: 2762 RVA: 0x0002ED52 File Offset: 0x0002D152
	public static void TransformReset(Transform t)
	{
		t.localScale = Vector3.one;
		t.localPosition = Vector3.zero;
	}
}
