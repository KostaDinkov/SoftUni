select Distinct DepartmentID, Salary from
	(select 
	DepartmentID , Salary ,
	DENSE_RANK() over (Partition by DepartmentID order by Salary desc) as r
	from Employees)as sub
	where r = 3


	
	
	


--select DepartmentID, Salary from Employees
--order by DepartmentID, Salary desc;


--create function ThirdLargestSalaryByDep (@p_DepartmentId int)
--returns table
--as 
--return
--(

--)
	


