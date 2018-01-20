using System;
using OneP.InfinityScrollView;
using OneP.Samples;
using UnityEngine.UI;

// Token: 0x0200011F RID: 287
public class Sample1 : SingletonMono<Sample1>
{
	// Token: 0x0600077F RID: 1919 RVA: 0x0001FC0E File Offset: 0x0001E00E
	private void Start()
	{
	}

	// Token: 0x06000780 RID: 1920 RVA: 0x0001FC10 File Offset: 0x0001E010
	private void Update()
	{
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x0001FC14 File Offset: 0x0001E014
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
		this.input.text = num.ToString();
		this.verticleScroll.Setup(num);
		if (num > 0)
		{
			this.verticleScroll.InternalReload();
		}
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x0001FC7F File Offset: 0x0001E07F
	public void OnClickItem(int index)
	{
		this.txtInfo.text = "Click On Item:" + index;
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x0001FC9C File Offset: 0x0001E09C
	public void NextSample()
	{
		SampleGlobalValue.GoToNextSample();
	}

	// Token: 0x04000463 RID: 1123
	public InputField input;

	// Token: 0x04000464 RID: 1124
	public InfinityScrollView verticleScroll;

	// Token: 0x04000465 RID: 1125
	public Text txtInfo;
}
