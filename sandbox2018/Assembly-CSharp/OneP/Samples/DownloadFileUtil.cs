using System;
using System.Collections;
using UnityEngine;

namespace OneP.Samples
{
	// Token: 0x0200012D RID: 301
	public class DownloadFileUtil : SingletonMono<DownloadFileUtil>
	{
		// Token: 0x060007C0 RID: 1984 RVA: 0x000209EC File Offset: 0x0001EDEC
		public void OnDownloadFile(string url, Action<ExtraInfoDownload> resultCallback, Action<float> processCallback, float secondTimeout, int maxRetry = 3)
		{
			if (string.IsNullOrEmpty(url))
			{
				return;
			}
			if (secondTimeout < 0f)
			{
				secondTimeout = 1f;
			}
			if (Singleton<ResourceLoaderManager>.Instance.PushToQueue(url, resultCallback))
			{
				base.StartCoroutine(this.OnDownloadFileRoutine(url, processCallback, secondTimeout, maxRetry, 0));
			}
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00020A40 File Offset: 0x0001EE40
		private IEnumerator OnDownloadFileRoutine(string url, Action<float> processCallback, float secondTimeout, int maxRetry, int retryCount = 0)
		{
			WWW w = null;
			float timeDownload = 0f;
			w = Singleton<ResourceLoaderManager>.Instance.GetWWW(url);
			if (w != null)
			{
				Singleton<ResourceLoaderManager>.Instance.DispathQueue(url, new ExtraInfoDownload(w, 0f, retryCount));
				if (processCallback != null)
				{
					processCallback(1f);
				}
				yield break;
			}
			w = new WWW(url);
			float cachePercent = 0f;
			int unDownLoadStep = 0;
			bool isFailDownload = false;
			while (!w.isDone)
			{
				if (Mathf.Abs(cachePercent - w.progress) > 0f)
				{
					cachePercent = w.progress;
					unDownLoadStep = 0;
					if (processCallback != null)
					{
						processCallback(cachePercent);
					}
				}
				else
				{
					unDownLoadStep++;
					if ((float)unDownLoadStep > 10f * secondTimeout)
					{
						isFailDownload = true;
						break;
					}
					if (processCallback != null)
					{
						processCallback(cachePercent);
					}
					yield return new WaitForSeconds(0.1f);
					timeDownload += 0.1f;
				}
				if (!string.IsNullOrEmpty(w.error))
				{
					isFailDownload = true;
				}
				yield return null;
			}
			if (isFailDownload)
			{
				this.RetryAttempDownloadFile(url, processCallback, secondTimeout, maxRetry, retryCount);
			}
			else
			{
				Singleton<ResourceLoaderManager>.Instance.AddWWW(url, w);
				Singleton<ResourceLoaderManager>.Instance.DispathQueue(url, new ExtraInfoDownload(w, timeDownload, retryCount));
			}
			yield break;
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00020A80 File Offset: 0x0001EE80
		public void RetryAttempDownloadFile(string url, Action<float> processCallback, float secondTimeout, int maxRetry, int retryCount)
		{
			if (retryCount < maxRetry)
			{
				retryCount++;
				base.StartCoroutine(this.OnDownloadFileRoutine(url, processCallback, secondTimeout, maxRetry, retryCount));
			}
			else
			{
				Singleton<ResourceLoaderManager>.Instance.DispathQueue(url, null);
			}
		}
	}
}
