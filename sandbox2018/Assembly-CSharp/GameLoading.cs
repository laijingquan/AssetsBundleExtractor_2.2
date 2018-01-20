using System;
using UnityEngine;

// Token: 0x02000147 RID: 327
public class GameLoading : MonoBehaviour
{
	// Token: 0x0600083B RID: 2107 RVA: 0x000230FF File Offset: 0x000214FF
	private void Start()
	{
		this.CheckVip();
		SceneGameManager.Instance.SwitchScene(AppConfig.SCENE_NAME_GMAE);
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x00023118 File Offset: 0x00021518
	private void CheckVip()
	{
		if (PlayerManager.Instance.GetVipType() == 0)
		{
			bool vip = PlayerManager.Instance.GetVip();
			if (vip)
			{
				PlayerManager.Instance.SetVipType(1);
			}
			PlayerManager.Instance.SetVipType(2);
			Debug.Log("2组vip");
		}
		int vipType = PlayerManager.Instance.GetVipType();
		if (vipType == 1)
		{
			Debug.Log("1组vip SubscriptionVip Init");
			SubscriptionVip.Instance.Init();
		}
		else if (vipType == 2)
		{
			Debug.Log("2组vip SubscriptionVipTwo Init");
			SubscriptionVipTwo.Instance.Init();
		}
	}
}
