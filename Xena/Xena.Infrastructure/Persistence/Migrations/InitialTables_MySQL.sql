DROP TABLE IF EXISTS `amazonadgroups`;

CREATE TABLE `amazonadgroups` (
  `Id` bigint NOT NULL,
  `UserId` int NOT NULL,
  `profileId` bigint NOT NULL,
  `campaignId` bigint NOT NULL,
  `Data` text,
  `LastSyncDate` datetime(6) NOT NULL,
  `IsDeleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `amazoncampaigns`;

CREATE TABLE `amazoncampaigns` (
  `Id` bigint NOT NULL,
  `UserId` int NOT NULL,
  `profileId` bigint NOT NULL,
  `Data` text,
  `LastSyncDate` datetime(6) NOT NULL,
  `IsDeleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `amazonkeywords`;

CREATE TABLE `amazonkeywords` (
  `Id` bigint NOT NULL,
  `UserId` int NOT NULL,
  `profileId` bigint NOT NULL,
  `adGroupId` bigint NOT NULL,
  `campaignId` bigint NOT NULL,
  `Data` text,
  `LastSyncDate` datetime(6) NOT NULL,
  `IsDeleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `amazonprofiles`;

CREATE TABLE `amazonprofiles` (
  `Id` bigint NOT NULL,
  `UserId` int NOT NULL,
  `Data` text,
  `LastSyncDate` datetime(6) NOT NULL,
  `IsDeleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `blacklistedtokens`;

CREATE TABLE `blacklistedtokens` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Token` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `LogoutDate` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `logs`;

CREATE TABLE `logs` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `Type` int NOT NULL,
  `ModuleId` int NOT NULL,
  `Data` longtext,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `IsDeleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `permissions`;

CREATE TABLE `permissions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `rolepermissions`;

CREATE TABLE `rolepermissions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` int NOT NULL,
  `PermissionId` int NOT NULL,
  `Type` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `roles`;

CREATE TABLE `roles` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `AdId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `userroles`;

CREATE TABLE `userroles` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `RoleId` int NOT NULL,
  PRIMARY KEY (`Id`)
);

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `LastName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Photo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `DOB` datetime(6) NOT NULL,
  `Address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Status` int NOT NULL,
  `CreateDate` datetime(6) NOT NULL,
  `UpdateDate` datetime(6) DEFAULT NULL,
  `IsDeleted` tinyint NOT NULL,
  PRIMARY KEY (`Id`)
);
