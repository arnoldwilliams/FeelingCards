# FeelingCards

A **.NET 10 MAUI** mobile app (Android + iOS) that shows the *"How would you feel
if…"* feeling cards as a swipeable **carousel**, with **Previous / Next** buttons
for stepping through the cards one at a time.

## Features

- `CarouselView` with swipe navigation between all 20 cards
- **Previous** / **Next** buttons for manual, one-at-a-time navigation
- Page indicator dots plus a *"n of 20"* counter
- Each card shows the original illustration together with its prompt text
- Buttons disable automatically at the first and last card

## Project layout

```
FeelingCards.slnx                     Solution (new .NET 10 XML solution format)
FeelingCards/
├─ FeelingCards.csproj                Target frameworks: net10.0-android, net10.0-ios
├─ App.xaml(.cs)                      Application definition
├─ AppShell.xaml(.cs)                 Shell host
├─ MainPage.xaml(.cs)                 Carousel + Previous/Next UI
├─ MauiProgram.cs                     DI / font / handler registration
├─ Models/FeelingCard.cs              Card model (image + prompt)
├─ ViewModels/MainViewModel.cs        Card data, current position, commands
├─ Platforms/Android                  MainActivity, MainApplication, manifest
├─ Platforms/iOS                      AppDelegate, Program, Info.plist
└─ Resources/
   ├─ Images/card_01..card_20.jpg      The 20 card illustrations
   ├─ Fonts/                           DejaVu Sans (regular + bold)
   ├─ AppIcon/                         App icon SVGs
   ├─ Splash/                          Splash screen SVG
   └─ Styles/                          Colors.xaml, Styles.xaml
```

## The cards

The 20 cards were extracted from the supplied *"How would you feel if…"* sheets
and are stored as `Resources/Images/card_NN.jpg`:

| # | Prompt | # | Prompt |
|---|--------|---|--------|
| 1 | The internet was broken at school? | 11 | You didn't do your homework? |
| 2 | You lost your mobile phone? | 12 | You had an argument with your friend? |
| 3 | It was the beginning of the summer holidays? | 13 | You were told off in class? |
| 4 | There was chocolate cake at lunchtime? | 14 | You weren't allowed on the computers? |
| 5 | School finished early tomorrow? | 15 | You were late to school? |
| 6 | You had to miss a break? | 16 | Today was your birthday? |
| 7 | You went on a rollercoaster? | 17 | It began to snow? |
| 8 | You went to a friend's house? | 18 | You had no one to play with at break? |
| 9 | You went to the cinema? | 19 | You forgot your lunch? |
| 10 | You were listening to your favourite music? | 20 | There was a fire alarm? |

## Building

Requirements: .NET 10 SDK with the `maui` workload, plus the Android SDK/JDK for
Android builds. iOS builds additionally require macOS with Xcode.

```bash
# Android
dotnet build FeelingCards/FeelingCards.csproj -f net10.0-android -c Debug

# iOS (on macOS)
dotnet build FeelingCards/FeelingCards.csproj -f net10.0-ios -c Debug
```
