CREATE TABLE `instance` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GuidID` char(36) DEFAULT 'UUID()',
  `Name` varchar(250) DEFAULT NULL,
  `Object` longtext,
  `Repository` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `GuidID_UNIQUE` (`GuidID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

CREATE TABLE `pairs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UniqueKey` varchar(250) CHARACTER SET utf8 DEFAULT NULL,
  `Object` varchar(500) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `idPairs_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
