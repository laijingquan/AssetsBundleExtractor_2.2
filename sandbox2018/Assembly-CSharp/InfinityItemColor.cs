using System;
using OneP.InfinityScrollView;
using OneP.Samples;
using UnityEngine.UI;

// Token: 0x0200011E RID: 286
public class InfinityItemColor : InfinityBaseItem
{
	// Token: 0x0600077C RID: 1916 RVA: 0x0001FA9A File Offset: 0x0001DE9A
	public override void Reload(InfinityScrollView _infinity, int _index)
	{
		base.Reload(_infinity, _index);
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x0001FAA4 File Offset: 0x0001DEA4
	public void OnClick()
	{
		SingletonMono<Sample1>.Instance.OnClickItem(base.Index + 1);
	}

	// Token: 0x04000461 RID: 1121
	public Image image;

	// Token: 0x04000462 RID: 1122
	public Text text;
}
