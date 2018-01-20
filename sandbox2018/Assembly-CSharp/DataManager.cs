using System;

// Token: 0x02000140 RID: 320
public class DataManager
{
	// Token: 0x0600081B RID: 2075 RVA: 0x00022940 File Offset: 0x00020D40
	public void LoadData()
	{
		if (!this._isLoaded)
		{
			this._isLoaded = true;
			this._dataConfig.Init();
			this._dataImageGroup.Init();
			this._dataTilesGroup.Init();
			this._dataDirectoryGroup.Init();
			this._dataLocalizationGroup.Init();
		}
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x0600081C RID: 2076 RVA: 0x00022996 File Offset: 0x00020D96
	public DataConfig dataConfig
	{
		get
		{
			return this._dataConfig;
		}
	}

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x0600081D RID: 2077 RVA: 0x0002299E File Offset: 0x00020D9E
	public DataImageGroup dataImageGroup
	{
		get
		{
			return this._dataImageGroup;
		}
	}

	// Token: 0x1700007B RID: 123
	// (get) Token: 0x0600081E RID: 2078 RVA: 0x000229A6 File Offset: 0x00020DA6
	public DataTilesGroup dataTilesGroup
	{
		get
		{
			return this._dataTilesGroup;
		}
	}

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x0600081F RID: 2079 RVA: 0x000229AE File Offset: 0x00020DAE
	public DataDirectoryGroup dataDirectoryGroup
	{
		get
		{
			return this._dataDirectoryGroup;
		}
	}

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06000820 RID: 2080 RVA: 0x000229B6 File Offset: 0x00020DB6
	public DataLocalizationGroup dataLocalizationGroup
	{
		get
		{
			return this._dataLocalizationGroup;
		}
	}

	// Token: 0x1700007E RID: 126
	// (get) Token: 0x06000821 RID: 2081 RVA: 0x000229BE File Offset: 0x00020DBE
	public static DataManager Instance
	{
		get
		{
			if (DataManager._instance == null)
			{
				DataManager._instance = new DataManager();
			}
			return DataManager._instance;
		}
	}

	// Token: 0x040004FB RID: 1275
	private bool _isLoaded;

	// Token: 0x040004FC RID: 1276
	private DataConfig _dataConfig = new DataConfig();

	// Token: 0x040004FD RID: 1277
	private DataImageGroup _dataImageGroup = new DataImageGroup();

	// Token: 0x040004FE RID: 1278
	private DataTilesGroup _dataTilesGroup = new DataTilesGroup();

	// Token: 0x040004FF RID: 1279
	private DataDirectoryGroup _dataDirectoryGroup = new DataDirectoryGroup();

	// Token: 0x04000500 RID: 1280
	private DataLocalizationGroup _dataLocalizationGroup = new DataLocalizationGroup();

	// Token: 0x04000501 RID: 1281
	private static DataManager _instance;
}
