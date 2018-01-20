using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02000059 RID: 89
	[AddComponentMenu("EasyTouch/Quick LongTap")]
	public class QuickLongTap : QuickBase
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x0000CDEC File Offset: 0x0000B1EC
		public QuickLongTap()
		{
			this.quickActionName = "QuickLongTap" + Guid.NewGuid().ToString().Substring(0, 7);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000CE2C File Offset: 0x0000B22C
		private void Update()
		{
			this.currentGesture = EasyTouch.current;
			if (this.currentGesture != null)
			{
				if (!this.is2Finger)
				{
					if (this.currentGesture.type == EasyTouch.EvtType.On_TouchStart && this.fingerIndex == -1 && this.IsOverMe(this.currentGesture))
					{
						this.fingerIndex = this.currentGesture.fingerIndex;
					}
					if (this.currentGesture.type == EasyTouch.EvtType.On_LongTapStart && this.actionTriggering == QuickLongTap.ActionTriggering.Start && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
					{
						this.DoAction(this.currentGesture);
					}
					if (this.currentGesture.type == EasyTouch.EvtType.On_LongTap && this.actionTriggering == QuickLongTap.ActionTriggering.InProgress && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
					{
						this.DoAction(this.currentGesture);
					}
					if (this.currentGesture.type == EasyTouch.EvtType.On_LongTapEnd && this.actionTriggering == QuickLongTap.ActionTriggering.End && (this.currentGesture.fingerIndex == this.fingerIndex || this.isMultiTouch))
					{
						this.DoAction(this.currentGesture);
						this.fingerIndex = -1;
					}
				}
				else
				{
					if (this.currentGesture.type == EasyTouch.EvtType.On_LongTapStart2Fingers && this.actionTriggering == QuickLongTap.ActionTriggering.Start)
					{
						this.DoAction(this.currentGesture);
					}
					if (this.currentGesture.type == EasyTouch.EvtType.On_LongTap2Fingers && this.actionTriggering == QuickLongTap.ActionTriggering.InProgress)
					{
						this.DoAction(this.currentGesture);
					}
					if (this.currentGesture.type == EasyTouch.EvtType.On_LongTapEnd2Fingers && this.actionTriggering == QuickLongTap.ActionTriggering.End)
					{
						this.DoAction(this.currentGesture);
					}
				}
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000CFFF File Offset: 0x0000B3FF
		private void DoAction(Gesture gesture)
		{
			if (this.IsOverMe(gesture))
			{
				this.onLongTap.Invoke(gesture);
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000D01C File Offset: 0x0000B41C
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

		// Token: 0x04000136 RID: 310
		[SerializeField]
		public QuickLongTap.OnLongTap onLongTap;

		// Token: 0x04000137 RID: 311
		public QuickLongTap.ActionTriggering actionTriggering;

		// Token: 0x04000138 RID: 312
		private Gesture currentGesture;

		// Token: 0x0200005A RID: 90
		[Serializable]
		public class OnLongTap : UnityEvent<Gesture>
		{
		}

		// Token: 0x0200005B RID: 91
		public enum ActionTriggering
		{
			// Token: 0x0400013A RID: 314
			Start,
			// Token: 0x0400013B RID: 315
			InProgress,
			// Token: 0x0400013C RID: 316
			End
		}
	}
}
