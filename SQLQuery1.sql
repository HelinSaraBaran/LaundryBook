create database vask_en_tid
go
use vask_en_tid
go

create table machines(
machine_ID int ,
machine_type varchar (200) 
);
create table Booking(
bookingdate datetime,
bookingtime int,
machine_ID int ,
mobile varchar(12) 
);
create table residents(
firstname varchar(200) ,
lastname varchar(200),
apartmentnumber varchar(200) ,
adress varchar(200) ,
streetnumber varchar(200),
postalcode varchar(4) ,
apartmentfloor int ,
email varchar(200) ,
mobile varchar(12) 
);
create table postalcity(
city varchar (200),
postalcode varchar(4)
);

--Constraints

alter table machines
alter column machine_ID int not null
alter table machines
add primary key (machine_ID)
alter table machines
alter column machine_type varchar(200) not null;

alter table Booking
alter  column bookingdate datetime  not null
alter table Booking
alter  column bookingtime int  not null
alter table Booking
add check (bookingtime in('1','2','3','4','5','6'))
alter table Booking
alter  column machine_ID int  not null
alter table Booking
ADD UNIQUE (machine_ID) 
alter table Booking
alter  column mobile varchar(12)  not null
alter table Booking
ADD UNIQUE (mobile);

alter table residents
alter column mobile varchar(12) not null
alter table residents
add primary key (mobile)
alter table residents
alter column firstname varchar(200) not null
alter table residents
alter column apartmentnumber varchar(200) not null
alter table residents
add unique (apartmentnumber)
alter table residents
add unique(adress)
alter table residents
add unique (postalcode)  
alter table residents
add check (postalcode like'[1-4][0-9][0-9][0-9]' and LEN(postalcode) <= 4)
alter table residents
ADD CONSTRAINT df_apartmentfloor
DEFAULT  0 for apartmentfloor
alter table residents
add unique (email) 
alter table residents
alter column email varchar(200) not null;

alter table postalcity
add primary key(postalcode) 