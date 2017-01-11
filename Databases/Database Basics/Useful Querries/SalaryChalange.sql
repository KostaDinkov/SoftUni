select top 10 FirstName, LastName, DepartmentID from
(select FirstName, LastName, DepartmentID, Salary,
avg(Salary) over (partition by DepartmentID )as R from Employees) as sub
where Salary > r
order by DepartmentID


