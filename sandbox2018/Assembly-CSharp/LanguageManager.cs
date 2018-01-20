using System;
using UnityEngine;

// Token: 0x02000149 RID: 329
public class LanguageManager : MonoBehaviour
{
	// Token: 0x1700008D RID: 141
	// (get) Token: 0x0600084C RID: 2124 RVA: 0x0002339C File Offset: 0x0002179C
	public SystemLanguage language
	{
		get
		{
			return this._language;
		}
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000233A4 File Offset: 0x000217A4
	public void Init()
	{
		this._language = Application.systemLanguage;
	}

	// Token: 0x1700008E RID: 142
	// (get) Token: 0x0600084E RID: 2126 RVA: 0x000233B4 File Offset: 0x000217B4
	public static LanguageManager Instance
	{
		get
		{
			if (LanguageManager._instance == null)
			{
				GameObject gameObject = new GameObject("LanguageManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				LanguageManager._instance = gameObject.AddComponent<LanguageManager>();
			}
			return LanguageManager._instance;
		}
	}

	// Token: 0x04000525 RID: 1317
	private SystemLanguage _language = SystemLanguage.English;

	// Token: 0x04000526 RID: 1318
	private static LanguageManager _instance;
}
