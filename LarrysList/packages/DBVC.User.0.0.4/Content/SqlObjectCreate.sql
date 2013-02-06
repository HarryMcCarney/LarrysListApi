

/****** Object:  Table [dbo].[user]    Script Date: 2/6/2013 3:02:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[token] [char](36) NOT NULL,
	[name] [nvarchar](255) NULL,
	[email] [varchar](255) NOT NULL,
	[pwd] [varchar](255) NOT NULL,
	[pwd_forget_token] [varchar](255) NULL,
	[pwd_forget_token_created] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  StoredProcedure [api].[user_email_available]    Script Date: 2/6/2013 3:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [api].[user_email_available]
@p xml,
@r xml output
as
begin try

declare @dbMessage varchar(255),
		@email varchar(255)
		
		
select @email = @p.value('(User/@email)[1]','nvarchar(255)')	

-------------------------------------------------------------------------------------------------------
-------------------------input validation--------------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	if    @email is null
		begin 
		raiserror	(N'insufficient input params',
					16, -- severity.
					1); -- state
		end
-------------------------------------------------------------------------------------------------------
-------------------------end input validation----------------------------------------------------------
-------------------------------------------------------------------------------------------------------

	if exists (select 1 from [user] where email = @email)
		set @dbMessage = 'EMAIL_TAKEN'
	
	select @r = (
		select 0 as "@status", 
		object_name(@@procid) as "@procName",
		@dbMessage as "@dbMessage"
		for xml path('Result')
		)

end try
begin catch
	exec dbo.set_error @p, @r output
end catch




GO
/****** Object:  StoredProcedure [api].[user_email_signup]    Script Date: 2/6/2013 3:02:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [api].[user_email_signup]
@p xml,
@r xml output
as
begin try

	declare @name nvarchar(255),
			@email varchar(255),
			@pwd varchar(25),
			@new_user_id int,
			@dbMessage varchar(255)


select	@email = @p.value('(User/@email)[1]','nvarchar(255)'),
		@pwd = @p.value('(User/@pwd)[1]','nvarchar(255)'),
		@name = @p.value('(User/@name)[1]','nvarchar(255)')
-------------------------------------------------------------------------------------------------------
-------------------------input validation--------------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	
	if  @email is null  or @pwd is null or @name is null
		begin 
		raiserror	(N'insufficient input params',
					16, -- severity.
					1) -- state
		end
-------------------------------------------------------------------------------------------------------
-------------------------end input validation----------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	
	if exists(select 1 from [user] where email  = @email)
		set @dbMessage = 'EMAIL_TAKEN'
	else
	insert [user]
	(token, email, pwd, name )
	select newid(), @email, [dbo].[fn_get_md5_hash](@pwd), @name
	set @new_user_id = scope_identity()

	select @r = (
	select 0 as "@status", 
	object_name(@@procid) as "@procName",
	@dbMessage as "@dbMessage",
	dbo.fn_get_user(@new_user_id, null) as "*"
	for xml path('Result')
	)

end try
begin catch
	exec set_error @p,  @r output
end catch

GO
/****** Object:  StoredProcedure [api].[user_login]    Script Date: 2/6/2013 3:02:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [api].[user_login]
@p xml,
@r xml output
as
begin try

declare @name nvarchar(255),
		@user xml,
		@dbMessage varchar(255),
		@email varchar(255),
		@pwd varchar(255),
		@user_id int
		
select @pwd = [dbo].[fn_get_md5_hash](@p.value('(User/@pwd)[1]','nvarchar(255)')),
		@email = @p.value('(User/@email)[1]','nvarchar(255)')	

-------------------------------------------------------------------------------------------------------
-------------------------input validation--------------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	if   @pwd is null or @email is null
		begin 
		raiserror	(N'insufficient input params',
					16, -- severity.
					1) -- state
		end
-------------------------------------------------------------------------------------------------------
-------------------------end input validation----------------------------------------------------------
-------------------------------------------------------------------------------------------------------

select @user_id = id from [user] where pwd = @pwd  and @email = email
if @user_id is null
	set @dbMessage = 'LOGIN_FAILED'

	select @r = (
		select 0 as "@status", 
		object_name(@@procid) as "@procName",
		@dbMessage as "@dbMessage",
		dbo.fn_get_user(@user_id, null) as "*"
		for xml path('Result')
		)

end try
begin catch
	exec dbo.set_error @p, @r output
end catch


GO
/****** Object:  StoredProcedure [api].[user_login_link]    Script Date: 2/6/2013 3:02:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [api].[user_login_link]
@p xml,
@r xml output
as
begin try
declare @token varchar(255),
		@no int,
		@user_id int,
		@name varchar(255),
		@authToken varchar(255)
		
select @token = @p.value('(LoginLink/@token)[1]','varchar(255)')
-------------------------------------------------------------------------------------------------------
-------------------------INPUT VALIDATION--------------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	if	@token is null
		begin 
		raiserror	('no token passed in',
					16, -- severity.
					1) -- state
		end

-------------------------------------------------------------------------------------------------------
-------------------------END INPUT VALIDATION----------------------------------------------------------
-------------------------------------------------------------------------------------------------------
		update u
		set  @user_id = id
		from [user] u
		where pwd_forget_token = @token
		set @no = @@rowcount
		
		select @r = (
			select 0 as "@status", 
			object_name(@@procid) as "@procName",
			case when isnull(@no,0) = 0 then 'NO_USER_FOUND' else null end as "@dbMessage",
			dbo.fn_get_user(@user_id, null) as "*"
			for xml path ('Result')
		)		
end try
begin catch
	exec set_error @p, @r output
end catch




GO
/****** Object:  StoredProcedure [api].[user_pwd_forgot]    Script Date: 2/6/2013 3:02:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [api].[user_pwd_forgot]
@p xml,
@r xml output
as
begin try
declare @email varchar(255),
		@activationToken varchar(1024),
		@dbMessage varchar(255),
		@name varchar(255),
		@user_id int
		
		
select 
		@email = @p.value('(User/@email)[1]','varchar(255)'),
		@activationToken = @p.value('(User/@activationToken)[1]','varchar(255)')
		
-------------------------------------------------------------------------------------------------------
-------------------------INPUT VALIDATION--------------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	if	@email is null or @activationToken is null
		begin 
		raiserror	('insufficient input params',
					16, -- severity.
					1) -- state
		end
		


-------------------------------------------------------------------------------------------------------
-------------------------END INPUT VALIDATION----------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	if not exists (
				select 1
				from dbo.[user]
				where email = @email
				)
	set @dbMessage = 	'NO_USER_WITH_THIS_EMAIL'
	if (select datediff(hh, isnull(pwd_forget_token_created,'1/jan/1980'), getutcdate())from [user] where email = @email) < 24 
	set @dbMessage = 'TOKEN_SET_IN_LAST_24_HOURS'
	if @dbMessage is null
	begin
	
	update [user]
	set pwd_forget_token_created = getutcdate(),
		pwd_forget_token = @activationToken,
		@user_id = id,
		@name = name 
	where email = @email
	end			
	select @r = (
		select 0 as "@status", 
		object_name(@@procid) as "@procName",
		@dbMessage as "@dbMessage",
		dbo.fn_get_user(@user_id,null) as "*"
		for xml path ('Result')
		)				
end try
begin catch
	exec set_error @p, @r output
end catch
	




GO
/****** Object:  StoredProcedure [api].[user_resend_pwd_forgot]    Script Date: 2/6/2013 3:02:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [api].[user_resend_pwd_forgot]
@p xml,
@r xml output
as
begin try
declare @email varchar(255),
		@activationToken varchar(1024),
		@dbMessage varchar(255),
		@firstName varchar(255),
		@user xml,
		@user_id int,
		@name varchar(255) 
		
select 
		@email = @p.value('(User/@email)[1]','varchar(255)')
	
		
-------------------------------------------------------------------------------------------------------
-------------------------INPUT VALIDATION--------------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	if	@email is null 
		begin 
		raiserror	('insufficient input params',
					16, -- severity.
					1) -- state
		end

-------------------------------------------------------------------------------------------------------
-------------------------END INPUT VALIDATION----------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	if not exists (
				select 1
				from dbo.[user]
				where email = @email
				)
	set @dbMessage = 	'NO_USER_WITH_THIS_EMAIL'
	select @activationToken = pwd_forget_token, @user_id = id  from [user] where email = @email and  pwd_forget_token is not null 
	if @activationToken is null
	set @dbMessage = 'NO_TOKEN_HAS_BEEN_SET'
	
	select @r = (
		select 0 as "@status", 
		object_name(@@procid) as "@procName",
		@dbMessage as "@dbMessage",
		dbo.fn_get_user(@user_id,null) as "*"
		for xml path ('Result')
		)				
end try
begin catch
	exec set_error @p, @r output
end catch
	





GO
/****** Object:  StoredProcedure [api].[user_update_pwd]    Script Date: 2/6/2013 3:02:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [api].[user_update_pwd]
@p xml,
@r xml output
as
begin try

	declare @pwd varchar (255),
			@db_message varchar(255),
			@token  char(36),
			@no int,
			@user_id int
	select 
		@token =  @p.value('(User/@token)[1]','char(36)'),
		@pwd = [dbo].[fn_get_md5_hash](@p.value('(User/@pwd)[1]','varchar(255)'))
		
	
-------------------------------------------------------------------------------------------------------
-------------------------INPUT VALIDATION--------------------------------------------------------------
-------------------------------------------------------------------------------------------------------
	If @token is null or @pwd is null
		BEGIN 
		RAISERROR	(N'insufficent input params',
					16, -- Severity.
					1) -- state
		END
-------------------------------------------------------------------------------------------------------
-------------------------END INPUT VALIDATION--------------------------------------------------------------
-------------------------------------------------------------------------------------------------------	
	
		update [user]
		set pwd = @pwd,
		@user_id = id
		where @token = token
		set @no = @@rowcount

		select @r = (
					select 0 as "@status", 
					object_name(@@procid) as "@procName", 
					case when isnull(@no,0) = 0 then 'NO_USER_FOUND' else null end as "@dbMessage",
					dbo.fn_get_user(@user_id,null) as "*"
					for xml path ('Result')
				)
				
	end try
	
	begin catch 
		exec dbo.set_error @p, @r output
	end catch 
	




GO



