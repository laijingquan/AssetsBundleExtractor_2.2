using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000B4 RID: 180
[Serializable]
public class ETCArea : MonoBehaviour
{
	// Token: 0x0600049F RID: 1183 RVA: 0x00015266 File Offset: 0x00013666
	public ETCArea()
	{
		this.show = true;
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x00015275 File Offset: 0x00013675
	public void Awake()
	{
		base.GetComponent<Image>().enabled = this.show;
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x00015288 File Offset: 0x00013688
	public void ApplyPreset(ETCArea.AreaPreset preset)
	{
		RectTransform component = base.transform.parent.GetComponent<RectTransform>();
		switch (preset)
		{
		case ETCArea.AreaPreset.TopLeft:
			this.rectTransform().anchoredPosition = new Vector2(-component.rect.width / 4f, component.rect.height / 4f);
			this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, component.rect.width / 2f);
			this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, component.rect.height / 2f);
			this.rectTransform().anchorMin = new Vector2(0f, 1f);
			this.rectTransform().anchorMax = new Vector2(0f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f, -this.rectTransform().sizeDelta.y / 2f);
			break;
		case ETCArea.AreaPreset.TopRight:
			this.rectTransform().anchoredPosition = new Vector2(component.rect.width / 4f, component.rect.height / 4f);
			this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, component.rect.width / 2f);
			this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, component.rect.height / 2f);
			this.rectTransform().anchorMin = new Vector2(1f, 1f);
			this.rectTransform().anchorMax = new Vector2(1f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f, -this.rectTransform().sizeDelta.y / 2f);
			break;
		case ETCArea.AreaPreset.BottomLeft:
			this.rectTransform().anchoredPosition = new Vector2(-component.rect.width / 4f, -component.rect.height / 4f);
			this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, component.rect.width / 2f);
			this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, component.rect.height / 2f);
			this.rectTransform().anchorMin = new Vector2(0f, 0f);
			this.rectTransform().anchorMax = new Vector2(0f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f, this.rectTransform().sizeDelta.y / 2f);
			break;
		case ETCArea.AreaPreset.BottomRight:
			this.rectTransform().anchoredPosition = new Vector2(component.rect.width / 4f, -component.rect.height / 4f);
			this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, component.rect.width / 2f);
			this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, component.rect.height / 2f);
			this.rectTransform().anchorMin = new Vector2(1f, 0f);
			this.rectTransform().anchorMax = new Vector2(1f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f, this.rectTransform().sizeDelta.y / 2f);
			break;
		}
	}

	// Token: 0x040002A8 RID: 680
	public bool show;

	// Token: 0x020000B5 RID: 181
	public enum AreaPreset
	{
		// Token: 0x040002AA RID: 682
		Choose,
		// Token: 0x040002AB RID: 683
		TopLeft,
		// Token: 0x040002AC RID: 684
		TopRight,
		// Token: 0x040002AD RID: 685
		BottomLeft,
		// Token: 0x040002AE RID: 686
		BottomRight
	}
}
