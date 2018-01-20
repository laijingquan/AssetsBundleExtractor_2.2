using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
public class AxisXUi : MonoBehaviour
{
	// Token: 0x0600047B RID: 1147 RVA: 0x00014DB9 File Offset: 0x000131B9
	public void ActivateAxisX(bool value)
	{
		ETCInput.SetAxisEnabled("Horizontal", value);
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x00014DC6 File Offset: 0x000131C6
	public void InvertedAxisX(bool value)
	{
		ETCInput.SetAxisInverted("Horizontal", value);
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x00014DD3 File Offset: 0x000131D3
	public void DeadAxisX(float value)
	{
		ETCInput.SetAxisDeadValue("Horizontal", value);
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x00014DE0 File Offset: 0x000131E0
	public void SpeedAxisX(float value)
	{
		ETCInput.SetAxisSensitivity("Horizontal", value);
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x00014DED File Offset: 0x000131ED
	public void IsInertiaX(bool value)
	{
		ETCInput.SetAxisInertia("Horizontal", value);
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x00014DFA File Offset: 0x000131FA
	public void InertiaSpeedX(float value)
	{
		ETCInput.SetAxisInertiaSpeed("Horizontal", value);
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x00014E07 File Offset: 0x00013207
	public void ActivateAxisY(bool value)
	{
		ETCInput.SetAxisEnabled("Vertical", value);
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x00014E14 File Offset: 0x00013214
	public void InvertedAxisY(bool value)
	{
		ETCInput.SetAxisInverted("Vertical", value);
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x00014E21 File Offset: 0x00013221
	public void DeadAxisY(float value)
	{
		ETCInput.SetAxisDeadValue("Vertical", value);
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x00014E2E File Offset: 0x0001322E
	public void SpeedAxisY(float value)
	{
		ETCInput.SetAxisSensitivity("Vertical", value);
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x00014E3B File Offset: 0x0001323B
	public void IsInertiaY(bool value)
	{
		ETCInput.SetAxisInertia("Vertical", value);
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x00014E48 File Offset: 0x00013248
	public void InertiaSpeedY(float value)
	{
		ETCInput.SetAxisInertiaSpeed("Vertical", value);
	}
}
