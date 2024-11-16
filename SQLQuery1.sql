CREATE DATABASE CRUDop;
CREATE TABLE Customer
( Cust_ID int IDENTITY primary key,
First_Name nvarchar (200) unique,
Last_Name nvarchar (200),
City nvarchar (1000),
Cust_Address nvarchar (1000)
);
drop table Customer;