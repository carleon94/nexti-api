# Considerar para la ejecucion del proyecto net core

## 1. Crear Base de Datos Sql Server

```
create Database DBNext

use DBNext

create table Usuarios (
Id int primary key identity,
Nombre VARCHAR(50),
Email VARCHAR(50),
Cedula VARCHAR(10),
)

create table Eventos (
Id int primary key identity,
Fecha datetime,
Lugar VARCHAR(250),
Descripcion VARCHAR(MAX),
Precio decimal(10,2),
)

INSERT INTO Usuarios (nombre,email,cedula) values ( 'Admin Test' , 'admin@test.com' , '1234567890' )
INSERT INTO Usuarios (nombre,email,cedula) values ( 'Soporte Test' , 'soporte@test.com' , '1234567890' )

```

## 2. Ejecutar en consola del administrador de paquetes Nuget:
```
Scaffold-DbContext "Data Source=CARLOS-KERLLY;Initial Catalog=DBNext;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

Esto para crear los modelos de las tablas de la base de datos. Considerar cambiar el Data Source por el ambiente local que se esta trabajando
