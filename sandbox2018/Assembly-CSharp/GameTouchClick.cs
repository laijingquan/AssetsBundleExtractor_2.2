using System;
using HedgehogTeam.EasyTouch;
using UnityEngine;

// Token: 0x0200016B RID: 363
public class GameTouchClick : MonoBehaviour
{
	// Token: 0x06000971 RID: 2417 RVA: 0x00028D44 File Offset: 0x00027144
	private void OnEnable()
	{
		EasyTouch.On_SimpleTap += this.On_SimpleTap;
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x00028D57 File Offset: 0x00027157
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x00028D5F File Offset: 0x0002715F
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x00028D67 File Offset: 0x00027167
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SimpleTap -= this.On_SimpleTap;
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x00028D7C File Offset: 0x0002717C
	private void On_SimpleTap(Gesture gesture)
	{
		if (gesture.pickedObject == base.gameObject)
		{
			GameManager.Instance.gameTouchLayer.SetDragEnabled(true);
			if (!GameManager.Instance.levelManager.isFirstTouch)
			{
				GameManager.Instance.levelManager.isFirstTouch = true;
				GameManager.Instance.levelManager.MaxZoom();
			}
			else
			{
				GameManager.Instance.tileManager.TileClick(gesture.position, true);
			}
		}
	}
}
