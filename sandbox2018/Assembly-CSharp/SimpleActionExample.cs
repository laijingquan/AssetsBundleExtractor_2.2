using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class SimpleActionExample : MonoBehaviour
{
	// Token: 0x06000253 RID: 595 RVA: 0x0000B04F File Offset: 0x0000944F
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
		this.startScale = base.transform.localScale;
	}

	// Token: 0x06000254 RID: 596 RVA: 0x0000B06E File Offset: 0x0000946E
	public void ChangeColor(Gesture gesture)
	{
		this.RandomColor();
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0000B076 File Offset: 0x00009476
	public void TimePressed(Gesture gesture)
	{
		this.textMesh.text = "Down since :" + gesture.actionTime.ToString("f2");
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0000B0A0 File Offset: 0x000094A0
	public void DisplaySwipeAngle(Gesture gesture)
	{
		float swipeOrDragAngle = gesture.GetSwipeOrDragAngle();
		this.textMesh.text = swipeOrDragAngle.ToString("f2") + " / " + gesture.swipe.ToString();
	}

	// Token: 0x06000257 RID: 599 RVA: 0x0000B0E6 File Offset: 0x000094E6
	public void ChangeText(string text)
	{
		this.textMesh.text = text;
	}

	// Token: 0x06000258 RID: 600 RVA: 0x0000B0F4 File Offset: 0x000094F4
	public void ResetScale()
	{
		base.transform.localScale = this.startScale;
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0000B108 File Offset: 0x00009508
	private void RandomColor()
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
	}

	// Token: 0x040000E5 RID: 229
	private TextMesh textMesh;

	// Token: 0x040000E6 RID: 230
	private Vector3 startScale;
}
