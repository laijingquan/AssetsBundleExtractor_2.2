using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000178 RID: 376
public class UIScrollViewDragDirection : MonoBehaviour
{
	// Token: 0x060009DD RID: 2525 RVA: 0x0002A997 File Offset: 0x00028D97
	private void Update()
	{
		this.Determine();
		this.DirectionSwitch();
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x0002A9A8 File Offset: 0x00028DA8
	private void Determine()
	{
		if (Input.GetMouseButton(0) && this.changeFlag)
		{
			float num = Mathf.Abs(Input.GetAxis("Mouse X"));
			float num2 = Mathf.Abs(Input.GetAxis("Mouse Y"));
			if (num2 > num)
			{
				this.nowDirection = UIScrollViewDragDirection.Direction.Y;
				this.changeFlag = false;
			}
			else if (num > num2)
			{
				this.nowDirection = UIScrollViewDragDirection.Direction.X;
				this.changeFlag = false;
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			this.nowDirection = UIScrollViewDragDirection.Direction.None;
			this.changeFlag = true;
		}
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x0002AA34 File Offset: 0x00028E34
	private void DirectionSwitch()
	{
		UIScrollViewDragDirection.Direction direction = this.nowDirection;
		if (direction != UIScrollViewDragDirection.Direction.None)
		{
			if (direction != UIScrollViewDragDirection.Direction.X)
			{
				if (direction == UIScrollViewDragDirection.Direction.Y)
				{
					this.SetSwitch(false, true);
				}
			}
			else
			{
				this.SetSwitch(true, false);
			}
		}
		else
		{
			this.SetSwitch(true, true);
		}
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x0002AA88 File Offset: 0x00028E88
	private void SetSwitch(bool x, bool y)
	{
		for (int i = 0; i < this.horizontalScrollRect.Count; i++)
		{
			this.horizontalScrollRect[i].enabled = x;
		}
		this.verticalScrollRect.enabled = y;
	}

	// Token: 0x040005FB RID: 1531
	private UIScrollViewDragDirection.Direction nowDirection;

	// Token: 0x040005FC RID: 1532
	public ScrollRect verticalScrollRect;

	// Token: 0x040005FD RID: 1533
	public List<ScrollRect> horizontalScrollRect = new List<ScrollRect>();

	// Token: 0x040005FE RID: 1534
	private bool changeFlag = true;

	// Token: 0x02000179 RID: 377
	public enum Direction
	{
		// Token: 0x04000600 RID: 1536
		None,
		// Token: 0x04000601 RID: 1537
		X,
		// Token: 0x04000602 RID: 1538
		Y
	}
}
