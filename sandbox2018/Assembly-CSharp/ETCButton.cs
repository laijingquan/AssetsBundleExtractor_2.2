using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000C2 RID: 194
[Serializable]
public class ETCButton : ETCBase, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x060004CC RID: 1228 RVA: 0x0001726C File Offset: 0x0001566C
	public ETCButton()
	{
		this.axis = new ETCAxis("Button");
		this._visible = true;
		this._activated = true;
		this.isOnTouch = false;
		this.enableKeySimulation = true;
		this.axis.unityAxis = "Jump";
		this.showPSInspector = true;
		this.showSpriteInspector = false;
		this.showBehaviourInspector = false;
		this.showEventInspector = false;
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x000172D7 File Offset: 0x000156D7
	protected override void Awake()
	{
		base.Awake();
		this.cachedImage = base.GetComponent<Image>();
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x000172EC File Offset: 0x000156EC
	public override void Start()
	{
		this.axis.InitAxis();
		base.Start();
		this.isOnPress = false;
		if (this.allowSimulationStandalone && this.enableKeySimulation && !Application.isEditor)
		{
			this.SetVisible(this.visibleOnStandalone);
		}
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x0001733D File Offset: 0x0001573D
	protected override void UpdateControlState()
	{
		this.UpdateButton();
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x00017345 File Offset: 0x00015745
	protected override void DoActionBeforeEndOfFrame()
	{
		this.axis.DoGravity();
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x00017354 File Offset: 0x00015754
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.isSwipeIn && !this.isOnTouch)
		{
			if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<ETCBase>() && eventData.pointerDrag != base.gameObject)
			{
				this.previousDargObject = eventData.pointerDrag;
			}
			eventData.pointerDrag = base.gameObject;
			eventData.pointerPress = base.gameObject;
			this.OnPointerDown(eventData);
		}
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x000173E0 File Offset: 0x000157E0
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this._activated && !this.isOnTouch)
		{
			this.pointId = eventData.pointerId;
			this.axis.ResetAxis();
			this.axis.axisState = ETCAxis.AxisState.Down;
			this.isOnPress = false;
			this.isOnTouch = true;
			this.onDown.Invoke();
			this.ApllyState();
			this.axis.UpdateButton();
		}
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x00017450 File Offset: 0x00015850
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.isOnPress = false;
			this.isOnTouch = false;
			this.axis.axisState = ETCAxis.AxisState.Up;
			this.axis.axisValue = 0f;
			this.onUp.Invoke();
			this.ApllyState();
			if (this.previousDargObject)
			{
				ExecuteEvents.Execute<IPointerUpHandler>(this.previousDargObject, eventData, ExecuteEvents.pointerUpHandler);
				this.previousDargObject = null;
			}
		}
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x000174D2 File Offset: 0x000158D2
	public void OnPointerExit(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId && this.axis.axisState == ETCAxis.AxisState.Press && !this.isSwipeOut)
		{
			this.OnPointerUp(eventData);
		}
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x00017508 File Offset: 0x00015908
	private void UpdateButton()
	{
		if (this.axis.axisState == ETCAxis.AxisState.Down)
		{
			this.isOnPress = true;
			this.axis.axisState = ETCAxis.AxisState.Press;
		}
		if (this.isOnPress)
		{
			this.axis.UpdateButton();
			this.onPressed.Invoke();
			this.onPressedValue.Invoke(this.axis.axisValue);
		}
		if (this.axis.axisState == ETCAxis.AxisState.Up)
		{
			this.isOnPress = false;
			this.axis.axisState = ETCAxis.AxisState.None;
		}
		if (this.enableKeySimulation && this._activated && this._visible && !this.isOnTouch)
		{
			if (Input.GetButton(this.axis.unityAxis) && this.axis.axisState == ETCAxis.AxisState.None)
			{
				this.axis.ResetAxis();
				this.onDown.Invoke();
				this.axis.axisState = ETCAxis.AxisState.Down;
			}
			if (!Input.GetButton(this.axis.unityAxis) && this.axis.axisState == ETCAxis.AxisState.Press)
			{
				this.axis.axisState = ETCAxis.AxisState.Up;
				this.axis.axisValue = 0f;
				this.onUp.Invoke();
			}
			this.axis.UpdateButton();
			this.ApllyState();
		}
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x00017668 File Offset: 0x00015A68
	protected override void SetVisible(bool forceUnvisible = false)
	{
		bool visible = this._visible;
		if (!base.visible)
		{
			visible = base.visible;
		}
		base.GetComponent<Image>().enabled = visible;
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x0001769C File Offset: 0x00015A9C
	private void ApllyState()
	{
		if (this.cachedImage)
		{
			ETCAxis.AxisState axisState = this.axis.axisState;
			if (axisState != ETCAxis.AxisState.Down && axisState != ETCAxis.AxisState.Press)
			{
				this.cachedImage.sprite = this.normalSprite;
				this.cachedImage.color = this.normalColor;
			}
			else
			{
				this.cachedImage.sprite = this.pressedSprite;
				this.cachedImage.color = this.pressedColor;
			}
		}
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x00017726 File Offset: 0x00015B26
	protected override void SetActivated()
	{
		if (!this._activated)
		{
			this.isOnPress = false;
			this.isOnTouch = false;
			this.axis.axisState = ETCAxis.AxisState.None;
			this.axis.axisValue = 0f;
			this.ApllyState();
		}
	}

	// Token: 0x04000345 RID: 837
	[SerializeField]
	public ETCButton.OnDownHandler onDown;

	// Token: 0x04000346 RID: 838
	[SerializeField]
	public ETCButton.OnPressedHandler onPressed;

	// Token: 0x04000347 RID: 839
	[SerializeField]
	public ETCButton.OnPressedValueandler onPressedValue;

	// Token: 0x04000348 RID: 840
	[SerializeField]
	public ETCButton.OnUPHandler onUp;

	// Token: 0x04000349 RID: 841
	public ETCAxis axis;

	// Token: 0x0400034A RID: 842
	public Sprite normalSprite;

	// Token: 0x0400034B RID: 843
	public Color normalColor;

	// Token: 0x0400034C RID: 844
	public Sprite pressedSprite;

	// Token: 0x0400034D RID: 845
	public Color pressedColor;

	// Token: 0x0400034E RID: 846
	private Image cachedImage;

	// Token: 0x0400034F RID: 847
	private bool isOnPress;

	// Token: 0x04000350 RID: 848
	private GameObject previousDargObject;

	// Token: 0x04000351 RID: 849
	private bool isOnTouch;

	// Token: 0x020000C3 RID: 195
	[Serializable]
	public class OnDownHandler : UnityEvent
	{
	}

	// Token: 0x020000C4 RID: 196
	[Serializable]
	public class OnPressedHandler : UnityEvent
	{
	}

	// Token: 0x020000C5 RID: 197
	[Serializable]
	public class OnPressedValueandler : UnityEvent<float>
	{
	}

	// Token: 0x020000C6 RID: 198
	[Serializable]
	public class OnUPHandler : UnityEvent
	{
	}
}
