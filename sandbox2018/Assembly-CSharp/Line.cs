using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001A7 RID: 423
public class Line : MonoBehaviour
{
	// Token: 0x06000AE9 RID: 2793 RVA: 0x0002F9CC File Offset: 0x0002DDCC
	private void Start()
	{
		VectorLine vectorLine = new VectorLine("Line", new List<Vector2>
		{
			new Vector2(0f, (float)UnityEngine.Random.Range(0, Screen.height)),
			new Vector2((float)(Screen.width - 1), (float)UnityEngine.Random.Range(0, Screen.height))
		}, 2f);
		vectorLine.Draw();
	}
}
