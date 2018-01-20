using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200014E RID: 334
public class PlayerManager : MonoBehaviour
{
	// Token: 0x0600086F RID: 2159 RVA: 0x000243F4 File Offset: 0x000227F4
	public bool IsCanShowRate()
	{
		if (!PlayerManager.Instance.GetRate())
		{
			long lastRateTime = PlayerManager.Instance.GetLastRateTime();
			long currentRealTimestamp = TimeHelper.GetCurrentRealTimestamp();
			if (currentRealTimestamp - lastRateTime >= 86400000L)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000870 RID: 2160 RVA: 0x00024434 File Offset: 0x00022834
	public void SetRate(bool b)
	{
		string key = "IS_RATE";
		if (b)
		{
			PlayerPrefs.SetInt(key, 1);
		}
		else
		{
			PlayerPrefs.SetInt(key, 0);
		}
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x00024460 File Offset: 0x00022860
	public bool GetRate()
	{
		string key = "IS_RATE";
		int @int = PlayerPrefs.GetInt(key, 0);
		return @int == 1;
	}

	// Token: 0x06000872 RID: 2162 RVA: 0x00024488 File Offset: 0x00022888
	public long GetLastRateTime()
	{
		string key = "LAST_RATE_TIME";
		string @string = PlayerPrefs.GetString(key, string.Empty);
		if (@string.CompareTo(string.Empty) == 0)
		{
			return 0L;
		}
		return long.Parse(@string);
	}

	// Token: 0x06000873 RID: 2163 RVA: 0x000244C0 File Offset: 0x000228C0
	public void SetLastRateTime(long time)
	{
		string key = "LAST_RATE_TIME";
		PlayerPrefs.SetString(key, time + string.Empty);
	}

	// Token: 0x06000874 RID: 2164 RVA: 0x000244EC File Offset: 0x000228EC
	public void SaveGameTime()
	{
		long currentRealTimestamp = TimeHelper.GetCurrentRealTimestamp();
		float num = Mathf.Abs((float)(currentRealTimestamp - this._gameStartTime)) / 1000f;
		num = Mathf.Max(0f, num);
		this.SetPalyerGameTime(num);
	}

	// Token: 0x06000875 RID: 2165 RVA: 0x00024528 File Offset: 0x00022928
	public void SetStartGameTime()
	{
		this._gameStartTime = TimeHelper.GetCurrentRealTimestamp();
	}

	// Token: 0x06000876 RID: 2166 RVA: 0x00024538 File Offset: 0x00022938
	public float GetPalyerGameTime()
	{
		string key = "PLAYER_GAME_TIME";
		return PlayerPrefs.GetFloat(key, 0f);
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x00024558 File Offset: 0x00022958
	private void SetPalyerGameTime(float time)
	{
		string key = "PLAYER_GAME_TIME";
		float num = PlayerPrefs.GetFloat(key, 0f);
		num += time;
		PlayerPrefs.SetFloat(key, num);
		Debug.Log(string.Concat(new object[]
		{
			"Game sum Time ",
			num,
			"game time ",
			time
		}));
	}

	// Token: 0x06000878 RID: 2168 RVA: 0x000245B4 File Offset: 0x000229B4
	public long GetSubscriptionTime()
	{
		string key = "ORDER_TIME";
		string @string = PlayerPrefs.GetString(key, string.Empty);
		if (@string.CompareTo(string.Empty) == 0)
		{
			return 0L;
		}
		return long.Parse(@string);
	}

	// Token: 0x06000879 RID: 2169 RVA: 0x000245EC File Offset: 0x000229EC
	public void SetSubscriptionTime(long time)
	{
		string key = "ORDER_TIME";
		PlayerPrefs.SetString(key, time + string.Empty);
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x00024618 File Offset: 0x00022A18
	public void SetOnePictureFinish(string TID, bool b)
	{
		string key = "PICTURE_FINISH_" + TID;
		if (b)
		{
			PlayerPrefs.SetInt(key, 1);
		}
		else
		{
			PlayerPrefs.SetInt(key, 0);
		}
	}

	// Token: 0x0600087B RID: 2171 RVA: 0x0002464C File Offset: 0x00022A4C
	public bool GetOnePictureFinish(string TID)
	{
		string key = "PICTURE_FINISH_" + TID;
		int @int = PlayerPrefs.GetInt(key, 0);
		return @int == 1;
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x00024678 File Offset: 0x00022A78
	public void SetVipType(int nVip)
	{
		string key = "VIP_TYPE";
		PlayerPrefs.SetInt(key, nVip);
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x00024694 File Offset: 0x00022A94
	public int GetVipType()
	{
		string key = "VIP_TYPE";
		return PlayerPrefs.GetInt(key, 0);
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x000246B0 File Offset: 0x00022AB0
	public void SetVip(int nVip)
	{
		string key = "VIP";
		PlayerPrefs.SetInt(key, nVip);
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x000246CC File Offset: 0x00022ACC
	public bool GetVip()
	{
		string key = "VIP";
		int @int = PlayerPrefs.GetInt(key, 0);
		return @int == 1;
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x000246F4 File Offset: 0x00022AF4
	public void SetLifeVip(int nLifeVip)
	{
		string key = "LIFE_VIP";
		PlayerPrefs.SetInt(key, nLifeVip);
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x00024710 File Offset: 0x00022B10
	public bool GetLifeVip()
	{
		string key = "LIFE_VIP";
		int @int = PlayerPrefs.GetInt(key, 0);
		return @int == 1;
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x00024738 File Offset: 0x00022B38
	public bool IsShowBanner()
	{
		if (this.GetVip())
		{
			return false;
		}
		if (this.GetLifeVip())
		{
			return false;
		}
		float palyerGameTime = this.GetPalyerGameTime();
		return palyerGameTime >= 1800f;
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x00024774 File Offset: 0x00022B74
	public void AddMyPictureList(string TID)
	{
		string key = "MY_PICTURE_LIST";
		string text = TID;
		List<string> myPictureList = this.GetMyPictureList();
		int count = myPictureList.Count;
		if (count > 0)
		{
			if (myPictureList.Contains(TID))
			{
				myPictureList.Remove(TID);
			}
			foreach (string str in myPictureList)
			{
				text = text + ";" + str;
			}
		}
		PlayerPrefs.SetString(key, text);
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x0002480C File Offset: 0x00022C0C
	public List<string> GetMyPictureList()
	{
		string key = "MY_PICTURE_LIST";
		List<string> list = new List<string>();
		string @string = PlayerPrefs.GetString(key);
		if (@string.CompareTo(string.Empty) == 0)
		{
			return list;
		}
		string[] array = @string.Split(new char[]
		{
			';'
		});
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			list.Add(array[i]);
		}
		return list;
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x00024878 File Offset: 0x00022C78
	public void SetFillColor(string TID, List<PlayerManager.TileFillColor> fillColorList)
	{
		string key = "FILLCOLOR_" + TID;
		int count = fillColorList.Count;
		int num = 0;
		string text = string.Empty;
		foreach (PlayerManager.TileFillColor tileFillColor in fillColorList)
		{
			num++;
			if (num < count)
			{
				text = text + tileFillColor.str + ";";
			}
			else
			{
				text += tileFillColor.str;
			}
		}
		PlayerPrefs.SetString(key, text);
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x00024920 File Offset: 0x00022D20
	public List<PlayerManager.TileFillColor> GetFillColor(string TID)
	{
		string key = "FILLCOLOR_" + TID;
		List<PlayerManager.TileFillColor> list = new List<PlayerManager.TileFillColor>();
		string @string = PlayerPrefs.GetString(key);
		if (@string.CompareTo(string.Empty) == 0)
		{
			return list;
		}
		string[] array = @string.Split(new char[]
		{
			';'
		});
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			string[] array2 = array[i].Split(new char[]
			{
				','
			});
			int i2 = int.Parse(array2[0]);
			int j = int.Parse(array2[1]);
			int color = int.Parse(array2[2]);
			int isTouchRight = int.Parse(array2[3]);
			int isEarser = int.Parse(array2[4]);
			PlayerManager.TileFillColor item = PlayerManager.TileFillColor.Create(i2, j, color, isTouchRight, isEarser);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x000249F0 File Offset: 0x00022DF0
	public void SaveLevelData(string TID)
	{
		string key = "LEVEL_" + TID;
		Dictionary<string, DataTiles> dicDataTiles = DataManager.Instance.dataTilesGroup.dicDataTiles;
		DataTiles dataTiles;
		dicDataTiles.TryGetValue(TID, out dataTiles);
		string text = string.Empty;
		if (dataTiles != null)
		{
			int count = dataTiles.dataTileDic.Values.Count;
			int num = 0;
			foreach (DataTiles.DataTile dataTile in dataTiles.dataTileDic.Values)
			{
				num++;
				int num2 = 0;
				if (dataTile.isTouchRight)
				{
					num2 = 1;
				}
				if (dataTile.isTouchWrong)
				{
					num2 = 2;
				}
				if (num < count)
				{
					string text2 = text;
					text = string.Concat(new object[]
					{
						text2,
						dataTile.indexX,
						",",
						dataTile.indexY,
						",",
						num2,
						",",
						dataTile.wrongColorIndex,
						";"
					});
				}
				else
				{
					string text2 = text;
					text = string.Concat(new object[]
					{
						text2,
						dataTile.indexX,
						",",
						dataTile.indexY,
						",",
						num2,
						",",
						dataTile.wrongColorIndex
					});
				}
			}
			PlayerPrefs.SetString(key, text);
		}
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x00024BAC File Offset: 0x00022FAC
	public Dictionary<string, DataTiles.DataTile> GetLevelData(string TID)
	{
		Dictionary<string, DataTiles.DataTile> dictionary = new Dictionary<string, DataTiles.DataTile>();
		string key = "LEVEL_" + TID;
		string @string = PlayerPrefs.GetString(key);
		if (@string.CompareTo(string.Empty) == 0)
		{
			return dictionary;
		}
		string[] array = @string.Split(new char[]
		{
			';'
		});
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			string[] array2 = array[i].Split(new char[]
			{
				','
			});
			DataTiles.DataTile dataTile = new DataTiles.DataTile();
			if (array2[2].CompareTo("1") == 0)
			{
				dataTile.isTouchRight = true;
				dataTile.isTouched = true;
			}
			else if (array2[2].CompareTo("2") == 0)
			{
				dataTile.isTouchWrong = true;
				dataTile.isTouched = true;
			}
			dataTile.wrongColorIndex = int.Parse(array2[3]);
			string key2 = array2[0] + "_" + array2[1];
			dictionary.Add(key2, dataTile);
		}
		return dictionary;
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x00024CA9 File Offset: 0x000230A9
	public void DeleteAllPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x00024CB0 File Offset: 0x000230B0
	public void OnDestroy()
	{
		this.SaveGameTime();
	}

	// Token: 0x17000098 RID: 152
	// (get) Token: 0x0600088B RID: 2187 RVA: 0x00024CB8 File Offset: 0x000230B8
	public static PlayerManager Instance
	{
		get
		{
			if (PlayerManager._instance == null)
			{
				GameObject gameObject = new GameObject("PlayerManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				PlayerManager._instance = gameObject.AddComponent<PlayerManager>();
			}
			return PlayerManager._instance;
		}
	}

	// Token: 0x04000541 RID: 1345
	private long _gameStartTime;

	// Token: 0x04000542 RID: 1346
	private static PlayerManager _instance;

	// Token: 0x0200014F RID: 335
	public class TileFillColor
	{
		// Token: 0x0600088D RID: 2189 RVA: 0x00024D00 File Offset: 0x00023100
		public static PlayerManager.TileFillColor Create(int i, int j, int color, int isTouchRight, int isEarser)
		{
			return new PlayerManager.TileFillColor
			{
				indexX = i,
				indexY = j,
				colorIndex = color,
				isTouchRight = isTouchRight,
				isEarser = isEarser,
				str = string.Concat(new object[]
				{
					i,
					",",
					j,
					",",
					color,
					",",
					isTouchRight,
					",",
					isEarser
				})
			};
		}

		// Token: 0x04000543 RID: 1347
		public int indexX;

		// Token: 0x04000544 RID: 1348
		public int indexY;

		// Token: 0x04000545 RID: 1349
		public int colorIndex;

		// Token: 0x04000546 RID: 1350
		public string str;

		// Token: 0x04000547 RID: 1351
		public int isTouchRight;

		// Token: 0x04000548 RID: 1352
		public int isEarser;
	}
}
