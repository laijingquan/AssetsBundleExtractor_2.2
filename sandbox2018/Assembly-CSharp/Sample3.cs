using System;
using System.Collections.Generic;
using OneP.InfinityScrollView;
using OneP.Samples;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000127 RID: 295
public class Sample3 : SingletonMono<Sample3>
{
	// Token: 0x060007A2 RID: 1954 RVA: 0x0002016C File Offset: 0x0001E56C
	private void Start()
	{
		string text = this.textAsset.ToString();
		string[] array = text.Split(new string[]
		{
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < array.Length; i++)
		{
			this.listIdUser.Add(array[i]);
		}
		this.verticleScroll.Setup();
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x000201C8 File Offset: 0x0001E5C8
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

	// Token: 0x060007A4 RID: 1956 RVA: 0x00020233 File Offset: 0x0001E633
	public void NextSample()
	{
		SampleGlobalValue.GoToNextSample();
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x0002023A File Offset: 0x0001E63A
	public string GetIDUser(int index)
	{
		if (this.listIdUser.Count > index && index > -1)
		{
			return this.listIdUser[index];
		}
		return string.Empty;
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x00020266 File Offset: 0x0001E666
	public void OnClickItem(int index)
	{
		this.txtInfo.text = "Click On User:" + index;
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x00020283 File Offset: 0x0001E683
	public void OnClickSkipItem(string skipInfo)
	{
		this.txtInfo.text = "Click On :" + skipInfo;
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x0002029B File Offset: 0x0001E69B
	private void Update()
	{
	}

	// Token: 0x0400047E RID: 1150
	public InputField input;

	// Token: 0x0400047F RID: 1151
	public InfinityScrollView verticleScroll;

	// Token: 0x04000480 RID: 1152
	public TextAsset textAsset;

	// Token: 0x04000481 RID: 1153
	public Text txtInfo;

	// Token: 0x04000482 RID: 1154
	private List<string> listIdUser = new List<string>();
}
