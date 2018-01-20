using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000174 RID: 372
public class AutoCenter : MonoBehaviour
{
	// Token: 0x060009D1 RID: 2513 RVA: 0x0002A6D8 File Offset: 0x00028AD8
	private void Update()
	{
		if (this.mNeedMove)
		{
			if (Mathf.Abs(this.m_Scrollbar.value - this.mTargetValue) < 0.01f)
			{
				this.m_Scrollbar.value = this.mTargetValue;
				this.mNeedMove = false;
				return;
			}
			this.m_Scrollbar.value = Mathf.SmoothDamp(this.m_Scrollbar.value, this.mTargetValue, ref this.mMoveSpeed, 0.2f);
		}
	}

	// Token: 0x060009D2 RID: 2514 RVA: 0x0002A758 File Offset: 0x00028B58
	public void PosChange()
	{
		if (this.m_Scrollbar.value <= 0.125f)
		{
			this.mTargetValue = 0f;
			MonoBehaviour.print("0");
		}
		else if (this.m_Scrollbar.value <= 0.375f)
		{
			this.mTargetValue = 0.25f;
			MonoBehaviour.print("0.25");
		}
		else if (this.m_Scrollbar.value <= 0.625f)
		{
			this.mTargetValue = 0.5f;
			MonoBehaviour.print("0.5");
		}
		else if (this.m_Scrollbar.value <= 0.875f)
		{
			this.mTargetValue = 0.75f;
			MonoBehaviour.print("0.75");
		}
		else
		{
			this.mTargetValue = 1f;
			MonoBehaviour.print("1");
		}
		this.mNeedMove = true;
	}

	// Token: 0x040005F3 RID: 1523
	public Scrollbar m_Scrollbar;

	// Token: 0x040005F4 RID: 1524
	private float mTargetValue;

	// Token: 0x040005F5 RID: 1525
	private bool mNeedMove;

	// Token: 0x040005F6 RID: 1526
	private const float MOVE_SPEED = 1f;

	// Token: 0x040005F7 RID: 1527
	private const float SMOOTH_TIME = 0.2f;

	// Token: 0x040005F8 RID: 1528
	private float mMoveSpeed;
}
