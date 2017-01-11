select Sum([Difference]) from
(select
	FirstName as Host, 
	DepositAmount as 'Host Wizzard Deposit', 
	Lead(FirstName) over (order by id) as 'Guest Wizzard',
	Lead(DepositAmount) over ( order by id) as 'Guest Wizzard Deposit',
	DepositAmount - (Lead(DepositAmount) over (order by id)) as 'Difference'
		
 from WizzardDeposits) as sub

 --select Id, FirstName from WizzardDeposits

