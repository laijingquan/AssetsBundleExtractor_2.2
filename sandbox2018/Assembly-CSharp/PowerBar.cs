using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C3 RID: 451
public class PowerBar : MonoBehaviour
{
	// Token: 0x06000B45 RID: 2885 RVA: 0x00033680 File Offset: 0x00031A80
	private void Start()
	{
		this.position = new Vector2(this.radius + 20f, (float)Screen.height - (this.radius + 20f));
		VectorLine vectorLine = new VectorLine("BarBackground", new List<Vector2>(50), null, (float)this.lineWidth, LineType.Continuous, Joins.Weld);
		vectorLine.MakeCircle(this.position, this.radius);
		vectorLine.Draw();
		this.bar = new VectorLine("TotalBar", new List<Vector2>(this.segmentCount + 1), null, (float)(this.lineWidth - 4), LineType.Continuous, Joins.Weld);
		this.bar.color = Color.black;
		this.bar.MakeArc(this.position, this.radius, this.radius, 0f, 270f);
		this.bar.Draw();
		this.currentPower = UnityEngine.Random.value;
		this.SetTargetPower();
		this.bar.SetColor(Color.red, 0, (int)Mathf.Lerp(0f, (float)this.segmentCount, this.currentPower));
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x000337A4 File Offset: 0x00031BA4
	private void SetTargetPower()
	{
		this.targetPower = UnityEngine.Random.value;
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x000337B4 File Offset: 0x00031BB4
	private void Update()
	{
		float t = this.currentPower;
		if (this.targetPower < this.currentPower)
		{
			this.currentPower -= this.speed * Time.deltaTime;
			if (this.currentPower < this.targetPower)
			{
				this.SetTargetPower();
			}
			this.bar.SetColor(Color.black, (int)Mathf.Lerp(0f, (float)this.segmentCount, this.currentPower), (int)Mathf.Lerp(0f, (float)this.segmentCount, t));
		}
		else
		{
			this.currentPower += this.speed * Time.deltaTime;
			if (this.currentPower > this.targetPower)
			{
				this.SetTargetPower();
			}
			this.bar.SetColor(Color.red, (int)Mathf.Lerp(0f, (float)this.segmentCount, t), (int)Mathf.Lerp(0f, (float)this.segmentCount, this.currentPower));
		}
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x000338C0 File Offset: 0x00031CC0
	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 40), (float)(Screen.height / 2 - 15), 80f, 30f), "Power: " + (this.currentPower * 100f).ToString("f0") + "%");
	}

	// Token: 0x040006EB RID: 1771
	public float speed = 0.25f;

	// Token: 0x040006EC RID: 1772
	public int lineWidth = 25;

	// Token: 0x040006ED RID: 1773
	public float radius = 60f;

	// Token: 0x040006EE RID: 1774
	public int segmentCount = 200;

	// Token: 0x040006EF RID: 1775
	private VectorLine bar;

	// Token: 0x040006F0 RID: 1776
	private Vector2 position;

	// Token: 0x040006F1 RID: 1777
	private float currentPower;

	// Token: 0x040006F2 RID: 1778
	private float targetPower;
}
