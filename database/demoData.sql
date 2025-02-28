USE smart_fridge;

-- Insert roles
INSERT INTO role (name, permissions) VALUES
('admin', '{"all": true}'),
('manager', '{"manage_fridges": true, "manage_food": true}'),
('user', '{"view": true, "add_food": true}'),
('guest', '{"view": true}');

-- Insert users
INSERT INTO user (email, password_hash, display_name, role_id) VALUES
('admin@smartfridge.com', '$2a$12$1234567890123456789012uqgOQjiLiEMZ3Yh6IkMk5yvnQxy5tK6', 'Admin User', 1),
('john.doe@example.com', '$2a$12$1234567890123456789012uhGzthG5wXMqvyfBGPR7c1crLpGDdUW', 'John Doe', 2),
('jane.smith@example.com', '$2a$12$1234567890123456789012uw1GDn0k1PylYWBWz3cmTQ4mSczPNg9K', 'Jane Smith', 2),
('bob.wilson@example.com', '$2a$12$1234567890123456789012uQgPrf0AmIjAXw6LVaGOELVX3eJnkTim', 'Bob Wilson', 3),
('alice.johnson@example.com', '$2a$12$1234567890123456789012uq86y1JuV5flHRjQvHXjmKkTGdQyRC2', 'Alice Johnson', 3),
('guest@smartfridge.com', '$2a$12$1234567890123456789012uYtkjKHYdKJA4wHFhKF2xeFJ5wFyG1O', 'Guest User', 4);

-- Insert organizations
INSERT INTO organization (name, address, contact_info, description) VALUES
('Community Kitchen', '123 Main St, Anytown, USA', 'contact@communitykitchen.org', 'Serving the local community with fresh food'),
('Food Bank Central', '456 Oak Ave, Springfield, USA', 'info@foodbankcentral.org', 'Collecting and distributing food for those in need'),
('Campus Dining Hall', 'University Campus, College Town, USA', 'dining@university.edu', 'Providing meals for students and faculty'),
('Senior Center', '789 Elder St, Retirement City, USA', 'info@seniorcenter.org', 'Supporting healthy eating for seniors');

-- Insert user_organization relationships
INSERT INTO user_organization (user_id, organization_id) VALUES
(1, 1), (1, 2),
(2, 1), (2, 3),
(3, 2), (3, 4),
(4, 3),
(5, 4),
(6, 1);

-- Insert fridge locations
INSERT INTO fridge_location (name, address) VALUES
('Main Kitchen', '123 Main St, Anytown, USA'),
('Campus Center', 'University Campus, College Town, USA'),
('Senior Center', '789 Elder St, Retirement City, USA'),
('Food Bank Warehouse', '456 Oak Ave, Springfield, USA'),
('Community Center', '101 Community Blvd, Anytown, USA');

-- Insert fridges
INSERT INTO fridge (name, location_id) VALUES
('Main Kitchen Fridge 1', 1),
('Main Kitchen Fridge 2', 1),
('Campus Center Fridge', 2),
('Senior Center Fridge', 3),
('Food Bank Fridge 1', 4),
('Food Bank Fridge 2', 4),
('Community Center Fridge', 5);

-- Insert user_fridge relationships
INSERT INTO user_fridge (user_id, fridge_id) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7),
(2, 1), (2, 2), (2, 3),
(3, 4), (3, 5), (3, 6),
(4, 3), (4, 7),
(5, 4), (5, 7),
(6, 7);

-- Insert units
INSERT INTO unit (name, abbreviation) VALUES
('Piece', 'pc'),
('Kilogram', 'kg'),
('Liter', 'L');

-- Insert food items
INSERT INTO food (name, ingredient_open_meal_db_name) VALUES
('Milk', 'Milk'),
('Eggs', 'Eggs'),
('Chicken Breast', 'Chicken Breast'),
('Ground Beef', 'Ground Beef'),
('Tomatoes', 'Tomato'),
('Lettuce', 'Lettuce'),
('Bread', 'Bread'),
('Cheese', 'Cheese'),
('Yogurt', 'Yogurt'),
('Apples', 'Apple'),
('Bananas', 'Banana'),
('Pasta', 'Pasta'),
('Rice', 'Rice'),
('Beans', 'Beans'),
('Onions', 'Onion'),
('Carrots', 'Carrot'),
('Potatoes', 'Potato'),
('Orange Juice', 'Orange Juice'),
('Butter', 'Butter'),
('Flour', 'Flour');

