using System;
using UnityEngine;

// Token: 0x02000137 RID: 311
public class AppConfig
{
	// Token: 0x040004B9 RID: 1209
	public static int GRID_MAX_ROW = 30;

	// Token: 0x040004BA RID: 1210
	public static int GRID_MAX_COLUMN = 30;

	// Token: 0x040004BB RID: 1211
	public static float NUMBER_IMG_SCALE = 0.18f;

	// Token: 0x040004BC RID: 1212
	public static float GRID_PIXEL_LENGTH = 4f;

	// Token: 0x040004BD RID: 1213
	public static float GRID_UNIT_LENGTH = AppConfig.GRID_PIXEL_LENGTH / 100f;

	// Token: 0x040004BE RID: 1214
	public static float NUMBER_PIXEL_LENGTH = 200f;

	// Token: 0x040004BF RID: 1215
	public static float GRID_NUMBER_UNIT_LENGTH = AppConfig.NUMBER_PIXEL_LENGTH / 100f;

	// Token: 0x040004C0 RID: 1216
	public static float TOUCH_LONGTAP_TIME = 0.3f;

	// Token: 0x040004C1 RID: 1217
	public static long TOUCH_VIBRATE_TIME = 50L;

	// Token: 0x040004C2 RID: 1218
	public static int HOLD_DRAW_GRID_MAX = 60;

	// Token: 0x040004C3 RID: 1219
	public const string FOLDER_DATACONFIG = "DataConfig/";

	// Token: 0x040004C4 RID: 1220
	public const int DESIGN_SCREEN_WIDTH = 1080;

	// Token: 0x040004C5 RID: 1221
	public const int DESIGN_SCREEN_HEIGHT = 1920;

	// Token: 0x040004C6 RID: 1222
	public const float DESIGN_ASPECT = 1.77777779f;

	// Token: 0x040004C7 RID: 1223
	public const string TAG_MAINCAMERA = "MainCamera";

	// Token: 0x040004C8 RID: 1224
	public const string GAME_TOUCH_LAYER = "GameTouchLayer";

	// Token: 0x040004C9 RID: 1225
	public const string GAME_TILES_LAYER = "GameTilesLayer";

	// Token: 0x040004CA RID: 1226
	public const string GAME_REPLAY_LAYER = "GameReplayLayer";

	// Token: 0x040004CB RID: 1227
	public const string GAME_UI_CANVAS = "GameUICanvas/";

	// Token: 0x040004CC RID: 1228
	public const float DesinSize = 1080f;

	// Token: 0x040004CD RID: 1229
	public const float CameraSize = 8f;

	// Token: 0x040004CE RID: 1230
	public const float BANNER_PIXEL_LENGTH = 150f;

	// Token: 0x040004CF RID: 1231
	public const float BOTTOM_PIXEL_LENGTH = 150f;

	// Token: 0x040004D0 RID: 1232
	public const float BOTTOM_BOUNDARY_OFFSET = 0.078125f;

	// Token: 0x040004D1 RID: 1233
	public const float BOTTOM_BOUNDARY_OFFSET_BANNER = 0.15625f;

	// Token: 0x040004D2 RID: 1234
	public static float GAME_BOTTOM_BOUNDARY_OFFSET = 0.078125f;

	// Token: 0x040004D3 RID: 1235
	public static float UI_THUMB_BIG_LENGTH = 500f;

	// Token: 0x040004D4 RID: 1236
	public static float UI_THUMB_SMALL_LENGTH = 340f;

	// Token: 0x040004D5 RID: 1237
	public static string GAME_THUMB_PICTURE_PATH = Application.persistentDataPath + "/Thumb_";

	// Token: 0x040004D6 RID: 1238
	public static string THUMB_PICTURE_FULL_PATH = Application.dataPath + "/Resources/Thumbs/Thumb_";

	// Token: 0x040004D7 RID: 1239
	public static bool DEBUGGING = true;

	// Token: 0x040004D8 RID: 1240
	public static bool USE_FIXED_FRAMERATE = false;

	// Token: 0x040004D9 RID: 1241
	public static string SCENE_NAME_GMAE = "Game";

	// Token: 0x040004DA RID: 1242
	public static long SUBSCRIPTION_VALID_MILLISCEOND = 604800000L;

	// Token: 0x040004DB RID: 1243
	public static string ANDROID_PACKAGE_NAME = "sandbox.coloring.number.pixel.art";
}
