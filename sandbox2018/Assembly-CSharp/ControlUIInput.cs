using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000AA RID: 170
public class ControlUIInput : MonoBehaviour
{
	// Token: 0x06000465 RID: 1125 RVA: 0x00014530 File Offset: 0x00012930
	private void Update()
	{
		this.getAxisText.text = ETCInput.GetAxis("Horizontal").ToString("f2");
		this.getAxisSpeedText.text = ETCInput.GetAxisSpeed("Horizontal").ToString("f2");
		this.getAxisYText.text = ETCInput.GetAxis("Vertical").ToString("f2");
		this.getAxisYSpeedText.text = ETCInput.GetAxisSpeed("Vertical").ToString("f2");
		if (ETCInput.GetAxisDownRight("Horizontal"))
		{
			this.downRightText.text = "YES";
			base.StartCoroutine(this.ClearText(this.downRightText));
		}
		if (ETCInput.GetAxisDownDown("Vertical"))
		{
			this.downDownText.text = "YES";
			base.StartCoroutine(this.ClearText(this.downDownText));
		}
		if (ETCInput.GetAxisDownLeft("Horizontal"))
		{
			this.downLeftText.text = "YES";
			base.StartCoroutine(this.ClearText(this.downLeftText));
		}
		if (ETCInput.GetAxisDownUp("Vertical"))
		{
			this.downUpText.text = "YES";
			base.StartCoroutine(this.ClearText(this.downUpText));
		}
		if (ETCInput.GetAxisPressedRight("Horizontal"))
		{
			this.rightText.text = "YES";
		}
		else
		{
			this.rightText.text = string.Empty;
		}
		if (ETCInput.GetAxisPressedDown("Vertical"))
		{
			this.downText.text = "YES";
		}
		else
		{
			this.downText.text = string.Empty;
		}
		if (ETCInput.GetAxisPressedLeft("Horizontal"))
		{
			this.leftText.text = "Yes";
		}
		else
		{
			this.leftText.text = string.Empty;
		}
		if (ETCInput.GetAxisPressedUp("Vertical"))
		{
			this.upText.text = "YES";
		}
		else
		{
			this.upText.text = string.Empty;
		}
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x00014760 File Offset: 0x00012B60
	private IEnumerator ClearText(Text textToCLead)
	{
		yield return new WaitForSeconds(0.3f);
		textToCLead.text = string.Empty;
		yield break;
	}

	// Token: 0x04000288 RID: 648
	public Text getAxisText;

	// Token: 0x04000289 RID: 649
	public Text getAxisSpeedText;

	// Token: 0x0400028A RID: 650
	public Text getAxisYText;

	// Token: 0x0400028B RID: 651
	public Text getAxisYSpeedText;

	// Token: 0x0400028C RID: 652
	public Text downRightText;

	// Token: 0x0400028D RID: 653
	public Text downDownText;

	// Token: 0x0400028E RID: 654
	public Text downLeftText;

	// Token: 0x0400028F RID: 655
	public Text downUpText;

	// Token: 0x04000290 RID: 656
	public Text rightText;

	// Token: 0x04000291 RID: 657
	public Text downText;

	// Token: 0x04000292 RID: 658
	public Text leftText;

	// Token: 0x04000293 RID: 659
	public Text upText;
}
