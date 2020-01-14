
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/28/2019 11:47:37
-- Generated from EDMX file: D:\Project C#\Fingerprint\Fingerprint\Fingerprint.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [fingerprint];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_absen_pegawai]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[absen] DROP CONSTRAINT [FK_absen_pegawai];
GO
IF OBJECT_ID(N'[dbo].[FK_izin_pegawai]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[izin] DROP CONSTRAINT [FK_izin_pegawai];
GO
IF OBJECT_ID(N'[dbo].[FK_jadwal_pegawai]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[jadwal] DROP CONSTRAINT [FK_jadwal_pegawai];
GO
IF OBJECT_ID(N'[dbo].[FK_log_pegawai]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[log] DROP CONSTRAINT [FK_log_pegawai];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[absen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[absen];
GO
IF OBJECT_ID(N'[dbo].[aturan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aturan];
GO
IF OBJECT_ID(N'[dbo].[hari_khusus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[hari_khusus];
GO
IF OBJECT_ID(N'[dbo].[izin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[izin];
GO
IF OBJECT_ID(N'[dbo].[jadwal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[jadwal];
GO
IF OBJECT_ID(N'[dbo].[libur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[libur];
GO
IF OBJECT_ID(N'[dbo].[log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[log];
GO
IF OBJECT_ID(N'[dbo].[mesin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[mesin];
GO
IF OBJECT_ID(N'[dbo].[pegawai]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pegawai];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'absens'
CREATE TABLE [dbo].[absens] (
    [pegawai_id] int  NOT NULL,
    [absen_tanggal] datetime  NOT NULL,
    [absen_hari] varchar(200)  NOT NULL,
    [absen_izin] varchar(50)  NULL,
    [absen_telat] time  NULL,
    [absen_masuk] time  NULL,
    [absen_pulang] time  NULL,
    [absen_istirahat] time  NULL,
    [absen_kembali] time  NULL,
    [absen_lembur] time  NULL,
    [absen_lembur_pulang] time  NULL,
    [upload] bit  NOT NULL
);
GO

-- Creating table 'aturans'
CREATE TABLE [dbo].[aturans] (
    [aturan_hari] int  NOT NULL,
    [aturan_kegiatan] bit  NOT NULL,
    [aturan_jam_masuk] time  NOT NULL,
    [aturan_jam_pulang] time  NOT NULL,
    [aturan_jam_masuk_khusus] time  NOT NULL,
    [aturan_jam_pulang_khusus] time  NOT NULL
);
GO

-- Creating table 'hari_khusus'
CREATE TABLE [dbo].[hari_khusus] (
    [hari_khusus_tanggal] datetime  NOT NULL,
    [hari_khusus_keterangan] varchar(max)  NOT NULL
);
GO

-- Creating table 'izins'
CREATE TABLE [dbo].[izins] (
    [pegawai_id] int  NOT NULL,
    [izin_tanggal] datetime  NOT NULL,
    [izin_jenis] varchar(50)  NOT NULL,
    [izin_keterangan] varchar(max)  NULL
);
GO

-- Creating table 'jadwals'
CREATE TABLE [dbo].[jadwals] (
    [pegawai_id] int  NOT NULL,
    [shift_id] int  NOT NULL,
    [jadwal_tanggal] datetime  NOT NULL
);
GO

-- Creating table 'liburs'
CREATE TABLE [dbo].[liburs] (
    [libur_tanggal] datetime  NOT NULL,
    [libur_keterangan] varchar(max)  NOT NULL
);
GO

-- Creating table 'logs'
CREATE TABLE [dbo].[logs] (
    [log_id] int IDENTITY(1,1) NOT NULL,
    [pegawai_id] int  NOT NULL,
    [log_tanggal] datetime  NOT NULL,
    [log_jam] time  NOT NULL,
    [log_kode] varchar(10)  NOT NULL,
    [log_keterangan] varchar(10)  NULL,
    [log_status] varchar(10)  NOT NULL
);
GO

-- Creating table 'mesins'
CREATE TABLE [dbo].[mesins] (
    [mesin_id] int IDENTITY(1,1) NOT NULL,
    [mesin_nama] varchar(50)  NOT NULL,
    [mesin_ip] varchar(50)  NOT NULL,
    [mesin_key] varchar(max)  NOT NULL,
    [mesin_sn] varchar(50)  NOT NULL
);
GO

-- Creating table 'pegawais'
CREATE TABLE [dbo].[pegawais] (
    [pegawai_id] int IDENTITY(1,1) NOT NULL,
    [pegawai_nip] varchar(50)  NULL,
    [pegawai_nama] varchar(max)  NOT NULL,
    [pegawai_panggilan] varchar(100)  NOT NULL,
    [pegawai_golongan] nchar(10)  NOT NULL,
    [pegawai_jenis_kelamin] nchar(10)  NULL,
    [pegawai_izin] nchar(1)  NOT NULL,
    [pegawai_sandi] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [pegawai_id], [absen_tanggal] in table 'absens'
ALTER TABLE [dbo].[absens]
ADD CONSTRAINT [PK_absens]
    PRIMARY KEY CLUSTERED ([pegawai_id], [absen_tanggal] ASC);
GO

-- Creating primary key on [aturan_hari] in table 'aturans'
ALTER TABLE [dbo].[aturans]
ADD CONSTRAINT [PK_aturans]
    PRIMARY KEY CLUSTERED ([aturan_hari] ASC);
GO

-- Creating primary key on [hari_khusus_tanggal] in table 'hari_khusus'
ALTER TABLE [dbo].[hari_khusus]
ADD CONSTRAINT [PK_hari_khusus]
    PRIMARY KEY CLUSTERED ([hari_khusus_tanggal] ASC);
GO

-- Creating primary key on [pegawai_id], [izin_tanggal] in table 'izins'
ALTER TABLE [dbo].[izins]
ADD CONSTRAINT [PK_izins]
    PRIMARY KEY CLUSTERED ([pegawai_id], [izin_tanggal] ASC);
GO

-- Creating primary key on [pegawai_id], [shift_id], [jadwal_tanggal] in table 'jadwals'
ALTER TABLE [dbo].[jadwals]
ADD CONSTRAINT [PK_jadwals]
    PRIMARY KEY CLUSTERED ([pegawai_id], [shift_id], [jadwal_tanggal] ASC);
GO

-- Creating primary key on [libur_tanggal] in table 'liburs'
ALTER TABLE [dbo].[liburs]
ADD CONSTRAINT [PK_liburs]
    PRIMARY KEY CLUSTERED ([libur_tanggal] ASC);
GO

-- Creating primary key on [log_id] in table 'logs'
ALTER TABLE [dbo].[logs]
ADD CONSTRAINT [PK_logs]
    PRIMARY KEY CLUSTERED ([log_id] ASC);
GO

-- Creating primary key on [mesin_id] in table 'mesins'
ALTER TABLE [dbo].[mesins]
ADD CONSTRAINT [PK_mesins]
    PRIMARY KEY CLUSTERED ([mesin_id] ASC);
GO

-- Creating primary key on [pegawai_id] in table 'pegawais'
ALTER TABLE [dbo].[pegawais]
ADD CONSTRAINT [PK_pegawais]
    PRIMARY KEY CLUSTERED ([pegawai_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [pegawai_id] in table 'absens'
ALTER TABLE [dbo].[absens]
ADD CONSTRAINT [FK_absen_pegawai]
    FOREIGN KEY ([pegawai_id])
    REFERENCES [dbo].[pegawais]
        ([pegawai_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [pegawai_id] in table 'izins'
ALTER TABLE [dbo].[izins]
ADD CONSTRAINT [FK_izin_pegawai]
    FOREIGN KEY ([pegawai_id])
    REFERENCES [dbo].[pegawais]
        ([pegawai_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [pegawai_id] in table 'jadwals'
ALTER TABLE [dbo].[jadwals]
ADD CONSTRAINT [FK_jadwal_pegawai]
    FOREIGN KEY ([pegawai_id])
    REFERENCES [dbo].[pegawais]
        ([pegawai_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [pegawai_id] in table 'logs'
ALTER TABLE [dbo].[logs]
ADD CONSTRAINT [FK_log_pegawai]
    FOREIGN KEY ([pegawai_id])
    REFERENCES [dbo].[pegawais]
        ([pegawai_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_log_pegawai'
CREATE INDEX [IX_FK_log_pegawai]
ON [dbo].[logs]
    ([pegawai_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------