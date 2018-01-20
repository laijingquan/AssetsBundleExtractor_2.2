using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A8 RID: 168
public class ButtonUIEvent : MonoBehaviour
{
	// Token: 0x0600044E RID: 1102 RVA: 0x00014013 File Offset: 0x00012413
	public void Down()
	{
		this.downText.text = "YES";
		base.StartCoroutine(this.ClearText(this.downText));
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x00014038 File Offset: 0x00012438
	public void Up()
	{
		this.upText.text = "YES";
		base.StartCoroutine(this.ClearText(this.upText));
		base.StartCoroutine(this.ClearText(this.pressText));
		base.StartCoroutine(this.ClearText(this.pressValueText));
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0001408E File Offset: 0x0001248E
	public void Press()
	{
		this.pressText.text = "YES";
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x000140A0 File Offset: 0x000124A0
	public void PressValue(float value)
	{
		this.pressValueText.text = value.ToString();
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x000140BC File Offset: 0x000124BC
	private IEnumerator ClearText(Text textToCLead)
	{
		yield return new WaitForSeconds(0.3f);
		textToCLead.text = string.Empty;
		yield break;
	}

	// Token: 0x04000272 RID: 626
	public Text downText;

	// Token: 0x04000273 RID: 627
	public Text pressText;

	// Token: 0x04000274 RID: 628
	public Text pressValueText;

	// Token: 0x04000275 RID: 629
	public Text upText;
}
