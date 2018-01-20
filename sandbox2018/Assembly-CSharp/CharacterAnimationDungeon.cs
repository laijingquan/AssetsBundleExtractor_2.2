using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class CharacterAnimationDungeon : MonoBehaviour
{
	// Token: 0x0600049B RID: 1179 RVA: 0x00015171 File Offset: 0x00013571
	private void Start()
	{
		this.cc = base.GetComponentInChildren<CharacterController>();
		this.anim = base.GetComponentInChildren<Animation>();
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x0001518C File Offset: 0x0001358C
	private void LateUpdate()
	{
		if (this.cc.isGrounded && (ETCInput.GetAxis("Vertical") != 0f || ETCInput.GetAxis("Horizontal") != 0f))
		{
			this.anim.CrossFade("soldierRun");
		}
		if (this.cc.isGrounded && ETCInput.GetAxis("Vertical") == 0f && ETCInput.GetAxis("Horizontal") == 0f)
		{
			this.anim.CrossFade("soldierIdleRelaxed");
		}
		if (!this.cc.isGrounded)
		{
			this.anim.CrossFade("soldierFalling");
		}
	}

	// Token: 0x040002A6 RID: 678
	private CharacterController cc;

	// Token: 0x040002A7 RID: 679
	private Animation anim;
}
