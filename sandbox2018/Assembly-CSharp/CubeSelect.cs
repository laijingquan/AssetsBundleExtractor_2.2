using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000029 RID: 41
public class CubeSelect : MonoBehaviour
{
	// Token: 0x06000186 RID: 390 RVA: 0x00008924 File Offset: 0x00006D24
	private void OnEnable()
	{
		EasyTouch.On_SimpleTap += this.On_SimpleTap;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00008937 File Offset: 0x00006D37
	private void OnDestroy()
	{
		EasyTouch.On_SimpleTap -= this.On_SimpleTap;
	}

	// Token: 0x06000188 RID: 392 RVA: 0x0000894A File Offset: 0x00006D4A
	private void Start()
	{
		this.cube = null;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00008954 File Offset: 0x00006D54
	private void On_SimpleTap(Gesture gesture)
	{
		if (gesture.pickedObject != null && gesture.pickedObject.name == "Cube")
		{
			this.ResteColor();
			this.cube = gesture.pickedObject;
			this.cube.GetComponent<Renderer>().material.color = Color.red;
		}
	}

	// Token: 0x0600018A RID: 394 RVA: 0x000089B8 File Offset: 0x00006DB8
	private void ResteColor()
	{
		if (this.cube != null)
		{
			this.cube.GetComponent<Renderer>().material.color = new Color(0.235294119f, 0.56078434f, 0.7882353f);
		}
	}

	// Token: 0x040000B9 RID: 185
	private GameObject cube;
}
