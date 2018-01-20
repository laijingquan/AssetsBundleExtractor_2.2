using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000173 RID: 371
public class NestedScrollRect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IEventSystemHandler
{
	// Token: 0x060009CC RID: 2508 RVA: 0x0002A5CC File Offset: 0x000289CC
	private void Awake()
	{
		this.thisScrollRect = base.GetComponent<ScrollRect>();
	}

	// Token: 0x060009CD RID: 2509 RVA: 0x0002A5DA File Offset: 0x000289DA
	public void OnBeginDrag(PointerEventData eventData)
	{
		this.anotherScrollRect.enabled = true;
		this.thisScrollRect.enabled = true;
		this.anotherScrollRect.OnBeginDrag(eventData);
	}

	// Token: 0x060009CE RID: 2510 RVA: 0x0002A600 File Offset: 0x00028A00
	public void OnDrag(PointerEventData eventData)
	{
		this.anotherScrollRect.enabled = true;
		this.thisScrollRect.enabled = true;
		this.anotherScrollRect.OnDrag(eventData);
		float num = Vector2.Angle(eventData.delta, Vector2.up);
		if (num > 45f && num < 135f)
		{
			this.thisScrollRect.enabled = !this.thisIsUpAndDown;
			this.anotherScrollRect.enabled = this.thisIsUpAndDown;
		}
		else
		{
			this.anotherScrollRect.enabled = !this.thisIsUpAndDown;
			this.thisScrollRect.enabled = this.thisIsUpAndDown;
		}
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x0002A6A7 File Offset: 0x00028AA7
	public void OnEndDrag(PointerEventData eventData)
	{
		this.anotherScrollRect.OnEndDrag(eventData);
		this.anotherScrollRect.enabled = true;
		this.thisScrollRect.enabled = true;
	}

	// Token: 0x040005F0 RID: 1520
	public ScrollRect anotherScrollRect;

	// Token: 0x040005F1 RID: 1521
	private bool thisIsUpAndDown;

	// Token: 0x040005F2 RID: 1522
	private ScrollRect thisScrollRect;
}
