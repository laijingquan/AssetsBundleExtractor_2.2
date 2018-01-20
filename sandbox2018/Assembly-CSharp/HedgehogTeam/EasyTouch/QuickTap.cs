using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02000064 RID: 100
	[AddComponentMenu("EasyTouch/Quick Tap")]
	public class QuickTap : QuickBase
	{
		// Token: 0x060002CF RID: 719 RVA: 0x0000D8FC File Offset: 0x0000BCFC
		public QuickTap()
		{
			this.quickActionName = "QuickTap" + Guid.NewGuid().ToString().Substring(0, 7);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000D93C File Offset: 0x0000BD3C
		private void Update()
		{
			this.currentGesture = EasyTouch.current;
			if (this.currentGesture != null)
			{
				if (!this.is2Finger)
				{
					if (this.currentGesture.type == EasyTouch.EvtType.On_DoubleTap && this.actionTriggering == QuickTap.ActionTriggering.Double_Tap)
					{
						this.DoAction(this.currentGesture);
					}
					if (this.currentGesture.type == EasyTouch.EvtType.On_SimpleTap && this.actionTriggering == QuickTap.ActionTriggering.Simple_Tap)
					{
						this.DoAction(this.currentGesture);
					}
				}
				else
				{
					if (this.currentGesture.type == EasyTouch.EvtType.On_DoubleTap2Fingers && this.actionTriggering == QuickTap.ActionTriggering.Double_Tap)
					{
						this.DoAction(this.currentGesture);
					}
					if (this.currentGesture.type == EasyTouch.EvtType.On_SimpleTap2Fingers && this.actionTriggering == QuickTap.ActionTriggering.Simple_Tap)
					{
						this.DoAction(this.currentGesture);
					}
				}
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000DA14 File Offset: 0x0000BE14
		private void DoAction(Gesture gesture)
		{
			if (this.realType == QuickBase.GameObjectType.UI)
			{
				if (gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
				{
					this.onTap.Invoke(gesture);
				}
			}
			else if (((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && EasyTouch.GetGameObjectAt(gesture.position, this.is2Finger) == base.gameObject)
			{
				this.onTap.Invoke(gesture);
			}
		}

		// Token: 0x04000161 RID: 353
		[SerializeField]
		public QuickTap.OnTap onTap;

		// Token: 0x04000162 RID: 354
		public QuickTap.ActionTriggering actionTriggering;

		// Token: 0x04000163 RID: 355
		private Gesture currentGesture;

		// Token: 0x02000065 RID: 101
		[Serializable]
		public class OnTap : UnityEvent<Gesture>
		{
		}

		// Token: 0x02000066 RID: 102
		public enum ActionTriggering
		{
			// Token: 0x04000165 RID: 357
			Simple_Tap,
			// Token: 0x04000166 RID: 358
			Double_Tap
		}
	}
}
