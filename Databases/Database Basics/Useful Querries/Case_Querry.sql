select SubQuerry.DepositGroup from
(select DepositGroup, avg(MagicWandSize)as AvgSize from WizzardDeposits group by DepositGroup) as SubQuerry
where SubQuerry.AvgSize = 
(select min(AvgSize) 
	from (select DepositGroup, avg(MagicWandSize)as AvgSize 
		from WizzardDeposits group by DepositGroup)as av) 








