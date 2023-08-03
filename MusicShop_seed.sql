-- Tabela: Address
INSERT INTO Address (id, city, country, state, postcode, street_name, street_number)
VALUES
    (1, 'New York', 'USA', 'New York', 12345, 'Broadway', 10),
    (2, 'Los Angeles', 'USA', 'California', 54321, 'Sunset Blvd', 20),
    (3, 'London', 'UK', 'England', 123456, 'Buckingham Palace Road', 1),
    (4, 'Tokyo', 'Japan', 'Tokyo', 1000002, 'Chiyoda', 3),
    (5, 'Berlin', 'Germany', 'Berlin', 10117, 'Brandenburg Gate', 10);

-- Tabela: Artist
INSERT INTO Artist (id, name)
VALUES
    (1, 'John Smith'),
    (2, 'Emma Johnson'),
    (3, 'Michael Williams');

-- Tabela: Customer
INSERT INTO Customer (id, name, surname, Discount_id, Address_id)
VALUES
    (1, 'David', 'Miller', 1, 3),
    (2, 'Emily', 'Anderson', 2, 5),
    (3, 'Daniel', 'White', 3, 1);

-- Tabela: Discount
INSERT INTO Discount (id, Percentage, MaxDiscount, MinPrice)
VALUES
    (1, 10, 50, 100),
    (2, 20, 75, 150),
    (3, 15, 60, 120);

-- Tabela: Distributor
INSERT INTO Distributor (id, name)
VALUES
    (1, 'MusicMaster Distribution'),
    (2, 'Harmony Records'),
    (3, 'Global Soundwaves'),
    (4, 'Melody Lane Distributors'),
    (5, 'BeatStreet Music');

-- Tabela: Genre
INSERT INTO Genre (id, name, description)
VALUES
    (1, 'Rock', 'Rock music is a broad genre of popular music that originated as "rock and roll" in the United States in the late 1940s and early 1950s.'),
    (2, 'Pop', 'Pop music is a genre of popular music that originated in its modern form during the mid-1950s in the United States and the United Kingdom.'),
    (3, 'Hip Hop', 'Hip hop music, also known as rap music, is a genre of popular music developed in the United States by inner-city African Americans and Latino Americans.');

-- Tabela: "Order"
INSERT INTO "Order" (id, quantity, Address_id, Status_id, RequestAt, FulfillAt)
VALUES
    (1, 5, 1, 1, '2023-08-03 10:00:00', '2023-08-03 15:00:00'),
    (2, 3, 2, 2, '2023-08-03 11:30:00', '2023-08-03 16:45:00'),
    (3, 7, 3, 3, '2023-08-03 09:15:00', '2023-08-03 14:30:00');

-- Tabela: Order_Record
INSERT INTO Order_Record (Record_id, Order_id, Quantity)
VALUES
    (1, 1, 2),
    (2, 1, 3),
    (3, 2, 1);

-- Tabela: Record
INSERT INTO Record (id, name, price, description, released, Distributor_id, TypeOfRecord_id)
VALUES
    (1, 'Thriller', 30, 'Thriller is the sixth studio album by American singer Michael Jackson, released on November 30, 1982.', '1982-11-30', 1, 1),
    (2, 'The Dark Side of the Moon', 25, 'The Dark Side of the Moon is the eighth studio album by the English progressive rock band Pink Floyd, released on March 1, 1973.', '1973-03-01', 2, 2),
    (3, 'Rumours', 20, 'Rumours is the eleventh studio album by British-American rock band Fleetwood Mac, released on February 4, 1977.', '1977-02-04', 3, 1);

-- Tabela: Record_Genre
INSERT INTO Record_Genre (Record_id, Genre_id)
VALUES
    (1, 2),
    (2, 1),
    (3, 1);

-- Tabela: Record_Storage
INSERT INTO Record_Storage (Record_id, Storage_id, Quantity)
VALUES
    (1, 1, 10),
    (2, 2, 5),
    (3, 3, 15);

-- Tabela: Status
INSERT INTO Status (id, name)
VALUES
    (1, 'Order Received'),
    (2, 'Processing'),
    (3, 'Fulfilled');

-- Tabela: Storage
INSERT INTO Storage (id, Address_id)
VALUES
    (1, 2),
    (2, 4),
    (3, 5);

-- Tabela: Type_Of_Record
INSERT INTO Type_Of_Record (id, name, color)
VALUES
    (1, 'Vinyl', 'Black'),
    (2, 'Tape', NULL),
    (3, 'CD', NULL);
