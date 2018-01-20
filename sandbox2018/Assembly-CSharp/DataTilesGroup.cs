using System;
using System.Collections.Generic;
using LitJson;

// Token: 0x02000144 RID: 324
public class DataTilesGroup
{
	// Token: 0x17000081 RID: 129
	// (get) Token: 0x0600082B RID: 2091 RVA: 0x00022D70 File Offset: 0x00021170
	public Dictionary<string, DataTiles> dicDataTiles
	{
		get
		{
			return this._dicDataTiles;
		}
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x00022D78 File Offset: 0x00021178
	public void Init()
	{
		int pictureAmount = DataManager.Instance.dataConfig.pictureAmount;
		for (int i = 0; i < pictureAmount; i++)
		{
			string name = string.Format("{0:D4}", i + 1);
			this.Load(name);
		}
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x00022DC4 File Offset: 0x000211C4
	private void Load(string name)
	{
		string fileName = "DataConfig/pic/" + name + ".json";
		byte[] bytes = ResourceHelper.QueryFileContent(fileName);
		string aJSON = StringHelper.ReadFromBytes(bytes);
		JSONNode json = JSON.Parse(aJSON);
		DataTiles dataTiles = new DataTiles();
		dataTiles.Load(name, json);
		this._dicDataTiles.Add(dataTiles.TID, dataTiles);
	}

	// Token: 0x04000515 RID: 1301
	private Dictionary<string, DataTiles> _dicDataTiles = new Dictionary<string, DataTiles>();
}
