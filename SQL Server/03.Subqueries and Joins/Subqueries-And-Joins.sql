/*------------------------------------
Part I – Queries for SoftUni Database
*/------------------------------------
USE SoftUni;
-- 1.	Employee Address

SELECT TOP(5) EmployeeID, JobTitle, a.AddressID, a.AddressText
FROM Employees e 
JOIN Addresses a ON e.AddressID = a.AddressID 
ORDER BY AddressID

-- 2.	Addresses with Towns
SELECT TOP(50) FirstName, LastName, t.Name, a.AddressText
FROM Employees e
JOIN Addresses a ON a.AddressID = e.AddressID 
JOIN Towns t ON a.TownID = t.TownID
ORDER BY FirstName, LastName

-- 3.	Sales Employee
SELECT e.EmployeeID, FirstName, LastName, d.Name
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

-- 4.	Employee Departments
SELECT TOP(5) e.EmployeeID, FirstName, Salary, d.Name
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- 5.	Employees Without Project
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees e
LEFT OUTER JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

-- 6.	Employees Hired After
SELECT FirstName, LastName, HireDate, d.Name 
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01' AND d.Name IN ('Sales', 'Finance')
ORDER BY HireDate

-- 7.	Employees with Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName 
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY EmployeeID

-- 8.	Employee 24
SELECT e.EmployeeID, e.FirstName,
		CASE 
			WHEN p.StartDate >= '2005-01-01' THEN NULL
			ELSE p.Name
		END AS [ProjectName]
FROM Employees e
JOIN EmployeesProjects ep 
	ON e.EmployeeID = ep.EmployeeID
JOIN Projects p 
	ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

-- 9.	Employee Manager
SELECT e.EmployeeID, e.FirstName, m.EmployeeID, m.FirstName 
FROM Employees e
JOIN Employees m
	ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

-- 10.	Employees Summary
SELECT TOP(50) 
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.Name AS DepartmentName
FROM Employees e
JOIN Employees m
	ON e.ManagerID = m.EmployeeID
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- 11.	Min Average Salary
SELECT TOP(1) AVG(Salary) AS MinAverageSalary FROM Employees
GROUP BY DepartmentID
ORDER BY AVG(Salary)

/*--------------------------------------
Part II – Queries for Geography Database
*/--------------------------------------
USE Geography;
-- 12.	Highest Peaks in Bulgaria

SELECT c.CountryCode, MountainRange, PeakName, Elevation
FROM Peaks p
JOIN Mountains m 
	ON p.MountainId = m.Id
JOIN MountainsCountries mc
	ON p.MountainId = mc.MountainId
JOIN Countries c
	ON mc.CountryCode = c.CountryCode
WHERE c.CountryCode = 'BG' AND Elevation >= 2835
ORDER BY Elevation DESC 

-- 13.	Count Mountain Ranges
SELECT CountryCode, COUNT(*) AS MountainRanges FROM MountainsCountries
WHERE CountryCode IN ('BG', 'RU', 'US')
GROUP BY CountryCode

-- 14.	Countries With or Without Rivers
SELECT TOP(5) 
	c.CountryName, 
	r.RiverName
FROM Countries c
LEFT JOIN CountriesRivers cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r
	ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY CountryName

-- 16.	Countries Without Any Mountains

SELECT COUNT(*) 
FROM Countries c
LEFT JOIN MountainsCountries mc
	ON c.CountryCode = mc.CountryCode
WHERE MountainId IS NULL 

-- 17.	Highest Peak and Longest River by Country

SELECT TOP(5) c.CountryName , 
	MAX(p.Elevation) AS [HighestPeakElevation], 
	MAX(r.Length) AS [LongestRiverLength]
FROM Countries c
FULL OUTER JOIN MountainsCountries mc 
	ON c.CountryCode = mc.CountryCode 
FULL OUTER JOIN Peaks p 
	ON mc.MountainId = p.MountainId
FULL OUTER JOIN CountriesRivers cr 
	ON c.CountryCode = cr.CountryCode 
FULL OUTER JOIN Rivers r 
	ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC

-- 18.	Highest Peak Name and Elevation by Country

SELECT TOP(5)
	c.CountryName AS Country,
	ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(p.Elevation, '0') AS [Highest Peak Elevation],
	ISNULL(m.MountainRange, '(no mountain)') AS [Mountain]
FROM Countries c
LEFT JOIN MountainsCountries mc 
	ON c.CountryCode = mc.CountryCode 
LEFT JOIN Mountains m
	ON mc.MountainId = m.Id 
LEFT JOIN Peaks p 
	ON mc.MountainId = p.MountainId
ORDER BY Country, p.PeakName

-- DENSE_RANK() Solution
SELECT TOP(5)
	td.CountryName AS Country,
	ISNULL(td.PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(td.Elevation, '0') AS [Highest Peak Elevation],
	ISNULL(td.MountainRange, '(no mountain)') AS [Mountain]
FROM (
	SELECT c.CountryName, 
		p.PeakName, 
		p.Elevation, 
		m.MountainRange ,
		DENSE_RANK() 
			OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank
	FROM Countries c
	LEFT JOIN MountainsCountries mc 
		ON c.CountryCode = mc.CountryCode 
	LEFT JOIN Mountains m
		ON mc.MountainId = m.Id 
	LEFT JOIN Peaks p 
		ON mc.MountainId = p.MountainId
) AS td
WHERE td.PeakRank = 1
ORDER BY td.CountryName, td.PeakName
