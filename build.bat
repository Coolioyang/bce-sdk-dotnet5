@echo off

echo == %DATE% %TIME% ==
set BUILD_HOME=%cd%
set OutputFolderBase=output

if exist %OutputFolderBase% (
    rmdir /s /q %OutputFolderBase%
)
if not exist %OutputFolderBase% ( 
    md %OutputFolderBase%
)

echo == %DATE% %TIME% ==
set PATH=D:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE;%PATH%

:: compile release
if %BUILD_RELEASE% equ 1 (
    echo == %DATE% %TIME% ==
    echo Compile Sources for Release...
    msbuild BceSdkDotNet.sln /t:Clean;Rebuild /m:4 /p:Configuration=Release > x86.release.compile.log
    xcopy /E /Y BceSdkDotNet\bin\2008\Release\*.* %OutputFolderBase%
    echo ******************* Build Release Done! ********************
)

@echo on
exit
