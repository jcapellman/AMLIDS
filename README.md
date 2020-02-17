# Android Machine Learning Intrusion Detection System
This repository contains all of the work for my DSc in Cybersecurity from Capitol Tech University.

## Components

### Android App (written in C# with Xamarin Forms)
1. Create the Android App to collect the hypothetical information needed to create the model
2. Add LiteDb and syncing to the gRPC service
3. Add background service to do the syncing automatically
4. Add ML detections from the background service

### gRPC Service (written in C# with ASP.NET Core)
1. Create a gRPC service and backend to store the data

### Model Training (Unknown approach at this time)
1. Take the data and train the model

## Compiling
As of this writing, Visual Studio 2019 16.4.5 for Windows compiles and builds all of the projects.  Visual Studio 2019 for Mac should also be able to build all of the projects (however this is not supported as I do not use a Mac for development).

### Component Specific Requirements
* gRPC Service requires .NET Core 3.1
* Android app in order to compile needs the Android SDK (targeting Android Q as of this writing)

## Notes
All of the source code, data and models are purely created for research and to satisfy my DSc - malicious intent is explicity prohibited.  In addition commercial use of this work is only permitted per you following the included license.
