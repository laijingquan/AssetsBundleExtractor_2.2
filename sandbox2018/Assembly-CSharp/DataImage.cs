using System;
using LitJson;

// Token: 0x0200013C RID: 316
public class DataImage
{
	// Token: 0x0600080C RID: 2060 RVA: 0x00022388 File Offset: 0x00020788
	public void Load(JSONNode json)
	{
		this.price = JsonReader.Int(json, "price");
		this.canvasLength = JsonReader.Int(json, "canvasLength");
		this.date = json["date"];
		this.isDailyNew = TimeHelper.IsNewDaily(this.date);
		this.isCanShow = TimeHelper.IsLessThanToday(this.date);
	}

	// Token: 0x040004F3 RID: 1267
	public int price;

	// Token: 0x040004F4 RID: 1268
	public int canvasLength;

	// Token: 0x040004F5 RID: 1269
	public string date;

	// Token: 0x040004F6 RID: 1270
	public bool isDailyNew;

	// Token: 0x040004F7 RID: 1271
	public bool isCanShow;
}
