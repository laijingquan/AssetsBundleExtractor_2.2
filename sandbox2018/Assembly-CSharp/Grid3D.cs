using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001B7 RID: 439
public class Grid3D : MonoBehaviour
{
	// Token: 0x06000B1B RID: 2843 RVA: 0x00031F4C File Offset: 0x0003034C
	private void Start()
	{
		this.numberOfLines = Mathf.Clamp(this.numberOfLines, 2, 8190);
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < this.numberOfLines; i++)
		{
			list.Add(new Vector3((float)i * this.distanceBetweenLines, 0f, 0f));
			list.Add(new Vector3((float)i * this.distanceBetweenLines, 0f, (float)(this.numberOfLines - 1) * this.distanceBetweenLines));
		}
		for (int j = 0; j < this.numberOfLines; j++)
		{
			list.Add(new Vector3(0f, 0f, (float)j * this.distanceBetweenLines));
			list.Add(new Vector3((float)(this.numberOfLines - 1) * this.distanceBetweenLines, 0f, (float)j * this.distanceBetweenLines));
		}
		VectorLine vectorLine = new VectorLine("Grid", list, this.lineWidth);
		vectorLine.Draw3DAuto();
		Vector3 position = base.transform.position;
		position.x = (float)(this.numberOfLines - 1) * this.distanceBetweenLines / 2f;
		base.transform.position = position;
	}

	// Token: 0x06000B1C RID: 2844 RVA: 0x00032084 File Offset: 0x00030484
	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			base.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * this.rotateSpeed);
			base.transform.Translate(Vector3.up * Input.GetAxis("Vertical") * Time.deltaTime * this.moveSpeed);
		}
		else
		{
			base.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * this.moveSpeed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * this.moveSpeed));
		}
	}

	// Token: 0x06000B1D RID: 2845 RVA: 0x0003215F File Offset: 0x0003055F
	private void OnGUI()
	{
		GUILayout.Label(" Use arrow keys to move camera. Hold Shift + arrow up/down to move vertically. Hold Shift + arrow left/right to rotate.", new GUILayoutOption[0]);
	}

	// Token: 0x040006A8 RID: 1704
	public int numberOfLines = 20;

	// Token: 0x040006A9 RID: 1705
	public float distanceBetweenLines = 2f;

	// Token: 0x040006AA RID: 1706
	public float moveSpeed = 8f;

	// Token: 0x040006AB RID: 1707
	public float rotateSpeed = 70f;

	// Token: 0x040006AC RID: 1708
	public float lineWidth = 2f;
}
