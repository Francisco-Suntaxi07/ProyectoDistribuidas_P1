/*==============================================================*/
/* DBMS name:      Sybase SQL Anywhere 12                       */
/* Created on:     19/12/2023 01:13:00 a. m.                    */
/*==============================================================*/

/*==============================================================*/
/* Table: Autor                                                 */
/*==============================================================*/
create table Autor 
(
   id_autor             varchar(8)                     not null,
   nombre_autor         varchar(64)                    null,
   nacionalidad_autor   varchar(16)                    null,
   constraint PK_autor primary key (id_autor)
);

/*==============================================================*/
/* Index: Autor_PK                                              */
/*==============================================================*/
create unique index Autor_PK on Autor (
id_autor ASC
);

/*==============================================================*/
/* Table: Cliente                                               */
/*==============================================================*/

/*CAMBIE EL VARCHAR DE 8 POR 16 PARA QUE SEA LA CEDULA EL ID*/
create table Cliente 
(
   id_cliente           varchar(16)                    not null,
   nombre_cliente       varchar(64)                    null,
   direccion_cliente    varchar(64)                    null,
   telf_cliente         varchar(16)                    null,
   email_cliente        varchar(64)                    null,
   edad_cliente         integer                        null,
   constraint PK_cliente primary key (id_cliente)
);

/*==============================================================*/
/* Index: Cliente_PK                                            */
/*==============================================================*/
create unique index Cliente_PK on Cliente (
id_cliente ASC
);

/*==============================================================*/
/* Table: Editorial                                             */
/*==============================================================*/
create table Editorial 
(
   id_editorial         varchar(8)                     not null,
   nombre_editorial     varchar(64)                    null,
   direccion_editorial  varchar(64)                    null,
   constraint PK_editorial primary key (id_editorial)
);

/*==============================================================*/
/* Index: Editorial_PK                                          */
/*==============================================================*/
create unique index Editorial_PK on Editorial (
id_editorial ASC
);

/*==============================================================*/
/* Table: Genero                                                */
/*==============================================================*/
create table Genero 
(
   id_genero            varchar(8)                     not null,
   nombre_genero        varchar(64)                    null,
   descripcion_genero   varchar(64)                    null,
   constraint PK_genero primary key (id_genero)
);

/*==============================================================*/
/* Index: Genero_PK                                             */
/*==============================================================*/
create unique index Genero_PK on Genero (
id_genero ASC
);

/*==============================================================*/
/* Table: Libro                                                 */
/*==============================================================*/
create table Libro 
(
   id_libro             varchar(8)                     not null,
   id_autor             varchar(8)                     not null,
   id_genero            varchar(8)                     not null,
   id_editorial         varchar(8)                     not null,
   titulo_libro         varchar(64)                    null,
   fecha_publicacion    date                           null,
   num_paginas          integer                        null,
   estado_libro         varchar(16)                    null,
   cantidad_libro       integer                        null,
   constraint PK_libro primary key (id_libro)
);

/*==============================================================*/
/* Index: Libro_PK                                              */
/*==============================================================*/
create unique index Libro_PK on Libro (
id_libro ASC
);

/*==============================================================*/
/* Index: Libro_autor_FK                                        */
/*==============================================================*/
create index Libro_autor_FK on Libro (
id_autor ASC
);

/*==============================================================*/
/* Index: Libro_genero_FK                                       */
/*==============================================================*/
create index Libro_genero_FK on Libro (
id_genero ASC
);

/*==============================================================*/
/* Index: Libro_editorial_FK                                    */
/*==============================================================*/
create index Libro_editorial_FK on Libro (
id_editorial ASC
);

/*==============================================================*/
/* Table: Prestamo                                              */
/*==============================================================*/

/*CAMBIE EL CHAR POR VARCHAR*/
create table Prestamo 
(
   id_prestamo          varchar(8)                     not null,
   id_libro             varchar(8)                     not null,
   id_cliente           varchar(16)                    not null,
   fecha_prestamo       date                           null,
   fecha_devolucion     date                           null,
   precio_prestamo      numeric(4,2)                   null,
   multa_prestamo       numeric(4,2)                   null,
   observaciones_prestamo varchar(256)                   null,
   constraint PK_prestamo primary key (id_prestamo)
);

/*==============================================================*/
/* Index: Prestamo_PK                                           */
/*==============================================================*/
create unique index Prestamo_PK on Prestamo (
id_prestamo ASC
);

/*==============================================================*/
/* Index: prestamo_cliente_FK                                   */
/*==============================================================*/
create index Prestamo_cliente_FK on Prestamo (
id_cliente ASC
);

/*==============================================================*/
/* Index: Libro_prestamo_FK                                     */
/*==============================================================*/
create index Libro_prestamo_FK on Prestamo (
id_libro ASC
);

ALTER TABLE Libro
   ADD CONSTRAINT FK_libro_libro_aut_autor FOREIGN KEY (id_autor)
      REFERENCES Autor (id_autor)
      ON UPDATE NO ACTION
      ON DELETE NO ACTION;

alter table Libro
   add constraint FK_libro_libro_edi_editoria foreign key (id_editorial)
      references Editorial (id_editorial)
      on update NO ACTION
      on delete NO ACTION;

alter table Libro
   add constraint FK_libro_libro_gen_genero foreign key (id_genero)
      references Genero (id_genero)
      on update NO ACTION
      on delete NO ACTION;

alter table Prestamo
   add constraint FK_prestamo_libro_pre_libro foreign key (id_libro)
      references Libro (id_libro)
      on update NO ACTION
      on delete NO ACTION;

alter table Prestamo
   add constraint FK_prestamo_prestamo__cliente foreign key (id_cliente)
      references Cliente (id_cliente)
      on update NO ACTION
      on delete NO ACTION;

