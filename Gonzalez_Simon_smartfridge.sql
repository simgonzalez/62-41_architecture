-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema smart_fridge
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `smart_fridge` DEFAULT CHARACTER SET utf8mb4 ;
USE `smart_fridge` ;

-- -----------------------------------------------------
-- Table `smart_fridge`.`status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`status` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(250) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `smart_fridge`.`addresses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`addresses` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `street_name` VARCHAR(2000) NOT NULL,
  `street_number` VARCHAR(20) NULL DEFAULT NULL,
  `npa` VARCHAR(10) NULL DEFAULT NULL,
  `city` VARCHAR(1000) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`foods`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`foods` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(1000) NOT NULL,
  `ingredient_open_meal_db_name` VARCHAR(1000) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 21
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`organizations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`organizations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(1000) NOT NULL,
  `description` TEXT NULL DEFAULT NULL,
  `address_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `address_id` (`address_id`),
  CONSTRAINT `fk_organizations_addresses`
    FOREIGN KEY (`address_id`)
    REFERENCES `smart_fridge`.`addresses` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`roles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `description` TEXT NULL DEFAULT NULL,
  `code` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `name` (`name`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `email` VARCHAR(1000) NOT NULL,
  `password_hash` VARCHAR(4000) NOT NULL,
  `first_name` VARCHAR(500) NOT NULL,
  `name` VARCHAR(500) NOT NULL,
  `role_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email` (`email`),
  INDEX `role_id` (`role_id`),
  CONSTRAINT `fk_users_roles`
    FOREIGN KEY (`role_id`)
    REFERENCES `smart_fridge`.`roles` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`food_requests`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`food_requests` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(1000) NOT NULL,
  `organization_id` INT NOT NULL,
  `description` TEXT NULL DEFAULT NULL,
  `deadline_date` TIMESTAMP NOT NULL,
  `responsible_user_id` INT NOT NULL,
  `created_by_user_id` INT NOT NULL,
  `status_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `organization_id` (`organization_id`),
  INDEX `responsible_user_id` (`responsible_user_id`),
  INDEX `created_by_user_id` (`created_by_user_id`),
  INDEX `idx_food_request_deadline` (`deadline_date`),
  INDEX `fk_food_request_status1_idx` (`status_id`),
  CONSTRAINT `fk_food_requests_organizations`
    FOREIGN KEY (`organization_id`)
    REFERENCES `smart_fridge`.`organizations` (`id`),
  CONSTRAINT `fk_food_requests_users_responsible`
    FOREIGN KEY (`responsible_user_id`)
    REFERENCES `smart_fridge`.`users` (`id`),
  CONSTRAINT `fk_food_requests_users_created_by`
    FOREIGN KEY (`created_by_user_id`)
    REFERENCES `smart_fridge`.`users` (`id`),
  CONSTRAINT `fk_food_requests_status`
    FOREIGN KEY (`status_id`)
    REFERENCES `smart_fridge`.`status` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`units`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`units` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(20) NOT NULL,
  `abbreviation` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `name` (`name`),
  UNIQUE INDEX `abbreviation` (`abbreviation`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`food_request_items`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`food_request_items` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `request_id` INT NOT NULL,
  `food_id` INT NOT NULL,
  `quantity` FLOAT NOT NULL,
  `quantity_unit_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `request_id` (`request_id`),
  INDEX `food_id` (`food_id`),
  INDEX `quantity_unit_id` (`quantity_unit_id`),
  CONSTRAINT `fk_food_request_items_food_requests`
    FOREIGN KEY (`request_id`)
    REFERENCES `smart_fridge`.`food_requests` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_food_request_items_foods`
    FOREIGN KEY (`food_id`)
    REFERENCES `smart_fridge`.`foods` (`id`),
  CONSTRAINT `fk_food_request_items_units`
    FOREIGN KEY (`quantity_unit_id`)
    REFERENCES `smart_fridge`.`units` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 19
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`fridge_locations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`fridge_locations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`fridges`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`fridges` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(250) NOT NULL,
  `location_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `location_id` (`location_id`),
  CONSTRAINT `fk_fridges_locations`
    FOREIGN KEY (`location_id`)
    REFERENCES `smart_fridge`.`fridge_locations` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`fridge_items`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`fridge_items` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `food_id` INT NOT NULL,
  `quantity` FLOAT NOT NULL,
  `quantity_unit_id` INT NOT NULL,
  `expiration_date` TIMESTAMP NOT NULL,
  `fridge_id` INT NOT NULL,
  `added_by_user_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `food_id` (`food_id`),
  INDEX `quantity_unit_id` (`quantity_unit_id`),
  INDEX `fridge_id` (`fridge_id`),
  INDEX `added_by_user_id` (`added_by_user_id`),
  INDEX `idx_fridge_item_expiration` (`expiration_date`),
  CONSTRAINT `fk_fridge_items_foods`
    FOREIGN KEY (`food_id`)
    REFERENCES `smart_fridge`.`foods` (`id`),
  CONSTRAINT `fk_fridge_items_units`
    FOREIGN KEY (`quantity_unit_id`)
    REFERENCES `smart_fridge`.`units` (`id`),
  CONSTRAINT `fk_fridge_items_fridges`
    FOREIGN KEY (`fridge_id`)
    REFERENCES `smart_fridge`.`fridges` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_fridge_items_users`
    FOREIGN KEY (`added_by_user_id`)
    REFERENCES `smart_fridge`.`users` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 21
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`request_contributions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`request_contributions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `request_id` INT NOT NULL,
  `contribution_date` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `quantity` FLOAT NOT NULL,
  `quantity_unit_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `user_id` (`user_id`),
  INDEX `request_id` (`request_id`),
  INDEX `quantity_unit_id` (`quantity_unit_id`),
  CONSTRAINT `fk_request_contributions_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `smart_fridge`.`users` (`id`),
  CONSTRAINT `fk_request_contributions_food_requests`
    FOREIGN KEY (`request_id`)
    REFERENCES `smart_fridge`.`food_requests` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_request_contributions_units`
    FOREIGN KEY (`quantity_unit_id`)
    REFERENCES `smart_fridge`.`units` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`fridge_user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`fridge_user` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `fridge_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `user_id` (`user_id`, `fridge_id`),
  INDEX `fridge_id` (`fridge_id`),
  CONSTRAINT `fk_fridge_user_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `smart_fridge`.`users` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_fridge_user_fridges`
    FOREIGN KEY (`fridge_id`)
    REFERENCES `smart_fridge`.`fridges` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 18
DEFAULT CHARACTER SET = utf8mb4;

-- -----------------------------------------------------
-- Table `smart_fridge`.`user_organizations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `smart_fridge`.`user_organizations` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `organization_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `user_id` (`user_id`, `organization_id`),
  INDEX `organization_id` (`organization_id`),
  CONSTRAINT `fk_user_organizations_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `smart_fridge`.`users` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_user_organizations_organizations`
    FOREIGN KEY (`organization_id`)
    REFERENCES `smart_fridge`.`organizations` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb4;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;