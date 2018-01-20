using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02000051 RID: 81
	[AddComponentMenu("EasyTouch/Quick Drag")]
	public class QuickDrag : QuickBase
	{
		// Token: 0x06000297 RID: 663 RVA: 0x0000C3A4 File Offset: 0x0000A7A4
		public QuickDrag()
		{
			this.quickActionName = "QuickDrag" + Guid.NewGuid().ToString().Substring(0, 7);
			this.axesAction = QuickBase.AffectedAxesAction.XY;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000C3E8 File Offset: 0x0000A7E8
		public override void OnEnable()
		{
			base.OnEnable();
			EasyTouch.On_TouchStart += this.On_TouchStart;
			EasyTouch.On_TouchDown += this.On_TouchDown;
			EasyTouch.On_TouchUp += this.On_TouchUp;
			EasyTouch.On_Drag += this.On_Drag;
			EasyTouch.On_DragStart += this.On_DragStart;
			EasyTouch.On_DragEnd += this.On_DragEnd;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000C461 File Offset: 0x0000A861
		public override void OnDisable()
		{
			base.OnDisable();
			this.UnsubscribeEvent();
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000C46F File Offset: 0x0000A86F
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000C478 File Offset: 0x0000A878
		private void UnsubscribeEvent()
		{
			EasyTouch.On_TouchStart -= this.On_TouchStart;
			EasyTouch.On_TouchDown -= this.On_TouchDown;
			EasyTouch.On_TouchUp -= this.On_TouchUp;
			EasyTouch.On_Drag -= this.On_Drag;
			EasyTouch.On_DragStart -= this.On_DragStart;
			EasyTouch.On_DragEnd -= this.On_DragEnd;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000C4EB File Offset: 0x0000A8EB
		private void OnCollisionEnter()
		{
			if (this.isStopOncollisionEnter && this.isOnDrag)
			{
				this.StopDrag();
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000C50C File Offset: 0x0000A90C
		private void On_TouchStart(Gesture gesture)
		{
			if (this.realType == QuickBase.GameObjectType.UI && gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)) && this.fingerIndex == -1)
			{
				this.fingerIndex = gesture.fingerIndex;
				base.transform.SetAsLastSibling();
				this.onDragStart.Invoke(gesture);
				this.isOnDrag = true;
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000C598 File Offset: 0x0000A998
		private void On_TouchDown(Gesture gesture)
		{
			if (this.isOnDrag && this.fingerIndex == gesture.fingerIndex && this.realType == QuickBase.GameObjectType.UI && gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
			{
				base.transform.position += gesture.deltaPosition;
				if (gesture.deltaPosition != Vector2.zero)
				{
					this.onDrag.Invoke(gesture);
				}
				this.lastGesture = gesture;
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000C652 File Offset: 0x0000AA52
		private void On_TouchUp(Gesture gesture)
		{
			if (this.fingerIndex == gesture.fingerIndex && this.realType == QuickBase.GameObjectType.UI)
			{
				this.lastGesture = gesture;
				this.StopDrag();
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000C680 File Offset: 0x0000AA80
		private void On_DragStart(Gesture gesture)
		{
			if (this.realType != QuickBase.GameObjectType.UI && ((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && gesture.pickedObject == base.gameObject && !this.isOnDrag)
			{
				this.isOnDrag = true;
				this.fingerIndex = gesture.fingerIndex;
				Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
				this.deltaPosition = touchToWorldPoint - base.transform.position;
				if (this.resetPhysic)
				{
					if (this.cachedRigidBody)
					{
						this.cachedRigidBody.isKinematic = true;
					}
					if (this.cachedRigidBody2D)
					{
						this.cachedRigidBody2D.isKinematic = true;
					}
				}
				this.onDragStart.Invoke(gesture);
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000C774 File Offset: 0x0000AB74
		private void On_Drag(Gesture gesture)
		{
			if (this.fingerIndex == gesture.fingerIndex && (this.realType == QuickBase.GameObjectType.Obj_2D || this.realType == QuickBase.GameObjectType.Obj_3D) && gesture.pickedObject == base.gameObject && this.fingerIndex == gesture.fingerIndex)
			{
				Vector3 position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position) - this.deltaPosition;
				base.transform.position = this.GetPositionAxes(position);
				if (gesture.deltaPosition != Vector2.zero)
				{
					this.onDrag.Invoke(gesture);
				}
				this.lastGesture = gesture;
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000C82D File Offset: 0x0000AC2D
		private void On_DragEnd(Gesture gesture)
		{
			if (this.fingerIndex == gesture.fingerIndex)
			{
				this.lastGesture = gesture;
				this.StopDrag();
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000C850 File Offset: 0x0000AC50
		private Vector3 GetPositionAxes(Vector3 position)
		{
			Vector3 result = position;
			switch (this.axesAction)
			{
			case QuickBase.AffectedAxesAction.X:
				result = new Vector3(position.x, base.transform.position.y, base.transform.position.z);
				break;
			case QuickBase.AffectedAxesAction.Y:
				result = new Vector3(base.transform.position.x, position.y, base.transform.position.z);
				break;
			case QuickBase.AffectedAxesAction.Z:
				result = new Vector3(base.transform.position.x, base.transform.position.y, position.z);
				break;
			case QuickBase.AffectedAxesAction.XY:
				result = new Vector3(position.x, position.y, base.transform.position.z);
				break;
			case QuickBase.AffectedAxesAction.XZ:
				result = new Vector3(position.x, base.transform.position.y, position.z);
				break;
			case QuickBase.AffectedAxesAction.YZ:
				result = new Vector3(base.transform.position.x, position.y, position.z);
				break;
			}
			return result;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000C9C4 File Offset: 0x0000ADC4
		public void StopDrag()
		{
			this.fingerIndex = -1;
			if (this.resetPhysic)
			{
				if (this.cachedRigidBody)
				{
					this.cachedRigidBody.isKinematic = this.isKinematic;
				}
				if (this.cachedRigidBody2D)
				{
					this.cachedRigidBody2D.isKinematic = this.isKinematic2D;
				}
			}
			this.isOnDrag = false;
			this.onDragEnd.Invoke(this.lastGesture);
		}

		// Token: 0x0400012B RID: 299
		[SerializeField]
		public QuickDrag.OnDragStart onDragStart;

		// Token: 0x0400012C RID: 300
		[SerializeField]
		public QuickDrag.OnDrag onDrag;

		// Token: 0x0400012D RID: 301
		[SerializeField]
		public QuickDrag.OnDragEnd onDragEnd;

		// Token: 0x0400012E RID: 302
		public bool isStopOncollisionEnter;

		// Token: 0x0400012F RID: 303
		private Vector3 deltaPosition;

		// Token: 0x04000130 RID: 304
		private bool isOnDrag;

		// Token: 0x04000131 RID: 305
		private Gesture lastGesture;

		// Token: 0x02000052 RID: 82
		[Serializable]
		public class OnDragStart : UnityEvent<Gesture>
		{
		}

		// Token: 0x02000053 RID: 83
		[Serializable]
		public class OnDrag : UnityEvent<Gesture>
		{
		}

		// Token: 0x02000054 RID: 84
		[Serializable]
		public class OnDragEnd : UnityEvent<Gesture>
		{
		}
	}
}
