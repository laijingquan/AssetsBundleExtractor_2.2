using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x0200004D RID: 77
	public class QuickBase : MonoBehaviour
	{
		// Token: 0x0600028E RID: 654 RVA: 0x0000BEE8 File Offset: 0x0000A2E8
		private void Awake()
		{
			this.cachedRigidBody = base.GetComponent<Rigidbody>();
			if (this.cachedRigidBody)
			{
				this.isKinematic = this.cachedRigidBody.isKinematic;
			}
			this.cachedRigidBody2D = base.GetComponent<Rigidbody2D>();
			if (this.cachedRigidBody2D)
			{
				this.isKinematic2D = this.cachedRigidBody2D.isKinematic;
			}
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000BF50 File Offset: 0x0000A350
		public virtual void Start()
		{
			EasyTouch.SetEnableAutoSelect(true);
			this.realType = QuickBase.GameObjectType.Obj_3D;
			if (base.GetComponent<Collider>())
			{
				this.realType = QuickBase.GameObjectType.Obj_3D;
			}
			else if (base.GetComponent<Collider2D>())
			{
				this.realType = QuickBase.GameObjectType.Obj_2D;
			}
			else if (base.GetComponent<CanvasRenderer>())
			{
				this.realType = QuickBase.GameObjectType.UI;
			}
			QuickBase.GameObjectType gameObjectType = this.realType;
			if (gameObjectType != QuickBase.GameObjectType.Obj_3D)
			{
				if (gameObjectType != QuickBase.GameObjectType.Obj_2D)
				{
					if (gameObjectType == QuickBase.GameObjectType.UI)
					{
						EasyTouch.instance.enableUIMode = true;
						EasyTouch.SetUICompatibily(false);
					}
				}
				else
				{
					EasyTouch.SetEnable2DCollider(true);
					LayerMask mask = EasyTouch.Get2DPickableLayer();
					mask |= 1 << base.gameObject.layer;
					EasyTouch.Set2DPickableLayer(mask);
				}
			}
			else
			{
				LayerMask mask = EasyTouch.Get3DPickableLayer();
				mask |= 1 << base.gameObject.layer;
				EasyTouch.Set3DPickableLayer(mask);
			}
			if (this.enablePickOverUI)
			{
				EasyTouch.instance.enableUIMode = true;
				EasyTouch.SetUICompatibily(false);
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000C06E File Offset: 0x0000A46E
		public virtual void OnEnable()
		{
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000C070 File Offset: 0x0000A470
		public virtual void OnDisable()
		{
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000C074 File Offset: 0x0000A474
		protected Vector3 GetInfluencedAxis()
		{
			Vector3 zero = Vector3.zero;
			switch (this.axesAction)
			{
			case QuickBase.AffectedAxesAction.X:
				zero = new Vector3(1f, 0f, 0f);
				break;
			case QuickBase.AffectedAxesAction.Y:
				zero = new Vector3(0f, 1f, 0f);
				break;
			case QuickBase.AffectedAxesAction.Z:
				zero = new Vector3(0f, 0f, 1f);
				break;
			case QuickBase.AffectedAxesAction.XY:
				zero = new Vector3(1f, 1f, 0f);
				break;
			case QuickBase.AffectedAxesAction.XZ:
				zero = new Vector3(1f, 0f, 1f);
				break;
			case QuickBase.AffectedAxesAction.YZ:
				zero = new Vector3(0f, 1f, 1f);
				break;
			case QuickBase.AffectedAxesAction.XYZ:
				zero = new Vector3(1f, 1f, 1f);
				break;
			}
			return zero;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000C174 File Offset: 0x0000A574
		protected void DoDirectAction(float value)
		{
			Vector3 influencedAxis = this.GetInfluencedAxis();
			switch (this.directAction)
			{
			case QuickBase.DirectAction.Rotate:
				base.transform.Rotate(influencedAxis * value, Space.World);
				break;
			case QuickBase.DirectAction.RotateLocal:
				base.transform.Rotate(influencedAxis * value, Space.Self);
				break;
			case QuickBase.DirectAction.Translate:
				if (this.directCharacterController == null)
				{
					base.transform.Translate(influencedAxis * value, Space.World);
				}
				else
				{
					Vector3 motion = influencedAxis * value;
					this.directCharacterController.Move(motion);
				}
				break;
			case QuickBase.DirectAction.TranslateLocal:
				if (this.directCharacterController == null)
				{
					base.transform.Translate(influencedAxis * value, Space.Self);
				}
				else
				{
					Vector3 motion2 = this.directCharacterController.transform.TransformDirection(influencedAxis) * value;
					this.directCharacterController.Move(motion2);
				}
				break;
			case QuickBase.DirectAction.Scale:
				base.transform.localScale += influencedAxis * value;
				break;
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000C298 File Offset: 0x0000A698
		public void EnabledQuickComponent(string quickActionName)
		{
			QuickBase[] components = base.GetComponents<QuickBase>();
			foreach (QuickBase quickBase in components)
			{
				if (quickBase.quickActionName == quickActionName)
				{
					quickBase.enabled = true;
				}
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000C2E0 File Offset: 0x0000A6E0
		public void DisabledQuickComponent(string quickActionName)
		{
			QuickBase[] components = base.GetComponents<QuickBase>();
			foreach (QuickBase quickBase in components)
			{
				if (quickBase.quickActionName == quickActionName)
				{
					quickBase.enabled = false;
				}
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000C328 File Offset: 0x0000A728
		public void DisabledAllSwipeExcepted(string quickActionName)
		{
			QuickSwipe[] array = UnityEngine.Object.FindObjectsOfType(typeof(QuickSwipe)) as QuickSwipe[];
			foreach (QuickSwipe quickSwipe in array)
			{
				if (quickSwipe.quickActionName != quickActionName || (quickSwipe.quickActionName == quickActionName && quickSwipe.gameObject != base.gameObject))
				{
					quickSwipe.enabled = false;
				}
			}
		}

		// Token: 0x04000106 RID: 262
		public string quickActionName;

		// Token: 0x04000107 RID: 263
		public bool isMultiTouch;

		// Token: 0x04000108 RID: 264
		public bool is2Finger;

		// Token: 0x04000109 RID: 265
		public bool isOnTouch;

		// Token: 0x0400010A RID: 266
		public bool enablePickOverUI;

		// Token: 0x0400010B RID: 267
		public bool resetPhysic;

		// Token: 0x0400010C RID: 268
		public QuickBase.DirectAction directAction;

		// Token: 0x0400010D RID: 269
		public QuickBase.AffectedAxesAction axesAction;

		// Token: 0x0400010E RID: 270
		public float sensibility = 1f;

		// Token: 0x0400010F RID: 271
		public CharacterController directCharacterController;

		// Token: 0x04000110 RID: 272
		public bool inverseAxisValue;

		// Token: 0x04000111 RID: 273
		protected Rigidbody cachedRigidBody;

		// Token: 0x04000112 RID: 274
		protected bool isKinematic;

		// Token: 0x04000113 RID: 275
		protected Rigidbody2D cachedRigidBody2D;

		// Token: 0x04000114 RID: 276
		protected bool isKinematic2D;

		// Token: 0x04000115 RID: 277
		protected QuickBase.GameObjectType realType;

		// Token: 0x04000116 RID: 278
		protected int fingerIndex = -1;

		// Token: 0x0200004E RID: 78
		protected enum GameObjectType
		{
			// Token: 0x04000118 RID: 280
			Auto,
			// Token: 0x04000119 RID: 281
			Obj_3D,
			// Token: 0x0400011A RID: 282
			Obj_2D,
			// Token: 0x0400011B RID: 283
			UI
		}

		// Token: 0x0200004F RID: 79
		public enum DirectAction
		{
			// Token: 0x0400011D RID: 285
			None,
			// Token: 0x0400011E RID: 286
			Rotate,
			// Token: 0x0400011F RID: 287
			RotateLocal,
			// Token: 0x04000120 RID: 288
			Translate,
			// Token: 0x04000121 RID: 289
			TranslateLocal,
			// Token: 0x04000122 RID: 290
			Scale
		}

		// Token: 0x02000050 RID: 80
		public enum AffectedAxesAction
		{
			// Token: 0x04000124 RID: 292
			X,
			// Token: 0x04000125 RID: 293
			Y,
			// Token: 0x04000126 RID: 294
			Z,
			// Token: 0x04000127 RID: 295
			XY,
			// Token: 0x04000128 RID: 296
			XZ,
			// Token: 0x04000129 RID: 297
			YZ,
			// Token: 0x0400012A RID: 298
			XYZ
		}
	}
}
