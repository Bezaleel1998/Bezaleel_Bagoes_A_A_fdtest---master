-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 25, 2025 at 06:43 AM
-- Server version: 10.11.9-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bezaleel_bagoes_a_a_fdtest`
--

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `book_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `author` varchar(255) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `thumbnail_url` varchar(255) DEFAULT NULL,
  `rating` float DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`book_id`, `user_id`, `title`, `author`, `description`, `thumbnail_url`, `rating`, `created_at`) VALUES
(12, 18, 'The Road', 'Cormac McCarthy', 'Post-apocalyptic survival story.', 'https://covers.openlibrary.org/b/id/8231996-L.jpg', 5, '2025-06-24 11:47:45'),
(13, 19, 'The Pragmatic Programmer', 'Andrew Hunt', 'A guide to software craftsmanship.', 'https://images-na.ssl-images-amazon.com/images/I/41as+WafrFL._SX342_SY445_QL70_ML2_.jpg', 5, '2025-06-24 11:47:45'),
(14, 20, 'Brave New World', 'Aldous Huxley', 'A dystopian view of the future.', 'https://covers.openlibrary.org/b/id/8775737-L.jpg', 4, '2025-06-24 11:47:45'),
(15, 21, 'Thinking in Systems', 'Donella Meadows', 'Systems thinking explained clearly.', 'https://images-na.ssl-images-amazon.com/images/I/81cpDaCJJCL.jpg', 5, '2025-06-24 11:47:45'),
(16, 22, 'To Kill a Mockingbird', 'Harper Lee', 'A novel about racial injustice.', 'https://covers.openlibrary.org/b/id/8228691-L.jpg', 5, '2025-06-24 11:47:45'),
(17, 23, 'Dune', 'Frank Herbert', 'Science fiction epic on a desert planet.', 'https://covers.openlibrary.org/b/id/8101355-L.jpg', 5, '2025-06-24 11:47:45'),
(18, 24, 'The Catcher in the Rye', 'J.D. Salinger', 'A teenager’s view on the adult world.', 'https://covers.openlibrary.org/b/id/8225631-L.jpg', 4, '2025-06-24 11:47:45'),
(19, 25, 'Shoe Dog', 'Phil Knight', 'Memoir by the founder of Nike.', 'https://images-na.ssl-images-amazon.com/images/I/41kLrZzG+sL._SX329_BO1,204,203,200_.jpg', 4, '2025-06-24 11:47:45'),
(20, 26, 'The Design of Everyday Things', 'Don Norman', 'Why good design is essential.', 'https://images-na.ssl-images-amazon.com/images/I/81zpLhP1gWL.jpg', 5, '2025-06-24 11:47:45'),
(21, 27, 'Deep Work', 'Cal Newport', 'How to focus in a distracted world.', 'https://images-na.ssl-images-amazon.com/images/I/71HMyqG6MRL.jpg', 4, '2025-06-24 11:47:45'),
(22, 28, 'Grit', 'Angela Duckworth', 'Power of passion and perseverance.', 'https://images-na.ssl-images-amazon.com/images/I/71aG+xDKSYL.jpg', 5, '2025-06-24 11:47:45'),
(24, 18, 'Outliers', 'Malcolm Gladwell', 'The story of success.', 'https://images-na.ssl-images-amazon.com/images/I/71HMyqG6MRL.jpg', 4, '2025-06-24 11:47:45'),
(25, 19, 'The War of Art', 'Steven Pressfield', 'Overcoming resistance.', 'https://images-na.ssl-images-amazon.com/images/I/71cHn1xXxwL.jpg', 5, '2025-06-24 11:47:45'),
(26, 20, 'Start With Why', 'Simon Sinek', 'Inspiring leaders start with why.', 'https://images-na.ssl-images-amazon.com/images/I/81N7FmJhbhL.jpg', 5, '2025-06-24 11:47:45'),
(27, 21, 'The Subtle Art of Not Giving a F*ck', 'Mark Manson', 'A counterintuitive approach to living well.', 'https://images-na.ssl-images-amazon.com/images/I/71QKQ9mwV7L.jpg', 4, '2025-06-24 11:47:45'),
(28, 22, 'Educated', 'Tara Westover', 'A memoir of transformation.', 'https://images-na.ssl-images-amazon.com/images/I/81WojUxbbFL.jpg', 5, '2025-06-24 11:47:45'),
(29, 23, '1984', 'George Orwell', 'Totalitarianism and surveillance.', 'https://covers.openlibrary.org/b/id/7222246-L.jpg', 5, '2025-06-24 11:47:45'),
(30, 24, 'The Lean Startup', 'Eric Ries', 'Build, measure, learn.', 'https://images-na.ssl-images-amazon.com/images/I/81-QB7nDh4L.jpg', 4, '2025-06-24 11:47:45'),
(31, 1, 'Game Development with Unity', 'Michelle Menard', 'GAME DEVELOPMENT WITH UNITY shows you how to use the Unity game engine, a multiplatform engine and editor in one, to build games that can be played on just about any platform available, from the web to the Wii and even on smartphones.', 'https://m.media-amazon.com/images/I/71O0CKQVUwL._SL1434_.jpg', 3.6, '2025-06-24 14:43:29'),
(32, 1, 'Unity for Absolute Beginners', 'Sue Blackman', 'Unity for Absolute Beginners walks you through the fundamentals of creating a small third-person shooter game with Unity.\r\nUsing the free version of Unity to begin your game development career, you\'ll learn how to import, evaluate and manage your game resources to create awesome third-person shooters.\r\nThis book assumes that you have little or no experience with game development, scripting, or 3D assets, and that you\'re eager to start creating games as quickly as possible, while learning Unity in a fun and interactive environment.', 'https://media.springernature.com/full/springer-static/cover-hires/book/978-1-4302-6778-2?as=webp', 3.7, '2025-06-24 14:51:13'),
(33, 1, 'Game Programming with Unity and C#: A Complete Beginner\'s Guide', 'Casey Hardman', '​Designed for beginners with no knowledge or experience in game development or programming, this book teaches the essentials of the Unity game engine, the C# programming language, and the art of object-oriented programming. New concepts are not only explained, but thoroughly demonstrated.', 'https://m.media-amazon.com/images/I/61Snx+TPvAL._SL1181_.jpg', 3.8, '2025-06-24 14:52:21'),
(34, 29, 'SukaSuka Suka Suka WorldEnd Shuumatsu Nani Shitemasu Ka? Isogashii Desu Ka? Sukutte Moratte Ii Desu Ka?', 'Akira Kareno', 'Five hundred years have passed since the humans went extinct at the hands of the fearsome and mysterious \'Beasts.\' The surviving races now make their homes up on floating islands in the sky, out of reach of all, but the most mobile of Beasts. However, this new safe haven Règles Aile has a dark secret behind it. In order to defeat the Beasts, only a small group of young girls, the Leprechauns, can wield the ancient Dug Weapons needed to fend off invasions from these creatures.', 'https://m.media-amazon.com/images/I/81Iaw9unPJL._SL1500_.jpg', 3.7, '2025-06-24 21:58:12'),
(36, 29, 'Rokka no Yuusha', 'Ishio Yamagata', 'Six people called the Braves of the Six Flowers are chosen by the Goddess of Fate to defeat the Demon God (魔神, Majin). However, when they gather, there are seven heroes present, leading them to believe that one is an impostor and on the side of the Demon God. The landscape, architecture, and written language portrayed is very similar to Mesoamerican Maya or Aztec peoples.', 'https://upload.wikimedia.org/wikipedia/en/4/4c/Rokka_no_Y%C5%ABsha_light_novel_volume_1_cover.jpg', 3.7, '2025-06-24 22:02:16'),
(37, 29, 'If It\'s for My Daughter, I\'d Even Defeat a Demon Lord', 'Chirolu', 'If It\'s for My Daughter, I\'d Even Defeat a Demon Lord (うちの娘の為ならば、俺はもしかしたら魔王も倒せるかもしれない。, Uchi no Ko no Tame Naraba, Ore wa Moshikashitara Maō mo Taoseru Kamoshirenai.) is a Japanese light novel series written by Chirolu and initially illustrated by Truffle until volume 2 where Kei assumed the illustration of the series. It began serialization online in August 2014 on the user-generated novel publishing website Shōsetsuka ni Narō. It was later acquired by Hobby Japan, which has published nine volumes since February 2015 under their HJ Novels imprint. The series is published in English by J-Novel Club.\r\n\r\nPlot : \r\n\r\nDale is a highly skilled adventurer who has made quite a name for himself despite his youth. One day on a job deep in the forest, he comes across a little devil girl named Latina who has almost wasted away. Unable to just leave her there to die, Dale takes her home and becomes her adoptive father.', 'https://upload.wikimedia.org/wikipedia/en/0/0c/If_It%27s_for_My_Daughter%2C_I%27d_Even_Defeat_a_Demon_Lord_light_novel_volume_1_cover.jpg', 4, '2025-06-24 22:04:16'),
(38, 29, 'My Youth Romantic Comedy Is Wrong, as I Expected', 'Wataru Watari', 'The story follows two loners, the pragmatic Hachiman Hikigaya and beautiful Yukino Yukinoshita, who despite their varying personalities and ideals, offer help and advice to others as part of their school\'s Service Club, assisted by the cheerful and friendly Yui Yuigahama. It largely depicts various social situations faced by teens in a high school setting and the psychology driving their interactions.', 'https://upload.wikimedia.org/wikipedia/en/c/ca/My_Teen_Romantic_Comedy_SNAFU_cover.jpg', 4, '2025-06-24 22:09:22'),
(40, 29, 'Reincarnated as a Sword (転生したら剣でした Tensei Shitara Ken Deshita)', 'Yuu Tanaka', 'I opened my eyes to find myself in another world. For some odd reason, I ended up as a sword. Before my eyes laid a plain full of magic beasts, and so, I launched my body and flew in search of a partner, a wielder (females only).\r\n\r\nWait. Absorbing magic stones gets me skills? Oh hell yeah! This be fun! More, more, give me more! Gimme all your magic stones! Okay, yeah no , but I am accepting anything anyone’s willing to give.\r\n\r\nThis tale is one that follows your everyday nerd, normal as could be, save for the fact that he happened to reincarnate as a sword.', 'https://m.media-amazon.com/images/I/91NPGOoMltL._SL1500_.jpg', 4.5, '2025-06-25 11:39:44');

