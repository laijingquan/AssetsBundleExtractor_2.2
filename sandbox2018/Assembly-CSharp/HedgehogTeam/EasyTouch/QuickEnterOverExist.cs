using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02000055 RID: 85
	[AddComponentMenu("EasyTouch/Quick Enter-Over-Exit")]
	public class QuickEnterOverExist : QuickBase
	{
		// Token: 0x060002A8 RID: 680 RVA: 0x0000CA58 File Offset: 0x0000AE58
		public QuickEnterOverExist()
		{
			this.quickActionName = "QuickEnterOverExit" + Guid.NewGuid().ToString().Substring(0, 7);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000CAA4 File Offset: 0x0000AEA4
		private void Awake()
		{
			for (int i = 0; i < 100; i++)
			{
				this.fingerOver[i] = false;
			}
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000CACD File Offset: 0x0000AECD
		public override void OnEnable()
		{
			base.OnEnable();
			EasyTouch.On_TouchDown += this.On_TouchDown;
			EasyTouch.On_TouchUp += this.On_TouchUp;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000CAF7 File Offset: 0x0000AEF7
		public override void OnDisable()
		{
			base.OnDisable();
			this.UnsubscribeEvent();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000CB05 File Offset: 0x0000AF05
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000CB0D File Offset: 0x0000AF0D
		private void UnsubscribeEvent()
		{
			EasyTouch.On_TouchDown -= this.On_TouchDown;
			EasyTouch.On_TouchUp -= this.On_TouchUp;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000CB34 File Offset: 0x0000AF34
		private void On_TouchDown(Gesture gesture)
		{
			if (this.realType != QuickBase.GameObjectType.UI)
			{
				if ((!this.enablePickOverUI && gesture.GetCurrentFirstPickedUIElement(false) == null) || this.enablePickOverUI)
				{
					if (gesture.GetCurrentPickedObject(false) == base.gameObject)
					{
						if (!this.fingerOver[gesture.fingerIndex] && ((!this.isOnTouch && !this.isMultiTouch) || this.isMultiTouch))
						{
							this.fingerOver[gesture.fingerIndex] = true;
							this.onTouchEnter.Invoke(gesture);
							this.isOnTouch = true;
						}
						else if (this.fingerOver[gesture.fingerIndex])
						{
							this.onTouchOver.Invoke(gesture);
						}
					}
					else if (this.fingerOver[gesture.fingerIndex])
					{
						this.fingerOver[gesture.fingerIndex] = false;
						this.onTouchExit.Invoke(gesture);
						if (!this.isMultiTouch)
						{
							this.isOnTouch = false;
						}
					}
				}
				else if (gesture.GetCurrentPickedObject(false) == base.gameObject && !this.enablePickOverUI && gesture.GetCurrentFirstPickedUIElement(false) != null && this.fingerOver[gesture.fingerIndex])
				{
					this.fingerOver[gesture.fingerIndex] = false;
					this.onTouchExit.Invoke(gesture);
					if (!this.isMultiTouch)
					{
						this.isOnTouch = false;
					}
				}
			}
			else if (gesture.GetCurrentFirstPickedUIElement(false) == base.gameObject)
			{
				if (!this.fingerOver[gesture.fingerIndex] && ((!this.isOnTouch && !this.isMultiTouch) || this.isMultiTouch))
				{
					this.fingerOver[gesture.fingerIndex] = true;
					this.onTouchEnter.Invoke(gesture);
					this.isOnTouch = true;
				}
				else if (this.fingerOver[gesture.fingerIndex])
				{
					this.onTouchOver.Invoke(gesture);
				}
			}
			else if (this.fingerOver[gesture.fingerIndex])
			{
				this.fingerOver[gesture.fingerIndex] = false;
				this.onTouchExit.Invoke(gesture);
				if (!this.isMultiTouch)
				{
					this.isOnTouch = false;
				}
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000CD93 File Offset: 0x0000B193
		private void On_TouchUp(Gesture gesture)
		{
			if (this.fingerOver[gesture.fingerIndex])
			{
				this.fingerOver[gesture.fingerIndex] = false;
				this.onTouchExit.Invoke(gesture);
				if (!this.isMultiTouch)
				{
					this.isOnTouch = false;
				}
			}
		}

		// Token: 0x04000132 RID: 306
		[SerializeField]
		public QuickEnterOverExist.OnTouchEnter onTouchEnter;

		// Token: 0x04000133 RID: 307
		[SerializeField]
		public QuickEnterOverExist.OnTouchOver onTouchOver;

		// Token: 0x04000134 RID: 308
		[SerializeField]
		public QuickEnterOverExist.OnTouchExit onTouchExit;

		// Token: 0x04000135 RID: 309
		private bool[] fingerOver = new bool[100];

		// Token: 0x02000056 RID: 86
		[Serializable]
		public class OnTouchEnter : UnityEvent<Gesture>
		{
		}

		// Token: 0x02000057 RID: 87
		[Serializable]
		public class OnTouchOver : UnityEvent<Gesture>
		{
		}

		// Token: 0x02000058 RID: 88
		[Serializable]
		public class OnTouchExit : UnityEvent<Gesture>
		{
		}
	}
}
