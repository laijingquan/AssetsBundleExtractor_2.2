using System;
using UnityEngine;

// Token: 0x0200002D RID: 45
public class ThirdPersonCamera : MonoBehaviour
{
	// Token: 0x0600019C RID: 412 RVA: 0x00008D37 File Offset: 0x00007137
	private void Start()
	{
		this.follow = GameObject.FindWithTag("Player").transform;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00008D50 File Offset: 0x00007150
	private void LateUpdate()
	{
		this.targetPosition = this.follow.position + Vector3.up * this.distanceUp - this.follow.forward * this.distanceAway;
		base.transform.position = Vector3.Lerp(base.transform.position, this.targetPosition, Time.deltaTime * this.smooth);
		base.transform.LookAt(this.follow);
	}

	// Token: 0x040000C1 RID: 193
	public float distanceAway;

	// Token: 0x040000C2 RID: 194
	public float distanceUp;

	// Token: 0x040000C3 RID: 195
	public float smooth;

	// Token: 0x040000C4 RID: 196
	private GameObject hovercraft;

	// Token: 0x040000C5 RID: 197
	private Vector3 targetPosition;

	// Token: 0x040000C6 RID: 198
	private Transform follow;
}
