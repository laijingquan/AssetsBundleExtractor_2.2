using System;
using System.Collections.Generic;

namespace com.adjust.sdk
{
	// Token: 0x02000017 RID: 23
	public class AdjustEvent
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x0000607C File Offset: 0x0000447C
		public AdjustEvent(string eventToken)
		{
			this.eventToken = eventToken;
			this.isReceiptSet = false;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00006092 File Offset: 0x00004492
		public void setRevenue(double amount, string currency)
		{
			this.revenue = new double?(amount);
			this.currency = currency;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000060A7 File Offset: 0x000044A7
		public void addCallbackParameter(string key, string value)
		{
			if (this.callbackList == null)
			{
				this.callbackList = new List<string>();
			}
			this.callbackList.Add(key);
			this.callbackList.Add(value);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000060D7 File Offset: 0x000044D7
		public void addPartnerParameter(string key, string value)
		{
			if (this.partnerList == null)
			{
				this.partnerList = new List<string>();
			}
			this.partnerList.Add(key);
			this.partnerList.Add(value);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00006107 File Offset: 0x00004507
		public void setTransactionId(string transactionId)
		{
			this.transactionId = transactionId;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00006110 File Offset: 0x00004510
		[Obsolete("This is an obsolete method. Please use the adjust purchase SDK for purchase verification (https://github.com/adjust/unity_purchase_sdk)")]
		public void setReceipt(string receipt, string transactionId)
		{
			this.receipt = receipt;
			this.transactionId = transactionId;
			this.isReceiptSet = true;
		}

		// Token: 0x04000053 RID: 83
		internal double? revenue;

		// Token: 0x04000054 RID: 84
		internal string currency;

		// Token: 0x04000055 RID: 85
		internal string eventToken;

		// Token: 0x04000056 RID: 86
		internal List<string> partnerList;

		// Token: 0x04000057 RID: 87
		internal List<string> callbackList;

		// Token: 0x04000058 RID: 88
		internal string receipt;

		// Token: 0x04000059 RID: 89
		internal string transactionId;

		// Token: 0x0400005A RID: 90
		internal bool isReceiptSet;
	}
}
