# AGENTS.md

FeelingCards — a .NET 10 MAUI app (Android + iOS) that shows "How would you feel if…"
cards. Card navigation is driven by `CurrentCard` plus `Next`/`Previous` commands, with
swipe gestures and tappable indicator dots.

## Layout: avoid star-sized rows

Do **not** use a `Grid` star (`*`) row as a page root, and do not nest one inside a
`VerticalStackLayout`. In this MAUI 10 / Android environment the page is measured against
an unbounded height, so a star row expands to the measure bound and collapses every row
after it. The symptom is an app that looks stuck on the splash screen because the content
and buttons are pushed off screen.

Give each element an explicit `HeightRequest` instead. Explicit heights are stable because
they do not depend on the parent's height. A pristine `dotnet new maui` app reproduces the
star-row failure, so it is environmental rather than specific to this project.

## Build

```bash
export DOTNET_ROOT=/workspace/dotnet
export PATH=$PATH:/workspace/dotnet
export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1   # no ICU in this image
export JAVA_HOME=/usr/lib/jvm/java-21-openjdk-amd64
export ANDROID_HOME=/workspace/android-sdk
export ANDROID_SDK_ROOT=/workspace/android-sdk

dotnet build -f net10.0-android -c Release \
  -p:TargetFrameworks=net10.0-android \
  -p:AndroidSdkDirectory=/workspace/android-sdk
```

`JAVA_HOME` may need reinstalling after a container restart:
`sudo apt-get update && sudo apt-get install -y openjdk-21-jdk-headless`.

## Emulator

This container has no `/dev/kvm`, so the emulator runs in software mode and is very slow.
Expect long boot times and occasional ANRs. Debug builds are more likely to be killed by
ANR than Release builds, so verify with Release.

```bash
avdmanager create avd -n fc_test -k "system-images;android-35;google_apis;x86_64" -d pixel_6 --force
emulator -avd fc_test -no-window -no-audio -no-boot-anim -gpu swiftshader_indirect -memory 2048 -no-snapshot -accel off -qemu -cpu qemu64
```

Inspect the rendered layout with `adb shell uiautomator dump` plus `adb exec-out screencap`,
and check `AccessibilityNodeInfoDumper` lines in `adb logcat` for bounds of off-screen views.

## Git

Push with the token in the remote URL:
`git push "https://${GITHUB_TOKEN}@github.com/arnoldwilliams/FeelingCards.git" <branch>`.
The token embedded in `origin` may be stale.
