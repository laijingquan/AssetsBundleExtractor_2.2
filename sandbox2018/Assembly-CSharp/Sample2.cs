using System;
using OneP.InfinityScrollView;
using OneP.Samples;
using UnityEngine.UI;

// Token: 0x02000124 RID: 292
public class Sample2 : SingletonMono<Sample2>
{
	// Token: 0x06000791 RID: 1937 RVA: 0x0001FE0E File Offset: 0x0001E20E
	public int GetTotalItem()
	{
		return this.totalItem;
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x0001FE16 File Offset: 0x0001E216
	private void Update()
	{
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x0001FE18 File Offset: 0x0001E218
	public void Reload()
	{
		string text = this.input.text;
		int num = 0;
		if (!int.TryParse(text, out num))
		{
			num = 100;
		}
		if (num < 0)
		{
			num = 100;
		}
		this.totalItem = num;
		this.input.text = num.ToString();
		int num2 = num / 2;
		if (num % 2 == 1)
		{
			num2++;
		}
		this.infinityScroll1.Setup(num2);
		if (num / 2 > 0)
		{
			this.infinityScroll1.InternalReload();
		}
		this.infinityScroll2.Setup(num);
		if (num > 0)
		{
			this.infinityScroll2.InternalReload();
		}
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x0001FEBB File Offset: 0x0001E2BB
	public void OnClickItem(int index)
	{
		this.txtInfo.text = "Click On Item:" + index;
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x0001FED8 File Offset: 0x0001E2D8
	public void NextSample()
	{
		SampleGlobalValue.GoToNextSample();
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x0001FEDF File Offset: 0x0001E2DF
	public void ClickAds()
	{
		this.txtInfo.text = "Click On Ads";
	}

	// Token: 0x04000474 RID: 1140
	public InputField input;

	// Token: 0x04000475 RID: 1141
	public InfinityScrollView infinityScroll1;

	// Token: 0x04000476 RID: 1142
	public InfinityScrollView infinityScroll2;

	// Token: 0x04000477 RID: 1143
	public Text txtInfo;

	// Token: 0x04000478 RID: 1144
	private int totalItem = 100;
}
