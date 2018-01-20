using System;
using System.Collections.Generic;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	// Token: 0x02000023 RID: 35
	[AddComponentMenu("DOTween/DOTween Animation")]
	public class DOTweenAnimation : ABSAnimationComponent
	{
		// Token: 0x06000154 RID: 340 RVA: 0x00007457 File Offset: 0x00005857
		private void Awake()
		{
			if (!this.isActive || !this.isValid)
			{
				return;
			}
			if (this.animationType != DOTweenAnimationType.Move || !this.useTargetAsV3)
			{
				this.CreateTween();
				this._tweenCreated = true;
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00007494 File Offset: 0x00005894
		private void Start()
		{
			if (this._tweenCreated || !this.isActive || !this.isValid)
			{
				return;
			}
			this.CreateTween();
			this._tweenCreated = true;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000074C5 File Offset: 0x000058C5
		private void OnDestroy()
		{
			if (this.tween != null && this.tween.IsActive())
			{
				this.tween.Kill(false);
			}
			this.tween = null;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000074F8 File Offset: 0x000058F8
		public void CreateTween()
		{
			if (this.target == null)
			{
				Debug.LogWarning(string.Format("{0} :: This tween's target is NULL, because the animation was created with a DOTween Pro version older than 0.9.255. To fix this, exit Play mode then simply select this object, and it will update automatically", base.gameObject.name), base.gameObject);
				return;
			}
			if (this.forcedTargetType != TargetType.Unset)
			{
				this.targetType = this.forcedTargetType;
			}
			if (this.targetType == TargetType.Unset)
			{
				this.targetType = DOTweenAnimation.TypeToDOTargetType(this.target.GetType());
			}
			switch (this.animationType)
			{
			case DOTweenAnimationType.Move:
				if (this.useTargetAsV3)
				{
					this.isRelative = false;
					if (this.endValueTransform == null)
					{
						Debug.LogWarning(string.Format("{0} :: This tween's TO target is NULL, a Vector3 of (0,0,0) will be used instead", base.gameObject.name), base.gameObject);
						this.endValueV3 = Vector3.zero;
					}
					else if (this.targetType == TargetType.RectTransform)
					{
						RectTransform rectTransform = this.endValueTransform as RectTransform;
						if (rectTransform == null)
						{
							Debug.LogWarning(string.Format("{0} :: This tween's TO target should be a RectTransform, a Vector3 of (0,0,0) will be used instead", base.gameObject.name), base.gameObject);
							this.endValueV3 = Vector3.zero;
						}
						else
						{
							RectTransform rectTransform2 = this.target as RectTransform;
							if (rectTransform2 == null)
							{
								Debug.LogWarning(string.Format("{0} :: This tween's target and TO target are not of the same type. Please reassign the values", base.gameObject.name), base.gameObject);
							}
							else
							{
								this.endValueV3 = DOTweenUtils46.SwitchToRectTransform(rectTransform, rectTransform2);
							}
						}
					}
					else
					{
						this.endValueV3 = this.endValueTransform.position;
					}
				}
				switch (this.targetType)
				{
				case TargetType.RectTransform:
					this.tween = ((RectTransform)this.target).DOAnchorPos3D(this.endValueV3, this.duration, this.optionalBool0);
					break;
				case TargetType.Rigidbody:
					this.tween = ((Rigidbody)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
					break;
				case TargetType.Rigidbody2D:
					this.tween = ((Rigidbody2D)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
					break;
				case TargetType.Transform:
					this.tween = ((Transform)this.target).DOMove(this.endValueV3, this.duration, this.optionalBool0);
					break;
				}
				break;
			case DOTweenAnimationType.LocalMove:
				this.tween = base.transform.DOLocalMove(this.endValueV3, this.duration, this.optionalBool0);
				break;
			case DOTweenAnimationType.Rotate:
			{
				TargetType targetType = this.targetType;
				if (targetType != TargetType.Transform)
				{
					if (targetType != TargetType.Rigidbody2D)
					{
						if (targetType == TargetType.Rigidbody)
						{
							this.tween = ((Rigidbody)this.target).DORotate(this.endValueV3, this.duration, this.optionalRotationMode);
						}
					}
					else
					{
						this.tween = ((Rigidbody2D)this.target).DORotate(this.endValueFloat, this.duration);
					}
				}
				else
				{
					this.tween = ((Transform)this.target).DORotate(this.endValueV3, this.duration, this.optionalRotationMode);
				}
				break;
			}
			case DOTweenAnimationType.LocalRotate:
				this.tween = base.transform.DOLocalRotate(this.endValueV3, this.duration, this.optionalRotationMode);
				break;
			case DOTweenAnimationType.Scale:
				this.tween = base.transform.DOScale((!this.optionalBool0) ? this.endValueV3 : new Vector3(this.endValueFloat, this.endValueFloat, this.endValueFloat), this.duration);
				break;
			case DOTweenAnimationType.Color:
				this.isRelative = false;
				switch (this.targetType)
				{
				case TargetType.Image:
					this.tween = ((Image)this.target).DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.Light:
					this.tween = ((Light)this.target).DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.Renderer:
					this.tween = ((Renderer)this.target).material.DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.SpriteRenderer:
					this.tween = ((SpriteRenderer)this.target).DOColor(this.endValueColor, this.duration);
					break;
				case TargetType.Text:
					this.tween = ((Text)this.target).DOColor(this.endValueColor, this.duration);
					break;
				}
				break;
			case DOTweenAnimationType.Fade:
				this.isRelative = false;
				switch (this.targetType)
				{
				case TargetType.CanvasGroup:
					this.tween = ((CanvasGroup)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.Image:
					this.tween = ((Image)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.Light:
					this.tween = ((Light)this.target).DOIntensity(this.endValueFloat, this.duration);
					break;
				case TargetType.Renderer:
					this.tween = ((Renderer)this.target).material.DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.SpriteRenderer:
					this.tween = ((SpriteRenderer)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				case TargetType.Text:
					this.tween = ((Text)this.target).DOFade(this.endValueFloat, this.duration);
					break;
				}
				break;
			case DOTweenAnimationType.Text:
			{
				TargetType targetType2 = this.targetType;
				if (targetType2 == TargetType.Text)
				{
					this.tween = ((Text)this.target).DOText(this.endValueString, this.duration, this.optionalBool0, this.optionalScrambleMode, this.optionalString);
				}
				break;
			}
			case DOTweenAnimationType.PunchPosition:
			{
				TargetType targetType3 = this.targetType;
				if (targetType3 != TargetType.RectTransform)
				{
					if (targetType3 == TargetType.Transform)
					{
						this.tween = ((Transform)this.target).DOPunchPosition(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
					}
				}
				else
				{
					this.tween = ((RectTransform)this.target).DOPunchAnchorPos(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0, this.optionalBool0);
				}
				break;
			}
			case DOTweenAnimationType.PunchRotation:
				this.tween = base.transform.DOPunchRotation(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0);
				break;
			case DOTweenAnimationType.PunchScale:
				this.tween = base.transform.DOPunchScale(this.endValueV3, this.duration, this.optionalInt0, this.optionalFloat0);
				break;
			case DOTweenAnimationType.ShakePosition:
			{
				TargetType targetType4 = this.targetType;
				if (targetType4 != TargetType.RectTransform)
				{
					if (targetType4 == TargetType.Transform)
					{
						this.tween = ((Transform)this.target).DOShakePosition(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, this.optionalBool0, true);
					}
				}
				else
				{
					this.tween = ((RectTransform)this.target).DOShakeAnchorPos(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, this.optionalBool0, true);
				}
				break;
			}
			case DOTweenAnimationType.ShakeRotation:
				this.tween = base.transform.DOShakeRotation(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, true);
				break;
			case DOTweenAnimationType.ShakeScale:
				this.tween = base.transform.DOShakeScale(this.duration, this.endValueV3, this.optionalInt0, this.optionalFloat0, true);
				break;
			case DOTweenAnimationType.CameraAspect:
				this.tween = ((Camera)this.target).DOAspect(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraBackgroundColor:
				this.tween = ((Camera)this.target).DOColor(this.endValueColor, this.duration);
				break;
			case DOTweenAnimationType.CameraFieldOfView:
				this.tween = ((Camera)this.target).DOFieldOfView(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraOrthoSize:
				this.tween = ((Camera)this.target).DOOrthoSize(this.endValueFloat, this.duration);
				break;
			case DOTweenAnimationType.CameraPixelRect:
				this.tween = ((Camera)this.target).DOPixelRect(this.endValueRect, this.duration);
				break;
			case DOTweenAnimationType.CameraRect:
				this.tween = ((Camera)this.target).DORect(this.endValueRect, this.duration);
				break;
			case DOTweenAnimationType.UIWidthHeight:
				this.tween = ((RectTransform)this.target).DOSizeDelta((!this.optionalBool0) ? this.endValueV2 : new Vector2(this.endValueFloat, this.endValueFloat), this.duration, false);
				break;
			}
			if (this.tween == null)
			{
				return;
			}
			if (this.isFrom)
			{
				((Tweener)this.tween).From(this.isRelative);
			}
			else
			{
				this.tween.SetRelative(this.isRelative);
			}
			this.tween.SetTarget(base.gameObject).SetDelay(this.delay).SetLoops(this.loops, this.loopType).SetAutoKill(this.autoKill).OnKill(delegate
			{
				this.tween = null;
			});
			if (this.isSpeedBased)
			{
				this.tween.SetSpeedBased<Tween>();
			}
			if (this.easeType == Ease.INTERNAL_Custom)
			{
				this.tween.SetEase(this.easeCurve);
			}
			else
			{
				this.tween.SetEase(this.easeType);
			}
			if (!string.IsNullOrEmpty(this.id))
			{
				this.tween.SetId(this.id);
			}
			this.tween.SetUpdate(this.isIndependentUpdate);
			if (this.hasOnStart)
			{
				if (this.onStart != null)
				{
					this.tween.OnStart(new TweenCallback(this.onStart.Invoke));
				}
			}
			else
			{
				this.onStart = null;
			}
			if (this.hasOnPlay)
			{
				if (this.onPlay != null)
				{
					this.tween.OnPlay(new TweenCallback(this.onPlay.Invoke));
				}
			}
			else
			{
				this.onPlay = null;
			}
			if (this.hasOnUpdate)
			{
				if (this.onUpdate != null)
				{
					this.tween.OnUpdate(new TweenCallback(this.onUpdate.Invoke));
				}
			}
			else
			{
				this.onUpdate = null;
			}
			if (this.hasOnStepComplete)
			{
				if (this.onStepComplete != null)
				{
					this.tween.OnStepComplete(new TweenCallback(this.onStepComplete.Invoke));
				}
			}
			else
			{
				this.onStepComplete = null;
			}
			if (this.hasOnComplete)
			{
				if (this.onComplete != null)
				{
					this.tween.OnComplete(new TweenCallback(this.onComplete.Invoke));
				}
			}
			else
			{
				this.onComplete = null;
			}
			if (this.hasOnRewind)
			{
				if (this.onRewind != null)
				{
					this.tween.OnRewind(new TweenCallback(this.onRewind.Invoke));
				}
			}
			else
			{
				this.onRewind = null;
			}
			if (this.autoPlay)
			{
				this.tween.Play<Tween>();
			}
			else
			{
				this.tween.Pause<Tween>();
			}
			if (this.hasOnTweenCreated && this.onTweenCreated != null)
			{
				this.onTweenCreated.Invoke();
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000081AC File Offset: 0x000065AC
		public override void DOPlay()
		{
			DOTween.Play(base.gameObject);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000081BA File Offset: 0x000065BA
		public override void DOPlayBackwards()
		{
			DOTween.PlayBackwards(base.gameObject);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000081C8 File Offset: 0x000065C8
		public override void DOPlayForward()
		{
			DOTween.PlayForward(base.gameObject);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000081D6 File Offset: 0x000065D6
		public override void DOPause()
		{
			DOTween.Pause(base.gameObject);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000081E4 File Offset: 0x000065E4
		public override void DOTogglePause()
		{
			DOTween.TogglePause(base.gameObject);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000081F4 File Offset: 0x000065F4
		public override void DORewind()
		{
			this._playCount = -1;
			DOTweenAnimation[] components = base.gameObject.GetComponents<DOTweenAnimation>();
			for (int i = components.Length - 1; i > -1; i--)
			{
				Tween tween = components[i].tween;
				if (tween != null && tween.IsInitialized())
				{
					components[i].tween.Rewind(true);
				}
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00008254 File Offset: 0x00006654
		public override void DORestart(bool fromHere = false)
		{
			this._playCount = -1;
			if (this.tween == null)
			{
				if (Debugger.logPriority > 1)
				{
					Debugger.LogNullTween(this.tween);
				}
				return;
			}
			if (fromHere && this.isRelative)
			{
				this.ReEvaluateRelativeTween();
			}
			DOTween.Restart(base.gameObject, true, -1f);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x000082B3 File Offset: 0x000066B3
		public override void DOComplete()
		{
			DOTween.Complete(base.gameObject, false);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000082C2 File Offset: 0x000066C2
		public override void DOKill()
		{
			DOTween.Kill(base.gameObject, false);
			this.tween = null;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000082D8 File Offset: 0x000066D8
		public void DOPlayById(string id)
		{
			DOTween.Play(base.gameObject, id);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000082E7 File Offset: 0x000066E7
		public void DOPlayAllById(string id)
		{
			DOTween.Play(id);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000082F0 File Offset: 0x000066F0
		public void DOPauseAllById(string id)
		{
			DOTween.Pause(id);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000082F9 File Offset: 0x000066F9
		public void DOPlayBackwardsById(string id)
		{
			DOTween.PlayBackwards(base.gameObject, id);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00008308 File Offset: 0x00006708
		public void DOPlayBackwardsAllById(string id)
		{
			DOTween.PlayBackwards(id);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00008311 File Offset: 0x00006711
		public void DOPlayForwardById(string id)
		{
			DOTween.PlayForward(base.gameObject, id);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00008320 File Offset: 0x00006720
		public void DOPlayForwardAllById(string id)
		{
			DOTween.PlayForward(id);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000832C File Offset: 0x0000672C
		public void DOPlayNext()
		{
			DOTweenAnimation[] components = base.GetComponents<DOTweenAnimation>();
			while (this._playCount < components.Length - 1)
			{
				this._playCount++;
				DOTweenAnimation dotweenAnimation = components[this._playCount];
				if (dotweenAnimation != null && dotweenAnimation.tween != null && !dotweenAnimation.tween.IsPlaying() && !dotweenAnimation.tween.IsComplete())
				{
					dotweenAnimation.tween.Play<Tween>();
					break;
				}
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000083B4 File Offset: 0x000067B4
		public void DORewindAndPlayNext()
		{
			this._playCount = -1;
			DOTween.Rewind(base.gameObject, true);
			this.DOPlayNext();
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000083D0 File Offset: 0x000067D0
		public void DORestartById(string id)
		{
			this._playCount = -1;
			DOTween.Restart(base.gameObject, id, true, -1f);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000083EC File Offset: 0x000067EC
		public void DORestartAllById(string id)
		{
			this._playCount = -1;
			DOTween.Restart(id, true, -1f);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00008404 File Offset: 0x00006804
		public List<Tween> GetTweens()
		{
			List<Tween> list = new List<Tween>();
			DOTweenAnimation[] components = base.GetComponents<DOTweenAnimation>();
			foreach (DOTweenAnimation dotweenAnimation in components)
			{
				list.Add(dotweenAnimation.tween);
			}
			return list;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000844C File Offset: 0x0000684C
		public static TargetType TypeToDOTargetType(Type t)
		{
			string text = t.ToString();
			int num = text.LastIndexOf(".");
			if (num != -1)
			{
				text = text.Substring(num + 1);
			}
			if (text.IndexOf("Renderer") != -1 && text != "SpriteRenderer")
			{
				text = "Renderer";
			}
			return (TargetType)Enum.Parse(typeof(TargetType), text);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000084BC File Offset: 0x000068BC
		private void ReEvaluateRelativeTween()
		{
			if (this.animationType == DOTweenAnimationType.Move)
			{
				((Tweener)this.tween).ChangeEndValue(base.transform.position + this.endValueV3, true);
			}
			else if (this.animationType == DOTweenAnimationType.LocalMove)
			{
				((Tweener)this.tween).ChangeEndValue(base.transform.localPosition + this.endValueV3, true);
			}
		}

		// Token: 0x04000092 RID: 146
		public float delay;

		// Token: 0x04000093 RID: 147
		public float duration = 1f;

		// Token: 0x04000094 RID: 148
		public Ease easeType = Ease.OutQuad;

		// Token: 0x04000095 RID: 149
		public AnimationCurve easeCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04000096 RID: 150
		public LoopType loopType;

		// Token: 0x04000097 RID: 151
		public int loops = 1;

		// Token: 0x04000098 RID: 152
		public string id = string.Empty;

		// Token: 0x04000099 RID: 153
		public bool isRelative;

		// Token: 0x0400009A RID: 154
		public bool isFrom;

		// Token: 0x0400009B RID: 155
		public bool isIndependentUpdate;

		// Token: 0x0400009C RID: 156
		public bool autoKill = true;

		// Token: 0x0400009D RID: 157
		public bool isActive = true;

		// Token: 0x0400009E RID: 158
		public bool isValid;

		// Token: 0x0400009F RID: 159
		public Component target;

		// Token: 0x040000A0 RID: 160
		public DOTweenAnimationType animationType;

		// Token: 0x040000A1 RID: 161
		public TargetType targetType;

		// Token: 0x040000A2 RID: 162
		public TargetType forcedTargetType;

		// Token: 0x040000A3 RID: 163
		public bool autoPlay = true;

		// Token: 0x040000A4 RID: 164
		public bool useTargetAsV3;

		// Token: 0x040000A5 RID: 165
		public float endValueFloat;

		// Token: 0x040000A6 RID: 166
		public Vector3 endValueV3;

		// Token: 0x040000A7 RID: 167
		public Vector2 endValueV2;

		// Token: 0x040000A8 RID: 168
		public Color endValueColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x040000A9 RID: 169
		public string endValueString = string.Empty;

		// Token: 0x040000AA RID: 170
		public Rect endValueRect = new Rect(0f, 0f, 0f, 0f);

		// Token: 0x040000AB RID: 171
		public Transform endValueTransform;

		// Token: 0x040000AC RID: 172
		public bool optionalBool0;

		// Token: 0x040000AD RID: 173
		public float optionalFloat0;

		// Token: 0x040000AE RID: 174
		public int optionalInt0;

		// Token: 0x040000AF RID: 175
		public RotateMode optionalRotationMode;

		// Token: 0x040000B0 RID: 176
		public ScrambleMode optionalScrambleMode;

		// Token: 0x040000B1 RID: 177
		public string optionalString;

		// Token: 0x040000B2 RID: 178
		private bool _tweenCreated;

		// Token: 0x040000B3 RID: 179
		private int _playCount = -1;
	}
}
