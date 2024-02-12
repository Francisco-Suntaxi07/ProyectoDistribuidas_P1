/*==============================================================*/
/*						BIBLIOTECA                              */
/*					Datos y Consultas                           */
/*==============================================================*/


/*==============================================================*/
/* DATOS DE PRUEBA                                              */
/*==============================================================*/

-- Inserting into AUTOR
INSERT INTO Autor (id_autor, nombre_autor, nacionalidad_autor)
VALUES ('A001', 'J. K. Rowling​', 'Británico');

INSERT INTO Autor (id_autor, nombre_autor, nacionalidad_autor)
VALUES 
   ('A002', 'Gabriel García Márquez', 'Colombiano'),
   ('A003', 'Robert C. Martin', 'Estadounidense'),
   ('A004', 'Haruki Murakami', 'Japonés'),
   ('A005', 'Isabel Allende', 'Chileno'),
   ('A006', 'Joyanes Aguilar', 'Español'),
   ('A007', 'Jules Gabriel Verne', 'Frances'),
   ('A008', 'Daniel James Brown', 'Estadounidense');

-- Inserting into EDITORIAL
INSERT INTO Editorial(id_editorial, nombre_editorial, direccion_editorial)
VALUES ('E001', 'Scholastic', '789 Maple St');

INSERT INTO Editorial(id_editorial, nombre_editorial, direccion_editorial)
VALUES 
	('E002', 'Prentice Hall', '123 Main Street'),
	('E003', 'O''Reilly Media', '1005 Gravenstein Highway North'),
	('E004', 'McGraw-Hill', '123 Educational Avenue'),
	('E005', 'HarperCollins Publishers', '456 Story Avenue'),
	('E006', 'Prentice Hall', '123 Main Street'),
    ('E007', 'SALAMANDRA', 'Madrid, España'),
	('E008', 'Editorial Sudamericana', 'Buenos Aires, Argentina');

-- Inserting into GENERO
INSERT INTO Genero (id_genero, nombre_genero, descripcion_genero)
VALUES ('GNo01', 'Novela', 'Historias narrativas extensas y complejas.');

INSERT INTO Genero (id_genero, nombre_genero, descripcion_genero)
VALUES 
   ('GFi10', 'Ficción', 'Basado en la imaginación y la creatividad.'),
   ('GNF11', 'No Ficción', 'Basado en hechos y eventos reales.'),
   ('GCF12', 'Ciencia Ficción', 'Aborda conceptos científicos y tecnológicos imaginarios.'),
   ('GMi20', 'Misterio', 'Se centra en el suspenso y la resolución de un enigma.'),
   ('GPo30', 'Poesía', 'Utiliza ritmo y expresión artística.'),
   ('GRo31', 'Romance', 'Se centra en las relaciones amorosas y emociones.'),
   ('GHi40', 'Historia', 'Basado en eventos y períodos históricos.'),
   ('GFa41', 'Fantasía', 'Involucra elementos mágicos y mundos imaginarios.'),
   ('GAv42', 'Aventura', 'Implica experiencias emocionantes y riesgos.'),
   ('GBi50', 'Biografía', 'Basado en la vida de personas reales.'),
   ('GAp60', 'Aprendizaje', 'Proporciona conocimientos y habilidades para el aprendizaje.');

-- Inserting into LIBRO
INSERT INTO Libro (id_libro, id_autor, id_genero, id_editorial, titulo_libro, fecha_publicacion, num_paginas, estado_libro, cantidad_libro)
VALUES ('L001', 'A001', 'GNo01', 'E001', 'Harry Potter y la piedra filosofal', '1997-06-26', 368, 'Disponible', 50);

INSERT INTO Libro (id_libro, id_autor, id_genero, id_editorial, titulo_libro, fecha_publicacion, num_paginas, estado_libro, cantidad_libro)
VALUES
	('L002', 'A001', 'GNo01', 'E007', 'Harry Potter y la camara secreta', '2000-06-26', 384, 'Disponible', 51),
    ('L003', 'A007', 'GFa41', 'E007', 'Viaje al centro de la tierra', '1867-05-30', 432, 'Disponible', 22),
    ('L004', 'A005', 'GFi10', 'E005', 'Norwegian Wood', '1987-08-04', 296, 'Disponible', 20),
    ('L005', 'A002', 'GHi40', 'E007', 'Cien años de soledad', '1967-05-30', 432, 'Disponible', 30),
    ('L006', 'A008', 'GHi40', 'E008', 'El Código Da Vinci', '2003-03-18', 454, 'Disponible', 40),
    ('L007', 'A004', 'GNo01', 'E004', 'La Casa de los Espíritus', '1982-01-01', 560, 'Disponible', 35),
    ('L008', 'A006', 'GFi10', 'E006', 'El Código Da Vinci', '2003-03-18', 454, 'Disponible', 40),
    ('L009', 'A007', 'GNF11', 'E007', 'The Boys in the Boat', '2013-06-04', 404, 'Disponible', 15),
    ('L010', 'A003', 'GAp60', 'E003', 'Clean Code: A Handbook of Agile Software Craftsmanship', '2008-08-01', 464, 'Disponible', 25),
    ('L011', 'A003', 'GAp60', 'E003', 'Codigo Limpio', '2008-08-01', 464, 'Disponible', 15),
    ('L012', 'A008', 'GAv42', 'E002', 'In the Garden of Beasts', '2011-05-10', 448, 'Disponible', 18),
    ('L013', 'A008', 'GMi20', 'E002', 'Brave New World', '1932-01-01', 311, 'Disponible', 35);

   
   
