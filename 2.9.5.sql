-- Création de l'utilisataur
-- GRANT ALL PRIVILEGES ON *.* TO 'userVeloPublic'@'localhost' IDENTIFIED BY PASSWORD '*4B588A2F3AC7203DE962E943AE588FC4CC88DFD3' WITH GRANT OPTION;
GRANT ALL PRIVILEGES ON *.* TO 'userVeloPublic'@'localhost' IDENTIFIED BY PASSWORD '*4B588A2F3AC7203DE962E943AE588FC4CC88DFD3' WITH GRANT OPTION;
-- username : userVeloPublic
-- PASSWORD : userVeloPublic

-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema veloinfospublic
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema veloinfospublic
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `veloinfospublic` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `veloinfospublic` ;

-- -----------------------------------------------------
-- Table `veloinfospublic`.`evenement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veloinfospublic`.`evenement` (
  `idEvenement` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `nom` VARCHAR(50) NULL DEFAULT NULL COMMENT '',
  `date` DATETIME NULL DEFAULT NULL COMMENT '',
  `lieu` VARCHAR(50) NULL DEFAULT NULL COMMENT '',
  PRIMARY KEY (`idEvenement`)  COMMENT '')
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;


-- -----------------------------------------------------
-- Table `veloinfospublic`.`course`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veloinfospublic`.`course` (
  `idCourse` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `evenement_id` INT NOT NULL COMMENT '',
  `estUnDefi` TINYINT(1) NULL COMMENT '',
  `duree` INT NULL COMMENT '',
  PRIMARY KEY (`idCourse`)  COMMENT '',
  INDEX `fk_Course_evenement1_idx` (`evenement_id` ASC)  COMMENT '',
  CONSTRAINT `fk_Course_evenement1`
    FOREIGN KEY (`evenement_id`)
    REFERENCES `veloinfospublic`.`evenement` (`idEvenement`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;


-- -----------------------------------------------------
-- Table `veloinfospublic`.`cycliste`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veloinfospublic`.`cycliste` (
  `idCycliste` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `nom` VARCHAR(25) NULL COMMENT '',
  `prenom` VARCHAR(25) NULL DEFAULT NULL COMMENT '',
  `poids` DOUBLE NULL DEFAULT NULL COMMENT '',
  `course_id` INT NOT NULL COMMENT '',
  PRIMARY KEY (`idCycliste`)  COMMENT '',
  INDEX `fk_cycliste_Course1_idx` (`course_id` ASC)  COMMENT '',
  CONSTRAINT `fk_cycliste_Course1`
    FOREIGN KEY (`course_id`)
    REFERENCES `veloinfospublic`.`course` (`idCourse`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 74
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci
PACK_KEYS = DEFAULT
ROW_FORMAT = DYNAMIC;


-- -----------------------------------------------------
-- Table `veloinfospublic`.`releve`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veloinfospublic`.`releve` (
  `idReleve` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `vitesse` DOUBLE NULL COMMENT '',
  `vitesseMoyenne` DOUBLE NULL COMMENT '',
  `niveauDifficulte` INT NULL COMMENT '',
  `distance` DOUBLE NULL COMMENT '',
  `calories` DOUBLE NULL COMMENT '',
  `productionEnergie` DOUBLE NULL COMMENT '',
  `cycliste_id` INT NOT NULL COMMENT '',
  `temps` INT NULL COMMENT '',
  `puissanceInstantanee` DOUBLE NULL COMMENT '',
  PRIMARY KEY (`idReleve`)  COMMENT '',
  INDEX `fk_Releve_cycliste_idx` (`cycliste_id` ASC)  COMMENT '',
  CONSTRAINT `fk_Releve_cycliste`
    FOREIGN KEY (`cycliste_id`)
    REFERENCES `veloinfospublic`.`cycliste` (`idCycliste`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_general_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
