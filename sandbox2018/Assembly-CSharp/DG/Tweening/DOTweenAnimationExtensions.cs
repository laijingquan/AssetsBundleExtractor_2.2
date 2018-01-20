using System;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000024 RID: 36
	public static class DOTweenAnimationExtensions
	{
		// Token: 0x06000170 RID: 368 RVA: 0x00008549 File Offset: 0x00006949
		public static bool IsSameOrSubclassOf<T>(this Component t)
		{
			return t is T;
		}
	}
}
