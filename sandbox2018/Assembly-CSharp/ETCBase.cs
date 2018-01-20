using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020000BC RID: 188
[Serializable]
public abstract class ETCBase : MonoBehaviour
{
	// Token: 0x1700003C RID: 60
	// (get) Token: 0x060004B2 RID: 1202 RVA: 0x000166B9 File Offset: 0x00014AB9
	// (set) Token: 0x060004B3 RID: 1203 RVA: 0x000166C1 File Offset: 0x00014AC1
	public ETCBase.RectAnchor anchor
	{
		get
		{
			return this._anchor;
		}
		set
		{
			if (value != this._anchor)
			{
				this._anchor = value;
				this.SetAnchorPosition();
			}
		}
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x060004B4 RID: 1204 RVA: 0x000166DC File Offset: 0x00014ADC
	// (set) Token: 0x060004B5 RID: 1205 RVA: 0x000166E4 File Offset: 0x00014AE4
	public Vector2 anchorOffet
	{
		get
		{
			return this._anchorOffet;
		}
		set
		{
			if (value != this._anchorOffet)
			{
				this._anchorOffet = value;
				this.SetAnchorPosition();
			}
		}
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x060004B6 RID: 1206 RVA: 0x00016704 File Offset: 0x00014B04
	// (set) Token: 0x060004B7 RID: 1207 RVA: 0x0001670C File Offset: 0x00014B0C
	public bool visible
	{
		get
		{
			return this._visible;
		}
		set
		{
			if (value != this._visible)
			{
				this._visible = value;
				this.SetVisible(true);
			}
		}
	}

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00016728 File Offset: 0x00014B28
	// (set) Token: 0x060004B9 RID: 1209 RVA: 0x00016730 File Offset: 0x00014B30
	public bool activated
	{
		get
		{
			return this._activated;
		}
		set
		{
			if (value != this._activated)
			{
				this._activated = value;
				this.SetActivated();
			}
		}
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x0001674C File Offset: 0x00014B4C
	protected virtual void Awake()
	{
		this.cachedRectTransform = (base.transform as RectTransform);
		this.cachedRootCanvas = base.transform.parent.GetComponent<Canvas>();
		if (!this.allowSimulationStandalone)
		{
			this.enableKeySimulation = false;
		}
		this.visibleAtStart = this._visible;
		this.activatedAtStart = this._activated;
		if (!this.isUnregisterAtDisable)
		{
			ETCInput.instance.RegisterControl(this);
		}
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x000167C0 File Offset: 0x00014BC0
	public virtual void Start()
	{
		if (this.enableCamera && this.autoLinkTagCam)
		{
			this.cameraTransform = null;
			GameObject gameObject = GameObject.FindGameObjectWithTag(this.autoCamTag);
			if (gameObject)
			{
				this.cameraTransform = gameObject.transform;
			}
		}
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x0001680D File Offset: 0x00014C0D
	public virtual void OnEnable()
	{
		if (this.isUnregisterAtDisable)
		{
			ETCInput.instance.RegisterControl(this);
		}
		this.visible = this.visibleAtStart;
		this.activated = this.activatedAtStart;
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x00016840 File Offset: 0x00014C40
	private void OnDisable()
	{
		if (ETCInput._instance && this.isUnregisterAtDisable)
		{
			ETCInput.instance.UnRegisterControl(this);
		}
		this.visibleAtStart = this._visible;
		this.activated = this._activated;
		this.visible = false;
		this.activated = false;
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x00016898 File Offset: 0x00014C98
	private void OnDestroy()
	{
		if (ETCInput._instance)
		{
			ETCInput.instance.UnRegisterControl(this);
		}
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x000168B4 File Offset: 0x00014CB4
	public virtual void Update()
	{
		if (!this.useFixedUpdate)
		{
			this.DoActionBeforeEndOfFrame();
		}
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x000168C7 File Offset: 0x00014CC7
	public virtual void FixedUpdate()
	{
		if (this.useFixedUpdate)
		{
			this.DoActionBeforeEndOfFrame();
		}
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x000168DC File Offset: 0x00014CDC
	public virtual void LateUpdate()
	{
		if (this.enableCamera)
		{
			if (this.autoLinkTagCam && this.cameraTransform == null)
			{
				GameObject gameObject = GameObject.FindGameObjectWithTag(this.autoCamTag);
				if (gameObject)
				{
					this.cameraTransform = gameObject.transform;
				}
			}
			ETCBase.CameraMode cameraMode = this.cameraMode;
			if (cameraMode != ETCBase.CameraMode.Follow)
			{
				if (cameraMode == ETCBase.CameraMode.SmoothFollow)
				{
					this.CameraSmoothFollow();
				}
			}
			else
			{
				this.CameraFollow();
			}
		}
		this.UpdateControlState();
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00016968 File Offset: 0x00014D68
	protected virtual void UpdateControlState()
	{
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x0001696A File Offset: 0x00014D6A
	protected virtual void SetVisible(bool forceUnvisible = true)
	{
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0001696C File Offset: 0x00014D6C
	protected virtual void SetActivated()
	{
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x00016970 File Offset: 0x00014D70
	public void SetAnchorPosition()
	{
		switch (this._anchor)
		{
		case ETCBase.RectAnchor.BottomLeft:
			this.rectTransform().anchorMin = new Vector2(0f, 0f);
			this.rectTransform().anchorMax = new Vector2(0f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f + this._anchorOffet.x, this.rectTransform().sizeDelta.y / 2f + this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.BottomCenter:
			this.rectTransform().anchorMin = new Vector2(0.5f, 0f);
			this.rectTransform().anchorMax = new Vector2(0.5f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(this._anchorOffet.x, this.rectTransform().sizeDelta.y / 2f + this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.BottonRight:
			this.rectTransform().anchorMin = new Vector2(1f, 0f);
			this.rectTransform().anchorMax = new Vector2(1f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f - this._anchorOffet.x, this.rectTransform().sizeDelta.y / 2f + this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.CenterLeft:
			this.rectTransform().anchorMin = new Vector2(0f, 0.5f);
			this.rectTransform().anchorMax = new Vector2(0f, 0.5f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f + this._anchorOffet.x, this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.Center:
			this.rectTransform().anchorMin = new Vector2(0.5f, 0.5f);
			this.rectTransform().anchorMax = new Vector2(0.5f, 0.5f);
			this.rectTransform().anchoredPosition = new Vector2(this._anchorOffet.x, this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.CenterRight:
			this.rectTransform().anchorMin = new Vector2(1f, 0.5f);
			this.rectTransform().anchorMax = new Vector2(1f, 0.5f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f - this._anchorOffet.x, this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.TopLeft:
			this.rectTransform().anchorMin = new Vector2(0f, 1f);
			this.rectTransform().anchorMax = new Vector2(0f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f + this._anchorOffet.x, -this.rectTransform().sizeDelta.y / 2f - this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.TopCenter:
			this.rectTransform().anchorMin = new Vector2(0.5f, 1f);
			this.rectTransform().anchorMax = new Vector2(0.5f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(this._anchorOffet.x, -this.rectTransform().sizeDelta.y / 2f - this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.TopRight:
			this.rectTransform().anchorMin = new Vector2(1f, 1f);
			this.rectTransform().anchorMax = new Vector2(1f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f - this._anchorOffet.x, -this.rectTransform().sizeDelta.y / 2f - this._anchorOffet.y);
			break;
		}
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x00016E54 File Offset: 0x00015254
	protected GameObject GetFirstUIElement(Vector2 position)
	{
		this.uiEventSystem = EventSystem.current;
		if (!(this.uiEventSystem != null))
		{
			return null;
		}
		this.uiPointerEventData = new PointerEventData(this.uiEventSystem);
		this.uiPointerEventData.position = position;
		this.uiEventSystem.RaycastAll(this.uiPointerEventData, this.uiRaycastResultCache);
		if (this.uiRaycastResultCache.Count > 0)
		{
			return this.uiRaycastResultCache[0].gameObject;
		}
		return null;
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00016EDC File Offset: 0x000152DC
	protected void CameraSmoothFollow()
	{
		if (!this.cameraTransform || !this.cameraLookAt)
		{
			return;
		}
		float y = this.cameraLookAt.eulerAngles.y;
		float b = this.cameraLookAt.position.y + this.followHeight;
		float num = this.cameraTransform.eulerAngles.y;
		float num2 = this.cameraTransform.position.y;
		num = Mathf.LerpAngle(num, y, this.followRotationDamping * Time.deltaTime);
		num2 = Mathf.Lerp(num2, b, this.followHeightDamping * Time.deltaTime);
		Quaternion rotation = Quaternion.Euler(0f, num, 0f);
		Vector3 vector = this.cameraLookAt.position;
		vector -= rotation * Vector3.forward * this.followDistance;
		vector = new Vector3(vector.x, num2, vector.z);
		RaycastHit raycastHit;
		if (this.enableWallDetection && Physics.Linecast(new Vector3(this.cameraLookAt.position.x, this.cameraLookAt.position.y + 1f, this.cameraLookAt.position.z), vector, out raycastHit))
		{
			vector = new Vector3(raycastHit.point.x, num2, raycastHit.point.z);
		}
		this.cameraTransform.position = vector;
		this.cameraTransform.LookAt(this.cameraLookAt);
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x00017090 File Offset: 0x00015490
	protected void CameraFollow()
	{
		if (!this.cameraTransform || !this.cameraLookAt)
		{
			return;
		}
		Vector3 b = this.followOffset;
		this.cameraTransform.position = this.cameraLookAt.position + b;
		this.cameraTransform.LookAt(this.cameraLookAt.position);
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x000170F8 File Offset: 0x000154F8
	private IEnumerator UpdateVirtualControl()
	{
		this.DoActionBeforeEndOfFrame();
		yield return new WaitForEndOfFrame();
		this.UpdateControlState();
		yield break;
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x00017114 File Offset: 0x00015514
	private IEnumerator FixedUpdateVirtualControl()
	{
		this.DoActionBeforeEndOfFrame();
		yield return new WaitForFixedUpdate();
		this.UpdateControlState();
		yield break;
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x0001712F File Offset: 0x0001552F
	protected virtual void DoActionBeforeEndOfFrame()
	{
	}

	// Token: 0x040002FC RID: 764
	protected RectTransform cachedRectTransform;

	// Token: 0x040002FD RID: 765
	protected Canvas cachedRootCanvas;

	// Token: 0x040002FE RID: 766
	public bool isUnregisterAtDisable;

	// Token: 0x040002FF RID: 767
	private bool visibleAtStart = true;

	// Token: 0x04000300 RID: 768
	private bool activatedAtStart = true;

	// Token: 0x04000301 RID: 769
	[SerializeField]
	protected ETCBase.RectAnchor _anchor;

	// Token: 0x04000302 RID: 770
	[SerializeField]
	protected Vector2 _anchorOffet;

	// Token: 0x04000303 RID: 771
	[SerializeField]
	protected bool _visible;

	// Token: 0x04000304 RID: 772
	[SerializeField]
	protected bool _activated;

	// Token: 0x04000305 RID: 773
	public bool enableCamera;

	// Token: 0x04000306 RID: 774
	public ETCBase.CameraMode cameraMode;

	// Token: 0x04000307 RID: 775
	public string camTargetTag = "Player";

	// Token: 0x04000308 RID: 776
	public bool autoLinkTagCam = true;

	// Token: 0x04000309 RID: 777
	public string autoCamTag = "MainCamera";

	// Token: 0x0400030A RID: 778
	public Transform cameraTransform;

	// Token: 0x0400030B RID: 779
	public ETCBase.CameraTargetMode cameraTargetMode;

	// Token: 0x0400030C RID: 780
	public bool enableWallDetection;

	// Token: 0x0400030D RID: 781
	public LayerMask wallLayer = 0;

	// Token: 0x0400030E RID: 782
	public Transform cameraLookAt;

	// Token: 0x0400030F RID: 783
	protected CharacterController cameraLookAtCC;

	// Token: 0x04000310 RID: 784
	public Vector3 followOffset = new Vector3(0f, 6f, -6f);

	// Token: 0x04000311 RID: 785
	public float followDistance = 10f;

	// Token: 0x04000312 RID: 786
	public float followHeight = 5f;

	// Token: 0x04000313 RID: 787
	public float followRotationDamping = 5f;

	// Token: 0x04000314 RID: 788
	public float followHeightDamping = 5f;

	// Token: 0x04000315 RID: 789
	public int pointId = -1;

	// Token: 0x04000316 RID: 790
	public bool enableKeySimulation;

	// Token: 0x04000317 RID: 791
	public bool allowSimulationStandalone;

	// Token: 0x04000318 RID: 792
	public bool visibleOnStandalone = true;

	// Token: 0x04000319 RID: 793
	public ETCBase.DPadAxis dPadAxisCount;

	// Token: 0x0400031A RID: 794
	public bool useFixedUpdate;

	// Token: 0x0400031B RID: 795
	private List<RaycastResult> uiRaycastResultCache = new List<RaycastResult>();

	// Token: 0x0400031C RID: 796
	private PointerEventData uiPointerEventData;

	// Token: 0x0400031D RID: 797
	private EventSystem uiEventSystem;

	// Token: 0x0400031E RID: 798
	public bool isOnDrag;

	// Token: 0x0400031F RID: 799
	public bool isSwipeIn;

	// Token: 0x04000320 RID: 800
	public bool isSwipeOut;

	// Token: 0x04000321 RID: 801
	public bool showPSInspector;

	// Token: 0x04000322 RID: 802
	public bool showSpriteInspector;

	// Token: 0x04000323 RID: 803
	public bool showEventInspector;

	// Token: 0x04000324 RID: 804
	public bool showBehaviourInspector;

	// Token: 0x04000325 RID: 805
	public bool showAxesInspector;

	// Token: 0x04000326 RID: 806
	public bool showTouchEventInspector;

	// Token: 0x04000327 RID: 807
	public bool showDownEventInspector;

	// Token: 0x04000328 RID: 808
	public bool showPressEventInspector;

	// Token: 0x04000329 RID: 809
	public bool showCameraInspector;

	// Token: 0x020000BD RID: 189
	public enum ControlType
	{
		// Token: 0x0400032B RID: 811
		Joystick,
		// Token: 0x0400032C RID: 812
		TouchPad,
		// Token: 0x0400032D RID: 813
		DPad,
		// Token: 0x0400032E RID: 814
		Button
	}

	// Token: 0x020000BE RID: 190
	public enum RectAnchor
	{
		// Token: 0x04000330 RID: 816
		UserDefined,
		// Token: 0x04000331 RID: 817
		BottomLeft,
		// Token: 0x04000332 RID: 818
		BottomCenter,
		// Token: 0x04000333 RID: 819
		BottonRight,
		// Token: 0x04000334 RID: 820
		CenterLeft,
		// Token: 0x04000335 RID: 821
		Center,
		// Token: 0x04000336 RID: 822
		CenterRight,
		// Token: 0x04000337 RID: 823
		TopLeft,
		// Token: 0x04000338 RID: 824
		TopCenter,
		// Token: 0x04000339 RID: 825
		TopRight
	}

	// Token: 0x020000BF RID: 191
	public enum DPadAxis
	{
		// Token: 0x0400033B RID: 827
		Two_Axis,
		// Token: 0x0400033C RID: 828
		Four_Axis
	}

	// Token: 0x020000C0 RID: 192
	public enum CameraMode
	{
		// Token: 0x0400033E RID: 830
		Follow,
		// Token: 0x0400033F RID: 831
		SmoothFollow
	}

	// Token: 0x020000C1 RID: 193
	public enum CameraTargetMode
	{
		// Token: 0x04000341 RID: 833
		UserDefined,
		// Token: 0x04000342 RID: 834
		LinkOnTag,
		// Token: 0x04000343 RID: 835
		FromDirectActionAxisX,
		// Token: 0x04000344 RID: 836
		FromDirectActionAxisY
	}
}
