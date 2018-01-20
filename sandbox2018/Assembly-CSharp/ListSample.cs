using System;
using System.Collections.Generic;
using OneP.InfinityScrollView;
using UnityEngine;

// Token: 0x0200012F RID: 303
public class ListSample : MonoBehaviour
{
	// Token: 0x060007C8 RID: 1992 RVA: 0x00020DE9 File Offset: 0x0001F1E9
	private void Start()
	{
		this.verticleScroll.Setup(this.listString.Count);
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x00020E01 File Offset: 0x0001F201
	private void Update()
	{
	}

	// Token: 0x04000491 RID: 1169
	public InfinityScrollView verticleScroll;

	// Token: 0x04000492 RID: 1170
	public List<string> listString = new List<string>();
}
