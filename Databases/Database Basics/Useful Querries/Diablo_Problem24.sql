BEGIN TRAN

declare @gameStats table ( id int, Strength int, Defence int, Speed int, Luck int, Mind int)
insert into @gameStats
	select GameTypes.id ,Strength,Defence,Speed,Luck,Mind 
	from GameTypes,[Statistics] where GameTypes.BonusStatsId =[Statistics].Id;

declare @charStats table ( id int, Strength int, Defence int, Speed int, Luck int, Mind int)
insert into @charStats
	select Characters.id ,Strength,Defence,Speed,Luck,Mind 
	from Characters,[Statistics] where Characters.StatisticId =[Statistics].Id;

with Results (Username, GameName, CharacterName, GtID,CharId, Strength,Defence,Speed,Mind,Luck )
as
( 
	select  
		u.Username, 
		g.Name as GameName, 
		c.Name as CharacterName ,
		gt.Id as GameTypeID,
		c.id as CharID,
		sum(s.Strength) as Strength,
		SUM(s.Defence) as Defence,
		SUM(s.Speed) as Speed,
		SUM(s.Mind) as Mind,
		SUM(s.Luck) as Luck
		from Users u
		join UsersGames ug on ug.UserId = u.Id 	 
		join Games g on g.Id = ug.GameId
		join Characters c on c.Id = ug.CharacterId 
		join UserGameItems ugi on ugi.UserGameId = ug.Id
		join Items i on i.Id = ugi.ItemId 
		join GameTypes gt on gt.Id = g.GameTypeId 
		join [Statistics] s on s.Id = i.StatisticId 
		--where u.Username = 'skippingside'
		group by Username, g.Name, c.Name , c.Id, gt.id
)		
select Username, GameName as Game, CharacterName as [Character], 
	(results.Strength + 
	(select gs.Strength from @gameStats gs where gs.id = GtID) + 
	(select cs.Strength from @charStats cs where cs.id = CharId)) as Strength,
	
	(results.Defence + 
	(select gs.Defence from @gameStats gs where gs.id = GtID) + 
	(select cs.Defence from @charStats cs where cs.id = CharId)) as Defence,
	
	(results.Speed + 
	(select gs.Speed from @gameStats gs where gs.id = GtID) + 
	(select cs.Speed from @charStats cs where cs.id = CharId)) as Speed,
	
	(results.Mind + 
	(select gs.Mind from @gameStats gs where gs.id = GtID) + 
	(select cs.Mind from @charStats cs where cs.id = CharId)) as Mind,
	
	(results.Luck + 
	(select gs.Luck from @gameStats gs where gs.id = GtID) + 
	(select cs.Luck from @charStats cs where cs.id = CharId)) as Luck
   from results
   order by Strength desc, Defence desc, Speed desc, Mind desc, Luck desc

ROLLBACK