-- Inserting into CLIENTE
INSERT INTO Cliente (id_cliente, nombre_cliente, direccion_cliente, telf_cliente, email_cliente, edad_cliente)
VALUES ('1726164579', 'Francisco Suntaxi', 'Sin direcccion', '555-5678', 'sfsuntaxi1@espe.edu.ec', 18);

INSERT INTO Cliente (id_cliente, nombre_cliente, direccion_cliente, telf_cliente, email_cliente, edad_cliente)
VALUES 
	('1798765432', 'Mireya Lincango', 'San fernand', '0919283789', 'Mire123@gmail.com', 24),
	('1023456789', 'Luis Espinosa', 'Quito,Puente 2', '555-5678', 'lxespinoza@espe.edu.ec', 30),
	('1712345678', 'Alejandro Toscano', 'San fernand', '0912309812', 'Mire123@gmail.com', 23),
	('1798765431', 'Alison Caiza', 'San Rafael', '0912345678', 'Mire123@gmail.com', 24),
	('1712345679', 'Pedro Taboada', 'San fernand', '0987654321', 'Mire123@gmail.com', 23),
	('1757483922', 'Anthony Mena', 'Puente 7', '232-5678', 'mena_a@hotmail.com', 22);

-- Inserting into PRESTAMO
INSERT INTO Prestamo (id_prestamo, id_libro, id_cliente, fecha_prestamo, fecha_devolucion, precio_prestamo, multa_prestamo, observaciones_prestamo)
VALUES ('P001', 'L001', '1726164579', '2023-12-15', '2023-12-28', 4.99, 2.50, 'Regresado sin novedades');

INSERT INTO Prestamo (id_prestamo, id_libro, id_cliente, fecha_prestamo, fecha_devolucion, precio_prestamo, multa_prestamo, observaciones_prestamo)
VALUES 
	('P002', 'L010', '1023456789', '2022-07-04', '2022-07-10', 5.50, 0.0, 'Regresado sin novedades'),
	('P003', 'L002', '1798765432', '2018-11-19', '2022-01-22', 3.50, 2.50, 'Regresado sin novedades,pero con retraso'),
	('P004', 'L011', '1023456789', '2022-07-10', '2022-11-28', 5.50, 0.0, 'Regresado sin novedades'),
	('P005', 'L001', '1712345678', '2018-05-09', '0001-01-01', 6.50, 3.25, 'Aun no regresa');


/*==============================================================*/
/* CONSULTAS                                                    */
/*==============================================================*/
SELECT * FROM Libro;
SELECT * FROM Autor;
SELECT * FROM Editorial;
SELECT * FROM Genero;

SELECT * FROM Cliente;
SELECT * FROM Prestamo;

-- *PRESTAMOS
UPDATE Prestamo
SET
    fecha_devolucion = '2023-12-29',
    precio_prestamo = 5.99,
    multa_prestamo = 1.50,
    observaciones_prestamo = 'Regresado con algunas marcas'
WHERE
    id_prestamo = 'P003';

--
DELETE FROM Prestamo
WHERE id_prestamo = 'P001';

-- *CLIENTES
UPDATE Cliente
SET
	direccion_cliente ='San rafael',
    telf_cliente = '0992614124',
    email_cliente = 'kiaraBB@gamil.com',
    edad_cliente = 1
WHERE
    id_cliente = '1792657419';

DELETE FROM Cliente
WHERE id_cliente = '';



/*==============================================================*/
/* Borrar solo datos                                            */
/*==============================================================*/
DELETE FROM Prestamo;
DELETE FROM Cliente;

DELETE FROM Libro;
DELETE FROM Autor;
DELETE FROM Editorial;
DELETE FROM Genero;






/*==============================================================*/
/* Borrar toda la estructura                                    */
/*==============================================================*/
--PRESTAMO
ALTER TABLE Prestamo DROP CONSTRAINT FK_prestamo_libro_pre_libro;
ALTER TABLE Prestamo DROP CONSTRAINT FK_prestamo_prestamo__cliente;
DROP TABLE Prestamo;

--CLIENTE
DROP TABLE Cliente;

--LIBRO
ALTER TABLE Libro DROP CONSTRAINT FK_libro_libro_aut_autor;
ALTER TABLE Libro DROP CONSTRAINT FK_libro_libro_edi_editoria;
ALTER TABLE Libro DROP CONSTRAINT FK_libro_libro_gen_genero;
DROP TABLE Libro;

--EDITORIAL
DROP TABLE Editorial;

--AUTOR
DROP TABLE Autor;

--GENERO
DROP TABLE Genero;















