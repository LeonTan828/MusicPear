# ************************************************************
# Sequel Pro SQL dump
# Version 5446
#
# https://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 8.0.16)
# Database: MusicPear
# Generation Time: 2019-08-09 17:15:50 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
SET NAMES utf8mb4;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table Avatar
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Avatar`;

CREATE TABLE `Avatar` (
  `userID` varchar(50) NOT NULL,
  `body` int(11) DEFAULT NULL,
  `head` int(11) DEFAULT NULL,
  `color` int(11) DEFAULT NULL,
  PRIMARY KEY (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



# Dump of table Belongs_to
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Belongs_to`;

CREATE TABLE `Belongs_to` (
  `songID` varchar(50) NOT NULL,
  `LID` varchar(50) NOT NULL,
  PRIMARY KEY (`songID`,`LID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



# Dump of table My_Library
# ------------------------------------------------------------

DROP TABLE IF EXISTS `My_Library`;

CREATE TABLE `My_Library` (
  `LID` varchar(50) NOT NULL,
  `userID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`LID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



# Dump of table Playlist
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Playlist`;

CREATE TABLE `Playlist` (
  `PID` varchar(50) NOT NULL,
  `pname` varchar(50) DEFAULT NULL,
  `LID` varchar(50) DEFAULT NULL,
  `userID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`PID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



# Dump of table Song
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Song`;

CREATE TABLE `Song` (
  `songID` varchar(50) NOT NULL,
  `title` varchar(50) DEFAULT NULL,
  `artist` varchar(50) DEFAULT NULL,
  `album` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`songID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



# Dump of table User
# ------------------------------------------------------------

DROP TABLE IF EXISTS `User`;

CREATE TABLE `User` (
  `userID` varchar(50) NOT NULL,
  `uname` varchar(50) DEFAULT NULL,
  `upassword` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;




/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
