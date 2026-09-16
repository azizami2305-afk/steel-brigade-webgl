# Steel Brigade - WebGL Prototype

This repository will contain a Unity WebGL prototype for an original 2.5D run-and-gun inspired by classic arcade shooters.

Working title: Steel Brigade

Unity version: Recommended Unity 2022.3 LTS (or later LTS). Use the same major version locally when opening the project.

This initial commit adds core C# scripts (systems only) and a README with setup notes. Scenes, art, and WebGL builds will be added in subsequent commits.

What to expect next
- I will scaffold a Unity project (ProjectSettings, Packages) and create a prototype scene with placeholder models.
- Implement player movement, shooting, one enemy, a mountable tank, HUD, and a WebGL build.

How to open locally
1. Install Unity Hub and Unity 2022.3 LTS.
2. Clone this repository and create a new Unity project named "SteelBrigade".
3. Copy the Assets folder from the repo into your Unity project, open Unity and let it compile.

WebGL build notes
- Use Compression Format: gzip or Brotli in Player Settings and configure your host to serve .gz/.br files with correct Content-Encoding headers.
- Reduce build size: strip engine code, use Addressables for large assets, compress textures (ETC2/ASTC), and minimize audio/music bundle sizes.

License: MIT. Repo visibility: public.

