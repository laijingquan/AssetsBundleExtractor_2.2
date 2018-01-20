using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000C7 RID: 199
public class ETCDPad : ETCBase, IDragHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x060004DD RID: 1245 RVA: 0x00017784 File Offset: 0x00015B84
	public ETCDPad()
	{
		this.axisX = new ETCAxis("Horizontal");
		this.axisY = new ETCAxis("Vertical");
		this._visible = true;
		this._activated = true;
		this.dPadAxisCount = ETCBase.DPadAxis.Two_Axis;
		this.tmpAxis = Vector2.zero;
		this.showPSInspector = true;
		this.showSpriteInspector = false;
		this.showBehaviourInspector = false;
		this.showEventInspector = false;
		this.isOnDrag = false;
		this.isOnTouch = false;
		this.axisX.unityAxis = "Horizontal";
		this.axisY.unityAxis = "Vertical";
		this.enableKeySimulation = true;
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x00017834 File Offset: 0x00015C34
	public override void Start()
	{
		base.Start();
		this.tmpAxis = Vector2.zero;
		this.OldTmpAxis = Vector2.zero;
		this.axisX.InitAxis();
		this.axisY.InitAxis();
		if (this.allowSimulationStandalone && this.enableKeySimulation && !Application.isEditor)
		{
			this.SetVisible(this.visibleOnStandalone);
		}
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x0001789F File Offset: 0x00015C9F
	protected override void UpdateControlState()
	{
		this.UpdateDPad();
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x000178A7 File Offset: 0x00015CA7
	protected override void DoActionBeforeEndOfFrame()
	{
		this.axisX.DoGravity();
		this.axisY.DoGravity();
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x000178C0 File Offset: 0x00015CC0
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this._activated && !this.isOnTouch)
		{
			this.onTouchStart.Invoke();
			this.GetTouchDirection(eventData.position, eventData.pressEventCamera);
			this.isOnTouch = true;
			this.isOnDrag = true;
			this.pointId = eventData.pointerId;
		}
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x0001791A File Offset: 0x00015D1A
	public void OnDrag(PointerEventData eventData)
	{
		if (this._activated && this.pointId == eventData.pointerId)
		{
			this.isOnTouch = true;
			this.isOnDrag = true;
			this.GetTouchDirection(eventData.position, eventData.pressEventCamera);
		}
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x00017958 File Offset: 0x00015D58
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.isOnTouch = false;
			this.isOnDrag = false;
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
			this.pointId = -1;
			this.onTouchUp.Invoke();
		}
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00017A08 File Offset: 0x00015E08
	private void UpdateDPad()
	{
		if (this.enableKeySimulation && !this.isOnTouch && this._activated && this._visible)
		{
			float axis = Input.GetAxis(this.axisX.unityAxis);
			float axis2 = Input.GetAxis(this.axisY.unityAxis);
			this.isOnDrag = false;
			this.tmpAxis = Vector2.zero;
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
		if ((this.axisX.axisValue != 0f || this.axisY.axisValue != 0f) && this.OldTmpAxis == Vector2.zero)
		{
			this.onMoveStart.Invoke();
		}
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
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x00017F9C File Offset: 0x0001639C
	protected override void SetVisible(bool forceUnvisible = false)
	{
		bool visible = this._visible;
		if (!base.visible)
		{
			visible = base.visible;
		}
		base.GetComponent<Image>().enabled = visible;
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x00017FD0 File Offset: 0x000163D0
	protected override void SetActivated()
	{
		if (!this._activated)
		{
			this.isOnTouch = false;
			this.isOnDrag = false;
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

	// Token: 0x060004E7 RID: 1255 RVA: 0x00018064 File Offset: 0x00016464
	private void GetTouchDirection(Vector2 position, Camera cam)
	{
		Vector2 vector;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedRectTransform, position, cam, out vector);
		Vector2 vector2 = this.rectTransform().sizeDelta / this.buttonSizeCoef;
		this.tmpAxis = Vector2.zero;
		if ((vector.x < -vector2.x / 2f && vector.y > -vector2.y / 2f && vector.y < vector2.y / 2f && this.dPadAxisCount == ETCBase.DPadAxis.Two_Axis) || (this.dPadAxisCount == ETCBase.DPadAxis.Four_Axis && vector.x < -vector2.x / 2f))
		{
			this.tmpAxis.x = -1f;
		}
		if ((vector.x > vector2.x / 2f && vector.y > -vector2.y / 2f && vector.y < vector2.y / 2f && this.dPadAxisCount == ETCBase.DPadAxis.Two_Axis) || (this.dPadAxisCount == ETCBase.DPadAxis.Four_Axis && vector.x > vector2.x / 2f))
		{
			this.tmpAxis.x = 1f;
		}
		if ((vector.y > vector2.y / 2f && vector.x > -vector2.x / 2f && vector.x < vector2.x / 2f && this.dPadAxisCount == ETCBase.DPadAxis.Two_Axis) || (this.dPadAxisCount == ETCBase.DPadAxis.Four_Axis && vector.y > vector2.y / 2f))
		{
			this.tmpAxis.y = 1f;
		}
		if ((vector.y < -vector2.y / 2f && vector.x > -vector2.x / 2f && vector.x < vector2.x / 2f && this.dPadAxisCount == ETCBase.DPadAxis.Two_Axis) || (this.dPadAxisCount == ETCBase.DPadAxis.Four_Axis && vector.y < -vector2.y / 2f))
		{
			this.tmpAxis.y = -1f;
		}
	}

	// Token: 0x04000352 RID: 850
	[SerializeField]
	public ETCDPad.OnMoveStartHandler onMoveStart;

	// Token: 0x04000353 RID: 851
	[SerializeField]
	public ETCDPad.OnMoveHandler onMove;

	// Token: 0x04000354 RID: 852
	[SerializeField]
	public ETCDPad.OnMoveSpeedHandler onMoveSpeed;

	// Token: 0x04000355 RID: 853
	[SerializeField]
	public ETCDPad.OnMoveEndHandler onMoveEnd;

	// Token: 0x04000356 RID: 854
	[SerializeField]
	public ETCDPad.OnTouchStartHandler onTouchStart;

	// Token: 0x04000357 RID: 855
	[SerializeField]
	public ETCDPad.OnTouchUPHandler onTouchUp;

	// Token: 0x04000358 RID: 856
	[SerializeField]
	public ETCDPad.OnDownUpHandler OnDownUp;

	// Token: 0x04000359 RID: 857
	[SerializeField]
	public ETCDPad.OnDownDownHandler OnDownDown;

	// Token: 0x0400035A RID: 858
	[SerializeField]
	public ETCDPad.OnDownLeftHandler OnDownLeft;

	// Token: 0x0400035B RID: 859
	[SerializeField]
	public ETCDPad.OnDownRightHandler OnDownRight;

	// Token: 0x0400035C RID: 860
	[SerializeField]
	public ETCDPad.OnDownUpHandler OnPressUp;

	// Token: 0x0400035D RID: 861
	[SerializeField]
	public ETCDPad.OnDownDownHandler OnPressDown;

	// Token: 0x0400035E RID: 862
	[SerializeField]
	public ETCDPad.OnDownLeftHandler OnPressLeft;

	// Token: 0x0400035F RID: 863
	[SerializeField]
	public ETCDPad.OnDownRightHandler OnPressRight;

	// Token: 0x04000360 RID: 864
	public ETCAxis axisX;

	// Token: 0x04000361 RID: 865
	public ETCAxis axisY;

	// Token: 0x04000362 RID: 866
	public Sprite normalSprite;

	// Token: 0x04000363 RID: 867
	public Color normalColor;

	// Token: 0x04000364 RID: 868
	public Sprite pressedSprite;

	// Token: 0x04000365 RID: 869
	public Color pressedColor;

	// Token: 0x04000366 RID: 870
	private Vector2 tmpAxis;

	// Token: 0x04000367 RID: 871
	private Vector2 OldTmpAxis;

	// Token: 0x04000368 RID: 872
	private bool isOnTouch;

	// Token: 0x04000369 RID: 873
	private Image cachedImage;

	// Token: 0x0400036A RID: 874
	public float buttonSizeCoef = 3f;

	// Token: 0x020000C8 RID: 200
	[Serializable]
	public class OnMoveStartHandler : UnityEvent
	{
	}

	// Token: 0x020000C9 RID: 201
	[Serializable]
	public class OnMoveHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x020000CA RID: 202
	[Serializable]
	public class OnMoveSpeedHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x020000CB RID: 203
	[Serializable]
	public class OnMoveEndHandler : UnityEvent
	{
	}

	// Token: 0x020000CC RID: 204
	[Serializable]
	public class OnTouchStartHandler : UnityEvent
	{
	}

	// Token: 0x020000CD RID: 205
	[Serializable]
	public class OnTouchUPHandler : UnityEvent
	{
	}

	// Token: 0x020000CE RID: 206
	[Serializable]
	public class OnDownUpHandler : UnityEvent
	{
	}

	// Token: 0x020000CF RID: 207
	[Serializable]
	public class OnDownDownHandler : UnityEvent
	{
	}

	// Token: 0x020000D0 RID: 208
	[Serializable]
	public class OnDownLeftHandler : UnityEvent
	{
	}

	// Token: 0x020000D1 RID: 209
	[Serializable]
	public class OnDownRightHandler : UnityEvent
	{
	}

	// Token: 0x020000D2 RID: 210
	[Serializable]
	public class OnPressUpHandler : UnityEvent
	{
	}

	// Token: 0x020000D3 RID: 211
	[Serializable]
	public class OnPressDownHandler : UnityEvent
	{
	}

	// Token: 0x020000D4 RID: 212
	[Serializable]
	public class OnPressLeftHandler : UnityEvent
	{
	}

	// Token: 0x020000D5 RID: 213
	[Serializable]
	public class OnPressRightHandler : UnityEvent
	{
	}
}
