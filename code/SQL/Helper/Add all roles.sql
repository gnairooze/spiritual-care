
declare @mail nvarchar(512), @UserId nvarchar(256)
set @mail = 'admin@gnairooze.info'

select
	@UserId = Id
from AspNetUsers
where Email = @mail

insert AspNetUserRoles
(
	RoleId,
	UserId
)
select
	AspNetRoles.Id,
	@UserId
from AspNetRoles
left join AspNetUserRoles
	on AspNetRoles.Id = AspNetUserRoles.RoleId
	and AspNetUserRoles.UserId = @UserId
where AspNetUserRoles.UserId is null
