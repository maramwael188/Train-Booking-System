/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     5/20/2023 11:07:10 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMIN') and o.name = 'FK_ADMIN_ADD_TRAIN')
alter table ADMIN
   drop constraint FK_ADMIN_ADD_TRAIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMIN') and o.name = 'FK_ADMIN_ADD1_TRIP')
alter table ADMIN
   drop constraint FK_ADMIN_ADD1_TRIP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMIN') and o.name = 'FK_ADMIN_MANAGE_PASSENGE')
alter table ADMIN
   drop constraint FK_ADMIN_MANAGE_PASSENGE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMIN') and o.name = 'FK_ADMIN_UPDATE_TRAIN')
alter table ADMIN
   drop constraint FK_ADMIN_UPDATE_TRAIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMIN') and o.name = 'FK_ADMIN_UPDATE1_TRIP')
alter table ADMIN
   drop constraint FK_ADMIN_UPDATE1_TRIP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BOOKING') and o.name = 'FK_BOOKING_HAVE_SEAT')
alter table BOOKING
   drop constraint FK_BOOKING_HAVE_SEAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BOOKING') and o.name = 'FK_BOOKING_RESERVE_TRIP')
alter table BOOKING
   drop constraint FK_BOOKING_RESERVE_TRIP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLASS') and o.name = 'FK_CLASS_CONTAIN_TRIP')
alter table CLASS
   drop constraint FK_CLASS_CONTAIN_TRIP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLASS') and o.name = 'FK_CLASS_HAS_SEAT')
alter table CLASS
   drop constraint FK_CLASS_HAS_SEAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PASSENGER') and o.name = 'FK_PASSENGE_BOOK_BOOKING')
alter table PASSENGER
   drop constraint FK_PASSENGE_BOOK_BOOKING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PASSENGER') and o.name = 'FK_PASSENGE_CANCEL_BOOKING')
alter table PASSENGER
   drop constraint FK_PASSENGE_CANCEL_BOOKING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TRAIN') and o.name = 'FK_TRAIN_MAKE_TRIP')
alter table TRAIN
   drop constraint FK_TRAIN_MAKE_TRIP
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ADMIN')
            and   name  = 'MANAGE_FK'
            and   indid > 0
            and   indid < 255)
   drop index ADMIN.MANAGE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ADMIN')
            and   name  = 'UPDATE1_FK'
            and   indid > 0
            and   indid < 255)
   drop index ADMIN.UPDATE1_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ADMIN')
            and   name  = 'ADD1_FK'
            and   indid > 0
            and   indid < 255)
   drop index ADMIN.ADD1_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ADMIN')
            and   name  = 'ADD_FK'
            and   indid > 0
            and   indid < 255)
   drop index ADMIN.ADD_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ADMIN')
            and   name  = 'UPDATE_FK'
            and   indid > 0
            and   indid < 255)
   drop index ADMIN.UPDATE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMIN')
            and   type = 'U')
   drop table ADMIN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BOOKING')
            and   name  = 'HAVE_FK'
            and   indid > 0
            and   indid < 255)
   drop index BOOKING.HAVE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BOOKING')
            and   name  = 'RESERVE_FK'
            and   indid > 0
            and   indid < 255)
   drop index BOOKING.RESERVE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BOOKING')
            and   type = 'U')
   drop table BOOKING
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CLASS')
            and   name  = 'CONTAIN_FK'
            and   indid > 0
            and   indid < 255)
   drop index CLASS.CONTAIN_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CLASS')
            and   name  = 'HAS_FK'
            and   indid > 0
            and   indid < 255)
   drop index CLASS.HAS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLASS')
            and   type = 'U')
   drop table CLASS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PASSENGER')
            and   name  = 'CANCEL_FK'
            and   indid > 0
            and   indid < 255)
   drop index PASSENGER.CANCEL_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PASSENGER')
            and   name  = 'BOOK_FK'
            and   indid > 0
            and   indid < 255)
   drop index PASSENGER.BOOK_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PASSENGER')
            and   type = 'U')
   drop table PASSENGER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SEAT')
            and   type = 'U')
   drop table SEAT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TRAIN')
            and   name  = 'MAKE_FK'
            and   indid > 0
            and   indid < 255)
   drop index TRAIN.MAKE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TRAIN')
            and   type = 'U')
   drop table TRAIN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TRIP')
            and   type = 'U')
   drop table TRIP
