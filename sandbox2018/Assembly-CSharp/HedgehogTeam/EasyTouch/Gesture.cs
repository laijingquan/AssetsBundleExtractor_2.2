using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020000A3 RID: 163
	public class Gesture : BaseFinger, ICloneable
	{
		// Token: 0x06000437 RID: 1079 RVA: 0x00013C29 File Offset: 0x00012029
		public object Clone()
		{
			return base.MemberwiseClone();
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00013C31 File Offset: 0x00012031
		public Vector3 GetTouchToWorldPoint(float z)
		{
			return Camera.main.ScreenToWorldPoint(new Vector3(this.position.x, this.position.y, z));
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00013C5C File Offset: 0x0001205C
		public Vector3 GetTouchToWorldPoint(Vector3 position3D)
		{
			return Camera.main.ScreenToWorldPoint(new Vector3(this.position.x, this.position.y, Camera.main.transform.InverseTransformPoint(position3D).z));
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00013CA8 File Offset: 0x000120A8
		public float GetSwipeOrDragAngle()
		{
			return Mathf.Atan2(this.swipeVector.normalized.y, this.swipeVector.normalized.x) * 57.29578f;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00013CE8 File Offset: 0x000120E8
		public Vector2 NormalizedPosition()
		{
			return new Vector2(100f / (float)Screen.width * this.position.x / 100f, 100f / (float)Screen.height * this.position.y / 100f);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00013D36 File Offset: 0x00012136
		public bool IsOverUIElement()
		{
			return EasyTouch.IsFingerOverUIElement(this.fingerIndex);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00013D43 File Offset: 0x00012143
		public bool IsOverRectTransform(RectTransform tr, Camera camera = null)
		{
			if (camera == null)
			{
				return RectTransformUtility.RectangleContainsScreenPoint(tr, this.position, null);
			}
			return RectTransformUtility.RectangleContainsScreenPoint(tr, this.position, camera);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00013D6C File Offset: 0x0001216C
		public GameObject GetCurrentFirstPickedUIElement(bool isTwoFinger = false)
		{
			return EasyTouch.GetCurrentPickedUIElement(this.fingerIndex, isTwoFinger);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00013D7A File Offset: 0x0001217A
		public GameObject GetCurrentPickedObject(bool isTwoFinger = false)
		{
			return EasyTouch.GetCurrentPickedObject(this.fingerIndex, isTwoFinger);
		}

		// Token: 0x0400024A RID: 586
		public EasyTouch.SwipeDirection swipe;

		// Token: 0x0400024B RID: 587
		public float swipeLength;

		// Token: 0x0400024C RID: 588
		public Vector2 swipeVector;

		// Token: 0x0400024D RID: 589
		public float deltaPinch;

		// Token: 0x0400024E RID: 590
		public float twistAngle;

		// Token: 0x0400024F RID: 591
		public float twoFingerDistance;

		// Token: 0x04000250 RID: 592
		public EasyTouch.EvtType type;
	}
}
