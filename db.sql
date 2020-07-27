-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               5.1.72-community - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL Version:             9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for challenge
CREATE DATABASE IF NOT EXISTS `challenge` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `challenge`;

-- Dumping structure for table challenge.customer
CREATE TABLE IF NOT EXISTS `customer` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) NOT NULL DEFAULT '0',
  `last_name` varchar(50) NOT NULL DEFAULT '0',
  `dob` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- Dumping data for table challenge.customer: 0 rows
DELETE FROM `customer`;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` (`id`, `first_name`, `last_name`, `dob`) VALUES
	(2, 'andri', 'andri', 0),
	(3, 'aaa', 'cdad', 0),
	(4, 'baa', 'ddaa', 0),
	(5, 'aaa', 'aaaaa', 0),
	(7, 'fdasfaf', 'fdasfsaf', 0),
	(8, 'dddd', 'ddd', 0),
	(9, 'fdasfsafa', 'fdasfafad', 0),
	(10, 'fdasfafsacs', 'cadsafasdf', 0),
	(11, 'dafsafsadfdas', 'fdasfasfasdfa', 0),
	(16, 'fadfasf', 'fsadfasdfa', 0),
	(13, 'qfdqwefq', 'qfdwf', 0),
	(14, 'fsadfaf', 'qqq', 0),
	(15, 'fdsafas', 'qqq', 0),
	(17, 'azul', 'jabars', 0);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;

-- Dumping structure for table challenge.user
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table challenge.user: 0 rows
DELETE FROM `user`;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`id`, `username`, `password`) VALUES
	(1, 'nc', 'nc');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
