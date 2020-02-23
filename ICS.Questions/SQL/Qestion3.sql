DECLARE @CODE VARCHAR(3)='PNT'
;With oc AS (
	SELECT ParentKeyCode,KeyCode ,OfficeName,0 As Level From Offices  WHERE KeyCode=@CODE
	UNION ALL
	SELECT o.ParentKeyCode,o.KeyCode ,o.OfficeName,Level+1 As Level From Offices o
	INNER JOIN oc ON Oc.ParentKeyCode=o.KeyCode

)

SELECT * FROM (
	
	SELECT oc.KeyCode,oc.OfficeName,oc.Level,ocf.FacilityCode,ocf.ServiceLevel FROM oc
	INNER JOIN OfficeFacilities ocf ON ocf.OfficeKeyCode=oc.KeyCode
) AS s
PIVOT(
	Min(s.ServiceLevel) FOR s.FacilityCode IN ([Parking],[MeetingRooms],[TeleCon])
) As pivot_table
Order by Level
