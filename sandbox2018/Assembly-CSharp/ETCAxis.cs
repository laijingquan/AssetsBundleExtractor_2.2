using System;
using UnityEngine;

// Token: 0x020000B6 RID: 182
[Serializable]
public class ETCAxis
{
	// Token: 0x060004A2 RID: 1186 RVA: 0x000156AC File Offset: 0x00013AAC
	public ETCAxis(string axisName)
	{
		this.name = axisName;
		this.enable = true;
		this.speed = 15f;
		this.invertedAxis = false;
		this.isEnertia = false;
		this.inertia = 0f;
		this.inertiaThreshold = 0.08f;
		this.axisValue = 0f;
		this.axisSpeedValue = 0f;
		this.gravity = 0f;
		this.isAutoStab = false;
		this.autoStabThreshold = 0.01f;
		this.autoStabSpeed = 10f;
		this.maxAngle = 90f;
		this.minAngle = 90f;
		this.axisState = ETCAxis.AxisState.None;
		this.maxOverTimeValue = 1f;
		this.overTimeStep = 1f;
		this.isValueOverTime = false;
		this.axisThreshold = 0.5f;
		this.deadValue = 0.1f;
		this.actionOn = ETCAxis.ActionOn.Press;
	}

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0001579C File Offset: 0x00013B9C
	// (set) Token: 0x060004A4 RID: 1188 RVA: 0x000157A4 File Offset: 0x00013BA4
	public Transform directTransform
	{
		get
		{
			return this._directTransform;
		}
		set
		{
			this._directTransform = value;
			if (this._directTransform != null)
			{
				this.directCharacterController = this._directTransform.GetComponent<CharacterController>();
				this.directRigidBody = this._directTransform.GetComponent<Rigidbody>();
			}
			else
			{
				this.directCharacterController = null;
			}
		}
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x000157F8 File Offset: 0x00013BF8
	public void InitAxis()
	{
		if (this.autoLinkTagPlayer)
		{
			this.player = GameObject.FindGameObjectWithTag(this.autoTag);
			if (this.player)
			{
				this.directTransform = this.player.transform;
			}
		}
		this.startAngle = this.GetAngle();
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x00015850 File Offset: 0x00013C50
	public void UpdateAxis(float realValue, bool isOnDrag, ETCBase.ControlType type, bool deltaTime = true)
	{
		if ((this.autoLinkTagPlayer && this.player == null) || (this.player && !this.player.activeSelf))
		{
			this.player = GameObject.FindGameObjectWithTag(this.autoTag);
			if (this.player)
			{
				this.directTransform = this.player.transform;
			}
		}
		if (this.isAutoStab && this.axisValue == 0f && this._directTransform)
		{
			this.DoAutoStabilisation();
		}
		if (this.invertedAxis)
		{
			realValue *= -1f;
		}
		if (this.isValueOverTime && realValue != 0f)
		{
			this.axisValue += this.overTimeStep * Mathf.Sign(realValue) * Time.deltaTime;
			if (Mathf.Sign(this.axisValue) > 0f)
			{
				this.axisValue = Mathf.Clamp(this.axisValue, 0f, this.maxOverTimeValue);
			}
			else
			{
				this.axisValue = Mathf.Clamp(this.axisValue, -this.maxOverTimeValue, 0f);
			}
		}
		this.ComputAxisValue(realValue, type, isOnDrag, deltaTime);
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x000159A4 File Offset: 0x00013DA4
	public void UpdateButton()
	{
		if ((this.autoLinkTagPlayer && this.player == null) || (this.player && !this.player.activeSelf))
		{
			this.player = GameObject.FindGameObjectWithTag(this.autoTag);
			if (this.player)
			{
				this.directTransform = this.player.transform;
			}
		}
		if (this.isValueOverTime)
		{
			this.axisValue += this.overTimeStep * Time.deltaTime;
			this.axisValue = Mathf.Clamp(this.axisValue, 0f, this.maxOverTimeValue);
		}
		else if (this.axisState == ETCAxis.AxisState.Press || this.axisState == ETCAxis.AxisState.Down)
		{
			this.axisValue = 1f;
		}
		else
		{
			this.axisValue = 0f;
		}
		ETCAxis.ActionOn actionOn = this.actionOn;
		if (actionOn != ETCAxis.ActionOn.Down)
		{
			if (actionOn == ETCAxis.ActionOn.Press)
			{
				this.axisSpeedValue = this.axisValue * this.speed * Time.deltaTime;
				if (this.axisState == ETCAxis.AxisState.Press)
				{
					this.DoDirectAction();
				}
			}
		}
		else
		{
			this.axisSpeedValue = this.axisValue * this.speed;
			if (this.axisState == ETCAxis.AxisState.Down)
			{
				this.DoDirectAction();
			}
		}
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x00015B0C File Offset: 0x00013F0C
	public void ResetAxis()
	{
		if (!this.isEnertia || (this.isEnertia && Mathf.Abs(this.axisValue) < this.inertiaThreshold))
		{
			this.axisValue = 0f;
			this.axisSpeedValue = 0f;
		}
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x00015B5C File Offset: 0x00013F5C
	public void DoDirectAction()
	{
		if (this.directTransform)
		{
			Vector3 influencedAxis = this.GetInfluencedAxis();
			switch (this.directAction)
			{
			case ETCAxis.DirectAction.Rotate:
				this.directTransform.Rotate(influencedAxis * this.axisSpeedValue, Space.World);
				break;
			case ETCAxis.DirectAction.RotateLocal:
				this.directTransform.Rotate(influencedAxis * this.axisSpeedValue, Space.Self);
				break;
			case ETCAxis.DirectAction.Translate:
				if (this.directCharacterController == null)
				{
					this.directTransform.Translate(influencedAxis * this.axisSpeedValue, Space.World);
				}
				else if (this.directCharacterController.isGrounded || !this.isLockinJump)
				{
					Vector3 motion = influencedAxis * this.axisSpeedValue;
					this.directCharacterController.Move(motion);
					this.lastMove = influencedAxis * (this.axisSpeedValue / Time.deltaTime);
				}
				else
				{
					this.directCharacterController.Move(this.lastMove * Time.deltaTime);
				}
				break;
			case ETCAxis.DirectAction.TranslateLocal:
				if (this.directCharacterController == null)
				{
					this.directTransform.Translate(influencedAxis * this.axisSpeedValue, Space.Self);
				}
				else if (this.directCharacterController.isGrounded || !this.isLockinJump)
				{
					Vector3 motion2 = this.directCharacterController.transform.TransformDirection(influencedAxis) * this.axisSpeedValue;
					this.directCharacterController.Move(motion2);
					this.lastMove = this.directCharacterController.transform.TransformDirection(influencedAxis) * (this.axisSpeedValue / Time.deltaTime);
				}
				else
				{
					this.directCharacterController.Move(this.lastMove * Time.deltaTime);
				}
				break;
			case ETCAxis.DirectAction.Scale:
				this.directTransform.localScale += influencedAxis * this.axisSpeedValue;
				break;
			case ETCAxis.DirectAction.Force:
				if (this.directRigidBody != null)
				{
					this.directRigidBody.AddForce(influencedAxis * this.axisValue * this.speed);
				}
				else
				{
					Debug.LogWarning("ETCAxis : " + this.name + " No rigidbody on gameobject : " + this._directTransform.name);
				}
				break;
			case ETCAxis.DirectAction.RelativeForce:
				if (this.directRigidBody != null)
				{
					this.directRigidBody.AddRelativeForce(influencedAxis * this.axisValue * this.speed);
				}
				else
				{
					Debug.LogWarning("ETCAxis : " + this.name + " No rigidbody on gameobject : " + this._directTransform.name);
				}
				break;
			case ETCAxis.DirectAction.Torque:
				if (this.directRigidBody != null)
				{
					this.directRigidBody.AddTorque(influencedAxis * this.axisValue * this.speed);
				}
				else
				{
					Debug.LogWarning("ETCAxis : " + this.name + " No rigidbody on gameobject : " + this._directTransform.name);
				}
				break;
			case ETCAxis.DirectAction.RelativeTorque:
				if (this.directRigidBody != null)
				{
					this.directRigidBody.AddRelativeTorque(influencedAxis * this.axisValue * this.speed);
				}
				else
				{
					Debug.LogWarning("ETCAxis : " + this.name + " No rigidbody on gameobject : " + this._directTransform.name);
				}
				break;
			case ETCAxis.DirectAction.Jump:
				if (this.directCharacterController != null && !this.isJump)
				{
					this.isJump = true;
					this.currentGravity = this.speed;
				}
				break;
			}
			if (this.isClampRotation && this.directAction == ETCAxis.DirectAction.RotateLocal)
			{
				this.DoAngleLimitation();
			}
		}
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x00015F58 File Offset: 0x00014358
	public void DoGravity()
	{
		if (this.directCharacterController != null && this.gravity != 0f)
		{
			if (!this.isJump)
			{
				Vector3 a = new Vector3(0f, -this.gravity, 0f);
				this.directCharacterController.Move(a * Time.deltaTime);
			}
			else
			{
				this.currentGravity -= this.gravity * Time.deltaTime;
				Vector3 a2 = new Vector3(0f, this.currentGravity, 0f);
				this.directCharacterController.Move(a2 * Time.deltaTime);
			}
			if (this.directCharacterController.isGrounded)
			{
				this.isJump = false;
				this.currentGravity = 0f;
			}
		}
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x00016030 File Offset: 0x00014430
	private void ComputAxisValue(float realValue, ETCBase.ControlType type, bool isOnDrag, bool deltaTime)
	{
		if (this.enable)
		{
			if (type == ETCBase.ControlType.Joystick)
			{
				if (this.valueMethod == ETCAxis.AxisValueMethod.Classical)
				{
					float num = Mathf.Max(Mathf.Abs(realValue), 0.001f);
					float num2 = Mathf.Max(num - this.deadValue, 0f) / (1f - this.deadValue) / num;
					realValue *= num2;
				}
				else
				{
					realValue = this.curveValue.Evaluate(Mathf.Abs(realValue)) * Mathf.Sign(realValue);
				}
			}
			if (this.isEnertia)
			{
				realValue -= this.axisValue;
				realValue /= this.inertia;
				this.axisValue += realValue;
				if (Mathf.Abs(this.axisValue) < this.inertiaThreshold && !isOnDrag)
				{
					this.axisValue = 0f;
				}
			}
			else if (!this.isValueOverTime || (this.isValueOverTime && realValue == 0f))
			{
				this.axisValue = realValue;
			}
			if (deltaTime)
			{
				this.axisSpeedValue = this.axisValue * this.speed * Time.deltaTime;
			}
			else
			{
				this.axisSpeedValue = this.axisValue * this.speed;
			}
		}
		else
		{
			this.axisValue = 0f;
			this.axisSpeedValue = 0f;
		}
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x00016184 File Offset: 0x00014584
	private Vector3 GetInfluencedAxis()
	{
		Vector3 result = Vector3.zero;
		ETCAxis.AxisInfluenced axisInfluenced = this.axisInfluenced;
		if (axisInfluenced != ETCAxis.AxisInfluenced.X)
		{
			if (axisInfluenced != ETCAxis.AxisInfluenced.Y)
			{
				if (axisInfluenced == ETCAxis.AxisInfluenced.Z)
				{
					result = Vector3.forward;
				}
			}
			else
			{
				result = Vector3.up;
			}
		}
		else
		{
			result = Vector3.right;
		}
		return result;
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x000161DC File Offset: 0x000145DC
	private float GetAngle()
	{
		float num = 0f;
		if (this._directTransform != null)
		{
			ETCAxis.AxisInfluenced axisInfluenced = this.axisInfluenced;
			if (axisInfluenced != ETCAxis.AxisInfluenced.X)
			{
				if (axisInfluenced != ETCAxis.AxisInfluenced.Y)
				{
					if (axisInfluenced == ETCAxis.AxisInfluenced.Z)
					{
						num = this._directTransform.localRotation.eulerAngles.z;
					}
				}
				else
				{
					num = this._directTransform.localRotation.eulerAngles.y;
				}
			}
			else
			{
				num = this._directTransform.localRotation.eulerAngles.x;
			}
			if (num <= 360f && num >= 180f)
			{
				num -= 360f;
			}
		}
		return num;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x000162A8 File Offset: 0x000146A8
	private void DoAutoStabilisation()
	{
		float num = this.GetAngle();
		if (num <= 360f && num >= 180f)
		{
			num -= 360f;
		}
		if (num > this.startAngle - this.autoStabThreshold || num < this.startAngle + this.autoStabThreshold)
		{
			float num2 = 0f;
			Vector3 zero = Vector3.zero;
			if (num > this.startAngle - this.autoStabThreshold)
			{
				num2 = num + this.autoStabSpeed / 100f * Mathf.Abs(num - this.startAngle) * Time.deltaTime * -1f;
			}
			if (num < this.startAngle + this.autoStabThreshold)
			{
				num2 = num + this.autoStabSpeed / 100f * Mathf.Abs(num - this.startAngle) * Time.deltaTime;
			}
			ETCAxis.AxisInfluenced axisInfluenced = this.axisInfluenced;
			if (axisInfluenced != ETCAxis.AxisInfluenced.X)
			{
				if (axisInfluenced != ETCAxis.AxisInfluenced.Y)
				{
					if (axisInfluenced == ETCAxis.AxisInfluenced.Z)
					{
						zero = new Vector3(this._directTransform.localRotation.eulerAngles.x, this._directTransform.localRotation.eulerAngles.y, num2);
					}
				}
				else
				{
					zero = new Vector3(this._directTransform.localRotation.eulerAngles.x, num2, this._directTransform.localRotation.eulerAngles.z);
				}
			}
			else
			{
				zero = new Vector3(num2, this._directTransform.localRotation.eulerAngles.y, this._directTransform.localRotation.eulerAngles.z);
			}
			this._directTransform.localRotation = Quaternion.Euler(zero);
		}
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x00016484 File Offset: 0x00014884
	private void DoAngleLimitation()
	{
		Quaternion localRotation = this._directTransform.localRotation;
		localRotation.x /= localRotation.w;
		localRotation.y /= localRotation.w;
		localRotation.z /= localRotation.w;
		localRotation.w = 1f;
		ETCAxis.AxisInfluenced axisInfluenced = this.axisInfluenced;
		if (axisInfluenced != ETCAxis.AxisInfluenced.X)
		{
			if (axisInfluenced != ETCAxis.AxisInfluenced.Y)
			{
				if (axisInfluenced == ETCAxis.AxisInfluenced.Z)
				{
					float num = 114.59156f * Mathf.Atan(localRotation.z);
					num = Mathf.Clamp(num, -this.minAngle, this.maxAngle);
					localRotation.z = Mathf.Tan(0.008726646f * num);
				}
			}
			else
			{
				float num = 114.59156f * Mathf.Atan(localRotation.y);
				num = Mathf.Clamp(num, -this.minAngle, this.maxAngle);
				localRotation.y = Mathf.Tan(0.008726646f * num);
			}
		}
		else
		{
			float num = 114.59156f * Mathf.Atan(localRotation.x);
			num = Mathf.Clamp(num, -this.minAngle, this.maxAngle);
			localRotation.x = Mathf.Tan(0.008726646f * num);
		}
		this._directTransform.localRotation = localRotation;
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x000165D7 File Offset: 0x000149D7
	public void InitDeadCurve()
	{
		this.curveValue = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
		this.curveValue.postWrapMode = WrapMode.PingPong;
		this.curveValue.preWrapMode = WrapMode.PingPong;
	}

	// Token: 0x040002AF RID: 687
	public string name;

	// Token: 0x040002B0 RID: 688
	public bool autoLinkTagPlayer;

	// Token: 0x040002B1 RID: 689
	public string autoTag = "Player";

	// Token: 0x040002B2 RID: 690
	public GameObject player;

	// Token: 0x040002B3 RID: 691
	public bool enable;

	// Token: 0x040002B4 RID: 692
	public bool invertedAxis;

	// Token: 0x040002B5 RID: 693
	public float speed;

	// Token: 0x040002B6 RID: 694
	public float deadValue;

	// Token: 0x040002B7 RID: 695
	public ETCAxis.AxisValueMethod valueMethod;

	// Token: 0x040002B8 RID: 696
	public AnimationCurve curveValue;

	// Token: 0x040002B9 RID: 697
	public bool isEnertia;

	// Token: 0x040002BA RID: 698
	public float inertia;

	// Token: 0x040002BB RID: 699
	public float inertiaThreshold;

	// Token: 0x040002BC RID: 700
	public bool isAutoStab;

	// Token: 0x040002BD RID: 701
	public float autoStabThreshold;

	// Token: 0x040002BE RID: 702
	public float autoStabSpeed;

	// Token: 0x040002BF RID: 703
	private float startAngle;

	// Token: 0x040002C0 RID: 704
	public bool isClampRotation;

	// Token: 0x040002C1 RID: 705
	public float maxAngle;

	// Token: 0x040002C2 RID: 706
	public float minAngle;

	// Token: 0x040002C3 RID: 707
	public bool isValueOverTime;

	// Token: 0x040002C4 RID: 708
	public float overTimeStep;

	// Token: 0x040002C5 RID: 709
	public float maxOverTimeValue;

	// Token: 0x040002C6 RID: 710
	public float axisValue;

	// Token: 0x040002C7 RID: 711
	public float axisSpeedValue;

	// Token: 0x040002C8 RID: 712
	public float axisThreshold;

	// Token: 0x040002C9 RID: 713
	public bool isLockinJump;

	// Token: 0x040002CA RID: 714
	private Vector3 lastMove;

	// Token: 0x040002CB RID: 715
	public ETCAxis.AxisState axisState;

	// Token: 0x040002CC RID: 716
	[SerializeField]
	private Transform _directTransform;

	// Token: 0x040002CD RID: 717
	public ETCAxis.DirectAction directAction;

	// Token: 0x040002CE RID: 718
	public ETCAxis.AxisInfluenced axisInfluenced;

	// Token: 0x040002CF RID: 719
	public ETCAxis.ActionOn actionOn;

	// Token: 0x040002D0 RID: 720
	public CharacterController directCharacterController;

	// Token: 0x040002D1 RID: 721
	public Rigidbody directRigidBody;

	// Token: 0x040002D2 RID: 722
	public float gravity;

	// Token: 0x040002D3 RID: 723
	public float currentGravity;

	// Token: 0x040002D4 RID: 724
	public bool isJump;

	// Token: 0x040002D5 RID: 725
	public string unityAxis;

	// Token: 0x040002D6 RID: 726
	public bool showGeneralInspector;

	// Token: 0x040002D7 RID: 727
	public bool showDirectInspector;

	// Token: 0x040002D8 RID: 728
	public bool showInertiaInspector;

	// Token: 0x040002D9 RID: 729
	public bool showSimulatinInspector;

	// Token: 0x020000B7 RID: 183
	public enum DirectAction
	{
		// Token: 0x040002DB RID: 731
		Rotate,
		// Token: 0x040002DC RID: 732
		RotateLocal,
		// Token: 0x040002DD RID: 733
		Translate,
		// Token: 0x040002DE RID: 734
		TranslateLocal,
		// Token: 0x040002DF RID: 735
		Scale,
		// Token: 0x040002E0 RID: 736
		Force,
		// Token: 0x040002E1 RID: 737
		RelativeForce,
		// Token: 0x040002E2 RID: 738
		Torque,
		// Token: 0x040002E3 RID: 739
		RelativeTorque,
		// Token: 0x040002E4 RID: 740
		Jump
	}

	// Token: 0x020000B8 RID: 184
	public enum AxisInfluenced
	{
		// Token: 0x040002E6 RID: 742
		X,
		// Token: 0x040002E7 RID: 743
		Y,
		// Token: 0x040002E8 RID: 744
		Z
	}

	// Token: 0x020000B9 RID: 185
	public enum AxisValueMethod
	{
		// Token: 0x040002EA RID: 746
		Classical,
		// Token: 0x040002EB RID: 747
		Curve
	}

	// Token: 0x020000BA RID: 186
	public enum AxisState
	{
		// Token: 0x040002ED RID: 749
		None,
		// Token: 0x040002EE RID: 750
		Down,
		// Token: 0x040002EF RID: 751
		Press,
		// Token: 0x040002F0 RID: 752
		Up,
		// Token: 0x040002F1 RID: 753
		DownUp,
		// Token: 0x040002F2 RID: 754
		DownDown,
		// Token: 0x040002F3 RID: 755
		DownLeft,
		// Token: 0x040002F4 RID: 756
		DownRight,
		// Token: 0x040002F5 RID: 757
		PressUp,
		// Token: 0x040002F6 RID: 758
		PressDown,
		// Token: 0x040002F7 RID: 759
		PressLeft,
		// Token: 0x040002F8 RID: 760
		PressRight
	}

	// Token: 0x020000BB RID: 187
	public enum ActionOn
	{
		// Token: 0x040002FA RID: 762
		Down,
		// Token: 0x040002FB RID: 763
		Press
	}
}
