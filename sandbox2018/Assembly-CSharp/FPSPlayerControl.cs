using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000AC RID: 172
public class FPSPlayerControl : MonoBehaviour
{
	// Token: 0x0600046F RID: 1135 RVA: 0x00014893 File Offset: 0x00012C93
	private void Awake()
	{
		this.anim = base.GetComponentInChildren<Animator>();
		this.audioSource = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x000148B0 File Offset: 0x00012CB0
	private void Update()
	{
		if (ETCInput.GetButton("Fire") && !this.inFire && this.armoCount > 0 && !this.inReload)
		{
			this.inFire = true;
			this.anim.SetBool("Shoot", true);
			base.InvokeRepeating("GunFire", 0.12f, 0.12f);
			this.GunFire();
		}
		if (ETCInput.GetButtonDown("Fire") && this.armoCount == 0 && !this.inReload)
		{
			this.audioSource.PlayOneShot(this.needReload, 1f);
		}
		if (ETCInput.GetButtonUp("Fire"))
		{
			this.anim.SetBool("Shoot", false);
			this.muzzleEffect.SetActive(false);
			this.inFire = false;
			base.CancelInvoke();
		}
		if (ETCInput.GetButtonDown("Reload"))
		{
			this.inReload = true;
			this.audioSource.PlayOneShot(this.reload, 1f);
			this.anim.SetBool("Reload", true);
			base.StartCoroutine(this.Reload());
		}
		if (ETCInput.GetButtonDown("Back"))
		{
			base.transform.Rotate(Vector3.up * 180f);
		}
		this.armoText.text = this.armoCount.ToString();
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x00014A24 File Offset: 0x00012E24
	public void MoveStart()
	{
		this.anim.SetBool("Move", true);
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x00014A37 File Offset: 0x00012E37
	public void MoveStop()
	{
		this.anim.SetBool("Move", false);
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x00014A4C File Offset: 0x00012E4C
	public void GunFire()
	{
		if (this.armoCount > 0)
		{
			this.muzzleEffect.transform.Rotate(Vector3.forward * UnityEngine.Random.Range(0f, 360f));
			this.muzzleEffect.transform.localScale = new Vector3(UnityEngine.Random.Range(0.1f, 0.2f), UnityEngine.Random.Range(0.1f, 0.2f), 1f);
			this.muzzleEffect.SetActive(true);
			base.StartCoroutine(this.Flash());
			this.audioSource.PlayOneShot(this.gunSound, 1f);
			this.shellParticle.Emit(1);
			Vector3 vector = new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f);
			vector += new Vector3((float)UnityEngine.Random.Range(-10, 10), (float)UnityEngine.Random.Range(-10, 10), 0f);
			Ray ray = Camera.main.ScreenPointToRay(vector);
			RaycastHit[] array = Physics.RaycastAll(ray);
			if (array.Length > 0)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.impactEffect, array[0].point - array[0].normal * -0.2f, Quaternion.identity);
			}
		}
		else
		{
			this.anim.SetBool("Shoot", false);
			this.muzzleEffect.SetActive(false);
			this.inFire = false;
		}
		this.armoCount--;
		if (this.armoCount < 0)
		{
			this.armoCount = 0;
		}
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x00014BE0 File Offset: 0x00012FE0
	public void TouchPadSwipe(bool value)
	{
		ETCInput.SetControlSwipeIn("FreeLookTouchPad", value);
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x00014BF0 File Offset: 0x00012FF0
	private IEnumerator Flash()
	{
		yield return new WaitForSeconds(0.08f);
		this.muzzleEffect.SetActive(false);
		yield break;
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x00014C0C File Offset: 0x0001300C
	private IEnumerator Reload()
	{
		yield return new WaitForSeconds(0.5f);
		this.armoCount = 30;
		this.inReload = false;
		this.anim.SetBool("Reload", false);
		yield break;
	}

	// Token: 0x04000294 RID: 660
	public AudioClip gunSound;

	// Token: 0x04000295 RID: 661
	public AudioClip reload;

	// Token: 0x04000296 RID: 662
	public AudioClip needReload;

	// Token: 0x04000297 RID: 663
	public ParticleSystem shellParticle;

	// Token: 0x04000298 RID: 664
	public GameObject muzzleEffect;

	// Token: 0x04000299 RID: 665
	public GameObject impactEffect;

	// Token: 0x0400029A RID: 666
	public Text armoText;

	// Token: 0x0400029B RID: 667
	private bool inFire;

	// Token: 0x0400029C RID: 668
	private bool inReload;

	// Token: 0x0400029D RID: 669
	private Animator anim;

	// Token: 0x0400029E RID: 670
	private int armoCount = 30;

	// Token: 0x0400029F RID: 671
	private AudioSource audioSource;
}
