using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x0200005C RID: 92
	[AddComponentMenu("EasyTouch/Quick Pinch")]
	public class QuickPinch : QuickBase
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x0000D0D0 File Offset: 0x0000B4D0
		public QuickPinch()
		{
			this.quickActionName = "QuickPinch" + Guid.NewGuid().ToString().Substring(0, 7);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000D110 File Offset: 0x0000B510
		public override void OnEnable()
		{
			EasyTouch.On_Pinch += this.On_Pinch;
			EasyTouch.On_PinchIn += this.On_PinchIn;
			EasyTouch.On_PinchOut += this.On_PinchOut;
			EasyTouch.On_PinchEnd += this.On_PichEnd;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000D161 File Offset: 0x0000B561
		public override void OnDisable()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000D169 File Offset: 0x0000B569
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000D174 File Offset: 0x0000B574
		private void UnsubscribeEvent()
		{
			EasyTouch.On_Pinch -= this.On_Pinch;
			EasyTouch.On_PinchIn -= this.On_PinchIn;
			EasyTouch.On_PinchOut -= this.On_PinchOut;
			EasyTouch.On_PinchEnd -= this.On_PichEnd;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000D1C5 File Offset: 0x0000B5C5
		private void On_Pinch(Gesture gesture)
		{
			if (this.actionTriggering == QuickPinch.ActionTiggering.InProgress && this.pinchDirection == QuickPinch.ActionPinchDirection.All)
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000D1E4 File Offset: 0x0000B5E4
		private void On_PinchIn(Gesture gesture)
		{
			if (this.actionTriggering == QuickPinch.ActionTiggering.InProgress & this.pinchDirection == QuickPinch.ActionPinchDirection.PinchIn)
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000D205 File Offset: 0x0000B605
		private void On_PinchOut(Gesture gesture)
		{
			if (this.actionTriggering == QuickPinch.ActionTiggering.InProgress & this.pinchDirection == QuickPinch.ActionPinchDirection.PinchOut)
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000D226 File Offset: 0x0000B626
		private void On_PichEnd(Gesture gesture)
		{
			if (this.actionTriggering == QuickPinch.ActionTiggering.End)
			{
				this.DoAction(gesture);
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000D23C File Offset: 0x0000B63C
		private void DoAction(Gesture gesture)
		{
			this.axisActionValue = gesture.deltaPinch * this.sensibility * Time.deltaTime;
			if (this.isGestureOnMe)
			{
				if (this.realType == QuickBase.GameObjectType.UI)
				{
					if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
					{
						this.onPinchAction.Invoke(gesture);
						if (this.enableSimpleAction)
						{
							base.DoDirectAction(this.axisActionValue);
						}
					}
				}
				else if (((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && gesture.GetCurrentPickedObject(true) == base.gameObject)
				{
					this.onPinchAction.Invoke(gesture);
					if (this.enableSimpleAction)
					{
						base.DoDirectAction(this.axisActionValue);
					}
				}
			}
			else if ((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI)
			{
				this.onPinchAction.Invoke(gesture);
				if (this.enableSimpleAction)
				{
					base.DoDirectAction(this.axisActionValue);
				}
			}
		}

		// Token: 0x0400013D RID: 317
		[SerializeField]
		public QuickPinch.OnPinchAction onPinchAction;

		// Token: 0x0400013E RID: 318
		public bool isGestureOnMe;

		// Token: 0x0400013F RID: 319
		public QuickPinch.ActionTiggering actionTriggering;

		// Token: 0x04000140 RID: 320
		public QuickPinch.ActionPinchDirection pinchDirection;

		// Token: 0x04000141 RID: 321
		private float axisActionValue;

		// Token: 0x04000142 RID: 322
		public bool enableSimpleAction;

		// Token: 0x0200005D RID: 93
		[Serializable]
		public class OnPinchAction : UnityEvent<Gesture>
		{
		}

		// Token: 0x0200005E RID: 94
		public enum ActionTiggering
		{
			// Token: 0x04000144 RID: 324
			InProgress,
			// Token: 0x04000145 RID: 325
			End
		}

		// Token: 0x0200005F RID: 95
		public enum ActionPinchDirection
		{
			// Token: 0x04000147 RID: 327
			All,
			// Token: 0x04000148 RID: 328
			PinchIn,
			// Token: 0x04000149 RID: 329
			PinchOut
		}
	}
}
