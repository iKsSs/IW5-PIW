Use master 
GO
IF EXISTS(SELECT request_session_id FROM sys.dm_tran_locks WHERE resource_database_id = DB_ID('master'))
PRINT 'Model Database being used by some other session'
ELSE
PRINT 'Model Database not used by other session'
