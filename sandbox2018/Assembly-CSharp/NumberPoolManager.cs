using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000153 RID: 339
public class NumberPoolManager : MonoBehaviour
{
	// Token: 0x060008A4 RID: 2212 RVA: 0x00025408 File Offset: 0x00023808
	public void Load()
	{
		if (!this._isLoad)
		{
			this._isLoad = true;
			for (int i = 0; i < 20; i++)
			{
				NumberPoolManager.SingleNumber singleNumber = new NumberPoolManager.SingleNumber();
				singleNumber.Init(i + 1, base.transform);
				this._allNumberDic.Add(i + 1, singleNumber);
			}
		}
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x00025460 File Offset: 0x00023860
	public Transform GetNumber(int number)
	{
		NumberPoolManager.SingleNumber singleNumber;
		this._allNumberDic.TryGetValue(number, out singleNumber);
		return singleNumber.GetTransform();
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x00025484 File Offset: 0x00023884
	public void Reset()
	{
		foreach (NumberPoolManager.SingleNumber singleNumber in this._allNumberDic.Values)
		{
			singleNumber.Reset();
		}
	}

	// Token: 0x1700009C RID: 156
	// (get) Token: 0x060008A7 RID: 2215 RVA: 0x000254E4 File Offset: 0x000238E4
	public static NumberPoolManager Instance
	{
		get
		{
			if (NumberPoolManager._instance == null)
			{
				GameObject gameObject = new GameObject("NumberPoolManager");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				NumberPoolManager._instance = gameObject.AddComponent<NumberPoolManager>();
			}
			return NumberPoolManager._instance;
		}
	}

	// Token: 0x04000559 RID: 1369
	private const int MAX_NUMBER_COUNT = 20;

	// Token: 0x0400055A RID: 1370
	private Dictionary<int, NumberPoolManager.SingleNumber> _allNumberDic = new Dictionary<int, NumberPoolManager.SingleNumber>();

	// Token: 0x0400055B RID: 1371
	private bool _isLoad;

	// Token: 0x0400055C RID: 1372
	private static NumberPoolManager _instance;

	// Token: 0x02000154 RID: 340
	public class SingleNumber
	{
		// Token: 0x060008A9 RID: 2217 RVA: 0x00025535 File Offset: 0x00023935
		public void Init(int number, Transform parent)
		{
			this._number = number;
			this._parent = parent;
			this._prefab = Resources.Load("Prefabs/Number/" + this._number);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00025568 File Offset: 0x00023968
		public Transform GetTransform()
		{
			if (this._index < this._amount)
			{
				Transform result = this._numberPrefab[this._index];
				this._index++;
				return result;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(this._prefab) as GameObject;
			this._numberPrefab.Add(gameObject.transform);
			this._amount++;
			this._index++;
			return gameObject.transform;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x000255EC File Offset: 0x000239EC
		public void Reset()
		{
			this._index = 0;
			for (int i = 0; i < this._amount; i++)
			{
				this._numberPrefab[i].SetParent(this._parent);
				this._numberPrefab[i].localPosition = new Vector2(10000f, 10000f);
			}
		}

		// Token: 0x0400055D RID: 1373
		private int _number;

		// Token: 0x0400055E RID: 1374
		private Transform _parent;

		// Token: 0x0400055F RID: 1375
		private UnityEngine.Object _prefab;

		// Token: 0x04000560 RID: 1376
		private int _amount;

		// Token: 0x04000561 RID: 1377
		private int _index;

		// Token: 0x04000562 RID: 1378
		public List<Transform> _numberPrefab = new List<Transform>();
	}
}
