# Jelly Blast - Project Documentation

## Thông tin dự án
- **Tên game**: Jelly Blast (Match-3 Puzzle Game)
- **Engine**: Unity 6.0 (6000.0.58f2)
- **Platform**: Android
- **Developer**: Dotmob Studio

---

## Cấu trúc thư mục chính

```
Assets/
├── AdManager.cs              # Quản lý quảng cáo (AdMob/Gley Mobile Ads)
├── DM_Scripts/               # Scripts chính của game (424 files)
│   ├── GameMain.cs           # Controller chính của gameplay
│   ├── BoardManager.cs       # Quản lý board game, slots, outline
│   ├── CPanelGameUI.cs       # UI panel trong game
│   ├── PopupManager.cs       # Quản lý popup (singleton)
│   ├── Popup.cs              # Base class cho popup
│   ├── PopupType.cs          # Enum 100+ loại popup
│   ├── PlayerDataManager.cs  # Quản lý dữ liệu người chơi
│   ├── Booster.cs            # Logic booster items
│   ├── Slot.cs               # Logic từng ô slot trên board
│   ├── InGameUIOrientationVariable.cs  # UI orientation base
│   ├── InGameUIOrientationPortrait.cs  # UI portrait mode
│   └── ...
├── DM_Scenes/                # Scenes
│   ├── Game.unity            # Scene gameplay chính
│   ├── Loading.unity         # Scene loading
│   ├── Lobby.unity           # Scene lobby/menu
│   └── Menu.unity            # Scene menu
├── DM_Sprites/               # Sprites/Images
│   ├── top_bar.png           # Header background màu hồng
│   ├── bottom_bar.png        # Footer background màu hồng
│   ├── Gameplay_Screen.png   # Khung Move/Goal box
│   ├── bg_ingame_tile2_m.png # Nền slot (màu #00586c)
│   ├── SR_IngameUI_outline_*.png  # Sprites viền board (đã đổi màu)
│   ├── available_indicator.png    # Hình tròn số lượng booster
│   └── ...
├── Prefab/                   # Prefabs
│   ├── LT.prefab, RT.prefab, LB.prefab, RB.prefab  # Góc bo board
│   ├── HT.prefab, HB.prefab, VL.prefab, VR.prefab  # Cạnh bo board
│   └── ...
└── Resources/                # Prefabs động
    ├── ButtonBooster.prefab  # Prefab booster button ở footer
    └── ...
```

---

## Tiến trình công việc đã hoàn thành

### 1. Xóa Banner Ads ✅
**Mục đích**: Loại bỏ banner quảng cáo ngang để UI đẹp hơn

**Files đã sửa**:

#### `Assets/AdManager.cs` (line 18)
```csharp
private void OnInitialized()
{
    // API.ShowBanner(BannerPosition.Bottom, BannerType.Adaptive); // Disabled banner ads

    if (!API.GDPRConsentWasSet())
    {
        API.ShowBuiltInConsentPopup(PopupCloseds);
    }
}
```

#### `Assets/DM_Scripts/GameMain.cs` (line 373)
```csharp
private void Awake()
{
    // API.ShowBanner(BannerPosition.Bottom, BannerType.Adaptive); // Disabled banner ads
    main = this;
    // ...
}
```

---

### 2. Thay đổi Footer UI ✅
**Mục đích**: Đổi footer thành background màu hồng với booster items

**Scene**: `Assets/DM_Scenes/Game.unity`

**Hierarchy path**:
```
SceneGame > Game > UI > UIGame > UIGameCamera > GameUI > ViewPortrait > BottomPanel
```

**Thay đổi trên BottomPanel**:
- Source Image: `BG_3_1` → `bottom_bar.png`
- Image Type: Sliced

**Sprite configuration cho `bottom_bar.png`**:
- Texture Type: Sprite (2D and UI)
- Sprite Mode: Single

---

### 3. Điều chỉnh Booster Buttons ✅
**Mục đích**: Dạt booster sang trái, thu nhỏ khoảng cách để chừa chỗ cho nút Settings

**Object**: `BottomPanel > Booster`

**RectTransform**:
- Pos X: -50
- Pos Y: -30
- Width: 500
- Height: 100

**Horizontal Layout Group**:
- Padding Left: 20
- Spacing: 10
- Child Alignment: Middle Left
- Control Child Size > Width: checked
- Child Force Expand > Width: checked

---

### 4. Di chuyển nút Settings xuống Footer ✅
**Mục đích**: Đưa nút Settings (bánh răng) vào footer, tự động responsive

**Thay đổi**:
1. Kéo `ToggleOptionMenu` vào làm child của `BottomPanel`
2. Hierarchy mới:
```
BottomPanel
├── ToggleOptionMenu        # ← Đã di chuyển vào đây
│   ├── ButtonNormal
│   └── ButtonMain
├── AnchorBoardPositionBottom
├── BoardBottomInfo
├── Booster
└── ...
```

