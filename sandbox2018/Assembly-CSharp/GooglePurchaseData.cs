using System;
using UnityEngine;

// Token: 0x0200015A RID: 346
internal class GooglePurchaseData
{
	// Token: 0x060008DB RID: 2267 RVA: 0x00025F18 File Offset: 0x00024318
	public GooglePurchaseData(string receipt)
	{
		try
		{
			GooglePurchaseData.GooglePurchasePayload googlePurchasePayload = JsonUtility.FromJson<GooglePurchaseData.GooglePurchasePayload>(JsonUtility.FromJson<GooglePurchaseData.GooglePurchaseReceipt>(receipt).Payload);
			GooglePurchaseData.GooglePurchaseJson googlePurchaseJson = JsonUtility.FromJson<GooglePurchaseData.GooglePurchaseJson>(googlePurchasePayload.json);
			this.inAppPurchaseData = googlePurchasePayload.json;
			this.inAppDataSignature = googlePurchasePayload.signature;
			this.json = googlePurchaseJson;
		}
		catch
		{
			Debug.Log("Could not parse receipt: " + receipt);
			this.inAppPurchaseData = string.Empty;
			this.inAppDataSignature = string.Empty;
		}
	}

	// Token: 0x04000580 RID: 1408
	public string inAppPurchaseData;

	// Token: 0x04000581 RID: 1409
	public string inAppDataSignature;

	// Token: 0x04000582 RID: 1410
	public GooglePurchaseData.GooglePurchaseJson json;

	// Token: 0x0200015B RID: 347
	[Serializable]
	private struct GooglePurchaseReceipt
	{
		// Token: 0x04000583 RID: 1411
		public string Payload;
	}

	// Token: 0x0200015C RID: 348
	[Serializable]
	private struct GooglePurchasePayload
	{
		// Token: 0x04000584 RID: 1412
		public string json;

		// Token: 0x04000585 RID: 1413
		public string signature;
	}

	// Token: 0x0200015D RID: 349
	[Serializable]
	public struct GooglePurchaseJson
	{
		// Token: 0x04000586 RID: 1414
		public string autoRenewing;

		// Token: 0x04000587 RID: 1415
		public string orderId;

		// Token: 0x04000588 RID: 1416
		public string packageName;

		// Token: 0x04000589 RID: 1417
		public string productId;

		// Token: 0x0400058A RID: 1418
		public string purchaseTime;

		// Token: 0x0400058B RID: 1419
		public string purchaseState;

		// Token: 0x0400058C RID: 1420
		public string developerPayload;

		// Token: 0x0400058D RID: 1421
		public string purchaseToken;
	}
}
