@ECHO off

:: batch file for
:: Murach's C# 2015
:: company: Mike Murach & Associates, Inc.
:: date:    January 6, 2016
:: 
:: Uses SQLCMD utility to run a SQL script that creates
:: the MMABooks database.

ECHO Attempting to create the MMABooks database . . . 
sqlcmd -S localhost\SqlExpress -E /i create_database.sql
ECHO.
ECHO If no error message is shown, then the database was created successfully.
ECHO.
PAUSE