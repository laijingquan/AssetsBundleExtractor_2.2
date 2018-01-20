using System;
using UnityEngine;

// Token: 0x020001B9 RID: 441
public class MakeSpheres : MonoBehaviour
{
	// Token: 0x06000B28 RID: 2856 RVA: 0x000329BC File Offset: 0x00030DBC
	private void Start()
	{
		for (int i = 0; i < this.numberOfSpheres; i++)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.spherePrefab, new Vector3(UnityEngine.Random.Range(-this.area, this.area), UnityEngine.Random.Range(-this.area, this.area), UnityEngine.Random.Range(-this.area, this.area)), UnityEngine.Random.rotation);
		}
	}

	// Token: 0x040006BD RID: 1725
	public GameObject spherePrefab;

	// Token: 0x040006BE RID: 1726
	public int numberOfSpheres = 12;

	// Token: 0x040006BF RID: 1727
	public float area = 4.5f;
}
