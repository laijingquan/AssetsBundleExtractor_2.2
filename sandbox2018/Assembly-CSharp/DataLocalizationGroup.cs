using System;
using System.Collections.Generic;
using LitJson;

// Token: 0x0200013F RID: 319
public class DataLocalizationGroup
{
	// Token: 0x17000078 RID: 120
	// (get) Token: 0x06000816 RID: 2070 RVA: 0x000225C7 File Offset: 0x000209C7
	public Dictionary<string, DataLocalization> dicDataLocalization
	{
		get
		{
			return this._dicDataLocalization;
		}
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x000225CF File Offset: 0x000209CF
	public void Init()
	{
		this.Load("localizationtext");
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x000225DC File Offset: 0x000209DC
	public string GetText(string key)
	{
		return this._dicDataLocalization[key].GetText();
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x000225F0 File Offset: 0x000209F0
	private void Load(string name)
	{
		string fileName = "DataConfig/" + name + ".json";
		byte[] bytes = ResourceHelper.QueryFileContent(fileName);
		string aJSON = StringHelper.ReadFromBytes(bytes);
		JSONNode jsonnode = JSON.Parse(aJSON);
		DataLocalization dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["zoom_in"]);
		this._dicDataLocalization.Add("zoom_in", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["zoom_out"]);
		this._dicDataLocalization.Add("zoom_out", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["select_color"]);
		this._dicDataLocalization.Add("select_color", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["long_press"]);
		this._dicDataLocalization.Add("long_press", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["start"]);
		this._dicDataLocalization.Add("start", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["view_all"]);
		this._dicDataLocalization.Add("view_all", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["CARTOON"]);
		this._dicDataLocalization.Add("CARTOON", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["ANIMAL"]);
		this._dicDataLocalization.Add("ANIMAL", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["KID"]);
		this._dicDataLocalization.Add("KID", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["PLANT"]);
		this._dicDataLocalization.Add("PLANT", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["FOOD"]);
		this._dicDataLocalization.Add("FOOD", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["HOUSEHOLD"]);
		this._dicDataLocalization.Add("HOUSEHOLD", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["OTHERS"]);
		this._dicDataLocalization.Add("OTHERS", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["DAILY"]);
		this._dicDataLocalization.Add("DAILY", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["next_release"]);
		this._dicDataLocalization.Add("next_release", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["my_work"]);
		this._dicDataLocalization.Add("my_work", dataLocalization);
		dataLocalization = new DataLocalization();
		dataLocalization.Load(jsonnode["save_successfully"]);
		this._dicDataLocalization.Add("save_successfully", dataLocalization);
	}

	// Token: 0x040004FA RID: 1274
	private Dictionary<string, DataLocalization> _dicDataLocalization = new Dictionary<string, DataLocalization>();
}
