USE [DbDesafioThomasGreg]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Logotipo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logradouros]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logradouros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Endereco] [nvarchar](max) NULL,
	[Cidade] [nvarchar](max) NULL,
	[Estado] [nvarchar](max) NULL,
	[Cep] [nvarchar](max) NULL,
	[ClienteId] [int] NULL,
 CONSTRAINT [PK_Logradouros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Logradouros]  WITH CHECK ADD  CONSTRAINT [FK_Logradouros_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Logradouros] CHECK CONSTRAINT [FK_Logradouros_Clientes_ClienteId]
GO
/****** Object:  StoredProcedure [dbo].[AddNewCliente]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewCliente]
	-- Add the parameters for the stored procedure here
	@nome [nvarchar](max),
	@Email [nvarchar](max),
	@Logotipo [nvarchar](max)
AS
BEGIN
    -- Verificar se o e-mail já existe
    IF EXISTS (SELECT 1 FROM Clientes WHERE Email = @Email)
    BEGIN
        PRINT 'Erro: Este endereço de e-mail já está cadastrado.'
        RETURN;
    END

    -- Inserir novo cliente
    INSERT INTO Clientes (Nome, Email, Logotipo)
    VALUES (@Nome, @Email, @Logotipo)

    PRINT 'Cliente cadastrado com sucesso.'
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewLogradouro]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddNewLogradouro]
	
	@Endereco [nvarchar](max),
	@Cidade [nvarchar](max),
	@Estado [nvarchar](max),
	@Cep [nvarchar](max)

AS
BEGIN
	INSERT INTO dbo.Logradouros
		(
			Endereco,
			Cidade,
			Estado,
			Cep
		)
    VALUES
		(
			@Endereco,
			@Cidade,
			@Estado,
			@Cep
		)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteClienteById]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marcio de Andrade
-- Create date: 28/11/2023
-- Description:	Delete Cliente
-- =============================================
CREATE PROCEDURE [dbo].[DeleteClienteById]
	@Id int
AS
BEGIN
	DELETE FROM dbo.Clientes where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteLogradouroById]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marcio de Andrade
-- Create date: 28/11/2023
-- Description:	Delete Logradouro por Id
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLogradouroById]
	@Id int
AS
BEGIN
	DELETE FROM dbo.Logradouros where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetClienteById]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marcio de Andrade
-- Create date: 28/11/2023
-- Description:	Seleciona Cliente pelo Id
-- =============================================
CREATE PROCEDURE [dbo].[GetClienteById]
	@id int
	AS
	BEGIN
		SELECT
			Id,
			Nome,
			Email,
			Logotipo
	FROM dbo.Clientes where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetClienteList]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marcio de Andrade
-- Create date: 28/11/2023
-- Description:	Seleciona todos clientes
-- =============================================
CREATE PROCEDURE [dbo].[GetClienteList]
	
AS
BEGIN
	Select * from dbo.Clientes
END
GO
/****** Object:  StoredProcedure [dbo].[GetLogradouroById]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marcio de Andrade
-- Create date: 28/11/2023
-- Description:	Seleciona Logradouro pelo Id
-- =============================================
CREATE PROCEDURE [dbo].[GetLogradouroById]
	@id int
	AS
	BEGIN
		SELECT
			Id,
			Endereco,
			Cidade,
			Estado,
			Cep
	FROM dbo.Logradouros where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetLogradouroList]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marcio de Andrade
-- Create date: 28/11/2023
-- Description:	Seleciona Logradouros
-- =============================================
CREATE PROCEDURE [dbo].[GetLogradouroList]
	
AS
BEGIN
	
	SELECT * from dbo.Logradouros
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCliente]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marcio de Andrade
-- Create date: 28/11/2023
-- Description:	Atualiza Cliente
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCliente] 
	
	@Id int,
	@Nome [nvarchar](max),
	@Email [nvarchar](max),
	@Logotipo [nvarchar](max)

AS
BEGIN
	UPDATE dbo.Clientes
    SET
		Nome =  @Nome,
		Email = @Email,
		Logotipo = @Logotipo
		
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLogradouro]    Script Date: 12/12/2023 15:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Marcio de Andrade
-- Create date: 28/11/2023
-- Description:	Atualiza Logradouro
-- =============================================
CREATE PROCEDURE [dbo].[UpdateLogradouro]
	
	@Id int,
	@Endereco [nvarchar](max),
	@Cidade [nvarchar](max),
	@Estado [nvarchar](max),
	@Cep[nvarchar](max)

AS
BEGIN
	UPDATE dbo.Logradouros
    SET
		Endereco =  @Endereco,
		Cidade	 = @Cidade,
		Estado   = @Estado,
		Cep      = @Cep
		
	WHERE Id = @Id
END
GO