-- --------------------------------------------------------

--
-- Table structure for table `email_verifications`
--

CREATE TABLE `email_verifications` (
  `verification_id` varchar(36) NOT NULL,
  `user_id` int(11) NOT NULL,
  `token` varchar(100) NOT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `expires_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `password_reset_requests`
--

CREATE TABLE `password_reset_requests` (
  `request_id` varchar(36) NOT NULL,
  `user_id` int(11) NOT NULL,
  `token` varchar(100) NOT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `expires_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `password_reset_requests`
--

INSERT INTO `password_reset_requests` (`request_id`, `user_id`, `token`, `created_at`, `expires_at`) VALUES
('087776e6-74bb-4ed8-9d02-fe01e811cf48', 1, 'd49aa3d0-1261-4d49-9491-58fd5435b1bc', '2025-06-24 19:56:54', '2025-06-24 20:11:54'),
('24a746ca-369a-4d1a-ad35-ade6594d3bc0', 1, '8570c15c-439e-4030-9d13-9b1854af4366', '2025-06-24 23:55:17', '2025-06-25 00:10:17'),
('2679629a-8a98-461e-8357-bfee426cbb4d', 1, '26d49aea-f828-4135-a1be-74ca9be09141', '2025-06-24 23:49:46', '2025-06-25 00:04:46'),
('499258ad-886c-4d14-9010-6f90aa3dc18c', 29, '1b8169c3-4f27-480d-8a8d-fab670b484ae', '2025-06-24 23:48:55', '2025-06-25 00:03:55'),
('68dced4a-01ee-40f5-99de-2187fb5d2c87', 1, '65148be2-923d-4d9e-b681-c21daf7b6f4e', '2025-06-25 00:07:51', '2025-06-25 00:22:51'),
('a3d82744-6e6c-49d6-8843-67773392f455', 1, '28d1e25a-8c08-41f5-8f44-7be02a01710a', '2025-06-24 23:48:23', '2025-06-25 00:03:23'),
('c1ea174c-bbfe-4c1d-8333-25e5f78c79fb', 29, '3a0bd133-7649-4f6a-a55b-f36915025f74', '2025-06-24 23:51:20', '2025-06-25 00:06:20'),
('dd184a82-6cd8-44cf-b55d-56bc999833fc', 1, '02e3f7f5-c268-4b90-afe4-a60102873311', '2025-06-24 23:49:23', '2025-06-25 00:04:23'),
('fe65f20d-b142-405a-8504-bed627544715', 29, 'e4698188-8204-4da6-94a5-1b600aa53dd6', '2025-06-24 23:49:08', '2025-06-25 00:04:08');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `email` varchar(255) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `is_email_verified` tinyint(1) DEFAULT 0,
  `created_at` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `name`, `email`, `password_hash`, `is_email_verified`, `created_at`) VALUES
