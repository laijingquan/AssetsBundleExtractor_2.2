using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
public class ImpactEffect : MonoBehaviour
{
	// Token: 0x06000478 RID: 1144 RVA: 0x00014D86 File Offset: 0x00013186
	private void Start()
	{
		this.ps = base.GetComponent<ParticleSystem>();
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x00014D94 File Offset: 0x00013194
	private void Update()
	{
		if (!this.ps.IsAlive())
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040002A0 RID: 672
	private ParticleSystem ps;
}
