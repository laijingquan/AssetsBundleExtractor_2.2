using System;
using UnityEngine;

namespace OneP.Samples
{
	// Token: 0x02000121 RID: 289
	public class SampleGlobalValue
	{
		// Token: 0x06000785 RID: 1925 RVA: 0x0001FCAC File Offset: 0x0001E0AC
		public static void GoToNextSample()
		{
			int num = (int)SampleGlobalValue.sceneNow;
			num++;
			num %= 6;
			SampleGlobalValue.sceneNow = (SampleScene)num;
			Application.LoadLevel(SampleGlobalValue.sceneNow.ToString());
		}

		// Token: 0x0400046D RID: 1133
		public static SampleScene sceneNow;
	}
}