go

/*==============================================================*/
/* Table: ADMIN                                                 */
/*==============================================================*/
create table ADMIN (
   ADMINID              int                  not null,
   TRAINANUM            int                  null,
   TRIPID               int                  null,
   TRA_TRAINANUM        int                  null,
   TRI_TRIPID           int                  null,
   PASSENGERID          int                  null,
   FIRSTNAME            varchar(30)          not null,
   LASTNAME             varchar(20)          not null,
   EMAIL                varchar(30)          not null,
   PASSWORD             varchar(20)          not null,
   WORKHRS              int                  null,
   AREACODE             numeric              not null,
   NUMBER               varchar(30)          not null,
   constraint PK_ADMIN primary key nonclustered (ADMINID)
)
go

/*==============================================================*/
/* Index: UPDATE_FK                                             */
/*==============================================================*/
create index UPDATE_FK on ADMIN (
TRA_TRAINANUM ASC
)
go

/*==============================================================*/
/* Index: ADD_FK                                                */
/*==============================================================*/
create index ADD_FK on ADMIN (
TRAINANUM ASC
)
go

/*==============================================================*/
/* Index: ADD1_FK                                               */
/*==============================================================*/
create index ADD1_FK on ADMIN (
TRIPID ASC
)
go

/*==============================================================*/
/* Index: UPDATE1_FK                                            */
/*==============================================================*/
create index UPDATE1_FK on ADMIN (
TRI_TRIPID ASC
)
go

/*==============================================================*/
/* Index: MANAGE_FK                                             */
/*==============================================================*/
create index MANAGE_FK on ADMIN (
PASSENGERID ASC
)
go

/*==============================================================*/
/* Table: BOOKING                                               */
/*==============================================================*/
create table BOOKING (
   BOOKINGNUMBER        int                  not null,
   TRIPID               int                  null,
   TRIPNUMBER           int                  null,
   SEATNUMBER           int                  null,
   CLASSN               varchar(30)          null,
   SEATSNUMS            int                  not null,
   BOOKINGDATE          datetime             not null,
   BOOKINGSTATUS        bit                  not null,
   NUMOFSEATS           int                  null,
   constraint PK_BOOKING primary key nonclustered (BOOKINGNUMBER)
)
go

/*==============================================================*/
/* Index: RESERVE_FK                                            */
/*==============================================================*/
create index RESERVE_FK on BOOKING (
TRIPID ASC
)
go

/*==============================================================*/
/* Index: HAVE_FK                                               */
/*==============================================================*/
create index HAVE_FK on BOOKING (
TRIPNUMBER ASC,
SEATNUMBER ASC,
CLASSN ASC
)
go

/*==============================================================*/
/* Table: CLASS                                                 */
/*==============================================================*/
create table CLASS (
   TRIPID               int                  null,
   TRIPNUMBER           int                  null,
   SEATNUMBER           int                  null,
   CLASSN               varchar(30)          null,
   TRIPNUM              int                  null,
   CLASSNAME            varchar(30)          null,
   PRICE                decimal              null
)
go

/*==============================================================*/
/* Index: HAS_FK                                                */
/*==============================================================*/
create index HAS_FK on CLASS (
TRIPNUMBER ASC,
SEATNUMBER ASC,
CLASSN ASC
)
go

/*==============================================================*/
/* Index: CONTAIN_FK                                            */
/*==============================================================*/
create index CONTAIN_FK on CLASS (
TRIPID ASC
)
go

/*==============================================================*/
/* Table: PASSENGER                                             */
/*==============================================================*/
create table PASSENGER (
   PASSENGERID          int                  not null,
   BOOKINGNUMBER        int                  null,
   BOO_BOOKINGNUMBER    int                  null,
   FIRSTNAME            varchar(30)          not null,
   LASTNAME             varchar(20)          not null,
   EMAIL                varchar(30)          not null,
   ARIACODE             numeric              not null,
   NUMBER               varchar(30)          not null,
   PASSWORD             varchar(20)          not null,
   GENDER               char(10)             not null,
   constraint PK_PASSENGER primary key nonclustered (PASSENGERID)
)
go

