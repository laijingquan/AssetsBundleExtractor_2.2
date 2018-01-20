using System;
using System.Collections.Generic;
using LitJson;

// Token: 0x0200013B RID: 315
public class DataDirectoryGroup
{
	// Token: 0x17000075 RID: 117
	// (get) Token: 0x06000806 RID: 2054 RVA: 0x000222D1 File Offset: 0x000206D1
	public List<DataCategory> dataCategoryList
	{
		get
		{
			return this._dataCategoryList;
		}
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x06000807 RID: 2055 RVA: 0x000222D9 File Offset: 0x000206D9
	public int amount
	{
		get
		{
			return this._dataCategoryList.Count;
		}
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x000222E6 File Offset: 0x000206E6
	public DataCategory GetDataCategory(int index)
	{
		return this._dataCategoryList[index];
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x000222F4 File Offset: 0x000206F4
	public void Init()
	{
		this.Load("directory");
	}

	// Token: 0x0600080A RID: 2058 RVA: 0x00022304 File Offset: 0x00020704
	private void Load(string name)
	{
		string fileName = "DataConfig/" + name + ".json";
		byte[] bytes = ResourceHelper.QueryFileContent(fileName);
		string aJSON = StringHelper.ReadFromBytes(bytes);
		JSONNode jsonnode = JSON.Parse(aJSON);
		int count = jsonnode.Count;
		for (int i = 0; i < count; i++)
		{
			JSONNode json = jsonnode[i];
			DataCategory dataCategory = new DataCategory();
			dataCategory.Load(json);
			this._dataCategoryList.Add(dataCategory);
		}
	}

	// Token: 0x040004F2 RID: 1266
	private List<DataCategory> _dataCategoryList = new List<DataCategory>();
}
