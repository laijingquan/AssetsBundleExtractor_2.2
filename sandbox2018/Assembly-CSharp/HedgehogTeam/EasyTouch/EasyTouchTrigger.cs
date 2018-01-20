using System;
using System.Collections.Generic;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02000049 RID: 73
	[AddComponentMenu("EasyTouch/Trigger")]
	[Serializable]
	public class EasyTouchTrigger : MonoBehaviour
	{
		// Token: 0x0600025B RID: 603 RVA: 0x0000B16F File Offset: 0x0000956F
		private void Start()
		{
			EasyTouch.SetEnableAutoSelect(true);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000B177 File Offset: 0x00009577
		private void OnEnable()
		{
			this.SubscribeEasyTouchEvent();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000B17F File Offset: 0x0000957F
		private void OnDisable()
		{
			this.UnsubscribeEasyTouchEvent();
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000B187 File Offset: 0x00009587
		private void OnDestroy()
		{
			this.UnsubscribeEasyTouchEvent();
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000B190 File Offset: 0x00009590
		private void SubscribeEasyTouchEvent()
		{
			if (this.IsRecevier4(EasyTouch.EvtType.On_Cancel))
			{
				EasyTouch.On_Cancel += this.On_Cancel;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchStart))
			{
				EasyTouch.On_TouchStart += this.On_TouchStart;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchDown))
			{
				EasyTouch.On_TouchDown += this.On_TouchDown;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchUp))
			{
				EasyTouch.On_TouchUp += this.On_TouchUp;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SimpleTap))
			{
				EasyTouch.On_SimpleTap += this.On_SimpleTap;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTapStart))
			{
				EasyTouch.On_LongTapStart += this.On_LongTapStart;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTap))
			{
				EasyTouch.On_LongTap += this.On_LongTap;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTapEnd))
			{
				EasyTouch.On_LongTapEnd += this.On_LongTapEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DoubleTap))
			{
				EasyTouch.On_DoubleTap += this.On_DoubleTap;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DragStart))
			{
				EasyTouch.On_DragStart += this.On_DragStart;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Drag))
			{
				EasyTouch.On_Drag += this.On_Drag;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DragEnd))
			{
				EasyTouch.On_DragEnd += this.On_DragEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SwipeStart))
			{
				EasyTouch.On_SwipeStart += this.On_SwipeStart;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Swipe))
			{
				EasyTouch.On_Swipe += this.On_Swipe;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SwipeEnd))
			{
				EasyTouch.On_SwipeEnd += this.On_SwipeEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchStart2Fingers))
			{
				EasyTouch.On_TouchStart2Fingers += this.On_TouchStart2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchDown2Fingers))
			{
				EasyTouch.On_TouchDown2Fingers += this.On_TouchDown2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TouchUp2Fingers))
			{
				EasyTouch.On_TouchUp2Fingers += this.On_TouchUp2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SimpleTap2Fingers))
			{
				EasyTouch.On_SimpleTap2Fingers += this.On_SimpleTap2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTapStart2Fingers))
			{
				EasyTouch.On_LongTapStart2Fingers += this.On_LongTapStart2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTap2Fingers))
			{
				EasyTouch.On_LongTap2Fingers += this.On_LongTap2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_LongTapEnd2Fingers))
			{
				EasyTouch.On_LongTapEnd2Fingers += this.On_LongTapEnd2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DoubleTap2Fingers))
			{
				EasyTouch.On_DoubleTap2Fingers += this.On_DoubleTap2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SwipeStart2Fingers))
			{
				EasyTouch.On_SwipeStart2Fingers += this.On_SwipeStart2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Swipe2Fingers))
			{
				EasyTouch.On_Swipe2Fingers += this.On_Swipe2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_SwipeEnd2Fingers))
			{
				EasyTouch.On_SwipeEnd2Fingers += this.On_SwipeEnd2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DragStart2Fingers))
			{
				EasyTouch.On_DragStart2Fingers += this.On_DragStart2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Drag2Fingers))
			{
				EasyTouch.On_Drag2Fingers += this.On_Drag2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_DragEnd2Fingers))
			{
				EasyTouch.On_DragEnd2Fingers += this.On_DragEnd2Fingers;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Pinch))
			{
				EasyTouch.On_Pinch += this.On_Pinch;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_PinchIn))
			{
				EasyTouch.On_PinchIn += this.On_PinchIn;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_PinchOut))
			{
				EasyTouch.On_PinchOut += this.On_PinchOut;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_PinchEnd))
			{
				EasyTouch.On_PinchEnd += this.On_PinchEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_Twist))
			{
				EasyTouch.On_Twist += this.On_Twist;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_TwistEnd))
			{
				EasyTouch.On_TwistEnd += this.On_TwistEnd;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_OverUIElement))
			{
				EasyTouch.On_OverUIElement += this.On_OverUIElement;
			}
			if (this.IsRecevier4(EasyTouch.EvtType.On_UIElementTouchUp))
			{
				EasyTouch.On_UIElementTouchUp += this.On_UIElementTouchUp;
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000B5EC File Offset: 0x000099EC
		private void UnsubscribeEasyTouchEvent()
		{
			EasyTouch.On_Cancel -= this.On_Cancel;
			EasyTouch.On_TouchStart -= this.On_TouchStart;
			EasyTouch.On_TouchDown -= this.On_TouchDown;
			EasyTouch.On_TouchUp -= this.On_TouchUp;
			EasyTouch.On_SimpleTap -= this.On_SimpleTap;
			EasyTouch.On_LongTapStart -= this.On_LongTapStart;
			EasyTouch.On_LongTap -= this.On_LongTap;
			EasyTouch.On_LongTapEnd -= this.On_LongTapEnd;
			EasyTouch.On_DoubleTap -= this.On_DoubleTap;
			EasyTouch.On_DragStart -= this.On_DragStart;
			EasyTouch.On_Drag -= this.On_Drag;
			EasyTouch.On_DragEnd -= this.On_DragEnd;
			EasyTouch.On_SwipeStart -= this.On_SwipeStart;
			EasyTouch.On_Swipe -= this.On_Swipe;
			EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
			EasyTouch.On_TouchStart2Fingers -= this.On_TouchStart2Fingers;
			EasyTouch.On_TouchDown2Fingers -= this.On_TouchDown2Fingers;
			EasyTouch.On_TouchUp2Fingers -= this.On_TouchUp2Fingers;
			EasyTouch.On_SimpleTap2Fingers -= this.On_SimpleTap2Fingers;
			EasyTouch.On_LongTapStart2Fingers -= this.On_LongTapStart2Fingers;
			EasyTouch.On_LongTap2Fingers -= this.On_LongTap2Fingers;
			EasyTouch.On_LongTapEnd2Fingers -= this.On_LongTapEnd2Fingers;
			EasyTouch.On_DoubleTap2Fingers -= this.On_DoubleTap2Fingers;
			EasyTouch.On_SwipeStart2Fingers -= this.On_SwipeStart2Fingers;
			EasyTouch.On_Swipe2Fingers -= this.On_Swipe2Fingers;
			EasyTouch.On_SwipeEnd2Fingers -= this.On_SwipeEnd2Fingers;
			EasyTouch.On_DragStart2Fingers -= this.On_DragStart2Fingers;
			EasyTouch.On_Drag2Fingers -= this.On_Drag2Fingers;
			EasyTouch.On_DragEnd2Fingers -= this.On_DragEnd2Fingers;
			EasyTouch.On_Pinch -= this.On_Pinch;
			EasyTouch.On_PinchIn -= this.On_PinchIn;
			EasyTouch.On_PinchOut -= this.On_PinchOut;
			EasyTouch.On_PinchEnd -= this.On_PinchEnd;
			EasyTouch.On_Twist -= this.On_Twist;
			EasyTouch.On_TwistEnd -= this.On_TwistEnd;
			EasyTouch.On_OverUIElement += this.On_OverUIElement;
			EasyTouch.On_UIElementTouchUp += this.On_UIElementTouchUp;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000B86E File Offset: 0x00009C6E
		private void On_TouchStart(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchStart, gesture);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000B878 File Offset: 0x00009C78
		private void On_TouchDown(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchDown, gesture);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000B882 File Offset: 0x00009C82
		private void On_TouchUp(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchUp, gesture);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000B88C File Offset: 0x00009C8C
		private void On_SimpleTap(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SimpleTap, gesture);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000B896 File Offset: 0x00009C96
		private void On_DoubleTap(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DoubleTap, gesture);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000B8A0 File Offset: 0x00009CA0
		private void On_LongTapStart(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTapStart, gesture);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000B8AA File Offset: 0x00009CAA
		private void On_LongTap(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTap, gesture);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000B8B4 File Offset: 0x00009CB4
		private void On_LongTapEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTapEnd, gesture);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000B8BE File Offset: 0x00009CBE
		private void On_SwipeStart(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SwipeStart, gesture);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000B8C9 File Offset: 0x00009CC9
		private void On_Swipe(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Swipe, gesture);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000B8D4 File Offset: 0x00009CD4
		private void On_SwipeEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SwipeEnd, gesture);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000B8DF File Offset: 0x00009CDF
		private void On_DragStart(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DragStart, gesture);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000B8EA File Offset: 0x00009CEA
		private void On_Drag(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Drag, gesture);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000B8F5 File Offset: 0x00009CF5
		private void On_DragEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DragEnd, gesture);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000B900 File Offset: 0x00009D00
		private void On_Cancel(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Cancel, gesture);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000B90B File Offset: 0x00009D0B
		private void On_TouchStart2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchStart2Fingers, gesture);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000B916 File Offset: 0x00009D16
		private void On_TouchDown2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchDown2Fingers, gesture);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000B921 File Offset: 0x00009D21
		private void On_TouchUp2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TouchUp2Fingers, gesture);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000B92C File Offset: 0x00009D2C
		private void On_LongTapStart2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTapStart2Fingers, gesture);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000B937 File Offset: 0x00009D37
		private void On_LongTap2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTap2Fingers, gesture);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000B942 File Offset: 0x00009D42
		private void On_LongTapEnd2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_LongTapEnd2Fingers, gesture);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000B94D File Offset: 0x00009D4D
		private void On_DragStart2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DragStart2Fingers, gesture);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000B958 File Offset: 0x00009D58
		private void On_Drag2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Drag2Fingers, gesture);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000B963 File Offset: 0x00009D63
		private void On_DragEnd2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DragEnd2Fingers, gesture);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000B96E File Offset: 0x00009D6E
		private void On_SwipeStart2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SwipeStart2Fingers, gesture);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000B979 File Offset: 0x00009D79
		private void On_Swipe2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Swipe2Fingers, gesture);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000B984 File Offset: 0x00009D84
		private void On_SwipeEnd2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SwipeEnd2Fingers, gesture);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000B98F File Offset: 0x00009D8F
		private void On_Twist(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Twist, gesture);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000B99A File Offset: 0x00009D9A
		private void On_TwistEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_TwistEnd, gesture);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000B9A5 File Offset: 0x00009DA5
		private void On_Pinch(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_Pinch, gesture);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000B9B0 File Offset: 0x00009DB0
		private void On_PinchOut(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_PinchOut, gesture);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000B9BB File Offset: 0x00009DBB
		private void On_PinchIn(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_PinchIn, gesture);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000B9C6 File Offset: 0x00009DC6
		private void On_PinchEnd(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_PinchEnd, gesture);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000B9D1 File Offset: 0x00009DD1
		private void On_SimpleTap2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_SimpleTap2Fingers, gesture);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000B9DC File Offset: 0x00009DDC
		private void On_DoubleTap2Fingers(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_DoubleTap2Fingers, gesture);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000B9E7 File Offset: 0x00009DE7
		private void On_UIElementTouchUp(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_UIElementTouchUp, gesture);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000B9F2 File Offset: 0x00009DF2
		private void On_OverUIElement(Gesture gesture)
		{
			this.TriggerScheduler(EasyTouch.EvtType.On_OverUIElement, gesture);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000BA00 File Offset: 0x00009E00
		public void AddTrigger(EasyTouch.EvtType ev)
		{
			EasyTouchTrigger.EasyTouchReceiver easyTouchReceiver = new EasyTouchTrigger.EasyTouchReceiver();
			easyTouchReceiver.enable = true;
			easyTouchReceiver.restricted = true;
			easyTouchReceiver.eventName = ev;
			easyTouchReceiver.gameObject = null;
			easyTouchReceiver.otherReceiver = false;
			easyTouchReceiver.name = "New trigger";
			this.receivers.Add(easyTouchReceiver);
			if (Application.isPlaying)
			{
				this.UnsubscribeEasyTouchEvent();
				this.SubscribeEasyTouchEvent();
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000BA64 File Offset: 0x00009E64
		public bool SetTriggerEnable(string triggerName, bool value)
		{
			EasyTouchTrigger.EasyTouchReceiver trigger = this.GetTrigger(triggerName);
			if (trigger != null)
			{
				trigger.enable = value;
				return true;
			}
			return false;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000BA8C File Offset: 0x00009E8C
		public bool GetTriggerEnable(string triggerName)
		{
			EasyTouchTrigger.EasyTouchReceiver trigger = this.GetTrigger(triggerName);
			return trigger != null && trigger.enable;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000BAB0 File Offset: 0x00009EB0
		private void TriggerScheduler(EasyTouch.EvtType evnt, Gesture gesture)
		{
			foreach (EasyTouchTrigger.EasyTouchReceiver easyTouchReceiver in this.receivers)
			{
				if (easyTouchReceiver.enable && easyTouchReceiver.eventName == evnt && ((easyTouchReceiver.restricted && ((gesture.pickedObject == base.gameObject && easyTouchReceiver.triggerType == EasyTouchTrigger.ETTType.Object3D) || (gesture.pickedUIElement == base.gameObject && easyTouchReceiver.triggerType == EasyTouchTrigger.ETTType.UI))) || (!easyTouchReceiver.restricted && (easyTouchReceiver.gameObject == null || (easyTouchReceiver.gameObject == gesture.pickedObject && easyTouchReceiver.triggerType == EasyTouchTrigger.ETTType.Object3D) || (gesture.pickedUIElement == easyTouchReceiver.gameObject && easyTouchReceiver.triggerType == EasyTouchTrigger.ETTType.UI)))))
				{
					GameObject gameObject = base.gameObject;
					if (easyTouchReceiver.otherReceiver && easyTouchReceiver.gameObjectReceiver != null)
					{
						gameObject = easyTouchReceiver.gameObjectReceiver;
					}
					switch (easyTouchReceiver.parameter)
					{
					case EasyTouchTrigger.ETTParameter.None:
						gameObject.SendMessage(easyTouchReceiver.methodName, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Gesture:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Finger_Id:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.fingerIndex, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Touch_Count:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.touchCount, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Start_Position:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.startPosition, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Position:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.position, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Delta_Position:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.deltaPosition, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Swipe_Type:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.swipe, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Swipe_Length:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.swipeLength, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Swipe_Vector:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.swipeVector, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Delta_Pinch:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.deltaPinch, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.Twist_Anlge:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.twistAngle, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.ActionTime:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.actionTime, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.DeltaTime:
						gameObject.SendMessage(easyTouchReceiver.methodName, gesture.deltaTime, SendMessageOptions.DontRequireReceiver);
						break;
					case EasyTouchTrigger.ETTParameter.PickedObject:
						if (gesture.pickedObject != null)
						{
							gameObject.SendMessage(easyTouchReceiver.methodName, gesture.pickedObject, SendMessageOptions.DontRequireReceiver);
						}
						break;
					case EasyTouchTrigger.ETTParameter.PickedUIElement:
						if (gesture.pickedUIElement != null)
						{
							gameObject.SendMessage(easyTouchReceiver.methodName, gesture.pickedObject, SendMessageOptions.DontRequireReceiver);
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000BE24 File Offset: 0x0000A224
		private bool IsRecevier4(EasyTouch.EvtType evnt)
		{
			int num = this.receivers.FindIndex((EasyTouchTrigger.EasyTouchReceiver e) => e.eventName == evnt);
			return num > -1;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000BE60 File Offset: 0x0000A260
		private EasyTouchTrigger.EasyTouchReceiver GetTrigger(string triggerName)
		{
			return this.receivers.Find((EasyTouchTrigger.EasyTouchReceiver n) => n.name == triggerName);
		}

		// Token: 0x040000E7 RID: 231
		[SerializeField]
		public List<EasyTouchTrigger.EasyTouchReceiver> receivers = new List<EasyTouchTrigger.EasyTouchReceiver>();

		// Token: 0x0200004A RID: 74
		public enum ETTParameter
		{
			// Token: 0x040000E9 RID: 233
			None,
			// Token: 0x040000EA RID: 234
			Gesture,
			// Token: 0x040000EB RID: 235
			Finger_Id,
			// Token: 0x040000EC RID: 236
			Touch_Count,
			// Token: 0x040000ED RID: 237
			Start_Position,
			// Token: 0x040000EE RID: 238
			Position,
			// Token: 0x040000EF RID: 239
			Delta_Position,
			// Token: 0x040000F0 RID: 240
			Swipe_Type,
			// Token: 0x040000F1 RID: 241
			Swipe_Length,
			// Token: 0x040000F2 RID: 242
			Swipe_Vector,
			// Token: 0x040000F3 RID: 243
			Delta_Pinch,
			// Token: 0x040000F4 RID: 244
			Twist_Anlge,
			// Token: 0x040000F5 RID: 245
			ActionTime,
			// Token: 0x040000F6 RID: 246
			DeltaTime,
			// Token: 0x040000F7 RID: 247
			PickedObject,
			// Token: 0x040000F8 RID: 248
			PickedUIElement
		}

		// Token: 0x0200004B RID: 75
		public enum ETTType
		{
			// Token: 0x040000FA RID: 250
			Object3D,
			// Token: 0x040000FB RID: 251
			UI
		}

		// Token: 0x0200004C RID: 76
		[Serializable]
		public class EasyTouchReceiver
		{
			// Token: 0x040000FC RID: 252
			public bool enable;

			// Token: 0x040000FD RID: 253
			public EasyTouchTrigger.ETTType triggerType;

			// Token: 0x040000FE RID: 254
			public string name;

			// Token: 0x040000FF RID: 255
			public bool restricted;

			// Token: 0x04000100 RID: 256
			public GameObject gameObject;

			// Token: 0x04000101 RID: 257
			public bool otherReceiver;

			// Token: 0x04000102 RID: 258
			public GameObject gameObjectReceiver;

			// Token: 0x04000103 RID: 259
			public EasyTouch.EvtType eventName;

			// Token: 0x04000104 RID: 260
			public string methodName;

			// Token: 0x04000105 RID: 261
			public EasyTouchTrigger.ETTParameter parameter;
		}
	}
}
