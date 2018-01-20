using System;
using UnityEngine;
using Vectrosity;

// Token: 0x020001CF RID: 463
public class VectorObject : MonoBehaviour
{
	// Token: 0x06000B72 RID: 2930 RVA: 0x00034DC0 File Offset: 0x000331C0
	private void Start()
	{
		VectorLine vectorLine = new VectorLine("Shape", XrayLineData.use.shapePoints[(int)this.shape], XrayLineData.use.lineTexture, XrayLineData.use.lineWidth);
		vectorLine.color = Color.green;
		VectorManager.ObjectSetup(base.gameObject, vectorLine, Visibility.Always, Brightness.None);
	}

	// Token: 0x04000726 RID: 1830
	public VectorObject.Shape shape;

	// Token: 0x020001D0 RID: 464
	public enum Shape
	{
		// Token: 0x04000728 RID: 1832
		Cube,
		// Token: 0x04000729 RID: 1833
		Sphere
	}
}
