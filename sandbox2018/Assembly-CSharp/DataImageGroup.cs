using System;
using System.Collections.Generic;
using LitJson;

// Token: 0x0200013D RID: 317
public class DataImageGroup
{
	// Token: 0x17000077 RID: 119
	// (get) Token: 0x0600080E RID: 2062 RVA: 0x00022402 File Offset: 0x00020802
	public Dictionary<string, DataImage> dicImages
	{
		get
		{
			return this._dicImages;
		}
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x0002240A File Offset: 0x0002080A
	public void Init()
	{
		this.Load("image");
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x00022418 File Offset: 0x00020818
	public DataImage GetImage(string TID)
	{
		DataImage result;
		DataManager.Instance.dataImageGroup.dicImages.TryGetValue(TID, out result);
		return result;
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x00022440 File Offset: 0x00020840
	private void Load(string name)
	{
		string fileName = "DataConfig/" + name + ".json";
		byte[] bytes = ResourceHelper.QueryFileContent(fileName);
		string aJSON = StringHelper.ReadFromBytes(bytes);
		JSONNode jsonnode = JSON.Parse(aJSON);
		int pictureAmount = DataManager.Instance.dataConfig.pictureAmount;
		for (int i = 0; i < pictureAmount; i++)
		{
			string text = string.Format("{0:D4}", i + 1);
			JSONNode json = jsonnode[text];
			DataImage dataImage = new DataImage();
			dataImage.Load(json);
			this._dicImages.Add(text, dataImage);
		}
	}

	// Token: 0x040004F8 RID: 1272
	private Dictionary<string, DataImage> _dicImages = new Dictionary<string, DataImage>();
}
