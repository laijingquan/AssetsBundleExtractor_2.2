using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200016E RID: 366
public class GameTouchLayer : MonoBehaviour
{
	// Token: 0x06000989 RID: 2441 RVA: 0x00029224 File Offset: 0x00027624
	public void Init()
	{
		EasyTouch.SetLongTapTime(AppConfig.TOUCH_LONGTAP_TIME);
		this._cameraWidth = GameManager.Instance.cameraController.cameraSizeWidth;
		this._cameraHeight = GameManager.Instance.cameraController.cameraSizeHeight;
		this._boxCollider = base.GetComponent<BoxCollider2D>();
		this._boxCollider.size = new Vector2(this._cameraWidth, this._cameraHeight);
		this._gameTouchDrag = base.gameObject.AddComponent<GameTouchDrag>();
		this._gameTouchScale = base.gameObject.AddComponent<GameTouchScale>();
		this._gameTouchClick = base.gameObject.AddComponent<GameTouchClick>();
		this._gameTouchHold = base.gameObject.AddComponent<GameTouchHold>();
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x000292D1 File Offset: 0x000276D1
	public void SetDragEnabled(bool b)
	{
		this._gameTouchDrag.enabled = b;
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x000292DF File Offset: 0x000276DF
	public void SetScaleEnabled(bool b)
	{
		this._gameTouchScale.enabled = b;
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x000292ED File Offset: 0x000276ED
	public void SetClickEnabled(bool b)
	{
		this._gameTouchClick.enabled = b;
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x000292FB File Offset: 0x000276FB
	public void SetHoldEnabled(bool b)
	{
		this._gameTouchHold.enabled = b;
	}

	// Token: 0x0600098E RID: 2446 RVA: 0x00029309 File Offset: 0x00027709
	private void Update()
	{
	}

	// Token: 0x040005CB RID: 1483
	private float _cameraWidth;

	// Token: 0x040005CC RID: 1484
	private float _cameraHeight;

	// Token: 0x040005CD RID: 1485
	private BoxCollider2D _boxCollider;

	// Token: 0x040005CE RID: 1486
	private GameTouchDrag _gameTouchDrag;

	// Token: 0x040005CF RID: 1487
	private GameTouchScale _gameTouchScale;

	// Token: 0x040005D0 RID: 1488
	private GameTouchClick _gameTouchClick;

	// Token: 0x040005D1 RID: 1489
	private GameTouchHold _gameTouchHold;
}
