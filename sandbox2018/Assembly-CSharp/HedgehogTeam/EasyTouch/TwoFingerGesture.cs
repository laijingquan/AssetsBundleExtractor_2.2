using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020000A4 RID: 164
	public class TwoFingerGesture
	{
		// Token: 0x06000441 RID: 1089 RVA: 0x00013DA5 File Offset: 0x000121A5
		public void ClearPickedObjectData()
		{
			this.pickedObject = null;
			this.oldPickedObject = null;
			this.pickedCamera = null;
			this.isGuiCamera = false;
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00013DC3 File Offset: 0x000121C3
		public void ClearPickedUIData()
		{
			this.isOverGui = false;
			this.pickedUIElement = null;
		}

		// Token: 0x04000251 RID: 593
		public EasyTouch.GestureType currentGesture = EasyTouch.GestureType.None;

		// Token: 0x04000252 RID: 594
		public EasyTouch.GestureType oldGesture = EasyTouch.GestureType.None;

		// Token: 0x04000253 RID: 595
		public int finger0;

		// Token: 0x04000254 RID: 596
		public int finger1;

		// Token: 0x04000255 RID: 597
		public float startTimeAction;

		// Token: 0x04000256 RID: 598
		public float timeSinceStartAction;

		// Token: 0x04000257 RID: 599
		public Vector2 startPosition;

		// Token: 0x04000258 RID: 600
		public Vector2 position;

		// Token: 0x04000259 RID: 601
		public Vector2 deltaPosition;

		// Token: 0x0400025A RID: 602
		public Vector2 oldStartPosition;

		// Token: 0x0400025B RID: 603
		public float startDistance;

		// Token: 0x0400025C RID: 604
		public float fingerDistance;

		// Token: 0x0400025D RID: 605
		public float oldFingerDistance;

		// Token: 0x0400025E RID: 606
		public bool lockPinch;

		// Token: 0x0400025F RID: 607
		public bool lockTwist = true;

		// Token: 0x04000260 RID: 608
		public float lastPinch;

		// Token: 0x04000261 RID: 609
		public float lastTwistAngle;

		// Token: 0x04000262 RID: 610
		public GameObject pickedObject;

		// Token: 0x04000263 RID: 611
		public GameObject oldPickedObject;

		// Token: 0x04000264 RID: 612
		public Camera pickedCamera;

		// Token: 0x04000265 RID: 613
		public bool isGuiCamera;

		// Token: 0x04000266 RID: 614
		public bool isOverGui;

		// Token: 0x04000267 RID: 615
		public GameObject pickedUIElement;

		// Token: 0x04000268 RID: 616
		public bool dragStart;

		// Token: 0x04000269 RID: 617
		public bool swipeStart;

		// Token: 0x0400026A RID: 618
		public bool inSingleDoubleTaps;

		// Token: 0x0400026B RID: 619
		public float tapCurentTime;
	}
}
