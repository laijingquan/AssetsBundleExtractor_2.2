using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public class CharacterAnimation : MonoBehaviour
{
	// Token: 0x06000498 RID: 1176 RVA: 0x00015013 File Offset: 0x00013413
	private void Start()
	{
		this.cc = base.GetComponentInChildren<CharacterController>();
		this.anim = base.GetComponentInChildren<Animation>();
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x00015030 File Offset: 0x00013430
	private void LateUpdate()
	{
		if (this.cc.isGrounded && ETCInput.GetAxis("Vertical") != 0f)
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
		if (this.cc.isGrounded && ETCInput.GetAxis("Vertical") == 0f && ETCInput.GetAxis("Horizontal") > 0f)
		{
			this.anim.CrossFade("soldierSpinRight");
		}
		if (this.cc.isGrounded && ETCInput.GetAxis("Vertical") == 0f && ETCInput.GetAxis("Horizontal") < 0f)
		{
			this.anim.CrossFade("soldierSpinLeft");
		}
	}

	// Token: 0x040002A4 RID: 676
	private CharacterController cc;

	// Token: 0x040002A5 RID: 677
	private Animation anim;
}
