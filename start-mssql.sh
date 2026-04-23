#!/bin/bash

# Start SQL Server in the background first.
/opt/mssql/bin/sqlservr &
sql_server_pid=$!

echo 'Waiting for SQL Server to start...'
ready=0
for i in {1..50}; do
    /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_DEV_PASSWORD" -C -Q "SELECT 1" > /dev/null 2>&1
    if [ $? -eq 0 ]; then
        echo 'SQL Server is ready!'
        ready=1
        break
    fi
    echo "Attempt $i: not ready yet, waiting..."
    sleep 1
done

if [ "$ready" -ne 1 ]; then
    echo 'SQL Server did not become ready in time.'
    kill "$sql_server_pid"
    exit 1
fi

echo 'Running initialization script...'
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_DEV_PASSWORD" -C -v DevUserPassword="$MSSQL_DEV_PASSWORD" -i /var/opt/mssql/init-db.sql
echo 'Initialization complete!'

# Keep container running with SQL Server foreground lifecycle.
wait "$sql_server_pid"
