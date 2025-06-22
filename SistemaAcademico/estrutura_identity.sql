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
CREATE TABLE [Aluno] (
    [Id_Aluno] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Endereco] nvarchar(max) NOT NULL,
    [Data_Nasc] datetime2 NOT NULL,
    CONSTRAINT [PK_Aluno] PRIMARY KEY ([Id_Aluno])
);

CREATE TABLE [AspNetRoles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

CREATE TABLE [AspNetUsers] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

CREATE TABLE [Curso] (
    [Id_Curso] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Duracao] int NOT NULL,
    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id_Curso])
);

CREATE TABLE [Disciplina] (
    [Id_Disciplina] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Disciplina] PRIMARY KEY ([Id_Disciplina])
);

CREATE TABLE [Financeiro] (
    [Id_Financeiro] int NOT NULL IDENTITY,
    [Id_Matricula] int NOT NULL,
    [Valor] decimal(10,2) NOT NULL,
    [Data_Vencimento] datetime2 NOT NULL,
    [Data_Pagamento] datetime2 NULL,
    [Status] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Financeiro] PRIMARY KEY ([Id_Financeiro])
);

CREATE TABLE [Frequencia] (
    [Id_Frequencia] int NOT NULL IDENTITY,
    [Id_Matricula] int NOT NULL,
    [Data_Frequencia] datetime2 NOT NULL,
    [Presenca] bit NOT NULL,
    CONSTRAINT [PK_Frequencia] PRIMARY KEY ([Id_Frequencia])
);

CREATE TABLE [Professor] (
    [Id_Professor] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Departamento] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Professor] PRIMARY KEY ([Id_Professor])
);

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserRoles] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [AspNetUserTokens] (
    [UserId] int NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Matricula] (
    [Id_Matricula] int NOT NULL IDENTITY,
    [Id_Aluno] int NOT NULL,
    [Id_Curso] int NOT NULL,
    [Data_Matricula] datetime2 NOT NULL,
    [Status_Matricula] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Matricula] PRIMARY KEY ([Id_Matricula]),
    CONSTRAINT [FK_Matricula_Aluno_Id_Aluno] FOREIGN KEY ([Id_Aluno]) REFERENCES [Aluno] ([Id_Aluno]) ON DELETE CASCADE,
    CONSTRAINT [FK_Matricula_Curso_Id_Curso] FOREIGN KEY ([Id_Curso]) REFERENCES [Curso] ([Id_Curso]) ON DELETE CASCADE
);

CREATE TABLE [CursoDisciplina] (
    [Id] int NOT NULL IDENTITY,
    [Id_Curso] int NOT NULL,
    [Id_Disciplina] int NOT NULL,
    CONSTRAINT [PK_CursoDisciplina] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CursoDisciplina_Curso_Id_Curso] FOREIGN KEY ([Id_Curso]) REFERENCES [Curso] ([Id_Curso]) ON DELETE CASCADE,
    CONSTRAINT [FK_CursoDisciplina_Disciplina_Id_Disciplina] FOREIGN KEY ([Id_Disciplina]) REFERENCES [Disciplina] ([Id_Disciplina]) ON DELETE CASCADE
);

CREATE TABLE [Turma] (
    [Id_Turma] int NOT NULL IDENTITY,
    [Id_Disciplina] int NOT NULL,
    [Id_Professor] int NOT NULL,
    [Ano] int NOT NULL,
    [Semestre] nvarchar(max) NOT NULL,
    [Turno] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Turma] PRIMARY KEY ([Id_Turma]),
    CONSTRAINT [FK_Turma_Disciplina_Id_Disciplina] FOREIGN KEY ([Id_Disciplina]) REFERENCES [Disciplina] ([Id_Disciplina]) ON DELETE CASCADE,
    CONSTRAINT [FK_Turma_Professor_Id_Professor] FOREIGN KEY ([Id_Professor]) REFERENCES [Professor] ([Id_Professor]) ON DELETE CASCADE
);

CREATE TABLE [Nota] (
    [Id_Nota] int NOT NULL IDENTITY,
    [Id_Aluno] int NOT NULL,
    [Id_Turma] int NOT NULL,
    [Nota_Final] float NOT NULL,
    [Data_Avaliacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Nota] PRIMARY KEY ([Id_Nota]),
    CONSTRAINT [FK_Nota_Aluno_Id_Aluno] FOREIGN KEY ([Id_Aluno]) REFERENCES [Aluno] ([Id_Aluno]) ON DELETE CASCADE,
    CONSTRAINT [FK_Nota_Turma_Id_Turma] FOREIGN KEY ([Id_Turma]) REFERENCES [Turma] ([Id_Turma]) ON DELETE CASCADE
);

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

CREATE INDEX [IX_CursoDisciplina_Id_Curso] ON [CursoDisciplina] ([Id_Curso]);

CREATE INDEX [IX_CursoDisciplina_Id_Disciplina] ON [CursoDisciplina] ([Id_Disciplina]);

CREATE INDEX [IX_Matricula_Id_Aluno] ON [Matricula] ([Id_Aluno]);

CREATE INDEX [IX_Matricula_Id_Curso] ON [Matricula] ([Id_Curso]);

CREATE INDEX [IX_Nota_Id_Aluno] ON [Nota] ([Id_Aluno]);

CREATE INDEX [IX_Nota_Id_Turma] ON [Nota] ([Id_Turma]);

CREATE INDEX [IX_Turma_Id_Disciplina] ON [Turma] ([Id_Disciplina]);

CREATE INDEX [IX_Turma_Id_Professor] ON [Turma] ([Id_Professor]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250622010759_IdentityStructure', N'9.0.3');

COMMIT;
GO

