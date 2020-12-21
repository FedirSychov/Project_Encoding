-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3307
-- Generation Time: Dec 21, 2020 at 04:36 PM
-- Server version: 5.7.24
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `encryptdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `code_keys`
--

CREATE TABLE `code_keys` (
  `id` int(11) NOT NULL,
  `code_key` varchar(145) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `code_keys`
--

INSERT INTO `code_keys` (`id`, `code_key`) VALUES
(10, '6bcpela'),
(11, 'lz5zpy4'),
(12, 're4liad'),
(13, 'itegvkt');

-- --------------------------------------------------------

--
-- Table structure for table `groups`
--

CREATE TABLE `groups` (
  `id` int(11) NOT NULL,
  `name` varchar(145) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `groups`
--

INSERT INTO `groups` (`id`, `name`) VALUES
(1, '19-Кб-ПР1'),
(2, '19-КБ-ПР2'),
(3, '19-КБ-ПИ3');

-- --------------------------------------------------------

--
-- Table structure for table `profiles`
--

CREATE TABLE `profiles` (
  `profile_id` int(11) NOT NULL,
  `login` varchar(245) NOT NULL,
  `password` varchar(245) NOT NULL,
  `role_id` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `profiles`
--

INSERT INTO `profiles` (`profile_id`, `login`, `password`, `role_id`) VALUES
(10, 'Shishkov Danil', 'ce0bfd15059b68d67688884d7a3d3e8c', 0),
(11, 'Sychev Fedor', 'ce0bfd15059b68d67688884d7a3d3e8c', 0),
(12, 'Kovtun Alexander', 'ce0bfd15059b68d67688884d7a3d3e8c', 1),
(13, 'Markov Vitaliy', 'ce0bfd15059b68d67688884d7a3d3e8c', 1);

-- --------------------------------------------------------

--
-- Table structure for table `prof_spec`
--

CREATE TABLE `prof_spec` (
  `id_prof` int(11) NOT NULL,
  `prof_name` varchar(245) NOT NULL,
  `spec_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `prof_spec`
--

INSERT INTO `prof_spec` (`id_prof`, `prof_name`, `spec_id`) VALUES
(1, 'ПРПО', 1);

-- --------------------------------------------------------

--
-- Table structure for table `specs`
--

CREATE TABLE `specs` (
  `spec_id` int(11) NOT NULL,
  `spec_name` varchar(245) NOT NULL,
  `educ_type_id` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specs`
--

INSERT INTO `specs` (`spec_id`, `spec_name`, `educ_type_id`) VALUES
(1, 'Программная инженерия', 1);

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `profile_id` int(11) NOT NULL,
  `name` varchar(245) NOT NULL,
  `surname` varchar(245) NOT NULL,
  `group_id` int(11) NOT NULL,
  `prof_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`profile_id`, `name`, `surname`, `group_id`, `prof_id`) VALUES
