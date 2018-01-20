using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C6 RID: 454
public class ScribbleCube : MonoBehaviour
{
	// Token: 0x06000B50 RID: 2896 RVA: 0x00033C08 File Offset: 0x00032008
	private void Start()
	{
		this.line = new VectorLine("Line", new List<Vector3>(this.numberOfPoints), this.lineTexture, (float)this.lineWidth, LineType.Continuous);
		this.line.material = this.lineMaterial;
		this.line.drawTransform = base.transform;
		this.LineSetup(false);
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x00033C68 File Offset: 0x00032068
	private void LineSetup(bool resize)
	{
		if (resize)
		{
			this.lineColors = null;
			this.line.Resize(this.numberOfPoints);
		}
		for (int i = 0; i < this.line.points3.Count; i++)
		{
			this.line.points3[i] = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
		}
		this.SetLineColors();
	}

	// Token: 0x06000B52 RID: 2898 RVA: 0x00033D00 File Offset: 0x00032100
	private void SetLineColors()
	{
		if (this.lineColors == null)
		{
			this.lineColors = new List<Color32>(new Color32[this.numberOfPoints - 1]);
		}
		for (int i = 0; i < this.lineColors.Count; i++)
		{
			this.lineColors[i] = Color.Lerp(this.color1, this.color2, (float)i / (float)this.lineColors.Count);
		}
		this.line.SetColors(this.lineColors);
	}

	// Token: 0x06000B53 RID: 2899 RVA: 0x00033D8E File Offset: 0x0003218E
	private void LateUpdate()
	{
		this.line.Draw();
	}

	// Token: 0x06000B54 RID: 2900 RVA: 0x00033D9C File Offset: 0x0003219C
	private void OnGUI()
	{
		GUI.Label(new Rect(20f, 10f, 250f, 30f), "Zoom with scrollwheel or arrow keys");
		if (GUI.Button(new Rect(20f, 50f, 100f, 30f), "Change colors"))
		{
			int num = UnityEngine.Random.Range(0, 3);
			int num2;
			do
			{
				num2 = UnityEngine.Random.Range(0, 3);
			}
			while (num2 == num);
			this.color1 = this.RandomColor(this.color1, num);
			this.color2 = this.RandomColor(this.color2, num2);
			this.SetLineColors();
		}
		GUI.Label(new Rect(20f, 100f, 150f, 30f), "Number of points: " + this.numberOfPoints);
		this.numberOfPoints = (int)GUI.HorizontalSlider(new Rect(20f, 130f, 120f, 30f), (float)this.numberOfPoints, 50f, 1000f);
		if (GUI.Button(new Rect(160f, 120f, 40f, 30f), "Set"))
		{
			this.LineSetup(true);
		}
	}

	// Token: 0x06000B55 RID: 2901 RVA: 0x00033ED4 File Offset: 0x000322D4
	private Color RandomColor(Color color, int component)
	{
		for (int i = 0; i < 3; i++)
		{
			if (i == component)
			{
				color[i] = UnityEngine.Random.value * 0.25f;
			}
			else
			{
				color[i] = UnityEngine.Random.value * 0.5f + 0.5f;
			}
		}
		return color;
	}

	// Token: 0x040006FD RID: 1789
	public Texture lineTexture;

	// Token: 0x040006FE RID: 1790
	public Material lineMaterial;

	// Token: 0x040006FF RID: 1791
	public int lineWidth = 14;

	// Token: 0x04000700 RID: 1792
	private Color color1 = Color.green;

	// Token: 0x04000701 RID: 1793
	private Color color2 = Color.blue;

	// Token: 0x04000702 RID: 1794
	private VectorLine line;

	// Token: 0x04000703 RID: 1795
	private List<Color32> lineColors;

	// Token: 0x04000704 RID: 1796
	private int numberOfPoints = 350;
}
