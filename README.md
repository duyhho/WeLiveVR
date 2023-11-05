# WeLiveVR
Authors: Duy Ho, Hieu Trinh, Nhung Tran

## Award: 
- v1: 1st place (Spring 2022) - `https://info.umkc.edu/hack-a-roo/spring-2022-t-mobile-track-2/`
- v2: 3rd place (Fall 2022) - `https://info.umkc.edu/hack-a-roo/fall-2022-t-mobile-track/`

# Motivation


Our project, WeLive intends to show user two universes in Metaverse: one that is based on the physical world with enriched experiences, and the other that is purely imaginary, surreal but still relatable and playful. 
In these virtual worlds, our users can interact with the environment and other users in various ways. Such experience is refreshing, enjoyable and offers infinite possibilities for future development. 

# V1 (Spring 2022)
## Main Features
### Realistic 3D Scenarios:
- Gymnasium
- Classroom
- Doctor’s Clinic
- Conference Room
- Relaxing Scenery
  - Forest
  - Meadows
  - Lakes

### Diverse and Detailed Assets:
- Theme music is supported based on scenery.
- Multiple avatars for different settings.

### Real-time Interactions:
- Supports Interaction between players and objects
- Supports Communication between players
  - Voice chat
- Supports Interactions between players
  - Synchronization of object interaction
  - Object passing and catching

### Other backend features:
- Stores messages, texts, and voice in a meeting in database.
- Cross-platform compatibility (Android, Oculus, ...)
- Cloud Voice Transcription via API

## Implementation
### Front End
- **Unity**
  - Leading platform for 2D and 3D game and application development
  - Realistic physics mechanism and interaction (collision, gravity, speed, acceleration,
  - High-quality rendering and graphics
  - Cross-platform compatibility (mobile, android, PC, web, HoloLens, Oculus Quest, Oculus Rift, Vive, SteamVR, and Valve)
  - Abundant assets (standard, free, and paid) from Unity and other third parties
  - Strong community support and maintenance

- **OpenXR**
  - Cross-platform compatibility (Oculus Quest, Oculus Rift, Vive, SteamVR, and Valve).

- **Multiplayer Synchronization**
  - Photon PUN 2

- **Voice Chat**
  - Photon Voice

### Back End
- Firebase SDK for Unity
- Firebase SDK for Android
- Firebase Firestore Real-time Database
- Firebase Methods (Server)
- Firebase Authentication
- Firebase Storage
- Google Transcription API
- 
![media2](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media2.gif)
![media3](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media3.gif)
![media4](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media4.gif)
![media5](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media5.gif)
![media6](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media6.gif)
![media7](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media7.gif)
![media8](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media8.gif)
![media9](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media9.gif)
![media10](https://github.com/duyhho/WeLiveVR/blob/FruitNinja-Custom/Media/media10.gif)

# V2 (Fall 2022)
Focus: Enhanced single-player experience with haptics, lip sync, and real-time interaction with objects.

### Entertainment and Fitness:
- Fruit Ninja
- Cake Ninja
- Cube Ninja
- Alien Defense

#### Features:
- Precise weapon control with controller movement.
- Diverse assets, themes, music.
- Built-in controller-to-hand mapping and animation.
- Slice animations and special effects.
## Avatars

- Utilized [ReadyPlayer.Me](https://readyplayer.me) and Mozilla Hub VR Half-body character design with programmable visemes (lipsync-ready animations).
  - Quick imports and diverse designs.
  - Compatible with OVR Lipsync and ARKit Facial animation.
- Avatars are designed with 3 bones for each finger (index, thumb, middle, ring, and pinky)
- Animations are mapped based on headset and controller input
  - Headset -> Head and body
  - Trigger -> Index finger
  - Primary buttons -> Thumb
  - Grip -> Middle, ring, and pinky
- Avatar lipsync based on user's speech via OVR Lipsync.
- Real-time character switch
![image](https://github.com/duyhho/WeLiveVR/assets/17374092/bab69167-63bb-45dd-8e96-38d3eb4f1281)
### Medical Training
#### At-home Medical Training (Controller-based)
- **3D surgical devices with responsive real-time visual/audio feedback and built-in haptics.**
#### At-home Medical Training (Hand-based)
- **3D surgical devices with responsive real-time visual/audio feedback.**
### [![Use case: Trocar Surgery with Visual, Audio, and Haptic feedback](https://img.youtube.com/vi/iasvHwjaKyU/0.jpg)](https://youtu.be/iasvHwjaKyU)

Use case:
Trocar Surgery with Visual, Audio, and Haptic feedback

#### 3D Models:
- Bladder
- Pelvic Bone
- Cartilage
- Blood vessels

#### Visual Feedback:
- 3D Models will appear to indicate positions once device tip touches.
- Surgical device will change color for a few seconds.

#### Audio Feedback:
- Alarm will sound upon collision with vital organs.

#### Haptic Feedback:
- Controller will vibrate for half a second upon touching the vital organs.

#### Features:
- Collision tracking between device and object.
- Animations enabled for each button:
  - Index finger – Trigger button
  - Thumb – Primary buttons
  - Three fingers – Grip Button
- Precise placement of device on hand
- Visual feedback: warnings upon collision with vital organs and blood vessels.
- Audio feedback: alarm activation upon touching organs.
- Haptic feedback: Controller vibration upon mistakes.



#### Features:
- Collision tracking between hand/fingers and object.
- Precise placement of device on hand grip
- Visual feedback: warnings upon collision with vital organs and blood vessels.
- Audio feedback: alarm activation upon touching organs.


## Additional Demos: 
Cube Ninja (Beat Saber - Simplified)

### [![Cube Ninja (Beat Saber - Simplified)](https://img.youtube.com/vi/BtuJVMuRp-g/0.jpg)](https://youtu.be/BtuJVMuRp-g)

Alien Defense (Fitness game)

### [![Alien Defense (Fitness game)](https://img.youtube.com/vi/oF1l-QRNQtQ/0.jpg)](https://youtu.be/oF1l-QRNQtQ)













