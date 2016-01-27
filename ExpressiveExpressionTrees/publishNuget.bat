del /Q ExpressiveExpressionTrees*.nupkg
nuget pack -Symbol -Prop Configuration=Release
nuget push ExpressiveExpressionTrees*.nupkg


REM vim: set expandtab ts=2 sw=2: 