**RectTransform của ToggleOptionMenu**:
- Anchors: Min (1, 1), Max (1, 1) - neo góc phải trên của BottomPanel
- Pivot: (1, 1)
- Pos X: -5
- Pos Y: -15.55
- Width: 100
- Height: 100

---

### 5. Thay đổi Header UI ✅
**Mục đích**: Redesign header giống demo mới

**Hierarchy path**:
```
ViewPortrait > BoardTopInfo
├── Image                    # Header background (top_bar.png)
├── MoveInfo                 # Move box bên trái
│   ├── Image                # Label "Move" (namebg)
│   ├── bg                   # Khung trắng (Gameplay_Screen)
│   └── TextMoveCount        # Số moves
├── Goal                     # Goal box bên phải
│   ├── Image                # Label "Goal" (namebg)
│   ├── bg                   # Khung trắng (Gameplay_Screen)
│   └── block                # Icon item goal
├── Avatar                   # Avatar ở giữa (mới thêm)
│   ├── AvatarImage          # Hình nhân vật
│   ├── Star_1, Star_2, Star_3  # 3 sao progress
└── score                    # (ẩn)
```

**Thông số quan trọng**:

| Object | Pos X | Pos Y | Width | Height |
|--------|-------|-------|-------|--------|
| MoveInfo | -156 | 104 | 100 | 100 |
| Goal | 156 | 104 | 100 | 100 |
| MoveInfo > bg | -24 | -7 | 175 | 110 |
| Goal > bg | 24 | -7 | 175 | 110 |

**Avatar (mới tạo)**:
- Source Image: `profile_indicator_shadow` (khung tròn hồng)
- Pos X: 0, Pos Y: 0 (giữa header)
- AvatarImage bên trong với sprite nhân vật

**3 sao trên Avatar**:
- Di chuyển Star_1, Star_2, Star_3 từ `score` vào `Avatar`
- Xếp theo hình vòng cung phía trên avatar

---

### 6. Bo góc Board Game ✅
**Mục đích**: Bo góc mềm mại cho board game, đổi màu viền đồng bộ với nền slot

**File đã sửa**: `Assets/DM_Scripts/BoardManager.cs`

#### Dòng 1559-1562: Bật/tắt outline
```csharp
public void DrawBoardOutline()
{
    // Bo góc board game - đổi màu outline thành màu xanh đậm giống nền slot
    // Nếu muốn ẩn hoàn toàn outline, bỏ comment dòng return bên dưới
    // return;

    // ... code vẽ outline
}
```

#### Dòng 1757-1762: Đổi màu outline
```csharp
// Đổi màu outline thành màu xanh đậm giống nền slot bg_ingame_tile2_m.png (#00586c)
SpriteRenderer outlineSR = gameObject.GetComponent<SpriteRenderer>();
if (outlineSR != null)
{
    outlineSR.color = Color.white; // Hiện tại đang dùng màu trắng để test
}
```

**Sprites outline cần đổi màu** (trong `Assets/DM_Sprites/`):
- `SR_IngameUI_outline_bottom.png`
- `SR_IngameUI_outline_middle.png`
- `SR_IngameUI_outline_top.png`
- `SR_IngameUI_outline_top-edge.png`

**Màu chuẩn nền slot**: `#00586c`

**Cách đổi màu sprite**:
1. Mở sprite bằng Photoshop/GIMP
2. Đổi màu thành `#00586c`
3. Save và refresh Unity

---

## Hướng dẫn thay thế Sprites/Images

### Thay sprite trong Unity
1. Copy file ảnh mới vào thư mục `Assets/DM_Sprites/`
2. Chọn file trong Project window
3. Trong Inspector, đổi:
   - **Texture Type**: Sprite (2D and UI)
   - **Sprite Mode**: Single (hoặc Multiple nếu là spritesheet)
4. Click **Apply**
5. Kéo thả sprite vào **Source Image** của object cần thay

### Thay sprite cho UI elements
**Header background**: `BoardTopInfo > Image` → Source Image
**Footer background**: `BottomPanel` → Source Image
**Move/Goal box**: `MoveInfo > bg` hoặc `Goal > bg` → Source Image
**Avatar frame**: `Avatar` → Source Image

### Thay sprite cho Board outline
1. Thay các file `SR_IngameUI_outline_*.png` trong `Assets/DM_Sprites/`
2. Hoặc sửa code trong `BoardManager.cs` method `DrawBoardOutline()`

---

## Hướng dẫn chỉnh sửa Booster Button

### Vị trí prefab
`Assets/Resources/ButtonBooster.prefab`

