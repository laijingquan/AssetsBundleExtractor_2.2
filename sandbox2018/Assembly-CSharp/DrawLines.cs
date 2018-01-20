using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B0 RID: 432
public class DrawLines : MonoBehaviour
{
	// Token: 0x06000B03 RID: 2819 RVA: 0x00030F96 File Offset: 0x0002F396
	private void Start()
	{
		this.SetLine();
	}

	// Token: 0x06000B04 RID: 2820 RVA: 0x00030FA0 File Offset: 0x0002F3A0
	private void SetLine()
	{
		VectorLine.Destroy(ref this.line);
		if (!this.continuous)
		{
			this.fillJoins = false;
		}
		LineType lineType = (!this.continuous) ? LineType.Discrete : LineType.Continuous;
		Joins joins = (!this.fillJoins) ? Joins.None : Joins.Fill;
		int num = (!this.thickLine) ? 2 : 24;
		this.line = new VectorLine("Line", new List<Vector2>(), (float)num, lineType, joins);
		this.line.drawTransform = base.transform;
		this.endReached = false;
	}

	// Token: 0x06000B05 RID: 2821 RVA: 0x00031038 File Offset: 0x0002F438
	private void Update()
	{
		Vector3 v = base.transform.InverseTransformPoint(Input.mousePosition);
		if (Input.GetMouseButtonDown(0) && this.canClick && !this.endReached)
		{
			this.line.points2.Add(v);
			if (this.line.points2.Count == 1)
			{
				this.line.points2.Add(Vector2.zero);
			}
			if ((float)this.line.points2.Count == this.maxPoints)
			{
				this.endReached = true;
			}
		}
		if (this.line.points2.Count >= 2)
		{
			this.line.points2[this.line.points2.Count - 1] = v;
			this.line.Draw();
		}
		base.transform.RotateAround(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), Vector3.forward, Time.deltaTime * this.rotateSpeed * Input.GetAxis("Horizontal"));
	}

	// Token: 0x06000B06 RID: 2822 RVA: 0x00031168 File Offset: 0x0002F568
	private void OnGUI()
	{
		Rect screenRect = new Rect(20f, 20f, 265f, 220f);
		this.canClick = !screenRect.Contains(Event.current.mousePosition);
		GUILayout.BeginArea(screenRect);
		GUI.contentColor = Color.black;
		GUILayout.Label("Click to add points to the line\nRotate with the right/left arrow keys", new GUILayoutOption[0]);
		GUILayout.Space(5f);
		this.continuous = GUILayout.Toggle(this.continuous, "Continuous line", new GUILayoutOption[0]);
		this.thickLine = GUILayout.Toggle(this.thickLine, "Thick line", new GUILayoutOption[0]);
		this.line.lineWidth = (float)((!this.thickLine) ? 2 : 24);
		this.fillJoins = GUILayout.Toggle(this.fillJoins, "Fill joins (only works with continuous line)", new GUILayoutOption[0]);
		if (this.line.lineType != LineType.Continuous)
		{
			this.fillJoins = false;
		}
		this.weldJoins = GUILayout.Toggle(this.weldJoins, "Weld joins", new GUILayoutOption[0]);
		if (this.oldContinuous != this.continuous)
		{
			this.oldContinuous = this.continuous;
			this.line.lineType = ((!this.continuous) ? LineType.Discrete : LineType.Continuous);
		}
		if (this.oldFillJoins != this.fillJoins)
		{
			if (this.fillJoins)
			{
				this.weldJoins = false;
			}
			this.oldFillJoins = this.fillJoins;
		}
		else if (this.oldWeldJoins != this.weldJoins)
		{
			if (this.weldJoins)
			{
				this.fillJoins = false;
			}
			this.oldWeldJoins = this.weldJoins;
		}
		if (this.fillJoins)
		{
			this.line.joins = Joins.Fill;
		}
		else if (this.weldJoins)
		{
			this.line.joins = Joins.Weld;
		}
		else
		{
			this.line.joins = Joins.None;
		}
		GUILayout.Space(10f);
		GUI.contentColor = Color.white;
		if (GUILayout.Button("Randomize Color", new GUILayoutOption[]
		{
			GUILayout.Width(150f)
		}))
		{
			this.RandomizeColor();
		}
		if (GUILayout.Button("Randomize All Colors", new GUILayoutOption[]
		{
			GUILayout.Width(150f)
		}))
		{
			this.RandomizeAllColors();
		}
		if (GUILayout.Button("Reset line", new GUILayoutOption[]
		{
			GUILayout.Width(150f)
		}))
		{
			this.SetLine();
		}
		if (this.endReached)
		{
			GUI.contentColor = Color.black;
			GUILayout.Label("No more points available. You must be bored!", new GUILayoutOption[0]);
		}
		GUILayout.EndArea();
	}

	// Token: 0x06000B07 RID: 2823 RVA: 0x00031411 File Offset: 0x0002F811
	private void RandomizeColor()
	{
		this.line.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
	}

	// Token: 0x06000B08 RID: 2824 RVA: 0x00031438 File Offset: 0x0002F838
	private void RandomizeAllColors()
	{
		int segmentNumber = this.line.GetSegmentNumber();
		for (int i = 0; i < segmentNumber; i++)
		{
			this.line.SetColor(new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), i);
		}
	}

	// Token: 0x04000671 RID: 1649
	public float rotateSpeed = 90f;

	// Token: 0x04000672 RID: 1650
	public float maxPoints = 500f;

	// Token: 0x04000673 RID: 1651
	private VectorLine line;

	// Token: 0x04000674 RID: 1652
	private bool endReached;

	// Token: 0x04000675 RID: 1653
	private bool continuous = true;

	// Token: 0x04000676 RID: 1654
	private bool oldContinuous = true;

	// Token: 0x04000677 RID: 1655
	private bool fillJoins;

	// Token: 0x04000678 RID: 1656
	private bool oldFillJoins;

	// Token: 0x04000679 RID: 1657
	private bool weldJoins;

	// Token: 0x0400067A RID: 1658
	private bool oldWeldJoins;

	// Token: 0x0400067B RID: 1659
	private bool thickLine;

	// Token: 0x0400067C RID: 1660
	private bool canClick = true;
}
