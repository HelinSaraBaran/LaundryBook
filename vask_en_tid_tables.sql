create database vask_en_tid
go
use vask_en_tid
go

create table maskiner(
maskine_ID int ,
maskine_type varchar (200) 
);
create table Booking(
dato datetime,
tidspunkt int,
maskine_ID int ,
mobile varchar(12) 
);
create table beboere(
navn varchar(200) ,
efternavn varchar(200),
lejeligheds_nr varchar(200) ,
adresse varchar(200) ,
_by varchar (200),
gade_nr varchar(200),
post_nr varchar(4) ,
etage int ,
email varchar(200) ,
mobile varchar(12) 
);


--Constraints

alter table maskiner
alter column maskine_ID int not null
alter table maskiner
add primary key (maskine_ID)
alter table maskiner
alter column maskine_type varchar(200) not null;

alter table Booking
alter  column dato datetime  not null
alter table Booking
alter  column tidspunkt int  not null
alter table Booking
add check (tidspunkt in('1','2','3','4','5','6'))
alter table Booking
alter  column maskine_ID int  not null
alter table Booking
ADD UNIQUE (maskine_ID) 
alter table Booking
alter  column mobile varchar(12)  not null
alter table Booking
ADD UNIQUE (mobile);

alter table beboere
alter column mobile varchar(12) not null
alter table beboere
add primary key (mobile)
alter table beboere
alter column navn varchar(200) not null
alter table beboere
alter column lejeligheds_nr varchar(200) not null
alter table beboere
add unique (lejeligheds_nr)
alter table beboere
add unique(adresse)
alter table beboere
add unique (post_nr)  
alter table beboere
add check (post_nr like'[1-4][0-9][0-9][0-9]' and LEN(post_nr) <= 4)
alter table beboere
ADD CONSTRAINT df_etage
DEFAULT  0 for etage
alter table beboere
add unique (email) 
alter table beboere
alter column email varchar(200) not null;
