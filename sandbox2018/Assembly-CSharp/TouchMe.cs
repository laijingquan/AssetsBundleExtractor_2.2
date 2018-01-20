using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x02000036 RID: 54
public class TouchMe : MonoBehaviour
{
	// Token: 0x060001D6 RID: 470 RVA: 0x000097C6 File Offset: 0x00007BC6
	private void OnEnable()
	{
		EasyTouch.On_TouchStart += this.On_TouchStart;
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchUp += this.On_TouchUp;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x000097FB File Offset: 0x00007BFB
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00009803 File Offset: 0x00007C03
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0000980B File Offset: 0x00007C0B
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00009840 File Offset: 0x00007C40
	private void Start()
	{
		this.textMesh = base.GetComponentInChildren<TextMesh>();
		this.startColor = base.gameObject.GetComponent<Renderer>().material.color;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00009869 File Offset: 0x00007C69
	private void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.RandomColor();
		}
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00009887 File Offset: 0x00007C87
	private void On_TouchDown(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			this.textMesh.text = "Down since :" + gesture.actionTime.ToString("f2");
		}
	}

	// Token: 0x060001DD RID: 477 RVA: 0x000098C4 File Offset: 0x00007CC4
	private void On_TouchUp(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = this.startColor;
			this.textMesh.text = "Touch me";
		}
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00009914 File Offset: 0x00007D14
	private void RandomColor()
	{
		base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
	}

	// Token: 0x040000D3 RID: 211
	private TextMesh textMesh;

	// Token: 0x040000D4 RID: 212
	private Color startColor;
}
