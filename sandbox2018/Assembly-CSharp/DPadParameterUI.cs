using System;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class DPadParameterUI : MonoBehaviour
{
	// Token: 0x06000468 RID: 1128 RVA: 0x0001481F File Offset: 0x00012C1F
	public void SetClassicalInertia(bool value)
	{
		ETCInput.SetAxisInertia("Horizontal", value);
		ETCInput.SetAxisInertia("Vertical", value);
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x00014837 File Offset: 0x00012C37
	public void SetTimePushInertia(bool value)
	{
		ETCInput.SetAxisInertia("HorizontalTP", value);
		ETCInput.SetAxisInertia("VerticalTP", value);
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x0001484F File Offset: 0x00012C4F
	public void SetClassicalTwoAxesCount()
	{
		ETCInput.SetDPadAxesCount("DPadClassical", ETCBase.DPadAxis.Two_Axis);
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x0001485C File Offset: 0x00012C5C
	public void SetClassicalFourAxesCount()
	{
		ETCInput.SetDPadAxesCount("DPadClassical", ETCBase.DPadAxis.Four_Axis);
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x00014869 File Offset: 0x00012C69
	public void SetTimePushTwoAxesCount()
	{
		ETCInput.SetDPadAxesCount("DPadTimePush", ETCBase.DPadAxis.Two_Axis);
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x00014876 File Offset: 0x00012C76
	public void SetTimePushFourAxesCount()
	{
		ETCInput.SetDPadAxesCount("DPadTimePush", ETCBase.DPadAxis.Four_Axis);
	}
}
