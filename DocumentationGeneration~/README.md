# Generating GoCS Documentation

In order to generate API documentation files, GoCS needs to:

1. Build a DLL via Visual Studio to force the generation of a XML documentation file
2. Use the generated XML documentation file to generate Markdown files via [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation)

However, since we're not legally allowed to redistribute Unity DLLs needed to build the project, you'll need to copy them manually to the `DocumentationGeneration~/ref` folder.

In the following paths, `%UNITY%` refers to:

- On Windows: `%PROGRAMFILES%\Unity\Hub\Editor\2018.4.X`
- On Mac: (TODO)

You need to copy:

1. `%UNITY%\Editor\Data\Managed\UnityEngine.dll`
2. `%UNITY%\Editor\Data\Managed\UnityEditor.dll`
3. `%UNITY%\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll`

Then:

1. Open `DocumentationGeneration~/GoCS.sln` in Visual Studio
2. Restore NuGet packages to install DefaultDocumentation
3. Build!

The Markdown files should automatically get created under `Documentation~/API`.