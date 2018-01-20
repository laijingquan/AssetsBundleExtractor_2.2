using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A9 RID: 169
public class ControlUIEvent : MonoBehaviour
{
	// Token: 0x06000454 RID: 1108 RVA: 0x0001417C File Offset: 0x0001257C
	private void Update()
	{
		if (this.isDown)
		{
			this.downText.text = "YES";
			this.isDown = false;
		}
		else
		{
			this.downText.text = string.Empty;
		}
		if (this.isLeft)
		{
			this.leftText.text = "YES";
			this.isLeft = false;
		}
		else
		{
			this.leftText.text = string.Empty;
		}
		if (this.isUp)
		{
			this.upText.text = "YES";
			this.isUp = false;
		}
		else
		{
			this.upText.text = string.Empty;
		}
		if (this.isRight)
		{
			this.rightText.text = "YES";
			this.isRight = false;
		}
		else
		{
			this.rightText.text = string.Empty;
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x00014265 File Offset: 0x00012665
	public void MoveStart()
	{
		this.moveStartText.text = "YES";
		base.StartCoroutine(this.ClearText(this.moveStartText));
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0001428A File Offset: 0x0001268A
	public void Move(Vector2 move)
	{
		this.moveText.text = move.ToString();
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x000142A4 File Offset: 0x000126A4
	public void MoveSpeed(Vector2 move)
	{
		this.moveSpeedText.text = move.ToString();
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x000142C0 File Offset: 0x000126C0
	public void MoveEnd()
	{
		if (this.moveEndText.enabled)
		{
			this.moveEndText.text = "YES";
			base.StartCoroutine(this.ClearText(this.moveEndText));
			base.StartCoroutine(this.ClearText(this.touchUpText));
			base.StartCoroutine(this.ClearText(this.moveText));
			base.StartCoroutine(this.ClearText(this.moveSpeedText));
		}
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x00014339 File Offset: 0x00012739
	public void TouchStart()
	{
		this.touchStartText.text = "YES";
		base.StartCoroutine(this.ClearText(this.touchStartText));
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x00014360 File Offset: 0x00012760
	public void TouchUp()
	{
		this.touchUpText.text = "YES";
		base.StartCoroutine(this.ClearText(this.touchUpText));
		base.StartCoroutine(this.ClearText(this.moveText));
		base.StartCoroutine(this.ClearText(this.moveSpeedText));
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x000143B6 File Offset: 0x000127B6
	public void DownRight()
	{
		this.downRightText.text = "YES";
		base.StartCoroutine(this.ClearText(this.downRightText));
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x000143DB File Offset: 0x000127DB
	public void DownDown()
	{
		this.downDownText.text = "YES";
		base.StartCoroutine(this.ClearText(this.downDownText));
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x00014400 File Offset: 0x00012800
	public void DownLeft()
	{
		this.downLeftText.text = "YES";
		base.StartCoroutine(this.ClearText(this.downLeftText));
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x00014425 File Offset: 0x00012825
	public void DownUp()
	{
		this.downUpText.text = "YES";
		base.StartCoroutine(this.ClearText(this.downUpText));
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x0001444A File Offset: 0x0001284A
	public void Right()
	{
		this.isRight = true;
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x00014453 File Offset: 0x00012853
	public void Down()
	{
		this.isDown = true;
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x0001445C File Offset: 0x0001285C
	public void Left()
	{
		this.isLeft = true;
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x00014465 File Offset: 0x00012865
	public void Up()
	{
		this.isUp = true;
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x00014470 File Offset: 0x00012870
	private IEnumerator ClearText(Text textToCLead)
	{
		yield return new WaitForSeconds(0.3f);
		textToCLead.text = string.Empty;
		yield break;
	}

	// Token: 0x04000276 RID: 630
	public Text moveStartText;

	// Token: 0x04000277 RID: 631
	public Text moveText;

	// Token: 0x04000278 RID: 632
	public Text moveSpeedText;

	// Token: 0x04000279 RID: 633
	public Text moveEndText;

	// Token: 0x0400027A RID: 634
	public Text touchStartText;

	// Token: 0x0400027B RID: 635
	public Text touchUpText;

	// Token: 0x0400027C RID: 636
	public Text downRightText;

	// Token: 0x0400027D RID: 637
	public Text downDownText;

	// Token: 0x0400027E RID: 638
	public Text downLeftText;

	// Token: 0x0400027F RID: 639
	public Text downUpText;

	// Token: 0x04000280 RID: 640
	public Text rightText;

	// Token: 0x04000281 RID: 641
	public Text downText;

	// Token: 0x04000282 RID: 642
	public Text leftText;

	// Token: 0x04000283 RID: 643
	public Text upText;

	// Token: 0x04000284 RID: 644
	private bool isDown;

	// Token: 0x04000285 RID: 645
	private bool isLeft;

	// Token: 0x04000286 RID: 646
	private bool isUp;

	// Token: 0x04000287 RID: 647
	private bool isRight;
}
