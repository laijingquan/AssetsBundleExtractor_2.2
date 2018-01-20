using System;
using UnityEngine;

namespace OneP.InfinityScrollView
{
	// Token: 0x02000136 RID: 310
	public static class RectTransformExtensions
	{
		// Token: 0x060007E1 RID: 2017 RVA: 0x00021A57 File Offset: 0x0001FE57
		public static void SetDefaultScale(this RectTransform trans)
		{
			trans.localScale = new Vector3(1f, 1f, 1f);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x00021A73 File Offset: 0x0001FE73
		public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec)
		{
			trans.pivot = aVec;
			trans.anchorMin = aVec;
			trans.anchorMax = aVec;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x00021A8C File Offset: 0x0001FE8C
		public static Vector2 GetSize(this RectTransform trans)
		{
			return trans.rect.size;
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x00021AA8 File Offset: 0x0001FEA8
		public static float GetWidth(this RectTransform trans)
		{
			return trans.rect.width;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00021AC4 File Offset: 0x0001FEC4
		public static float GetHeight(this RectTransform trans)
		{
			return trans.rect.height;
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00021AE0 File Offset: 0x0001FEE0
		public static void SetLocalPosition(this RectTransform trans, Vector2 newPos)
		{
			trans.localPosition = new Vector3(newPos.x, newPos.y, trans.localPosition.z);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00021B14 File Offset: 0x0001FF14
		public static void SetLeftBottomPosition(this RectTransform trans, Vector2 newPos)
		{
			trans.localPosition = new Vector3(newPos.x + trans.pivot.x * trans.rect.width, newPos.y + trans.pivot.y * trans.rect.height, trans.localPosition.z);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00021B88 File Offset: 0x0001FF88
		public static void SetLeftTopPosition(this RectTransform trans, Vector2 newPos)
		{
			trans.localPosition = new Vector3(newPos.x + trans.pivot.x * trans.rect.width, newPos.y - (1f - trans.pivot.y) * trans.rect.height, trans.localPosition.z);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00021C00 File Offset: 0x00020000
		public static void SetRightBottomPosition(this RectTransform trans, Vector2 newPos)
		{
			trans.localPosition = new Vector3(newPos.x - (1f - trans.pivot.x) * trans.rect.width, newPos.y + trans.pivot.y * trans.rect.height, trans.localPosition.z);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00021C78 File Offset: 0x00020078
		public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos)
		{
			trans.localPosition = new Vector3(newPos.x - (1f - trans.pivot.x) * trans.rect.width, newPos.y - (1f - trans.pivot.y) * trans.rect.height, trans.localPosition.z);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00021CF8 File Offset: 0x000200F8
		public static void SetSizeDelta(this RectTransform trans, Vector2 newSize)
		{
			Vector2 size = trans.rect.size;
			Vector2 vector = newSize - size;
			trans.offsetMin -= new Vector2(vector.x * trans.pivot.x, vector.y * trans.pivot.y);
			trans.offsetMax += new Vector2(vector.x * (1f - trans.pivot.x), vector.y * (1f - trans.pivot.y));
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00021DB0 File Offset: 0x000201B0
		public static void SetWidth(this RectTransform trans, float newSize)
		{
			trans.SetSizeDelta(new Vector2(newSize, trans.rect.size.y));
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x00021DE0 File Offset: 0x000201E0
		public static void SetHeight(this RectTransform trans, float newSize)
		{
			trans.SetSizeDelta(new Vector2(trans.rect.size.x, newSize));
		}
	}
}
