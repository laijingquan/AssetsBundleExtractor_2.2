using System;
using System.Collections;
using UnityEngine;

namespace OneP.Samples
{
	// Token: 0x0200011D RID: 285
	public class CheckFPS : MonoBehaviour
	{
		// Token: 0x06000776 RID: 1910 RVA: 0x0001F770 File Offset: 0x0001DB70
		private void Start()
		{
			Application.targetFrameRate = 60;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			base.StartCoroutine(this.FPS());
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0001F791 File Offset: 0x0001DB91
		private void Update()
		{
			this.accum += Time.timeScale / Time.deltaTime;
			this.frames++;
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0001F7BC File Offset: 0x0001DBBC
		private IEnumerator FPS()
		{
			for (;;)
			{
				float fps = this.accum / (float)this.frames;
				this.sFPS = fps.ToString("f" + Mathf.Clamp(this.nbDecimal, 0, 10));
				this.color = ((fps < 30f) ? ((fps <= 10f) ? Color.yellow : Color.red) : Color.green);
				this.accum = 0f;
				this.frames = 0;
				yield return new WaitForSeconds(this.frequency);
			}
			yield break;
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0001F7D8 File Offset: 0x0001DBD8
		private void OnGUI()
		{
			if (!this.render)
			{
				return;
			}
			if (this.style == null)
			{
				this.style = new GUIStyle(GUI.skin.label);
				this.style.normal.textColor = Color.white;
				this.style.alignment = TextAnchor.MiddleCenter;
			}
			GUI.color = ((!this.updateColor) ? Color.white : this.color);
			this.startRect = GUI.Window(0, this.startRect, new GUI.WindowFunction(this.DoMyWindow), string.Empty);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0001F878 File Offset: 0x0001DC78
		private void DoMyWindow(int windowID)
		{
			string text = this.sFPS + " FPS\n";
			GUI.Label(new Rect(0f, 0f, this.startRect.width, this.startRect.height), text, this.style);
			if (this.allowDrag)
			{
				GUI.DragWindow(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
			}
		}

		// Token: 0x04000456 RID: 1110
		public bool render;

		// Token: 0x04000457 RID: 1111
		public Rect startRect = new Rect(80f, 40f, 75f, 50f);

		// Token: 0x04000458 RID: 1112
		public bool updateColor = true;

		// Token: 0x04000459 RID: 1113
		public bool allowDrag = true;

		// Token: 0x0400045A RID: 1114
		public float frequency = 0.5f;

		// Token: 0x0400045B RID: 1115
		public int nbDecimal = 1;

		// Token: 0x0400045C RID: 1116
		private float accum;

		// Token: 0x0400045D RID: 1117
		private int frames;

		// Token: 0x0400045E RID: 1118
		private Color color = Color.white;

		// Token: 0x0400045F RID: 1119
		private string sFPS = string.Empty;

		// Token: 0x04000460 RID: 1120
		private GUIStyle style;
	}
}
