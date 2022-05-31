BEGIN TRANSACTION;
GO

EXEC sp_rename N'[produto].[name]', N'nome', N'COLUMN';
GO

EXEC sp_rename N'[loja].[name]', N'nome', N'COLUMN';
GO

EXEC sp_rename N'[categoria_produto].[name]', N'nome', N'COLUMN';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[produto]') AND [c].[name] = N'preco');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [produto] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [produto] ALTER COLUMN [preco] decimal(7,2) NOT NULL;
GO

ALTER TABLE [produto] ADD [descricao] nvarchar(max) NULL;
GO

ALTER TABLE [produto] ADD [garantia] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [produto] ADD [imagens] nvarchar(max) NULL;
GO

ALTER TABLE [produto] ADD [quantidade_estoque] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [produto] ADD [tipo_garantia] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220524204344_ChangeProduto', N'5.0.5');
GO

COMMIT;
GO

