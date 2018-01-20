using System;
using OneP.Samples;
using UnityEngine;

// Token: 0x02000125 RID: 293
public class ItemSkip : MonoBehaviour
{
	// Token: 0x06000798 RID: 1944 RVA: 0x0001FEF9 File Offset: 0x0001E2F9
	private void Start()
	{
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x0001FEFB File Offset: 0x0001E2FB
	private void Update()
	{
	}

	// Token: 0x0600079A RID: 1946 RVA: 0x0001FEFD File Offset: 0x0001E2FD
	public void OnClickSkipItem()
	{
		SingletonMono<Sample3>.Instance.OnClickSkipItem(this.skipName);
	}

	// Token: 0x04000479 RID: 1145
	public string skipName;
}
