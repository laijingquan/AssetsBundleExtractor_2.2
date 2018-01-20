using System;
using OneP.InfinityScrollView;
using OneP.Samples;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000122 RID: 290
public class ItemHorizontal1 : InfinityBaseItem
{
	// Token: 0x06000788 RID: 1928 RVA: 0x0001FCEC File Offset: 0x0001E0EC
	public override void Reload(InfinityScrollView _infinity, int _index)
	{
		base.Reload(_infinity, _index);
		this.text1.text = (base.Index * 2 + 1).ToString();
		this.text2.text = (base.Index * 2 + 2).ToString();
		int totalItem = SingletonMono<Sample2>.Instance.GetTotalItem();
		if (_index * 2 + 1 < totalItem)
		{
			this.item2.SetActive(true);
		}
		else
		{
			this.item2.SetActive(false);
		}
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x0001FD7A File Offset: 0x0001E17A
	public void OnClick1()
	{
		SingletonMono<Sample2>.Instance.OnClickItem(base.Index * 2 + 1);
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x0001FD90 File Offset: 0x0001E190
	public void OnClick2()
	{
		SingletonMono<Sample2>.Instance.OnClickItem(base.Index * 2 + 2);
	}

	// Token: 0x0400046E RID: 1134
	public GameObject item1;

	// Token: 0x0400046F RID: 1135
	public GameObject item2;

	// Token: 0x04000470 RID: 1136
	public Text text1;

	// Token: 0x04000471 RID: 1137
	public Text text2;
}
