/opt/mssql-tools/bin/sqlcmd -S sqlserver -U SA -P partner2023! -Q "CREATE DATABASE partner;"
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U SA -P partner2023! -Q "CREATE LOGIN partner WITH PASSWORD = 'partner2023!';"
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U SA -P partner2023! -Q "USE partner; CREATE USER partner FOR LOGIN partner; EXEC sp_addrolemember 'db_owner', 'partner';"
