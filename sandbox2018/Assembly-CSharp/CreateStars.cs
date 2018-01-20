using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001BD RID: 445
public class CreateStars : MonoBehaviour
{
	// Token: 0x06000B32 RID: 2866 RVA: 0x00032DA8 File Offset: 0x000311A8
	private void Start()
	{
		Vector3[] array = new Vector3[this.numberOfStars];
		for (int i = 0; i < this.numberOfStars; i++)
		{
			array[i] = UnityEngine.Random.onUnitSphere * 100f;
		}
		float[] array2 = new float[this.numberOfStars];
		for (int j = 0; j < this.numberOfStars; j++)
		{
			array2[j] = UnityEngine.Random.Range(1.5f, 2.5f);
		}
		Color32[] array3 = new Color32[this.numberOfStars];
		for (int k = 0; k < this.numberOfStars; k++)
		{
			float num = UnityEngine.Random.value * 0.75f + 0.25f;
			array3[k] = new Color(num, num, num);
		}
		this.stars = new VectorLine("Stars", new List<Vector3>(array), 1f, LineType.Points);
		this.stars.SetColors(new List<Color32>(array3));
		this.stars.SetWidths(new List<float>(array2));
		this.stars.Draw();
		VectorLine.SetCanvasCamera(Camera.main);
		VectorLine.canvas.planeDistance = Camera.main.farClipPlane - 1f;
	}

	// Token: 0x06000B33 RID: 2867 RVA: 0x00032EEF File Offset: 0x000312EF
	private void LateUpdate()
	{
		this.stars.Draw();
	}

	// Token: 0x040006D0 RID: 1744
	public int numberOfStars = 2000;

	// Token: 0x040006D1 RID: 1745
	private VectorLine stars;
}
