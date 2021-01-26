-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: tpcuarentena
-- ------------------------------------------------------
-- Server version	8.0.20

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
-- Table structure for table `alumno`
--

DROP TABLE IF EXISTS `alumno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumno` (
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Fechanacimiento` datetime NOT NULL,
  `Dni` int NOT NULL,
  `ALegajo` int NOT NULL AUTO_INCREMENT,
  `FechaDeIngreso` datetime NOT NULL,
  `FechaDeEgreso` datetime NOT NULL,
  PRIMARY KEY (`ALegajo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumno`
--

LOCK TABLES `alumno` WRITE;
/*!40000 ALTER TABLE `alumno` DISABLE KEYS */;
INSERT INTO `alumno` VALUES ('Prueba1','Prueba1','2020-12-13 00:00:00',5153115,1,'2020-12-13 00:00:00','2001-01-01 00:00:00'),('prueba2','prueba2','2020-12-13 00:00:00',454,2,'2020-12-13 00:00:00','2001-01-01 00:00:00'),('Alejandro','Avila','2020-12-13 00:00:00',78,3,'2020-12-09 00:00:00','2001-01-01 00:00:00'),('Francisco Jimenez','Javier','1994-12-01 00:00:00',1321,5,'2000-12-13 00:00:00','2020-12-13 00:00:00');
/*!40000 ALTER TABLE `alumno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alumnomateria`
--

DROP TABLE IF EXISTS `alumnomateria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumnomateria` (
  `Alegajo` int NOT NULL,
  `IdMateria` int NOT NULL,
  PRIMARY KEY (`Alegajo`,`IdMateria`),
  KEY `IdMateria_idx` (`IdMateria`),
  KEY `Plegajo_idx` (`Alegajo`),
  CONSTRAINT `IdMateria` FOREIGN KEY (`IdMateria`) REFERENCES `materias` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumnomateria`
--

LOCK TABLES `alumnomateria` WRITE;
/*!40000 ALTER TABLE `alumnomateria` DISABLE KEYS */;
INSERT INTO `alumnomateria` VALUES (1,6);
/*!40000 ALTER TABLE `alumnomateria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materias`
--

DROP TABLE IF EXISTS `materias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materias` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(60) NOT NULL,
  `AnioCurso` int NOT NULL,
  `Activa` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materias`
--

LOCK TABLES `materias` WRITE;
/*!40000 ALTER TABLE `materias` DISABLE KEYS */;
INSERT INTO `materias` VALUES (1,'Fisica',200,0),(2,'matematica',2020,0),(3,'Castellano',2020,1),(4,'Ingles',2020,1),(5,'Trigonometria Avanzada',2020,1),(6,'Artes',2020,1),(7,'EdFisica',2020,1);
/*!40000 ALTER TABLE `materias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profesor`
--

DROP TABLE IF EXISTS `profesor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profesor` (
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Fechanacimiento` datetime NOT NULL,
  `Dni` int NOT NULL,
  `PLegajo` int NOT NULL AUTO_INCREMENT,
  `FechaDeIngreso` datetime NOT NULL,
  `ACTIVO` tinyint(1) NOT NULL,
  PRIMARY KEY (`PLegajo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profesor`
--

LOCK TABLES `profesor` WRITE;
/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
INSERT INTO `profesor` VALUES ('Francisco ','Jimenez','2020-12-13 00:00:00',1501,1,'2020-12-13 00:00:00',0),('Adrian','Jimenez','1990-01-30 00:00:00',1501,2,'2019-01-15 00:00:00',1);
/*!40000 ALTER TABLE `profesor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profesormateria`
--

DROP TABLE IF EXISTS `profesormateria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profesormateria` (
  `Plegajo` int NOT NULL,
  `IdMateria` int NOT NULL,
  PRIMARY KEY (`Plegajo`,`IdMateria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profesormateria`
--

LOCK TABLES `profesormateria` WRITE;
/*!40000 ALTER TABLE `profesormateria` DISABLE KEYS */;
INSERT INTO `profesormateria` VALUES (1,3),(1,5),(1,6),(1,7),(2,5),(2,6),(3,4),(3,5),(3,7);
/*!40000 ALTER TABLE `profesormateria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'tpcuarentena'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-15  1:58:55
