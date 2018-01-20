using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000145 RID: 325
public class DailyManager : MonoBehaviour
{
	// Token: 0x17000082 RID: 130
	// (get) Token: 0x0600082F RID: 2095 RVA: 0x00022E39 File Offset: 0x00021239
	public bool isExpired
	{
		get
		{
			return this._isExpired;
		}
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x00022E41 File Offset: 0x00021241
	public void Load()
	{
		if (!this._isLoad)
		{
			this._isLoad = true;
			this.CreateDailyImage();
			this.RefershDailyImage();
			this.RefershAllImage();
		}
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x00022E68 File Offset: 0x00021268
	public void RefershDailyImage()
	{
		if (!this._isExpired)
		{
			string todayStr = TimeHelper.GetTodayStr();
			List<string> list;
			this._dicDailyImage.TryGetValue(todayStr, out list);
			if (list != null)
			{
				DataCategory dataCategory = DataManager.Instance.dataDirectoryGroup.dataCategoryList[0];
				dataCategory.UpdateDailyCategory(list);
			}
			else
			{
				this._isExpired = true;
			}
		}
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x00022EC4 File Offset: 0x000212C4
	public void RefershAllImage()
	{
		int amount = DataManager.Instance.dataDirectoryGroup.amount;
		for (int i = 1; i < amount; i++)
		{
			DataCategory dataCategory = DataManager.Instance.dataDirectoryGroup.GetDataCategory(i);
			dataCategory.UpdateOtherCategory();
		}
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x00022F0C File Offset: 0x0002130C
	private void CreateDailyImage()
	{
		DataCategory dataCategory = DataManager.Instance.dataDirectoryGroup.dataCategoryList[0];
		foreach (string text in dataCategory.picList)
		{
			DataImage image = DataManager.Instance.dataImageGroup.GetImage(text);
			List<string> list;
			this._dicDailyImage.TryGetValue(image.date, out list);
			if (list == null)
			{
				list = new List<string>();
				this._dicDailyImage.Add(image.date, list);
			}
			list.Add(text);
			this._maxDateStr = TimeHelper.MaxDateDayStr(image.date, this._maxDateStr);
		}
		this._isExpired = TimeHelper.IsExpiredDay(this._maxDateStr);
	}

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x06000834 RID: 2100 RVA: 0x00022FF0 File Offset: 0x000213F0
	public static DailyManager Instance
	{
		get
		{
			if (DailyManager._instance == null)
			{
				GameObject gameObject = new GameObject("DailyManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				DailyManager._instance = gameObject.AddComponent<DailyManager>();
			}
			return DailyManager._instance;
		}
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0002302E File Offset: 0x0002142E
	private void Update()
	{
	}

	// Token: 0x04000516 RID: 1302
	private string _maxDateStr = "1970-1-1";

	// Token: 0x04000517 RID: 1303
	private Dictionary<string, List<string>> _dicDailyImage = new Dictionary<string, List<string>>();

	// Token: 0x04000518 RID: 1304
	public bool _isExpired;

	// Token: 0x04000519 RID: 1305
	private bool _isLoad;

	// Token: 0x0400051A RID: 1306
	private static DailyManager _instance;
}
