using System;
using UnityEngine;

namespace OneP.Samples
{
	// Token: 0x02000129 RID: 297
	public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
	{
		// Token: 0x060007AD RID: 1965 RVA: 0x0001FAC0 File Offset: 0x0001DEC0
		public static bool IsInstanceValid()
		{
			return SingletonMono<T>.singleton != null;
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0001FAD2 File Offset: 0x0001DED2
		private void Reset()
		{
			base.gameObject.name = typeof(T).Name;
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060007AF RID: 1967 RVA: 0x0001FAF0 File Offset: 0x0001DEF0
		public static T Instance
		{
			get
			{
				if (SingletonMono<T>.singleton == null)
				{
					SingletonMono<T>.singleton = (T)((object)UnityEngine.Object.FindObjectOfType(typeof(T)));
					if (SingletonMono<T>.singleton == null)
					{
						SingletonMono<T>.singleton = new GameObject
						{
							name = "[@" + typeof(T).Name + "]"
						}.AddComponent<T>();
					}
				}
				return SingletonMono<T>.singleton;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0001FB7C File Offset: 0x0001DF7C
		public static T instance
		{
			get
			{
				if (SingletonMono<T>.singleton == null)
				{
					SingletonMono<T>.singleton = (T)((object)UnityEngine.Object.FindObjectOfType(typeof(T)));
					if (SingletonMono<T>.singleton == null)
					{
						SingletonMono<T>.singleton = new GameObject
						{
							name = "[@" + typeof(T).Name + "]"
						}.AddComponent<T>();
					}
				}
				return SingletonMono<T>.singleton;
			}
		}

		// Token: 0x04000484 RID: 1156
		private static T singleton;
	}
}
