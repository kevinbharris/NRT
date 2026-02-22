# 🧠 Nicotine Replacement Tracker (NRT)

> A Windows desktop application that helps track nicotine gum usage during nicotine replacement therapy by enforcing safe chewing intervals and providing audio + visual reminders.

## 📌 Overview

The **NRT Tracker** is a Windows Forms application designed to assist with nicotine cessation therapy management by:

- Tracking quit progress over time
- Enforcing safe chewing intervals
- Playing reminder audio alerts
- Supporting system tray background operation
- Persisting user settings in the Windows Registry

## 🚀 Features

### ⏱ Therapy Tracking
- Tracks:
  - Quit date
  - Last gum chewing time
  - Last time gum was spat out

### 🧾 Stage-Based Therapy Progression

| Week Range | Stage | Interval Between Pieces |
|---|---|---|
| Week 1–6 | Stage 1 | 1 hour |
| Week 7–9 | Stage 2 | 2 hours |
| Week 10–12 | Stage 3 | 4 hours |
| Week 13+ | Stage 4 | No restriction |

### 🔊 Audio Notifications

Supports custom sound alerts for:
- Chewing reminder alerts
- Spit reminder alerts

Uses:
- NAudio for audio playback

### 🔔 Smart Alerts

The app automatically notifies when:
- It is time to spit gum out
- It is time to chew another piece

Includes:
- Message box notifications
- Optional audio playback

### 💾 Registry-Based Persistence

Settings are stored under:

HKEY_CURRENT_USER\SOFTWARE\kbhtech\NRT

Persisted values include:
- Quit date
- App behavior preferences
- Audio file paths
- Status history
- Last chewing timestamps

### 🪟 System Tray Integration

Supports:
- Minimize to tray
- Close to tray
- Double click tray icon to restore

### 🏁 Startup Behavior

Optional:
- Launch application automatically on Windows startup

## 🧩 Architecture

The app follows an event-driven WinForms architecture.

### Core Components

#### Form Layer
- frmMain
- frmSettings
- frmAdjust
- frmConfig

Handles:
- User interaction
- Therapy workflow control

#### Persistence Layer

Registry helper methods manage:
- Typed registry reading
- Boolean storage
- File path storage
- Date storage using ticks
- Enum state persistence

#### Audio Engine

Uses:
- WaveOutEvent
- AudioFileReader

For:
- Sound playback lifecycle management
- Resource cleanup

## 🧠 Status State Machine
Ready → Chewing → Waiting → Ready

### Status Definitions

| Status | Meaning |
|---|---|
| Ready | User can chew next piece |
| Chewing | Gum currently being chewed |
| Waiting | Cooling-off period active |

## 🛠 Requirements

### Software
- Windows 10 / 11
- .NET Desktop Runtime

### Dependencies
- NAudio

Install via NuGet:

Install-Package NAudio

## 🧪 How It Works

### Startup Flow

1. Load quit date from registry
2. Load user preferences
3. Load audio files
4. Restore previous session state

If no quit date exists:
- User is prompted to configure one

### Timer Workflow

Every timer tick:

If Chewing:
- After 30 minutes:
  - Play spit alert sound
  - Show notification
  - Switch to waiting state

If Waiting:
- After required hours pass:
  - Play chew alert sound
  - Enable chewing button

## ⚙ Registry Schema

SOFTWARE
 └ kbhtech
    └ NRT
       ├ QuitDateTicks
       ├ StartedChewingLastPieceOfGumTicks
       ├ StoppedChewingLastPieceOfGumTicks
       ├ ChewSoundFile
       ├ SpitSoundFile
       ├ Status
       ├ CloseToTray
       ├ MinimizeToTray

## 📦 Building From Source

Clone repository:

git clone https://github.com/YOUR_USERNAME/NRT-Tracker.git

Open in:
Visual Studio 2022+

Build:
Build → Build Solution

## ▶ Running the Application

1. Launch executable
2. Enter quit date when prompted
3. Configure settings
4. Start therapy tracking

## 🎵 Adding Custom Sounds

1. Open Settings
2. Choose:
   - Chew reminder sound
   - Spit reminder sound
3. Select audio files

Supported formats:
- MP3
- WAV

## 🔧 Configuration

Users can configure:
- Start with Windows
- Close to tray
- Minimize to tray

Audio Alerts:
- Custom chew sounds
- Custom spit sounds

## 🧾 UI Displays

Main window shows:
- Current therapy week
- Therapy stage
- Time until next gum piece
- Last chewing timestamp

## 💡 Design Philosophy

Built to:
- Reduce decision fatigue
- Provide automated therapy pacing
- Support ADHD-friendly reminder workflows

## 🐞 Error Handling

Handles:
- Invalid registry values
- Missing audio files
- Playback failures
- Corrupt session state

## 🔒 Security

- No external data transmission
- All data stored locally

## 👨‍💻 Developer

Kevin B. Harris  
Email: kevin.b.harris.2015@gmail.com

## 📜 License

General Public License

## ❤️ Acknowledgements

- .NET Framework
- NAudio Contributors
- Therapy support communities

## ⭐ Support

- Star the repository
- Share with others
- Submit feedback via issues
