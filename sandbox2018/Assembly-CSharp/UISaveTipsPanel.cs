using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000183 RID: 387
public class UISaveTipsPanel : MonoBehaviour
{
	// Token: 0x06000A1E RID: 2590 RVA: 0x0002BA88 File Offset: 0x00029E88
	public void Init()
	{
		base.GetComponent<RectTransform>().offsetMin = Vector2.zero;
		base.GetComponent<RectTransform>().offsetMax = Vector2.zero;
		base.StartCoroutine(this.DelayFade(this._showTime));
		base.StartCoroutine(this.DelayDestroy(this._showTime + this._fadeTime));
		Text component = base.transform.Find("Text").GetComponent<Text>();
		component.text = DataManager.Instance.dataLocalizationGroup.GetText("save_successfully");
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x0002BB14 File Offset: 0x00029F14
	private IEnumerator DelayFade(float t)
	{
		yield return new WaitForSeconds(t);
		UIFUHelper.UGUIFade(base.transform, 0f, this._fadeTime);
		yield break;
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x0002BB38 File Offset: 0x00029F38
	private IEnumerator DelayDestroy(float t)
	{
		yield return new WaitForSeconds(t);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x0002BB5A File Offset: 0x00029F5A
	private void Update()
	{
	}

	// Token: 0x04000623 RID: 1571
	private float _showTime = 0.5f;

	// Token: 0x04000624 RID: 1572
	private float _fadeTime = 0.5f;
}
