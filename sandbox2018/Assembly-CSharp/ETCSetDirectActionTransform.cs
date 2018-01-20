using System;
using UnityEngine;

// Token: 0x020000A5 RID: 165
[AddComponentMenu("EasyTouch Controls/Set Direct Action Transform ")]
public class ETCSetDirectActionTransform : MonoBehaviour
{
	// Token: 0x06000444 RID: 1092 RVA: 0x00013DDC File Offset: 0x000121DC
	private void Start()
	{
		if (!string.IsNullOrEmpty(this.axisName1))
		{
			ETCInput.SetAxisDirecTransform(this.axisName1, base.transform);
		}
		if (!string.IsNullOrEmpty(this.axisName2))
		{
			ETCInput.SetAxisDirecTransform(this.axisName2, base.transform);
		}
	}

	// Token: 0x0400026C RID: 620
	public string axisName1;

	// Token: 0x0400026D RID: 621
	public string axisName2;
}
