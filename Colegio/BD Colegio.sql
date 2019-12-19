create database Colegio
use Colegio
create table Curso(
IDCurso int primary key identity (1,1),
Nombre varchar(20),
Seccion varchar(10),
)


create table Materias(
IDMaterias int primary key identity(1,1),
IDCurso int not null,
Profesor varchar(30), 
NombreMateria varchar(20),
Horario varchar(20),
constraint FKMC foreign key(IDCurso) references Curso(IDCurso)
)

create table Alumno(
IDAlumno int primary key identity(1,1),
IDCurso int not null,
Nombre varchar(30),
Edad int,
Telefono varchar(15),
Direccion varchar(40),
constraint FKAC foreign key(IDCurso) references Curso(IDCurso)
)