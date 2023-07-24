# HUSH

## What is hush?
Hush is first and foremost a meditation. To make the viewer more present in the meditation it deviates from the classical audio platform to a virtual reality platform. Particularly, it is a meditation that can be experienced just with an android phone and a Google Cardboard VR Viewer. You can choose from two different meditation scenes (Ocean and Garden), various background audio, as well as set the daytime and the voice for the meditation audio.

## How was it made?
Hush was made in Unity 2023.3.23f1. It makes use of the Google Cardboard XR Plugin (https://developers.google.com/cardboard/develop/unity/quickstart) as well as the Oculus Voice SDK (https://developer.oculus.com/documentation/unity/voice-sdk-overview/). 

## Content of the repository

## SDKs   
The project is set to build for Android, so you need to have downloaded the Android SDK for Unity either during installation or after installation through the unity hub.

You also need the Google Cardboard XR Plugin installed. A thorough guide for installation can be found here: https://developers.google.com/cardboard/develop/unity/quickstart. 

Finally you need the Oculus Voice SDK. In this project the standalone Voice SDK Version 54.0 was used. You can download it from here: https://developer.oculus.com/downloads/package/oculus-voice-sdk/. For the Wit Application it should be sufficient to use the pre-made configuration file that you can find under Assets/WitConfigurations/VersionX.asset (currently workign with Version1.asset).

## Other tools/SDKs/Assetpacks... How to get repository to work
Some of the prefabs used are from the Standard Assets 2018.4 Asset Pack (especially the water prefabs). Unity does not officially support the package anymore, but you can still find it here: https://github.com/jamschutz/Unity-Standard-Assets.

For the Skybox Assets that are used during the daytime switch, the following Asset Packs need to be installed: https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014 & https://assetstore.unity.com/packages/2d/textures-materials/sky/8k-skybox-pack-free-150926

For the flying birds, the following Asset Pack was made use of:
https://assetstore.unity.com/packages/3d/characters/animals/simple-boids-flocks-of-birds-fish-and-insects-164188

For the meditation scenes, the following Asset Packs were used:
https://assetstore.unity.com/packages/3d/environments/fantasy/fantasy-forest-environment-free-demo-35361 &
https://assetstore.unity.com/packages/3d/props/exterior/polygon-prototype-low-poly-3d-art-by-synty-137126

## Overview of Build Settings

## Relevant Docus
To become more familiar with the Oculus Voice SDK, the following tutorial covers the functionality quite well (it was made for the experimental Wit SDK and not the Voice SDK, but with a little bit of thinking it can easily be applied to the Voice SDK, since it works in basically the same way, just with different names): https://github.com/wit-ai/wit-unity/blob/main/Tutorials/ShapesTutorial.md
