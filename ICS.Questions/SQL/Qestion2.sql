DECLARE @startDate DATETIME='12/01/2020'
DECLARE @endDate DATETIME= EOMONTH(@startDate) -- mm/dd/yyyy

;WITH Calender AS 
(
    SELECT @startDate AS CalanderDate 
    UNION ALL
    SELECT CalanderDate + 1 FROM Calender
    WHERE CalanderDate + 1 <= @endDate
)
SELECT ROW_NUMBER() OVER(ORDER BY CalanderDate) As #,DATENAME(dw, CalanderDate) as Day, [Date] = CONVERT(VARCHAR(10),CalanderDate,25) 
FROM Calender WHERE DATENAME(dw, CalanderDate) NOT IN ('Saturday','Sunday')
OPTION (MAXRECURSION 0)