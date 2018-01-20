using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02000070 RID: 112
	public class EasyTouch : MonoBehaviour
	{
		// Token: 0x060002E5 RID: 741 RVA: 0x0000E1E8 File Offset: 0x0000C5E8
		public EasyTouch()
		{
			this.enable = true;
			this.allowUIDetection = true;
			this.enableUIMode = true;
			this.autoUpdatePickedUI = false;
			this.enabledNGuiMode = false;
			this.nGUICameras = new List<Camera>();
			this.autoSelect = true;
			this.touchCameras = new List<ECamera>();
			this.pickableLayers3D = 1;
			this.enable2D = false;
			this.pickableLayers2D = 1;
			this.gesturePriority = EasyTouch.GesturePriority.Tap;
			this.StationaryTolerance = 15f;
			this.longTapTime = 1f;
			this.doubleTapDetection = EasyTouch.DoubleTapDetection.BySystem;
			this.doubleTapTime = 0.3f;
			this.swipeTolerance = 0.85f;
			this.alwaysSendSwipe = false;
			this.enable2FingersGesture = true;
			this.twoFingerPickMethod = EasyTouch.TwoFingerPickMethod.Finger;
			this.enable2FingersSwipe = true;
			this.enablePinch = true;
			this.minPinchLength = 0f;
			this.enableTwist = true;
			this.minTwistAngle = 0f;
			this.enableSimulation = true;
			this.twistKey = KeyCode.LeftAlt;
			this.swipeKey = KeyCode.LeftControl;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060002E6 RID: 742 RVA: 0x0000E35C File Offset: 0x0000C75C
		// (remove) Token: 0x060002E7 RID: 743 RVA: 0x0000E390 File Offset: 0x0000C790
		public static event EasyTouch.TouchCancelHandler On_Cancel;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060002E8 RID: 744 RVA: 0x0000E3C4 File Offset: 0x0000C7C4
		// (remove) Token: 0x060002E9 RID: 745 RVA: 0x0000E3F8 File Offset: 0x0000C7F8
		public static event EasyTouch.Cancel2FingersHandler On_Cancel2Fingers;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060002EA RID: 746 RVA: 0x0000E42C File Offset: 0x0000C82C
		// (remove) Token: 0x060002EB RID: 747 RVA: 0x0000E460 File Offset: 0x0000C860
		public static event EasyTouch.TouchStartHandler On_TouchStart;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060002EC RID: 748 RVA: 0x0000E494 File Offset: 0x0000C894
		// (remove) Token: 0x060002ED RID: 749 RVA: 0x0000E4C8 File Offset: 0x0000C8C8
		public static event EasyTouch.TouchDownHandler On_TouchDown;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060002EE RID: 750 RVA: 0x0000E4FC File Offset: 0x0000C8FC
		// (remove) Token: 0x060002EF RID: 751 RVA: 0x0000E530 File Offset: 0x0000C930
		public static event EasyTouch.TouchUpHandler On_TouchUp;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060002F0 RID: 752 RVA: 0x0000E564 File Offset: 0x0000C964
		// (remove) Token: 0x060002F1 RID: 753 RVA: 0x0000E598 File Offset: 0x0000C998
		public static event EasyTouch.SimpleTapHandler On_SimpleTap;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060002F2 RID: 754 RVA: 0x0000E5CC File Offset: 0x0000C9CC
		// (remove) Token: 0x060002F3 RID: 755 RVA: 0x0000E600 File Offset: 0x0000CA00
		public static event EasyTouch.DoubleTapHandler On_DoubleTap;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060002F4 RID: 756 RVA: 0x0000E634 File Offset: 0x0000CA34
		// (remove) Token: 0x060002F5 RID: 757 RVA: 0x0000E668 File Offset: 0x0000CA68
		public static event EasyTouch.LongTapStartHandler On_LongTapStart;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060002F6 RID: 758 RVA: 0x0000E69C File Offset: 0x0000CA9C
		// (remove) Token: 0x060002F7 RID: 759 RVA: 0x0000E6D0 File Offset: 0x0000CAD0
		public static event EasyTouch.LongTapHandler On_LongTap;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060002F8 RID: 760 RVA: 0x0000E704 File Offset: 0x0000CB04
		// (remove) Token: 0x060002F9 RID: 761 RVA: 0x0000E738 File Offset: 0x0000CB38
		public static event EasyTouch.LongTapEndHandler On_LongTapEnd;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060002FA RID: 762 RVA: 0x0000E76C File Offset: 0x0000CB6C
		// (remove) Token: 0x060002FB RID: 763 RVA: 0x0000E7A0 File Offset: 0x0000CBA0
		public static event EasyTouch.DragStartHandler On_DragStart;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060002FC RID: 764 RVA: 0x0000E7D4 File Offset: 0x0000CBD4
		// (remove) Token: 0x060002FD RID: 765 RVA: 0x0000E808 File Offset: 0x0000CC08
		public static event EasyTouch.DragHandler On_Drag;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060002FE RID: 766 RVA: 0x0000E83C File Offset: 0x0000CC3C
		// (remove) Token: 0x060002FF RID: 767 RVA: 0x0000E870 File Offset: 0x0000CC70
		public static event EasyTouch.DragEndHandler On_DragEnd;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000300 RID: 768 RVA: 0x0000E8A4 File Offset: 0x0000CCA4
		// (remove) Token: 0x06000301 RID: 769 RVA: 0x0000E8D8 File Offset: 0x0000CCD8
		public static event EasyTouch.SwipeStartHandler On_SwipeStart;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000302 RID: 770 RVA: 0x0000E90C File Offset: 0x0000CD0C
		// (remove) Token: 0x06000303 RID: 771 RVA: 0x0000E940 File Offset: 0x0000CD40
		public static event EasyTouch.SwipeHandler On_Swipe;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000304 RID: 772 RVA: 0x0000E974 File Offset: 0x0000CD74
		// (remove) Token: 0x06000305 RID: 773 RVA: 0x0000E9A8 File Offset: 0x0000CDA8
		public static event EasyTouch.SwipeEndHandler On_SwipeEnd;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000306 RID: 774 RVA: 0x0000E9DC File Offset: 0x0000CDDC
		// (remove) Token: 0x06000307 RID: 775 RVA: 0x0000EA10 File Offset: 0x0000CE10
		public static event EasyTouch.TouchStart2FingersHandler On_TouchStart2Fingers;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000308 RID: 776 RVA: 0x0000EA44 File Offset: 0x0000CE44
		// (remove) Token: 0x06000309 RID: 777 RVA: 0x0000EA78 File Offset: 0x0000CE78
		public static event EasyTouch.TouchDown2FingersHandler On_TouchDown2Fingers;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600030A RID: 778 RVA: 0x0000EAAC File Offset: 0x0000CEAC
		// (remove) Token: 0x0600030B RID: 779 RVA: 0x0000EAE0 File Offset: 0x0000CEE0
		public static event EasyTouch.TouchUp2FingersHandler On_TouchUp2Fingers;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600030C RID: 780 RVA: 0x0000EB14 File Offset: 0x0000CF14
		// (remove) Token: 0x0600030D RID: 781 RVA: 0x0000EB48 File Offset: 0x0000CF48
		public static event EasyTouch.SimpleTap2FingersHandler On_SimpleTap2Fingers;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x0600030E RID: 782 RVA: 0x0000EB7C File Offset: 0x0000CF7C
		// (remove) Token: 0x0600030F RID: 783 RVA: 0x0000EBB0 File Offset: 0x0000CFB0
		public static event EasyTouch.DoubleTap2FingersHandler On_DoubleTap2Fingers;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000310 RID: 784 RVA: 0x0000EBE4 File Offset: 0x0000CFE4
		// (remove) Token: 0x06000311 RID: 785 RVA: 0x0000EC18 File Offset: 0x0000D018
		public static event EasyTouch.LongTapStart2FingersHandler On_LongTapStart2Fingers;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000312 RID: 786 RVA: 0x0000EC4C File Offset: 0x0000D04C
		// (remove) Token: 0x06000313 RID: 787 RVA: 0x0000EC80 File Offset: 0x0000D080
		public static event EasyTouch.LongTap2FingersHandler On_LongTap2Fingers;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000314 RID: 788 RVA: 0x0000ECB4 File Offset: 0x0000D0B4
		// (remove) Token: 0x06000315 RID: 789 RVA: 0x0000ECE8 File Offset: 0x0000D0E8
		public static event EasyTouch.LongTapEnd2FingersHandler On_LongTapEnd2Fingers;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000316 RID: 790 RVA: 0x0000ED1C File Offset: 0x0000D11C
		// (remove) Token: 0x06000317 RID: 791 RVA: 0x0000ED50 File Offset: 0x0000D150
		public static event EasyTouch.TwistHandler On_Twist;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000318 RID: 792 RVA: 0x0000ED84 File Offset: 0x0000D184
		// (remove) Token: 0x06000319 RID: 793 RVA: 0x0000EDB8 File Offset: 0x0000D1B8
		public static event EasyTouch.TwistEndHandler On_TwistEnd;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x0600031A RID: 794 RVA: 0x0000EDEC File Offset: 0x0000D1EC
		// (remove) Token: 0x0600031B RID: 795 RVA: 0x0000EE20 File Offset: 0x0000D220
		public static event EasyTouch.PinchHandler On_Pinch;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x0600031C RID: 796 RVA: 0x0000EE54 File Offset: 0x0000D254
		// (remove) Token: 0x0600031D RID: 797 RVA: 0x0000EE88 File Offset: 0x0000D288
		public static event EasyTouch.PinchInHandler On_PinchIn;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x0600031E RID: 798 RVA: 0x0000EEBC File Offset: 0x0000D2BC
		// (remove) Token: 0x0600031F RID: 799 RVA: 0x0000EEF0 File Offset: 0x0000D2F0
		public static event EasyTouch.PinchOutHandler On_PinchOut;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000320 RID: 800 RVA: 0x0000EF24 File Offset: 0x0000D324
		// (remove) Token: 0x06000321 RID: 801 RVA: 0x0000EF58 File Offset: 0x0000D358
		public static event EasyTouch.PinchEndHandler On_PinchEnd;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000322 RID: 802 RVA: 0x0000EF8C File Offset: 0x0000D38C
		// (remove) Token: 0x06000323 RID: 803 RVA: 0x0000EFC0 File Offset: 0x0000D3C0
		public static event EasyTouch.DragStart2FingersHandler On_DragStart2Fingers;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000324 RID: 804 RVA: 0x0000EFF4 File Offset: 0x0000D3F4
		// (remove) Token: 0x06000325 RID: 805 RVA: 0x0000F028 File Offset: 0x0000D428
		public static event EasyTouch.Drag2FingersHandler On_Drag2Fingers;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06000326 RID: 806 RVA: 0x0000F05C File Offset: 0x0000D45C
		// (remove) Token: 0x06000327 RID: 807 RVA: 0x0000F090 File Offset: 0x0000D490
		public static event EasyTouch.DragEnd2FingersHandler On_DragEnd2Fingers;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000328 RID: 808 RVA: 0x0000F0C4 File Offset: 0x0000D4C4
		// (remove) Token: 0x06000329 RID: 809 RVA: 0x0000F0F8 File Offset: 0x0000D4F8
		public static event EasyTouch.SwipeStart2FingersHandler On_SwipeStart2Fingers;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x0600032A RID: 810 RVA: 0x0000F12C File Offset: 0x0000D52C
		// (remove) Token: 0x0600032B RID: 811 RVA: 0x0000F160 File Offset: 0x0000D560
		public static event EasyTouch.Swipe2FingersHandler On_Swipe2Fingers;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x0600032C RID: 812 RVA: 0x0000F194 File Offset: 0x0000D594
		// (remove) Token: 0x0600032D RID: 813 RVA: 0x0000F1C8 File Offset: 0x0000D5C8
		public static event EasyTouch.SwipeEnd2FingersHandler On_SwipeEnd2Fingers;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x0600032E RID: 814 RVA: 0x0000F1FC File Offset: 0x0000D5FC
		// (remove) Token: 0x0600032F RID: 815 RVA: 0x0000F230 File Offset: 0x0000D630
		public static event EasyTouch.EasyTouchIsReadyHandler On_EasyTouchIsReady;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000330 RID: 816 RVA: 0x0000F264 File Offset: 0x0000D664
		// (remove) Token: 0x06000331 RID: 817 RVA: 0x0000F298 File Offset: 0x0000D698
		public static event EasyTouch.OverUIElementHandler On_OverUIElement;

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06000332 RID: 818 RVA: 0x0000F2CC File Offset: 0x0000D6CC
		// (remove) Token: 0x06000333 RID: 819 RVA: 0x0000F300 File Offset: 0x0000D700
		public static event EasyTouch.UIElementTouchUpHandler On_UIElementTouchUp;

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0000F334 File Offset: 0x0000D734
		public static EasyTouch instance
		{
			get
			{
				if (!EasyTouch._instance)
				{
					EasyTouch._instance = (UnityEngine.Object.FindObjectOfType(typeof(EasyTouch)) as EasyTouch);
					if (!EasyTouch._instance)
					{
						GameObject gameObject = new GameObject("Easytouch");
						EasyTouch._instance = gameObject.AddComponent<EasyTouch>();
					}
				}
				return EasyTouch._instance;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0000F393 File Offset: 0x0000D793
		public static Gesture current
		{
			get
			{
				return EasyTouch.instance._currentGesture;
			}
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000F39F File Offset: 0x0000D79F
		private void OnEnable()
		{
			if (Application.isPlaying && Application.isEditor)
			{
				this.Init();
			}
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000F3BB File Offset: 0x0000D7BB
		private void Awake()
		{
			this.Init();
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000F3C4 File Offset: 0x0000D7C4
		private void Start()
		{
			for (int i = 0; i < 100; i++)
			{
				this.singleDoubleTap[i] = new EasyTouch.DoubleTap();
			}
			int num = this.touchCameras.FindIndex((ECamera c) => c.camera == Camera.main);
			if (num < 0)
			{
				this.touchCameras.Add(new ECamera(Camera.main, false));
			}
			if (EasyTouch.On_EasyTouchIsReady != null)
			{
				EasyTouch.On_EasyTouchIsReady();
			}
			this._currentGestures.Add(new Gesture());
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000F45B File Offset: 0x0000D85B
		private void Init()
		{
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000F45D File Offset: 0x0000D85D
		private void OnDrawGizmos()
		{
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000F460 File Offset: 0x0000D860
		private void Update()
		{
			if (this.enable && EasyTouch.instance == this)
			{
				if (Application.isPlaying && Input.touchCount > 0)
				{
					this.enableRemote = true;
				}
				if (Application.isPlaying && Input.touchCount == 0)
				{
					this.enableRemote = false;
				}
				int num = this.input.TouchCount();
				if (this.oldTouchCount == 2 && num != 2 && num > 0)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_Cancel2Fingers, Vector2.zero, Vector2.zero, Vector2.zero, 0f, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, 0f);
				}
				this.UpdateTouches(true, num);
				this.twoFinger.oldPickedObject = this.twoFinger.pickedObject;
				if (this.enable2FingersGesture && num == 2)
				{
					this.TwoFinger();
				}
				for (int i = 0; i < 100; i++)
				{
					if (this.fingers[i] != null)
					{
						this.OneFinger(i);
					}
				}
				this.oldTouchCount = num;
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000F580 File Offset: 0x0000D980
		private void LateUpdate()
		{
			if (this._currentGestures.Count > 1)
			{
				this._currentGestures.RemoveAt(0);
			}
			else
			{
				this._currentGestures[0] = null;
			}
			this._currentGesture = this._currentGestures[0];
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000F5D0 File Offset: 0x0000D9D0
		private void UpdateTouches(bool realTouch, int touchCount)
		{
			this.fingers.CopyTo(this.tmpArray, 0);
			if (realTouch || this.enableRemote)
			{
				this.ResetTouches();
				for (int i = 0; i < touchCount; i++)
				{
					Touch touch = Input.GetTouch(i);
					int num = 0;
					while (num < 100 && this.fingers[i] == null)
					{
						if (this.tmpArray[num] != null && this.tmpArray[num].fingerIndex == touch.fingerId)
						{
							this.fingers[i] = this.tmpArray[num];
						}
						num++;
					}
					if (this.fingers[i] == null)
					{
						this.fingers[i] = new Finger();
						this.fingers[i].fingerIndex = touch.fingerId;
						this.fingers[i].gesture = EasyTouch.GestureType.None;
						this.fingers[i].phase = TouchPhase.Began;
					}
					else
					{
						this.fingers[i].phase = touch.phase;
					}
					if (this.fingers[i].phase != TouchPhase.Began)
					{
						this.fingers[i].deltaPosition = touch.position - this.fingers[i].position;
					}
					else
					{
						this.fingers[i].deltaPosition = Vector2.zero;
					}
					this.fingers[i].position = touch.position;
					this.fingers[i].tapCount = touch.tapCount;
					this.fingers[i].deltaTime = touch.deltaTime;
					this.fingers[i].touchCount = touchCount;
					this.fingers[i].altitudeAngle = touch.altitudeAngle;
					this.fingers[i].azimuthAngle = touch.azimuthAngle;
					this.fingers[i].maximumPossiblePressure = touch.maximumPossiblePressure;
					this.fingers[i].pressure = touch.pressure;
					this.fingers[i].radius = touch.radius;
					this.fingers[i].radiusVariance = touch.radiusVariance;
					this.fingers[i].touchType = touch.type;
				}
			}
			else
			{
				for (int j = 0; j < touchCount; j++)
				{
					this.fingers[j] = this.input.GetMouseTouch(j, this.fingers[j]);
					this.fingers[j].touchCount = touchCount;
				}
			}
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000F840 File Offset: 0x0000DC40
		private void ResetTouches()
		{
			for (int i = 0; i < 100; i++)
			{
				this.fingers[i] = null;
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000F86C File Offset: 0x0000DC6C
		private void OneFinger(int fingerIndex)
		{
			if (this.fingers[fingerIndex].gesture == EasyTouch.GestureType.None)
			{
				if (!this.singleDoubleTap[fingerIndex].inDoubleTap)
				{
					this.singleDoubleTap[fingerIndex].inDoubleTap = true;
					this.singleDoubleTap[fingerIndex].time = 0f;
					this.singleDoubleTap[fingerIndex].count = 1;
				}
				this.fingers[fingerIndex].startTimeAction = Time.realtimeSinceStartup;
				this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Acquisition;
				this.fingers[fingerIndex].startPosition = this.fingers[fingerIndex].position;
				if (this.autoSelect && this.GetPickedGameObject(this.fingers[fingerIndex], false))
				{
					this.fingers[fingerIndex].pickedObject = this.pickedObject.pickedObj;
					this.fingers[fingerIndex].isGuiCamera = this.pickedObject.isGUI;
					this.fingers[fingerIndex].pickedCamera = this.pickedObject.pickedCamera;
				}
				if (this.allowUIDetection)
				{
					this.fingers[fingerIndex].isOverGui = this.IsScreenPositionOverUI(this.fingers[fingerIndex].position);
					this.fingers[fingerIndex].pickedUIElement = this.GetFirstUIElementFromCache();
				}
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_TouchStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
			}
			if (this.singleDoubleTap[fingerIndex].inDoubleTap)
			{
				this.singleDoubleTap[fingerIndex].time += Time.deltaTime;
			}
			this.fingers[fingerIndex].actionTime = Time.realtimeSinceStartup - this.fingers[fingerIndex].startTimeAction;
			if (this.fingers[fingerIndex].phase == TouchPhase.Canceled)
			{
				this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Cancel;
			}
			if (this.fingers[fingerIndex].phase != TouchPhase.Ended && this.fingers[fingerIndex].phase != TouchPhase.Canceled)
			{
				if (this.fingers[fingerIndex].phase == TouchPhase.Stationary && this.fingers[fingerIndex].actionTime >= this.longTapTime && this.fingers[fingerIndex].gesture == EasyTouch.GestureType.Acquisition)
				{
					this.fingers[fingerIndex].gesture = EasyTouch.GestureType.LongTap;
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_LongTapStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
				}
				if (((this.fingers[fingerIndex].gesture == EasyTouch.GestureType.Acquisition || this.fingers[fingerIndex].gesture == EasyTouch.GestureType.LongTap) && this.fingers[fingerIndex].phase == TouchPhase.Moved && this.gesturePriority == EasyTouch.GesturePriority.Slips) || ((this.fingers[fingerIndex].gesture == EasyTouch.GestureType.Acquisition || this.fingers[fingerIndex].gesture == EasyTouch.GestureType.LongTap) && !this.FingerInTolerance(this.fingers[fingerIndex]) && this.gesturePriority == EasyTouch.GesturePriority.Tap))
				{
					if (this.fingers[fingerIndex].gesture == EasyTouch.GestureType.LongTap)
					{
						this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Cancel;
						this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_LongTapEnd, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
						this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Acquisition;
					}
					else
					{
						this.fingers[fingerIndex].oldSwipeType = EasyTouch.SwipeDirection.None;
						if (this.fingers[fingerIndex].pickedObject)
						{
							this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Drag;
							this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_DragStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
							if (this.alwaysSendSwipe)
							{
								this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SwipeStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
							}
						}
						else
						{
							this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Swipe;
							this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SwipeStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
						}
					}
				}
				EasyTouch.EvtType evtType = EasyTouch.EvtType.None;
				EasyTouch.GestureType gesture = this.fingers[fingerIndex].gesture;
				if (gesture != EasyTouch.GestureType.LongTap)
				{
					if (gesture != EasyTouch.GestureType.Drag)
					{
						if (gesture == EasyTouch.GestureType.Swipe)
						{
							evtType = EasyTouch.EvtType.On_Swipe;
						}
					}
					else
					{
						evtType = EasyTouch.EvtType.On_Drag;
					}
				}
				else
				{
					evtType = EasyTouch.EvtType.On_LongTap;
				}
				EasyTouch.SwipeDirection swipe = this.GetSwipe(new Vector2(0f, 0f), this.fingers[fingerIndex].deltaPosition);
				if (evtType != EasyTouch.EvtType.None)
				{
					this.fingers[fingerIndex].oldSwipeType = swipe;
					this.CreateGesture(fingerIndex, evtType, this.fingers[fingerIndex], swipe, 0f, this.fingers[fingerIndex].deltaPosition);
					if (evtType == EasyTouch.EvtType.On_Drag && this.alwaysSendSwipe)
					{
						this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_Swipe, this.fingers[fingerIndex], swipe, 0f, this.fingers[fingerIndex].deltaPosition);
					}
				}
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_TouchDown, this.fingers[fingerIndex], swipe, 0f, this.fingers[fingerIndex].deltaPosition);
			}
			else
			{
				switch (this.fingers[fingerIndex].gesture)
				{
				case EasyTouch.GestureType.Drag:
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_DragEnd, this.fingers[fingerIndex], this.GetSwipe(this.fingers[fingerIndex].startPosition, this.fingers[fingerIndex].position), (this.fingers[fingerIndex].startPosition - this.fingers[fingerIndex].position).magnitude, this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition);
					if (this.alwaysSendSwipe)
					{
						this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SwipeEnd, this.fingers[fingerIndex], this.GetSwipe(this.fingers[fingerIndex].startPosition, this.fingers[fingerIndex].position), (this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition).magnitude, this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition);
					}
					break;
				case EasyTouch.GestureType.Swipe:
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SwipeEnd, this.fingers[fingerIndex], this.GetSwipe(this.fingers[fingerIndex].startPosition, this.fingers[fingerIndex].position), (this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition).magnitude, this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition);
					break;
				case EasyTouch.GestureType.LongTap:
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_LongTapEnd, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
					break;
				case EasyTouch.GestureType.Cancel:
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_Cancel, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
					break;
				case EasyTouch.GestureType.Acquisition:
					if (this.doubleTapDetection == EasyTouch.DoubleTapDetection.BySystem)
					{
						if (this.FingerInTolerance(this.fingers[fingerIndex]))
						{
							if (this.fingers[fingerIndex].tapCount < 2)
							{
								this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SimpleTap, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
							}
							else
							{
								this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_DoubleTap, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
							}
						}
					}
					else if (!this.singleDoubleTap[fingerIndex].inWait)
					{
						this.singleDoubleTap[fingerIndex].finger = this.fingers[fingerIndex];
						base.StartCoroutine(this.SingleOrDouble(fingerIndex));
					}
					else
					{
						this.singleDoubleTap[fingerIndex].count++;
					}
					break;
				}
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_TouchUp, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
				this.fingers[fingerIndex] = null;
			}
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0001001C File Offset: 0x0000E41C
		private IEnumerator SingleOrDouble(int fingerIndex)
		{
			this.singleDoubleTap[fingerIndex].inWait = true;
			float time2Wait = this.doubleTapTime - this.singleDoubleTap[fingerIndex].finger.actionTime;
			if (time2Wait < 0f)
			{
				time2Wait = 0f;
			}
			yield return new WaitForSeconds(time2Wait);
			if (this.singleDoubleTap[fingerIndex].count < 2)
			{
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SimpleTap, this.singleDoubleTap[fingerIndex].finger, EasyTouch.SwipeDirection.None, 0f, this.singleDoubleTap[fingerIndex].finger.deltaPosition);
			}
			else
			{
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_DoubleTap, this.singleDoubleTap[fingerIndex].finger, EasyTouch.SwipeDirection.None, 0f, this.singleDoubleTap[fingerIndex].finger.deltaPosition);
			}
			this.singleDoubleTap[fingerIndex].Stop();
			base.StopCoroutine("SingleOrDouble");
			yield break;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00010040 File Offset: 0x0000E440
		private void CreateGesture(int touchIndex, EasyTouch.EvtType message, Finger finger, EasyTouch.SwipeDirection swipe, float swipeLength, Vector2 swipeVector)
		{
			bool flag = true;
			if (this.autoUpdatePickedUI && this.allowUIDetection)
			{
				finger.isOverGui = this.IsScreenPositionOverUI(finger.position);
				finger.pickedUIElement = this.GetFirstUIElementFromCache();
			}
			if (this.enabledNGuiMode && message == EasyTouch.EvtType.On_TouchStart)
			{
				finger.isOverGui = (finger.isOverGui || this.IsTouchOverNGui(finger.position, false));
			}
			if (this.enableUIMode || this.enabledNGuiMode)
			{
				flag = !finger.isOverGui;
			}
			Gesture gesture = finger.GetGesture();
			if (this.autoUpdatePickedObject && this.autoSelect && message != EasyTouch.EvtType.On_Drag && message != EasyTouch.EvtType.On_DragEnd && message != EasyTouch.EvtType.On_DragStart)
			{
				if (this.GetPickedGameObject(finger, false))
				{
					gesture.pickedObject = this.pickedObject.pickedObj;
					gesture.pickedCamera = this.pickedObject.pickedCamera;
					gesture.isGuiCamera = this.pickedObject.isGUI;
				}
				else
				{
					gesture.pickedObject = null;
					gesture.pickedCamera = null;
					gesture.isGuiCamera = false;
				}
			}
			gesture.swipe = swipe;
			gesture.swipeLength = swipeLength;
			gesture.swipeVector = swipeVector;
			gesture.deltaPinch = 0f;
			gesture.twistAngle = 0f;
			if (flag)
			{
				this.RaiseEvent(message, gesture);
			}
			else if (finger.isOverGui)
			{
				if (message == EasyTouch.EvtType.On_TouchUp)
				{
					this.RaiseEvent(EasyTouch.EvtType.On_UIElementTouchUp, gesture);
				}
				else
				{
					this.RaiseEvent(EasyTouch.EvtType.On_OverUIElement, gesture);
				}
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000101D0 File Offset: 0x0000E5D0
		private void TwoFinger()
		{
			bool flag = false;
			if (this.twoFinger.currentGesture == EasyTouch.GestureType.None)
			{
				if (!this.singleDoubleTap[99].inDoubleTap)
				{
					this.singleDoubleTap[99].inDoubleTap = true;
					this.singleDoubleTap[99].time = 0f;
					this.singleDoubleTap[99].count = 1;
				}
				this.twoFinger.finger0 = this.GetTwoFinger(-1);
				this.twoFinger.finger1 = this.GetTwoFinger(this.twoFinger.finger0);
				this.twoFinger.startTimeAction = Time.realtimeSinceStartup;
				this.twoFinger.currentGesture = EasyTouch.GestureType.Acquisition;
				this.fingers[this.twoFinger.finger0].startPosition = this.fingers[this.twoFinger.finger0].position;
				this.fingers[this.twoFinger.finger1].startPosition = this.fingers[this.twoFinger.finger1].position;
				this.fingers[this.twoFinger.finger0].oldPosition = this.fingers[this.twoFinger.finger0].position;
				this.fingers[this.twoFinger.finger1].oldPosition = this.fingers[this.twoFinger.finger1].position;
				this.twoFinger.oldFingerDistance = Mathf.Abs(Vector2.Distance(this.fingers[this.twoFinger.finger0].position, this.fingers[this.twoFinger.finger1].position));
				this.twoFinger.startPosition = new Vector2((this.fingers[this.twoFinger.finger0].position.x + this.fingers[this.twoFinger.finger1].position.x) / 2f, (this.fingers[this.twoFinger.finger0].position.y + this.fingers[this.twoFinger.finger1].position.y) / 2f);
				this.twoFinger.position = this.twoFinger.startPosition;
				this.twoFinger.oldStartPosition = this.twoFinger.startPosition;
				this.twoFinger.deltaPosition = Vector2.zero;
				this.twoFinger.startDistance = this.twoFinger.oldFingerDistance;
				if (this.autoSelect)
				{
					if (this.GetTwoFingerPickedObject())
					{
						this.twoFinger.pickedObject = this.pickedObject.pickedObj;
						this.twoFinger.pickedCamera = this.pickedObject.pickedCamera;
						this.twoFinger.isGuiCamera = this.pickedObject.isGUI;
					}
					else
					{
						this.twoFinger.ClearPickedObjectData();
					}
				}
				if (this.allowUIDetection)
				{
					if (this.GetTwoFingerPickedUIElement())
					{
						this.twoFinger.pickedUIElement = this.pickedObject.pickedObj;
						this.twoFinger.isOverGui = true;
					}
					else
					{
						this.twoFinger.ClearPickedUIData();
					}
				}
				this.CreateGesture2Finger(EasyTouch.EvtType.On_TouchStart2Fingers, this.twoFinger.startPosition, this.twoFinger.startPosition, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.oldFingerDistance);
			}
			if (this.singleDoubleTap[99].inDoubleTap)
			{
				this.singleDoubleTap[99].time += Time.deltaTime;
			}
			this.twoFinger.timeSinceStartAction = Time.realtimeSinceStartup - this.twoFinger.startTimeAction;
			this.twoFinger.position = new Vector2((this.fingers[this.twoFinger.finger0].position.x + this.fingers[this.twoFinger.finger1].position.x) / 2f, (this.fingers[this.twoFinger.finger0].position.y + this.fingers[this.twoFinger.finger1].position.y) / 2f);
			this.twoFinger.deltaPosition = this.twoFinger.position - this.twoFinger.oldStartPosition;
			this.twoFinger.fingerDistance = Mathf.Abs(Vector2.Distance(this.fingers[this.twoFinger.finger0].position, this.fingers[this.twoFinger.finger1].position));
			if (this.fingers[this.twoFinger.finger0].phase == TouchPhase.Canceled || this.fingers[this.twoFinger.finger1].phase == TouchPhase.Canceled)
			{
				this.twoFinger.currentGesture = EasyTouch.GestureType.Cancel;
			}
			if (this.fingers[this.twoFinger.finger0].phase != TouchPhase.Ended && this.fingers[this.twoFinger.finger1].phase != TouchPhase.Ended && this.twoFinger.currentGesture != EasyTouch.GestureType.Cancel)
			{
				if (this.twoFinger.currentGesture == EasyTouch.GestureType.Acquisition && this.twoFinger.timeSinceStartAction >= this.longTapTime && this.FingerInTolerance(this.fingers[this.twoFinger.finger0]) && this.FingerInTolerance(this.fingers[this.twoFinger.finger1]))
				{
					this.twoFinger.currentGesture = EasyTouch.GestureType.LongTap;
					this.CreateGesture2Finger(EasyTouch.EvtType.On_LongTapStart2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
				}
				if (((!this.FingerInTolerance(this.fingers[this.twoFinger.finger0]) || !this.FingerInTolerance(this.fingers[this.twoFinger.finger1])) && this.gesturePriority == EasyTouch.GesturePriority.Tap) || ((this.fingers[this.twoFinger.finger0].phase == TouchPhase.Moved || this.fingers[this.twoFinger.finger1].phase == TouchPhase.Moved) && this.gesturePriority == EasyTouch.GesturePriority.Slips))
				{
					flag = true;
				}
				if (flag && this.twoFinger.currentGesture != EasyTouch.GestureType.Tap)
				{
					Vector2 currentDistance = this.fingers[this.twoFinger.finger0].position - this.fingers[this.twoFinger.finger1].position;
					Vector2 previousDistance = this.fingers[this.twoFinger.finger0].oldPosition - this.fingers[this.twoFinger.finger1].oldPosition;
					float currentDelta = currentDistance.magnitude - previousDistance.magnitude;
					if (this.enable2FingersSwipe)
					{
						float num = Vector2.Dot(this.fingers[this.twoFinger.finger0].deltaPosition.normalized, this.fingers[this.twoFinger.finger1].deltaPosition.normalized);
						if (num > 0f)
						{
							if (this.twoFinger.oldGesture == EasyTouch.GestureType.LongTap)
							{
								this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, false, this.twoFinger.fingerDistance, 0f, 0f);
								this.twoFinger.startTimeAction = Time.realtimeSinceStartup;
							}
							if (this.twoFinger.pickedObject && !this.twoFinger.dragStart && !this.alwaysSendSwipe)
							{
								this.twoFinger.currentGesture = EasyTouch.GestureType.Drag;
								this.CreateGesture2Finger(EasyTouch.EvtType.On_DragStart2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
								this.CreateGesture2Finger(EasyTouch.EvtType.On_SwipeStart2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
								this.twoFinger.dragStart = true;
							}
							else if (!this.twoFinger.pickedObject && !this.twoFinger.swipeStart)
							{
								this.twoFinger.currentGesture = EasyTouch.GestureType.Swipe;
								this.CreateGesture2Finger(EasyTouch.EvtType.On_SwipeStart2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
								this.twoFinger.swipeStart = true;
							}
						}
						else if (num < 0f)
						{
							this.twoFinger.dragStart = false;
							this.twoFinger.swipeStart = false;
						}
						if (this.twoFinger.dragStart)
						{
							this.CreateGesture2Finger(EasyTouch.EvtType.On_Drag2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.oldStartPosition, this.twoFinger.position), 0f, this.twoFinger.deltaPosition, 0f, 0f, this.twoFinger.fingerDistance);
							this.CreateGesture2Finger(EasyTouch.EvtType.On_Swipe2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.oldStartPosition, this.twoFinger.position), 0f, this.twoFinger.deltaPosition, 0f, 0f, this.twoFinger.fingerDistance);
						}
						if (this.twoFinger.swipeStart)
						{
							this.CreateGesture2Finger(EasyTouch.EvtType.On_Swipe2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.oldStartPosition, this.twoFinger.position), 0f, this.twoFinger.deltaPosition, 0f, 0f, this.twoFinger.fingerDistance);
						}
					}
					this.DetectPinch(currentDelta);
					this.DetecTwist(previousDistance, currentDistance, currentDelta);
				}
				else if (this.twoFinger.currentGesture == EasyTouch.GestureType.LongTap)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_LongTap2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
				}
				this.CreateGesture2Finger(EasyTouch.EvtType.On_TouchDown2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.oldStartPosition, this.twoFinger.position), 0f, this.twoFinger.deltaPosition, 0f, 0f, this.twoFinger.fingerDistance);
				this.fingers[this.twoFinger.finger0].oldPosition = this.fingers[this.twoFinger.finger0].position;
				this.fingers[this.twoFinger.finger1].oldPosition = this.fingers[this.twoFinger.finger1].position;
				this.twoFinger.oldFingerDistance = this.twoFinger.fingerDistance;
				this.twoFinger.oldStartPosition = this.twoFinger.position;
				this.twoFinger.oldGesture = this.twoFinger.currentGesture;
			}
			else if (this.twoFinger.currentGesture != EasyTouch.GestureType.Acquisition && this.twoFinger.currentGesture != EasyTouch.GestureType.Tap)
			{
				this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, true, this.twoFinger.fingerDistance, 0f, 0f);
				this.twoFinger.currentGesture = EasyTouch.GestureType.None;
				this.twoFinger.pickedObject = null;
				this.twoFinger.swipeStart = false;
				this.twoFinger.dragStart = false;
			}
			else
			{
				this.twoFinger.currentGesture = EasyTouch.GestureType.Tap;
				this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, true, this.twoFinger.fingerDistance, 0f, 0f);
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00010F9C File Offset: 0x0000F39C
		private void DetectPinch(float currentDelta)
		{
			if (this.enablePinch)
			{
				if ((Mathf.Abs(this.twoFinger.fingerDistance - this.twoFinger.startDistance) >= this.minPinchLength && this.twoFinger.currentGesture != EasyTouch.GestureType.Pinch) || this.twoFinger.currentGesture == EasyTouch.GestureType.Pinch)
				{
					if (currentDelta != 0f && this.twoFinger.oldGesture == EasyTouch.GestureType.LongTap)
					{
						this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, false, this.twoFinger.fingerDistance, 0f, 0f);
						this.twoFinger.startTimeAction = Time.realtimeSinceStartup;
					}
					this.twoFinger.currentGesture = EasyTouch.GestureType.Pinch;
					if (currentDelta > 0f)
					{
						this.CreateGesture2Finger(EasyTouch.EvtType.On_PinchOut, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.startPosition, this.twoFinger.position), 0f, Vector2.zero, 0f, Mathf.Abs(this.twoFinger.fingerDistance - this.twoFinger.oldFingerDistance), this.twoFinger.fingerDistance);
					}
					if (currentDelta < 0f)
					{
						this.CreateGesture2Finger(EasyTouch.EvtType.On_PinchIn, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.startPosition, this.twoFinger.position), 0f, Vector2.zero, 0f, Mathf.Abs(this.twoFinger.fingerDistance - this.twoFinger.oldFingerDistance), this.twoFinger.fingerDistance);
					}
					if (currentDelta < 0f || currentDelta > 0f)
					{
						this.CreateGesture2Finger(EasyTouch.EvtType.On_Pinch, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.startPosition, this.twoFinger.position), 0f, Vector2.zero, 0f, currentDelta, this.twoFinger.fingerDistance);
					}
				}
				this.twoFinger.lastPinch = ((currentDelta <= 0f) ? this.twoFinger.lastPinch : currentDelta);
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00011254 File Offset: 0x0000F654
		private void DetecTwist(Vector2 previousDistance, Vector2 currentDistance, float currentDelta)
		{
			if (this.enableTwist)
			{
				float num = Vector2.Angle(previousDistance, currentDistance);
				if (previousDistance == currentDistance)
				{
					num = 0f;
				}
				if ((Mathf.Abs(num) >= this.minTwistAngle && this.twoFinger.currentGesture != EasyTouch.GestureType.Twist) || this.twoFinger.currentGesture == EasyTouch.GestureType.Twist)
				{
					if (this.twoFinger.oldGesture == EasyTouch.GestureType.LongTap)
					{
						this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, false, this.twoFinger.fingerDistance, 0f, 0f);
						this.twoFinger.startTimeAction = Time.realtimeSinceStartup;
					}
					this.twoFinger.currentGesture = EasyTouch.GestureType.Twist;
					if (num != 0f)
					{
						num *= Mathf.Sign(Vector3.Cross(previousDistance, currentDistance).z);
					}
					this.CreateGesture2Finger(EasyTouch.EvtType.On_Twist, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, num, 0f, this.twoFinger.fingerDistance);
				}
				this.twoFinger.lastTwistAngle = ((num == 0f) ? this.twoFinger.lastTwistAngle : num);
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x000113DC File Offset: 0x0000F7DC
		private void CreateStateEnd2Fingers(EasyTouch.GestureType gesture, Vector2 startPosition, Vector2 position, Vector2 deltaPosition, float time, bool realEnd, float fingerDistance, float twist = 0f, float pinch = 0f)
		{
			switch (gesture)
			{
			case EasyTouch.GestureType.LongTap:
				this.CreateGesture2Finger(EasyTouch.EvtType.On_LongTapEnd2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, fingerDistance);
				goto IL_1D2;
			case EasyTouch.GestureType.Pinch:
				this.CreateGesture2Finger(EasyTouch.EvtType.On_PinchEnd, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, this.twoFinger.lastPinch, fingerDistance);
				goto IL_1D2;
			case EasyTouch.GestureType.Twist:
				this.CreateGesture2Finger(EasyTouch.EvtType.On_TwistEnd, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, this.twoFinger.lastTwistAngle, 0f, fingerDistance);
				goto IL_1D2;
			default:
				if (gesture != EasyTouch.GestureType.Tap)
				{
					goto IL_1D2;
				}
				break;
			case EasyTouch.GestureType.Acquisition:
				break;
			}
			if (this.doubleTapDetection == EasyTouch.DoubleTapDetection.BySystem)
			{
				if (this.fingers[this.twoFinger.finger0].tapCount < 2 && this.fingers[this.twoFinger.finger1].tapCount < 2)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_SimpleTap2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, fingerDistance);
				}
				else
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_DoubleTap2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, fingerDistance);
				}
				this.twoFinger.currentGesture = EasyTouch.GestureType.None;
				this.twoFinger.pickedObject = null;
				this.twoFinger.swipeStart = false;
				this.twoFinger.dragStart = false;
				this.singleDoubleTap[99].Stop();
				base.StopCoroutine("SingleOrDouble2Fingers");
			}
			else if (!this.singleDoubleTap[99].inWait)
			{
				base.StartCoroutine("SingleOrDouble2Fingers");
			}
			else
			{
				this.singleDoubleTap[99].count++;
			}
			IL_1D2:
			if (realEnd)
			{
				if (this.twoFinger.dragStart)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_DragEnd2Fingers, startPosition, position, deltaPosition, time, this.GetSwipe(startPosition, position), (position - startPosition).magnitude, position - startPosition, 0f, 0f, fingerDistance);
				}
				if (this.twoFinger.swipeStart)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_SwipeEnd2Fingers, startPosition, position, deltaPosition, time, this.GetSwipe(startPosition, position), (position - startPosition).magnitude, position - startPosition, 0f, 0f, fingerDistance);
				}
				this.CreateGesture2Finger(EasyTouch.EvtType.On_TouchUp2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, fingerDistance);
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00011678 File Offset: 0x0000FA78
		private IEnumerator SingleOrDouble2Fingers()
		{
			this.singleDoubleTap[99].inWait = true;
			yield return new WaitForSeconds(this.doubleTapTime);
			if (this.singleDoubleTap[99].count < 2)
			{
				this.CreateGesture2Finger(EasyTouch.EvtType.On_SimpleTap2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
			}
			else
			{
				this.CreateGesture2Finger(EasyTouch.EvtType.On_DoubleTap2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
			}
			this.twoFinger.currentGesture = EasyTouch.GestureType.None;
			this.twoFinger.pickedObject = null;
			this.twoFinger.swipeStart = false;
			this.twoFinger.dragStart = false;
			this.singleDoubleTap[99].Stop();
			base.StopCoroutine("SingleOrDouble2Fingers");
			yield break;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00011694 File Offset: 0x0000FA94
		private void CreateGesture2Finger(EasyTouch.EvtType message, Vector2 startPosition, Vector2 position, Vector2 deltaPosition, float actionTime, EasyTouch.SwipeDirection swipe, float swipeLength, Vector2 swipeVector, float twist, float pinch, float twoDistance)
		{
			bool flag = true;
			Gesture gesture = new Gesture();
			gesture.isOverGui = false;
			if (this.enabledNGuiMode && message == EasyTouch.EvtType.On_TouchStart2Fingers)
			{
				gesture.isOverGui = (gesture.isOverGui || (this.IsTouchOverNGui(this.twoFinger.position, false) && this.IsTouchOverNGui(this.twoFinger.position, false)));
			}
			gesture.touchCount = 2;
			gesture.fingerIndex = -1;
			gesture.startPosition = startPosition;
			gesture.position = position;
			gesture.deltaPosition = deltaPosition;
			gesture.actionTime = actionTime;
			gesture.deltaTime = Time.deltaTime;
			gesture.swipe = swipe;
			gesture.swipeLength = swipeLength;
			gesture.swipeVector = swipeVector;
			gesture.deltaPinch = pinch;
			gesture.twistAngle = twist;
			gesture.twoFingerDistance = twoDistance;
			gesture.pickedObject = this.twoFinger.pickedObject;
			gesture.pickedCamera = this.twoFinger.pickedCamera;
			gesture.isGuiCamera = this.twoFinger.isGuiCamera;
			if (this.autoUpdatePickedObject && message != EasyTouch.EvtType.On_Drag && message != EasyTouch.EvtType.On_DragEnd && message != EasyTouch.EvtType.On_Twist && message != EasyTouch.EvtType.On_TwistEnd && message != EasyTouch.EvtType.On_Pinch && message != EasyTouch.EvtType.On_PinchEnd && message != EasyTouch.EvtType.On_PinchIn && message != EasyTouch.EvtType.On_PinchOut)
			{
				if (this.GetTwoFingerPickedObject())
				{
					gesture.pickedObject = this.pickedObject.pickedObj;
					gesture.pickedCamera = this.pickedObject.pickedCamera;
					gesture.isGuiCamera = this.pickedObject.isGUI;
				}
				else
				{
					this.twoFinger.ClearPickedObjectData();
				}
			}
			gesture.pickedUIElement = this.twoFinger.pickedUIElement;
			gesture.isOverGui = this.twoFinger.isOverGui;
			if (this.allowUIDetection && this.autoUpdatePickedUI && message != EasyTouch.EvtType.On_Drag && message != EasyTouch.EvtType.On_DragEnd && message != EasyTouch.EvtType.On_Twist && message != EasyTouch.EvtType.On_TwistEnd && message != EasyTouch.EvtType.On_Pinch && message != EasyTouch.EvtType.On_PinchEnd && message != EasyTouch.EvtType.On_PinchIn && message != EasyTouch.EvtType.On_PinchOut && message == EasyTouch.EvtType.On_SimpleTap2Fingers)
			{
				if (this.GetTwoFingerPickedUIElement())
				{
					gesture.pickedUIElement = this.pickedObject.pickedObj;
					gesture.isOverGui = true;
				}
				else
				{
					this.twoFinger.ClearPickedUIData();
				}
			}
			if (this.enableUIMode || (this.enabledNGuiMode && this.allowUIDetection))
			{
				flag = !gesture.isOverGui;
			}
			if (flag)
			{
				this.RaiseEvent(message, gesture);
			}
			else if (gesture.isOverGui)
			{
				if (message == EasyTouch.EvtType.On_TouchUp2Fingers)
				{
					this.RaiseEvent(EasyTouch.EvtType.On_UIElementTouchUp, gesture);
				}
				else
				{
					this.RaiseEvent(EasyTouch.EvtType.On_OverUIElement, gesture);
				}
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00011954 File Offset: 0x0000FD54
		private int GetTwoFinger(int index)
		{
			int num = index + 1;
			bool flag = false;
			while (num < 10 && !flag)
			{
				if (this.fingers[num] != null && num >= index)
				{
					flag = true;
				}
				num++;
			}
			return num - 1;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0001199C File Offset: 0x0000FD9C
		private bool GetTwoFingerPickedObject()
		{
			bool result = false;
			if (this.twoFingerPickMethod == EasyTouch.TwoFingerPickMethod.Finger)
			{
				if (this.GetPickedGameObject(this.fingers[this.twoFinger.finger0], false))
				{
					GameObject pickedObj = this.pickedObject.pickedObj;
					if (this.GetPickedGameObject(this.fingers[this.twoFinger.finger1], false) && pickedObj == this.pickedObject.pickedObj)
					{
						result = true;
					}
				}
			}
			else if (this.GetPickedGameObject(this.fingers[this.twoFinger.finger0], true))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00011A3C File Offset: 0x0000FE3C
		private bool GetTwoFingerPickedUIElement()
		{
			bool result = false;
			if (this.fingers[this.twoFinger.finger0] == null)
			{
				return false;
			}
			if (this.twoFingerPickMethod == EasyTouch.TwoFingerPickMethod.Finger)
			{
				if (this.IsScreenPositionOverUI(this.fingers[this.twoFinger.finger0].position))
				{
					GameObject firstUIElementFromCache = this.GetFirstUIElementFromCache();
					if (this.IsScreenPositionOverUI(this.fingers[this.twoFinger.finger1].position))
					{
						GameObject firstUIElementFromCache2 = this.GetFirstUIElementFromCache();
						if (firstUIElementFromCache2 == firstUIElementFromCache || firstUIElementFromCache2.transform.IsChildOf(firstUIElementFromCache.transform) || firstUIElementFromCache.transform.IsChildOf(firstUIElementFromCache2.transform))
						{
							this.pickedObject.pickedObj = firstUIElementFromCache;
							this.pickedObject.isGUI = true;
							result = true;
						}
					}
				}
			}
			else if (this.IsScreenPositionOverUI(this.twoFinger.position))
			{
				this.pickedObject.pickedObj = this.GetFirstUIElementFromCache();
				this.pickedObject.isGUI = true;
				result = true;
			}
			return result;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00011B50 File Offset: 0x0000FF50
		private void RaiseEvent(EasyTouch.EvtType evnt, Gesture gesture)
		{
			gesture.type = evnt;
			switch (evnt)
			{
			case EasyTouch.EvtType.On_TouchStart:
				if (EasyTouch.On_TouchStart != null)
				{
					EasyTouch.On_TouchStart(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchDown:
				if (EasyTouch.On_TouchDown != null)
				{
					EasyTouch.On_TouchDown(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchUp:
				if (EasyTouch.On_TouchUp != null)
				{
					EasyTouch.On_TouchUp(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SimpleTap:
				if (EasyTouch.On_SimpleTap != null)
				{
					EasyTouch.On_SimpleTap(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DoubleTap:
				if (EasyTouch.On_DoubleTap != null)
				{
					EasyTouch.On_DoubleTap(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTapStart:
				if (EasyTouch.On_LongTapStart != null)
				{
					EasyTouch.On_LongTapStart(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTap:
				if (EasyTouch.On_LongTap != null)
				{
					EasyTouch.On_LongTap(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTapEnd:
				if (EasyTouch.On_LongTapEnd != null)
				{
					EasyTouch.On_LongTapEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DragStart:
				if (EasyTouch.On_DragStart != null)
				{
					EasyTouch.On_DragStart(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Drag:
				if (EasyTouch.On_Drag != null)
				{
					EasyTouch.On_Drag(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DragEnd:
				if (EasyTouch.On_DragEnd != null)
				{
					EasyTouch.On_DragEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SwipeStart:
				if (EasyTouch.On_SwipeStart != null)
				{
					EasyTouch.On_SwipeStart(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Swipe:
				if (EasyTouch.On_Swipe != null)
				{
					EasyTouch.On_Swipe(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SwipeEnd:
				if (EasyTouch.On_SwipeEnd != null)
				{
					EasyTouch.On_SwipeEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchStart2Fingers:
				if (EasyTouch.On_TouchStart2Fingers != null)
				{
					EasyTouch.On_TouchStart2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchDown2Fingers:
				if (EasyTouch.On_TouchDown2Fingers != null)
				{
					EasyTouch.On_TouchDown2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchUp2Fingers:
				if (EasyTouch.On_TouchUp2Fingers != null)
				{
					EasyTouch.On_TouchUp2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SimpleTap2Fingers:
				if (EasyTouch.On_SimpleTap2Fingers != null)
				{
					EasyTouch.On_SimpleTap2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DoubleTap2Fingers:
				if (EasyTouch.On_DoubleTap2Fingers != null)
				{
					EasyTouch.On_DoubleTap2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTapStart2Fingers:
				if (EasyTouch.On_LongTapStart2Fingers != null)
				{
					EasyTouch.On_LongTapStart2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTap2Fingers:
				if (EasyTouch.On_LongTap2Fingers != null)
				{
					EasyTouch.On_LongTap2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTapEnd2Fingers:
				if (EasyTouch.On_LongTapEnd2Fingers != null)
				{
					EasyTouch.On_LongTapEnd2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Twist:
				if (EasyTouch.On_Twist != null)
				{
					EasyTouch.On_Twist(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TwistEnd:
				if (EasyTouch.On_TwistEnd != null)
				{
					EasyTouch.On_TwistEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Pinch:
				if (EasyTouch.On_Pinch != null)
				{
					EasyTouch.On_Pinch(gesture);
				}
				break;
			case EasyTouch.EvtType.On_PinchIn:
				if (EasyTouch.On_PinchIn != null)
				{
					EasyTouch.On_PinchIn(gesture);
				}
				break;
			case EasyTouch.EvtType.On_PinchOut:
				if (EasyTouch.On_PinchOut != null)
				{
					EasyTouch.On_PinchOut(gesture);
				}
				break;
			case EasyTouch.EvtType.On_PinchEnd:
				if (EasyTouch.On_PinchEnd != null)
				{
					EasyTouch.On_PinchEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DragStart2Fingers:
				if (EasyTouch.On_DragStart2Fingers != null)
				{
					EasyTouch.On_DragStart2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Drag2Fingers:
				if (EasyTouch.On_Drag2Fingers != null)
				{
					EasyTouch.On_Drag2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DragEnd2Fingers:
				if (EasyTouch.On_DragEnd2Fingers != null)
				{
					EasyTouch.On_DragEnd2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SwipeStart2Fingers:
				if (EasyTouch.On_SwipeStart2Fingers != null)
				{
					EasyTouch.On_SwipeStart2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Swipe2Fingers:
				if (EasyTouch.On_Swipe2Fingers != null)
				{
					EasyTouch.On_Swipe2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SwipeEnd2Fingers:
				if (EasyTouch.On_SwipeEnd2Fingers != null)
				{
					EasyTouch.On_SwipeEnd2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Cancel:
				if (EasyTouch.On_Cancel != null)
				{
					EasyTouch.On_Cancel(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Cancel2Fingers:
				if (EasyTouch.On_Cancel2Fingers != null)
				{
					EasyTouch.On_Cancel2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_OverUIElement:
				if (EasyTouch.On_OverUIElement != null)
				{
					EasyTouch.On_OverUIElement(gesture);
				}
				break;
			case EasyTouch.EvtType.On_UIElementTouchUp:
				if (EasyTouch.On_UIElementTouchUp != null)
				{
					EasyTouch.On_UIElementTouchUp(gesture);
				}
				break;
			}
			int num = this._currentGestures.FindIndex((Gesture obj) => obj != null && obj.type == gesture.type && obj.fingerIndex == gesture.fingerIndex);
			if (num > -1)
			{
				this._currentGestures[num].touchCount = gesture.touchCount;
				this._currentGestures[num].position = gesture.position;
				this._currentGestures[num].actionTime = gesture.actionTime;
				this._currentGestures[num].pickedCamera = gesture.pickedCamera;
				this._currentGestures[num].pickedObject = gesture.pickedObject;
				this._currentGestures[num].pickedUIElement = gesture.pickedUIElement;
				this._currentGestures[num].isOverGui = gesture.isOverGui;
				this._currentGestures[num].isGuiCamera = gesture.isGuiCamera;
				this._currentGestures[num].deltaPinch += gesture.deltaPinch;
				this._currentGestures[num].deltaPosition += gesture.deltaPosition;
				this._currentGestures[num].deltaTime += gesture.deltaTime;
				this._currentGestures[num].twistAngle += gesture.twistAngle;
			}
			if (num == -1)
			{
				this._currentGestures.Add((Gesture)gesture.Clone());
				if (this._currentGestures.Count > 0)
				{
					this._currentGesture = this._currentGestures[0];
				}
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00012290 File Offset: 0x00010690
		private bool GetPickedGameObject(Finger finger, bool isTowFinger = false)
		{
			if (finger == null && !isTowFinger)
			{
				return false;
			}
			this.pickedObject.isGUI = false;
			this.pickedObject.pickedObj = null;
			this.pickedObject.pickedCamera = null;
			if (this.touchCameras.Count > 0)
			{
				for (int i = 0; i < this.touchCameras.Count; i++)
				{
					if (this.touchCameras[i].camera != null && this.touchCameras[i].camera.enabled)
					{
						Vector2 position = Vector2.zero;
						if (!isTowFinger)
						{
							position = finger.position;
						}
						else
						{
							position = this.twoFinger.position;
						}
						if (this.GetGameObjectAt(position, this.touchCameras[i].camera, this.touchCameras[i].guiCamera))
						{
							return true;
						}
					}
				}
			}
			else
			{
				Debug.LogWarning("No camera is assigned to EasyTouch");
			}
			return false;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00012398 File Offset: 0x00010798
		private bool GetGameObjectAt(Vector2 position, Camera cam, bool isGuiCam)
		{
			Ray ray = cam.ScreenPointToRay(position);
			if (this.enable2D)
			{
				LayerMask mask = this.pickableLayers2D;
				RaycastHit2D[] array = new RaycastHit2D[1];
				if (Physics2D.GetRayIntersectionNonAlloc(ray, array, float.PositiveInfinity, mask) > 0)
				{
					this.pickedObject.pickedCamera = cam;
					this.pickedObject.isGUI = isGuiCam;
					this.pickedObject.pickedObj = array[0].collider.gameObject;
					return true;
				}
			}
			LayerMask mask2 = this.pickableLayers3D;
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit, 3.40282347E+38f, mask2))
			{
				this.pickedObject.pickedCamera = cam;
				this.pickedObject.isGUI = isGuiCam;
				this.pickedObject.pickedObj = raycastHit.collider.gameObject;
				return true;
			}
			return false;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0001246C File Offset: 0x0001086C
		private EasyTouch.SwipeDirection GetSwipe(Vector2 start, Vector2 end)
		{
			Vector2 normalized = (end - start).normalized;
			if (Vector2.Dot(normalized, Vector2.up) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.Up;
			}
			if (Vector2.Dot(normalized, -Vector2.up) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.Down;
			}
			if (Vector2.Dot(normalized, Vector2.right) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.Right;
			}
			if (Vector2.Dot(normalized, -Vector2.right) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.Left;
			}
			Vector2 lhs = normalized;
			Vector2 vector = new Vector2(0.5f, 0.5f);
			if (Vector2.Dot(lhs, vector.normalized) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.UpRight;
			}
			Vector2 lhs2 = normalized;
			Vector2 vector2 = new Vector2(0.5f, -0.5f);
			if (Vector2.Dot(lhs2, vector2.normalized) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.DownRight;
			}
			Vector2 lhs3 = normalized;
			Vector2 vector3 = new Vector2(-0.5f, 0.5f);
			if (Vector2.Dot(lhs3, vector3.normalized) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.UpLeft;
			}
			Vector2 lhs4 = normalized;
			Vector2 vector4 = new Vector2(-0.5f, -0.5f);
			if (Vector2.Dot(lhs4, vector4.normalized) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.DownLeft;
			}
			return EasyTouch.SwipeDirection.Other;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x000125A4 File Offset: 0x000109A4
		private bool FingerInTolerance(Finger finger)
		{
			return (finger.position - finger.startPosition).sqrMagnitude <= this.StationaryTolerance * this.StationaryTolerance;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x000125E0 File Offset: 0x000109E0
		private bool IsTouchOverNGui(Vector2 position, bool isTwoFingers = false)
		{
			bool flag = false;
			if (this.enabledNGuiMode)
			{
				LayerMask mask = this.nGUILayers;
				int num = 0;
				while (!flag && num < this.nGUICameras.Count)
				{
					Vector2 v = Vector2.zero;
					if (!isTwoFingers)
					{
						v = position;
					}
					else
					{
						v = this.twoFinger.position;
					}
					Ray ray = this.nGUICameras[num].ScreenPointToRay(v);
					RaycastHit raycastHit;
					flag = Physics.Raycast(ray, out raycastHit, float.MaxValue, mask);
					num++;
				}
			}
			return flag;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00012678 File Offset: 0x00010A78
		private Finger GetFinger(int finderId)
		{
			int num = 0;
			Finger finger = null;
			while (num < 10 && finger == null)
			{
				if (this.fingers[num] != null && this.fingers[num].fingerIndex == finderId)
				{
					finger = this.fingers[num];
				}
				num++;
			}
			return finger;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x000126CC File Offset: 0x00010ACC
		private bool IsScreenPositionOverUI(Vector2 position)
		{
			this.uiEventSystem = EventSystem.current;
			if (this.uiEventSystem != null)
			{
				this.uiPointerEventData = new PointerEventData(this.uiEventSystem);
				this.uiPointerEventData.position = position;
				this.uiEventSystem.RaycastAll(this.uiPointerEventData, this.uiRaycastResultCache);
				return this.uiRaycastResultCache.Count > 0;
			}
			return false;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00012740 File Offset: 0x00010B40
		private GameObject GetFirstUIElementFromCache()
		{
			if (this.uiRaycastResultCache.Count > 0)
			{
				return this.uiRaycastResultCache[0].gameObject;
			}
			return null;
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00012774 File Offset: 0x00010B74
		private GameObject GetFirstUIElement(Vector2 position)
		{
			if (this.IsScreenPositionOverUI(position))
			{
				return this.GetFirstUIElementFromCache();
			}
			return null;
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0001278C File Offset: 0x00010B8C
		public static bool IsFingerOverUIElement(int fingerIndex)
		{
			if (EasyTouch.instance != null)
			{
				Finger finger = EasyTouch.instance.GetFinger(fingerIndex);
				return finger != null && EasyTouch.instance.IsScreenPositionOverUI(finger.position);
			}
			return false;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x000127D0 File Offset: 0x00010BD0
		public static GameObject GetCurrentPickedUIElement(int fingerIndex, bool isTwoFinger)
		{
			if (!(EasyTouch.instance != null))
			{
				return null;
			}
			Finger finger = EasyTouch.instance.GetFinger(fingerIndex);
			if (finger != null || isTwoFinger)
			{
				Vector2 position = Vector2.zero;
				if (!isTwoFinger)
				{
					position = finger.position;
				}
				else
				{
					position = EasyTouch.instance.twoFinger.position;
				}
				return EasyTouch.instance.GetFirstUIElement(position);
			}
			return null;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0001283C File Offset: 0x00010C3C
		public static GameObject GetCurrentPickedObject(int fingerIndex, bool isTwoFinger)
		{
			if (!(EasyTouch.instance != null))
			{
				return null;
			}
			Finger finger = EasyTouch.instance.GetFinger(fingerIndex);
			if ((finger != null || isTwoFinger) && EasyTouch.instance.GetPickedGameObject(finger, isTwoFinger))
			{
				return EasyTouch.instance.pickedObject.pickedObj;
			}
			return null;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x00012898 File Offset: 0x00010C98
		public static GameObject GetGameObjectAt(Vector2 position, bool isTwoFinger = false)
		{
			if (EasyTouch.instance != null)
			{
				if (isTwoFinger)
				{
					position = EasyTouch.instance.twoFinger.position;
				}
				if (EasyTouch.instance.touchCameras.Count > 0)
				{
					int i = 0;
					while (i < EasyTouch.instance.touchCameras.Count)
					{
						if (EasyTouch.instance.touchCameras[i].camera != null && EasyTouch.instance.touchCameras[i].camera.enabled)
						{
							if (EasyTouch.instance.GetGameObjectAt(position, EasyTouch.instance.touchCameras[i].camera, EasyTouch.instance.touchCameras[i].guiCamera))
							{
								return EasyTouch.instance.pickedObject.pickedObj;
							}
							return null;
						}
						else
						{
							i++;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0001298D File Offset: 0x00010D8D
		public static int GetTouchCount()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.input.TouchCount();
			}
			return 0;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x000129AF File Offset: 0x00010DAF
		public static void ResetTouch(int fingerIndex)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.GetFinger(fingerIndex).gesture = EasyTouch.GestureType.None;
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000129D1 File Offset: 0x00010DD1
		public static void SetEnabled(bool enable)
		{
			EasyTouch.instance.enable = enable;
			if (enable)
			{
				EasyTouch.instance.ResetTouches();
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000129EE File Offset: 0x00010DEE
		public static bool GetEnabled()
		{
			return EasyTouch.instance && EasyTouch.instance.enable;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00012A0B File Offset: 0x00010E0B
		public static void SetEnableUIDetection(bool enable)
		{
			if (EasyTouch.instance != null)
			{
				EasyTouch.instance.allowUIDetection = enable;
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00012A28 File Offset: 0x00010E28
		public static bool GetEnableUIDetection()
		{
			return EasyTouch.instance && EasyTouch.instance.allowUIDetection;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00012A45 File Offset: 0x00010E45
		public static void SetUICompatibily(bool value)
		{
			if (EasyTouch.instance != null)
			{
				EasyTouch.instance.enableUIMode = value;
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00012A62 File Offset: 0x00010E62
		public static bool GetUIComptability()
		{
			return EasyTouch.instance != null && EasyTouch.instance.enableUIMode;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00012A80 File Offset: 0x00010E80
		public static void SetAutoUpdateUI(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.autoUpdatePickedUI = value;
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00012A9C File Offset: 0x00010E9C
		public static bool GetAutoUpdateUI()
		{
			return EasyTouch.instance && EasyTouch.instance.autoUpdatePickedUI;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00012AB9 File Offset: 0x00010EB9
		public static void SetNGUICompatibility(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enabledNGuiMode = value;
			}
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00012AD5 File Offset: 0x00010ED5
		public static bool GetNGUICompatibility()
		{
			return EasyTouch.instance && EasyTouch.instance.enabledNGuiMode;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00012AF2 File Offset: 0x00010EF2
		public static void SetEnableAutoSelect(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.autoSelect = value;
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00012B0E File Offset: 0x00010F0E
		public static bool GetEnableAutoSelect()
		{
			return EasyTouch.instance && EasyTouch.instance.autoSelect;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00012B2B File Offset: 0x00010F2B
		public static void SetAutoUpdatePickedObject(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.autoUpdatePickedObject = value;
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00012B47 File Offset: 0x00010F47
		public static bool GetAutoUpdatePickedObject()
		{
			return EasyTouch.instance && EasyTouch.instance.autoUpdatePickedObject;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00012B64 File Offset: 0x00010F64
		public static void Set3DPickableLayer(LayerMask mask)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.pickableLayers3D = mask;
			}
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00012B80 File Offset: 0x00010F80
		public static LayerMask Get3DPickableLayer()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.pickableLayers3D;
			}
			return LayerMask.GetMask(new string[]
			{
				"Default"
			});
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00012BB4 File Offset: 0x00010FB4
		public static void AddCamera(Camera cam, bool guiCam = false)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.touchCameras.Add(new ECamera(cam, guiCam));
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00012BDC File Offset: 0x00010FDC
		public static void RemoveCamera(Camera cam)
		{
			if (EasyTouch.instance)
			{
				int num = EasyTouch.instance.touchCameras.FindIndex((ECamera c) => c.camera == cam);
				if (num > -1)
				{
					EasyTouch.instance.touchCameras[num] = null;
					EasyTouch.instance.touchCameras.RemoveAt(num);
				}
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00012C49 File Offset: 0x00011049
		public static Camera GetCamera(int index = 0)
		{
			if (!EasyTouch.instance)
			{
				return null;
			}
			if (index < EasyTouch.instance.touchCameras.Count)
			{
				return EasyTouch.instance.touchCameras[index].camera;
			}
			return null;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00012C88 File Offset: 0x00011088
		public static void SetEnable2DCollider(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enable2D = value;
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00012CA4 File Offset: 0x000110A4
		public static bool GetEnable2DCollider()
		{
			return EasyTouch.instance && EasyTouch.instance.enable2D;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00012CC1 File Offset: 0x000110C1
		public static void Set2DPickableLayer(LayerMask mask)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.pickableLayers2D = mask;
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00012CDD File Offset: 0x000110DD
		public static LayerMask Get2DPickableLayer()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.pickableLayers2D;
			}
			return LayerMask.GetMask(new string[]
			{
				"Default"
			});
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00012D11 File Offset: 0x00011111
		public static void SetGesturePriority(EasyTouch.GesturePriority value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.gesturePriority = value;
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00012D2D File Offset: 0x0001112D
		public static EasyTouch.GesturePriority GetGesturePriority()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.gesturePriority;
			}
			return EasyTouch.GesturePriority.Tap;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00012D4A File Offset: 0x0001114A
		public static void SetStationaryTolerance(float tolerance)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.StationaryTolerance = tolerance;
			}
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00012D66 File Offset: 0x00011166
		public static float GetStationaryTolerance()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.StationaryTolerance;
			}
			return -1f;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00012D87 File Offset: 0x00011187
		public static void SetLongTapTime(float time)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.longTapTime = time;
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00012DA3 File Offset: 0x000111A3
		public static float GetlongTapTime()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.longTapTime;
			}
			return -1f;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00012DC4 File Offset: 0x000111C4
		public static void SetDoubleTapTime(float time)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.doubleTapTime = time;
			}
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00012DE0 File Offset: 0x000111E0
		public static float GetDoubleTapTime()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.doubleTapTime;
			}
			return -1f;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00012E01 File Offset: 0x00011201
		public static void SetDoubleTapMethod(EasyTouch.DoubleTapDetection detection)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.doubleTapDetection = detection;
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00012E1D File Offset: 0x0001121D
		public static EasyTouch.DoubleTapDetection GetDoubleTapMethod()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.doubleTapDetection;
			}
			return EasyTouch.DoubleTapDetection.BySystem;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00012E3A File Offset: 0x0001123A
		public static void SetSwipeTolerance(float tolerance)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.swipeTolerance = tolerance;
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00012E56 File Offset: 0x00011256
		public static float GetSwipeTolerance()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.swipeTolerance;
			}
			return -1f;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00012E77 File Offset: 0x00011277
		public static void SetEnable2FingersGesture(bool enable)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enable2FingersGesture = enable;
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00012E93 File Offset: 0x00011293
		public static bool GetEnable2FingersGesture()
		{
			return EasyTouch.instance && EasyTouch.instance.enable2FingersGesture;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00012EB0 File Offset: 0x000112B0
		public static void SetTwoFingerPickMethod(EasyTouch.TwoFingerPickMethod pickMethod)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.twoFingerPickMethod = pickMethod;
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00012ECC File Offset: 0x000112CC
		public static EasyTouch.TwoFingerPickMethod GetTwoFingerPickMethod()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.twoFingerPickMethod;
			}
			return EasyTouch.TwoFingerPickMethod.Finger;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00012EE9 File Offset: 0x000112E9
		public static void SetEnablePinch(bool enable)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enablePinch = enable;
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00012F05 File Offset: 0x00011305
		public static bool GetEnablePinch()
		{
			return EasyTouch.instance && EasyTouch.instance.enablePinch;
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00012F22 File Offset: 0x00011322
		public static void SetMinPinchLength(float length)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.minPinchLength = length;
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00012F3E File Offset: 0x0001133E
		public static float GetMinPinchLength()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.minPinchLength;
			}
			return -1f;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00012F5F File Offset: 0x0001135F
		public static void SetEnableTwist(bool enable)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enableTwist = enable;
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00012F7B File Offset: 0x0001137B
		public static bool GetEnableTwist()
		{
			return EasyTouch.instance && EasyTouch.instance.enableTwist;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00012F98 File Offset: 0x00011398
		public static void SetMinTwistAngle(float angle)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.minTwistAngle = angle;
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00012FB4 File Offset: 0x000113B4
		public static float GetMinTwistAngle()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.minTwistAngle;
			}
			return -1f;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00012FD5 File Offset: 0x000113D5
		public static bool GetSecondeFingerSimulation()
		{
			return EasyTouch.instance != null && EasyTouch.instance.enableSimulation;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00012FF3 File Offset: 0x000113F3
		public static void SetSecondFingerSimulation(bool value)
		{
			if (EasyTouch.instance != null)
			{
				EasyTouch.instance.enableSimulation = value;
			}
		}

		// Token: 0x040001B6 RID: 438
		private static EasyTouch _instance;

		// Token: 0x040001B7 RID: 439
		private Gesture _currentGesture = new Gesture();

		// Token: 0x040001B8 RID: 440
		private List<Gesture> _currentGestures = new List<Gesture>();

		// Token: 0x040001B9 RID: 441
		public bool enable;

		// Token: 0x040001BA RID: 442
		public bool enableRemote;

		// Token: 0x040001BB RID: 443
		public EasyTouch.GesturePriority gesturePriority;

		// Token: 0x040001BC RID: 444
		public float StationaryTolerance;

		// Token: 0x040001BD RID: 445
		public float longTapTime;

		// Token: 0x040001BE RID: 446
		public float swipeTolerance;

		// Token: 0x040001BF RID: 447
		public float minPinchLength;

		// Token: 0x040001C0 RID: 448
		public float minTwistAngle;

		// Token: 0x040001C1 RID: 449
		public EasyTouch.DoubleTapDetection doubleTapDetection;

		// Token: 0x040001C2 RID: 450
		public float doubleTapTime;

		// Token: 0x040001C3 RID: 451
		public bool alwaysSendSwipe;

		// Token: 0x040001C4 RID: 452
		public bool enable2FingersGesture;

		// Token: 0x040001C5 RID: 453
		public bool enableTwist;

		// Token: 0x040001C6 RID: 454
		public bool enablePinch;

		// Token: 0x040001C7 RID: 455
		public bool enable2FingersSwipe;

		// Token: 0x040001C8 RID: 456
		public EasyTouch.TwoFingerPickMethod twoFingerPickMethod;

		// Token: 0x040001C9 RID: 457
		public List<ECamera> touchCameras;

		// Token: 0x040001CA RID: 458
		public bool autoSelect;

		// Token: 0x040001CB RID: 459
		public LayerMask pickableLayers3D;

		// Token: 0x040001CC RID: 460
		public bool enable2D;

		// Token: 0x040001CD RID: 461
		public LayerMask pickableLayers2D;

		// Token: 0x040001CE RID: 462
		public bool autoUpdatePickedObject;

		// Token: 0x040001CF RID: 463
		public bool allowUIDetection;

		// Token: 0x040001D0 RID: 464
		public bool enableUIMode;

		// Token: 0x040001D1 RID: 465
		public bool autoUpdatePickedUI;

		// Token: 0x040001D2 RID: 466
		public bool enabledNGuiMode;

		// Token: 0x040001D3 RID: 467
		public LayerMask nGUILayers;

		// Token: 0x040001D4 RID: 468
		public List<Camera> nGUICameras;

		// Token: 0x040001D5 RID: 469
		public bool enableSimulation;

		// Token: 0x040001D6 RID: 470
		public KeyCode twistKey;

		// Token: 0x040001D7 RID: 471
		public KeyCode swipeKey;

		// Token: 0x040001D8 RID: 472
		public bool showGuiInspector;

		// Token: 0x040001D9 RID: 473
		public bool showSelectInspector;

		// Token: 0x040001DA RID: 474
		public bool showGestureInspector;

		// Token: 0x040001DB RID: 475
		public bool showTwoFingerInspector;

		// Token: 0x040001DC RID: 476
		public bool showSecondFingerInspector;

		// Token: 0x040001DD RID: 477
		private EasyTouchInput input = new EasyTouchInput();

		// Token: 0x040001DE RID: 478
		private Finger[] fingers = new Finger[100];

		// Token: 0x040001DF RID: 479
		public Texture secondFingerTexture;

		// Token: 0x040001E0 RID: 480
		private TwoFingerGesture twoFinger = new TwoFingerGesture();

		// Token: 0x040001E1 RID: 481
		private int oldTouchCount;

		// Token: 0x040001E2 RID: 482
		private EasyTouch.DoubleTap[] singleDoubleTap = new EasyTouch.DoubleTap[100];

		// Token: 0x040001E3 RID: 483
		private Finger[] tmpArray = new Finger[100];

		// Token: 0x040001E4 RID: 484
		private EasyTouch.PickedObject pickedObject = new EasyTouch.PickedObject();

		// Token: 0x040001E5 RID: 485
		private List<RaycastResult> uiRaycastResultCache = new List<RaycastResult>();

		// Token: 0x040001E6 RID: 486
		private PointerEventData uiPointerEventData;

		// Token: 0x040001E7 RID: 487
		private EventSystem uiEventSystem;

		// Token: 0x02000071 RID: 113
		[Serializable]
		private class DoubleTap
		{
			// Token: 0x0600038E RID: 910 RVA: 0x0001302A File Offset: 0x0001142A
			public void Stop()
			{
				this.inDoubleTap = false;
				this.inWait = false;
				this.time = 0f;
				this.count = 0;
			}

			// Token: 0x040001E9 RID: 489
			public bool inDoubleTap;

			// Token: 0x040001EA RID: 490
			public bool inWait;

			// Token: 0x040001EB RID: 491
			public float time;

			// Token: 0x040001EC RID: 492
			public int count;

			// Token: 0x040001ED RID: 493
			public Finger finger;
		}

		// Token: 0x02000072 RID: 114
		private class PickedObject
		{
			// Token: 0x040001EE RID: 494
			public GameObject pickedObj;

			// Token: 0x040001EF RID: 495
			public Camera pickedCamera;

			// Token: 0x040001F0 RID: 496
			public bool isGUI;
		}

		// Token: 0x02000073 RID: 115
		// (Invoke) Token: 0x06000391 RID: 913
		public delegate void TouchCancelHandler(Gesture gesture);

		// Token: 0x02000074 RID: 116
		// (Invoke) Token: 0x06000395 RID: 917
		public delegate void Cancel2FingersHandler(Gesture gesture);

		// Token: 0x02000075 RID: 117
		// (Invoke) Token: 0x06000399 RID: 921
		public delegate void TouchStartHandler(Gesture gesture);

		// Token: 0x02000076 RID: 118
		// (Invoke) Token: 0x0600039D RID: 925
		public delegate void TouchDownHandler(Gesture gesture);

		// Token: 0x02000077 RID: 119
		// (Invoke) Token: 0x060003A1 RID: 929
		public delegate void TouchUpHandler(Gesture gesture);

		// Token: 0x02000078 RID: 120
		// (Invoke) Token: 0x060003A5 RID: 933
		public delegate void SimpleTapHandler(Gesture gesture);

		// Token: 0x02000079 RID: 121
		// (Invoke) Token: 0x060003A9 RID: 937
		public delegate void DoubleTapHandler(Gesture gesture);

		// Token: 0x0200007A RID: 122
		// (Invoke) Token: 0x060003AD RID: 941
		public delegate void LongTapStartHandler(Gesture gesture);

		// Token: 0x0200007B RID: 123
		// (Invoke) Token: 0x060003B1 RID: 945
		public delegate void LongTapHandler(Gesture gesture);

		// Token: 0x0200007C RID: 124
		// (Invoke) Token: 0x060003B5 RID: 949
		public delegate void LongTapEndHandler(Gesture gesture);

		// Token: 0x0200007D RID: 125
		// (Invoke) Token: 0x060003B9 RID: 953
		public delegate void DragStartHandler(Gesture gesture);

		// Token: 0x0200007E RID: 126
		// (Invoke) Token: 0x060003BD RID: 957
		public delegate void DragHandler(Gesture gesture);

		// Token: 0x0200007F RID: 127
		// (Invoke) Token: 0x060003C1 RID: 961
		public delegate void DragEndHandler(Gesture gesture);

		// Token: 0x02000080 RID: 128
		// (Invoke) Token: 0x060003C5 RID: 965
		public delegate void SwipeStartHandler(Gesture gesture);

		// Token: 0x02000081 RID: 129
		// (Invoke) Token: 0x060003C9 RID: 969
		public delegate void SwipeHandler(Gesture gesture);

		// Token: 0x02000082 RID: 130
		// (Invoke) Token: 0x060003CD RID: 973
		public delegate void SwipeEndHandler(Gesture gesture);

		// Token: 0x02000083 RID: 131
		// (Invoke) Token: 0x060003D1 RID: 977
		public delegate void TouchStart2FingersHandler(Gesture gesture);

		// Token: 0x02000084 RID: 132
		// (Invoke) Token: 0x060003D5 RID: 981
		public delegate void TouchDown2FingersHandler(Gesture gesture);

		// Token: 0x02000085 RID: 133
		// (Invoke) Token: 0x060003D9 RID: 985
		public delegate void TouchUp2FingersHandler(Gesture gesture);

		// Token: 0x02000086 RID: 134
		// (Invoke) Token: 0x060003DD RID: 989
		public delegate void SimpleTap2FingersHandler(Gesture gesture);

		// Token: 0x02000087 RID: 135
		// (Invoke) Token: 0x060003E1 RID: 993
		public delegate void DoubleTap2FingersHandler(Gesture gesture);

		// Token: 0x02000088 RID: 136
		// (Invoke) Token: 0x060003E5 RID: 997
		public delegate void LongTapStart2FingersHandler(Gesture gesture);

		// Token: 0x02000089 RID: 137
		// (Invoke) Token: 0x060003E9 RID: 1001
		public delegate void LongTap2FingersHandler(Gesture gesture);

		// Token: 0x0200008A RID: 138
		// (Invoke) Token: 0x060003ED RID: 1005
		public delegate void LongTapEnd2FingersHandler(Gesture gesture);

		// Token: 0x0200008B RID: 139
		// (Invoke) Token: 0x060003F1 RID: 1009
		public delegate void TwistHandler(Gesture gesture);

		// Token: 0x0200008C RID: 140
		// (Invoke) Token: 0x060003F5 RID: 1013
		public delegate void TwistEndHandler(Gesture gesture);

		// Token: 0x0200008D RID: 141
		// (Invoke) Token: 0x060003F9 RID: 1017
		public delegate void PinchInHandler(Gesture gesture);

		// Token: 0x0200008E RID: 142
		// (Invoke) Token: 0x060003FD RID: 1021
		public delegate void PinchOutHandler(Gesture gesture);

		// Token: 0x0200008F RID: 143
		// (Invoke) Token: 0x06000401 RID: 1025
		public delegate void PinchEndHandler(Gesture gesture);

		// Token: 0x02000090 RID: 144
		// (Invoke) Token: 0x06000405 RID: 1029
		public delegate void PinchHandler(Gesture gesture);

		// Token: 0x02000091 RID: 145
		// (Invoke) Token: 0x06000409 RID: 1033
		public delegate void DragStart2FingersHandler(Gesture gesture);

		// Token: 0x02000092 RID: 146
		// (Invoke) Token: 0x0600040D RID: 1037
		public delegate void Drag2FingersHandler(Gesture gesture);

		// Token: 0x02000093 RID: 147
		// (Invoke) Token: 0x06000411 RID: 1041
		public delegate void DragEnd2FingersHandler(Gesture gesture);

		// Token: 0x02000094 RID: 148
		// (Invoke) Token: 0x06000415 RID: 1045
		public delegate void SwipeStart2FingersHandler(Gesture gesture);

		// Token: 0x02000095 RID: 149
		// (Invoke) Token: 0x06000419 RID: 1049
		public delegate void Swipe2FingersHandler(Gesture gesture);

		// Token: 0x02000096 RID: 150
		// (Invoke) Token: 0x0600041D RID: 1053
		public delegate void SwipeEnd2FingersHandler(Gesture gesture);

		// Token: 0x02000097 RID: 151
		// (Invoke) Token: 0x06000421 RID: 1057
		public delegate void EasyTouchIsReadyHandler();

		// Token: 0x02000098 RID: 152
		// (Invoke) Token: 0x06000425 RID: 1061
		public delegate void OverUIElementHandler(Gesture gesture);

		// Token: 0x02000099 RID: 153
		// (Invoke) Token: 0x06000429 RID: 1065
		public delegate void UIElementTouchUpHandler(Gesture gesture);

		// Token: 0x0200009A RID: 154
		public enum GesturePriority
		{
			// Token: 0x040001F2 RID: 498
			Tap,
			// Token: 0x040001F3 RID: 499
			Slips
		}

		// Token: 0x0200009B RID: 155
		public enum DoubleTapDetection
		{
			// Token: 0x040001F5 RID: 501
			BySystem,
			// Token: 0x040001F6 RID: 502
			ByTime
		}

		// Token: 0x0200009C RID: 156
		public enum GestureType
		{
			// Token: 0x040001F8 RID: 504
			Tap,
			// Token: 0x040001F9 RID: 505
			Drag,
			// Token: 0x040001FA RID: 506
			Swipe,
			// Token: 0x040001FB RID: 507
			None,
			// Token: 0x040001FC RID: 508
			LongTap,
			// Token: 0x040001FD RID: 509
			Pinch,
			// Token: 0x040001FE RID: 510
			Twist,
			// Token: 0x040001FF RID: 511
			Cancel,
			// Token: 0x04000200 RID: 512
			Acquisition
		}

		// Token: 0x0200009D RID: 157
		public enum SwipeDirection
		{
			// Token: 0x04000202 RID: 514
			None,
			// Token: 0x04000203 RID: 515
			Left,
			// Token: 0x04000204 RID: 516
			Right,
			// Token: 0x04000205 RID: 517
			Up,
			// Token: 0x04000206 RID: 518
			Down,
			// Token: 0x04000207 RID: 519
			UpLeft,
			// Token: 0x04000208 RID: 520
			UpRight,
			// Token: 0x04000209 RID: 521
			DownLeft,
			// Token: 0x0400020A RID: 522
			DownRight,
			// Token: 0x0400020B RID: 523
			Other,
			// Token: 0x0400020C RID: 524
			All
		}

		// Token: 0x0200009E RID: 158
		public enum TwoFingerPickMethod
		{
			// Token: 0x0400020E RID: 526
			Finger,
			// Token: 0x0400020F RID: 527
			Average
		}

		// Token: 0x0200009F RID: 159
		public enum EvtType
		{
			// Token: 0x04000211 RID: 529
			None,
			// Token: 0x04000212 RID: 530
			On_TouchStart,
			// Token: 0x04000213 RID: 531
			On_TouchDown,
			// Token: 0x04000214 RID: 532
			On_TouchUp,
			// Token: 0x04000215 RID: 533
			On_SimpleTap,
			// Token: 0x04000216 RID: 534
			On_DoubleTap,
			// Token: 0x04000217 RID: 535
			On_LongTapStart,
			// Token: 0x04000218 RID: 536
			On_LongTap,
			// Token: 0x04000219 RID: 537
			On_LongTapEnd,
			// Token: 0x0400021A RID: 538
			On_DragStart,
			// Token: 0x0400021B RID: 539
			On_Drag,
			// Token: 0x0400021C RID: 540
			On_DragEnd,
			// Token: 0x0400021D RID: 541
			On_SwipeStart,
			// Token: 0x0400021E RID: 542
			On_Swipe,
			// Token: 0x0400021F RID: 543
			On_SwipeEnd,
			// Token: 0x04000220 RID: 544
			On_TouchStart2Fingers,
			// Token: 0x04000221 RID: 545
			On_TouchDown2Fingers,
			// Token: 0x04000222 RID: 546
			On_TouchUp2Fingers,
			// Token: 0x04000223 RID: 547
			On_SimpleTap2Fingers,
			// Token: 0x04000224 RID: 548
			On_DoubleTap2Fingers,
			// Token: 0x04000225 RID: 549
			On_LongTapStart2Fingers,
			// Token: 0x04000226 RID: 550
			On_LongTap2Fingers,
			// Token: 0x04000227 RID: 551
			On_LongTapEnd2Fingers,
			// Token: 0x04000228 RID: 552
			On_Twist,
			// Token: 0x04000229 RID: 553
			On_TwistEnd,
			// Token: 0x0400022A RID: 554
			On_Pinch,
			// Token: 0x0400022B RID: 555
			On_PinchIn,
			// Token: 0x0400022C RID: 556
			On_PinchOut,
			// Token: 0x0400022D RID: 557
			On_PinchEnd,
			// Token: 0x0400022E RID: 558
			On_DragStart2Fingers,
			// Token: 0x0400022F RID: 559
			On_Drag2Fingers,
			// Token: 0x04000230 RID: 560
			On_DragEnd2Fingers,
			// Token: 0x04000231 RID: 561
			On_SwipeStart2Fingers,
			// Token: 0x04000232 RID: 562
			On_Swipe2Fingers,
			// Token: 0x04000233 RID: 563
			On_SwipeEnd2Fingers,
			// Token: 0x04000234 RID: 564
			On_EasyTouchIsReady,
			// Token: 0x04000235 RID: 565
			On_Cancel,
			// Token: 0x04000236 RID: 566
			On_Cancel2Fingers,
			// Token: 0x04000237 RID: 567
			On_OverUIElement,
			// Token: 0x04000238 RID: 568
			On_UIElementTouchUp
		}
	}
}
