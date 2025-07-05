# Robot Vacuum Game

A 2D Unity game where you control a smart vacuum cleaner to collect stars in a room environment.

## Overview

Robot Vacuum Game is a simple 2D game built with Unity where the player controls a robotic vacuum cleaner. The objective is to navigate around a room and collect all the star collectibles to win the game.

## Features

- **Player Control**: Move the robot vacuum using WASD or arrow keys
- **Collectible System**: Collect star items scattered around the room
- **Room Environment**: Automatically generated room with walls and boundaries
- **Particle Effects**: Visual feedback when collecting stars
- **Win Condition**: Complete the level by collecting all stars

## Game Components

### Scripts

- **SmartVacuumController.cs**: Handles player movement and rotation
- **GameManager.cs**: Manages game state and win conditions
- **StarCollectible.cs**: Manages collectible star behavior and particle effects
- **RoomGenerator.cs**: Procedurally generates room walls and boundaries

### Key Features

- Smooth 2D movement with physics-based controls
- Automatic rotation towards movement direction
- Collision detection with room boundaries
- Particle effects on star collection
- Game over state management

## Controls

- **WASD** or **Arrow Keys**: Move the vacuum cleaner
- The vacuum automatically rotates to face the movement direction

## How to Play

1. Start the game
2. Use the movement controls to navigate the vacuum around the room
3. Collect all the star collectibles by moving over them
4. Once all stars are collected, you win the game!

## Technical Details

### Requirements

- Unity 2023.x or later
- TextMesh Pro package
- 2D Physics system

### Project Structure

```
Assets/
├── Scripts/
│   ├── SmartVacuumController.cs
│   ├── GameManager.cs
│   ├── StarCollectible.cs
│   └── RoomGenerator.cs
├── Scenes/
├── Prefabs/
├── Sprites/
└── Settings/
```

### Physics Settings

- Uses Rigidbody2D for movement
- BoxCollider2D for wall collision
- Trigger colliders for collectible detection

## Setup Instructions

1. Clone or download the project
2. Open in Unity 2023.x or later
3. Make sure all required packages are imported:
   - TextMesh Pro
   - 2D Animation
   - Universal Render Pipeline (URP)
4. Open the main scene
5. Press Play to start the game

## Game Settings

### Vacuum Controller Settings

- **Move Speed**: 3f (adjustable)
- **Rotation Speed**: 630f (adjustable)

### Room Settings

- **Room Size**: 16x9 units
- **Wall Thickness**: 0.1 units

## Development

### Adding New Features

To extend the game, you can:

- Add more collectible types
- Implement obstacles and hazards
- Create multiple levels
- Add sound effects and music
- Implement scoring system
- Add timer-based challenges

### Customization

- Adjust movement speed in `SmartVacuumController`
- Modify room size in `RoomGenerator`
- Change particle effects in star collectibles
- Add new game mechanics through `GameManager`

## Assets Used

- Unity's built-in sprites and materials
- TextMesh Pro for UI text
- Unity's particle system for effects

## License

This project is for educational purposes. Feel free to use and modify as needed.

## Version History

- **v1.0**: Initial release with basic gameplay mechanics
  - Player movement
  - Star collection
  - Room generation
  - Win condition

## Credits

Developed as part of SE18B04 - Semester 7 - PRU course project.

## Troubleshooting

### Common Issues

1. **Vacuum not moving**: Check if Rigidbody2D is attached and not frozen
2. **Stars not collecting**: Ensure colliders are set as triggers
3. **Win text not showing**: Verify GameManager is properly configured in the scene

### Performance Tips

- Keep particle systems optimized for mobile devices
- Use object pooling for multiple collectibles if expanding the game
- Optimize sprite textures for better performance
