using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001CD RID: 461
public class TextDemo : MonoBehaviour
{
	// Token: 0x06000B6B RID: 2923 RVA: 0x000349DC File Offset: 0x00032DDC
	private void Start()
	{
		this.textLine = new VectorLine("Text", new List<Vector2>(), 1f);
		this.textLine.color = Color.yellow;
		this.textLine.drawTransform = base.transform;
		this.textLine.MakeText(this.text, new Vector2((float)(Screen.width / 2 - this.text.Length * this.textSize / 2), (float)(Screen.height / 2 + this.textSize / 2)), (float)this.textSize);
		this.textLine.Draw();
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x00034A84 File Offset: 0x00032E84
	private void Update()
	{
	}

	// Token: 0x0400071C RID: 1820
	private string text = "5";

	// Token: 0x0400071D RID: 1821
	public int textSize = 20;

	// Token: 0x0400071E RID: 1822
	private VectorLine textLine;
}
