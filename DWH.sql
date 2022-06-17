DROP database dwhv2;
create database dwhv2;
use dwhv2;

Create table dealers
(
    ID               int,
    username         varchar,
    password         varchar,
    email            varchar,
    phoneNumber      varchar,
    registrationDate date,
    constraint pk_dealers
        primary key (ID)
)

Create table bank_employees
(
    ID       int,
    username varchar,
    password varchar,
    email    varchar,
    constraint pk_bank_employees
        primary key (ID)
)

Create table pos_terminals
(
    ID        int,
    Dealer_ID int,
    constraint pk_pos_terminals
        primary key (ID),
    constraint fk_pos_terminals_dealers
        foreign key (Dealer_ID)
            references dealers (ID)
)

insert into bank_employees(username, password, email,)