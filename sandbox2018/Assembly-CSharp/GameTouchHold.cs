using System;
using System.Collections;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200016D RID: 365
public class GameTouchHold : MonoBehaviour
{
	// Token: 0x0600097F RID: 2431 RVA: 0x00028F8E File Offset: 0x0002738E
	private void OnEnable()
	{
		EasyTouch.On_LongTapStart += this.On_LongTapStart;
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x00028FA1 File Offset: 0x000273A1
	private void OnDestroy()
	{
		this.SetSlideTouchEnable(false);
		EasyTouch.On_LongTapStart -= this.On_LongTapStart;
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x00028FBC File Offset: 0x000273BC
	private void OnHoldStart()
	{
		this.SetSlideTouchEnable(true);
		GameManager.Instance.levelManager.isFirstTouch = true;
		Vibration.Vibrate(AppConfig.TOUCH_VIBRATE_TIME);
		GameManager.Instance.gameTouchLayer.SetDragEnabled(false);
		GameManager.Instance.gameTouchLayer.SetClickEnabled(false);
		GameManager.Instance.gameTouchLayer.SetScaleEnabled(false);
		GameManager.Instance.tileManager.TileHoldOnceClickReset();
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x00029029 File Offset: 0x00027429
	private void OnHoldEnd()
	{
		this.SetSlideTouchEnable(false);
		GameManager.Instance.gameTouchLayer.SetDragEnabled(true);
		GameManager.Instance.gameTouchLayer.SetClickEnabled(true);
		GameManager.Instance.gameTouchLayer.SetScaleEnabled(true);
	}

	// Token: 0x06000983 RID: 2435 RVA: 0x00029064 File Offset: 0x00027464
	private void SetSlideTouchEnable(bool b)
	{
		if (b)
		{
			EasyTouch.On_TouchDown += this.On_TouchDown;
			EasyTouch.On_TouchUp += this.On_TouchUp;
		}
		else
		{
			EasyTouch.On_TouchDown -= this.On_TouchDown;
			EasyTouch.On_TouchUp -= this.On_TouchUp;
		}
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x000290C0 File Offset: 0x000274C0
	private void On_LongTapStart(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			int curGridCount = GameManager.Instance.levelManager.GetCurGridCount();
			if (curGridCount < AppConfig.HOLD_DRAW_GRID_MAX && this._isHoldEnabled)
			{
				this.OnHoldStart();
				base.StartCoroutine(this.DelayHoldEnabled(0.2f));
			}
		}
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x00029124 File Offset: 0x00027524
	private IEnumerator DelayHoldEnabled(float delayTime)
	{
		this._isHoldEnabled = false;
		yield return new WaitForSeconds(delayTime);
		this._isHoldEnabled = true;
		yield break;
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x00029146 File Offset: 0x00027546
	private void On_TouchDown(Gesture gesture)
	{
		if (gesture.pickedObject != null)
		{
			GameManager.Instance.tileManager.TileClick(gesture.position, false);
		}
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x0002916F File Offset: 0x0002756F
	private void On_TouchUp(Gesture gesture)
	{
		this.OnHoldEnd();
	}

	// Token: 0x040005CA RID: 1482
	private bool _isHoldEnabled = true;
}
