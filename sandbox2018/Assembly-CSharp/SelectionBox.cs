using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C7 RID: 455
public class SelectionBox : MonoBehaviour
{
	// Token: 0x06000B57 RID: 2903 RVA: 0x00033F34 File Offset: 0x00032334
	private void Start()
	{
		this.lineColors = new List<Color32>(new Color32[4]);
		this.selectionLine = new VectorLine("Selection", new List<Vector2>(5), 3f, LineType.Continuous);
		this.selectionLine.capLength = 1.5f;
	}

	// Token: 0x06000B58 RID: 2904 RVA: 0x00033F73 File Offset: 0x00032373
	private void OnGUI()
	{
		GUI.Label(new Rect(10f, 10f, 300f, 25f), "Click & drag to make a selection box");
	}

	// Token: 0x06000B59 RID: 2905 RVA: 0x00033F98 File Offset: 0x00032398
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			base.StopCoroutine("CycleColor");
			this.selectionLine.SetColor(Color.white);
			this.originalPos = Input.mousePosition;
		}
		if (Input.GetMouseButton(0))
		{
			this.selectionLine.MakeRect(this.originalPos, Input.mousePosition);
			this.selectionLine.Draw();
		}
		if (Input.GetMouseButtonUp(0))
		{
			base.StartCoroutine("CycleColor");
		}
	}

	// Token: 0x06000B5A RID: 2906 RVA: 0x00034028 File Offset: 0x00032428
	private IEnumerator CycleColor()
	{
		for (;;)
		{
			for (int i = 0; i < 4; i++)
			{
				this.lineColors[i] = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong((Time.time + (float)i * 0.25f) * 3f, 1f));
			}
			this.selectionLine.SetColors(this.lineColors);
			yield return null;
		}
		yield break;
	}

	// Token: 0x04000705 RID: 1797
	private VectorLine selectionLine;

	// Token: 0x04000706 RID: 1798
	private Vector2 originalPos;

	// Token: 0x04000707 RID: 1799
	private List<Color32> lineColors;
}
