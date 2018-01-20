using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C4 RID: 452
public class CreateHills : MonoBehaviour
{
	// Token: 0x06000B4A RID: 2890 RVA: 0x00033938 File Offset: 0x00031D38
	private void Start()
	{
		this.storedPosition = this.ball.transform.position;
		this.splinePoints = new Vector2[this.numberOfHills * 2 + 1];
		this.hills = new VectorLine("Hills", new List<Vector2>(this.numberOfPoints), this.hillTexture, 12f, LineType.Continuous, Joins.Weld);
		this.hills.useViewportCoords = true;
		this.hills.collider = true;
		this.hills.physicsMaterial = this.hillPhysicsMaterial;
		UnityEngine.Random.InitState(95);
		this.CreateHillLine();
	}

	// Token: 0x06000B4B RID: 2891 RVA: 0x000339D0 File Offset: 0x00031DD0
	private void OnGUI()
	{
		if (GUI.Button(new Rect(10f, 10f, 150f, 40f), "Make new hills"))
		{
			this.CreateHillLine();
			this.ball.transform.position = this.storedPosition;
			this.ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			this.ball.GetComponent<Rigidbody2D>().WakeUp();
		}
	}

	// Token: 0x06000B4C RID: 2892 RVA: 0x00033A48 File Offset: 0x00031E48
	private void CreateHillLine()
	{
		this.splinePoints[0] = new Vector2(-0.02f, UnityEngine.Random.Range(0.1f, 0.6f));
		float num = 0f;
		float num2 = 1f / (float)(this.numberOfHills * 2);
		int i;
		for (i = 1; i < this.splinePoints.Length; i += 2)
		{
			num += num2;
			this.splinePoints[i] = new Vector2(num, UnityEngine.Random.Range(0.3f, 0.7f));
			num += num2;
			this.splinePoints[i + 1] = new Vector2(num, UnityEngine.Random.Range(0.1f, 0.6f));
		}
		this.splinePoints[i - 1] = new Vector2(1.02f, UnityEngine.Random.Range(0.1f, 0.6f));
		this.hills.MakeSpline(this.splinePoints);
		this.hills.Draw();
	}

	// Token: 0x040006F3 RID: 1779
	public Texture hillTexture;

	// Token: 0x040006F4 RID: 1780
	public PhysicsMaterial2D hillPhysicsMaterial;

	// Token: 0x040006F5 RID: 1781
	public int numberOfPoints = 100;

	// Token: 0x040006F6 RID: 1782
	public int numberOfHills = 4;

	// Token: 0x040006F7 RID: 1783
	public GameObject ball;

	// Token: 0x040006F8 RID: 1784
	private Vector3 storedPosition;

	// Token: 0x040006F9 RID: 1785
	private VectorLine hills;

	// Token: 0x040006FA RID: 1786
	private Vector2[] splinePoints;
}
