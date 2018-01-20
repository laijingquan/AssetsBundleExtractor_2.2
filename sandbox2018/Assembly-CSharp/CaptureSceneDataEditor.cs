using System;
using UnityEngine;

// Token: 0x020001A4 RID: 420
public class CaptureSceneDataEditor : MonoBehaviour
{
	// Token: 0x170000B1 RID: 177
	// (get) Token: 0x06000ADD RID: 2781 RVA: 0x0002F220 File Offset: 0x0002D620
	public static CaptureSceneDataEditor Instance
	{
		get
		{
			if (CaptureSceneDataEditor._instance == null)
			{
				GameObject gameObject = new GameObject("CaptureSceneDataEditor");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				CaptureSceneDataEditor._instance = gameObject.AddComponent<CaptureSceneDataEditor>();
			}
			return CaptureSceneDataEditor._instance;
		}
	}

	// Token: 0x06000ADE RID: 2782 RVA: 0x0002F25E File Offset: 0x0002D65E
	private void Start()
	{
	}

	// Token: 0x06000ADF RID: 2783 RVA: 0x0002F260 File Offset: 0x0002D660
	private void Update()
	{
	}

	// Token: 0x04000652 RID: 1618
	public int pictureIndex = 197;

	// Token: 0x04000653 RID: 1619
	public string pictureName = "0001";

	// Token: 0x04000654 RID: 1620
	private static CaptureSceneDataEditor _instance;
}
