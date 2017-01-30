--Set NOCOUNT ON will stop rows affected being outputted to the messages pane
SET NOCOUNT ON
DECLARE @HealthCheckScore INT = 0;
DECLARE @LineBreak Char(100)  = REPLICATE('-',100);

RAISERROR('',10,1);
RAISERROR('SQL Server Health Check Beginning...',10,1) WITH NOWAIT;
RAISERROR('',10,1);
RAISERROR(@LineBreak,10,1);
RAISERROR('',10,1);


------------------------------------------------------------------------------------------

--Create/Truncate table #SQLServices_TempTbl to store SQL Service Info
IF OBJECT_ID('TempDB..#SQLServices_TempTbl') IS NOT NULL
BEGIN
	TRUNCATE TABLE #SQLServices_TempTbl;
END
ELSE
BEGIN
	CREATE TABLE #SQLServices_TempTbl (ServiceID INT IDENTITY(1,1), ServiceStatus VarChar(8));
END

------------------------------------------------------------------------------------------

--Insert Service Information in to ServiceInfo Temp Table
INSERT INTO #SQLServices_TempTbl
EXEC Master.dbo.xp_ServiceControl 'QUERYSTATE','MSSQLServer';

INSERT INTO #SQLServices_TempTbl
EXEC Master.dbo.xp_ServiceControl 'QUERYSTATE','SQLServerAgent';

------------------------------------------------------------------------------------------

--Print the service's status
DECLARE @SQLServerService  VarChar(100) = (SELECT ServiceStatus FROM #SQLServices_TempTbl WHERE ServiceID = 1);
DECLARE @SQLAgentService   VarChar(100) = (SELECT ServiceStatus FROM #SQLServices_TempTbl WHERE ServiceID = 2);

RAISERROR('SQL Server Service is %s'      ,10,1,@SQLServerService);
RAISERROR('SQL Server Agent Service is %s'  ,10,1,@SQLAgentService);

SELECT @HealthCheckScore = @HealthCheckScore + CASE WHEN @SQLServerService  LIKE '%Running.' THEN 10 ELSE 0 END;
SELECT @HealthCheckScore = @HealthCheckScore + CASE WHEN @SQLAgentService   LIKE '%Running.' THEN 10 ELSE 0 END;

DROP TABLE #SQLServices_TempTbl;

RAISERROR('',10,1);
RAISERROR(@LineBreak,10,1);
RAISERROR('',10,1);



------------------------------------------------------------------------------------------

--Print the Max Memory
DECLARE @PhysMem VarChar(100) =
(
	SELECT CASE 
		      WHEN CAST((CAST(Value_In_Use AS DECIMAL(12,2))/CAST((SELECT Physical_Memory_KB/1024 FROM SYS.DM_OS_SYS_INFO) AS DECIMAL(12,2)))*100 AS DECIMAL(12,2)) >= 100			  
				THEN 'SQL Server Max Memory is 100%% of System Memory. ('	    + (CAST(CAST(value_in_use AS INT)/1000 AS VarChar(7))) + ' GB out of ' + CAST((SELECT Physical_Memory_KB/1024/1000 FROM SYS.DM_OS_SYS_INFO) AS VarChar(3)) + ' GB)'

			  WHEN CAST((CAST(Value_In_Use AS DECIMAL(12,2))/CAST((SELECT Physical_Memory_KB/1024 FROM SYS.DM_OS_SYS_INFO) AS DECIMAL(12,2)))*100 AS DECIMAL(12,2)) BETWEEN 75 AND 99 
				THEN 'SQL Server Max Memory is over 75%% of System Memory. (' + (CAST(CAST(value_in_use AS INT)/1000 AS VarChar(7))) + ' GB out of ' + CAST((SELECT Physical_Memory_KB/1024/1000 FROM SYS.DM_OS_SYS_INFO) AS VarChar(3)) + ' GB)'

			  WHEN CAST((CAST(Value_In_Use AS DECIMAL(12,2))/CAST((SELECT Physical_Memory_KB/1024 FROM SYS.DM_OS_SYS_INFO) AS DECIMAL(12,2)))*100 AS DECIMAL(12,2)) < 75			  
				THEN 'SQL Server Max Memory is below 75%% of System Memory. ('+ (CAST(CAST(value_in_use AS INT)/1000 AS VarChar(7))) + ' GB out of ' + CAST((SELECT Physical_Memory_KB/1024/1000 FROM SYS.DM_OS_SYS_INFO) AS VarChar(3)) + ' GB)'
		   END
	FROM SYS.Configurations 
	WHERE Name = 'Max Server Memory (MB)'
);

SELECT @HealthCheckScore = @HealthCheckScore + CASE WHEN @PhysMem LIKE '%below%' THEN 10 ELSE 0 END;
RAISERROR(@PhysMem,10,1);
RAISERROR('',10,1);
RAISERROR(@LineBreak,10,1);
RAISERROR('',10,1);

------------------------------------------------------------------------------------------

--Get the current failed Agent Job count
DECLARE @FailedJobCount VarChar(100);

SELECT @FailedJobCount = 
	CASE 
		WHEN COUNT(*) > 0 THEN 'There has been ' + CAST(COUNT(*) AS VarChar(5)) + ' SQL Agent Job failures over the past 14 days'
		ELSE 'There has been ' + CAST(COUNT(*) AS VarChar(5)) + ' SQL Agent Job failures over the past 14 days'
	END
FROM 
	MSDB..SysJobHistory JH INNER JOIN 
	MSDB..SysJobSteps JS ON JH.Job_ID=JS.Job_ID INNER JOIN
	MSDB..SysJobs J ON JH.Job_ID=J.Job_ID
WHERE 
	CAST(MSDB.dbo.Agent_Datetime(JH.Run_Date, JH.Run_Time) AS Date) BETWEEN CAST((GetDate() - 14) AS Date) AND CAST(GetDate() AS Date) AND
	JH.Run_Status = 0 AND
	JH.[Message] LIKE 'The Job Failed%'
	

--Update the HealthCheckScore variable
SELECT @HealthCheckScore = @HealthCheckScore + CASE WHEN @FailedJobCount LIKE 'There has been 0 SQL%' THEN 10 ELSE 0 END;

PRINT @FailedJobCount;
RAISERROR('',10,1);
RAISERROR(@LineBreak,10,1);
RAISERROR('',10,1);
RAISERROR('Health Check Score - %d/100',10,1,@HealthCheckScore)

------------------------------------------------------------------------------------------