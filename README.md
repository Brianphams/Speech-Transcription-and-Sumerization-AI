🎙️ Speech-to-Text & Summarization App
Turn voice into readable text and get a summary — in real time!

🚀 Overview
This web app lets you upload MP3 or MP4 files and automatically:

✨ Transcribe speech to text using AI (WhisperX)
✨ Summarize the content using the T5 model
✨ View results live on the interface with real-time updates

It’s designed to run locally — great for demos, research projects, or as a base for production systems.

🔍 Key Features
✅ Easy upload for MP3/MP4 files
✅ Automatic and accurate speech transcription
✅ Readable, AI-powered content summarization
✅ Real-time result updates using SignalR
✅ Clean, intuitive interface with collapsible result sections

🛠️ Tech Stack
🎧 Audio Processing & AI (Python + FastAPI)
WhisperX: Accurate speech recognition

T5 Transformer: Text summarization

FastAPI + Uvicorn: High-speed backend API

PyDub + FFmpeg: Converts audio for processing

🌐 Frontend & Orchestration (ASP.NET Core)
ASP.NET Core MVC + Razor: Dynamic web interface

SignalR: Real-time updates as processing happens

Hangfire: Background processing made easy

Bootstrap & jQuery: Smooth and responsive UI

🖼️ UI Sneak Peek

<img width="886" height="546" alt="Screenshot 2025-08-05 231340" src="https://github.com/user-attachments/assets/e571db91-51a8-46a7-a71d-b953904e030e" />
<img width="849" height="572" alt="Screenshot 2025-08-05 231406" src="https://github.com/user-attachments/assets/23707272-a7e8-4d67-9374-8c1112eac894" />
