-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 20-05-2022 a las 22:46:03
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dbferreteria1975`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `preciosystock`
--

CREATE TABLE `preciosystock` (
  `ID` int(11) NOT NULL,
  `DESCRIPCION` varchar(255) COLLATE utf8_spanish_ci NOT NULL,
  `MICOSTO` decimal(12,2) DEFAULT NULL,
  `$` varchar(3) COLLATE utf8_spanish_ci NOT NULL,
  `STOCK` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `preciosystock`
--

INSERT INTO `preciosystock` (`ID`, `DESCRIPCION`, `MICOSTO`, `$`, `STOCK`) VALUES
(28, '23452', '23452345.00', 'ARS', 5453),
(29, '23452345', '2345245.00', 'ARS', 5453),
(30, 'dasdf', '123.00', 'ARS', 5453),
(31, 'asdf', '4324.00', 'ARS', 5453),
(32, 'sex', '2342343.00', 'ARS', 5453),
(33, 'purpura', '2341231223.00', 'ARS', 5453),
(34, 'a', '34344.00', '', 0),
(37, '1231', '3434.40', 'ARS', 100),
(38, '234', '2334.00', 'ARS', 34231),
(39, '?', '33.00', '', 0),
(40, 'no lie', '18.00', 'USD', 18),
(41, '¿', '0.00', '', 99999),
(42, '1241324', '18.00', 'ARS', 18),
(43, '¿', '897687.80', 'ARS', 99999),
(44, '¿', '897687.80', 'USD', 99999),
(45, '¿', '897687.80', 'USD', 99999),
(47, '¿(/&%$#\"W', '897687.89', 'USD', 99999),
(48, 'detornillador de acero hidraulico con sexo integrado y wos bailandole', '9999999999.99', '', 99999),
(49, 'FDSÑLKJHSDFÑOJSDFHLKJDSHGLKJSDHFLGKJSHDLKFJGHSLDKJFGHSLKDJFHGLKSJDFHGLKJSDFHGLKJSDFHGLIUSDKHGCSIERUYGHVNSDIUFGHVUIRUYIKFNTERSIUYKFNTSECRSIEKUNYCGRFIKNSGUCYERTNIHKSUYCGFERNIKCGHSYURTNGHIUKCSYERNCGHKISUEYRCSGNIKHEUYRSGNEIKCHYUNSGCIKHEYUNSGCKEIYUGUKNCYSIENGK', '9999999999.99', 'ARS', 99999),
(50, '1345234', '1231.00', 'USD', 33),
(51, '1345234', '1231.00', 'USD', 33),
(52, '1345234', '1231.00', 'USD', 33),
(53, '1345234', '1231.00', 'USD', 33),
(54, '1345234', '1231.00', 'USD', 33),
(55, '1345234', '1231.00', 'USD', 33),
(56, '1345234', '1231.00', 'USD', 33),
(57, '1345234', '1231.00', 'USD', 33),
(58, '124234', '32.00', '', 32),
(59, '1345234', '1231.00', 'USD', 33),
(60, '1345234', '1231.00', 'USD', 33),
(61, 'hosdfasd', '33.00', 'USD', 33),
(62, '12312', '24124.00', 'ARS', 18),
(63, '12312', '24124.00', 'ARS', 18),
(64, 'sdafa', '124124.00', '', 99999),
(65, 'sdafa', '124124.00', '', 99999),
(66, 'sdafa', '124124.00', '', 99999),
(67, '23423', '234324.34', '', 234),
(68, '23423', '234324.34', 'ARS', 234),
(69, 'asd', '1242.00', 'ARS', 1242),
(70, 'asd', '1242.00', 'ARS', 1242),
(71, 'fasdgas', '1242.32', 'USD', 21),
(72, 'tornillo x12', '45.50', 'ARS', 51),
(73, '214124', '21234.00', 'ARS', 12345);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `ID` int(11) NOT NULL,
  `usuario` varchar(255) COLLATE utf8_spanish_ci NOT NULL,
  `contraseña` varchar(255) COLLATE utf8_spanish_ci NOT NULL,
  `admin` varchar(2) COLLATE utf8_spanish_ci NOT NULL,
  `nombre` varchar(255) COLLATE utf8_spanish_ci NOT NULL,
  `apellido` varchar(255) COLLATE utf8_spanish_ci NOT NULL,
  `sexo` varchar(25) COLLATE utf8_spanish_ci NOT NULL,
  `dni` int(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`ID`, `usuario`, `contraseña`, `admin`, `nombre`, `apellido`, `sexo`, `dni`) VALUES
(1, 'tronax', 'celeste44', 'si', 'Tomás', 'Mársico', 'Hombre', 44051462),
(2, 'asd', 'asd', '', 'asd', 'asd', 'mujer', 12412412),
(3, 'asd', 'asd412', '', 'asd', 'asd', 'mujer', 12412412),
(4, '123', '123', '', '123', '123', 'hombre', 12123123),
(5, 'javi', 'river2007', '', 'Javier', 'Silva', 'hombre', 34235235);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `preciosystock`
--
ALTER TABLE `preciosystock`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `preciosystock`
--
ALTER TABLE `preciosystock`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=74;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
