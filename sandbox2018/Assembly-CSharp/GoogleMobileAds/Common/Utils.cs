using System;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	// Token: 0x02000112 RID: 274
	internal class Utils
	{
		// Token: 0x060006E5 RID: 1765 RVA: 0x0001DA70 File Offset: 0x0001BE70
		public static Texture2D GetTexture2DFromByteArray(byte[] img)
		{
			Texture2D texture2D = new Texture2D(1, 1);
			if (!texture2D.LoadImage(img))
			{
				throw new InvalidOperationException("Could not load custom native template\n                        image asset as texture");
			}
			return texture2D;
		}
	}
}
