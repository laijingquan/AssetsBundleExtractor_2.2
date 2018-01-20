using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x020001A9 RID: 425
public class UniformTexturedLine : MonoBehaviour
{
	// Token: 0x06000AED RID: 2797 RVA: 0x0002FAB4 File Offset: 0x0002DEB4
	private void Start()
	{
		new VectorLine("Line", new List<Vector2>
		{
			new Vector2(0f, (float)UnityEngine.Random.Range(0, Screen.height / 2)),
			new Vector2((float)(Screen.width - 1), (float)UnityEngine.Random.Range(0, Screen.height))
		}, this.lineTexture, this.lineWidth)
		{
			textureScale = this.textureScale
		}.Draw();
	}

	// Token: 0x04000655 RID: 1621
	public Texture lineTexture;

	// Token: 0x04000656 RID: 1622
	public float lineWidth = 8f;

	// Token: 0x04000657 RID: 1623
	public float textureScale = 1f;
}
