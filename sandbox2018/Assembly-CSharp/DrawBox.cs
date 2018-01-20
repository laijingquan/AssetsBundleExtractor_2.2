using System;
using System.Collections;
using UnityEngine;
using Vectrosity;

// Token: 0x020001CE RID: 462
public class DrawBox : MonoBehaviour
{
	// Token: 0x06000B6E RID: 2926 RVA: 0x00034AB8 File Offset: 0x00032EB8
	private IEnumerator Start()
	{
		base.GetComponent<Renderer>().enabled = false;
		this.rigidbodies = (UnityEngine.Object.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[]);
		VectorLine.canvas.planeDistance = 0.5f;
		yield return null;
		VectorLine.SetCanvasCamera(this.vectorCam);
		yield break;
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x00034AD4 File Offset: 0x00032ED4
	private void Update()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 1f;
		Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);
		if (Input.GetMouseButtonDown(0) && this.canClick)
		{
			base.GetComponent<Renderer>().enabled = true;
			base.transform.position = position;
			this.mouseDown = true;
		}
		if (this.mouseDown)
		{
			base.transform.localScale = new Vector3(position.x - base.transform.position.x, position.y - base.transform.position.y, 1f);
		}
		if (Input.GetMouseButtonUp(0))
		{
			this.mouseDown = false;
			this.boxDrawn = true;
		}
		base.transform.Translate(-Vector3.up * Time.deltaTime * this.moveSpeed * Input.GetAxis("Vertical"));
		base.transform.Translate(Vector3.right * Time.deltaTime * this.moveSpeed * Input.GetAxis("Horizontal"));
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x00034C10 File Offset: 0x00033010
	private void OnGUI()
	{
		GUI.Box(new Rect(20f, 20f, 320f, 38f), "Draw a box by clicking and dragging with the mouse\nMove the drawn box with the arrow keys");
		Rect position = new Rect(20f, 62f, 60f, 30f);
		this.canClick = !position.Contains(Event.current.mousePosition);
		if (this.boxDrawn && GUI.Button(position, "Boom!"))
		{
			foreach (Rigidbody rigidbody in this.rigidbodies)
			{
				rigidbody.AddExplosionForce(this.explodePower, new Vector3(0f, -6.5f, -1.5f), 20f, 0f, ForceMode.VelocityChange);
			}
		}
	}

	// Token: 0x0400071F RID: 1823
	public float moveSpeed = 1f;

	// Token: 0x04000720 RID: 1824
	public float explodePower = 20f;

	// Token: 0x04000721 RID: 1825
	public Camera vectorCam;

	// Token: 0x04000722 RID: 1826
	private bool mouseDown;

	// Token: 0x04000723 RID: 1827
	private Rigidbody[] rigidbodies;

	// Token: 0x04000724 RID: 1828
	private bool canClick = true;

	// Token: 0x04000725 RID: 1829
	private bool boxDrawn;
}
