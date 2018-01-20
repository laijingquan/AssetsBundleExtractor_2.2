using System;
using OneP.InfinityScrollView;
using UnityEngine.UI;

// Token: 0x0200012E RID: 302
public class ItemSample : InfinityBaseItem
{
	// Token: 0x060007C4 RID: 1988 RVA: 0x00020D6E File Offset: 0x0001F16E
	private void Start()
	{
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x00020D70 File Offset: 0x0001F170
	private void Update()
	{
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x00020D74 File Offset: 0x0001F174
	public override void Reload(InfinityScrollView _infinity, int _index)
	{
		base.Reload(_infinity, _index);
		if (this.listSample != null && this.listSample.listString.Count > base.Index)
		{
			this.text.text = this.listSample.listString[base.Index];
		}
	}

	// Token: 0x0400048F RID: 1167
	public ListSample listSample;

	// Token: 0x04000490 RID: 1168
	public Text text;
}
