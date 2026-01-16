# Jellivo Saga

A Match-3 Puzzle Game built with Unity 6.0

![Unity](https://img.shields.io/badge/Unity-6.0-blue)
![Platform](https://img.shields.io/badge/Platform-Android-green)
![License](https://img.shields.io/badge/License-Private-red)

## Screenshots

| Lobby | Gameplay |
|-------|----------|
| Main menu with daily rewards | Match-3 puzzle gameplay |

## Features

- Classic Match-3 gameplay mechanics
- Multiple level types and goals
- Booster items (Hammer, Shuffle, Bombs, etc.)
- Daily rewards and spin wheel
- Beautiful candy-themed graphics
- Smooth animations with DOTween

## Tech Stack

- **Engine**: Unity 6.0 (6000.0.58f2)
- **Platform**: Android
- **Ads**: Google AdMob (Gley Mobile Ads)
- **Analytics**: Firebase
- **Animation**: DOTween

## Project Structure

```
Assets/
├── DM_Scripts/          # Main game scripts
│   ├── GameMain.cs      # Core gameplay controller
│   ├── BoardManager.cs  # Board and slot management
│   ├── PopupManager.cs  # Popup system
│   └── ...
├── DM_Scenes/           # Game scenes
│   ├── Game.unity       # Main gameplay scene
│   ├── Lobby.unity      # Lobby/menu scene
│   ├── Loading.unity    # Loading scene
│   └── Menu.unity       # Menu scene
├── DM_Sprites/          # Sprites and images
├── Resources/           # Dynamic loaded assets
└── Prefab/              # Prefabs
```

## Key Systems

### Singleton Pattern
```csharp
MonoSingleton<PlayerDataManager>.Instance
MonoSingleton<PopupManager>.Instance
MonoSingleton<UIManager>.Instance
```

### Popup System
```csharp
// Open popup
MonoSingleton<PopupManager>.Instance.Open(PopupType.PopupSettings);

// Close popup
MonoSingleton<PopupManager>.Instance.Close();
```

### Booster Types
- Hammer - Destroy single block
- CandyPack - Create combo
- Shuffle - Shuffle board
- HBomb - Horizontal bomb
- VBomb - Vertical bomb
- Move5 - Add 5 moves

## Setup

1. Clone the repository
2. Open with Unity 6.0 or later
3. Open `DM_Scenes/Loading.unity` to start

## Build

1. Go to File > Build Settings
2. Select Android platform
3. Configure Player Settings
4. Build APK

## Documentation

See [project.md](project.md) for detailed documentation in Vietnamese.

## Developer

**Dotmob Studio**
- Email: dotmobstudio@gmail.com

---

*This project uses Git LFS for large files (Firebase SDK, DLLs)*
