using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02000060 RID: 96
	[AddComponentMenu("EasyTouch/Quick Swipe")]
	public class QuickSwipe : QuickBase
	{
		// Token: 0x060002C3 RID: 707 RVA: 0x0000D398 File Offset: 0x0000B798
		public QuickSwipe()
		{
			this.quickActionName = "QuickSwipe" + Guid.NewGuid().ToString().Substring(0, 7);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000D3E4 File Offset: 0x0000B7E4
		public override void OnEnable()
		{
			base.OnEnable();
			EasyTouch.On_Drag += this.On_Drag;
			EasyTouch.On_Swipe += this.On_Swipe;
			EasyTouch.On_DragEnd += this.On_DragEnd;
			EasyTouch.On_SwipeEnd += this.On_SwipeEnd;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000D43B File Offset: 0x0000B83B
		public override void OnDisable()
		{
			base.OnDisable();
			this.UnsubscribeEvent();
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000D449 File Offset: 0x0000B849
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000D454 File Offset: 0x0000B854
		private void UnsubscribeEvent()
		{
			EasyTouch.On_Drag -= this.On_Drag;
			EasyTouch.On_Swipe -= this.On_Swipe;
			EasyTouch.On_DragEnd -= this.On_DragEnd;
			EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000D4A8 File Offset: 0x0000B8A8
		private void On_Swipe(Gesture gesture)
		{
			if (gesture.touchCount == 1 && ((gesture.pickedObject != base.gameObject && !this.allowSwipeStartOverMe) || this.allowSwipeStartOverMe))
			{
				this.fingerIndex = gesture.fingerIndex;
				if (this.actionTriggering == QuickSwipe.ActionTriggering.InProgress && this.isRightDirection(gesture))
				{
					this.onSwipeAction.Invoke(gesture);
					if (this.enableSimpleAction)
					{
						this.DoAction(gesture);
					}
				}
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000D530 File Offset: 0x0000B930
		private void On_SwipeEnd(Gesture gesture)
		{
			if (this.actionTriggering == QuickSwipe.ActionTriggering.End && this.isRightDirection(gesture))
			{
				this.onSwipeAction.Invoke(gesture);
				if (this.enableSimpleAction)
				{
					this.DoAction(gesture);
				}
			}
			if (this.fingerIndex == gesture.fingerIndex)
			{
				this.fingerIndex = -1;
			}
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000D58B File Offset: 0x0000B98B
		private void On_DragEnd(Gesture gesture)
		{
			if (gesture.pickedObject == base.gameObject && this.allowSwipeStartOverMe)
			{
				this.On_SwipeEnd(gesture);
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000D5B5 File Offset: 0x0000B9B5
		private void On_Drag(Gesture gesture)
		{
			if (gesture.pickedObject == base.gameObject && this.allowSwipeStartOverMe)
			{
				this.On_Swipe(gesture);
			}
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000D5E0 File Offset: 0x0000B9E0
		private bool isRightDirection(Gesture gesture)
		{
			float num = -1f;
			if (this.inverseAxisValue)
			{
				num = 1f;
			}
			this.axisActionValue = 0f;
			switch (this.swipeDirection)
			{
			case QuickSwipe.SwipeDirection.Vertical:
				if (gesture.swipe == EasyTouch.SwipeDirection.Up || gesture.swipe == EasyTouch.SwipeDirection.Down)
				{
					this.axisActionValue = gesture.deltaPosition.y * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Horizontal:
				if (gesture.swipe == EasyTouch.SwipeDirection.Left || gesture.swipe == EasyTouch.SwipeDirection.Right)
				{
					this.axisActionValue = gesture.deltaPosition.x * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.DiagonalRight:
				if (gesture.swipe == EasyTouch.SwipeDirection.UpRight || gesture.swipe == EasyTouch.SwipeDirection.DownLeft)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.DiagonalLeft:
				if (gesture.swipe == EasyTouch.SwipeDirection.UpLeft || gesture.swipe == EasyTouch.SwipeDirection.DownRight)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Up:
				if (gesture.swipe == EasyTouch.SwipeDirection.Up)
				{
					this.axisActionValue = gesture.deltaPosition.y * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.UpRight:
				if (gesture.swipe == EasyTouch.SwipeDirection.UpRight)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Right:
				if (gesture.swipe == EasyTouch.SwipeDirection.Right)
				{
					this.axisActionValue = gesture.deltaPosition.x * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.DownRight:
				if (gesture.swipe == EasyTouch.SwipeDirection.DownRight)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Down:
				if (gesture.swipe == EasyTouch.SwipeDirection.Down)
				{
					this.axisActionValue = gesture.deltaPosition.y * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.DownLeft:
				if (gesture.swipe == EasyTouch.SwipeDirection.DownLeft)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.Left:
				if (gesture.swipe == EasyTouch.SwipeDirection.Left)
				{
					this.axisActionValue = gesture.deltaPosition.x * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.UpLeft:
				if (gesture.swipe == EasyTouch.SwipeDirection.UpLeft)
				{
					this.axisActionValue = gesture.deltaPosition.magnitude * num;
					return true;
				}
				break;
			case QuickSwipe.SwipeDirection.All:
				this.axisActionValue = gesture.deltaPosition.magnitude * num;
				return true;
			}
			this.axisActionValue = 0f;
			return false;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000D870 File Offset: 0x0000BC70
		private void DoAction(Gesture gesture)
		{
			switch (this.directAction)
			{
			case QuickBase.DirectAction.Rotate:
			case QuickBase.DirectAction.RotateLocal:
				this.axisActionValue *= this.sensibility;
				break;
			case QuickBase.DirectAction.Translate:
			case QuickBase.DirectAction.TranslateLocal:
			case QuickBase.DirectAction.Scale:
				this.axisActionValue /= Screen.dpi;
				this.axisActionValue *= this.sensibility;
				break;
			}
			base.DoDirectAction(this.axisActionValue);
		}

		// Token: 0x0400014A RID: 330
		[SerializeField]
		public QuickSwipe.OnSwipeAction onSwipeAction;

		// Token: 0x0400014B RID: 331
		public bool allowSwipeStartOverMe = true;

		// Token: 0x0400014C RID: 332
		public QuickSwipe.ActionTriggering actionTriggering;

		// Token: 0x0400014D RID: 333
		public QuickSwipe.SwipeDirection swipeDirection = QuickSwipe.SwipeDirection.All;

		// Token: 0x0400014E RID: 334
		private float axisActionValue;

		// Token: 0x0400014F RID: 335
		public bool enableSimpleAction;

		// Token: 0x02000061 RID: 97
		[Serializable]
		public class OnSwipeAction : UnityEvent<Gesture>
		{
		}

		// Token: 0x02000062 RID: 98
		public enum ActionTriggering
		{
			// Token: 0x04000151 RID: 337
			InProgress,
			// Token: 0x04000152 RID: 338
			End
		}

		// Token: 0x02000063 RID: 99
		public enum SwipeDirection
		{
			// Token: 0x04000154 RID: 340
			Vertical,
			// Token: 0x04000155 RID: 341
			Horizontal,
			// Token: 0x04000156 RID: 342
			DiagonalRight,
			// Token: 0x04000157 RID: 343
			DiagonalLeft,
			// Token: 0x04000158 RID: 344
			Up,
			// Token: 0x04000159 RID: 345
			UpRight,
			// Token: 0x0400015A RID: 346
			Right,
			// Token: 0x0400015B RID: 347
			DownRight,
			// Token: 0x0400015C RID: 348
			Down,
			// Token: 0x0400015D RID: 349
			DownLeft,
			// Token: 0x0400015E RID: 350
			Left,
			// Token: 0x0400015F RID: 351
			UpLeft,
			// Token: 0x04000160 RID: 352
			All
		}
	}
}
