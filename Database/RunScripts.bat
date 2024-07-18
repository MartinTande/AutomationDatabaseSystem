@echo off
@echo Executing Multiple SQL scripts from folder in one go

setlocal enabledelayedexpansion

for /r %%G in (*.sql) do (
    sqlcmd -s LAPTOP-FV372A99 -d AUTOMATIONSYSTEM -E -i "%%G"
)

echo DATABASE CREATE IS COMPLETE
pause