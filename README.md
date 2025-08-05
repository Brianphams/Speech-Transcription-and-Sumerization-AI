# Speech-to-Text & Summarization App

This project is a web application that allows users to upload MP3 or MP4 audio files, transcribe them to text using WhisperX, and generate summaries using the T5 model. It consists of a FastAPI backend for transcription and summarization, an ASP.NET Core backend for handling file uploads and real-time updates via SignalR, and a Razor-based frontend for user interaction. The application is designed to be run locally and can be hosted on a Git repository for collaboration.
Features
Audio Upload: Supports MP3 and MP4 file uploads.
Transcription: Transcribes audio into text segments using WhisperX.
Summarization: Summarizes transcribed text using T5, splitting long texts into chunks for processing.
Real-Time Updates: Displays transcription segments, full transcript, summary chunks, and final summary via SignalR.
Responsive UI: Built with Razor, Bootstrap, and custom CSS, featuring collapsible sections for results.
Technologies Used
FastAPI Backend:
Python 3.10: Core programming language.
FastAPI (0.115.2): Web framework for the transcription and summarization API.
WhisperX (3.1.5): For audio transcription.
Transformers (4.45.2): For T5-based text summarization.
Pydub (0.25.1): For audio file conversion (MP3/MP4 to WAV).
PyTorch (1.10.0+cu102): For WhisperX and T5 model execution.
Pyannote.audio (0.0.1): For voice activity detection in WhisperX.
Uvicorn (0.32.0): ASGI server for FastAPI.
FFmpeg: System dependency for audio processing.
ASP.NET Core Backend
.NET 6.0: Framework for the backend.
ASP.NET Core MVC: For serving Razor views.
SignalR (6.0.0): For real-time communication between backend and frontend.
Hangfire (1.7.28): For background job processing.
HttpClient: For communicating with the FastAPI backend.
Frontend:
Razor (ASP.NET Core): For rendering the UI (Index.cshtml)
Bootstrap (5.x): For responsive styling.
jQuery (3.x): For DOM manipulation.
SignalR Client (7.0.5): For real-time updates from the backend.
Custom CSS/JavaScript: For collapsible sections and UI enhancements.
Project Structure

project/
├── fastapi/
│   └── app.py                # FastAPI backend for transcription and summarization
├── aspnetcore/
│   ├── SpetoTex/
│   │   ├── Controllers/
│   │   │   └── VideoUploadController.cs  # Handles file uploads
│   │   ├── Hubs/
│   │   │   └── VideoProcessingHub.cs     # SignalR hub for real-time updates
│   │   ├── Service/
│   │   │   └── VideoProcessingService.cs # Processes uploads and communicates with FastAPI
│   │   ├── Views/
│   │   │   ├── Home/
│   │   │   │   └── Index.cshtml          # Razor frontend
│   │   │   └── Shared/
│   │   │       └── _Layout.cshtml        # Layout without navbar
│   │   ├── wwwroot/
│   │   │   ├── css/site.css              # Custom styles
│   │   │   ├── js/site.js                # Custom scripts
│   │   │   └── lib/
│   │   │       ├── bootstrap/            # Bootstrap CSS and JS
│   │   │       └── jquery/               # jQuery
│   │   └── Program.cs                    # ASP.NET Core configuration
│   └── SpetoTex.csproj                   # Project file
└── README.md                             # This file







Git: For cloning the repository.
