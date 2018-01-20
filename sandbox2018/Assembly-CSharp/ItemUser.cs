using System;
using System.Collections;
using OneP.InfinityScrollView;
using OneP.Samples;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000126 RID: 294
public class ItemUser : InfinityBaseItem
{
	// Token: 0x0600079C RID: 1948 RVA: 0x0001FF24 File Offset: 0x0001E324
	public override void Reload(InfinityScrollView _infinity, int _index)
	{
		base.Reload(_infinity, _index);
		base.StopAllCoroutines();
		this.text.text = "User " + (base.Index + 1);
		string iduser = SingletonMono<Sample3>.Instance.GetIDUser(base.Index);
		if (string.IsNullOrEmpty(iduser))
		{
			this.avatar.sprite = this.spriteDefault;
		}
		else
		{
			string text = "http://graph.facebook.com/" + iduser + "/picture?type=square";
			this.urlAva = text;
			Sprite memorySprite = Singleton<ResourceLoaderManager>.Instance.GetMemorySprite(text);
			if (memorySprite != null)
			{
				this.avatar.sprite = memorySprite;
			}
			else
			{
				this.avatar.sprite = this.spriteDefault;
				base.StartCoroutine(this.LoadAvatar(text));
			}
		}
	}

	// Token: 0x0600079D RID: 1949 RVA: 0x0001FFF4 File Offset: 0x0001E3F4
	private IEnumerator LoadAvatar(string path)
	{
        yield return new WaitForSeconds(0.6f);
        if (path.Length > 0)
        {
            this.urlAva = path;
            Action<CustomSpriteData> ac = (res) =>
            {
                if (res != null && res.url.Equals(this.urlAva) && this.avatar != null)
                {
                    this.avatar.sprite = res.sprite;
                }
            };
            Singleton<ResourceLoaderManager>.Instance.DownloadSpriteCustom(path, ac);
        }
		yield break;
	}

	// Token: 0x0600079E RID: 1950 RVA: 0x00020016 File Offset: 0x0001E416
	public void OnClickItem()
	{
		SingletonMono<Sample3>.Instance.OnClickItem(base.Index + 1);
	}

	// Token: 0x0600079F RID: 1951 RVA: 0x0002002A File Offset: 0x0001E42A
	private void Start()
	{
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x0002002C File Offset: 0x0001E42C
	private void Update()
	{
	}

	// Token: 0x0400047A RID: 1146
	public Sprite spriteDefault;

	// Token: 0x0400047B RID: 1147
	public Text text;

	// Token: 0x0400047C RID: 1148
	public Image avatar;

	// Token: 0x0400047D RID: 1149
	private string urlAva = string.Empty;
}
