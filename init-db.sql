-- SQL Server initialization script for UPZMG development
-- This script runs automatically when the SQL Server container starts

-- Prerequisite for migrations to work—it sets up the container so migrations have somewhere to run.

-- Create the application database
CREATE DATABASE upzmg;
GO

-- Switch to the new database
USE upzmg;
GO

-- Create login for the application user (server-level)
CREATE LOGIN dev_user WITH PASSWORD = '$(DevUserPassword)';
GO

-- Create user in the database (linked to the login)
CREATE USER dev_user FOR LOGIN dev_user;
GO

-- Grant necessary permissions to the app user
-- db_datareader: SELECT on all tables
ALTER ROLE db_datareader ADD MEMBER dev_user;
GO

-- db_datawriter: INSERT, UPDATE, DELETE on all tables
ALTER ROLE db_datawriter ADD MEMBER dev_user;
GO

-- db_ddladmin: CREATE, ALTER, DROP for schema changes (for EF Core migrations in dev)
ALTER ROLE db_ddladmin ADD MEMBER dev_user;
GO

-- Verify the user was created successfully
PRINT 'Database upzmg created successfully';
PRINT 'User dev_user created with roles: db_datareader, db_datawriter, db_ddladmin';
GO



-- Types of ROLES 
/*
db_datareader   	Can read (SELECT) any table in the database
db_datawriter	    Can write (INSERT, UPDATE, DELETE) any table
db_ddladmin	        Can modify the structure (CREATE TABLE, ALTER TABLE, DROP TABLE)
db_owner	        Can do everything in the database
db_securityadmin	Can manage permissions and roles
db_backupoperator	Can backup the database
db_denydatareader	Explicitly BLOCKED from reading any table
db_denydatawriter	Explicitly BLOCKED from writing any table
*/