(10, 'Danil', 'Shishkov', 1, 1),
(11, 'Fedor', 'Sychev', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `subjects`
--

CREATE TABLE `subjects` (
  `subject_id` int(11) NOT NULL,
  `subject_name` varchar(245) NOT NULL,
  `prof_spec_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `subjects`
--

INSERT INTO `subjects` (`subject_id`, `subject_name`, `prof_spec_id`) VALUES
(1, 'ИТ', 1),
(2, 'Арх. ЭВМ', 1),
(3, 'АСД', 1);

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE `teachers` (
  `profile_id` int(11) NOT NULL,
  `name` varchar(245) NOT NULL,
  `surname` varchar(245) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`profile_id`, `name`, `surname`) VALUES
(12, 'Александр', 'Ковтун'),
(13, 'Виталий', 'Марков');

-- --------------------------------------------------------

--
-- Table structure for table `teacher_subject`
--

CREATE TABLE `teacher_subject` (
  `teacher_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `teacher_subject`
--

INSERT INTO `teacher_subject` (`teacher_id`, `subject_id`) VALUES
(12, 1),
(12, 2),
(13, 3);

-- --------------------------------------------------------

--
-- Table structure for table `users_files`
--

CREATE TABLE `users_files` (
  `id` int(11) NOT NULL,
  `file_name` varchar(245) NOT NULL,
  `file_path` varchar(245) NOT NULL,
  `user_id` int(11) NOT NULL,
  `subject` varchar(245) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `for_teacher_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users_files`
--

INSERT INTO `users_files` (`id`, `file_name`, `file_path`, `user_id`, `subject`, `created_at`, `updated_at`, `for_teacher_id`) VALUES
(35, 'Курсовая работа Сычев Федор.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\Курсовая работа Сычев Федор.sedf', 11, 'АСД', '2020-11-20 16:00:26', '2020-11-20 16:00:26', 13),
(36, 'Курсовая Шишков Данил Программирование.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\Курсовая Шишков Данил Программирование.sedf', 11, 'Програм', '2020-11-20 16:02:32', '2020-11-20 16:02:32', 13),
(37, 'Статья Сычев Федор Распознавание лиц.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\Статья Сычев Федор Распознавание лиц.sedf', 11, 'Програм', '2020-11-20 16:02:42', '2020-11-20 16:02:42', 13),
(38, 'Документ Microsoft Word (3).sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\Документ Microsoft Word (3).sedf', 11, 'АСД', '2020-11-21 10:21:32', '2020-11-21 10:21:32', 13),
(39, 'Курсовая работа Сычев Федор АСД.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\Курсовая работа Сычев Федор АСД.sedf', 11, 'New', '2020-12-09 15:53:55', '2020-12-09 15:53:55', 13),
(40, 'testtttt1.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\testtttt1.sedf', 11, 'New', '2020-12-09 15:54:33', '2020-12-09 15:54:33', 13),
(41, 'New_Downloaded2.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Shishkov Danil\\New_Downloaded2.sedf', 10, 'New', '2020-12-17 07:31:14', '2020-12-17 07:31:14', 13),
(42, 'Курсовая Шишков Данил АСД.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Shishkov Danil\\Курсовая Шишков Данил АСД.sedf', 10, 'АСД', '2020-12-17 07:31:28', '2020-12-17 07:31:28', 13),
(43, 'Отчет по лабораторной работе №7 Кравцов Олег.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\Отчет по лабораторной работе №7 Кравцов Олег.sedf', 11, 'ОС', '2020-12-17 07:54:23', '2020-12-17 07:54:23', 12),
(46, 'Отчет по лабораторной работе №8 Кроавцов Олег.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Shishkov Danil\\Отчет по лабораторной работе №8 Кроавцов Олег.sedf', 10, 'ASD', '2020-12-20 12:53:58', '2020-12-20 12:53:58', 12),
(47, 'Карточка обучающегося Сычев В2.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Shishkov Danil\\Карточка обучающегося Сычев В2.sedf', 10, 'ASD', '2020-12-20 12:54:21', '2020-12-20 12:54:21', 13),
(48, 'Курсовая Сычев Федор ИТ.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\Курсовая Сычев Федор ИТ.sedf', 11, 'ИТ', '2020-12-20 13:11:39', '2020-12-20 13:11:39', 13),
(49, 'Документ Microsoft Word (6) — копия.sedf', 'C:\\Users\\Asus\\Desktop\\Studium\\3 Семестр\\Проект шифрование\\local_data_base\\Sychev Fedor\\Документ Microsoft Word (6) — копия.sedf', 11, 'ИТ', '2020-12-20 13:11:56', '2020-12-20 13:11:56', 12);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `code_keys`
--
ALTER TABLE `code_keys`
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `groups`
--
ALTER TABLE `groups`
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `profiles`
--
ALTER TABLE `profiles`
  ADD UNIQUE KEY `id` (`profile_id`),
  ADD UNIQUE KEY `login` (`login`);

--
-- Indexes for table `prof_spec`
--
ALTER TABLE `prof_spec`
  ADD PRIMARY KEY (`id_prof`),
  ADD KEY `spec_id` (`spec_id`);

--
-- Indexes for table `specs`
--
ALTER TABLE `specs`
  ADD PRIMARY KEY (`spec_id`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD UNIQUE KEY `id` (`profile_id`),
  ADD KEY `group_id` (`group_id`),
  ADD KEY `prof_id_2` (`prof_id`);

--
-- Indexes for table `subjects`
--
ALTER TABLE `subjects`
  ADD UNIQUE KEY `id` (`subject_id`),
  ADD KEY `prof_spec_id` (`prof_spec_id`);

--
-- Indexes for table `teachers`
--
ALTER TABLE `teachers`
  ADD UNIQUE KEY `id` (`profile_id`);

--
-- Indexes for table `teacher_subject`
--
ALTER TABLE `teacher_subject`
  ADD KEY `teacher_id` (`teacher_id`),
  ADD KEY `subject_id` (`subject_id`);

--
-- Indexes for table `users_files`
--
ALTER TABLE `users_files`
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `file_name` (`file_name`),
  ADD KEY `user_id` (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `profiles`
--
ALTER TABLE `profiles`
  MODIFY `profile_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `prof_spec`
--
ALTER TABLE `prof_spec`
  MODIFY `id_prof` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `specs`
--
ALTER TABLE `specs`
  MODIFY `spec_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `subjects`
--
ALTER TABLE `subjects`
  MODIFY `subject_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `users_files`
--
ALTER TABLE `users_files`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `prof_spec`
--
ALTER TABLE `prof_spec`
  ADD CONSTRAINT `prof_spec_ibfk_1` FOREIGN KEY (`spec_id`) REFERENCES `specs` (`spec_id`);

--
-- Constraints for table `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `students_ibfk_1` FOREIGN KEY (`profile_id`) REFERENCES `profiles` (`profile_id`),
  ADD CONSTRAINT `students_ibfk_2` FOREIGN KEY (`group_id`) REFERENCES `groups` (`id`),
  ADD CONSTRAINT `students_ibfk_3` FOREIGN KEY (`prof_id`) REFERENCES `prof_spec` (`id_prof`);

--
-- Constraints for table `subjects`
--
ALTER TABLE `subjects`
  ADD CONSTRAINT `subjects_ibfk_1` FOREIGN KEY (`prof_spec_id`) REFERENCES `prof_spec` (`id_prof`);

--
-- Constraints for table `teachers`
--
ALTER TABLE `teachers`
  ADD CONSTRAINT `teachers_ibfk_1` FOREIGN KEY (`profile_id`) REFERENCES `profiles` (`profile_id`);

--
-- Constraints for table `teacher_subject`
--
ALTER TABLE `teacher_subject`
  ADD CONSTRAINT `teacher_subject_ibfk_1` FOREIGN KEY (`teacher_id`) REFERENCES `teachers` (`profile_id`),
  ADD CONSTRAINT `teacher_subject_ibfk_2` FOREIGN KEY (`subject_id`) REFERENCES `subjects` (`subject_id`);

--
-- Constraints for table `users_files`
--
ALTER TABLE `users_files`
  ADD CONSTRAINT `users_files_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `profiles` (`profile_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
