using System;
using LitJson;
using UnityEngine;

// Token: 0x0200013E RID: 318
public class DataLocalization
{
	// Token: 0x06000813 RID: 2067 RVA: 0x000224E1 File Offset: 0x000208E1
	public void Load(JSONNode json)
	{
		this._json = json;
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x000224EC File Offset: 0x000208EC
	public string GetText()
	{
		SystemLanguage language = LanguageManager.Instance.language;
		if (language == SystemLanguage.French)
		{
			return this._json["French"];
		}
		if (language == SystemLanguage.German)
		{
			return this._json["German"];
		}
		if (language == SystemLanguage.Japanese)
		{
			return this._json["Japanese"];
		}
		if (language == SystemLanguage.Korean)
		{
			return this._json["Korean"];
		}
		if (language != SystemLanguage.English)
		{
			return this._json["English"];
		}
		return this._json["English"];
	}

	// Token: 0x040004F9 RID: 1273
	private JSONNode _json;
}
