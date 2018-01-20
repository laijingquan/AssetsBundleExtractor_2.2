using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000B0 RID: 176
public class TouchPadUIEvent : MonoBehaviour
{
	// Token: 0x06000493 RID: 1171 RVA: 0x00014EDD File Offset: 0x000132DD
	public void TouchDown()
	{
		this.touchDownText.text = "YES";
		base.StartCoroutine(this.ClearText(this.touchDownText));
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x00014F02 File Offset: 0x00013302
	public void TouchEvt(Vector2 value)
	{
		this.touchText.text = value.ToString();
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x00014F1C File Offset: 0x0001331C
	public void TouchUp()
	{
		this.touchUpText.text = "YES";
		base.StartCoroutine(this.ClearText(this.touchUpText));
		base.StartCoroutine(this.ClearText(this.touchText));
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x00014F54 File Offset: 0x00013354
	private IEnumerator ClearText(Text textToCLead)
	{
		yield return new WaitForSeconds(0.3f);
		textToCLead.text = string.Empty;
		yield break;
	}

	// Token: 0x040002A1 RID: 673
	public Text touchDownText;

	// Token: 0x040002A2 RID: 674
	public Text touchText;

	// Token: 0x040002A3 RID: 675
	public Text touchUpText;
}
