-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2023-08-03 09:37:46.667

-- foreign keys
ALTER TABLE Artist_Record DROP CONSTRAINT Artist_Record_Artist;

ALTER TABLE Artist_Record DROP CONSTRAINT Artist_Record_Record;

ALTER TABLE Customer DROP CONSTRAINT Customer_Address;

ALTER TABLE Customer DROP CONSTRAINT Customer_Discount;

ALTER TABLE "Order" DROP CONSTRAINT Order_Address;

ALTER TABLE Order_Record DROP CONSTRAINT Order_Record_Order;

ALTER TABLE Order_Record DROP CONSTRAINT Order_Record_Record;

ALTER TABLE "Order" DROP CONSTRAINT Order_Status;

ALTER TABLE Record_Storage DROP CONSTRAINT RecordStorage_Record;

ALTER TABLE Record_Storage DROP CONSTRAINT RecordStorage_Storage;

ALTER TABLE Record DROP CONSTRAINT Record_Distributor;

ALTER TABLE Record_Genre DROP CONSTRAINT Record_Genre_Genre;

ALTER TABLE Record_Genre DROP CONSTRAINT Record_Genre_Record;

ALTER TABLE Record DROP CONSTRAINT Record_TypeOfRecord;

ALTER TABLE Storage DROP CONSTRAINT Storage_Address;

-- tables
DROP TABLE Address;

DROP TABLE Artist;

DROP TABLE Artist_Record;

DROP TABLE Customer;

DROP TABLE Discount;

DROP TABLE Distributor;

DROP TABLE Genre;

DROP TABLE "Order";

DROP TABLE Order_Record;

DROP TABLE Record;

DROP TABLE Record_Genre;

DROP TABLE Record_Storage;

DROP TABLE Status;

DROP TABLE Storage;

DROP TABLE Type_Of_Record;

-- End of file.

