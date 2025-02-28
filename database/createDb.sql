CREATE DATABASE IF NOT EXISTS smart_fridge;
USE smart_fridge;

CREATE TABLE role (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE
    description VARCHAR(1000),
);

CREATE TABLE user (
    id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    firstname VARCHAR(100) NOT NULL,
    name VARCHAR(100) NOT NULL,
    role_id INT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES role(id)
);

CREATE TABLE organization (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    address TEXT,
    contact_info VARCHAR(100),
    description TEXT
);

CREATE TABLE user_organization (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    organization_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE,
    FOREIGN KEY (organization_id) REFERENCES organization(id) ON DELETE CASCADE,
    UNIQUE (user_id, organization_id)
);

CREATE TABLE fridge_location (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    address TEXT
);

CREATE TABLE fridge (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    location_id INT NOT NULL,
    FOREIGN KEY (location_id) REFERENCES fridge_location(id)
);

CREATE TABLE user_fridge (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    fridge_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user(id) ON DELETE CASCADE,
    FOREIGN KEY (fridge_id) REFERENCES fridge(id) ON DELETE CASCADE,
    UNIQUE (user_id, fridge_id)
);

CREATE TABLE unit (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL UNIQUE,
    abbreviation VARCHAR(10) NOT NULL UNIQUE
);

CREATE TABLE food (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    ingredient_open_meal_db_name VARCHAR(100)
);

CREATE TABLE fridge_item (
    id INT AUTO_INCREMENT PRIMARY KEY,
    food_id INT NOT NULL,
    quantity_value FLOAT NOT NULL,
    quantity_unit_id INT NOT NULL,
    expiration_date TIMESTAMP,
    fridge_id INT NOT NULL,
    added_by_user_id INT NOT NULL,
    FOREIGN KEY (food_id) REFERENCES food(id),
    FOREIGN KEY (quantity_unit_id) REFERENCES unit(id),
    FOREIGN KEY (fridge_id) REFERENCES fridge(id) ON DELETE CASCADE,
    FOREIGN KEY (added_by_user_id) REFERENCES user(id)
);

CREATE TABLE food_request (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(200) NOT NULL,
    organization_id INT NOT NULL,
    description TEXT,
    deadline_date TIMESTAMP,
    status VARCHAR(50) DEFAULT 'open',
    responsible_user_id INT NOT NULL,
    created_by_user_id INT NOT NULL,
    FOREIGN KEY (organization_id) REFERENCES organization(id),
    FOREIGN KEY (responsible_user_id) REFERENCES user(id),
    FOREIGN KEY (created_by_user_id) REFERENCES user(id)
);

CREATE TABLE food_request_item (
    id INT AUTO_INCREMENT PRIMARY KEY,
    request_id INT NOT NULL,
    food_id INT NOT NULL,
    quantity_value FLOAT NOT NULL,
    quantity_unit_id INT NOT NULL,
    FOREIGN KEY (request_id) REFERENCES food_request(id) ON DELETE CASCADE,
    FOREIGN KEY (food_id) REFERENCES food(id),
    FOREIGN KEY (quantity_unit_id) REFERENCES unit(id)
);

CREATE TABLE request_contribution (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    request_id INT NOT NULL,
    contribution_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    quantity_value FLOAT NOT NULL,
    quantity_unit_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES user(id),
    FOREIGN KEY (request_id) REFERENCES food_request(id) ON DELETE CASCADE,
    FOREIGN KEY (quantity_unit_id) REFERENCES unit(id)
);

CREATE INDEX idx_fridge_item_expiration ON fridge_item(expiration_date);
CREATE INDEX idx_food_request_deadline ON food_request(deadline_date);
CREATE INDEX idx_food_request_status ON food_request(status);