USE master;
GO

-- 🔹 Création du login SQL Server
CREATE LOGIN userKL 
WITH PASSWORD = '1234KITLAN';
GO

-- 🔹 Aller dans la base kitlanDB
USE kitlanDB;
GO

-- 🔹 Création de l'utilisateur dans la base de données
CREATE USER userKL FOR LOGIN userKL;
GO

-- 🔹 Attribution des permissions (lecture et écriture)
ALTER ROLE db_owner ADD MEMBER userKL;
GO
