-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2023-08-03 09:37:46.667

-- tables
-- Table: Address
CREATE TABLE Address (
    id int  NOT NULL,
    city text  NOT NULL,
    country text  NOT NULL,
    state text  NOT NULL,
    postcode int  NOT NULL,
    street_name text  NOT NULL,
    street_number int  NOT NULL,
    CONSTRAINT Address_pk PRIMARY KEY  (id)
);

-- Table: Artist
CREATE TABLE Artist (
    id int  NOT NULL,
    name text  NOT NULL,
    CONSTRAINT Artist_pk PRIMARY KEY  (id)
);

-- Table: Artist_Record
CREATE TABLE Artist_Record (
    Artist_id int  NOT NULL,
    Record_id int  NOT NULL,
    CONSTRAINT Artist_Record_pk PRIMARY KEY  (Artist_id,Record_id)
);

-- Table: Customer
CREATE TABLE Customer (
    id int  NOT NULL,
    name text  NOT NULL,
    surname text  NOT NULL,
    Discount_id int  NULL,
    Address_id int  NOT NULL,
    CONSTRAINT Customer_pk PRIMARY KEY  (id)
);

-- Table: Discount
CREATE TABLE Discount (
    id int  NOT NULL,
    Percentage int  NOT NULL,
    MaxDiscount int  NOT NULL,
    MinPrice int  NOT NULL,
    CONSTRAINT Discount_pk PRIMARY KEY  (id)
);

-- Table: Distributor
CREATE TABLE Distributor (
    id int  NOT NULL,
    name text  NOT NULL,
    CONSTRAINT Distributor_pk PRIMARY KEY  (id)
);

-- Table: Genre
CREATE TABLE Genre (
    id int  NOT NULL,
    name text  NOT NULL,
    description text  NOT NULL,
    CONSTRAINT Genre_pk PRIMARY KEY  (id)
);

-- Table: Order
CREATE TABLE "Order" (
    id int  NOT NULL,
    quantity int  NOT NULL,
    Address_id int  NOT NULL,
    Status_id int  NOT NULL,
    RequestAt datetime  NOT NULL,
    FulfillAt datetime  NOT NULL,
    CONSTRAINT Order_pk PRIMARY KEY  (id)
);

-- Table: Order_Record
CREATE TABLE Order_Record (
    Record_id int  NOT NULL,
    Order_id int  NOT NULL,
    Quantity int  NOT NULL,
    CONSTRAINT Order_Record_pk PRIMARY KEY  (Record_id,Order_id)
);

-- Table: Record
CREATE TABLE Record (
    id int  NOT NULL,
    name text  NOT NULL,
    price int  NOT NULL,
    description text  NOT NULL,
    released date  NOT NULL,
    Distributor_id int  NOT NULL,
    TypeOfRecord_id int  NOT NULL,
    CONSTRAINT Record_pk PRIMARY KEY  (id)
);

-- Table: Record_Genre
CREATE TABLE Record_Genre (
    Record_id int  NOT NULL,
    Genre_id int  NOT NULL,
    CONSTRAINT Record_Genre_pk PRIMARY KEY  (Record_id,Genre_id)
);

-- Table: Record_Storage
CREATE TABLE Record_Storage (
    Record_id int  NOT NULL,
    Storage_id int  NOT NULL,
    Quantity int  NOT NULL,
    CONSTRAINT Record_Storage_pk PRIMARY KEY  (Record_id,Storage_id)
);

-- Table: Status
CREATE TABLE Status (
    id int  NOT NULL,
    name text  NOT NULL,
    CONSTRAINT Status_pk PRIMARY KEY  (id)
);

-- Table: Storage
CREATE TABLE Storage (
    id int  NOT NULL,
    Address_id int  NOT NULL,
    CONSTRAINT Storage_pk PRIMARY KEY  (id)
);

-- Table: Type_Of_Record
CREATE TABLE Type_Of_Record (
    id int  NOT NULL,
    name text  NOT NULL,
    color text  NULL,
    CONSTRAINT Type_Of_Record_pk PRIMARY KEY  (id)
);

-- foreign keys
-- Reference: Artist_Record_Artist (table: Artist_Record)
ALTER TABLE Artist_Record ADD CONSTRAINT Artist_Record_Artist
    FOREIGN KEY (Artist_id)
    REFERENCES Artist (id);

-- Reference: Artist_Record_Record (table: Artist_Record)
ALTER TABLE Artist_Record ADD CONSTRAINT Artist_Record_Record
    FOREIGN KEY (Record_id)
    REFERENCES Record (id);

-- Reference: Customer_Address (table: Customer)
ALTER TABLE Customer ADD CONSTRAINT Customer_Address
    FOREIGN KEY (Address_id)
    REFERENCES Address (id);

-- Reference: Customer_Discount (table: Customer)
ALTER TABLE Customer ADD CONSTRAINT Customer_Discount
    FOREIGN KEY (Discount_id)
    REFERENCES Discount (id);

-- Reference: Order_Address (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Address
    FOREIGN KEY (Address_id)
    REFERENCES Address (id);

-- Reference: Order_Record_Order (table: Order_Record)
ALTER TABLE Order_Record ADD CONSTRAINT Order_Record_Order
    FOREIGN KEY (Order_id)
    REFERENCES "Order" (id);

-- Reference: Order_Record_Record (table: Order_Record)
ALTER TABLE Order_Record ADD CONSTRAINT Order_Record_Record
    FOREIGN KEY (Record_id)
    REFERENCES Record (id);

-- Reference: Order_Status (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Status
    FOREIGN KEY (Status_id)
    REFERENCES Status (id);

-- Reference: RecordStorage_Record (table: Record_Storage)
ALTER TABLE Record_Storage ADD CONSTRAINT RecordStorage_Record
    FOREIGN KEY (Record_id)
    REFERENCES Record (id);

-- Reference: RecordStorage_Storage (table: Record_Storage)
ALTER TABLE Record_Storage ADD CONSTRAINT RecordStorage_Storage
    FOREIGN KEY (Storage_id)
    REFERENCES Storage (id);

-- Reference: Record_Distributor (table: Record)
ALTER TABLE Record ADD CONSTRAINT Record_Distributor
    FOREIGN KEY (Distributor_id)
    REFERENCES Distributor (id);

-- Reference: Record_Genre_Genre (table: Record_Genre)
ALTER TABLE Record_Genre ADD CONSTRAINT Record_Genre_Genre
    FOREIGN KEY (Genre_id)
    REFERENCES Genre (id);

-- Reference: Record_Genre_Record (table: Record_Genre)
ALTER TABLE Record_Genre ADD CONSTRAINT Record_Genre_Record
    FOREIGN KEY (Record_id)
    REFERENCES Record (id);

-- Reference: Record_TypeOfRecord (table: Record)
ALTER TABLE Record ADD CONSTRAINT Record_TypeOfRecord
    FOREIGN KEY (TypeOfRecord_id)
    REFERENCES Type_Of_Record (id);

-- Reference: Storage_Address (table: Storage)
ALTER TABLE Storage ADD CONSTRAINT Storage_Address
    FOREIGN KEY (Address_id)
    REFERENCES Address (id);

-- End of file.

