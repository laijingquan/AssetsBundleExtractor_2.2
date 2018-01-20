using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000D6 RID: 214
public class ETCInput : MonoBehaviour
{
	// Token: 0x17000040 RID: 64
	// (get) Token: 0x060004F7 RID: 1271 RVA: 0x00018368 File Offset: 0x00016768
	public static ETCInput instance
	{
		get
		{
			if (!ETCInput._instance)
			{
				ETCInput._instance = (UnityEngine.Object.FindObjectOfType(typeof(ETCInput)) as ETCInput);
				if (!ETCInput._instance)
				{
					GameObject gameObject = new GameObject("InputManager");
					ETCInput._instance = gameObject.AddComponent<ETCInput>();
				}
			}
			return ETCInput._instance;
		}
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x000183C8 File Offset: 0x000167C8
	public void RegisterControl(ETCBase ctrl)
	{
		if (this.controls.ContainsKey(ctrl.name))
		{
			Debug.LogWarning("ETCInput control : " + ctrl.name + " already exists");
		}
		else
		{
			this.controls.Add(ctrl.name, ctrl);
			if (ctrl.GetType() == typeof(ETCJoystick))
			{
				this.RegisterAxis((ctrl as ETCJoystick).axisX);
				this.RegisterAxis((ctrl as ETCJoystick).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCTouchPad))
			{
				this.RegisterAxis((ctrl as ETCTouchPad).axisX);
				this.RegisterAxis((ctrl as ETCTouchPad).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCDPad))
			{
				this.RegisterAxis((ctrl as ETCDPad).axisX);
				this.RegisterAxis((ctrl as ETCDPad).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCButton))
			{
				this.RegisterAxis((ctrl as ETCButton).axis);
			}
		}
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x000184F8 File Offset: 0x000168F8
	public void UnRegisterControl(ETCBase ctrl)
	{
		if (this.controls.ContainsKey(ctrl.name) && ctrl.enabled)
		{
			this.controls.Remove(ctrl.name);
			if (ctrl.GetType() == typeof(ETCJoystick))
			{
				this.UnRegisterAxis((ctrl as ETCJoystick).axisX);
				this.UnRegisterAxis((ctrl as ETCJoystick).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCTouchPad))
			{
				this.UnRegisterAxis((ctrl as ETCTouchPad).axisX);
				this.UnRegisterAxis((ctrl as ETCTouchPad).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCDPad))
			{
				this.UnRegisterAxis((ctrl as ETCDPad).axisX);
				this.UnRegisterAxis((ctrl as ETCDPad).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCButton))
			{
				this.UnRegisterAxis((ctrl as ETCButton).axis);
			}
		}
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x00018612 File Offset: 0x00016A12
	public void Create()
	{
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x00018614 File Offset: 0x00016A14
	public static void Register(ETCBase ctrl)
	{
		ETCInput.instance.RegisterControl(ctrl);
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x00018621 File Offset: 0x00016A21
	public static void UnRegister(ETCBase ctrl)
	{
		ETCInput.instance.UnRegisterControl(ctrl);
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x00018630 File Offset: 0x00016A30
	public static void SetControlVisible(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.visible = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x0001867C File Offset: 0x00016A7C
	public static bool GetControlVisible(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.visible;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return false;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x000186BC File Offset: 0x00016ABC
	public static void SetControlActivated(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.activated = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x00018708 File Offset: 0x00016B08
	public static bool GetControlActivated(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.activated;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return false;
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x00018748 File Offset: 0x00016B48
	public static void SetControlSwipeIn(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.isSwipeIn = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00018794 File Offset: 0x00016B94
	public static bool GetControlSwipeIn(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.isSwipeIn;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return false;
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x000187D4 File Offset: 0x00016BD4
	public static void SetControlSwipeOut(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.isSwipeOut = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x00018820 File Offset: 0x00016C20
	public static bool GetControlSwipeOut(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.isSwipeOut;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return false;
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x00018860 File Offset: 0x00016C60
	public static void SetDPadAxesCount(string ctrlName, ETCBase.DPadAxis value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.dPadAxisCount = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x000188AC File Offset: 0x00016CAC
	public static ETCBase.DPadAxis GetDPadAxesCount(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.dPadAxisCount;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return ETCBase.DPadAxis.Two_Axis;
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x000188EC File Offset: 0x00016CEC
	public static ETCJoystick GetControlJoystick(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCJoystick))
		{
			return (ETCJoystick)ETCInput.control;
		}
		return null;
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x0001893C File Offset: 0x00016D3C
	public static ETCDPad GetControlDPad(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCDPad))
		{
			return (ETCDPad)ETCInput.control;
		}
		return null;
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x0001898C File Offset: 0x00016D8C
	public static ETCTouchPad GetControlTouchPad(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCTouchPad))
		{
			return (ETCTouchPad)ETCInput.control;
		}
		return null;
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x000189DC File Offset: 0x00016DDC
	public static ETCButton GetControlButton(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCJoystick))
		{
			return (ETCButton)ETCInput.control;
		}
		return null;
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x00018A2C File Offset: 0x00016E2C
	public static void SetControlSprite(string ctrlName, Sprite spr, Color color = default(Color))
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			Image component = ETCInput.control.GetComponent<Image>();
			if (component)
			{
				component.sprite = spr;
				component.color = color;
			}
		}
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00018A78 File Offset: 0x00016E78
	public static void SetJoystickThumbSprite(string ctrlName, Sprite spr, Color color = default(Color))
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCJoystick))
		{
			ETCJoystick etcjoystick = (ETCJoystick)ETCInput.control;
			if (etcjoystick)
			{
				Image component = etcjoystick.thumb.GetComponent<Image>();
				if (component)
				{
					component.sprite = spr;
					component.color = color;
				}
			}
		}
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x00018AF4 File Offset: 0x00016EF4
	public static void SetButtonSprite(string ctrlName, Sprite sprNormal, Sprite sprPress, Color color = default(Color))
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCButton component = ETCInput.control.GetComponent<ETCButton>();
			component.normalSprite = sprNormal;
			component.normalColor = color;
			component.pressedColor = color;
			component.pressedSprite = sprPress;
			ETCInput.SetControlSprite(ctrlName, sprNormal, color);
		}
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x00018B4C File Offset: 0x00016F4C
	public static void SetAxisSpeed(string axisName, float speed)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.speed = speed;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x00018B98 File Offset: 0x00016F98
	public static void SetAxisGravity(string axisName, float gravity)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.gravity = gravity;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x00018BE4 File Offset: 0x00016FE4
	public static void SetTurnMoveSpeed(string ctrlName, float speed)
	{
		ETCJoystick controlJoystick = ETCInput.GetControlJoystick(ctrlName);
		if (controlJoystick)
		{
			controlJoystick.tmSpeed = speed;
		}
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x00018C0C File Offset: 0x0001700C
	public static void ResetAxis(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.axisValue = 0f;
			ETCInput.axis.axisSpeedValue = 0f;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x00018C6C File Offset: 0x0001706C
	public static void SetAxisEnabled(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.enable = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x00018CB8 File Offset: 0x000170B8
	public static bool GetAxisEnabled(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.enable;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00018CF8 File Offset: 0x000170F8
	public static void SetAxisInverted(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.invertedAxis = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x00018D44 File Offset: 0x00017144
	public static bool GetAxisInverted(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.invertedAxis;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00018D84 File Offset: 0x00017184
	public static void SetAxisDeadValue(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.deadValue = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x00018DD0 File Offset: 0x000171D0
	public static float GetAxisDeadValue(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.deadValue;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x00018E1C File Offset: 0x0001721C
	public static void SetAxisSensitivity(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.speed = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x00018E68 File Offset: 0x00017268
	public static float GetAxisSensitivity(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.speed;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x00018EB4 File Offset: 0x000172B4
	public static void SetAxisThreshold(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.axisThreshold = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00018F00 File Offset: 0x00017300
	public static float GetAxisThreshold(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisThreshold;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00018F4C File Offset: 0x0001734C
	public static void SetAxisInertia(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.isEnertia = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00018F98 File Offset: 0x00017398
	public static bool GetAxisInertia(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.isEnertia;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00018FD8 File Offset: 0x000173D8
	public static void SetAxisInertiaSpeed(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.inertia = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x00019024 File Offset: 0x00017424
	public static float GetAxisInertiaSpeed(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.inertia;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x00019070 File Offset: 0x00017470
	public static void SetAxisInertiaThreshold(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.inertiaThreshold = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x000190BC File Offset: 0x000174BC
	public static float GetAxisInertiaThreshold(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.inertiaThreshold;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x00019108 File Offset: 0x00017508
	public static void SetAxisAutoStabilization(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.isAutoStab = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x00019154 File Offset: 0x00017554
	public static bool GetAxisAutoStabilization(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.isAutoStab;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x00019194 File Offset: 0x00017594
	public static void SetAxisAutoStabilizationSpeed(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.autoStabSpeed = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x000191E0 File Offset: 0x000175E0
	public static float GetAxisAutoStabilizationSpeed(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.autoStabSpeed;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x0001922C File Offset: 0x0001762C
	public static void SetAxisAutoStabilizationThreshold(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.autoStabThreshold = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000527 RID: 1319 RVA: 0x00019278 File Offset: 0x00017678
	public static float GetAxisAutoStabilizationThreshold(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.autoStabThreshold;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x000192C4 File Offset: 0x000176C4
	public static void SetAxisClampRotation(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.isClampRotation = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x00019310 File Offset: 0x00017710
	public static bool GetAxisClampRotation(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.isClampRotation;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x00019350 File Offset: 0x00017750
	public static void SetAxisClampRotationValue(string axisName, float min, float max)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.minAngle = min;
			ETCInput.axis.maxAngle = max;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x000193A8 File Offset: 0x000177A8
	public static void SetAxisClampRotationMinValue(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.minAngle = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x000193F4 File Offset: 0x000177F4
	public static void SetAxisClampRotationMaxValue(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.maxAngle = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x00019440 File Offset: 0x00017840
	public static float GetAxisClampRotationMinValue(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.minAngle;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x0001948C File Offset: 0x0001788C
	public static float GetAxisClampRotationMaxValue(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.maxAngle;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x000194D8 File Offset: 0x000178D8
	public static void SetAxisDirecTransform(string axisName, Transform value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.directTransform = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x00019524 File Offset: 0x00017924
	public static Transform GetAxisDirectTransform(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.directTransform;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return null;
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x00019564 File Offset: 0x00017964
	public static void SetAxisDirectAction(string axisName, ETCAxis.DirectAction value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.directAction = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x000195B0 File Offset: 0x000179B0
	public static ETCAxis.DirectAction GetAxisDirectAction(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.directAction;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return ETCAxis.DirectAction.Rotate;
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x000195F0 File Offset: 0x000179F0
	public static void SetAxisAffectedAxis(string axisName, ETCAxis.AxisInfluenced value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.axisInfluenced = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x0001963C File Offset: 0x00017A3C
	public static ETCAxis.AxisInfluenced GetAxisAffectedAxis(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisInfluenced;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return ETCAxis.AxisInfluenced.X;
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x0001967C File Offset: 0x00017A7C
	public static void SetAxisOverTime(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.isValueOverTime = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x000196C8 File Offset: 0x00017AC8
	public static bool GetAxisOverTime(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.isValueOverTime;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x00019708 File Offset: 0x00017B08
	public static void SetAxisOverTimeStep(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.overTimeStep = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x00019754 File Offset: 0x00017B54
	public static float GetAxisOverTimeStep(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.overTimeStep;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x000197A0 File Offset: 0x00017BA0
	public static void SetAxisOverTimeMaxValue(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.maxOverTimeValue = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x000197EC File Offset: 0x00017BEC
	public static float GetAxisOverTimeMaxValue(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.maxOverTimeValue;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x00019838 File Offset: 0x00017C38
	public static float GetAxis(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisValue;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return 0f;
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x00019884 File Offset: 0x00017C84
	public static float GetAxisSpeed(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisSpeedValue;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return 0f;
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x000198C0 File Offset: 0x00017CC0
	public static bool GetAxisDownUp(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.DownUp;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x0001990C File Offset: 0x00017D0C
	public static bool GetAxisDownDown(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.DownDown;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x00019958 File Offset: 0x00017D58
	public static bool GetAxisDownRight(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.DownRight;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x000199A4 File Offset: 0x00017DA4
	public static bool GetAxisDownLeft(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.DownLeft;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x000199F0 File Offset: 0x00017DF0
	public static bool GetAxisPressedUp(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.PressUp;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x00019A3C File Offset: 0x00017E3C
	public static bool GetAxisPressedDown(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.PressDown;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00019A8C File Offset: 0x00017E8C
	public static bool GetAxisPressedRight(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.PressRight;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x00019ADC File Offset: 0x00017EDC
	public static bool GetAxisPressedLeft(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.PressLeft;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x00019B2C File Offset: 0x00017F2C
	public static bool GetButtonDown(string buttonName)
	{
		if (ETCInput.instance.axes.TryGetValue(buttonName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.Down;
		}
		Debug.LogWarning(buttonName + " doesn't exist");
		return false;
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x00019B78 File Offset: 0x00017F78
	public static bool GetButton(string buttonName)
	{
		if (ETCInput.instance.axes.TryGetValue(buttonName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.Down || ETCInput.axis.axisState == ETCAxis.AxisState.Press;
		}
		Debug.LogWarning(buttonName + " doesn't exist");
		return false;
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x00019BD4 File Offset: 0x00017FD4
	public static bool GetButtonUp(string buttonName)
	{
		if (ETCInput.instance.axes.TryGetValue(buttonName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.Up;
		}
		Debug.LogWarning(buttonName + " doesn't exist");
		return false;
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x00019C20 File Offset: 0x00018020
	public static float GetButtonValue(string buttonName)
	{
		if (ETCInput.instance.axes.TryGetValue(buttonName, out ETCInput.axis))
		{
			return ETCInput.axis.axisValue;
		}
		Debug.LogWarning(buttonName + " doesn't exist");
		return -1f;
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x00019C5C File Offset: 0x0001805C
	private void RegisterAxis(ETCAxis axis)
	{
		if (ETCInput.instance.axes.ContainsKey(axis.name))
		{
			Debug.LogWarning("ETCInput axis : " + axis.name + " already exists");
		}
		else
		{
			this.axes.Add(axis.name, axis);
		}
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x00019CB4 File Offset: 0x000180B4
	private void UnRegisterAxis(ETCAxis axis)
	{
		if (ETCInput.instance.axes.ContainsKey(axis.name))
		{
			this.axes.Remove(axis.name);
		}
	}

	// Token: 0x0400036B RID: 875
	public static ETCInput _instance;

	// Token: 0x0400036C RID: 876
	private Dictionary<string, ETCAxis> axes = new Dictionary<string, ETCAxis>();

	// Token: 0x0400036D RID: 877
	private Dictionary<string, ETCBase> controls = new Dictionary<string, ETCBase>();

	// Token: 0x0400036E RID: 878
	private static ETCBase control;

	// Token: 0x0400036F RID: 879
	private static ETCAxis axis;
}
