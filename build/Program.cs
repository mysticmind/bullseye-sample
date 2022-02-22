using static Bullseye.Targets;
using static SimpleExec.Command;

// Create a build target for npm install to make esbuild available for use
Target("npm:install", () => Run("npm","install"));

// Create build target esbuild:dist target which will minify 
// CSS under static/css and add it to wwwroot/css folder
// This build target has a depedency on `npm:install` build target 
Target("esbuild:dist", DependsOn("npm:install"), () => Run("npm","run minify"));

// Create build target esbuild:dist target which will allow to 
// watch for changes in dev env
// This build target has a depedency on `npm:install` build target 
Target("esbuild:watch", DependsOn("npm:install"), () => Run("npm","run watch"));

// Create a build target Clean the web project output from previous build
Target("clean", () => Run("dotnet","clean src/WebApp/WebApp.csproj"));

// Create a build target to compile the web project
// This build target depends on `clean` build target 
Target("compile", DependsOn("clean"), () => Run("dotnet","build ./src/WebApp/WebApp.csproj -c Release"));

// Create a build target to watch for changes in dev
// This build target depends on `clean` build target
Target("watch", () => Run("dotnet", "watch --project ./src/WebApp/WebApp.csproj"));

// Create a default target
// This target depends on `esbuild:dist` and `compile` build targets
Target("default", DependsOn("esbuild:dist", "compile"));

await RunTargetsAndExitAsync(args);
