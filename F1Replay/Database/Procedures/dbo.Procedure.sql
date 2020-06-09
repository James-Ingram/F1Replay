CREATE PROCEDURE [dbo].[InsertTable]
    @myTableType MyTableType readonly
AS
BEGIN
    insert into [dbo].Records select * from @myTableType 
END