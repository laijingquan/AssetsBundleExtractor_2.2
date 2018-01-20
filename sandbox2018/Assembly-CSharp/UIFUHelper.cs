using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001A1 RID: 417
public class UIFUHelper
{
	// Token: 0x06000ACC RID: 2764 RVA: 0x0002ED74 File Offset: 0x0002D174
	public static void UGUIFade(Transform t, float fade, float time)
	{
		Image[] componentsInChildren = t.GetComponentsInChildren<Image>();
		foreach (Image target in componentsInChildren)
		{
			target.DOFade(fade, time);
		}
		Text[] componentsInChildren2 = t.GetComponentsInChildren<Text>();
		foreach (Text target2 in componentsInChildren2)
		{
			target2.DOFade(fade, time);
		}
	}
}
