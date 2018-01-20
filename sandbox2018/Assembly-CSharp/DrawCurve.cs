using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001AE RID: 430
public class DrawCurve : MonoBehaviour
{
	// Token: 0x06000AF7 RID: 2807 RVA: 0x0003015C File Offset: 0x0002E55C
	private void Start()
	{
		DrawCurve.use = this;
		DrawCurve.cam = Camera.main;
		this.oldWidth = Screen.width;
		this.oldSegments = this.segments;
		List<Vector2> list = new List<Vector2>();
		list.Add(new Vector2((float)Screen.width * 0.25f, (float)Screen.height * 0.25f));
		list.Add(new Vector2((float)Screen.width * 0.125f, (float)Screen.height * 0.5f));
		list.Add(new Vector2((float)Screen.width - (float)Screen.width * 0.25f, (float)Screen.height - (float)Screen.height * 0.25f));
		list.Add(new Vector2((float)Screen.width - (float)Screen.width * 0.125f, (float)Screen.height * 0.5f));
		this.controlLine = new VectorLine("Control Line", list, 2f);
		this.controlLine.color = new Color(0f, 0.75f, 0.1f, 0.6f);
		this.controlLine.Draw();
		this.line = new VectorLine("Curve", new List<Vector2>(this.segments + 1), this.lineTexture, 5f, LineType.Continuous, Joins.Weld);
		this.line.MakeCurve(list[0], list[1], list[2], list[3], this.segments);
		this.line.Draw();
		this.AddControlObjects();
		this.AddControlObjects();
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x00030304 File Offset: 0x0002E704
	private void SetLine()
	{
		if (this.useDottedLine)
		{
			this.line.texture = this.dottedLineTexture;
			this.line.color = this.dottedLineColor;
			this.line.lineWidth = 8f;
			this.line.textureScale = 1f;
		}
		else
		{
			this.line.texture = this.lineTexture;
			this.line.color = this.lineColor;
			this.line.lineWidth = 5f;
			this.line.textureScale = 0f;
		}
	}

	// Token: 0x06000AF9 RID: 2809 RVA: 0x000303B0 File Offset: 0x0002E7B0
	private void AddControlObjects()
	{
		this.anchorObject = UnityEngine.Object.Instantiate<GameObject>(this.anchorPoint, DrawCurve.cam.ScreenToViewportPoint(this.controlLine.points2[this.pointIndex]), Quaternion.identity);
		this.anchorObject.GetComponent<CurvePointControl>().objectNumber = this.pointIndex++;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.controlPoint, DrawCurve.cam.ScreenToViewportPoint(this.controlLine.points2[this.pointIndex]), Quaternion.identity);
		gameObject.GetComponent<CurvePointControl>().objectNumber = this.pointIndex++;
		this.anchorObject.GetComponent<CurvePointControl>().controlObject = gameObject;
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x0003047C File Offset: 0x0002E87C
	public void UpdateLine(int objectNumber, Vector2 pos, GameObject go)
	{
		Vector2 b = this.controlLine.points2[objectNumber];
		this.controlLine.points2[objectNumber] = pos;
		int num = objectNumber / 4;
		int num2 = num * 4;
		this.line.MakeCurve(this.controlLine.points2[num2], this.controlLine.points2[num2 + 1], this.controlLine.points2[num2 + 2], this.controlLine.points2[num2 + 3], this.segments, num * (this.segments + 1));
		if (objectNumber % 2 == 0)
		{
			List<Vector2> points;
			int index;
			(points = this.controlLine.points2)[index = objectNumber + 1] = points[index] + (pos - b);
			go.GetComponent<CurvePointControl>().controlObject.transform.position = DrawCurve.cam.ScreenToViewportPoint(this.controlLine.points2[objectNumber + 1]);
			if (objectNumber > 0 && objectNumber < this.controlLine.points2.Count - 2)
			{
				this.controlLine.points2[objectNumber + 2] = pos;
				int index2;
				(points = this.controlLine.points2)[index2 = objectNumber + 3] = points[index2] + (pos - b);
				go.GetComponent<CurvePointControl>().controlObject2.transform.position = DrawCurve.cam.ScreenToViewportPoint(this.controlLine.points2[objectNumber + 3]);
				this.line.MakeCurve(this.controlLine.points2[num2 + 4], this.controlLine.points2[num2 + 5], this.controlLine.points2[num2 + 6], this.controlLine.points2[num2 + 7], this.segments, (num + 1) * (this.segments + 1));
			}
		}
		this.line.Draw();
		this.controlLine.Draw();
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x000306C4 File Offset: 0x0002EAC4
	private void OnGUI()
	{
		if (GUI.Button(new Rect(20f, 20f, 100f, 30f), "Add Point"))
		{
			this.AddPoint();
		}
		GUI.Label(new Rect(20f, 59f, 200f, 30f), "Curve resolution: " + this.segments);
		this.segments = (int)GUI.HorizontalSlider(new Rect(20f, 80f, 150f, 30f), (float)this.segments, 3f, 60f);
		if (this.oldSegments != this.segments)
		{
			this.oldSegments = this.segments;
			this.ChangeSegments();
		}
		this.useDottedLine = GUI.Toggle(new Rect(20f, 105f, 80f, 20f), this.useDottedLine, " Dotted line");
		if (this.oldDottedLineSetting != this.useDottedLine)
		{
			this.oldDottedLineSetting = this.useDottedLine;
			this.SetLine();
			this.line.Draw();
		}
		GUILayout.BeginArea(new Rect(20f, 150f, 150f, 800f));
		if (GUILayout.Button((!this.listPoints) ? "List points" : "Hide points", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.listPoints = !this.listPoints;
		}
		if (this.listPoints)
		{
			int num = 0;
			for (int i = 0; i < this.controlLine.points2.Count; i += 2)
			{
				GUILayout.Label(string.Concat(new object[]
				{
					"Anchor ",
					num,
					": (",
					(int)this.controlLine.points2[i].x,
					", ",
					(int)this.controlLine.points2[i].y,
					")"
				}), new GUILayoutOption[0]);
				GUILayout.Label(string.Concat(new object[]
				{
					"Control ",
					num++,
					": (",
					(int)this.controlLine.points2[i + 1].x,
					", ",
					(int)this.controlLine.points2[i + 1].y,
					")"
				}), new GUILayoutOption[0]);
			}
		}
		GUILayout.EndArea();
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x00030990 File Offset: 0x0002ED90
	private void AddPoint()
	{
		if (this.line.points2.Count + this.controlLine.points2.Count + this.segments + 4 > 16383)
		{
			return;
		}
		this.controlLine.points2.Add(this.controlLine.points2[this.pointIndex - 2]);
		this.controlLine.points2.Add(this.controlLine.points2[this.pointIndex - 1]);
		Vector2 b = (this.controlLine.points2[this.pointIndex - 2] - this.controlLine.points2[this.pointIndex - 4]) * 0.25f;
		this.controlLine.points2.Add(this.controlLine.points2[this.pointIndex - 2] + b);
		this.controlLine.points2.Add(this.controlLine.points2[this.pointIndex - 1] + b);
		if (this.controlLine.points2[this.pointIndex + 2].x > (float)Screen.width || this.controlLine.points2[this.pointIndex + 2].y > (float)Screen.height || this.controlLine.points2[this.pointIndex + 2].x < 0f || this.controlLine.points2[this.pointIndex + 2].y < 0f)
		{
			this.controlLine.points2[this.pointIndex + 2] = this.controlLine.points2[this.pointIndex - 2] - b;
			this.controlLine.points2[this.pointIndex + 3] = this.controlLine.points2[this.pointIndex - 1] - b;
		}
		Vector2 vector = this.controlLine.points2[this.pointIndex - 1] + (this.controlLine.points2[this.pointIndex] - this.controlLine.points2[this.pointIndex - 1]) * 2f;
		this.pointIndex++;
		this.controlLine.points2[this.pointIndex] = vector;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.controlPoint, DrawCurve.cam.ScreenToViewportPoint(vector), Quaternion.identity);
		gameObject.GetComponent<CurvePointControl>().objectNumber = this.pointIndex++;
		this.anchorObject.GetComponent<CurvePointControl>().controlObject2 = gameObject;
		this.AddControlObjects();
		this.controlLine.Draw();
		this.line.Resize((this.segments + 1) * ++this.numberOfCurves);
		this.line.MakeCurve(this.controlLine.points2[this.pointIndex - 4], this.controlLine.points2[this.pointIndex - 3], this.controlLine.points2[this.pointIndex - 2], this.controlLine.points2[this.pointIndex - 1], this.segments, (this.segments + 1) * (this.numberOfCurves - 1));
		this.line.Draw();
	}

	// Token: 0x06000AFD RID: 2813 RVA: 0x00030D84 File Offset: 0x0002F184
	private void ChangeSegments()
	{
		if (this.segments * 4 * this.numberOfCurves > 65534)
		{
			return;
		}
		this.line.Resize((this.segments + 1) * this.numberOfCurves);
		for (int i = 0; i < this.numberOfCurves; i++)
		{
			this.line.MakeCurve(this.controlLine.points2[i * 4], this.controlLine.points2[i * 4 + 1], this.controlLine.points2[i * 4 + 2], this.controlLine.points2[i * 4 + 3], this.segments, (this.segments + 1) * i);
		}
		this.line.Draw();
	}

	// Token: 0x06000AFE RID: 2814 RVA: 0x00030E68 File Offset: 0x0002F268
	private void Update()
	{
		if (Screen.width != this.oldWidth)
		{
			this.oldWidth = Screen.width;
			this.ChangeResolution();
		}
	}

	// Token: 0x06000AFF RID: 2815 RVA: 0x00030E8C File Offset: 0x0002F28C
	private void ChangeResolution()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("GameController");
		foreach (GameObject gameObject in array)
		{
			gameObject.transform.position = DrawCurve.cam.ScreenToViewportPoint(this.controlLine.points2[gameObject.GetComponent<CurvePointControl>().objectNumber]);
		}
	}

	// Token: 0x0400065C RID: 1628
	public Texture lineTexture;

	// Token: 0x0400065D RID: 1629
	public Color lineColor = Color.white;

	// Token: 0x0400065E RID: 1630
	public Texture dottedLineTexture;

	// Token: 0x0400065F RID: 1631
	public Color dottedLineColor = Color.yellow;

	// Token: 0x04000660 RID: 1632
	public int segments = 60;

	// Token: 0x04000661 RID: 1633
	public GameObject anchorPoint;

	// Token: 0x04000662 RID: 1634
	public GameObject controlPoint;

	// Token: 0x04000663 RID: 1635
	private int numberOfCurves = 1;

	// Token: 0x04000664 RID: 1636
	private VectorLine line;

	// Token: 0x04000665 RID: 1637
	private VectorLine controlLine;

	// Token: 0x04000666 RID: 1638
	private int pointIndex;

	// Token: 0x04000667 RID: 1639
	private GameObject anchorObject;

	// Token: 0x04000668 RID: 1640
	private int oldWidth;

	// Token: 0x04000669 RID: 1641
	private bool useDottedLine;

	// Token: 0x0400066A RID: 1642
	private bool oldDottedLineSetting;

	// Token: 0x0400066B RID: 1643
	private int oldSegments;

	// Token: 0x0400066C RID: 1644
	private bool listPoints;

	// Token: 0x0400066D RID: 1645
	public static DrawCurve use;

	// Token: 0x0400066E RID: 1646
	public static Camera cam;
}
