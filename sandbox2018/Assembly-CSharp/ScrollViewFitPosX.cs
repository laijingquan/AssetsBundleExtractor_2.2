using System;
using UnityEngine;

// Token: 0x02000176 RID: 374
public class ScrollViewFitPosX : MonoBehaviour
{
	// Token: 0x060009D6 RID: 2518 RVA: 0x0002A8B8 File Offset: 0x00028CB8
	private void Start()
	{
		Vector2 vector = base.GetComponent<RectTransform>().localPosition;
		float num = (float)Screen.height * 1f / (float)Screen.width;
		float num2 = 1.77777779f / num;
		float x = vector.x * num2;
		base.GetComponent<RectTransform>().localPosition = new Vector2(x, vector.y);
	}

	// Token: 0x060009D7 RID: 2519 RVA: 0x0002A919 File Offset: 0x00028D19
	private void Update()
	{
	}
}
