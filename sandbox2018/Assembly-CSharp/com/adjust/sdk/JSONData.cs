using System;
using System.IO;

namespace com.adjust.sdk
{
	// Token: 0x02000006 RID: 6
	public class JSONData : JSONNode
	{
		// Token: 0x0600004C RID: 76 RVA: 0x000039CF File Offset: 0x00001DCF
		public JSONData(string aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000039DE File Offset: 0x00001DDE
		public JSONData(float aData)
		{
			this.AsFloat = aData;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000039ED File Offset: 0x00001DED
		public JSONData(double aData)
		{
			this.AsDouble = aData;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000039FC File Offset: 0x00001DFC
		public JSONData(bool aData)
		{
			this.AsBool = aData;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003A0B File Offset: 0x00001E0B
		public JSONData(int aData)
		{
			this.AsInt = aData;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00003A1A File Offset: 0x00001E1A
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00003A22 File Offset: 0x00001E22
		public override string Value
		{
			get
			{
				return this.m_Data;
			}
			set
			{
				this.m_Data = value;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003A2B File Offset: 0x00001E2B
		public override string ToString()
		{
			return "\"" + JSONNode.Escape(this.m_Data) + "\"";
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003A47 File Offset: 0x00001E47
		public override string ToString(string aPrefix)
		{
			return "\"" + JSONNode.Escape(this.m_Data) + "\"";
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003A64 File Offset: 0x00001E64
		public override void Serialize(BinaryWriter aWriter)
		{
			JSONData jsondata = new JSONData(string.Empty);
			jsondata.AsInt = this.AsInt;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(4);
				aWriter.Write(this.AsInt);
				return;
			}
			jsondata.AsFloat = this.AsFloat;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(7);
				aWriter.Write(this.AsFloat);
				return;
			}
			jsondata.AsDouble = this.AsDouble;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(5);
				aWriter.Write(this.AsDouble);
				return;
			}
			jsondata.AsBool = this.AsBool;
			if (jsondata.m_Data == this.m_Data)
			{
				aWriter.Write(6);
				aWriter.Write(this.AsBool);
				return;
			}
			aWriter.Write(3);
			aWriter.Write(this.m_Data);
		}

		// Token: 0x0400000B RID: 11
		private string m_Data;
	}
}
