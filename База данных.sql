-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: calculator
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `event` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nameevent` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fershet`
--

DROP TABLE IF EXISTS `fershet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fershet` (
  `id` int NOT NULL AUTO_INCREMENT,
  `namefershet` varchar(100) NOT NULL,
  `descriptions` varchar(100) NOT NULL,
  `people` varchar(100) NOT NULL,
  `cost` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fershet`
--

LOCK TABLES `fershet` WRITE;
/*!40000 ALTER TABLE `fershet` DISABLE KEYS */;
/*!40000 ALTER TABLE `fershet` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `holiday`
--

DROP TABLE IF EXISTS `holiday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `holiday` (
  `id` int NOT NULL AUTO_INCREMENT,
  `startdate` datetime NOT NULL,
  `enddate` datetime NOT NULL,
  `eventid` int NOT NULL,
  `roomid` int NOT NULL,
  `klientid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `eventid` (`eventid`),
  KEY `roomid` (`roomid`),
  KEY `klientid` (`klientid`),
  CONSTRAINT `holiday_ibfk_1` FOREIGN KEY (`eventid`) REFERENCES `event` (`id`),
  CONSTRAINT `holiday_ibfk_2` FOREIGN KEY (`roomid`) REFERENCES `room` (`id`),
  CONSTRAINT `holiday_ibfk_3` FOREIGN KEY (`klientid`) REFERENCES `klient` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `holiday`
--

LOCK TABLES `holiday` WRITE;
/*!40000 ALTER TABLE `holiday` DISABLE KEYS */;
/*!40000 ALTER TABLE `holiday` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `holidayservices`
--

DROP TABLE IF EXISTS `holidayservices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `holidayservices` (
  `id` int NOT NULL AUTO_INCREMENT,
  `holidayid` int NOT NULL,
  `servicesid` int NOT NULL,
  `fershetid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `holidayid` (`holidayid`),
  KEY `servicesid` (`servicesid`),
  KEY `fershetid` (`fershetid`),
  CONSTRAINT `holidayservices_ibfk_1` FOREIGN KEY (`holidayid`) REFERENCES `holiday` (`id`),
  CONSTRAINT `holidayservices_ibfk_2` FOREIGN KEY (`servicesid`) REFERENCES `services` (`id`),
  CONSTRAINT `holidayservices_ibfk_3` FOREIGN KEY (`fershetid`) REFERENCES `fershet` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `holidayservices`
--

LOCK TABLES `holidayservices` WRITE;
/*!40000 ALTER TABLE `holidayservices` DISABLE KEYS */;
/*!40000 ALTER TABLE `holidayservices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `klient`
--

DROP TABLE IF EXISTS `klient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `klient` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fullname` varchar(100) NOT NULL,
  `phone` varchar(11) NOT NULL,
  `email` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klient`
--

LOCK TABLES `klient` WRITE;
/*!40000 ALTER TABLE `klient` DISABLE KEYS */;
/*!40000 ALTER TABLE `klient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `room`
--

DROP TABLE IF EXISTS `room`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `room` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nameroom` varchar(100) NOT NULL,
  `descriptions` varchar(100) NOT NULL,
  `persons` varchar(11) NOT NULL,
  `photo` longblob,
  `cost` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `room`
--

LOCK TABLES `room` WRITE;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
/*!40000 ALTER TABLE `room` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `services` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nameservices` varchar(100) NOT NULL,
  `cost` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-17 18:13:54
