# PEngine (Pokemon Engine)

Pokemon Engine is a tool to create your own Generation 2 Pokemon games without the need of an emulator, roms or multiple obscure development tools.
It includes two main components: 
- The creator program that lets you create maps, scripts and texts
- The game - this runs your projects created in the creator program.

It's also easy to share any created game with others by packaging your project with the game as a portable executable.

## Current status
![](https://i.imgur.com/gu49QuR.png)  
>The game is able to display basic maps and allows for player movement.

## Technical side of things

The game runs on MonoGame 3.7 and currently only on the DirectX platform (=> Windows). I might port this to Linux later.
The creator program is written using the Windows Forms platform and therefore also only available for Windows.

In short: Game runs on Windows, might be on Linux later, Creator is Windows-only.

All code is written in C# and compiled with .Net 4.5.
