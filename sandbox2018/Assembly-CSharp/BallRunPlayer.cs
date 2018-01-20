using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200002C RID: 44
public class BallRunPlayer : MonoBehaviour
{
	// Token: 0x06000194 RID: 404 RVA: 0x00008B3A File Offset: 0x00006F3A
	private void OnEnable()
	{
		EasyTouch.On_SwipeEnd += this.On_SwipeEnd;
	}

	// Token: 0x06000195 RID: 405 RVA: 0x00008B4D File Offset: 0x00006F4D
	private void OnDestroy()
	{
		EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
	}

	// Token: 0x06000196 RID: 406 RVA: 0x00008B60 File Offset: 0x00006F60
	private void Start()
	{
		this.characterController = base.GetComponent<CharacterController>();
		this.startPosition = base.transform.position;
	}

	// Token: 0x06000197 RID: 407 RVA: 0x00008B80 File Offset: 0x00006F80
	private void Update()
	{
		if (this.start)
		{
			this.moveDirection = base.transform.TransformDirection(Vector3.forward) * 10f * Time.deltaTime;
			this.moveDirection.y = this.moveDirection.y - 9.81f * Time.deltaTime;
			if (this.isJump)
			{
				this.moveDirection.y = 8f;
				this.isJump = false;
			}
			this.characterController.Move(this.moveDirection);
			this.ballModel.Rotate(Vector3.right * 400f * Time.deltaTime);
		}
		if ((double)base.transform.position.y < 0.5)
		{
			this.start = false;
			base.transform.position = this.startPosition;
		}
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00008C71 File Offset: 0x00007071
	private void OnCollision()
	{
		Debug.Log("ok");
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00008C80 File Offset: 0x00007080
	private void On_SwipeEnd(Gesture gesture)
	{
		if (this.start)
		{
			switch (gesture.swipe)
			{
			case EasyTouch.SwipeDirection.Left:
			case EasyTouch.SwipeDirection.UpLeft:
			case EasyTouch.SwipeDirection.DownLeft:
				base.transform.Rotate(Vector3.up * -90f);
				break;
			case EasyTouch.SwipeDirection.Right:
			case EasyTouch.SwipeDirection.UpRight:
			case EasyTouch.SwipeDirection.DownRight:
				base.transform.Rotate(Vector3.up * 90f);
				break;
			case EasyTouch.SwipeDirection.Up:
				if (this.characterController.isGrounded)
				{
					this.isJump = true;
				}
				break;
			}
		}
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00008D26 File Offset: 0x00007126
	public void StartGame()
	{
		this.start = true;
	}

	// Token: 0x040000BB RID: 187
	public Transform ballModel;

	// Token: 0x040000BC RID: 188
	private bool start;

	// Token: 0x040000BD RID: 189
	private Vector3 moveDirection;

	// Token: 0x040000BE RID: 190
	private CharacterController characterController;

	// Token: 0x040000BF RID: 191
	private Vector3 startPosition;

	// Token: 0x040000C0 RID: 192
	private bool isJump;
}
