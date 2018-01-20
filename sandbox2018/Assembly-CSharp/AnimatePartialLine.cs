using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001C0 RID: 448
public class AnimatePartialLine : MonoBehaviour
{
	// Token: 0x06000B3A RID: 2874 RVA: 0x00033034 File Offset: 0x00031434
	private void Start()
	{
		this.startIndex = (float)(-(float)this.visibleLineSegments);
		this.endIndex = 0f;
		List<Vector2> points = new List<Vector2>(this.segments + 1);
		this.line = new VectorLine("Spline", points, this.lineTexture, 30f, LineType.Continuous, Joins.Weld);
		int num = Screen.width / 5;
		int num2 = Screen.height / 3;
		this.line.MakeSpline(new Vector2[]
		{
			new Vector2((float)num, (float)num2),
			new Vector2((float)(num * 2), (float)(num2 * 2)),
			new Vector2((float)(num * 3), (float)(num2 * 2)),
			new Vector2((float)(num * 4), (float)num2)
		});
	}

	// Token: 0x06000B3B RID: 2875 RVA: 0x00033108 File Offset: 0x00031508
	private void Update()
	{
		this.startIndex += Time.deltaTime * this.speed;
		this.endIndex += Time.deltaTime * this.speed;
		if (this.startIndex >= (float)(this.segments + 1))
		{
			this.startIndex = (float)(-(float)this.visibleLineSegments);
			this.endIndex = 0f;
		}
		else if (this.startIndex < (float)(-(float)this.visibleLineSegments))
		{
			this.startIndex = (float)this.segments;
			this.endIndex = (float)(this.segments + this.visibleLineSegments);
		}
		this.line.drawStart = (int)this.startIndex;
		this.line.drawEnd = (int)this.endIndex;
		this.line.Draw();
	}

	// Token: 0x040006D7 RID: 1751
	public Texture lineTexture;

	// Token: 0x040006D8 RID: 1752
	public int segments = 60;

	// Token: 0x040006D9 RID: 1753
	public int visibleLineSegments = 20;

	// Token: 0x040006DA RID: 1754
	public float speed = 60f;

	// Token: 0x040006DB RID: 1755
	private float startIndex;

	// Token: 0x040006DC RID: 1756
	private float endIndex;

	// Token: 0x040006DD RID: 1757
	private VectorLine line;
}
