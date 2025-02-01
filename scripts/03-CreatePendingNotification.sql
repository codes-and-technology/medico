SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW PendingNotification
AS

SELECT	n.Id,
		n.Success,
		n.ErrorMessage,
		n.SendDate,
		n.CreateDate,
		n.Message,
		ud.Email as DoctorEmail,
		ud.Name as DoctorName,
		up.Name as PatientName,
		d.AvailableDate as AppointmentDate,
		t.Time  as AppointmentTime
FROM	[DBO].Notification n,
		[DBO].Appointments a,
		[DBO].DoctorsTimetablesDate d,
		[DBO].DoctorsTimetablesTimes t,
		[DBO].Users ud,
		[dbo].Users up
WHERE	1=1
		AND	a.Id = n.IdAppointments
		AND d.Id = a.IdDoctorsTimetablesDate
		AND t.Id = a.IdDoctorsTimetablesTime
		AND ud.Id = a.IdDoctor
		AND up.Id = a.IdPatient
		AND	n.SendDate IS NULL	

GO

/*
SELECT * FROM PendingNotification

UPDATE PendingNotification SET
	Success = 1,
	SendDate = CURRENT_TIMESTAMP
	WHERE ID = 'NOT.TS[2025-02-01T20:39:04.710]'

UPDATE Notification SET
	Success = NULL,
	SendDate = NULL
	WHERE ID = 'NOT.TS[2025-02-01T20:39:04.710]'

*/