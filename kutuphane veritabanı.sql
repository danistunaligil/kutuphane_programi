-- --------------------------------------------------------
-- Sunucu:                       127.0.0.1
-- Sunucu sürümü:                8.0.17 - MySQL Community Server - GPL
-- Sunucu İşletim Sistemi:       Win64
-- HeidiSQL Sürüm:               11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- kutuphane için veritabanı yapısı dökülüyor
CREATE DATABASE IF NOT EXISTS `kutuphane` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `kutuphane`;

-- tablo yapısı dökülüyor kutuphane.kitaplar
CREATE TABLE IF NOT EXISTS `kitaplar` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `barkod` varchar(20) NOT NULL DEFAULT '0',
  `adi` varchar(100) NOT NULL DEFAULT '0',
  `yazari` varchar(100) NOT NULL DEFAULT '0',
  `yayinevi` varchar(100) NOT NULL DEFAULT '0',
  `adet` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `barkod` (`barkod`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- kutuphane.kitaplar: ~2 rows (yaklaşık) tablosu için veriler indiriliyor
/*!40000 ALTER TABLE `kitaplar` DISABLE KEYS */;
INSERT INTO `kitaplar` (`id`, `barkod`, `adi`, `yazari`, `yayinevi`, `adet`) VALUES
	(1, '1111111111111', 'Don kişot', 'cervantes', 'hakan yayınevi', 5),
	(2, '2222222222222', 'mor salkımlı ev', 'halide edip adıvar', 'bilmemne yayınevi', 3);
/*!40000 ALTER TABLE `kitaplar` ENABLE KEYS */;

-- tablo yapısı dökülüyor kutuphane.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `adi` varchar(30) NOT NULL DEFAULT '0',
  `password` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `su` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `adi` (`adi`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- kutuphane.users: ~4 rows (yaklaşık) tablosu için veriler indiriliyor
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`id`, `adi`, `password`, `su`) VALUES
	(5, 'Ayça', 'zKcBnXs2bis=', 1),
	(6, 'Admin', 'HACWG13z8e8=', 1),
	(7, 'Emir', '4Q+fxyyVTFk=', 0),
	(8, 'Emir Kaya', '4Q+fxyyVTFk=', 0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- tablo yapısı dökülüyor kutuphane.uyeler
CREATE TABLE IF NOT EXISTS `uyeler` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tc` varchar(11) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ad` varchar(30) DEFAULT NULL,
  `soyad` varchar(30) DEFAULT NULL,
  `cinsiyet` varchar(5) DEFAULT NULL,
  `telefon` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `e_posta` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `tc` (`tc`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- kutuphane.uyeler: ~7 rows (yaklaşık) tablosu için veriler indiriliyor
/*!40000 ALTER TABLE `uyeler` DISABLE KEYS */;
INSERT INTO `uyeler` (`id`, `tc`, `ad`, `soyad`, `cinsiyet`, `telefon`, `e_posta`) VALUES
	(1, '10036073022', 'Emirhan', 'Bodur', 'Erkek', '(506) 214 55 77', 'e_bodur@gmail.com'),
	(7, '11111222235', 'Şükrü', 'Çobanoğlu', 'Erkek', '(553) 565-6565', 'guneysukru@gmail.com'),
	(8, '12312312344', 'Serkan', 'Güleç', 'Erkek', '(544) 444-4444', ''),
	(9, '22233344455', 'Mehmet', 'Kaya', 'Erkek', '(544) 444-4444', ''),
	(10, '44433366688', 'Gülnisa', 'Emirhasan', 'Kız', '(506)1231234', NULL),
	(11, '44444444444', 'Ersin', 'Yiğit', 'Erkek', '(544) 444-4444', ''),
	(12, '22222222222', 'Ali', 'Uğurlu', 'Erkek', '(555) 555-5555', '');
/*!40000 ALTER TABLE `uyeler` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