-- Insert fridge items
INSERT INTO fridge_item (food_id, quantity_value, quantity_unit_id, expiration_date, fridge_id, added_by_user_id) VALUES
(1, 1, 3, DATE_ADD(CURRENT_DATE(), INTERVAL 7 DAY), 1, 2),
(2, 12, 5, DATE_ADD(CURRENT_DATE(), INTERVAL 14 DAY), 1, 2),
(3, 500, 2, DATE_ADD(CURRENT_DATE(), INTERVAL 3 DAY), 1, 2),
(4, 1, 1, DATE_ADD(CURRENT_DATE(), INTERVAL 2 DAY), 2, 2),
(5, 6, 5, DATE_ADD(CURRENT_DATE(), INTERVAL 5 DAY), 2, 1),
(6, 1, 5, DATE_ADD(CURRENT_DATE(), INTERVAL 4 DAY), 3, 4),
(7, 2, 6, DATE_ADD(CURRENT_DATE(), INTERVAL 7 DAY), 3, 4),
(8, 300, 2, DATE_ADD(CURRENT_DATE(), INTERVAL 10 DAY), 4, 5),
(9, 500, 2, DATE_ADD(CURRENT_DATE(), INTERVAL 8 DAY), 4, 5),
(10, 10, 5, DATE_ADD(CURRENT_DATE(), INTERVAL 14 DAY), 5, 3),
(11, 8, 5, DATE_ADD(CURRENT_DATE(), INTERVAL 5 DAY), 5, 3),
(12, 3, 6, DATE_ADD(CURRENT_DATE(), INTERVAL 60 DAY), 6, 3),
(13, 2, 1, DATE_ADD(CURRENT_DATE(), INTERVAL 180 DAY), 6, 1),
(14, 4, 7, DATE_ADD(CURRENT_DATE(), INTERVAL 365 DAY), 7, 4),
(15, 5, 5, DATE_ADD(CURRENT_DATE(), INTERVAL 14 DAY), 7, 5),
(16, 1, 1, DATE_ADD(CURRENT_DATE(), INTERVAL 21 DAY), 1, 1),
(17, 2, 1, DATE_ADD(CURRENT_DATE(), INTERVAL 30 DAY), 2, 2),
(18, 2, 3, DATE_ADD(CURRENT_DATE(), INTERVAL 7 DAY), 3, 4),
(19, 250, 2, DATE_ADD(CURRENT_DATE(), INTERVAL 14 DAY), 4, 3),
(20, 1, 1, DATE_ADD(CURRENT_DATE(), INTERVAL 180 DAY), 5, 3);

-- Insert food requests
INSERT INTO food_request (title, organization_id, description, deadline_date, status, responsible_user_id, created_by_user_id) VALUES
('Weekly Community Meal', 1, 'Food needed for our weekly community dinner serving 50 people', DATE_ADD(CURRENT_DATE(), INTERVAL 7 DAY), 'open', 2, 2),
('Emergency Food Drive', 2, 'Collecting non-perishable items for disaster relief', DATE_ADD(CURRENT_DATE(), INTERVAL 3 DAY), 'urgent', 3, 3),
('Campus Food Pantry Restock', 3, 'Restocking our student food pantry for the new semester', DATE_ADD(CURRENT_DATE(), INTERVAL 14 DAY), 'open', 4, 4),
('Senior Nutrition Program', 4, 'Healthy foods for our senior meal program', DATE_ADD(CURRENT_DATE(), INTERVAL 10 DAY), 'open', 5, 5),
('Holiday Food Baskets', 1, 'Creating 25 holiday meal baskets for families in need', DATE_ADD(CURRENT_DATE(), INTERVAL 30 DAY), 'planning', 2, 1);

-- Insert food request items
INSERT INTO food_request_item (request_id, food_id, quantity_value, quantity_unit_id) VALUES
(1, 3, 5, 1), -- 5kg of chicken for community meal
(1, 5, 20, 5), -- 20 tomatoes for community meal
(1, 7, 10, 6), -- 10 packages of bread for community meal
(1, 17, 5, 1), -- 5kg of potatoes for community meal
(2, 12, 20, 6), -- 20 packages of pasta for food drive
(2, 13, 10, 1), -- 10kg of rice for food drive
(2, 14, 30, 7), -- 30 cans of beans for food drive
(3, 1, 10, 3), -- 10L of milk for campus pantry
(3, 7, 15, 6), -- 15 packages of bread for campus pantry
(3, 9, 20, 5), -- 20 yogurts for campus pantry
(4, 10, 30, 5), -- 30 apples for senior program
(4, 11, 30, 5), -- 30 bananas for senior program
(4, 16, 5, 1), -- 5kg of carrots for senior program
(5, 3, 25, 1), -- 25kg of chicken for holiday baskets
(5, 4, 15, 1), -- 15kg of ground beef for holiday baskets
(5, 13, 25, 1), -- 25kg of rice for holiday baskets
(5, 17, 25, 1); -- 25kg of potatoes for holiday baskets

-- Insert request contributions
INSERT INTO request_contribution (user_id, request_id, contribution_date, quantity_value, quantity_unit_id) VALUES
(2, 1, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), 2, 1), -- 2kg of chicken
(4, 1, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), 10, 5), -- 10 tomatoes
(6, 1, CURRENT_DATE(), 5, 6), -- 5 packages of bread
(3, 2, DATE_SUB(CURRENT_DATE(), INTERVAL 3 DAY), 10, 6), -- 10 packages of pasta
(5, 2, DATE_SUB(CURRENT_DATE(), INTERVAL 2 DAY), 5, 1), -- 5kg of rice
(1, 2, DATE_SUB(CURRENT_DATE(), INTERVAL 1 DAY), 15, 7), -- 15 cans of beans
(4, 3, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), 5, 3), -- 5L of milk
(2, 3, DATE_SUB(CURRENT_DATE(), INTERVAL 4 DAY), 8, 6), -- 8 packages of bread
(3, 4, DATE_SUB(CURRENT_DATE(), INTERVAL 6 DAY), 15, 5), -- 15 apples
(5, 4, DATE_SUB(CURRENT_DATE(), INTERVAL 5 DAY), 15, 5), -- 15 bananas
(1, 5, DATE_SUB(CURRENT_DATE(), INTERVAL 10 DAY), 10, 1), -- 10kg of chicken
(2, 5, DATE_SUB(CURRENT_DATE(), INTERVAL 9 DAY), 5, 1); -- 5kg of ground beef