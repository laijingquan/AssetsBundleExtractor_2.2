using System;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

// Token: 0x020001A6 RID: 422
public class TrimDataEditor : MonoBehaviour
{
	// Token: 0x06000AE4 RID: 2788 RVA: 0x0002F308 File Offset: 0x0002D708
	private void Start()
	{
		foreach (string name in new List<string>
		{
			"0195",
			"0175",
			"0186",
			"0182"
		})
		{
			this.TrimDataRemoveWhite(name);
		}
	}

	// Token: 0x06000AE5 RID: 2789 RVA: 0x0002F394 File Offset: 0x0002D794
	private void TrimDataRemoveWhite(string name)
	{
		string fileName = "DataConfig/pic/" + name + ".json";
		byte[] bytes = ResourceHelper.QueryFileContent(fileName);
		string aJSON = StringHelper.ReadFromBytes(bytes);
		JSONNode jsonnode = JSON.Parse(aJSON);
		JSONNode jsonnode2 = jsonnode["colorRank"];
		Dictionary<string, Color> dictionary = new Dictionary<string, Color>();
		int count = jsonnode2.Count;
		for (int i = 1; i <= count; i++)
		{
			string text = i + string.Empty;
			JSONNode jsonnode3 = jsonnode2[text];
			dictionary.Add(text, new Color
			{
				r = (float)jsonnode3[0].AsInt,
				g = (float)jsonnode3[1].AsInt,
				b = (float)jsonnode3[2].AsInt
			});
		}
		string text2 = "0";
		foreach (KeyValuePair<string, Color> keyValuePair in dictionary)
		{
			if (Mathf.Abs(keyValuePair.Value.r - 255f) <= 2f && Mathf.Abs(keyValuePair.Value.g - 255f) <= 2f && Mathf.Abs(keyValuePair.Value.b - 255f) <= 2f)
			{
				text2 = keyValuePair.Key;
				Debug.Log("白色 index " + text2);
				break;
			}
		}
		List<Color> list = new List<Color>();
		if (text2.CompareTo("0") != 0)
		{
			Debug.Log("Trim Data " + name);
			dictionary.Remove(text2);
			JSONNode jsonnode4 = jsonnode["dataList"];
			int count2 = jsonnode4.Count;
			for (int j = 0; j < count2; j++)
			{
				JSONNode jsonnode5 = jsonnode4[j];
				if (text2.CompareTo(jsonnode5[2]) != 0)
				{
					list.Add(new Color
					{
						r = (float)jsonnode5[0].AsInt,
						g = (float)jsonnode5[1].AsInt,
						b = (float)int.Parse(jsonnode5[2])
					});
				}
			}
			this.WriteTrimPic(name, dictionary, list);
		}
	}

	// Token: 0x06000AE6 RID: 2790 RVA: 0x0002F62C File Offset: 0x0002DA2C
	private void WriteTrimPic(string name, Dictionary<string, Color> colorRankList, List<Color> tileList)
	{
		string file_name = name + ".json";
		string file_path = Application.dataPath + "/TrimDataConfig";
		string text = "{ \"colorRank\": {";
		int num = 0;
		foreach (KeyValuePair<string, Color> keyValuePair in colorRankList)
		{
			string str;
			if (num < colorRankList.Count - 1)
			{
				str = string.Concat(new object[]
				{
					"\"",
					keyValuePair.Key,
					"\":[",
					keyValuePair.Value.r,
					",",
					keyValuePair.Value.g,
					",",
					keyValuePair.Value.b,
					"],"
				});
			}
			else
			{
				str = string.Concat(new object[]
				{
					"\"",
					keyValuePair.Key,
					"\":[",
					keyValuePair.Value.r,
					",",
					keyValuePair.Value.g,
					",",
					keyValuePair.Value.b,
					"]"
				});
			}
			text += str;
			num++;
		}
		text += "}";
		text += ",";
		text += "\n";
		text += "\"dataList\": [";
		num = 0;
		foreach (Color color in tileList)
		{
			string str2;
			if (num < tileList.Count - 1)
			{
				str2 = string.Concat(new object[]
				{
					"[",
					color.r,
					",",
					color.g,
					",\"",
					color.b,
					"\"],"
				});
			}
			else
			{
				str2 = string.Concat(new object[]
				{
					"[",
					color.r,
					",",
					color.g,
					",\"",
					color.b,
					"\"]"
				});
			}
			text += str2;
			num++;
		}
		text += "]";
		text += "}";
		this.WriteFileByLine(file_path, file_name, text);
	}

	// Token: 0x06000AE7 RID: 2791 RVA: 0x0002F954 File Offset: 0x0002DD54
	private void WriteFileByLine(string file_path, string file_name, string str_info)
	{
		if (File.Exists(file_path + "//" + file_name))
		{
			File.Delete(file_path + "//" + file_name);
		}
		StreamWriter streamWriter = File.CreateText(file_path + "//" + file_name);
		streamWriter.WriteLine(str_info);
		streamWriter.Close();
		streamWriter.Dispose();
		Debug.Log("Trim Pic Data Success " + file_path + "//" + file_name);
	}
}
