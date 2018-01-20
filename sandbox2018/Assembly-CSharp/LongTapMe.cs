using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000033 RID: 51
public class LongTapMe : MonoBehaviour
{
	// Token: 0x060001BE RID: 446 RVA: 0x00009444 File Offset: 0x00007844
	private void OnEnable()
	{
		EasyTouch.On_LongTapStart += this.On_LongTapStart;
		EasyTouch.On_LongTap += this.On_LongTap;
		EasyTouch.On_LongTapEnd += this.On_LongTapEnd;
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00009479 File Offset: 0x00007879
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00009481 File Offset: 0x00007881
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x00009489 File Offset: 0x00007889
	private void UnsubscribeEvent()
	{
		EasyTouch.On_LongTapStart -= this.On_LongTapStart;
		EasyTouch.On_LongTap -= this.On_LongTap;
		EasyTouch.On_LongTapEnd -= this.On_LongTapEnd;
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x000094BE File Offset: 0x000078BE
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
		this.startColor = base.gameObject.GetComponent<Renderer>().material.color;
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x000094E7 File Offset: 0x000078E7
	private void On_LongTapStart(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.RandomColor();
		}
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x00009505 File Offset: 0x00007905
	private void On_LongTap(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.textMesh.text = gesture.actionTime.ToString("f2");
		}
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x00009538 File Offset: 0x00007938
	private void On_LongTapEnd(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = this.startColor;
			this.textMesh.text = "Long tap me";
		}
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x00009588 File Offset: 0x00007988
	private void RandomColor()
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
	}

	// Token: 0x040000CF RID: 207
	private TextMesh textMesh;

	// Token: 0x040000D0 RID: 208
	private Color startColor;
}
