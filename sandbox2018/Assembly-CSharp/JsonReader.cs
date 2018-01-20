using System;
using LitJson;

// Token: 0x02000190 RID: 400
public class JsonReader
{
	// Token: 0x06000A66 RID: 2662 RVA: 0x0002CF04 File Offset: 0x0002B304
	public static float Float(JSONNode json, string key)
	{
		string text = json[key];
		if (text == null || text == string.Empty)
		{
			return 0f;
		}
		return float.Parse(text);
	}

	// Token: 0x06000A67 RID: 2663 RVA: 0x0002CF40 File Offset: 0x0002B340
	public static int Int(JSONNode json, string key)
	{
		string text = json[key];
		if (text == null || text == string.Empty)
		{
			return 0;
		}
		return int.Parse(text);
	}

	// Token: 0x06000A68 RID: 2664 RVA: 0x0002CF78 File Offset: 0x0002B378
	public static int Int(string json)
	{
		if (json == null || json == string.Empty)
		{
			return 0;
		}
		return int.Parse(json);
	}
}
