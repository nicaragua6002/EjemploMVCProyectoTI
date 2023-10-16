
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/12/2023 11:19:08
-- Generated from EDMX file: C:\Users\solis\source\repos\EjemploMVC\EjemploMVC\Models\ProyectoTIModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProyectosTIBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Comentarios'
CREATE TABLE [dbo].[Comentarios] (
    [Id] int  NOT NULL,
    [Texto] nvarchar(max)  NULL,
    [Fecha] datetime  NULL,
    [TareaId] int  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- Creating table 'Equipos'
CREATE TABLE [dbo].[Equipos] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(50)  NULL
);
GO

-- Creating table 'Miembros'
CREATE TABLE [dbo].[Miembros] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(50)  NULL,
    [Apellido] nvarchar(50)  NULL,
    [Cargo] nvarchar(50)  NULL,
    [EquipoId] int  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Proyectoes'
CREATE TABLE [dbo].[Proyectoes] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(255)  NULL,
    [Descripcion] nvarchar(max)  NULL,
    [FechaInicio] datetime  NULL,
    [FechaFinalizacion] datetime  NULL,
    [Estado] nvarchar(50)  NULL,
    [Presupuesto] decimal(18,2)  NULL
);
GO

-- Creating table 'Tareas'
CREATE TABLE [dbo].[Tareas] (
    [Id] int  NOT NULL,
    [Nombre] nvarchar(255)  NULL,
    [Descripcion] nvarchar(max)  NULL,
    [FechaInicio] datetime  NULL,
    [FechaFinalizacion] datetime  NULL,
    [Estado] nvarchar(50)  NULL,
    [ProyectoId] int  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int  NOT NULL,
    [NombreUsuario] nvarchar(50)  NULL,
    [Contraseña] nvarchar(255)  NULL,
    [Roles] nvarchar(255)  NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Valoraciones'
CREATE TABLE [dbo].[Valoraciones] (
    [Id] int  NOT NULL,
    [Puntuacion] int  NULL,
    [TareaId] int  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- Creating table 'Asignaciones'
CREATE TABLE [dbo].[Asignaciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MiembroId] int  NOT NULL,
    [TareaId] int  NOT NULL,
    [Rol] nvarchar(max)  NOT NULL,
    [Fecha] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [PK_Comentarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Equipos'
ALTER TABLE [dbo].[Equipos]
ADD CONSTRAINT [PK_Equipos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Miembros'
ALTER TABLE [dbo].[Miembros]
ADD CONSTRAINT [PK_Miembros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proyectoes'
ALTER TABLE [dbo].[Proyectoes]
ADD CONSTRAINT [PK_Proyectoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [PK_Tareas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Valoraciones'
ALTER TABLE [dbo].[Valoraciones]
ADD CONSTRAINT [PK_Valoraciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Asignaciones'
ALTER TABLE [dbo].[Asignaciones]
ADD CONSTRAINT [PK_Asignaciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EquipoId] in table 'Miembros'
ALTER TABLE [dbo].[Miembros]
ADD CONSTRAINT [FK_EquipoMiembro]
    FOREIGN KEY ([EquipoId])
    REFERENCES [dbo].[Equipos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipoMiembro'
CREATE INDEX [IX_FK_EquipoMiembro]
ON [dbo].[Miembros]
    ([EquipoId]);
GO

-- Creating foreign key on [MiembroId] in table 'Asignaciones'
ALTER TABLE [dbo].[Asignaciones]
ADD CONSTRAINT [FK_MiembroAsignacion]
    FOREIGN KEY ([MiembroId])
    REFERENCES [dbo].[Miembros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MiembroAsignacion'
CREATE INDEX [IX_FK_MiembroAsignacion]
ON [dbo].[Asignaciones]
    ([MiembroId]);
GO

-- Creating foreign key on [TareaId] in table 'Asignaciones'
ALTER TABLE [dbo].[Asignaciones]
ADD CONSTRAINT [FK_TareaAsignacion]
    FOREIGN KEY ([TareaId])
    REFERENCES [dbo].[Tareas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TareaAsignacion'
CREATE INDEX [IX_FK_TareaAsignacion]
ON [dbo].[Asignaciones]
    ([TareaId]);
GO

-- Creating foreign key on [ProyectoId] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_ProyectoTarea]
    FOREIGN KEY ([ProyectoId])
    REFERENCES [dbo].[Proyectoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyectoTarea'
CREATE INDEX [IX_FK_ProyectoTarea]
ON [dbo].[Tareas]
    ([ProyectoId]);
GO

-- Creating foreign key on [TareaId] in table 'Valoraciones'
ALTER TABLE [dbo].[Valoraciones]
ADD CONSTRAINT [FK_TareaValoracion]
    FOREIGN KEY ([TareaId])
    REFERENCES [dbo].[Tareas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TareaValoracion'
CREATE INDEX [IX_FK_TareaValoracion]
ON [dbo].[Valoraciones]
    ([TareaId]);
GO

-- Creating foreign key on [TareaId] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [FK_TareaComentario]
    FOREIGN KEY ([TareaId])
    REFERENCES [dbo].[Tareas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TareaComentario'
CREATE INDEX [IX_FK_TareaComentario]
ON [dbo].[Comentarios]
    ([TareaId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Valoraciones'
ALTER TABLE [dbo].[Valoraciones]
ADD CONSTRAINT [FK_UsuarioValoracion]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioValoracion'
CREATE INDEX [IX_FK_UsuarioValoracion]
ON [dbo].[Valoraciones]
    ([UsuarioId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [FK_UsuarioComentario]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioComentario'
CREATE INDEX [IX_FK_UsuarioComentario]
ON [dbo].[Comentarios]
    ([UsuarioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------