(1, 'Bezaleel', 'bezaleelbagoes@gmail.com', 'xZS6UKadRiZgGv73mCiqi+PtNkJPWdE7V+31B/N0Rb0=', 1, '2025-06-23 16:45:36'),
(18, 'Miller', 'jbmiller11031998@gmail.com', 'MJiGjkYn1ENhos9Ww+sxk8z0ira46lUdklE20n9FJKg=', 1, '2025-06-23 19:42:10'),
(19, 'Alice Johnson', 'alice@example.com', 'hashed_pw_1', 1, '2025-06-24 10:49:41'),
(20, 'Bob Smith', 'bob@example.com', 'hashed_pw_2', 0, '2025-06-24 10:49:41'),
(21, 'Charlie Brown', 'charlie@example.com', 'hashed_pw_3', 1, '2025-06-24 10:49:41'),
(22, 'Diana Prince', 'diana@example.com', 'hashed_pw_4', 1, '2025-06-24 10:49:41'),
(23, 'Evan Peters', 'evan@example.com', 'hashed_pw_5', 0, '2025-06-24 10:49:41'),
(24, 'Fiona Glenanne', 'fiona@example.com', 'hashed_pw_6', 1, '2025-06-24 10:49:41'),
(25, 'George Hall', 'george@example.com', 'hashed_pw_7', 1, '2025-06-24 10:49:41'),
(26, 'Hannah Lee', 'hannah@example.com', 'hashed_pw_8', 0, '2025-06-24 10:49:41'),
(27, 'Ian Somerhalder', 'ian@example.com', 'hashed_pw_9', 1, '2025-06-24 10:49:41'),
(28, 'Julia Roberts', 'julia@example.com', 'hashed_pw_10', 1, '2025-06-24 10:49:41'),
(29, 'JohnMiller', 'captainmillerbigredone@gmail.com', 'SRMS8s4vDQXMiCGVajQThCinLWy/PkJu9rzIfykFthQ=', 1, '2025-06-24 21:54:50'),
(30, 'Sugar Charlie', 'Aloha@gmail.com', 'ZehL4zUy+3hMSBKWdfnv86aCsnFowOp0Syz1juAjN8U=', 1, '2025-06-25 00:08:25');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`book_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `email_verifications`
--
ALTER TABLE `email_verifications`
  ADD PRIMARY KEY (`verification_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `password_reset_requests`
--
ALTER TABLE `password_reset_requests`
  ADD PRIMARY KEY (`request_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `book_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `books`
--
ALTER TABLE `books`
  ADD CONSTRAINT `books_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE;

--
-- Constraints for table `email_verifications`
--
ALTER TABLE `email_verifications`
  ADD CONSTRAINT `email_verifications_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE;

--
-- Constraints for table `password_reset_requests`
--
ALTER TABLE `password_reset_requests`
  ADD CONSTRAINT `password_reset_requests_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
