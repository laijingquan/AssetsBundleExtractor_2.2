using System;
using UnityEngine;

namespace OneP.InfinityScrollView
{
	// Token: 0x02000130 RID: 304
	public class InfinityBaseItem : MonoBehaviour
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x0001FA5C File Offset: 0x0001DE5C
		// (set) Token: 0x060007CB RID: 1995 RVA: 0x0001FA53 File Offset: 0x0001DE53
		public int Index
		{
			get
			{
				return this.index;
			}
			private set
			{
				this.index = value;
			}
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0001FA64 File Offset: 0x0001DE64
		public InfinityScrollView GetInfinityScrollView()
		{
			return this.infinityScrollView;
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0001FA6C File Offset: 0x0001DE6C
		private void Start()
		{
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0001FA6E File Offset: 0x0001DE6E
		private void Update()
		{
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0001FA70 File Offset: 0x0001DE70
		public virtual void Reload(InfinityScrollView infinity, int _index)
		{
			this.infinityScrollView = infinity;
			this.Index = _index;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0001FA80 File Offset: 0x0001DE80
		public virtual void SelfReload()
		{
			if (this.Index != -2147483648)
			{
			}
		}

		// Token: 0x04000493 RID: 1171
		private InfinityScrollView infinityScrollView;

		// Token: 0x04000494 RID: 1172
		private int index = int.MinValue;
	}
}
