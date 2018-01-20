using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A6 RID: 166
public class SliderText : MonoBehaviour
{
	// Token: 0x06000446 RID: 1094 RVA: 0x00013E33 File Offset: 0x00012233
	public void SetText(float value)
	{
		base.GetComponent<Text>().text = value.ToString("f2");
	}
}
