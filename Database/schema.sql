CREATE DATABASE funcionarioDB;

USE funcionarioDB;

CREATE TABLE `Funcionarios` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Nome` longtext CHARACTER
  SET
    utf8mb4 COLLATE utf8mb4_0900_ai_ci,
    `Sobrenome` longtext CHARACTER
  SET
    utf8mb4 COLLATE utf8mb4_0900_ai_ci,
    `Documento` longtext CHARACTER
  SET
    utf8mb4 COLLATE utf8mb4_0900_ai_ci,
    `Setor` longtext CHARACTER
  SET
    utf8mb4 COLLATE utf8mb4_0900_ai_ci,
    `SalarioBruto` double NOT NULL,
    `DataAdmissao` datetime(6) NOT NULL,
    `HasPlanoSaude` tinyint(1) NOT NULL,
    `HasPlanoDental` tinyint(1) NOT NULL,
    `HasValeTransporte` tinyint(1) NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;