### Cấu trúc prefab
```
ButtonBooster
├── frame_bg
├── bg
├── Item
├── Item_free
├── PriceSetForPreBooster
├── Button_buy_bg
├── Button_number           # ← Chứa số lượng booster
│   ├── ImageGreen
│   ├── ImageYellow         # ← Hình tròn nền số lượng
│   └── Text
├── Button_buy
├── Eff_Item_use
├── Eff_Itemuse_fail
├── ButtonAd
└── Image_highlight
```

### Chỉnh vị trí số lượng booster
1. Mở prefab `ButtonBooster` (double-click trong Unity)
2. Chọn `Button_number`
3. Chỉnh **Pos Y** để đẩy lên/xuống
4. Ctrl+S để save prefab

### Đổi màu/sprite hình tròn số lượng
1. Chọn `Button_number > ImageYellow`
2. Đổi **Source Image** hoặc **Color** trong Inspector
3. Sprite hiện tại: `available_indicator`

---

## Thông tin kỹ thuật quan trọng

### Singleton Pattern
Game sử dụng `MonoSingleton<T>` cho các manager:
```csharp
MonoSingleton<PlayerDataManager>.Instance
MonoSingleton<PopupManager>.Instance
MonoSingleton<UIManager>.Instance
MonoSingleton<AppEventManager>.Instance
```

### Ad System (Gley Mobile Ads)
```csharp
using Gley.MobileAds;

// Initialize
API.Initialize(OnInitialized);

// Show ads
API.ShowBanner(BannerPosition.Bottom, BannerType.Adaptive);
API.ShowInterstitial();
API.ShowRewardedVideo(OnRewardedComplete);
API.ShowAppOpen();
```

### Popup System
```csharp
// Mở popup
MonoSingleton<PopupManager>.Instance.Open(PopupType.PopupSettings);

// Đóng popup
MonoSingleton<PopupManager>.Instance.Close();
```

### Animation (DOTween)
Game sử dụng DOTween cho animations:
```csharp
using DG.Tweening;

transform.DOMove(target, duration);
rectTransform.DOAnchorPosX(value, duration);
```

### Board System
```csharp
// BoardManager.cs - Quản lý board game
BoardManager.main.GetSlot(x, y);           // Lấy slot tại vị trí
BoardManager.main.DrawBoardOutline();      // Vẽ viền bo góc
BoardManager.main.SpritesSlotBackground;   // Mảng sprite nền slot
```

### Booster System
```csharp
// Booster.cs - Các loại booster
public enum BoosterType
{
    Hammer,      // Phá 1 block
    CandyPack,   // Tạo combo
    Shuffle,     // Xáo trộn board
    HBomb,       // Bomb ngang
    VBomb,       // Bomb dọc
    Max,
    Move5,       // +5 moves
    Move1,       // +1 move
    NONE
}
```

---

## Lưu ý quan trọng

1. **Save Scene**: Luôn nhớ Ctrl+S sau khi chỉnh sửa trong Unity Editor
2. **Play Mode**: Thay đổi trong Play Mode sẽ mất khi dừng, cần copy giá trị ra trước
3. **Sprite Import**: Khi thêm sprite mới, đổi Texture Type → "Sprite (2D and UI)"
4. **Anchors**: Sử dụng anchors đúng để UI responsive trên nhiều màn hình
5. **Prefab Edit**: Double-click prefab để mở chế độ edit, Ctrl+S để save

---

## Công việc tiếp theo (TODO)

### UI/UX
- [ ] Đổi màu sprite outline board thành #00586c
- [ ] Chỉnh vị trí số lượng booster (Button_number Pos Y)
- [ ] Kiểm tra UI trên các tỷ lệ màn hình khác (18:9, 20:9, tablet)
- [ ] Điều chỉnh ViewLandscape nếu cần hỗ trợ landscape mode

### Monetization
- [ ] Cấu hình Interstitial ads (quảng cáo giữa level)
- [ ] Cấu hình Rewarded ads (xem quảng cáo nhận thưởng)
- [ ] Test IAP (In-App Purchase)

### Gameplay
- [ ] Review level balance
- [ ] Test daily spin reward
- [ ] Test booster functionality

### Build & Release
- [ ] Cấu hình keystore cho Android
- [ ] Build APK để test trên thiết bị thật
- [ ] Test trên nhiều thiết bị Android khác nhau

---

## Ngày cập nhật
- **2026-01-15**: Khởi tạo document, hoàn thành UI footer redesign
- **2026-01-16**:
  - Hoàn thành Header UI redesign (Move/Goal box, Avatar, 3 sao)
  - Bo góc board game, đổi màu outline
  - Tìm hiểu cấu trúc Booster prefab
