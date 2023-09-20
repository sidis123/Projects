-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 18, 2023 at 11:09 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.0.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `lab2`
--

-- --------------------------------------------------------

--
-- Table structure for table `daktarai`
--

CREATE TABLE `daktarai` (
  `Specializacija` varchar(100) NOT NULL,
  `NuoKadaDirba` date NOT NULL,
  `Vardas` varchar(30) NOT NULL,
  `Pavarde` varchar(30) NOT NULL,
  `Telefonas` varchar(18) NOT NULL,
  `id_Daktaras` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `daktarai`
--

INSERT INTO `daktarai` (`Specializacija`, `NuoKadaDirba`, `Vardas`, `Pavarde`, `Telefonas`, `id_Daktaras`) VALUES
('Sed sit possimus sunt maxime harum et sit.', '2009-04-29', 'Christian', 'Wiegand', '1-296-901-9292x348', 1240),
('Fugit maiores et voluptatem quos et voluptatem est.', '1986-07-24', 'Glen', 'Okuneva', '+82(2)1087297095', 1624),
('Voluptatem occaecati commodi perferendis ea est tempora.', '2006-08-25', 'Chance', 'Kunze', '584.816.5741x999', 2754),
('Minus corporis atque aut quia ab consequatur.', '1974-03-07', 'Jacques', 'Macejkovic', '967.845.8161x681', 2986),
('Libero autem nostrum et dicta maiores at.', '2004-12-31', 'Odell', 'McLaughlin', '+92(3)6260828215', 3212),
('Ut tempore sunt et facere cum ipsum quo quam.', '1979-02-04', 'Jack', 'Jacobs', '1-883-889-4538', 3579),
('Sunt eum in dolorum harum dolor occaecati et.', '2010-09-25', 'Woodrow', 'Thiel', '+69(1)1171271434', 3679),
('Repellat consequatur nulla quis quisquam.', '2020-10-20', 'Monserrate', 'Schulist', '1-968-350-6698x969', 3732),
('Facere dolores qui similique consequatur minima.', '1974-04-11', 'Kirk', 'Heller', '529.556.4529x29920', 4325),
('Ratione fuga aliquam dolor sit exercitationem.', '2000-07-20', 'Jovani', 'White', '(199)403-0015x4272', 4383),
('Aspernatur quia delectus quaerat officia dolore molestiae velit.', '1980-09-20', 'Dallas', 'Abshire', '(273)395-8303', 4761),
('Eaque saepe laborum voluptatem optio enim qui perspiciatis autem.', '1983-01-27', 'Imani', 'Hodkiewicz', '1-412-910-3997', 5397),
('Eius dolore adipisci occaecati harum.', '1972-07-02', 'Ruben', 'Christiansen', '04967021425', 5738),
('Autem possimus dolorum delectus accusamus et commodi mollitia et.', '1995-04-03', 'Garrett', 'Abshire', '(254)158-2650', 5891),
('Laudantium rerum cum harum corporis excepturi.', '2008-09-17', 'Lloyd', 'Casper', '067-053-7851x6773', 7341),
('Non ducimus explicabo repellat ipsa.', '1998-06-23', 'Sanford', 'Rolfson', '04389157874', 7566),
('Repudiandae id laudantium velit.', '2002-10-07', 'Carroll', 'Renner', '615.786.6355x33797', 7682),
('Architecto et voluptate consequatur et temporibus vero amet.', '1984-06-30', 'Ahmed', 'Vandervort', '089.303.8573x17370', 8759),
('Ex tempore facilis quia praesentium vero.', '2002-04-08', 'Luis', 'Kunde', '1-989-458-8005x357', 9019),
('Ratione vitae et tempore id aut.', '1995-12-07', 'Curtis', 'Skiles', '338-541-6425x4228', 9207);

-- --------------------------------------------------------

--
-- Table structure for table `ligos_istorijos`
--

CREATE TABLE `ligos_istorijos` (
  `Susirgimo_Data` date NOT NULL,
  `Pasveikimo_Data` date NOT NULL,
  `id_Ligos_Istorija` int(11) NOT NULL,
  `fk_PacientasAsmens_Kod` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ligos_istorijos`
--

INSERT INTO `ligos_istorijos` (`Susirgimo_Data`, `Pasveikimo_Data`, `id_Ligos_Istorija`, `fk_PacientasAsmens_Kod`) VALUES
('2016-11-10', '1997-03-27', 0, '0032903'),
('1976-01-22', '2005-11-09', 98, '4725367'),
('1998-05-01', '2017-09-08', 739, '8978409'),
('1977-03-28', '2009-02-20', 1997, '3273408'),
('1985-06-26', '2008-06-09', 3440, '4747806'),
('1973-12-31', '1995-01-15', 4492, '1454669'),
('2021-01-06', '1976-08-18', 5639, '1976893'),
('1980-04-08', '1992-10-22', 22959, '5504181'),
('2016-10-04', '2001-07-10', 71101, '9663563'),
('2013-06-04', '2017-02-07', 147863, '1297322'),
('1999-11-15', '2015-01-20', 750157, '3150053'),
('1991-01-03', '1970-03-18', 1754953, '7058642'),
('2008-08-05', '1999-10-11', 2300275, '9268295'),
('2020-01-23', '1989-06-20', 7238362, '2753986'),
('1975-10-02', '2014-01-15', 8455742, '7145329'),
('1981-01-02', '1996-06-29', 9540566, '0868853'),
('2021-12-26', '2015-03-08', 39761968, '6291972'),
('2013-11-13', '1986-11-07', 206426994, '6784845'),
('2009-11-10', '1981-08-25', 311532877, '3940032'),
('1989-08-02', '1998-11-14', 963360631, '0469829');

-- --------------------------------------------------------

--
-- Table structure for table `pacientai`
--

CREATE TABLE `pacientai` (
  `Vardas` varchar(30) NOT NULL,
  `Pavarde` varchar(30) NOT NULL,
  `Gimimo_Data` date NOT NULL,
  `Diabetikas` tinyint(1) NOT NULL,
  `Adresas` varchar(200) NOT NULL,
  `Telefonas` varchar(15) NOT NULL,
  `Asmens_Kod` varchar(13) NOT NULL,
  `El_Pastas` varchar(50) NOT NULL,
  `fk_Seseleid_Sesele` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pacientai`
--

INSERT INTO `pacientai` (`Vardas`, `Pavarde`, `Gimimo_Data`, `Diabetikas`, `Adresas`, `Telefonas`, `Asmens_Kod`, `El_Pastas`, `fk_Seseleid_Sesele`) VALUES
('Erberts', 'Kirhenšteins', '2019-01-28', 1, '47 Neilands Causeway', '+371 8193131', '0032903', 'česlava.saulīte@hotmail.com', 1),
('Evģenijs', 'Ozoliņi', '2002-12-13', 0, '88 Muižeļi Dale Apt. 929', '+371 7574575', '0469829', 'žuanete66@hotmail.com', 2),
('Ādams', 'Lazovskis', '2006-02-15', 0, '37 Dāles Forks', '60987070', '0868853', 'ervids31@gmail.com', 3),
('Ero', 'Priedīte', '1972-05-21', 0, '21 Krieviņš Vista', '91-867-484', '1297322', 'obērziņš@yahoo.com', 4),
('Dzintars', 'Freidenfelds', '2009-04-01', 0, '11 Jankevics Mills', '30-702-391', '1454669', 'āris.dombrovskis@budreiko.com', 5),
('Ženija', 'Muciņš', '1976-03-31', 1, '35 Ermanis Point Apt. 563', '+371 2496456', '1976893', 'gozoliņš@silmanissaulīte.com', 6),
('Everts', 'Krieviņš', '2011-07-12', 1, '30 Kreši Keys Apt. 375', '03639385', '2753986', 'veidenbaums.ermanis@šileiko.biz', 7),
('Enrijs', 'Rozentāls', '1977-10-17', 1, '62 Krieviņš Wall Suite 339', '63-680-598', '3150053', 'esams60@bērziņšzviedrītis.com', 8),
('Žuanete', 'Lejiņš', '2004-08-29', 0, '42 Ģints Path', '69-059-017', '3273408', 'kreši.žanija@hotmail.com', 9),
('Evgenijs', 'Liepiņš', '1971-07-02', 0, '33 Andersons Isle Suite 002', '67-522-660', '3940032', 'dombrovskis.žene@polītiskronvalds.com', 10),
('Ermīns', 'Sēļi', '1977-05-19', 1, '97 Ernis Islands', '02540902', '4725367', 'ēvisa46@jankevicskalniņi.biz', 11),
('Evarts', 'Liepiņš', '1975-01-14', 0, '34 Erlends Mountain', '+371 8006267', '4747806', 'ymuižeļi@sēļibudreiko.com', 12),
('Ernests', 'Andreiko', '1993-08-01', 0, '74 Emīls Squares Suite 162', '96217705', '5504181', 'zkovaļevskis@gmail.com', 13),
('Enno', 'Raņķi', '2013-02-22', 1, '21 Ratkēvičs Lakes Apt. 195', '92-558-239', '6291972', 'erims.lejiņš@gmail.com', 14),
('Enriko', 'Ratkēvičs', '1976-01-15', 0, '41 Ervids Ford', '+371 8887245', '6784845', 'gratkēvičs@zviedrītis.biz', 15),
('Šandors', 'Budreiko', '1978-02-18', 0, '29 Rungaiņi Corners Apt. 137', '17735435', '7058642', 'žermena03@yahoo.com', 16),
('Enriko', 'Blaumanis', '2009-09-03', 1, '07 Jurēvics Lake', '81-984-469', '7145329', 'krieviņš.ģederts@jankovskis.com', 17),
('Eventijs', 'Kalniņš', '2005-08-05', 0, '67 Ervijs Square Suite 216', '94-579-707', '8978409', 'ratkēvičs.žermena@jankovskis.com', 18),
('Ervils', 'Jankovskis', '2022-11-29', 1, '04 Dumpji Falls', '85-523-773', '9268295', 'ārvaldis94@gmail.com', 19),
('Šandors', 'Gailītis', '2019-07-16', 1, '87 Priedīte Manors', '79654281', '9663563', 'siliņš.ervids@yahoo.com', 20);

-- --------------------------------------------------------

--
-- Table structure for table `seseles`
--

CREATE TABLE `seseles` (
  `Vardas` varchar(255) NOT NULL,
  `id_Sesele` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `seseles`
--

INSERT INTO `seseles` (`Vardas`, `id_Sesele`) VALUES
('Zaneta', 1),
('Dziumbra', 2),
('Sasuke', 3),
('Maugle', 4),
('ZAZA', 5),
('MiaKhalifa', 6),
('Saule', 7),
('Mangruda', 8),
('Joe', 9),
('Mama', 10),
('Sukon', 11),
('Deeez', 12),
('Rocken', 13),
('Rollas', 14),
('Arenijus', 15),
('Remyga', 16),
('Bezdzione', 17),
('Sesute', 18),
('Silke', 19),
('coca cola', 20);

-- --------------------------------------------------------

--
-- Table structure for table `turi`
--

CREATE TABLE `turi` (
  `fk_Daktarasid_Daktaras` int(11) NOT NULL,
  `fk_PacientasAsmens_Kod` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `turi`
--

INSERT INTO `turi` (`fk_Daktarasid_Daktaras`, `fk_PacientasAsmens_Kod`) VALUES
(1240, '0032903'),
(1624, '0469829'),
(2754, '0868853'),
(2986, '1297322'),
(3212, '1454669'),
(3579, '1976893'),
(3679, '2753986'),
(3732, '3150053'),
(4325, '3273408'),
(4383, '3940032'),
(4761, '4725367'),
(5397, '4747806'),
(5738, '5504181'),
(5891, '6291972'),
(7341, '6784845'),
(7566, '7058642'),
(7682, '7145329'),
(8759, '8978409'),
(9019, '9268295'),
(9207, '9663563');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `daktarai`
--
ALTER TABLE `daktarai`
  ADD PRIMARY KEY (`id_Daktaras`);

--
-- Indexes for table `ligos_istorijos`
--
ALTER TABLE `ligos_istorijos`
  ADD PRIMARY KEY (`id_Ligos_Istorija`),
  ADD UNIQUE KEY `fk_PacientasAsmens_Kod` (`fk_PacientasAsmens_Kod`);

--
-- Indexes for table `pacientai`
--
ALTER TABLE `pacientai`
  ADD PRIMARY KEY (`Asmens_Kod`),
  ADD KEY `Slaugo` (`fk_Seseleid_Sesele`);

--
-- Indexes for table `seseles`
--
ALTER TABLE `seseles`
  ADD PRIMARY KEY (`id_Sesele`);

--
-- Indexes for table `turi`
--
ALTER TABLE `turi`
  ADD PRIMARY KEY (`fk_Daktarasid_Daktaras`,`fk_PacientasAsmens_Kod`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ligos_istorijos`
--
ALTER TABLE `ligos_istorijos`
  ADD CONSTRAINT `turi4` FOREIGN KEY (`fk_PacientasAsmens_Kod`) REFERENCES `pacientai` (`Asmens_Kod`);

--
-- Constraints for table `pacientai`
--
ALTER TABLE `pacientai`
  ADD CONSTRAINT `Slaugo` FOREIGN KEY (`fk_Seseleid_Sesele`) REFERENCES `seseles` (`id_Sesele`);

--
-- Constraints for table `turi`
--
ALTER TABLE `turi`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_Daktarasid_Daktaras`) REFERENCES `daktarai` (`id_Daktaras`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
