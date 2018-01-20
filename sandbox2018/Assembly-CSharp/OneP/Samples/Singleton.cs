using System;

namespace OneP.Samples
{
	// Token: 0x02000128 RID: 296
	public abstract class Singleton<T> where T : new()
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x000202A5 File Offset: 0x0001E6A5
		public static T Instance
		{
			get
			{
				if (Singleton<T>.singleton == null)
				{
					Singleton<T>.singleton = Activator.CreateInstance<T>();
				}
				return Singleton<T>.singleton;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x000202C5 File Offset: 0x0001E6C5
		public static T instance
		{
			get
			{
				if (Singleton<T>.singleton == null)
				{
					Singleton<T>.singleton = Activator.CreateInstance<T>();
				}
				return Singleton<T>.singleton;
			}
		}

		// Token: 0x04000483 RID: 1155
		private static T singleton;
	}
}
