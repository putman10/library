-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 19, 2018 at 11:30 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `library`
--
CREATE DATABASE IF NOT EXISTS `library` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `library`;

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE `authors` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`id`, `name`) VALUES
(1, 'Beverly Cleary'),
(2, 'Greg Porter'),
(3, 'Tammy Johnson'),
(4, 'Ryan'),
(5, 'Ryan'),
(6, 'Nick'),
(7, 'Renee Sarley'),
(8, 'Renee Sarley'),
(9, 'Test Author'),
(10, 'Michael Jordan'),
(11, 'Michael Jordan'),
(12, 'Test'),
(13, 'TEst author '),
(14, 'another test author '),
(15, 'again '),
(16, 'noather one '),
(17, 'ZXCVZXC'),
(18, 'ASDFASD'),
(19, 'VSDAWSED'),
(20, 'K.JKL.JKL;'),
(21, 'Peter Pan'),
(22, 'CIndy Loo Hoo'),
(23, 'Jennifer Lopez'),
(24, 'Britney Spears'),
(25, 'Jennifer Lopez'),
(26, 'Britney Spears'),
(27, 'Pink'),
(28, 'Beyonce'),
(29, 'Jennifer Lopez'),
(30, 'Britney Spears'),
(31, 'Clifford Lane'),
(32, 'Harry Water'),
(33, 'Glacier Point'),
(34, 'Glacier Point'),
(35, 'Panasonic Headphone'),
(36, 'Panasonic Headphone'),
(37, 'EXPO 12'),
(38, 'EXPO 12'),
(39, 'EXPO 13'),
(40, 'EXPO 13'),
(41, 'teeeest Author1'),
(42, 'teeeest Author2'),
(43, 'test'),
(44, 'George of the jungle'),
(45, 'Greg Snail'),
(46, 'REnee'),
(47, 'Reese'),
(48, 'Renee'),
(49, 'Ryan'),
(50, 'THad'),
(51, 'Ryan'),
(52, 'Renee'),
(53, 'Ryan'),
(54, 're');

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`id`, `title`) VALUES
(1, 'Green Eggs and Ham'),
(2, 'HTlerktle'),
(3, 'Blah Blah Blah'),
(4, 'sadfasd'),
(5, 'Tes'),
(6, 'fdsfa'),
(7, 'rerer'),
(8, 'dfasdf'),
(9, 'asdlfkj'),
(10, 'Test Book '),
(11, 'werqwfasdf'),
(12, 'sdfasdfas'),
(13, 'sadfasd'),
(14, 'sadfasd'),
(15, 'SDFASDF'),
(16, 'testgttt'),
(17, 'red wagon'),
(18, 'Test Book 100'),
(19, 'FInal Test'),
(20, 'teeeest'),
(21, 'fsdfasdf'),
(22, 'red'),
(23, 'This Is THe New BOok'),
(24, 'Twilight New Moon'),
(25, 'Harry Potter Half Blood Prince'),
(26, 'Clifford'),
(27, 'Testsgtt'),
(28, 'redf'),
(29, 'rewr');

-- --------------------------------------------------------

--
-- Table structure for table `books_authors`
--

