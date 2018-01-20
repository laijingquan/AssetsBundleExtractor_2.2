using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000028 RID: 40
public class MultiCameraUI : MonoBehaviour
{
	// Token: 0x06000182 RID: 386 RVA: 0x000088E4 File Offset: 0x00006CE4
	public void AddCamera2(bool value)
	{
		this.AddCamera(this.cam2, value);
	}

	// Token: 0x06000183 RID: 387 RVA: 0x000088F3 File Offset: 0x00006CF3
	public void AddCamera3(bool value)
	{
		this.AddCamera(this.cam3, value);
	}

	// Token: 0x06000184 RID: 388 RVA: 0x00008902 File Offset: 0x00006D02
	public void AddCamera(Camera cam, bool value)
	{
		if (value)
		{
			EasyTouch.AddCamera(cam, false);
		}
		else
		{
			EasyTouch.RemoveCamera(cam);
		}
	}

	// Token: 0x040000B7 RID: 183
	public Camera cam2;

	// Token: 0x040000B8 RID: 184
	public Camera cam3;
}
