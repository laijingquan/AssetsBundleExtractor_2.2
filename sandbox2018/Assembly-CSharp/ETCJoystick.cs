using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000D7 RID: 215
[Serializable]
public class ETCJoystick : ETCBase, IPointerEnterHandler, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x0600054C RID: 1356 RVA: 0x00019CE4 File Offset: 0x000180E4
	public ETCJoystick()
	{
		this.joystickType = ETCJoystick.JoystickType.Static;
		this.allowJoystickOverTouchPad = false;
		this.radiusBase = ETCJoystick.RadiusBase.Width;
		this.axisX = new ETCAxis("Horizontal");
		this.axisY = new ETCAxis("Vertical");
		this._visible = true;
		this._activated = true;
		this.joystickArea = ETCJoystick.JoystickArea.FullScreen;
		this.isDynamicActif = false;
		this.isOnDrag = false;
		this.isOnTouch = false;
		this.axisX.unityAxis = "Horizontal";
		this.axisY.unityAxis = "Vertical";
		this.enableKeySimulation = true;
		this.isNoReturnThumb = false;
		this.showPSInspector = false;
		this.showAxesInspector = false;
		this.showEventInspector = false;
		this.showSpriteInspector = false;
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x0600054D RID: 1357 RVA: 0x00019DAB File Offset: 0x000181AB
	// (set) Token: 0x0600054E RID: 1358 RVA: 0x00019DB3 File Offset: 0x000181B3
	public bool IsNoReturnThumb
	{
		get
		{
			return this.isNoReturnThumb;
		}
		set
		{
			this.isNoReturnThumb = value;
		}
	}

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x0600054F RID: 1359 RVA: 0x00019DBC File Offset: 0x000181BC
	// (set) Token: 0x06000550 RID: 1360 RVA: 0x00019DC4 File Offset: 0x000181C4
	public bool IsNoOffsetThumb
	{
		get
		{
			return this.isNoOffsetThumb;
		}
		set
		{
			this.isNoOffsetThumb = value;
		}
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x00019DD0 File Offset: 0x000181D0
	protected override void Awake()
	{
		base.Awake();
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic)
		{
			this.rectTransform().anchorMin = new Vector2(0.5f, 0.5f);
			this.rectTransform().anchorMax = new Vector2(0.5f, 0.5f);
			this.rectTransform().SetAsLastSibling();
			base.visible = false;
		}
		if (this.allowSimulationStandalone && this.enableKeySimulation && !Application.isEditor && this.joystickType != ETCJoystick.JoystickType.Dynamic)
		{
			this.SetVisible(this.visibleOnStandalone);
		}
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x00019E6C File Offset: 0x0001826C
	public override void Start()
	{
		this.axisX.InitAxis();
		this.axisY.InitAxis();
		if (this.enableCamera)
		{
			this.InitCameraLookAt();
		}
		this.tmpAxis = Vector2.zero;
		this.OldTmpAxis = Vector2.zero;
		this.noReturnPosition = this.thumb.position;
		this.pointId = -1;
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic)
		{
			base.visible = false;
		}
		base.Start();
		if (this.enableCamera && this.cameraMode == ETCBase.CameraMode.SmoothFollow && this.cameraTransform && this.cameraLookAt)
		{
			this.cameraTransform.position = this.cameraLookAt.TransformPoint(new Vector3(0f, this.followHeight, -this.followDistance));
			this.cameraTransform.LookAt(this.cameraLookAt);
		}
		if (this.enableCamera && this.cameraMode == ETCBase.CameraMode.Follow && this.cameraTransform && this.cameraLookAt)
		{
			this.cameraTransform.position = this.cameraLookAt.position + this.followOffset;
			this.cameraTransform.LookAt(this.cameraLookAt.position);
		}
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x00019FD0 File Offset: 0x000183D0
	public override void Update()
	{
		base.Update();
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic && !this._visible && this._activated)
		{
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			if (this.isTouchOverJoystickArea(ref zero, ref zero2))
			{
				GameObject firstUIElement = base.GetFirstUIElement(zero2);
				if (firstUIElement == null || (this.allowJoystickOverTouchPad && firstUIElement.GetComponent<ETCTouchPad>()) || (firstUIElement != null && firstUIElement.GetComponent<ETCArea>()))
				{
					this.cachedRectTransform.anchoredPosition = zero;
					base.visible = true;
				}
			}
		}
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic && this._visible && this.GetTouchCount() == 0)
		{
			base.visible = false;
		}
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0001A0A5 File Offset: 0x000184A5
	public override void LateUpdate()
	{
		if (this.enableCamera && !this.cameraLookAt)
		{
			this.InitCameraLookAt();
		}
		base.LateUpdate();
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0001A0D0 File Offset: 0x000184D0
	private void InitCameraLookAt()
	{
		if (this.cameraTargetMode == ETCBase.CameraTargetMode.FromDirectActionAxisX)
		{
			this.cameraLookAt = this.axisX.directTransform;
		}
		else if (this.cameraTargetMode == ETCBase.CameraTargetMode.FromDirectActionAxisY)
		{
			this.cameraLookAt = this.axisY.directTransform;
			if (this.isTurnAndMove)
			{
				this.cameraLookAt = this.axisX.directTransform;
			}
		}
		else if (this.cameraTargetMode == ETCBase.CameraTargetMode.LinkOnTag)
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag(this.camTargetTag);
			if (gameObject)
			{
				this.cameraLookAt = gameObject.transform;
			}
		}
		if (this.cameraLookAt)
		{
			this.cameraLookAtCC = this.cameraLookAt.GetComponent<CharacterController>();
		}
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x0001A18D File Offset: 0x0001858D
	protected override void UpdateControlState()
	{
		if (this._visible)
		{
			this.UpdateJoystick();
		}
		else if (this.joystickType == ETCJoystick.JoystickType.Dynamic)
		{
			this.OnUp(false);
		}
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x0001A1B8 File Offset: 0x000185B8
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic && !this.isDynamicActif && this._activated && this.pointId == -1)
		{
			eventData.pointerDrag = base.gameObject;
			eventData.pointerPress = base.gameObject;
			this.isDynamicActif = true;
			this.pointId = eventData.pointerId;
		}
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic && !eventData.eligibleForClick)
		{
			this.OnPointerUp(eventData);
		}
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x0001A23A File Offset: 0x0001863A
	public void OnPointerDown(PointerEventData eventData)
	{
		this.onTouchStart.Invoke();
		this.pointId = eventData.pointerId;
		if (this.isNoOffsetThumb)
		{
			this.OnDrag(eventData);
		}
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x0001A265 File Offset: 0x00018665
	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x0001A268 File Offset: 0x00018668
	public void OnDrag(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.isOnDrag = true;
			this.isOnTouch = true;
			float radius = this.GetRadius();
			if (!this.isNoReturnThumb)
			{
				this.thumbPosition = eventData.position - eventData.pressPosition;
			}
			else
			{
				this.thumbPosition = (eventData.position - this.noReturnPosition) / this.cachedRootCanvas.rectTransform().localScale.x + this.noReturnOffset;
			}
			if (this.isNoOffsetThumb)
			{
				this.thumbPosition = (eventData.position - this.cachedRectTransform.position) / this.cachedRootCanvas.rectTransform().localScale.x;
			}
			this.thumbPosition.x = (float)Mathf.FloorToInt(this.thumbPosition.x);
			this.thumbPosition.y = (float)Mathf.FloorToInt(this.thumbPosition.y);
			if (!this.axisX.enable)
			{
				this.thumbPosition.x = 0f;
			}
			if (!this.axisY.enable)
			{
				this.thumbPosition.y = 0f;
			}
			if (this.thumbPosition.magnitude > radius)
			{
				if (!this.isNoReturnThumb)
				{
					this.thumbPosition = this.thumbPosition.normalized * radius;
				}
				else
				{
					this.thumbPosition = this.thumbPosition.normalized * radius;
				}
			}
			this.thumb.anchoredPosition = this.thumbPosition;
		}
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x0001A422 File Offset: 0x00018822
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.OnUp(true);
		}
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x0001A43C File Offset: 0x0001883C
	private void OnUp(bool real = true)
	{
		this.isOnDrag = false;
		this.isOnTouch = false;
		if (this.isNoReturnThumb)
		{
			this.noReturnPosition = this.thumb.position;
			this.noReturnOffset = this.thumbPosition;
		}
		if (!this.isNoReturnThumb)
		{
			this.thumbPosition = Vector2.zero;
			this.thumb.anchoredPosition = Vector2.zero;
			this.axisX.axisState = ETCAxis.AxisState.None;
			this.axisY.axisState = ETCAxis.AxisState.None;
		}
		if (!this.axisX.isEnertia && !this.axisY.isEnertia)
		{
			this.axisX.ResetAxis();
			this.axisY.ResetAxis();
			this.tmpAxis = Vector2.zero;
			this.OldTmpAxis = Vector2.zero;
			if (real)
			{
				this.onMoveEnd.Invoke();
			}
		}
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic)
		{
			base.visible = false;
			this.isDynamicActif = false;
		}
		this.pointId = -1;
		if (real)
		{
			this.onTouchUp.Invoke();
		}
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x0001A550 File Offset: 0x00018950
	protected override void DoActionBeforeEndOfFrame()
	{
		this.axisX.DoGravity();
		this.axisY.DoGravity();
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x0001A568 File Offset: 0x00018968
	private void UpdateJoystick()
	{
		if (this.enableKeySimulation && !this.isOnTouch && this._activated && this._visible)
		{
			float axis = Input.GetAxis(this.axisX.unityAxis);
			float axis2 = Input.GetAxis(this.axisY.unityAxis);
			if (!this.isNoReturnThumb)
			{
				this.thumb.localPosition = Vector2.zero;
			}
			this.isOnDrag = false;
			if (axis != 0f)
			{
				this.isOnDrag = true;
				this.thumb.localPosition = new Vector2(this.GetRadius() * axis, this.thumb.localPosition.y);
			}
			if (axis2 != 0f)
			{
				this.isOnDrag = true;
				this.thumb.localPosition = new Vector2(this.thumb.localPosition.x, this.GetRadius() * axis2);
			}
			this.thumbPosition = this.thumb.localPosition;
		}
		this.OldTmpAxis.x = this.axisX.axisValue;
		this.OldTmpAxis.y = this.axisY.axisValue;
		this.tmpAxis = this.thumbPosition / this.GetRadius();
		this.axisX.UpdateAxis(this.tmpAxis.x, this.isOnDrag, ETCBase.ControlType.Joystick, true);
		this.axisY.UpdateAxis(this.tmpAxis.y, this.isOnDrag, ETCBase.ControlType.Joystick, true);
		if ((this.axisX.axisValue != 0f || this.axisY.axisValue != 0f) && this.OldTmpAxis == Vector2.zero)
		{
			this.onMoveStart.Invoke();
		}
		if (this.axisX.axisValue != 0f || this.axisY.axisValue != 0f)
		{
			if (!this.isTurnAndMove)
			{
				if (this.axisX.actionOn == ETCAxis.ActionOn.Down && (this.axisX.axisState == ETCAxis.AxisState.DownLeft || this.axisX.axisState == ETCAxis.AxisState.DownRight))
				{
					this.axisX.DoDirectAction();
				}
				else if (this.axisX.actionOn == ETCAxis.ActionOn.Press)
				{
					this.axisX.DoDirectAction();
				}
				if (this.axisY.actionOn == ETCAxis.ActionOn.Down && (this.axisY.axisState == ETCAxis.AxisState.DownUp || this.axisY.axisState == ETCAxis.AxisState.DownDown))
				{
					this.axisY.DoDirectAction();
				}
				else if (this.axisY.actionOn == ETCAxis.ActionOn.Press)
				{
					this.axisY.DoDirectAction();
				}
			}
			else
			{
				this.DoTurnAndMove();
			}
			this.onMove.Invoke(new Vector2(this.axisX.axisValue, this.axisY.axisValue));
			this.onMoveSpeed.Invoke(new Vector2(this.axisX.axisSpeedValue, this.axisY.axisSpeedValue));
		}
		else if (this.axisX.axisValue == 0f && this.axisY.axisValue == 0f && this.OldTmpAxis != Vector2.zero)
		{
			this.onMoveEnd.Invoke();
		}
		if (!this.isTurnAndMove)
		{
			if (this.axisX.axisValue == 0f && this.axisX.directCharacterController && !this.axisX.directCharacterController.isGrounded && this.axisX.isLockinJump)
			{
				this.axisX.DoDirectAction();
			}
			if (this.axisY.axisValue == 0f && this.axisY.directCharacterController && !this.axisY.directCharacterController.isGrounded && this.axisY.isLockinJump)
			{
				this.axisY.DoDirectAction();
			}
		}
		else if (this.axisX.axisValue == 0f && this.axisY.axisValue == 0f && this.axisX.directCharacterController && !this.axisX.directCharacterController.isGrounded && this.tmLockInJump)
		{
			this.DoTurnAndMove();
		}
		float num = 1f;
		if (this.axisX.invertedAxis)
		{
			num = -1f;
		}
		if (Mathf.Abs(this.OldTmpAxis.x) < this.axisX.axisThreshold && Mathf.Abs(this.axisX.axisValue) >= this.axisX.axisThreshold)
		{
			if (this.axisX.axisValue * num > 0f)
			{
				this.axisX.axisState = ETCAxis.AxisState.DownRight;
				this.OnDownRight.Invoke();
			}
			else if (this.axisX.axisValue * num < 0f)
			{
				this.axisX.axisState = ETCAxis.AxisState.DownLeft;
				this.OnDownLeft.Invoke();
			}
			else
			{
				this.axisX.axisState = ETCAxis.AxisState.None;
			}
		}
		else if (this.axisX.axisState != ETCAxis.AxisState.None)
		{
			if (this.axisX.axisValue * num > 0f)
			{
				this.axisX.axisState = ETCAxis.AxisState.PressRight;
				this.OnPressRight.Invoke();
			}
			else if (this.axisX.axisValue * num < 0f)
			{
				this.axisX.axisState = ETCAxis.AxisState.PressLeft;
				this.OnPressLeft.Invoke();
			}
			else
			{
				this.axisX.axisState = ETCAxis.AxisState.None;
			}
		}
		num = 1f;
		if (this.axisY.invertedAxis)
		{
			num = -1f;
		}
		if (Mathf.Abs(this.OldTmpAxis.y) < this.axisY.axisThreshold && Mathf.Abs(this.axisY.axisValue) >= this.axisY.axisThreshold)
		{
			if (this.axisY.axisValue * num > 0f)
			{
				this.axisY.axisState = ETCAxis.AxisState.DownUp;
				this.OnDownUp.Invoke();
			}
			else if (this.axisY.axisValue * num < 0f)
			{
				this.axisY.axisState = ETCAxis.AxisState.DownDown;
				this.OnDownDown.Invoke();
			}
			else
			{
				this.axisY.axisState = ETCAxis.AxisState.None;
			}
		}
		else if (this.axisY.axisState != ETCAxis.AxisState.None)
		{
			if (this.axisY.axisValue * num > 0f)
			{
				this.axisY.axisState = ETCAxis.AxisState.PressUp;
				this.OnPressUp.Invoke();
			}
			else if (this.axisY.axisValue * num < 0f)
			{
				this.axisY.axisState = ETCAxis.AxisState.PressDown;
				this.OnPressDown.Invoke();
			}
			else
			{
				this.axisY.axisState = ETCAxis.AxisState.None;
			}
		}
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x0001ACC8 File Offset: 0x000190C8
	private bool isTouchOverJoystickArea(ref Vector2 localPosition, ref Vector2 screenPosition)
	{
		bool flag = false;
		bool flag2 = false;
		screenPosition = Vector2.zero;
		int touchCount = this.GetTouchCount();
		int num = 0;
		while (num < touchCount && !flag)
		{
			if (Input.GetTouch(num).phase == TouchPhase.Began)
			{
				screenPosition = Input.GetTouch(num).position;
				flag2 = true;
			}
			if (flag2 && this.isScreenPointOverArea(screenPosition, ref localPosition))
			{
				flag = true;
			}
			num++;
		}
		return flag;
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x0001AD4C File Offset: 0x0001914C
	private bool isScreenPointOverArea(Vector2 screenPosition, ref Vector2 localPosition)
	{
		bool result = false;
		if (this.joystickArea != ETCJoystick.JoystickArea.UserDefined)
		{
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedRootCanvas.rectTransform(), screenPosition, null, out localPosition))
			{
				switch (this.joystickArea)
				{
				case ETCJoystick.JoystickArea.FullScreen:
					result = true;
					break;
				case ETCJoystick.JoystickArea.Left:
					if (localPosition.x < 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.Right:
					if (localPosition.x > 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.Top:
					if (localPosition.y > 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.Bottom:
					if (localPosition.y < 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.TopLeft:
					if (localPosition.y > 0f && localPosition.x < 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.TopRight:
					if (localPosition.y > 0f && localPosition.x > 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.BottomLeft:
					if (localPosition.y < 0f && localPosition.x < 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.BottomRight:
					if (localPosition.y < 0f && localPosition.x > 0f)
					{
						result = true;
					}
					break;
				}
			}
		}
		else if (RectTransformUtility.RectangleContainsScreenPoint(this.userArea, screenPosition, this.cachedRootCanvas.worldCamera))
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedRootCanvas.rectTransform(), screenPosition, this.cachedRootCanvas.worldCamera, out localPosition);
			result = true;
		}
		return result;
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0001AEF7 File Offset: 0x000192F7
	private int GetTouchCount()
	{
		return Input.touchCount;
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x0001AF00 File Offset: 0x00019300
	public float GetRadius()
	{
		float result = 0f;
		ETCJoystick.RadiusBase radiusBase = this.radiusBase;
		if (radiusBase != ETCJoystick.RadiusBase.Width)
		{
			if (radiusBase != ETCJoystick.RadiusBase.Height)
			{
				if (radiusBase == ETCJoystick.RadiusBase.UserDefined)
				{
					result = this.radiusBaseValue;
				}
			}
			else
			{
				result = this.cachedRectTransform.sizeDelta.y * 0.5f;
			}
		}
		else
		{
			result = this.cachedRectTransform.sizeDelta.x * 0.5f;
		}
		return result;
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x0001AF7E File Offset: 0x0001937E
	protected override void SetActivated()
	{
		base.GetComponent<CanvasGroup>().blocksRaycasts = this._activated;
		if (!this._activated)
		{
			this.OnUp(false);
		}
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x0001AFA4 File Offset: 0x000193A4
	protected override void SetVisible(bool visible = true)
	{
		bool enabled = this._visible;
		if (!visible)
		{
			enabled = visible;
		}
		base.GetComponent<Image>().enabled = enabled;
		this.thumb.GetComponent<Image>().enabled = enabled;
		base.GetComponent<CanvasGroup>().blocksRaycasts = this._activated;
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x0001AFF0 File Offset: 0x000193F0
	private void DoTurnAndMove()
	{
		float num = Mathf.Atan2(this.axisX.axisValue, this.axisY.axisValue) * 57.29578f;
		AnimationCurve animationCurve = this.tmMoveCurve;
		Vector2 vector = new Vector2(this.axisX.axisValue, this.axisY.axisValue);
		float d = animationCurve.Evaluate(vector.magnitude) * this.tmSpeed;
		if (this.axisX.directTransform != null)
		{
			this.axisX.directTransform.rotation = Quaternion.Euler(new Vector3(0f, num + this.tmAdditionnalRotation, 0f));
			if (this.axisX.directCharacterController != null)
			{
				if (this.axisX.directCharacterController.isGrounded || !this.tmLockInJump)
				{
					Vector3 a = this.axisX.directCharacterController.transform.TransformDirection(Vector3.forward) * d;
					this.axisX.directCharacterController.Move(a * Time.deltaTime);
					this.tmLastMove = a;
				}
				else
				{
					this.axisX.directCharacterController.Move(this.tmLastMove * Time.deltaTime);
				}
			}
			else
			{
				this.axisX.directTransform.Translate(Vector3.forward * d * Time.deltaTime, Space.Self);
			}
		}
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0001B163 File Offset: 0x00019563
	public void InitCurve()
	{
		this.axisX.InitDeadCurve();
		this.axisY.InitDeadCurve();
		this.InitTurnMoveCurve();
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x0001B181 File Offset: 0x00019581
	public void InitTurnMoveCurve()
	{
		this.tmMoveCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
		this.tmMoveCurve.postWrapMode = WrapMode.PingPong;
		this.tmMoveCurve.preWrapMode = WrapMode.PingPong;
	}

	// Token: 0x04000370 RID: 880
	[SerializeField]
	public ETCJoystick.OnMoveStartHandler onMoveStart;

	// Token: 0x04000371 RID: 881
	[SerializeField]
	public ETCJoystick.OnMoveHandler onMove;

	// Token: 0x04000372 RID: 882
	[SerializeField]
	public ETCJoystick.OnMoveSpeedHandler onMoveSpeed;

	// Token: 0x04000373 RID: 883
	[SerializeField]
	public ETCJoystick.OnMoveEndHandler onMoveEnd;

	// Token: 0x04000374 RID: 884
	[SerializeField]
	public ETCJoystick.OnTouchStartHandler onTouchStart;

	// Token: 0x04000375 RID: 885
	[SerializeField]
	public ETCJoystick.OnTouchUpHandler onTouchUp;

	// Token: 0x04000376 RID: 886
	[SerializeField]
	public ETCJoystick.OnDownUpHandler OnDownUp;

	// Token: 0x04000377 RID: 887
	[SerializeField]
	public ETCJoystick.OnDownDownHandler OnDownDown;

	// Token: 0x04000378 RID: 888
	[SerializeField]
	public ETCJoystick.OnDownLeftHandler OnDownLeft;

	// Token: 0x04000379 RID: 889
	[SerializeField]
	public ETCJoystick.OnDownRightHandler OnDownRight;

	// Token: 0x0400037A RID: 890
	[SerializeField]
	public ETCJoystick.OnDownUpHandler OnPressUp;

	// Token: 0x0400037B RID: 891
	[SerializeField]
	public ETCJoystick.OnDownDownHandler OnPressDown;

	// Token: 0x0400037C RID: 892
	[SerializeField]
	public ETCJoystick.OnDownLeftHandler OnPressLeft;

	// Token: 0x0400037D RID: 893
	[SerializeField]
	public ETCJoystick.OnDownRightHandler OnPressRight;

	// Token: 0x0400037E RID: 894
	public ETCJoystick.JoystickType joystickType;

	// Token: 0x0400037F RID: 895
	public bool allowJoystickOverTouchPad;

	// Token: 0x04000380 RID: 896
	public ETCJoystick.RadiusBase radiusBase;

	// Token: 0x04000381 RID: 897
	public float radiusBaseValue;

	// Token: 0x04000382 RID: 898
	public ETCAxis axisX;

	// Token: 0x04000383 RID: 899
	public ETCAxis axisY;

	// Token: 0x04000384 RID: 900
	public RectTransform thumb;

	// Token: 0x04000385 RID: 901
	public ETCJoystick.JoystickArea joystickArea;

	// Token: 0x04000386 RID: 902
	public RectTransform userArea;

	// Token: 0x04000387 RID: 903
	public bool isTurnAndMove;

	// Token: 0x04000388 RID: 904
	public float tmSpeed = 10f;

	// Token: 0x04000389 RID: 905
	public float tmAdditionnalRotation;

	// Token: 0x0400038A RID: 906
	public AnimationCurve tmMoveCurve;

	// Token: 0x0400038B RID: 907
	public bool tmLockInJump;

	// Token: 0x0400038C RID: 908
	private Vector3 tmLastMove;

	// Token: 0x0400038D RID: 909
	private Vector2 thumbPosition;

	// Token: 0x0400038E RID: 910
	private bool isDynamicActif;

	// Token: 0x0400038F RID: 911
	private Vector2 tmpAxis;

	// Token: 0x04000390 RID: 912
	private Vector2 OldTmpAxis;

	// Token: 0x04000391 RID: 913
	private bool isOnTouch;

	// Token: 0x04000392 RID: 914
	[SerializeField]
	private bool isNoReturnThumb;

	// Token: 0x04000393 RID: 915
	private Vector2 noReturnPosition;

	// Token: 0x04000394 RID: 916
	private Vector2 noReturnOffset;

	// Token: 0x04000395 RID: 917
	[SerializeField]
	private bool isNoOffsetThumb;

	// Token: 0x020000D8 RID: 216
	[Serializable]
	public class OnMoveStartHandler : UnityEvent
	{
	}

	// Token: 0x020000D9 RID: 217
	[Serializable]
	public class OnMoveSpeedHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x020000DA RID: 218
	[Serializable]
	public class OnMoveHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x020000DB RID: 219
	[Serializable]
	public class OnMoveEndHandler : UnityEvent
	{
	}

	// Token: 0x020000DC RID: 220
	[Serializable]
	public class OnTouchStartHandler : UnityEvent
	{
	}

	// Token: 0x020000DD RID: 221
	[Serializable]
	public class OnTouchUpHandler : UnityEvent
	{
	}

	// Token: 0x020000DE RID: 222
	[Serializable]
	public class OnDownUpHandler : UnityEvent
	{
	}

	// Token: 0x020000DF RID: 223
	[Serializable]
	public class OnDownDownHandler : UnityEvent
	{
	}

	// Token: 0x020000E0 RID: 224
	[Serializable]
	public class OnDownLeftHandler : UnityEvent
	{
	}

	// Token: 0x020000E1 RID: 225
	[Serializable]
	public class OnDownRightHandler : UnityEvent
	{
	}

	// Token: 0x020000E2 RID: 226
	[Serializable]
	public class OnPressUpHandler : UnityEvent
	{
	}

	// Token: 0x020000E3 RID: 227
	[Serializable]
	public class OnPressDownHandler : UnityEvent
	{
	}

	// Token: 0x020000E4 RID: 228
	[Serializable]
	public class OnPressLeftHandler : UnityEvent
	{
	}

	// Token: 0x020000E5 RID: 229
	[Serializable]
	public class OnPressRightHandler : UnityEvent
	{
	}

	// Token: 0x020000E6 RID: 230
	public enum JoystickArea
	{
		// Token: 0x04000397 RID: 919
		UserDefined,
		// Token: 0x04000398 RID: 920
		FullScreen,
		// Token: 0x04000399 RID: 921
		Left,
		// Token: 0x0400039A RID: 922
		Right,
		// Token: 0x0400039B RID: 923
		Top,
		// Token: 0x0400039C RID: 924
		Bottom,
		// Token: 0x0400039D RID: 925
		TopLeft,
		// Token: 0x0400039E RID: 926
		TopRight,
		// Token: 0x0400039F RID: 927
		BottomLeft,
		// Token: 0x040003A0 RID: 928
		BottomRight
	}

	// Token: 0x020000E7 RID: 231
	public enum JoystickType
	{
		// Token: 0x040003A2 RID: 930
		Dynamic,
		// Token: 0x040003A3 RID: 931
		Static
	}

	// Token: 0x020000E8 RID: 232
	public enum RadiusBase
	{
		// Token: 0x040003A5 RID: 933
		Width,
		// Token: 0x040003A6 RID: 934
		Height,
		// Token: 0x040003A7 RID: 935
		UserDefined
	}
}
