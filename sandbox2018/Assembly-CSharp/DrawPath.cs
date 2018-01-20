using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C1 RID: 449
public class DrawPath : MonoBehaviour
{
	// Token: 0x06000B3D RID: 2877 RVA: 0x0003320C File Offset: 0x0003160C
	private void Start()
	{
		this.pathLine = new VectorLine("Path", new List<Vector3>(), this.lineTex, 12f, LineType.Continuous);
		this.pathLine.color = Color.green;
		this.pathLine.textureScale = 1f;
		this.MakeBall();
		base.StartCoroutine(this.SamplePoints(this.ball.transform));
	}

	// Token: 0x06000B3E RID: 2878 RVA: 0x00033280 File Offset: 0x00031680
	private void MakeBall()
	{
		if (this.ball)
		{
			UnityEngine.Object.Destroy(this.ball);
		}
		this.ball = UnityEngine.Object.Instantiate<GameObject>(this.ballPrefab, new Vector3(-2.25f, -4.4f, -1.9f), Quaternion.Euler(300f, 70f, 310f));
		this.ball.GetComponent<Rigidbody>().useGravity = true;
		this.ball.GetComponent<Rigidbody>().AddForce(this.ball.transform.forward * this.force, ForceMode.Impulse);
	}

	// Token: 0x06000B3F RID: 2879 RVA: 0x00033320 File Offset: 0x00031720
	private IEnumerator SamplePoints(Transform thisTransform)
	{
		bool running = true;
		while (running)
		{
			this.pathLine.points3.Add(thisTransform.position);
			if (++this.pathIndex == this.maxPoints)
			{
				running = false;
			}
			yield return new WaitForSeconds(0.05f);
			if (this.continuousUpdate)
			{
				this.pathLine.Draw();
			}
		}
		yield break;
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x00033344 File Offset: 0x00031744
	private void OnGUI()
	{
		if (GUI.Button(new Rect(10f, 10f, 100f, 30f), "Reset"))
		{
			this.Reset();
		}
		if (!this.continuousUpdate && GUI.Button(new Rect(10f, 45f, 100f, 30f), "Draw Path"))
		{
			this.pathLine.Draw();
		}
	}

	// Token: 0x06000B41 RID: 2881 RVA: 0x000333C0 File Offset: 0x000317C0
	private void Reset()
	{
		base.StopAllCoroutines();
		this.MakeBall();
		this.pathLine.points3.Clear();
		this.pathLine.Draw();
		this.pathIndex = 0;
		base.StartCoroutine(this.SamplePoints(this.ball.transform));
	}

	// Token: 0x040006DE RID: 1758
	public Texture lineTex;

	// Token: 0x040006DF RID: 1759
	public Color lineColor = Color.green;

	// Token: 0x040006E0 RID: 1760
	public int maxPoints = 500;

	// Token: 0x040006E1 RID: 1761
	public bool continuousUpdate = true;

	// Token: 0x040006E2 RID: 1762
	public GameObject ballPrefab;

	// Token: 0x040006E3 RID: 1763
	public float force = 16f;

	// Token: 0x040006E4 RID: 1764
	private VectorLine pathLine;

	// Token: 0x040006E5 RID: 1765
	private int pathIndex;

	// Token: 0x040006E6 RID: 1766
	private GameObject ball;
}
