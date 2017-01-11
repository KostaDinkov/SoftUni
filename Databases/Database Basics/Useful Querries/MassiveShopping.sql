--constants
	declare @userName varchar(50);
	declare @gameName varchar(50);
	declare @minIlvl int;
	declare @maxIlvl int;
	declare @totalSum money;
	declare @userId int;
	declare @gameId int;
	declare @userGameId int;
	
	declare @itemsList table 
		( ItemID int, ItemName varchar(50), ItemPrice money, UserGameId int)
	
	set @userName = 'Stamat';
	set @gameName = 'Safflower';
	set @userId = 
		(select Id from Users where Username = @userName);
	set @gameId = 
		(select Id from Games where Name = @gameName);
	set @userGameId = 
		(select id from UsersGames where UserId = @userId and GameId = @gameId);

begin tran

begin try
	-- variables
	set @minIlvl = 11;
	set @maxIlvl = 12;
	
	insert into @itemsList (ItemID, ItemName, ItemPrice)
		select Id,Name,Price from Items
		where  MinLevel between @minIlvl and @maxIlvl;
	set @totalSum = 
		(select Sum(ItemPrice) from @itemsList )
	update @itemsList set UserGameId = @userGameId;
			
	
	----DEBUG
	--DECLARE @v XML = (SELECT * FROM @itemsList FOR XML AUTO)
	
	update UsersGames
	set Cash = Cash - @totalSum
	where GameId = @gameId
	and UserId = @userId;

	insert into UserGameItems
		select itemId, UserGameId from @itemsList

	--after the operation delete all from the temp itemlist table
	delete from @itemsList;
	commit

end try

begin catch
	rollback;
end catch

begin tran
begin try
	--constants
	
	set @minIlvl = 19;
	set @maxIlvl = 21;
		
	insert into @itemsList (ItemID, ItemName, ItemPrice)
		select Id,Name,Price from Items
		where  MinLevel between @minIlvl and @maxIlvl;
	set @totalSum = 
		(select Sum(ItemPrice) from @itemsList )
	update @itemsList set UserGameId = @userGameId;
			
	
	--DEBUG
	DECLARE @v XML = (SELECT * FROM @itemsList FOR XML AUTO)
	
	update UsersGames
	set Cash = Cash - @totalSum
	where GameId = @gameId
	and UserId = @userId;

	insert into UserGameItems
		select itemId, UserGameId from @itemsList
	commit

end try

begin catch
	rollback;
end catch

select i.Name from UserGameItems ugi
join UsersGames ug on ug.Id =ugi.UserGameId
join Users u on u.Id = ug.UserId 
join Games g on g.Id = ug.GameId
join Items i on i.Id= ItemId

where g.Name = 'Safflower'
order by ItemId