using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020000A2 RID: 162
	public class Finger : BaseFinger
	{
		// Token: 0x04000244 RID: 580
		public float startTimeAction;

		// Token: 0x04000245 RID: 581
		public Vector2 oldPosition;

		// Token: 0x04000246 RID: 582
		public int tapCount;

		// Token: 0x04000247 RID: 583
		public TouchPhase phase;

		// Token: 0x04000248 RID: 584
		public EasyTouch.GestureType gesture;

		// Token: 0x04000249 RID: 585
		public EasyTouch.SwipeDirection oldSwipeType;
	}
}
