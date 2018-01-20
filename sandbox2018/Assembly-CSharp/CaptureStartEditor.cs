using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020001A5 RID: 421
public class CaptureStartEditor : MonoBehaviour
{
	// Token: 0x06000AE1 RID: 2785 RVA: 0x0002F26C File Offset: 0x0002D66C
	private void Start()
	{
		DataManager.Instance.LoadData();
		int pictureIndex = CaptureSceneDataEditor.Instance.pictureIndex;
		int pictureAmount = DataManager.Instance.dataConfig.pictureAmount;
		if (pictureAmount == 0)
		{
			Debug.Log("Capture Thumb Start");
		}
		if (pictureIndex < pictureAmount)
		{
			CaptureSceneDataEditor.Instance.pictureIndex++;
			CaptureSceneDataEditor.Instance.pictureName = string.Format("{0:D4}", pictureIndex + 1);
			SceneManager.LoadScene("CaptureMainEditor");
		}
		else
		{
			Debug.Log("Capture Thumb Finish");
		}
	}

	// Token: 0x06000AE2 RID: 2786 RVA: 0x0002F2FC File Offset: 0x0002D6FC
	private void Update()
	{
	}
}
