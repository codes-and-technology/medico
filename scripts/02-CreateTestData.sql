SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE SP_CreateTestData
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	-- SET NOCOUNT ON;
	
	DECLARE  @idPatient varchar(50)
		    ,@idDoctor varchar(50)
			,@idDoctorAvailability varchar(50)
			,@intLoop int
			,@idDoctorTimeAvailability varchar(50)
			,@idAppointment varchar(50)
			,@idNotification varchar(50)
			;

	SET @idPatient = (SELECT max(id) FROM [Users] WHERE [CRM] IS NULL);
	IF (@idPatient IS NULL)
	BEGIN
		INSERT INTO [dbo].[Users]
			([Id]
			,[Name]
			,[CPF]
			,[Email]
			,[CreateDate])
		VALUES
			(NEWID()
			,'Kenneth Evans'
			,'22214425802'
			,'kevans.br@gmail.com'
			,CURRENT_TIMESTAMP);

		SET @idPatient = (SELECT max(id) FROM [Users] WHERE [CRM] IS NULL);
	END;

	SET @idDoctor = (SELECT max(id) FROM [Users] WHERE [CRM] IS NOT NULL);
	IF (@idDoctor IS NULL)
	BEGIN
		INSERT INTO [dbo].[Users]
			([Id]
			,[Name]
			,[CPF]
			,[Email]
			,[CRM]
			,[CreateDate])
		VALUES
			(NEWID()
			,'Emmett Brown'
			,'11122233344'
			,'kevans.br@gmail.com'
			,'SP123456'
			,CURRENT_TIMESTAMP);

		SET @idDoctor = (SELECT max(id) FROM [Users] WHERE [CRM] IS NOT NULL);
	END;

	SET @idDoctorAvailability = (SELECT max(id) FROM [DoctorsTimetablesDate] WHERE [IdDoctor] = @idDoctor AND [DeleteDate] IS NULL);
	IF (@idDoctorAvailability IS NULL)
	BEGIN

		INSERT INTO [dbo].[DoctorsTimetablesDate]
				   ([Id]
				   ,[IdDoctor]
				   ,[AvailableDate]
				   ,[CreateDate]
				   )
			 VALUES
				   (NEWID()
				   ,@idDoctor
				   ,getdate()+30
				   ,CURRENT_TIMESTAMP
				   );

		SET @idDoctorAvailability = (SELECT max(id) FROM [DoctorsTimetablesDate] WHERE [IdDoctor] = @idDoctor AND [DeleteDate] IS NULL);
	END;	

	SET @idDoctorTimeAvailability = (SELECT max(id) FROM [DoctorsTimetablesTimes] WHERE [IdDoctorsTimetablesDate] = @idDoctorAvailability AND [DeleteDate] IS NULL);
	IF (@idDoctorTimeAvailability IS NULL)
	BEGIN

		SET @intLoop = 0
		WHILE @intLoop < 10 
		BEGIN
			SET @intLoop = @intLoop+1

			INSERT INTO [dbo].[DoctorsTimetablesTimes]
					   ([Id]
					   ,[IdDoctorsTimetablesDate]
					   ,[Time]
					   ,[CreateDate]
					   )
				 VALUES
					   (NEWID()
					   ,@idDoctorAvailability
					   --,CONVERT(time, RIGHT('00' + (@intLoop+8), 2) + ':00')
					   ,RIGHT('00' + (@intLoop+8), 2) + ':00'
					   ,CURRENT_TIMESTAMP
					   );
		END

		SET @idDoctorTimeAvailability = (SELECT max(id) FROM [DoctorsTimetablesTimes] WHERE [IdDoctorsTimetablesDate] = @idDoctorAvailability AND [DeleteDate] IS NULL);

		INSERT INTO [dbo].[Appointments]
					([Id]
					,[IdPatient]
					,[IdDoctor]
					,[IdDoctorsTimetablesDate]
					,[IdDoctorsTimetablesTime]
					,[CreateDate])
				VALUES
					(NEWID()
					,@idPatient
					,@idDoctor
					,@idDoctorAvailability
					,@idDoctorTimeAvailability
					,CURRENT_TIMESTAMP
					);

		SET @idAppointment = (SELECT max(id) FROM [Appointments] WHERE [IdDoctorsTimetablesTime] = @idDoctorTimeAvailability);

		INSERT INTO [dbo].[Notification]
				   ([Id]
				   ,[IdAppointments]
				   ,[CreateDate]
				   ,[Message]
				   )
			 VALUES
				   (NEWID()
				   ,@idAppointment
				   ,CURRENT_TIMESTAMP
				   ,'Mensagem gerada pelo script de criação de dados de testes'
				   );

	END;	




	--SELECT @idPatient;

	/*
	IF(id_pro=id)THEN

	UPDATE products SET product=product, price=price, stock=stock, active=active 
	WHERE id_pro=id;

	ELSE

	INSERT INTO products (product, price, stock, active) VALUES 
	(product, price, stock, active);
	

    -- Insert statements for procedure here
	SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
	*/


END
GO

/*
DELETE FROM [DoctorsTimetablesTimes] WHERE [IdDoctorsTimetablesDate] = (SELECT [IdDoctorsTimetablesDate] FROM [DoctorsTimetablesDate] WHERE IdDoctor = 'DOC.0001')
EXEC SP_CreateTestData
SELECT * FROM [Users]
SELECT * FROM [DoctorsTimetablesDate]
SELECT * FROM [DoctorsTimetablesTimes]
SELECT * FROM [Appointments]
SELECT * FROM [Notification]
SELECT * FROM PendingNotification


DELETE FROM [Notification]
DELETE FROM [Appointments]
DELETE FROM [DoctorsTimetablesTimes]
DELETE FROM [DoctorsTimetablesDate]
DELETE FROM [Users]

*/