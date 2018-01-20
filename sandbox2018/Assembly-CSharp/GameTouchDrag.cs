using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200016C RID: 364
public class GameTouchDrag : MonoBehaviour
{
	// Token: 0x06000977 RID: 2423 RVA: 0x00028E05 File Offset: 0x00027205
	private void OnEnable()
	{
		EasyTouch.On_Drag += this.On_Drag;
		EasyTouch.On_DragStart += this.On_DragStart;
		EasyTouch.On_DragEnd += this.On_DragEnd;
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x00028E3A File Offset: 0x0002723A
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x00028E42 File Offset: 0x00027242
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x00028E4A File Offset: 0x0002724A
	private void UnsubscribeEvent()
	{
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_DragStart -= this.On_DragStart;
		EasyTouch.On_DragEnd -= this.On_DragEnd;
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x00028E80 File Offset: 0x00027280
	private void On_DragStart(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			GameManager.Instance.levelManager.isFirstTouch = true;
			this.fingerIndex = gesture.fingerIndex;
			Transform transform = GameManager.Instance.gameTilesLayer.transform;
			Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			this.deltaPosition = touchToWorldPoint - transform.position;
		}
	}

	// Token: 0x0600097C RID: 2428 RVA: 0x00028EF8 File Offset: 0x000272F8
	private void On_Drag(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject && this.fingerIndex == gesture.fingerIndex)
		{
			Vector3 vector = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
			vector -= this.deltaPosition;
			GameManager.Instance.levelManager.UpdateTouchDrag(vector);
		}
	}

	// Token: 0x0600097D RID: 2429 RVA: 0x00028F60 File Offset: 0x00027360
	private void On_DragEnd(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			base.enabled = true;
		}
	}

	// Token: 0x040005C8 RID: 1480
	private Vector3 deltaPosition;

	// Token: 0x040005C9 RID: 1481
	private int fingerIndex;
}
