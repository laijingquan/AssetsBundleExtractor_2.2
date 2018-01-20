using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020000A1 RID: 161
	[Serializable]
	public class ECamera
	{
		// Token: 0x06000434 RID: 1076 RVA: 0x00013C03 File Offset: 0x00012003
		public ECamera(Camera cam, bool gui)
		{
			this.camera = cam;
			this.guiCamera = gui;
		}

		// Token: 0x04000242 RID: 578
		public Camera camera;

		// Token: 0x04000243 RID: 579
		public bool guiCamera;
	}
}
