This sample demonstrates creating a build tool for a .NET project using a combination of [Bullseye](https://github.com/adamralph/bullseye) in combination with [SimpleExec](https://github.com/adamralph/simple-exec).

This repo has a .NET sample project a below:
- `src/WebApp` folder contains a .NET 6 minimal api web app with a Razor page to serve the index. 
- `src/WebApp/static/css/site.css` contains the css file for the web app which is referenced in the Razor page
- `package.json` at the root folder which has dev dependencies to `esbuild` and defines 2 scripts for minify and watch.
- minify - `esbuild --minify ./src/WebApp/static/css/site.css --outdir=./src/WebApp/wwwroot/css`
- watch - `esbuild --watch ./src/WebApp/static/css/site.css --outdir=./src/WebApp/wwwroot/css`
- ESBuild is used to minify the static assets i.e. css files from `src/WebApp/static/css`  and adds it under `wwwroot/css`
- build related project is under `build` folder.
- Use `build.sh`, `build.cmd` or `build.ps1` to run build.

For more details check [blog post](https://mysticmind.dev/dotnet-build-tool-using-bullseye-and-simpleexec).
 
