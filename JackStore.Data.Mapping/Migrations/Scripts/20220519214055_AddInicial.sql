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

CREATE TABLE [categoria_produto] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(100) NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_categoria_produto] PRIMARY KEY ([id])
);
GO

CREATE TABLE [loja] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(100) NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_loja] PRIMARY KEY ([id])
);
GO

CREATE TABLE [produto] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(100) NOT NULL,
    [preco] decimal(18,2) NOT NULL,
    [id_categoria] int NOT NULL,
    [id_loja] int NOT NULL,
    [created_at] datetime2 NOT NULL,
    CONSTRAINT [pk_produto] PRIMARY KEY ([id]),
    CONSTRAINT [fk_produto_id_categoria] FOREIGN KEY ([id_categoria]) REFERENCES [categoria_produto] ([id]) ON DELETE CASCADE,
    CONSTRAINT [fk_produto_id_loja] FOREIGN KEY ([id_loja]) REFERENCES [loja] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [idx_produto_id_categoria] ON [produto] ([id_categoria]);
GO

CREATE INDEX [idx_produto_id_loja] ON [produto] ([id_loja]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220519214055_AddInicial', N'5.0.5');
GO

COMMIT;
GO

