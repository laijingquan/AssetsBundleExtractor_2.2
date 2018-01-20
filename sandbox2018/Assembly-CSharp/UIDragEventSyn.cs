using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000177 RID: 375
public class UIDragEventSyn : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler, IEventSystemHandler
{
	// Token: 0x060009D9 RID: 2521 RVA: 0x0002A923 File Offset: 0x00028D23
	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.YScrollRect)
		{
			this.YScrollRect.OnEndDrag(eventData);
		}
	}

	// Token: 0x060009DA RID: 2522 RVA: 0x0002A941 File Offset: 0x00028D41
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.YScrollRect)
		{
			this.YScrollRect.OnBeginDrag(eventData);
		}
	}

	// Token: 0x060009DB RID: 2523 RVA: 0x0002A95F File Offset: 0x00028D5F
	public void OnDrag(PointerEventData eventData)
	{
		if (this.YScrollRect)
		{
			this.YScrollRect.OnDrag(eventData);
		}
	}

	// Token: 0x040005FA RID: 1530
	public ScrollRect YScrollRect;
}
