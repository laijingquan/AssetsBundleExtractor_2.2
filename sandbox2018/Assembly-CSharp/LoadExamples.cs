using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200002E RID: 46
public class LoadExamples : MonoBehaviour
{
	// Token: 0x0600019F RID: 415 RVA: 0x00008DE4 File Offset: 0x000071E4
	public void LoadExample(string level)
	{
		SceneManager.LoadScene(level);
	}
}
