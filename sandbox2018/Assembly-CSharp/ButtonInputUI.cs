using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A7 RID: 167
public class ButtonInputUI : MonoBehaviour
{
	// Token: 0x06000448 RID: 1096 RVA: 0x00013E54 File Offset: 0x00012254
	private void Update()
	{
		if (ETCInput.GetButton("Button"))
		{
			this.getButtonText.text = "YES";
			this.getButtonTimeText.text = ETCInput.GetButtonValue("Button").ToString();
		}
		else
		{
			this.getButtonText.text = string.Empty;
			this.getButtonTimeText.text = string.Empty;
		}
		if (ETCInput.GetButtonDown("Button"))
		{
			this.getButtonDownText.text = "YES";
			base.StartCoroutine(this.ClearText(this.getButtonDownText));
		}
		if (ETCInput.GetButtonUp("Button"))
		{
			this.getButtonUpText.text = "YES";
			base.StartCoroutine(this.ClearText(this.getButtonUpText));
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x00013F2C File Offset: 0x0001232C
	private IEnumerator ClearText(Text textToCLead)
	{
		yield return new WaitForSeconds(0.3f);
		textToCLead.text = string.Empty;
		yield break;
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x00013F47 File Offset: 0x00012347
	public void SetSwipeIn(bool value)
	{
		ETCInput.SetControlSwipeIn("Button", value);
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x00013F54 File Offset: 0x00012354
	public void SetSwipeOut(bool value)
	{
		ETCInput.SetControlSwipeOut("Button", value);
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x00013F61 File Offset: 0x00012361
	public void setTimePush(bool value)
	{
		ETCInput.SetAxisOverTime("Button", value);
	}

	// Token: 0x0400026E RID: 622
	public Text getButtonDownText;

	// Token: 0x0400026F RID: 623
	public Text getButtonText;

	// Token: 0x04000270 RID: 624
	public Text getButtonTimeText;

	// Token: 0x04000271 RID: 625
	public Text getButtonUpText;
}
