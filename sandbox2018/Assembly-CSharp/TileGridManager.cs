using System;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

// Token: 0x02000167 RID: 359
public class TileGridManager : MonoBehaviour
{
	// Token: 0x06000950 RID: 2384 RVA: 0x00027FF4 File Offset: 0x000263F4
	private void InitDrawLine()
	{
		this._drawLine = new VectorLine("DrawLine", new List<Vector2>(), 1f);
		this._drawLine.alignOddWidthToPixels = true;
		this._drawLine.color = this.GREY;
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x00028034 File Offset: 0x00026434
	public void SetAlpha(float alpha)
	{
		Color c = this._drawLine.color;
		c.a = alpha;
		this._drawLine.color = c;
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x0002806B File Offset: 0x0002646B
	public void Init()
	{
		this.InitDrawLine();
		this.SetAlpha(0f);
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x0002807E File Offset: 0x0002647E
	public void Reset()
	{
		this._drawLine.points2 = new List<Vector2>();
		this._drawLine.Draw();
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x0002809C File Offset: 0x0002649C
	public void Draw()
	{
		List<Vector2> list = this.GenPoints();
		this._drawLine.Resize(list.Count);
		this._drawLine.points2 = list;
		this._drawLine.Draw();
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x000280D8 File Offset: 0x000264D8
	private List<Vector2> GenPoints()
	{
		this._points.Clear();
		Dictionary<string, Tile> dicGameTiles = GameManager.Instance.tileManager.dicGameTiles;
		int canvasLength = GameManager.Instance.tileManager.GetCanvasLength();
		int num = canvasLength - 1;
		string key;
		Tile tile;
		for (int i = 0; i < canvasLength; i++)
		{
			key = 0 + "_" + i;
			tile = dicGameTiles[key];
			this._points.Add(this.GenGridPoint(tile, TileGridManager.DIRECTION.LB));
			key = num + "_" + i;
			tile = dicGameTiles[key];
			this._points.Add(this.GenGridPoint(tile, TileGridManager.DIRECTION.RB));
			key = i + "_" + 0;
			tile = dicGameTiles[key];
			this._points.Add(this.GenGridPoint(tile, TileGridManager.DIRECTION.LB));
			key = i + "_" + num;
			tile = dicGameTiles[key];
			this._points.Add(this.GenGridPoint(tile, TileGridManager.DIRECTION.LT));
		}
		key = 0 + "_" + num;
		tile = dicGameTiles[key];
		this._points.Add(this.GenGridPoint(tile, TileGridManager.DIRECTION.LT));
		key = num + "_" + num;
		tile = dicGameTiles[key];
		this._points.Add(this.GenGridPoint(tile, TileGridManager.DIRECTION.RT));
		key = num + "_" + 0;
		tile = dicGameTiles[key];
		this._points.Add(this.GenGridPoint(tile, TileGridManager.DIRECTION.RB));
		key = num + "_" + num;
		tile = dicGameTiles[key];
		this._points.Add(this.GenGridPoint(tile, TileGridManager.DIRECTION.RT));
		return this._points;
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x000282D4 File Offset: 0x000266D4
	private Vector2 GenGridPoint(Tile tile, TileGridManager.DIRECTION dir)
	{
		float curPicureScale = GameManager.Instance.levelManager.curPicureScale;
		float num = GameManager.Instance.levelManager.gridInitUnitLength * 0.5f;
		Vector2 a = tile.transform.localPosition;
		a *= curPicureScale;
		float curPictureScaleRadio = GameManager.Instance.levelManager.curPictureScaleRadio;
		num *= curPictureScaleRadio;
		a += GameManager.Instance.levelManager.curPictureMove;
		float screenWidth = GameManager.Instance.cameraController.screenWidth;
		float screenHeight = GameManager.Instance.cameraController.screenHeight;
		float d = screenWidth / GameManager.Instance.cameraController.cameraSizeWidth;
		switch (dir)
		{
		case TileGridManager.DIRECTION.LB:
		{
			Vector2 vector = new Vector2(a.x - num, a.y - num);
			vector *= d;
			vector += new Vector2(screenWidth * 0.5f, screenHeight * 0.5f);
			return vector;
		}
		case TileGridManager.DIRECTION.LT:
		{
			Vector2 vector2 = new Vector2(a.x - num, a.y + num);
			vector2 *= d;
			vector2 += new Vector2(screenWidth * 0.5f, screenHeight * 0.5f);
			return vector2;
		}
		case TileGridManager.DIRECTION.RB:
		{
			Vector2 vector3 = new Vector2(a.x + num, a.y - num);
			vector3 *= d;
			vector3 += new Vector2(screenWidth * 0.5f, screenHeight * 0.5f);
			return vector3;
		}
		case TileGridManager.DIRECTION.RT:
		{
			Vector2 vector4 = new Vector2(a.x + num, a.y + num);
			vector4 *= d;
			vector4 += new Vector2(screenWidth * 0.5f, screenHeight * 0.5f);
			return vector4;
		}
		default:
			return Vector2.zero;
		}
	}

	// Token: 0x040005BB RID: 1467
	private List<Vector2> _points = new List<Vector2>();

	// Token: 0x040005BC RID: 1468
	private Color GREY = new Color(0.412f, 0.412f, 0.412f, 1f);

	// Token: 0x040005BD RID: 1469
	private VectorLine _drawLine;

	// Token: 0x02000168 RID: 360
	public enum DIRECTION
	{
		// Token: 0x040005BF RID: 1471
		LB,
		// Token: 0x040005C0 RID: 1472
		LT,
		// Token: 0x040005C1 RID: 1473
		RB,
		// Token: 0x040005C2 RID: 1474
		RT
	}
}
