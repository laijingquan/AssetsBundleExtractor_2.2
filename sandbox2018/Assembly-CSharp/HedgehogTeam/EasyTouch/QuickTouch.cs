using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02000067 RID: 103
	[AddComponentMenu("EasyTouch/Quick Touch")]
	public class QuickTouch : QuickBase
	{
		// Token: 0x060002D3 RID: 723 RVA: 0x0000DAD8 File Offset: 0x0000BED8
		public QuickTouch()
		{
			this.quickActionName = "QuickTouch" + Guid.NewGuid().ToString().Substring(0, 7);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000DB18 File Offset: 0x0000BF18
		private void Update()
		{
			this.currentGesture = EasyTouch.current;
			if (!this.is2Finger && this.currentGesture != null)
			{
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchStart && this.fingerIndex == -1 && this.IsOverMe(this.currentGesture))
				{
					this.fingerIndex = this.currentGesture.fingerIndex;
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchStart && this.actionTriggering == QuickTouch.ActionTriggering.Start && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchDown && this.actionTriggering == QuickTouch.ActionTriggering.Down && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchUp)
				{
					if (this.actionTriggering == QuickTouch.ActionTriggering.Up && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
					{
						if (this.IsOverMe(this.currentGesture))
						{
							this.onTouch.Invoke(this.currentGesture);
						}
						else
						{
							this.onTouchNotOverMe.Invoke(this.currentGesture);
						}
					}
					if (this.currentGesture.fingerIndex == this.fingerIndex)
					{
						this.fingerIndex = -1;
					}
				}
			}
			else if (this.currentGesture != null)
			{
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchStart2Fingers && this.actionTriggering == QuickTouch.ActionTriggering.Start)
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchDown2Fingers && this.actionTriggering == QuickTouch.ActionTriggering.Down)
				{
					this.DoAction(this.currentGesture);
				}
				if (this.currentGesture.type == EasyTouch.EvtType.On_TouchUp2Fingers && this.actionTriggering == QuickTouch.ActionTriggering.Up)
				{
					this.DoAction(this.currentGesture);
				}
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000DD38 File Offset: 0x0000C138
		private void DoAction(Gesture gesture)
		{
			if (this.IsOverMe(gesture))
			{
				this.onTouch.Invoke(gesture);
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000DD54 File Offset: 0x0000C154
		private bool IsOverMe(Gesture gesture)
		{
			bool result = false;
			if (this.realType == QuickBase.GameObjectType.UI)
			{
				if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
				{
					result = true;
				}
			}
			else if (((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && EasyTouch.GetGameObjectAt(gesture.position, this.is2Finger) == base.gameObject)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x04000167 RID: 359
		[SerializeField]
		public QuickTouch.OnTouch onTouch;

		// Token: 0x04000168 RID: 360
		public QuickTouch.OnTouchNotOverMe onTouchNotOverMe;

		// Token: 0x04000169 RID: 361
		public QuickTouch.ActionTriggering actionTriggering;

		// Token: 0x0400016A RID: 362
		private Gesture currentGesture;

		// Token: 0x02000068 RID: 104
		[Serializable]
		public class OnTouch : UnityEvent<Gesture>
		{
		}

		// Token: 0x02000069 RID: 105
		[Serializable]
		public class OnTouchNotOverMe : UnityEvent<Gesture>
		{
		}

		// Token: 0x0200006A RID: 106
		public enum ActionTriggering
		{
			// Token: 0x0400016C RID: 364
			Start,
			// Token: 0x0400016D RID: 365
			Down,
			// Token: 0x0400016E RID: 366
			Up
		}
	}
}
