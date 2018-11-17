#!/usr/bin/env bash

mono=${MONO:=0}
dotnet=${DOTNET:=0}

case "$1" in
  dotnet)
    dotnet=1
    mono=0
    ;;
  mono)
    mono=1
    dotnet=0
    ;;
esac

echo "* settings: mono=$mono, dotnet=$dotnet"

set -e

if [ $dotnet -eq 1 ]; then
  echo "* building and testing dotnet"

  if [ "$TRAVIS_OS_NAME" == "osx" ]; then
    ulimit -n 1024
    dotnet restore --disable-parallel --runtime osx-x64
  else
    dotnet restore --runtime ubuntu-x64
  fi

  dotnet test ./test/BinaryEncoding.Tests/BinaryEncoding.Tests.csproj --configuration Release --framework netcoreapp2.0 --no-restore --blame
fi

if [ $mono -eq 1 ]; then
  echo "* building and testing mono"
  msbuild ./test/BinaryEncoding.Tests/BinaryEncoding.Tests.csproj /p:Configuration=Release;Platform=x64 /restore:true
  mono $HOME/.nuget/packages/xunit.runner.console/*/tools/net452/xunit.console.exe ./test/BinaryEncoding.Tests/bin/x64/Release/net452/BinaryEncoding.Tests.dll
fi
