# Sistema Hotelero 3.0

## Descripción
**Sistema Hotelero 3.0** es una aplicación de escritorio desarrollada en **C# con Visual Studio**, diseñada para gestionar de manera integral un hotel. Permite manejar huéspedes, reservas, habitaciones, servicios, empleados y pagos de forma centralizada, eficiente y segura.

El sistema sigue una **arquitectura en tres capas**:

1. **Capa de Datos:** Funciones que interactúan directamente con la base de datos en **SQL Server**.
2. **Capa Modelo:** Clases que representan las tablas de la base de datos, con propiedades que coinciden exactamente con los campos.
3. **Capa de Presentación:** Interfaz gráfica para el usuario, con formularios para la gestión de reservas, huéspedes, empleados y generación de reportes.

---

## Funcionalidades

### Gestión de Hoteles
- Registrar nuevos hoteles con información detallada.
- Visualizar y editar los datos de hoteles existentes.

### Gestión de Habitaciones
- Registrar y editar habitaciones y tipos de habitación.
- Control de disponibilidad: disponible, ocupada o en mantenimiento.
- Asociar habitaciones con servicios y reservas.

### Gestión de Reservas
- Crear, modificar y eliminar reservas.
- Asignar huéspedes a reservas.
- Controlar el estado de reservas: pendiente, confirmada o cancelada.

### Gestión de Huéspedes
- Registrar y editar huéspedes.
- Asociar huéspedes con reservas y habitaciones.

### Gestión de Empleados
- Registrar empleados y asignar roles: Administrador, Recepcionista o Personal de Limpieza.
- Gestionar permisos según rol:
  - **Administrador:** Control total del sistema.
  - **Recepcionista:** Gestión de reservas y huéspedes.
  - **Limpieza:** Gestión de habitaciones.

### Gestión de Servicios
- Registrar servicios ofrecidos por el hotel.
- Controlar consumos y asignarlos a reservas o habitaciones.
- Generar facturas y pagos por servicios.

### Reportes e Informes
- Generación de informes detallados en PDF que incluyen:
  - Cantidad de hoteles.
  - Listado de pisos y habitaciones.
  - Huéspedes registrados.
  - Habitaciones disponibles y en mantenimiento.
  - Resumen de reservas realizadas y pendientes.
  - Informe de empleados y roles.

---

## Base de Datos

El sistema utiliza **SQL Server** y cuenta con las siguientes tablas:

- `Hotel`
- `Habitaciones`
- `Tipo_de_habitaciones`
- `Huespedes`
- `Reservas`
- `Empleado`
- `Roles`
- `Permisos`
- `Consumos_servicios`
- `Detalle_de_habitaciones`
- `Detalle_de_servicios`
- `Estado_de_la_reserva`
- `Forma_de_pago`
- `Horario_empleados`
- `Servicios`

Las tablas están relacionadas para garantizar la **integridad referencial** y permitir una gestión coherente de todos los datos del hotel.

---

## Arquitectura del Sistema

```text
Capa de Presentación (UI) <--> Capa Modelo (Clases) <--> Capa de Datos (SQL Server)
Capa de Presentación: Formularios y botones que permiten al usuario interactuar con los datos.

Capa Modelo: Clases como Empleado, Huesped, Habitacion, Reserva, entre otras.

Capa de Datos: Funciones de CRUD (Create, Read, Update, Delete) que ejecutan consultas SQL.

Tecnologías Utilizadas
Lenguaje: C#

IDE: Visual Studio Community

Base de Datos: SQL Server

Generación de Reportes: PDF mediante librerías compatibles con C#

Control de versiones: Git / GitHub

Instalación y Uso
Clonar el repositorio:

bash
Copiar código
git clone https://github.com/rogelio888/Sistema-Hotelero.git
Abrir el proyecto en Visual Studio Community.

Configurar la conexión a la base de datos SQL Server en el archivo de configuración.

Ejecutar la aplicación.

Navegar por los formularios para gestionar hoteles, habitaciones, reservas, huéspedes, empleados y servicios.

Contribuciones
Si deseas contribuir al proyecto:

Hacer un fork del repositorio.

Crear una nueva rama:

bash
Copiar código
git checkout -b nueva-funcionalidad
Realizar cambios y commits.

Enviar un pull request al repositorio principal.

Licencia
Este proyecto es de uso personal y académico. Puedes modificarlo y adaptarlo según tus necesidades, siempre mencionando al autor original.

Autor
Rogelio Vladimir Hinojosa Navia
GitHub: https://github.com/rogelio888
