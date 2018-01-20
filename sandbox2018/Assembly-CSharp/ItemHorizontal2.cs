using System;
using OneP.InfinityScrollView;
using OneP.Samples;
using UnityEngine.UI;

// Token: 0x02000123 RID: 291
public class ItemHorizontal2 : InfinityBaseItem
{
	// Token: 0x0600078C RID: 1932 RVA: 0x0001FDAE File Offset: 0x0001E1AE
	private void Start()
	{
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x0001FDB0 File Offset: 0x0001E1B0
	private void Update()
	{
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x0001FDB4 File Offset: 0x0001E1B4
	public override void Reload(InfinityScrollView _infinity, int _index)
	{
		base.Reload(_infinity, _index);
		this.text.text = (base.Index + 1).ToString();
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x0001FDEA File Offset: 0x0001E1EA
	public void OnClick()
	{
		SingletonMono<Sample2>.Instance.OnClickItem(base.Index + 1);
	}

	// Token: 0x04000472 RID: 1138
	public Image image;

	// Token: 0x04000473 RID: 1139
	public Text text;
}
