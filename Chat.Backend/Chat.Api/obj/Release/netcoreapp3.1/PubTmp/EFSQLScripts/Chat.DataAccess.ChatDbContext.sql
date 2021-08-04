IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210801074357_InitialMigration')
BEGIN
    CREATE TABLE [ChatGroups] (
        [Id] int NOT NULL IDENTITY,
        [Title] NVARCHAR(50) NULL,
        [Name] NVARCHAR(50) NULL,
        [DateCreated] DATETIME NOT NULL,
        CONSTRAINT [PK_ChatGroups] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210801074357_InitialMigration')
BEGIN
    CREATE TABLE [ChatMessages] (
        [Id] int NOT NULL IDENTITY,
        [User] NVARCHAR(50) NULL,
        [Message] NVARCHAR(200) NULL,
        [GroupId] NVARCHAR(50) NOT NULL,
        [DateCreated] DATETIME NOT NULL,
        CONSTRAINT [PK_ChatMessages] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210801074357_InitialMigration')
BEGIN
    CREATE TABLE [UserGroups] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [GroupId] int NOT NULL,
        [DateCreated] DATETIME NOT NULL,
        CONSTRAINT [PK_UserGroups] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210801074357_InitialMigration')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [UserName] NVARCHAR(50) NULL,
        [Password] NVARCHAR(50) NULL,
        [DateCreated] DATETIME NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210801074357_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210801074357_InitialMigration', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210801182713_UpdateChatGroup')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ChatGroups]') AND [c].[name] = N'Name');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ChatGroups] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ChatGroups] DROP COLUMN [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210801182713_UpdateChatGroup')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210801182713_UpdateChatGroup', N'5.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210802065731_ChangeUser')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Password] NVARCHAR(1000) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210802065731_ChangeUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210802065731_ChangeUser', N'5.0.8');
END;
GO

COMMIT;
GO

