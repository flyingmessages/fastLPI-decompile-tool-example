@echo off

rem $$$FILEPATH$$$
rem $$$JARPATH$$$
rem SET FILEPATH=
SET FILEPATH="C:\Users\user\source\repos\Test\bin\Debug\netcoreapp3.1\dataAnalytics\Jar Data\jd-gui-forLPI.jar"
SET JARPATH="C:\Users\user\source\repos\Test\bin\Debug\netcoreapp3.1\dataAnalytics\Jar Data\jd-gui-forLPI.jar"

IF exist "%FILEPATH%" goto :Loading
IF not exist "%FILEPATH%" goto :FileNotExistError
goto :End

:Loading
%JARPATH% %FILEPATH%
goto :End

:FileNotExistError
echo File "%FILEPATH%" not exist !
pause
goto :End

:End
pause