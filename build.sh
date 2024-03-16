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
dotnet build 
cd ..

echo "Built"