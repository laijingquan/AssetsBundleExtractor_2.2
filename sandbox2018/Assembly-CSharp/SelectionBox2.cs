using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C8 RID: 456
public class SelectionBox2 : MonoBehaviour
{
	// Token: 0x06000B5C RID: 2908 RVA: 0x00034150 File Offset: 0x00032550
	private void Start()
	{
		this.selectionLine = new VectorLine("Selection", new List<Vector2>(5), this.lineTexture, 4f, LineType.Continuous);
		this.selectionLine.textureScale = this.textureScale;
		this.selectionLine.alignOddWidthToPixels = true;
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x0003419C File Offset: 0x0003259C
	private void OnGUI()
	{
		GUI.Label(new Rect(10f, 10f, 300f, 25f), "Click & drag to make a selection box");
	}

	// Token: 0x06000B5E RID: 2910 RVA: 0x000341C4 File Offset: 0x000325C4
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			this.originalPos = Input.mousePosition;
		}
		if (Input.GetMouseButton(0))
		{
			this.selectionLine.MakeRect(this.originalPos, Input.mousePosition);
			this.selectionLine.Draw();
		}
		this.selectionLine.textureOffset = -Time.time * 2f % 1f;
	}

	// Token: 0x04000708 RID: 1800
	public Texture lineTexture;

	// Token: 0x04000709 RID: 1801
	public float textureScale = 4f;

	// Token: 0x0400070A RID: 1802
	private VectorLine selectionLine;

	// Token: 0x0400070B RID: 1803
	private Vector2 originalPos;
}
