using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000186 RID: 390
public class UIVipPanel : MonoBehaviour
{
	// Token: 0x06000A37 RID: 2615 RVA: 0x0002C4E8 File Offset: 0x0002A8E8
	public void Init()
	{
		base.GetComponent<RectTransform>().offsetMin = Vector2.zero;
		base.GetComponent<RectTransform>().offsetMax = Vector2.zero;
		Button component = base.transform.Find("ButtonClose").GetComponent<Button>();
		component.onClick.AddListener(delegate
		{
			this.OnButtonVipClosed(base.gameObject);
		});
		int vipType = PlayerManager.Instance.GetVipType();
		Button component2 = base.transform.Find("ButtonVip").GetComponent<Button>();
		Button component3 = base.transform.Find("ButtonVip2").GetComponent<Button>();
		Button component4 = base.transform.Find("ButtonLife").GetComponent<Button>();
		if (vipType == 1)
		{
			AdjustSdkManager.Instance.EventGroup1VipShow();
			component2.gameObject.SetActive(true);
			component3.gameObject.SetActive(false);
			component4.gameObject.SetActive(false);
			component2.onClick.AddListener(delegate
			{
				this.OnButtonVipClick(base.gameObject);
			});
		}
		else if (vipType == 2)
		{
			AdjustSdkManager.Instance.EventGroup2VipShow();
			component2.gameObject.SetActive(false);
			component3.gameObject.SetActive(true);
			component4.gameObject.SetActive(true);
			component3.onClick.AddListener(delegate
			{
				this.OnButtonVip2Click(base.gameObject);
			});
			component4.onClick.AddListener(delegate
			{
				this.OnButtonVipLifeClick(base.gameObject);
			});
		}
		Button component5 = base.transform.Find("ButtonResumeVip").GetComponent<Button>();
		component5.onClick.AddListener(delegate
		{
			this.OnButtonResumeVipClick(base.gameObject);
		});
		component5.gameObject.SetActive(false);
		this.LocalizationUI();
	}

	// Token: 0x06000A38 RID: 2616 RVA: 0x0002C68C File Offset: 0x0002AA8C
	private void LocalizationUI()
	{
		SystemLanguage language = LanguageManager.Instance.language;
		if (language != SystemLanguage.French)
		{
			if (language == SystemLanguage.Korean)
			{
				this.ChangeLocalizationImage("Korean");
			}
		}
		else
		{
			this.ChangeLocalizationImage("French");
		}
	}

	// Token: 0x06000A39 RID: 2617 RVA: 0x0002C6DC File Offset: 0x0002AADC
	private void ChangeLocalizationImage(string language)
	{
		string str = "Localization/VipImage/" + language + "/";
		Image component = base.transform.Find("Image_1").GetComponent<Image>();
		component.sprite = ResourceHelper.LoadSprite(str + "neigou_wenzi1");
		component.SetNativeSize();
		Image component2 = base.transform.Find("Image_2").GetComponent<Image>();
		component2.sprite = ResourceHelper.LoadSprite(str + "neigou_wenzi2");
		component2.SetNativeSize();
		Image component3 = base.transform.Find("ButtonVip").GetComponent<Image>();
		component3.sprite = ResourceHelper.LoadSprite(str + "neigou_anniu1");
		component3.SetNativeSize();
		Image component4 = base.transform.Find("ButtonVip2").GetComponent<Image>();
		component4.sprite = ResourceHelper.LoadSprite(str + "neigou_anniu");
		component4.SetNativeSize();
		Image component5 = base.transform.Find("ButtonLife").GetComponent<Image>();
		component5.sprite = ResourceHelper.LoadSprite(str + "neigou_anniu2");
		component5.SetNativeSize();
	}

	// Token: 0x06000A3A RID: 2618 RVA: 0x0002C7FA File Offset: 0x0002ABFA
	private void OnButtonVipClosed(GameObject go)
	{
		this.Close();
	}

	// Token: 0x06000A3B RID: 2619 RVA: 0x0002C802 File Offset: 0x0002AC02
	public void Close()
	{
		base.transform.SetParent(null);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x06000A3C RID: 2620 RVA: 0x0002C81B File Offset: 0x0002AC1B
	private void OnButtonResumeVipClick(GameObject go)
	{
		Debug.Log("恢复购买VIP");
	}

	// Token: 0x06000A3D RID: 2621 RVA: 0x0002C827 File Offset: 0x0002AC27
	private void OnButtonVipClick(GameObject go)
	{
		Debug.Log("购买VIP");
		AdjustSdkManager.Instance.EventGroup1VipPay();
		SubscriptionVip.Instance.BuySubscription();
	}

	// Token: 0x06000A3E RID: 2622 RVA: 0x0002C847 File Offset: 0x0002AC47
	private void OnButtonVip2Click(GameObject go)
	{
		Debug.Log("购买VIP2");
		AdjustSdkManager.Instance.EventGroup2VipPay1();
		SubscriptionVipTwo.Instance.BuySubscription2();
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x0002C867 File Offset: 0x0002AC67
	private void OnButtonVipLifeClick(GameObject go)
	{
		Debug.Log("购买VIPLife");
		AdjustSdkManager.Instance.EventGroup2VipPay2();
		SubscriptionVipTwo.Instance.BuyLifeVip();
	}
}
