using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000043 RID: 67
public class UIWindow : MonoBehaviour, IDragHandler, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x0600023B RID: 571 RVA: 0x0000A988 File Offset: 0x00008D88
	public void OnDrag(PointerEventData eventData)
	{
		base.transform.position += eventData.delta;
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0000A9AB File Offset: 0x00008DAB
	public void OnPointerDown(PointerEventData eventData)
	{
		base.transform.SetAsLastSibling();
	}
}
