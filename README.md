# app-ruleta
My first roulette-game application

> *__Note:__ This is a quite old project, I will create a new one using better practices*

## About
This is a full-screen, like-game WPF application in with you can create a roulette with a number of attempts and a list of prizes that can be configured.

## How to debug
1. Open solution with Visual Studio 2015 or later
2. In solution explorer, right click on solution and select `Restore Nuget Packages`
3. Rebuild project
4. Clic on Debug button

## How to release
1. Open solution with Visual Studio 2015 or later
2. In solution explorer, right click on solution and select `Restore Nuget Packages`
3. In __Build__ section of __project properties__, change the configuration from `Debug` to `Release`.
4. Rebuild project
5. In solution explorer, right click on project and select `Publish`

## How to configure
1. After running the application, it will show a __Config Window__ with three sections:
    1. __Formulario__: In this section you can add fields if you need some information of the participants.
    2. __Ruleta__: In this sectioin you can add prices and you can set the number of attempts.
    3. __Imágenes__: In this section you can configure the images of the application such background image.
2. After configuring the application, you can clic on __Guardar__ (Save) button to save the changes and start the game.
3. With the game running, you can press `F12` to go back to the __Config Window__

## Develop Info
AppRuleta was developed as a WPF/XAML desktop application using MVVM pattern with .NET Framework 4.5 and Visual Studio 2015.

### Nuget packages used
|Package|Version|Project URL|
|-|-|-|
|CommonServiceLocator|1.3.0|[Project URL](https://github.com/unitycontainer/commonservicelocator)|
|MvvmLight|5.3.0|[Project URL](http://www.mvvmlight.net/)|
|MvvmLightLibs|5.3.0|[Project URL](http://www.mvvmlight.net/)|
