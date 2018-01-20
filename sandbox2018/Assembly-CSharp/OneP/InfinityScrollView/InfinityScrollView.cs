using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OneP.InfinityScrollView
{
	// Token: 0x02000135 RID: 309
	public class InfinityScrollView : MonoBehaviour
	{
		// Token: 0x060007D3 RID: 2003 RVA: 0x00020E76 File Offset: 0x0001F276
		public void Setup(int numberItem)
		{
			this.totalNumberItem = numberItem;
			if (this.totalNumberItem < 0)
			{
				this.totalNumberItem = 0;
			}
			this.Setup();
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x00020E98 File Offset: 0x0001F298
		public void Setup()
		{
			if (this.prefab == null)
			{
				Debug.LogWarning("No prefab/Gameobject Item linking");
				return;
			}
			if (this.type == InfinityType.Vertical)
			{
				int num = (int)((float)(this.totalNumberItem + this.list_skip_Index.Count) * this.itemSize);
				this.content.SetHeight((float)num + this.extraContentLength);
			}
			else
			{
				int num2 = (int)((float)(this.totalNumberItem + this.list_skip_Index.Count) * this.itemSize);
				this.content.SetWidth((float)num2 + this.extraContentLength);
			}
			this.arrayCurrent = new GameObject[this.totalNumberItem];
			for (int i = 0; i < this.itemGenerate; i++)
			{
				if (!this.isInit)
				{
					if (i < this.totalNumberItem)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefab);
						gameObject.name = "item_" + i;
						gameObject.transform.SetParent(this.content.transform, false);
						gameObject.transform.localScale = Vector3.one;
						this.listItem.Add(gameObject);
						if (this.type == InfinityType.Vertical)
						{
							RectTransform component = gameObject.GetComponent<RectTransform>();
							if (component != null)
							{
								Vector2 pivot = component.pivot;
								if (this.verticalType == VerticalType.BottomToTop)
								{
									Vector2 anchorMin = component.anchorMin;
									Vector2 anchorMax = component.anchorMax;
									component.anchorMin = new Vector2(anchorMin.x, 0f);
									component.anchorMax = new Vector2(anchorMax.x, 0f);
									component.pivot = new Vector2(pivot.x, 0f);
								}
								else
								{
									component.pivot = new Vector2(pivot.x, 1f);
								}
							}
						}
						else if (this.type == InfinityType.Horizontal)
						{
							RectTransform component2 = gameObject.GetComponent<RectTransform>();
							if (component2 != null)
							{
								Vector2 pivot2 = component2.pivot;
								if (this.horizontalType == HorizontalType.RigthToLeft)
								{
									Vector2 anchorMin2 = component2.anchorMin;
									Vector2 anchorMax2 = component2.anchorMax;
									component2.anchorMin = new Vector2(1f, anchorMin2.y);
									component2.anchorMax = new Vector2(1f, anchorMax2.y);
									component2.pivot = new Vector2(1f, pivot2.y);
								}
								else
								{
									component2.pivot = new Vector2(0f, pivot2.y);
								}
							}
						}
						this.Reload(gameObject, i);
						this.arrayCurrent[i] = gameObject;
					}
				}
				else if (i < this.totalNumberItem)
				{
					GameObject gameObject = this.listItem[i];
					gameObject.SetActive(true);
					this.Reload(gameObject, i);
					this.arrayCurrent[i] = gameObject;
				}
				else
				{
					GameObject gameObject = this.listItem[i];
					gameObject.SetActive(false);
				}
			}
			this.isInit = true;
			int num3 = 0;
			for (int j = 0; j < this.list_skip_Index.Count; j++)
			{
				if (j < this.list_skip_Object.Count && this.list_skip_Object[j] != null)
				{
					int num4 = this.list_skip_Index[j];
					if (num4 > this.totalNumberItem)
					{
						num4 = this.totalNumberItem;
					}
					num4 += num3;
					num3++;
					Vector3 localScale = this.list_skip_Object[j].transform.localScale;
					if (!this.list_skip_Object[j].activeInHierarchy)
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.list_skip_Object[j]);
						gameObject2.SetActive(true);
						this.list_skip_Object[j] = gameObject2;
					}
					this.list_skip_Object[j].transform.SetParent(this.content.transform);
					this.list_skip_Object[j].transform.localScale = localScale;
					if (this.type == InfinityType.Vertical)
					{
						RectTransform component3 = this.list_skip_Object[j].GetComponent<RectTransform>();
						if (component3 != null)
						{
							Vector2 pivot3 = component3.pivot;
							if (this.verticalType == VerticalType.BottomToTop)
							{
								Vector2 anchorMin3 = component3.anchorMin;
								Vector2 anchorMax3 = component3.anchorMax;
								component3.anchorMin = new Vector2(anchorMin3.x, 0f);
								component3.anchorMax = new Vector2(anchorMax3.x, 0f);
								component3.pivot = new Vector2(pivot3.x, 0f);
							}
							else
							{
								component3.pivot = new Vector2(pivot3.x, 1f);
							}
						}
					}
					else if (this.type == InfinityType.Horizontal)
					{
						RectTransform component4 = this.list_skip_Object[j].GetComponent<RectTransform>();
						if (component4 != null)
						{
							Vector2 pivot4 = component4.pivot;
							if (this.horizontalType == HorizontalType.RigthToLeft)
							{
								Vector2 anchorMin4 = component4.anchorMin;
								Vector2 anchorMax4 = component4.anchorMax;
								component4.anchorMin = new Vector2(1f, anchorMin4.y);
								component4.anchorMax = new Vector2(1f, anchorMax4.y);
								component4.pivot = new Vector2(1f, pivot4.y);
							}
							else
							{
								component4.pivot = new Vector2(0f, pivot4.y);
							}
						}
					}
					Vector3 v = Vector3.zero;
					if (this.locationType == DetemineLocationType.BaseOnObjectCreate)
					{
						if (this.listItem.Count > 0 && this.listItem[0] != null)
						{
							v = this.listItem[0].transform.localPosition;
						}
					}
					else
					{
						v = new Vector2(this.overrideX, this.overrideY);
					}
					this.list_skip_Object[j].transform.localPosition = this.GetLocationAppear(v, num4);
				}
			}
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x000214AB File Offset: 0x0001F8AB
		private float GetContentSize()
		{
			return this.content.GetHeight();
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x000214B8 File Offset: 0x0001F8B8
		public int GetLocaltionWithSkip(int index)
		{
			int num = index;
			for (int i = 0; i < this.list_skip_Index.Count; i++)
			{
				if (this.list_skip_Index[i] <= index)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x000214FC File Offset: 0x0001F8FC
		public int GetIndexRejectSkip(int index)
		{
			int num = index;
			for (int i = 0; i < this.list_skip_Index.Count; i++)
			{
				if (this.list_skip_Index[i] <= index)
				{
					num--;
				}
			}
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00021547 File Offset: 0x0001F947
		private void Awake()
		{
			this.scrollRect = base.GetComponent<ScrollRect>();
			this.scrollRect.onValueChanged.AddListener(new UnityAction<Vector2>(this.OnScrollChange));
			if (this.setupOnAwake)
			{
				this.Setup();
			}
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00021584 File Offset: 0x0001F984
		private int GetCurrentIndex()
		{
			int num;
			if (this.type == InfinityType.Vertical)
			{
				if (this.verticalType == VerticalType.TopToBottom)
				{
					num = (int)(this.content.anchoredPosition.y / this.itemSize);
				}
				else
				{
					num = (int)(-this.content.anchoredPosition.y / this.itemSize);
				}
			}
			else if (this.horizontalType == HorizontalType.LeftToRight)
			{
				num = (int)(-this.content.anchoredPosition.x / this.itemSize);
			}
			else
			{
				num = (int)(this.content.anchoredPosition.x / this.itemSize);
			}
			if (num < 0)
			{
				num = 0;
			}
			if (num > this.totalNumberItem - 1)
			{
				num = this.totalNumberItem - 1;
			}
			return num;
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x00021658 File Offset: 0x0001FA58
		public void InternalReload()
		{
			int index = this.GetCurrentIndex();
			index = this.GetIndexRejectSkip(index);
			this.FixFastReload(index);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0002167C File Offset: 0x0001FA7C
		public void OnScrollChange(Vector2 vec)
		{
			if (this.arrayCurrent.Length < 1)
			{
				return;
			}
			int num = this.GetCurrentIndex();
			num = this.GetIndexRejectSkip(num);
			if (this.cacheOld != num)
			{
				this.cacheOld = num;
				if (!this.FixFastReload(num))
				{
					GameObject gameObject = this.arrayCurrent[num];
					if (gameObject == null)
					{
						int num2 = num + this.itemGenerate;
						if (num2 > this.totalNumberItem - 1)
						{
							return;
						}
						GameObject gameObject2 = this.arrayCurrent[num2];
						if (gameObject2 != null)
						{
							this.arrayCurrent[num2] = gameObject;
							this.arrayCurrent[num] = gameObject2;
							this.Reload(this.arrayCurrent[num], num);
						}
					}
					else if (num > 0)
					{
						GameObject gameObject3 = this.arrayCurrent[num - 1];
						if (gameObject3 == null)
						{
							return;
						}
						int num3 = num - 1 + this.itemGenerate;
						if (num3 > this.totalNumberItem - 1)
						{
							return;
						}
						GameObject gameObject4 = this.arrayCurrent[num3];
						if (gameObject4 == null)
						{
							this.arrayCurrent[num3] = gameObject3;
							this.arrayCurrent[num - 1] = gameObject4;
							this.Reload(this.arrayCurrent[num3], num3);
						}
					}
				}
				return;
			}
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x000217B4 File Offset: 0x0001FBB4
		public bool FixFastReload(int index)
		{
			bool flag = false;
			int num = index + 1;
			for (int i = num; i < num + this.itemGenerate - 2; i++)
			{
				if (i < this.totalNumberItem)
				{
					GameObject gameObject = this.arrayCurrent[i];
					if (gameObject == null)
					{
						flag = true;
						break;
					}
					if (!gameObject.name.Equals("item_" + i))
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				for (int j = 0; j < this.totalNumberItem; j++)
				{
					this.arrayCurrent[j] = null;
				}
				int num2 = index;
				if (num2 + this.itemGenerate > this.totalNumberItem)
				{
					num2 = this.totalNumberItem - this.itemGenerate;
				}
				for (int k = 0; k < this.itemGenerate; k++)
				{
					this.arrayCurrent[num2 + k] = this.listItem[k];
					this.Reload(this.arrayCurrent[num2 + k], num2 + k);
				}
				return true;
			}
			return false;
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x000218D0 File Offset: 0x0001FCD0
		protected virtual void Reload(GameObject obj, int indexReload)
		{
			obj.transform.name = "item_" + indexReload;
			int localtionWithSkip = this.GetLocaltionWithSkip(indexReload);
			Vector3 vector = Vector3.zero;
			if (this.locationType == DetemineLocationType.BaseOnObjectCreate)
			{
				vector.x = obj.transform.localPosition.x;
				vector.y = obj.transform.localPosition.y;
			}
			else
			{
				vector = new Vector2(this.overrideX, this.overrideY);
			}
			vector = this.GetLocationAppear(vector, localtionWithSkip);
			obj.transform.localPosition = vector;
			InfinityBaseItem component = obj.GetComponent<InfinityBaseItem>();
			if (component != null)
			{
				component.Reload(this, indexReload);
			}
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0002199C File Offset: 0x0001FD9C
		private Vector3 GetLocationAppear(Vector2 initVec, int location)
		{
			Vector3 result = initVec;
			if (this.type == InfinityType.Vertical)
			{
				if (this.verticalType == VerticalType.TopToBottom)
				{
					result = new Vector3(result.x, -this.itemSize * (float)location, 0f);
				}
				else
				{
					result = new Vector3(result.x, this.itemSize * (float)location, 0f);
				}
			}
			else if (this.horizontalType == HorizontalType.LeftToRight)
			{
				result = new Vector3(this.itemSize * (float)location, result.y, 0f);
			}
			else
			{
				result = new Vector3(-this.itemSize * (float)location, result.y, 0f);
			}
			return result;
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x00021A53 File Offset: 0x0001FE53
		private void Start()
		{
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00021A55 File Offset: 0x0001FE55
		private void Update()
		{
		}

		// Token: 0x040004A1 RID: 1185
		[Header("Setting Reference object")]
		public GameObject prefab;

		// Token: 0x040004A2 RID: 1186
		public ScrollRect scrollRect;

		// Token: 0x040004A3 RID: 1187
		public RectTransform content;

		// Token: 0x040004A4 RID: 1188
		[Header("Setting For Custom Scroll View")]
		public InfinityType type;

		// Token: 0x040004A5 RID: 1189
		public VerticalType verticalType;

		// Token: 0x040004A6 RID: 1190
		public HorizontalType horizontalType;

		// Token: 0x040004A7 RID: 1191
		public DetemineLocationType locationType = DetemineLocationType.OverrideLocation;

		// Token: 0x040004A8 RID: 1192
		public float overrideX;

		// Token: 0x040004A9 RID: 1193
		public float overrideY;

		// Token: 0x040004AA RID: 1194
		public float extraContentLength;

		// Token: 0x040004AB RID: 1195
		[Header("Setting For Custom Data")]
		public float itemSize = 100f;

		// Token: 0x040004AC RID: 1196
		public int itemGenerate = 10;

		// Token: 0x040004AD RID: 1197
		public int totalNumberItem = 100;

		// Token: 0x040004AE RID: 1198
		[Header("Setting if want to skip some index item")]
		public List<int> list_skip_Index = new List<int>();

		// Token: 0x040004AF RID: 1199
		public List<GameObject> list_skip_Object = new List<GameObject>();

		// Token: 0x040004B0 RID: 1200
		[Header("flat check auto setup references")]
		public bool isAutoLinking = true;

		// Token: 0x040004B1 RID: 1201
		public bool isOverrideSettingScrollbar = true;

		// Token: 0x040004B2 RID: 1202
		public bool setupOnAwake = true;

		// Token: 0x040004B3 RID: 1203
		public int categoryIndex;

		// Token: 0x040004B4 RID: 1204
		public int initTotalNumber;

		// Token: 0x040004B5 RID: 1205
		private List<GameObject> listItem = new List<GameObject>();

		// Token: 0x040004B6 RID: 1206
		private GameObject[] arrayCurrent;

		// Token: 0x040004B7 RID: 1207
		private int cacheOld = -1;

		// Token: 0x040004B8 RID: 1208
		private bool isInit;
	}
}
