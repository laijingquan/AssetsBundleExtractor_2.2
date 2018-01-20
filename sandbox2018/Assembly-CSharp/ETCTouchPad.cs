using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000E9 RID: 233
[Serializable]
public class ETCTouchPad : ETCBase, IBeginDragHandler, IDragHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000576 RID: 1398 RVA: 0x0001B22C File Offset: 0x0001962C
	public ETCTouchPad()
	{
		this.axisX = new ETCAxis("Horizontal");
		this.axisX.speed = 1f;
		this.axisY = new ETCAxis("Vertical");
		this.axisY.speed = 1f;
		this._visible = true;
		this._activated = true;
		this.showPSInspector = true;
		this.showSpriteInspector = false;
		this.showBehaviourInspector = false;
		this.showEventInspector = false;
		this.tmpAxis = Vector2.zero;
		this.isOnDrag = false;
		this.isOnTouch = false;
		this.axisX.unityAxis = "Horizontal";
		this.axisY.unityAxis = "Vertical";
		this.enableKeySimulation = true;
		this.enableKeySimulation = false;
		this.isOut = false;
		this.axisX.axisState = ETCAxis.AxisState.None;
		this.useFixedUpdate = false;
		this.isDPI = false;
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x0001B311 File Offset: 0x00019711
	protected override void Awake()
	{
		base.Awake();
		this.cachedVisible = this._visible;
		this.cachedImage = base.GetComponent<Image>();
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x0001B334 File Offset: 0x00019734
	public override void OnEnable()
	{
		base.OnEnable();
		if (!this.cachedVisible)
		{
			this.cachedImage.color = new Color(0f, 0f, 0f, 0f);
		}
		if (this.allowSimulationStandalone && this.enableKeySimulation && !Application.isEditor)
		{
			this.SetVisible(this.visibleOnStandalone);
		}
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x0001B3A2 File Offset: 0x000197A2
	public override void Start()
	{
		base.Start();
		this.tmpAxis = Vector2.zero;
		this.OldTmpAxis = Vector2.zero;
		this.axisX.InitAxis();
		this.axisY.InitAxis();
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x0001B3D6 File Offset: 0x000197D6
	protected override void UpdateControlState()
	{
		this.UpdateTouchPad();
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x0001B3DE File Offset: 0x000197DE
	protected override void DoActionBeforeEndOfFrame()
	{
		this.axisX.DoGravity();
		this.axisY.DoGravity();
	}

	// Token: 0x0600057C RID: 1404 RVA: 0x0001B3F8 File Offset: 0x000197F8
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.isSwipeIn && this.axisX.axisState == ETCAxis.AxisState.None && this._activated && !this.isOnTouch)
		{
			if (eventData.pointerDrag != null && eventData.pointerDrag != base.gameObject)
			{
				this.previousDargObject = eventData.pointerDrag;
			}
			else if (eventData.pointerPress != null && eventData.pointerPress != base.gameObject)
			{
				this.previousDargObject = eventData.pointerPress;
			}
			eventData.pointerDrag = base.gameObject;
			eventData.pointerPress = base.gameObject;
			this.OnPointerDown(eventData);
		}
	}

	// Token: 0x0600057D RID: 1405 RVA: 0x0001B4C0 File Offset: 0x000198C0
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.onMoveStart.Invoke();
		}
	}

	// Token: 0x0600057E RID: 1406 RVA: 0x0001B4E0 File Offset: 0x000198E0
	public void OnDrag(PointerEventData eventData)
	{
		if (base.activated && !this.isOut && this.pointId == eventData.pointerId)
		{
			this.isOnTouch = true;
			this.isOnDrag = true;
			if (this.isDPI)
			{
				this.tmpAxis = new Vector2(eventData.delta.x / Screen.dpi * 100f, eventData.delta.y / Screen.dpi * 100f);
			}
			else
			{
				this.tmpAxis = new Vector2(eventData.delta.x, eventData.delta.y);
			}
			if (!this.axisX.enable)
			{
				this.tmpAxis.x = 0f;
			}
			if (!this.axisY.enable)
			{
				this.tmpAxis.y = 0f;
			}
		}
	}

	// Token: 0x0600057F RID: 1407 RVA: 0x0001B5D8 File Offset: 0x000199D8
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this._activated && !this.isOnTouch)
		{
			this.axisX.axisState = ETCAxis.AxisState.Down;
			this.tmpAxis = eventData.delta;
			this.isOut = false;
			this.isOnTouch = true;
			this.pointId = eventData.pointerId;
			this.onTouchStart.Invoke();
		}
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x0001B638 File Offset: 0x00019A38
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.isOnDrag = false;
			this.isOnTouch = false;
			this.tmpAxis = Vector2.zero;
			this.OldTmpAxis = Vector2.zero;
			this.axisX.axisState = ETCAxis.AxisState.None;
			this.axisY.axisState = ETCAxis.AxisState.None;
			if (!this.axisX.isEnertia && !this.axisY.isEnertia)
			{
				this.axisX.ResetAxis();
				this.axisY.ResetAxis();
				this.onMoveEnd.Invoke();
			}
			this.onTouchUp.Invoke();
			if (this.previousDargObject)
			{
				ExecuteEvents.Execute<IPointerUpHandler>(this.previousDargObject, eventData, ExecuteEvents.pointerUpHandler);
				this.previousDargObject = null;
			}
			this.pointId = -1;
		}
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x0001B70E File Offset: 0x00019B0E
	public void OnPointerExit(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId && !this.isSwipeOut)
		{
			this.isOut = true;
			this.OnPointerUp(eventData);
		}
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x0001B73C File Offset: 0x00019B3C
	private void UpdateTouchPad()
	{
		if (this.enableKeySimulation && !this.isOnTouch && this._activated && this._visible)
		{
			this.isOnDrag = false;
			this.tmpAxis = Vector2.zero;
			float axis = Input.GetAxis(this.axisX.unityAxis);
			float axis2 = Input.GetAxis(this.axisY.unityAxis);
			if (axis != 0f)
			{
				this.isOnDrag = true;
				this.tmpAxis = new Vector2(1f * Mathf.Sign(axis), this.tmpAxis.y);
			}
			if (axis2 != 0f)
			{
				this.isOnDrag = true;
				this.tmpAxis = new Vector2(this.tmpAxis.x, 1f * Mathf.Sign(axis2));
			}
		}
		this.OldTmpAxis.x = this.axisX.axisValue;
		this.OldTmpAxis.y = this.axisY.axisValue;
		this.axisX.UpdateAxis(this.tmpAxis.x, this.isOnDrag, ETCBase.ControlType.DPad, true);
		this.axisY.UpdateAxis(this.tmpAxis.y, this.isOnDrag, ETCBase.ControlType.DPad, true);
		if (this.axisX.axisValue != 0f || this.axisY.axisValue != 0f)
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
			this.onMove.Invoke(new Vector2(this.axisX.axisValue, this.axisY.axisValue));
			this.onMoveSpeed.Invoke(new Vector2(this.axisX.axisSpeedValue, this.axisY.axisSpeedValue));
		}
		else if (this.axisX.axisValue == 0f && this.axisY.axisValue == 0f && this.OldTmpAxis != Vector2.zero)
		{
			this.onMoveEnd.Invoke();
		}
		float num = 1f;
		if (this.axisX.invertedAxis)
		{
			num = -1f;
		}
		if (this.OldTmpAxis.x == 0f && Mathf.Abs(this.axisX.axisValue) > 0f)
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
		if (this.OldTmpAxis.y == 0f && Mathf.Abs(this.axisY.axisValue) > 0f)
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
		this.tmpAxis = Vector2.zero;
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x0001BC90 File Offset: 0x0001A090
	protected override void SetVisible(bool forceUnvisible = false)
	{
		if (Application.isPlaying)
		{
			if (!this._visible)
			{
				this.cachedImage.color = new Color(0f, 0f, 0f, 0f);
			}
			else
			{
				this.cachedImage.color = new Color(1f, 1f, 1f, 1f);
			}
		}
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x0001BD00 File Offset: 0x0001A100
	protected override void SetActivated()
	{
		if (!this._activated)
		{
			this.isOnDrag = false;
			this.isOnTouch = false;
			this.tmpAxis = Vector2.zero;
			this.OldTmpAxis = Vector2.zero;
			this.axisX.axisState = ETCAxis.AxisState.None;
			this.axisY.axisState = ETCAxis.AxisState.None;
			if (!this.axisX.isEnertia && !this.axisY.isEnertia)
			{
				this.axisX.ResetAxis();
				this.axisY.ResetAxis();
			}
			this.pointId = -1;
		}
	}

	// Token: 0x040003A8 RID: 936
	[SerializeField]
	public ETCTouchPad.OnMoveStartHandler onMoveStart;

	// Token: 0x040003A9 RID: 937
	[SerializeField]
	public ETCTouchPad.OnMoveHandler onMove;

	// Token: 0x040003AA RID: 938
	[SerializeField]
	public ETCTouchPad.OnMoveSpeedHandler onMoveSpeed;

	// Token: 0x040003AB RID: 939
	[SerializeField]
	public ETCTouchPad.OnMoveEndHandler onMoveEnd;

	// Token: 0x040003AC RID: 940
	[SerializeField]
	public ETCTouchPad.OnTouchStartHandler onTouchStart;

	// Token: 0x040003AD RID: 941
	[SerializeField]
	public ETCTouchPad.OnTouchUPHandler onTouchUp;

	// Token: 0x040003AE RID: 942
	[SerializeField]
	public ETCTouchPad.OnDownUpHandler OnDownUp;

	// Token: 0x040003AF RID: 943
	[SerializeField]
	public ETCTouchPad.OnDownDownHandler OnDownDown;

	// Token: 0x040003B0 RID: 944
	[SerializeField]
	public ETCTouchPad.OnDownLeftHandler OnDownLeft;

	// Token: 0x040003B1 RID: 945
	[SerializeField]
	public ETCTouchPad.OnDownRightHandler OnDownRight;

	// Token: 0x040003B2 RID: 946
	[SerializeField]
	public ETCTouchPad.OnDownUpHandler OnPressUp;

	// Token: 0x040003B3 RID: 947
	[SerializeField]
	public ETCTouchPad.OnDownDownHandler OnPressDown;

	// Token: 0x040003B4 RID: 948
	[SerializeField]
	public ETCTouchPad.OnDownLeftHandler OnPressLeft;

	// Token: 0x040003B5 RID: 949
	[SerializeField]
	public ETCTouchPad.OnDownRightHandler OnPressRight;

	// Token: 0x040003B6 RID: 950
	public ETCAxis axisX;

	// Token: 0x040003B7 RID: 951
	public ETCAxis axisY;

	// Token: 0x040003B8 RID: 952
	public bool isDPI;

	// Token: 0x040003B9 RID: 953
	private Image cachedImage;

	// Token: 0x040003BA RID: 954
	private Vector2 tmpAxis;

	// Token: 0x040003BB RID: 955
	private Vector2 OldTmpAxis;

	// Token: 0x040003BC RID: 956
	private GameObject previousDargObject;

	// Token: 0x040003BD RID: 957
	private bool isOut;

	// Token: 0x040003BE RID: 958
	private bool isOnTouch;

	// Token: 0x040003BF RID: 959
	private bool cachedVisible;

	// Token: 0x020000EA RID: 234
	[Serializable]
	public class OnMoveStartHandler : UnityEvent
	{
	}

	// Token: 0x020000EB RID: 235
	[Serializable]
	public class OnMoveHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x020000EC RID: 236
	[Serializable]
	public class OnMoveSpeedHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x020000ED RID: 237
	[Serializable]
	public class OnMoveEndHandler : UnityEvent
	{
	}

	// Token: 0x020000EE RID: 238
	[Serializable]
	public class OnTouchStartHandler : UnityEvent
	{
	}

	// Token: 0x020000EF RID: 239
	[Serializable]
	public class OnTouchUPHandler : UnityEvent
	{
	}

	// Token: 0x020000F0 RID: 240
	[Serializable]
	public class OnDownUpHandler : UnityEvent
	{
	}

	// Token: 0x020000F1 RID: 241
	[Serializable]
	public class OnDownDownHandler : UnityEvent
	{
	}

	// Token: 0x020000F2 RID: 242
	[Serializable]
	public class OnDownLeftHandler : UnityEvent
	{
	}

	// Token: 0x020000F3 RID: 243
	[Serializable]
	public class OnDownRightHandler : UnityEvent
	{
	}

	// Token: 0x020000F4 RID: 244
	[Serializable]
	public class OnPressUpHandler : UnityEvent
	{
	}

	// Token: 0x020000F5 RID: 245
	[Serializable]
	public class OnPressDownHandler : UnityEvent
	{
	}

	// Token: 0x020000F6 RID: 246
	[Serializable]
	public class OnPressLeftHandler : UnityEvent
	{
	}

	// Token: 0x020000F7 RID: 247
	[Serializable]
	public class OnPressRightHandler : UnityEvent
	{
	}
}