CREATE TABLE `books_authors` (
  `id` int(11) NOT NULL,
  `books_Id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `books_authors`
--

INSERT INTO `books_authors` (`id`, `books_Id`, `author_id`) VALUES
(1, 9, 1),
(2, 9, 3),
(3, 10, 1),
(4, 10, 3),
(5, 11, 1),
(6, 11, 3),
(7, 12, 1),
(8, 13, 1),
(9, 14, 1),
(10, 15, 1),
(11, 16, 1),
(12, 16, 30),
(13, 16, 29),
(14, 17, 1),
(15, 17, 32),
(16, 17, 31),
(17, 18, 1),
(18, 18, 34),
(19, 18, 36),
(20, 19, 1),
(21, 19, 3),
(22, 19, 38),
(23, 19, 40),
(24, 20, 1),
(25, 20, 41),
(26, 20, 42),
(27, 21, 0),
(28, 21, 43),
(29, 22, 1),
(30, 22, 3),
(31, 22, 44),
(32, 22, 45),
(33, 23, 1),
(34, 23, 46),
(35, 24, 1),
(36, 24, 3),
(37, 24, 47),
(38, 24, 48),
(39, 24, 49),
(40, 25, 1),
(41, 25, 3),
(42, 25, 50),
(43, 25, 51),
(44, 25, 52),
(45, 26, 1),
(46, 26, 53),
(47, 27, 1),
(48, 27, 54),
(49, 28, 1),
(50, 29, 3);

-- --------------------------------------------------------

--
-- Table structure for table `checkout`
--

CREATE TABLE `checkout` (
  `id` int(11) NOT NULL,
  `copies_Id` int(11) NOT NULL,
  `patrons_id` int(11) NOT NULL,
  `checkout_date` date NOT NULL,
  `due_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `checkout`
--

INSERT INTO `checkout` (`id`, `copies_Id`, `patrons_id`, `checkout_date`, `due_date`) VALUES
(1, 15, 3, '2018-07-18', '0000-00-00'),
(2, 4, 3, '2018-07-18', '0000-00-00'),
(3, 0, 3, '2018-07-18', '0000-00-00'),
(4, 1, 3, '2018-07-18', '0000-00-00'),
(5, 5, 3, '2018-07-18', '0000-00-00'),
(6, 6, 3, '2018-07-18', '0000-00-00'),
(7, 7, 3, '2018-07-18', '0000-00-00'),
(8, 8, 3, '2018-07-18', '0000-00-00'),
(9, 9, 3, '2018-07-18', '0000-00-00'),
(10, 10, 3, '2018-07-18', '0000-00-00'),
(11, 11, 3, '2018-07-19', '0000-00-00'),
(12, 26, 3, '2018-07-19', '0000-00-00'),
(13, 11, 3, '2018-07-19', '0000-00-00'),
(14, 12, 3, '2018-07-19', '0000-00-00'),
(15, 16, 3, '2018-07-19', '0000-00-00'),
(16, 27, 3, '2018-07-19', '0000-00-00'),
(17, 27, 3, '2018-07-19', '0000-00-00'),
(18, 16, 3, '2018-07-19', '0000-00-00'),
(19, 41, 3, '2018-07-19', '0000-00-00'),
(20, 27, 3, '2018-07-19', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `copies`
--

CREATE TABLE `copies` (
  `id` int(11) NOT NULL,
  `books_Id` int(11) NOT NULL,
  `available` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `copies`
--

INSERT INTO `copies` (`id`, `books_Id`, `available`) VALUES
(4, 3, 0),
(6, 4, 0),
(7, 4, 0),
(8, 4, 0),
(9, 4, 0),
(10, 4, 0),
(12, 4, 0),
(13, 4, 1),
(14, 4, 1),
(15, 4, 0),
(16, 23, 1),
(17, 23, 1),
(18, 23, 1),
(19, 23, 1),
(20, 23, 1),
(21, 23, 1),
(22, 23, 1),
(23, 23, 1),
(24, 23, 1),
(25, 23, 1),
(26, 24, 0),
(27, 24, 1),
(30, 24, 1),
(38, 24, 1),
(40, 24, 1),
(41, 25, 1),
(42, 26, 1),
(43, 26, 1),
(44, 26, 1),
(45, 27, 1),
(46, 28, 1),
(47, 29, 1),
(48, 29, 1),
(49, 29, 1),
(50, 29, 1),
(51, 29, 1),
(52, 29, 1),
(53, 29, 1),
(54, 29, 1),
(55, 29, 1),
(56, 29, 1),
(57, 29, 1),
(58, 29, 1);

-- --------------------------------------------------------

--
-- Table structure for table `patrons`
--

CREATE TABLE `patrons` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `patrons`
--

INSERT INTO `patrons` (`id`, `name`) VALUES
(3, 'Joe Smith'),
(4, 'Pamela White'),
(5, 'Ryan Happy'),
(6, 'dfasdf'),
(7, 'fdsf'),
(8, 'Thad');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `books_authors`
--
ALTER TABLE `books_authors`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `checkout`
--
ALTER TABLE `checkout`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `copies`
--
ALTER TABLE `copies`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patrons`
--
ALTER TABLE `patrons`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `authors`
--
ALTER TABLE `authors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT for table `books_authors`
--
ALTER TABLE `books_authors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `checkout`
--
ALTER TABLE `checkout`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `copies`
--
ALTER TABLE `copies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

--
-- AUTO_INCREMENT for table `patrons`
--
ALTER TABLE `patrons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
