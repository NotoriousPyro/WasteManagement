# WasteManagement

Provides various waste management buildings to the game.

Currently provides:
* Incineration Plant

More may come... please create an issue for any suggestions or bugs.

# How to install

> :warning: **You will need to start a new game to play this mod. This is a restriction of CoI.**

1. From the downloaded zip, copy the contents of the `Mods` folder to your Captain of Industry `Mods` folder.

    By default, this is `Documents\Captain of Industry\Mods`. You can find out where exactly by running the following in PowerShell:
    ```powershell
    ((new-object -COM Shell.Application).Namespace(0x05).Self.Path + '\Captain of Industry\Mods')
    ```

2. Verify you have something like the following for each of the mods you installed, inside each folder should be a dll file with the same name as the folder.

3. Start a new game!

# How to use

## Basic setup
![Basic setup](docs/basicsetup.png)

## Research
* **Incineration plant**: dependant on Exhaust Filtration first being completed.
![Research: Incineration Plant](docs/research_incinerationplant.png)

## Recipes
* Incineration plant
![Recipes: Incineration Plant](docs/recipes_incinerationplant.png)
