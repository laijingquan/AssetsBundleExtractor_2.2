using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x0200006B RID: 107
	[AddComponentMenu("EasyTouch/Quick Twist")]
	public class QuickTwist : QuickBase
	{
		// Token: 0x060002D9 RID: 729 RVA: 0x0000DE10 File Offset: 0x0000C210
		public QuickTwist()
		{
			this.quickActionName = "QuickTwist" + Guid.NewGuid().ToString().Substring(0, 7);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000DE4D File Offset: 0x0000C24D
		public override void OnEnable()
		{
			EasyTouch.On_Twist += this.On_Twist;
			EasyTouch.On_TwistEnd += this.On_TwistEnd;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000DE71 File Offset: 0x0000C271
		public override void OnDisable()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000DE79 File Offset: 0x0000C279
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000DE81 File Offset: 0x0000C281
		private void UnsubscribeEvent()
		{
			EasyTouch.On_Twist -= this.On_Twist;
			EasyTouch.On_TwistEnd -= this.On_TwistEnd;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000DEA5 File Offset: 0x0000C2A5
		private void On_Twist(Gesture gesture)
		{
			if (this.actionTriggering == QuickTwist.ActionTiggering.InProgress && this.IsRightRotation(gesture))
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000DEC5 File Offset: 0x0000C2C5
		private void On_TwistEnd(Gesture gesture)
		{
			if (this.actionTriggering == QuickTwist.ActionTiggering.End && this.IsRightRotation(gesture))
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000DEE8 File Offset: 0x0000C2E8
		private bool IsRightRotation(Gesture gesture)
		{
			this.axisActionValue = 0f;
			float num = 1f;
			if (this.inverseAxisValue)
			{
				num = -1f;
			}
			QuickTwist.ActionRotationDirection actionRotationDirection = this.rotationDirection;
			if (actionRotationDirection != QuickTwist.ActionRotationDirection.All)
			{
				if (actionRotationDirection != QuickTwist.ActionRotationDirection.Clockwise)
				{
					if (actionRotationDirection == QuickTwist.ActionRotationDirection.Counterclockwise)
					{
						if (gesture.twistAngle > 0f)
						{
							this.axisActionValue = gesture.twistAngle * this.sensibility * num;
							return true;
						}
					}
				}
				else if (gesture.twistAngle < 0f)
				{
					this.axisActionValue = gesture.twistAngle * this.sensibility * num;
					return true;
				}
				return false;
			}
			this.axisActionValue = gesture.twistAngle * this.sensibility * num;
			return true;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000DFA8 File Offset: 0x0000C3A8
		private void DoAction(Gesture gesture)
		{
			if (this.isGestureOnMe)
			{
				if (this.realType == QuickBase.GameObjectType.UI)
				{
					if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
					{
						this.onTwistAction.Invoke(gesture);
						if (this.enableSimpleAction)
						{
							base.DoDirectAction(this.axisActionValue);
						}
					}
				}
				else if (((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && gesture.GetCurrentPickedObject(true) == base.gameObject)
				{
					this.onTwistAction.Invoke(gesture);
					if (this.enableSimpleAction)
					{
						base.DoDirectAction(this.axisActionValue);
					}
				}
			}
			else if ((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI)
			{
				this.onTwistAction.Invoke(gesture);
				if (this.enableSimpleAction)
				{
					base.DoDirectAction(this.axisActionValue);
				}
			}
		}

		// Token: 0x0400016F RID: 367
		[SerializeField]
		public QuickTwist.OnTwistAction onTwistAction;

		// Token: 0x04000170 RID: 368
		public bool isGestureOnMe;

		// Token: 0x04000171 RID: 369
		public QuickTwist.ActionTiggering actionTriggering;

		// Token: 0x04000172 RID: 370
		public QuickTwist.ActionRotationDirection rotationDirection;

		// Token: 0x04000173 RID: 371
		private float axisActionValue;

		// Token: 0x04000174 RID: 372
		public bool enableSimpleAction;

		// Token: 0x0200006C RID: 108
		[Serializable]
		public class OnTwistAction : UnityEvent<Gesture>
		{
		}

		// Token: 0x0200006D RID: 109
		public enum ActionTiggering
		{
			// Token: 0x04000176 RID: 374
			InProgress,
			// Token: 0x04000177 RID: 375
			End
		}

		// Token: 0x0200006E RID: 110
		public enum ActionRotationDirection
		{
			// Token: 0x04000179 RID: 377
			All,
			// Token: 0x0400017A RID: 378
			Clockwise,
			// Token: 0x0400017B RID: 379
			Counterclockwise
		}
	}
}
