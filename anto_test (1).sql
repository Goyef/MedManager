-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:3306
-- Généré le : ven. 22 nov. 2024 à 16:47
-- Version du serveur : 5.7.24
-- Version de PHP : 8.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `anto_test`
--

-- --------------------------------------------------------

--
-- Structure de la table `allergiemedicament`
--

CREATE TABLE `allergiemedicament` (
  `AllergiesAllergieId` int(11) NOT NULL,
  `MedicamentsMedicamentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `allergiepatient`
--

CREATE TABLE `allergiepatient` (
  `AllergiesAllergieId` int(11) NOT NULL,
  `PatientsPatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `allergiepatient`
--

INSERT INTO `allergiepatient` (`AllergiesAllergieId`, `PatientsPatientId`) VALUES
(4, 1);

-- --------------------------------------------------------

--
-- Structure de la table `allergies`
--

CREATE TABLE `allergies` (
  `AllergieId` int(11) NOT NULL,
  `Libelle_al` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `allergies`
--

INSERT INTO `allergies` (`AllergieId`, `Libelle_al`) VALUES
(1, 'Coriandre'),
(2, 'Pollen'),
(3, 'Acarien'),
(4, 'Arachide'),
(5, 'Oeuf'),
(6, 'Lait');

-- --------------------------------------------------------

--
-- Structure de la table `antecedentmedicament`
--

CREATE TABLE `antecedentmedicament` (
  `AntecedentsAntecedentId` int(11) NOT NULL,
  `MedicamentsMedicamentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `antecedentpatient`
--

CREATE TABLE `antecedentpatient` (
  `AntecedentsAntecedentId` int(11) NOT NULL,
  `PatientsPatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `antecedentpatient`
--

INSERT INTO `antecedentpatient` (`AntecedentsAntecedentId`, `PatientsPatientId`) VALUES
(1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `antecedents`
--

CREATE TABLE `antecedents` (
  `AntecedentId` int(11) NOT NULL,
  `Libelle_a` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `antecedents`
--

INSERT INTO `antecedents` (`AntecedentId`, `Libelle_a`) VALUES
(1, 'Diabète'),
(2, 'Acné'),
(3, 'Anxiété'),
(4, 'Dépression'),
(5, 'Arthrite');

-- --------------------------------------------------------

--
-- Structure de la table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `Date_naissance_m` datetime(6) NOT NULL,
  `Role` varchar(30) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `Date_naissance_m`, `Role`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('ba7030c6-1bd0-4c3c-9067-d2f9ba33202a', '1992-10-08 00:00:00.000000', 'Prof', 'azerty', 'AZERTY', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEGaegzgIJeAX8lcoQrRPY1lmaxwrIm7zG1gzgj2H8jVTBG2AEYpd+O3yfuefMOh+ww==', 'BZQAAXHVZO4ZXNMW3QQUQPRIG5TTBJ65', 'ee948e3c-5ddc-4480-b6d7-173ca27436fc', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Structure de la table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `medicamentordonnance`
--

CREATE TABLE `medicamentordonnance` (
  `MedicamentsMedicamentId` int(11) NOT NULL,
  `OrdonnancesOrdonnanceId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `medicamentordonnance`
--

INSERT INTO `medicamentordonnance` (`MedicamentsMedicamentId`, `OrdonnancesOrdonnanceId`) VALUES
(2, 1),
(4, 1);

-- --------------------------------------------------------

--
-- Structure de la table `medicaments`
--

CREATE TABLE `medicaments` (
  `MedicamentId` int(11) NOT NULL,
  `Libelle_med` varchar(50) NOT NULL,
  `Contr_indication` longtext NOT NULL,
  `compteur` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `medicaments`
--

INSERT INTO `medicaments` (`MedicamentId`, `Libelle_med`, `Contr_indication`, `compteur`) VALUES
(1, 'Gabapentin', ' Utiliser avec prudence chez les patients ayant des troubles psychiatriques.', 0),
(2, 'Losartan', 'Ne pas utiliser avant de dormir', 1),
(3, 'Omeprazole', 'A eviter si vous êtes conducteur', 0),
(4, 'Albuterol', '...', 1),
(5, 'Metoprolol', '...', 0),
(6, 'Metformin', 'Ne pas utiliser en hiver', 0),
(7, 'Lisinopril', '...', 0),
(8, 'Levothyroxine', 'Ne pas consommer si déjà pris la même semaine', 0),
(9, 'Atorvastatin ', '...', 0),
(10, 'Amlodipine', 'Peut aggraver une toux sans fièvre', 0);

-- --------------------------------------------------------

--
-- Structure de la table `ordonnances`
--

CREATE TABLE `ordonnances` (
  `OrdonnanceId` int(11) NOT NULL,
  `Posologie` longtext NOT NULL,
  `Date_debut` datetime(6) NOT NULL,
  `Date_fin` datetime(6) NOT NULL,
  `Instructions_specifique` longtext,
  `MedecinId` varchar(255) NOT NULL,
  `PatientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `ordonnances`
--

INSERT INTO `ordonnances` (`OrdonnanceId`, `Posologie`, `Date_debut`, `Date_fin`, `Instructions_specifique`, `MedecinId`, `PatientId`) VALUES
(1, '5 nuits par semaines et des fois le matin', '2024-11-22 00:00:00.000000', '2024-11-23 00:00:00.000000', 'par l\'oreille', 'ba7030c6-1bd0-4c3c-9067-d2f9ba33202a', 1);

-- --------------------------------------------------------

--
-- Structure de la table `patients`
--

CREATE TABLE `patients` (
  `PatientId` int(11) NOT NULL,
  `Nom_p` longtext NOT NULL,
  `Prenom_p` longtext NOT NULL,
  `Age_p` int(11) NOT NULL,
  `Sexe_p` longtext NOT NULL,
  `Num_secu` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `patients`
--

INSERT INTO `patients` (`PatientId`, `Nom_p`, `Prenom_p`, `Age_p`, `Sexe_p`, `Num_secu`) VALUES
(1, 'Antoine', 'LeMec', 5, 'F', '123456789123456');

-- --------------------------------------------------------

--
-- Structure de la table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241122162305_FisrtMigration', '8.0.1');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `allergiemedicament`
--
ALTER TABLE `allergiemedicament`
  ADD PRIMARY KEY (`AllergiesAllergieId`,`MedicamentsMedicamentId`),
  ADD KEY `IX_AllergieMedicament_MedicamentsMedicamentId` (`MedicamentsMedicamentId`);

--
-- Index pour la table `allergiepatient`
--
ALTER TABLE `allergiepatient`
  ADD PRIMARY KEY (`AllergiesAllergieId`,`PatientsPatientId`),
  ADD KEY `IX_AllergiePatient_PatientsPatientId` (`PatientsPatientId`);

--
-- Index pour la table `allergies`
--
ALTER TABLE `allergies`
  ADD PRIMARY KEY (`AllergieId`);

--
-- Index pour la table `antecedentmedicament`
--
ALTER TABLE `antecedentmedicament`
  ADD PRIMARY KEY (`AntecedentsAntecedentId`,`MedicamentsMedicamentId`),
  ADD KEY `IX_AntecedentMedicament_MedicamentsMedicamentId` (`MedicamentsMedicamentId`);

--
-- Index pour la table `antecedentpatient`
--
ALTER TABLE `antecedentpatient`
  ADD PRIMARY KEY (`AntecedentsAntecedentId`,`PatientsPatientId`),
  ADD KEY `IX_AntecedentPatient_PatientsPatientId` (`PatientsPatientId`);

--
-- Index pour la table `antecedents`
--
ALTER TABLE `antecedents`
  ADD PRIMARY KEY (`AntecedentId`);

--
-- Index pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Index pour la table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Index pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Index pour la table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Index pour la table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Index pour la table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Index pour la table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Index pour la table `medicamentordonnance`
--
ALTER TABLE `medicamentordonnance`
  ADD PRIMARY KEY (`MedicamentsMedicamentId`,`OrdonnancesOrdonnanceId`),
  ADD KEY `IX_MedicamentOrdonnance_OrdonnancesOrdonnanceId` (`OrdonnancesOrdonnanceId`);

--
-- Index pour la table `medicaments`
--
ALTER TABLE `medicaments`
  ADD PRIMARY KEY (`MedicamentId`);

--
-- Index pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  ADD PRIMARY KEY (`OrdonnanceId`),
  ADD KEY `IX_Ordonnances_MedecinId` (`MedecinId`),
  ADD KEY `IX_Ordonnances_PatientId` (`PatientId`);

--
-- Index pour la table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`PatientId`);

--
-- Index pour la table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `allergies`
--
ALTER TABLE `allergies`
  MODIFY `AllergieId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pour la table `antecedents`
--
ALTER TABLE `antecedents`
  MODIFY `AntecedentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `medicaments`
--
ALTER TABLE `medicaments`
  MODIFY `MedicamentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  MODIFY `OrdonnanceId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `patients`
--
ALTER TABLE `patients`
  MODIFY `PatientId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `allergiemedicament`
--
ALTER TABLE `allergiemedicament`
  ADD CONSTRAINT `FK_AllergieMedicament_Allergies_AllergiesAllergieId` FOREIGN KEY (`AllergiesAllergieId`) REFERENCES `allergies` (`AllergieId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AllergieMedicament_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `allergiepatient`
--
ALTER TABLE `allergiepatient`
  ADD CONSTRAINT `FK_AllergiePatient_Allergies_AllergiesAllergieId` FOREIGN KEY (`AllergiesAllergieId`) REFERENCES `allergies` (`AllergieId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AllergiePatient_Patients_PatientsPatientId` FOREIGN KEY (`PatientsPatientId`) REFERENCES `patients` (`PatientId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `antecedentmedicament`
--
ALTER TABLE `antecedentmedicament`
  ADD CONSTRAINT `FK_AntecedentMedicament_Antecedents_AntecedentsAntecedentId` FOREIGN KEY (`AntecedentsAntecedentId`) REFERENCES `antecedents` (`AntecedentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AntecedentMedicament_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `antecedentpatient`
--
ALTER TABLE `antecedentpatient`
  ADD CONSTRAINT `FK_AntecedentPatient_Antecedents_AntecedentsAntecedentId` FOREIGN KEY (`AntecedentsAntecedentId`) REFERENCES `antecedents` (`AntecedentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AntecedentPatient_Patients_PatientsPatientId` FOREIGN KEY (`PatientsPatientId`) REFERENCES `patients` (`PatientId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Contraintes pour la table `medicamentordonnance`
--
ALTER TABLE `medicamentordonnance`
  ADD CONSTRAINT `FK_MedicamentOrdonnance_Medicaments_MedicamentsMedicamentId` FOREIGN KEY (`MedicamentsMedicamentId`) REFERENCES `medicaments` (`MedicamentId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_MedicamentOrdonnance_Ordonnances_OrdonnancesOrdonnanceId` FOREIGN KEY (`OrdonnancesOrdonnanceId`) REFERENCES `ordonnances` (`OrdonnanceId`) ON DELETE CASCADE;

--
-- Contraintes pour la table `ordonnances`
--
ALTER TABLE `ordonnances`
  ADD CONSTRAINT `FK_Ordonnances_AspNetUsers_MedecinId` FOREIGN KEY (`MedecinId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Ordonnances_Patients_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `patients` (`PatientId`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
