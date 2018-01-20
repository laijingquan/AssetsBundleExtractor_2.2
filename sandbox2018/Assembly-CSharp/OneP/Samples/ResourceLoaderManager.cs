using System;
using System.Collections.Generic;
using UnityEngine;

namespace OneP.Samples
{
	// Token: 0x0200012B RID: 299
	public class ResourceLoaderManager : Singleton<ResourceLoaderManager>
	{
		// Token: 0x060007B3 RID: 1971 RVA: 0x00020321 File Offset: 0x0001E721
		public Dictionary<string, WWW> GetLoader()
		{
			return this.dicResourceLoader;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0002032C File Offset: 0x0001E72C
		public bool PushToQueue(string url, Action<ExtraInfoDownload> actionCallback)
		{
			List<Action<ExtraInfoDownload>> list = null;
			this.processQueue.TryGetValue(url, out list);
			if (list == null)
			{
				list = new List<Action<ExtraInfoDownload>>();
				if (actionCallback != null)
				{
					list.Add(actionCallback);
				}
				this.processQueue[url] = list;
				return true;
			}
			if (actionCallback != null)
			{
				list.Add(actionCallback);
			}
			return false;
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00020380 File Offset: 0x0001E780
		public void DispathQueue(string url, ExtraInfoDownload info)
		{
			List<Action<ExtraInfoDownload>> list = null;
			this.processQueue.TryGetValue(url, out list);
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] != null)
					{
						list[i](info);
					}
				}
				list.Clear();
				this.processQueue.Remove(url);
			}
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x000203E8 File Offset: 0x0001E7E8
		public Sprite GetMemorySprite(string url)
		{
			Sprite result = null;
			this.dicSpriteLoader.TryGetValue(url, out result);
			return result;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00020408 File Offset: 0x0001E808
		public void DownloadSprite(string url, Action<Sprite> callback = null)
		{
			if (string.IsNullOrEmpty(url))
			{
				return;
			}
			if (this.dicSpriteLoader.ContainsKey(url))
			{
				callback(this.dicSpriteLoader[url]);
			}
			else
			{
				this.DownLoadTexture(url, delegate(Texture2D texture)
				{
					if (texture != null)
					{
						Rect rect;
						if (texture.width > texture.height)
						{
							rect = new Rect((float)(texture.width / 2 - texture.height / 2), 0f, (float)texture.height, (float)texture.height);
						}
						else
						{
							rect = new Rect(0f, (float)(texture.height / 2 - texture.width / 2), (float)texture.width, (float)texture.width);
						}
						Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
						this.dicSpriteLoader[url] = sprite;
						if (callback != null)
						{
							callback(sprite);
						}
					}
				});
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00020490 File Offset: 0x0001E890
		public void DownloadSpriteCustom(string url, Action<CustomSpriteData> callback = null)
		{
			CustomSpriteData customSpriteData = new CustomSpriteData();
			if (string.IsNullOrEmpty(url))
			{
				return;
			}
			if (this.dicSpriteLoader.ContainsKey(url))
			{
				customSpriteData.sprite = this.dicSpriteLoader[url];
				customSpriteData.url = url;
				callback(customSpriteData);
			}
			else
			{
				this.DownLoadTexture(url, delegate(Texture2D texture)
				{
					if (texture != null)
					{
						Rect rect;
						if (texture.width > texture.height)
						{
							rect = new Rect((float)(texture.width / 2 - texture.height / 2), 0f, (float)texture.height, (float)texture.height);
						}
						else
						{
							rect = new Rect(0f, (float)(texture.height / 2 - texture.width / 2), (float)texture.width, (float)texture.width);
						}
						Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
						this.dicSpriteLoader[url] = sprite;
						if (callback != null)
						{
							customSpriteData.sprite = sprite;
							customSpriteData.url = url;
							callback(customSpriteData);
						}
					}
				});
			}
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00020548 File Offset: 0x0001E948
		public void DownLoadTexture(string url, Action<Texture2D> callback = null)
		{
			if (string.IsNullOrEmpty(url))
			{
				return;
			}
			if (this.dicTextureLoader.ContainsKey(url))
			{
				callback(this.dicTextureLoader[url]);
			}
			else
			{
				WWW www = this.GetWWW(url);
				if (www != null)
				{
					if (www.texture != null)
					{
						this.dicTextureLoader[url] = www.texture;
						if (callback != null)
						{
							callback(www.texture);
						}
					}
				}
				else
				{
					SingletonMono<DownloadFileUtil>.Instance.OnDownloadFile(url, delegate(ExtraInfoDownload wwwCallBack)
					{
						if (wwwCallBack != null && wwwCallBack.www != null && string.IsNullOrEmpty(wwwCallBack.www.error))
						{
							this.dicTextureLoader[url] = wwwCallBack.www.texture;
							if (callback != null)
							{
								callback(wwwCallBack.www.texture);
							}
						}
					}, delegate(float process)
					{
					}, 5f, 3);
				}
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x00020654 File Offset: 0x0001EA54
		public WWW GetWWW(string url)
		{
			WWW www = null;
			if (string.IsNullOrEmpty(url))
			{
				return null;
			}
			if (this.dicResourceLoader.TryGetValue(url, out www) && www != null && string.IsNullOrEmpty(www.error))
			{
				return www;
			}
			return null;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0002069C File Offset: 0x0001EA9C
		public void AddWWW(string key, WWW w)
		{
			if (w != null && string.IsNullOrEmpty(w.error))
			{
				this.dicResourceLoader[key] = w;
			}
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x000206C4 File Offset: 0x0001EAC4
		public void DisposeWWW(string url, WWW w)
		{
			try
			{
				if (w != null)
				{
					if (w.assetBundle != null)
					{
						w.assetBundle.Unload(false);
					}
					else if (w.texture != null)
					{
						UnityEngine.Object.Destroy(w.texture);
					}
					w.Dispose();
					w = null;
					this.dicSpriteLoader.Remove(url);
					this.dicTextureLoader.Remove(url);
					this.dicResourceLoader.Remove(url);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Unload Resource Exception:" + url + ex.Message);
			}
		}

		// Token: 0x04000487 RID: 1159
		private Dictionary<string, WWW> dicResourceLoader = new Dictionary<string, WWW>();

		// Token: 0x04000488 RID: 1160
		private Dictionary<string, Texture2D> dicTextureLoader = new Dictionary<string, Texture2D>();

		// Token: 0x04000489 RID: 1161
		private Dictionary<string, Sprite> dicSpriteLoader = new Dictionary<string, Sprite>();

		// Token: 0x0400048A RID: 1162
		private Dictionary<string, List<Action<ExtraInfoDownload>>> processQueue = new Dictionary<string, List<Action<ExtraInfoDownload>>>();
	}
}