/*==============================================================*/
/* Index: BOOK_FK                                               */
/*==============================================================*/
create index BOOK_FK on PASSENGER (
BOOKINGNUMBER ASC
)
go

/*==============================================================*/
/* Index: CANCEL_FK                                             */
/*==============================================================*/
create index CANCEL_FK on PASSENGER (
BOO_BOOKINGNUMBER ASC
)
go

/*==============================================================*/
/* Table: SEAT                                                  */
/*==============================================================*/
create table SEAT (
   TRIPNUMBER           int                  not null,
   SEATNUMBER           int                  not null,
   CLASSN               varchar(30)          not null,
   constraint PK_SEAT primary key nonclustered (TRIPNUMBER, SEATNUMBER, CLASSN)
)
go

/*==============================================================*/
/* Table: TRAIN                                                 */
/*==============================================================*/
create table TRAIN (
   TRAINANUM            int                  not null,
   TRIPID               int                  null,
   MODELTRAIN           varchar(20)          not null,
   TRAINNAME            varchar(30)          not null,
   constraint PK_TRAIN primary key nonclustered (TRAINANUM)
)
go

/*==============================================================*/
/* Index: MAKE_FK                                               */
/*==============================================================*/
create index MAKE_FK on TRAIN (
TRIPID ASC
)
go

/*==============================================================*/
/* Table: TRIP                                                  */
/*==============================================================*/
create table TRIP (
   TRIPID               int                  not null,
   DEPARTDATE           datetime             not null,
   RETURNDATE           datetime             not null,
   TIME                 datetime             not null,
   SOURCE               varchar(40)          null,
   DESTINATION          decimal              null,
   AVAILABLESEAT        int                  null,
   constraint PK_TRIP primary key nonclustered (TRIPID)
)
go

alter table ADMIN
   add constraint FK_ADMIN_ADD_TRAIN foreign key (TRAINANUM)
      references TRAIN (TRAINANUM)
go

alter table ADMIN
   add constraint FK_ADMIN_ADD1_TRIP foreign key (TRIPID)
      references TRIP (TRIPID)
go

alter table ADMIN
   add constraint FK_ADMIN_MANAGE_PASSENGE foreign key (PASSENGERID)
      references PASSENGER (PASSENGERID)
go

alter table ADMIN
   add constraint FK_ADMIN_UPDATE_TRAIN foreign key (TRA_TRAINANUM)
      references TRAIN (TRAINANUM)
go

alter table ADMIN
   add constraint FK_ADMIN_UPDATE1_TRIP foreign key (TRI_TRIPID)
      references TRIP (TRIPID)
go

alter table BOOKING
   add constraint FK_BOOKING_HAVE_SEAT foreign key (TRIPNUMBER, SEATNUMBER, CLASSN)
      references SEAT (TRIPNUMBER, SEATNUMBER, CLASSN)
go

alter table BOOKING
   add constraint FK_BOOKING_RESERVE_TRIP foreign key (TRIPID)
      references TRIP (TRIPID)
go

alter table CLASS
   add constraint FK_CLASS_CONTAIN_TRIP foreign key (TRIPID)
      references TRIP (TRIPID)
go

alter table CLASS
   add constraint FK_CLASS_HAS_SEAT foreign key (TRIPNUMBER, SEATNUMBER, CLASSN)
      references SEAT (TRIPNUMBER, SEATNUMBER, CLASSN)
go

alter table PASSENGER
   add constraint FK_PASSENGE_BOOK_BOOKING foreign key (BOOKINGNUMBER)
      references BOOKING (BOOKINGNUMBER)
go

alter table PASSENGER
   add constraint FK_PASSENGE_CANCEL_BOOKING foreign key (BOO_BOOKINGNUMBER)
      references BOOKING (BOOKINGNUMBER)
go

alter table TRAIN
   add constraint FK_TRAIN_MAKE_TRIP foreign key (TRIPID)
      references TRIP (TRIPID)
go

