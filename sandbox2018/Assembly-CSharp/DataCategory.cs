using System;
using System.Collections.Generic;
using LitJson;

// Token: 0x02000139 RID: 313
public class DataCategory
{
	// Token: 0x17000073 RID: 115
	// (get) Token: 0x060007FD RID: 2045 RVA: 0x00022000 File Offset: 0x00020400
	public List<string> picList
	{
		get
		{
			return this._picList;
		}
	}

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x060007FE RID: 2046 RVA: 0x00022008 File Offset: 0x00020408
	public int amount
	{
		get
		{
			return this._picList.Count;
		}
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x00022018 File Offset: 0x00020418
	public void Load(JSONNode json)
	{
		this.title = json["title"];
		JSONNode jsonnode = json["pic"];
		int count = jsonnode.Count;
		for (int i = 0; i < count; i++)
		{
			this._picList.Add(jsonnode[i]);
		}
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x00022078 File Offset: 0x00020478
	public void UpdateDailyCategory(List<string> categoryList)
	{
		this._picList.Clear();
		foreach (string item in categoryList)
		{
			this._picList.Add(item);
		}
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x000220E0 File Offset: 0x000204E0
	public void UpdateOtherCategory()
	{
		int count = this._picList.Count;
		for (int i = count - 1; i >= 0; i--)
		{
			string text = this._picList[i];
			DataImage image = DataManager.Instance.dataImageGroup.GetImage(text);
			if (!image.isCanShow)
			{
				this._picList.Remove(text);
			}
		}
	}

	// Token: 0x040004E5 RID: 1253
	public string title;

	// Token: 0x040004E6 RID: 1254
	private List<string> _picList = new List<string>();
}
