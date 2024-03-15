#!/bin/bash

frontend_dir="wifi-finder"
backend_dir="src"
build_dir="build_dir"
output_dir="output_dir"

rm -rf "$build_dir"
rm -rf "$output_dir"

echo "Building Frontend..."
cd $frontend_dir || exit
npm install
npm run build
cd ..

echo "Building Backend..."
cd $backend_dir || exit
msbuild wiFind.sln /p:Configuration=Release /p:OutputPath="../$build_dir"
cd ../../..

echo "Copying Frontend to backend"
cp -r "$frontend_dir/build" "$backend_dir/wwwroot"

echo "Publishing Backend"
dotnet publish "$backend_dir/wiFind.Server/wiFind.Server.csproj" -c Release -o "$output_dir"

echo "Built"