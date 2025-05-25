# Custom Scroll Rect

This repository contains a couple of scripts that extend the default ScrollRect component in Unity. CustomScrollRect addresses a few problems with ScrollRect:
- Scroll wheel input conflicting with dragging input.
- Multiple touches on the scroll view causing conflicting input.
- Forces the MovementType to "Elastic" on iOS and Android, and "Clamped" otherwise.
- Disabling dragging input, scroll wheel input, both, or neither.

Feel free to use or share however you would like. 

Watch the full tutorial here: https://youtu.be/Pm3oonzb5K8

## How to Use
- Import the scripts into a Unity project. Last tested in Unity 2022.3.
- Make sure to place the editor script (CustomScrollRectEditor) in a folder named "Editor".
- Replace the ScrollRect component with CustomScrollRect.
