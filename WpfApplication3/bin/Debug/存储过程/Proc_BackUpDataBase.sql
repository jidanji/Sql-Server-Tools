

-- =============================================
-- Author:		Αυ
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Proc_BackUpDataBase]
    @FilePath VARCHAR(100) ,
    @DbName VARCHAR(50)
AS 
    DECLARE @BackupSql NVARCHAR(200)
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON ;
        SET @FilePath = ' ''' + @FilePath + @DbName
            + REPLACE(CONVERT(VARCHAR(20), GETDATE(), 20), ':', '') + '.bak'''
        SET @BackupSql = ' Backup Database ' + @DbName + ' To disk='
            + @FilePath
        EXECUTE sp_executesql @BackupSql
    END

