-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 06/11/2024 às 18:55
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.1.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `simple_shopping_cart_db`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `customers`
--

CREATE TABLE `customers` (
  `id` int(10) NOT NULL,
  `guid` varchar(50) NOT NULL,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone` varchar(30) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `customers`
--

INSERT INTO `customers` (`id`, `guid`, `name`, `email`, `phone`, `created_at`, `updated_at`) VALUES
(1, 'cb5b9bf6-1528-4b03-be4d-ada94d92e748', 'Augusto Campos', 'augustocampos@gmail.com', '11933446464', '2024-10-29 22:33:27', '2024-10-29 22:33:27'),
(3, '20cd78d0-4bd1-44d4-8a6c-4e084b774edf', 'Fulano de Taus 2001', 'finalodetaus1@gmail.com', '11933444545', '2024-10-30 13:48:31', '2024-10-30 13:48:31'),
(5, 'c25db989-ca5f-4704-8ffc-ba0c2664f752', 'Fulano de Taus 2002', 'finalodetaus2@gmail.com', '11933444545', '2024-10-30 14:07:29', '2024-10-30 14:07:29'),
(6, '8dab4177-c049-491a-b4eb-469f50fa1bd1', 'Fulano de Taus 2002', 'finalodetaus2@gmail.com', '11933444545', '2024-10-30 14:22:29', '2024-10-30 14:22:29'),
(7, '82cedd6d-e410-4a76-8fb2-468642605393', 'Fulano de Taus 2002', 'finalodetaus2@gmail.com', '11933444545', '2024-10-30 14:25:29', '2024-10-30 14:25:29'),
(8, 'f2c12611-204a-4c5b-b95c-a8bb34b4d0d4', 'Fulano de Taus 2002', 'finalodetaus2@gmail.com', '11933444545', '2024-11-04 20:32:36', '2024-11-04 20:32:36');

-- --------------------------------------------------------

--
-- Estrutura para tabela `orders`
--

CREATE TABLE `orders` (
  `id` int(10) NOT NULL,
  `guid` varchar(50) NOT NULL,
  `customer_id` int(10) NOT NULL,
  `total_price` decimal(10,2) NOT NULL,
  `status` int(1) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `orders`
--

INSERT INTO `orders` (`id`, `guid`, `customer_id`, `total_price`, `status`, `created_at`, `updated_at`) VALUES
(1, '7d2f5fd2-c9ae-478a-a887-d095f6aebdf0', 1, 5000.00, 1, '2024-10-30 18:58:00', '2024-10-30 18:58:00'),
(3, '0f0b8c15-7bec-4532-b144-a63b4e50da22', 3, 9999.99, 3, '2024-10-30 18:59:06', '2024-10-30 19:02:08'),
(5, '8c4afd00-ef94-4c9e-8237-94db16e7089c', 3, 9999.99, 2, '2024-10-30 19:04:30', '2024-10-30 19:04:30'),
(6, 'fb973dca-f46e-4c3b-b04d-3bac36bf66e2', 3, 9999.99, 2, '2024-10-30 19:05:16', '2024-10-30 19:05:16'),
(7, '9ef5e60c-0c98-4cd5-b834-653c7764a31d', 3, 1000000.00, 3, '2024-10-30 19:05:26', '2024-11-04 21:16:25'),
(8, 'c124f1de-0734-4d3f-9cda-159d9099ce9d', 3, 7000.00, 2, '2024-11-04 20:32:53', '2024-11-04 20:32:53'),
(9, 'ed2483a1-af89-4bdd-ad03-726e64af363b', 8, 7000.00, 2, '2024-11-04 20:43:58', '2024-11-04 20:43:58'),
(13, 'd43872c1-0684-4f24-9162-b4fd1423d566', 8, 7000.00, 2, '2024-11-04 21:10:46', '2024-11-04 21:10:46');

-- --------------------------------------------------------

--
-- Estrutura para tabela `orders_products`
--

CREATE TABLE `orders_products` (
  `id` int(10) NOT NULL,
  `guid` varchar(50) NOT NULL,
  `order_id` int(10) NOT NULL,
  `product_id` int(10) NOT NULL,
  `quantity` int(10) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `orders_products`
--

INSERT INTO `orders_products` (`id`, `guid`, `order_id`, `product_id`, `quantity`, `price`, `created_at`, `updated_at`) VALUES
(2, 'd1458968-871f-4d6d-8134-d8ced1293e3f', 1, 4, 2, 2000.00, '2024-10-30 19:48:19', '2024-10-30 19:48:19'),
(3, '7322f43d-ccc9-4f79-a70c-dc74a30788ad', 1, 5, 10, 2000.00, '2024-10-30 19:48:31', '2024-10-30 19:48:31'),
(5, 'f55de547-9742-436b-addc-ebb1b56925ff', 3, 5, 999, 2999.00, '2024-11-04 20:33:12', '2024-11-04 20:35:51'),
(6, 'd67d0e71-0ad0-444f-84d4-dc7bbb792519', 1, 5, 99, 2000.00, '2024-11-04 21:26:30', '2024-11-04 21:26:30'),
(7, '96b3116b-2a84-478d-a863-33e1efe24fa8', 1, 5, 99, 2000.00, '2024-11-04 21:26:55', '2024-11-04 21:26:55');

-- --------------------------------------------------------

--
-- Estrutura para tabela `products`
--

CREATE TABLE `products` (
  `id` int(10) NOT NULL,
  `guid` varchar(50) NOT NULL,
  `title` varchar(200) NOT NULL,
  `description` text NOT NULL,
  `price` decimal(6,2) NOT NULL,
  `created_at` datetime NOT NULL,
  `updated_at` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `products`
--

INSERT INTO `products` (`id`, `guid`, `title`, `description`, `price`, `created_at`, `updated_at`) VALUES
(4, 'f8a10e9c-7fa2-4160-9531-c5f9f8e250dd', 'Nintendo Switch Oled', 'Nintendo Switch Oled Description', 2289.99, '2024-10-30 15:01:22', '2024-10-30 15:01:22'),
(5, '0d4476fb-88e1-4ad1-8a5b-e6dfca205053', 'XBox series S', 'XBox series S descrição', 2499.99, '2024-10-30 18:23:56', '2024-10-30 18:23:56'),
(7, 'd07bd9b1-421d-4074-8b58-c4a4c40abe09', 'XBox series S Updated', 'XBox series S descrição Updated', 2799.99, '2024-10-30 18:26:28', '2024-11-04 20:33:48'),
(8, 'e7036d4a-b968-4a57-978a-9e680dd10b93', 'XBox series S 3', 'XBox series S descrição', 2499.99, '2024-10-31 15:07:09', '2024-10-31 15:07:09'),
(9, 'a892b006-e94c-4122-9190-bb8a51639438', 'XBox series S 3', 'XBox series S descrição', 2499.99, '2024-11-04 20:20:47', '2024-11-04 20:20:47'),
(10, 'e07d0c04-839d-4854-860f-ea9e6d9feed5', 'XBox series S 3', 'XBox series S descrição', 2499.99, '2024-11-04 20:21:07', '2024-11-04 20:21:07'),
(11, 'b32da513-52ab-4d23-8ac0-316268ba1a6d', 'XBox series S 3', 'XBox series S descrição', 2499.99, '2024-11-04 20:22:54', '2024-11-04 20:22:54');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `customers_guid` (`guid`);

--
-- Índices de tabela `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `orders_guid` (`guid`),
  ADD KEY `fk_orders_customers` (`customer_id`);

--
-- Índices de tabela `orders_products`
--
ALTER TABLE `orders_products`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `orders_products_guid` (`guid`),
  ADD KEY `fk_orders_products_product_id` (`product_id`),
  ADD KEY `fk_orders_products_order_id` (`order_id`);

--
-- Índices de tabela `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `products_guid` (`guid`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de tabela `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de tabela `orders_products`
--
ALTER TABLE `orders_products`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `products`
--
ALTER TABLE `products`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `fk_orders_customers` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`);

--
-- Restrições para tabelas `orders_products`
--
ALTER TABLE `orders_products`
  ADD CONSTRAINT `fk_orders_products_order_id` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`),
  ADD CONSTRAINT `fk_orders_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
