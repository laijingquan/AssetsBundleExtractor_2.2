using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x0200006F RID: 111
	public class BaseFinger
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x0000E0F0 File Offset: 0x0000C4F0
		public Gesture GetGesture()
		{
			return new Gesture
			{
				fingerIndex = this.fingerIndex,
				touchCount = this.touchCount,
				startPosition = this.startPosition,
				position = this.position,
				deltaPosition = this.deltaPosition,
				actionTime = this.actionTime,
				deltaTime = this.deltaTime,
				isOverGui = this.isOverGui,
				pickedCamera = this.pickedCamera,
				pickedObject = this.pickedObject,
				isGuiCamera = this.isGuiCamera,
				pickedUIElement = this.pickedUIElement,
				altitudeAngle = this.altitudeAngle,
				azimuthAngle = this.azimuthAngle,
				maximumPossiblePressure = this.maximumPossiblePressure,
				pressure = this.pressure,
				radius = this.radius,
				radiusVariance = this.radiusVariance,
				touchType = this.touchType
			};
		}

		// Token: 0x0400017C RID: 380
		public int fingerIndex;

		// Token: 0x0400017D RID: 381
		public int touchCount;

		// Token: 0x0400017E RID: 382
		public Vector2 startPosition;

		// Token: 0x0400017F RID: 383
		public Vector2 position;

		// Token: 0x04000180 RID: 384
		public Vector2 deltaPosition;

		// Token: 0x04000181 RID: 385
		public float actionTime;

		// Token: 0x04000182 RID: 386
		public float deltaTime;

		// Token: 0x04000183 RID: 387
		public Camera pickedCamera;

		// Token: 0x04000184 RID: 388
		public GameObject pickedObject;

		// Token: 0x04000185 RID: 389
		public bool isGuiCamera;

		// Token: 0x04000186 RID: 390
		public bool isOverGui;

		// Token: 0x04000187 RID: 391
		public GameObject pickedUIElement;

		// Token: 0x04000188 RID: 392
		public float altitudeAngle;

		// Token: 0x04000189 RID: 393
		public float azimuthAngle;

		// Token: 0x0400018A RID: 394
		public float maximumPossiblePressure;

		// Token: 0x0400018B RID: 395
		public float pressure;

		// Token: 0x0400018C RID: 396
		public float radius;

		// Token: 0x0400018D RID: 397
		public float radiusVariance;

		// Token: 0x0400018E RID: 398
		public TouchType touchType;
	}
}
