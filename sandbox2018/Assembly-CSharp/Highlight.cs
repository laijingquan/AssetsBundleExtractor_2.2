using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B8 RID: 440
public class Highlight : MonoBehaviour
{
	// Token: 0x06000B1F RID: 2847 RVA: 0x000321A8 File Offset: 0x000305A8
	private void Start()
	{
		Time.fixedDeltaTime = 0.01f;
		this.spheres = new GameObject[base.GetComponent<MakeSpheres>().numberOfSpheres];
		this.ignoreLayer = LayerMask.NameToLayer("Ignore Raycast");
		this.defaultLayer = LayerMask.NameToLayer("Default");
		this.line = new VectorLine("Line", new List<Vector2>(), (float)this.lineWidth);
		this.line.color = Color.green;
		this.line.capLength = (float)this.lineWidth * 0.5f;
		this.energyLine = new VectorLine("Energy", new List<Vector2>(this.pointsInEnergyLine), null, (float)this.energyLineWidth, LineType.Continuous);
		this.SetEnergyLinePoints();
	}

	// Token: 0x06000B20 RID: 2848 RVA: 0x00032268 File Offset: 0x00030668
	private void SetEnergyLinePoints()
	{
		for (int i = 0; i < this.energyLine.points2.Count; i++)
		{
			float x = Mathf.Lerp(70f, (float)(Screen.width - 20), (float)i / (float)this.energyLine.points2.Count);
			this.energyLine.points2[i] = new Vector2(x, (float)Screen.height * 0.1f);
		}
	}

	// Token: 0x06000B21 RID: 2849 RVA: 0x000322E4 File Offset: 0x000306E4
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > 50f && !this.fading)
		{
			if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift) && this.selectIndex > 0)
			{
				this.ResetSelection(true);
			}
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out this.hit))
			{
				this.spheres[this.selectIndex] = this.hit.collider.gameObject;
				this.spheres[this.selectIndex].layer = this.ignoreLayer;
				this.spheres[this.selectIndex].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
				this.selectIndex++;
				this.line.Resize(this.selectIndex * 10);
			}
		}
		for (int i = 0; i < this.selectIndex; i++)
		{
			float num = (float)Screen.height * this.selectionSize / Camera.main.transform.InverseTransformPoint(this.spheres[i].transform.position).z;
			Vector3 vector = Camera.main.WorldToScreenPoint(this.spheres[i].transform.position);
			Rect rect = new Rect(vector.x - num, vector.y - num, num * 2f, num * 2f);
			this.line.MakeRect(rect, i * 10);
			this.line.points2[i * 10 + 8] = new Vector2(rect.x - (float)this.lineWidth * 0.25f, rect.y + num);
			this.line.points2[i * 10 + 9] = new Vector2(35f, Mathf.Lerp(65f, (float)(Screen.height - 25), this.energyLevel));
			this.spheres[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(this.energyLevel, this.energyLevel, this.energyLevel));
		}
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x00032534 File Offset: 0x00030934
	private void FixedUpdate()
	{
		int i;
		for (i = 0; i < this.energyLine.points2.Count - 1; i++)
		{
			this.energyLine.points2[i] = new Vector2(this.energyLine.points2[i].x, this.energyLine.points2[i + 1].y);
		}
		this.timer += (double)(Time.deltaTime * Mathf.Lerp(5f, 20f, this.energyLevel));
		this.energyLine.points2[i] = new Vector2(this.energyLine.points2[i].x, (float)Screen.height * (0.1f + Mathf.Sin((float)this.timer) * 0.08f * this.energyLevel));
	}

	// Token: 0x06000B23 RID: 2851 RVA: 0x0003262C File Offset: 0x00030A2C
	private void LateUpdate()
	{
		this.line.Draw();
		this.energyLine.Draw();
	}

	// Token: 0x06000B24 RID: 2852 RVA: 0x00032644 File Offset: 0x00030A44
	private void ResetSelection(bool instantFade)
	{
		if (this.energyLevel > 0f)
		{
			base.StartCoroutine(this.FadeColor(instantFade));
		}
		this.selectIndex = 0;
		this.energyLevel = 0f;
		this.line.points2.Clear();
		this.line.Draw();
		foreach (GameObject gameObject in this.spheres)
		{
			if (gameObject)
			{
				gameObject.layer = this.defaultLayer;
			}
		}
	}

	// Token: 0x06000B25 RID: 2853 RVA: 0x000326D4 File Offset: 0x00030AD4
	private IEnumerator FadeColor(bool instantFade)
	{
		if (instantFade)
		{
			for (int i = 0; i < this.selectIndex; i++)
			{
				this.spheres[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
			}
		}
		else
		{
			this.fading = true;
			Color startColor = new Color(this.energyLevel, this.energyLevel, this.energyLevel, 0f);
			int thisIndex = this.selectIndex;
			for (float t = 0f; t < 1f; t += Time.deltaTime)
			{
				for (int j = 0; j < thisIndex; j++)
				{
					this.spheres[j].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(startColor, Color.black, t));
				}
				yield return null;
			}
			this.fading = false;
		}
		yield break;
	}

	// Token: 0x06000B26 RID: 2854 RVA: 0x000326F8 File Offset: 0x00030AF8
	private void OnGUI()
	{
		GUI.Label(new Rect(60f, 20f, 600f, 40f), "Click to select sphere, shift-click to select multiple spheres\nThen change energy level slider and click Go");
		this.energyLevel = GUI.VerticalSlider(new Rect(30f, 20f, 10f, (float)(Screen.height - 80)), this.energyLevel, 1f, 0f);
		if (this.selectIndex == 0)
		{
			this.energyLevel = 0f;
		}
		if (GUI.Button(new Rect(20f, (float)(Screen.height - 40), 32f, 20f), "Go"))
		{
			for (int i = 0; i < this.selectIndex; i++)
			{
				this.spheres[i].GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * this.force * this.energyLevel, ForceMode.VelocityChange);
			}
			this.ResetSelection(false);
		}
	}

	// Token: 0x040006AD RID: 1709
	public int lineWidth = 5;

	// Token: 0x040006AE RID: 1710
	public int energyLineWidth = 4;

	// Token: 0x040006AF RID: 1711
	public float selectionSize = 0.5f;

	// Token: 0x040006B0 RID: 1712
	public float force = 20f;

	// Token: 0x040006B1 RID: 1713
	public int pointsInEnergyLine = 100;

	// Token: 0x040006B2 RID: 1714
	private VectorLine line;

	// Token: 0x040006B3 RID: 1715
	private VectorLine energyLine;

	// Token: 0x040006B4 RID: 1716
	private RaycastHit hit;

	// Token: 0x040006B5 RID: 1717
	private int selectIndex;

	// Token: 0x040006B6 RID: 1718
	private float energyLevel;

	// Token: 0x040006B7 RID: 1719
	private bool canClick;

	// Token: 0x040006B8 RID: 1720
	private GameObject[] spheres;

	// Token: 0x040006B9 RID: 1721
	private double timer;

	// Token: 0x040006BA RID: 1722
	private int ignoreLayer;

	// Token: 0x040006BB RID: 1723
	private int defaultLayer;

	// Token: 0x040006BC RID: 1724
	private bool fading;
}
