using System;
using UnityEngine;
using Vectrosity;

// Token: 0x020001A8 RID: 424
public class ReallyBasicLine : MonoBehaviour
{
	// Token: 0x06000AEB RID: 2795 RVA: 0x0002FA3C File Offset: 0x0002DE3C
	private void Start()
	{
		VectorLine.SetLine(Color.white, new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2((float)(Screen.width - 1), (float)(Screen.height - 1))
		});
	}
}
