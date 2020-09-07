CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Bairro` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Descricao` varchar(255) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Bairro` PRIMARY KEY (`Id`)
);

CREATE TABLE `UF` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Descricao` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_UF` PRIMARY KEY (`Id`)
);

CREATE TABLE `Cidade` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UFId` int NOT NULL,
    `Descricao` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Cidade` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Cidade_UF_UFId` FOREIGN KEY (`UFId`) REFERENCES `UF` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Endereco` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CidadeId` int NOT NULL,
    `Numero` longtext CHARACTER SET utf8mb4 NULL,
    `Complemento` longtext CHARACTER SET utf8mb4 NULL,
    `Descricao` longtext CHARACTER SET utf8mb4 NULL,
    `BairroId` int NOT NULL,
    CONSTRAINT `PK_Endereco` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Endereco_Bairro_BairroId` FOREIGN KEY (`BairroId`) REFERENCES `Bairro` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Endereco_Cidade_CidadeId` FOREIGN KEY (`CidadeId`) REFERENCES `Cidade` (`Id`) ON DELETE CASCADE
);

CREATE UNIQUE INDEX `IX_Bairro_Descricao` ON `Bairro` (`Descricao`);

CREATE INDEX `IX_Cidade_UFId` ON `Cidade` (`UFId`);

CREATE INDEX `IX_Endereco_BairroId` ON `Endereco` (`BairroId`);

CREATE INDEX `IX_Endereco_CidadeId` ON `Endereco` (`CidadeId`);

CREATE UNIQUE INDEX `IX_UF_Descricao` ON `UF` (`Descricao`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200906182305_Inicial', '3.1.7');

CREATE TABLE `Disciplina` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Descricao` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Disciplina` PRIMARY KEY (`Id`)
);

CREATE TABLE `Escola` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ConvenioPoderPublico` tinyint(1) NOT NULL,
    `AtendeEducacaoEspecial` tinyint(1) NOT NULL,
    `CategoriaAdministrativa` int NOT NULL,
    `TipoLocalizacao` int NOT NULL,
    CONSTRAINT `PK_Escola` PRIMARY KEY (`Id`)
);

CREATE TABLE `HistoricoStatus` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `IdEscola` int NOT NULL,
    `Status` int NOT NULL,
    `Data` datetime NOT NULL DEFAULT '2020-09-06 20:11:41.804710',
    CONSTRAINT `PK_HistoricoStatus` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_HistoricoStatus_Escola_IdEscola` FOREIGN KEY (`IdEscola`) REFERENCES `Escola` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Modalidade` (
    `IdEscola` int NOT NULL,
    `IdModalidadeEnsino` int NOT NULL,
    `Id` int NOT NULL AUTO_INCREMENT,
    CONSTRAINT `PK_Modalidade` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Modalidade_Escola_IdEscola` FOREIGN KEY (`IdEscola`) REFERENCES `Escola` (`Id`)
);

CREATE TABLE `Telefone` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DDD` int NOT NULL,
    `Numero` int NOT NULL,
    `IdEscola` int NOT NULL,
    CONSTRAINT `PK_Telefone` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Telefone_Escola_IdEscola` FOREIGN KEY (`IdEscola`) REFERENCES `Escola` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Turma` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CodigoPesquisa` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
    `IdEscola` int NOT NULL,
    `HorasAula` int NOT NULL,
    `TotalVagas` int NOT NULL DEFAULT 1,
    `TotalVagasOcupadas` int NOT NULL,
    CONSTRAINT `PK_Turma` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Turma_Escola_IdEscola` FOREIGN KEY (`IdEscola`) REFERENCES `Escola` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `TurmaDisciplina` (
    `IdTurma` int NOT NULL,
    `IdDisciplina` int NOT NULL,
    `Id` int NOT NULL AUTO_INCREMENT,
    `DataVinculacao` datetime NOT NULL,
    `DataModificacao` datetime NOT NULL,
    `Status` int NOT NULL,
    CONSTRAINT `PK_TurmaDisciplina` PRIMARY KEY (`Id`, `IdTurma`, `IdDisciplina`),
    CONSTRAINT `FK_TurmaDisciplina_Disciplina_IdDisciplina` FOREIGN KEY (`IdDisciplina`) REFERENCES `Disciplina` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_TurmaDisciplina_Turma_IdTurma` FOREIGN KEY (`IdTurma`) REFERENCES `Turma` (`Id`) ON DELETE CASCADE
);

CREATE UNIQUE INDEX `IX_Endereco_IdEscola` ON `Endereco` (`IdEscola`);

CREATE UNIQUE INDEX `IX_Disciplina_Descricao` ON `Disciplina` (`Descricao`);

CREATE INDEX `IX_HistoricoStatus_IdEscola` ON `HistoricoStatus` (`IdEscola`);

CREATE INDEX `IX_Telefone_IdEscola` ON `Telefone` (`IdEscola`);

CREATE INDEX `IX_Turma_IdEscola` ON `Turma` (`IdEscola`);

CREATE INDEX `IX_TurmaDisciplina_IdDisciplina` ON `TurmaDisciplina` (`IdDisciplina`);

ALTER TABLE `Endereco` ADD CONSTRAINT `FK_Endereco_Escola_IdEscola` FOREIGN KEY (`IdEscola`) REFERENCES `Escola` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200906231142_MapEscolaAgregados', '3.1.7');

