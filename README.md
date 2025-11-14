# 🏨 Sistema Hotelero 3.0

**Sistema Hotelero 3.0** es una aplicación de escritorio robusta, desarrollada en **C\# con Visual Studio**, diseñada para la gestión integral de un hotel. Permite una administración centralizada, eficiente y segura de huéspedes, reservas, habitaciones, servicios, empleados y pagos.

## ✨ Características Principales

| Funcionalidad | Descripción |
| :--- | :--- |
| **Gestión de Hoteles** | Registro y edición de la información detallada de hoteles. |
| **Gestión de Habitaciones** | Control de disponibilidad (Disponible, Ocupada, Mantenimiento), registro de tipos y asociación con reservas/servicios. |
| **Gestión de Reservas** | Creación, modificación y eliminación de reservas. Control de estado (Pendiente, Confirmada, Cancelada). |
| **Gestión de Huéspedes** | Registro completo de huéspedes y asociación con sus reservas. |
| **Gestión de Empleados** | Registro de personal, asignación de roles (**Administrador, Recepcionista, Limpieza**) y gestión de permisos. |
| **Gestión de Servicios** | Registro de servicios, control de consumos, generación de facturas y pagos. |
| **Reportes e Informes** | Generación de informes detallados en formato **PDF** (ej. habitaciones disponibles, resumen de reservas, listado de empleados, etc.). |

-----

## 🏗️ Arquitectura del Sistema

El sistema sigue una arquitectura clara y desacoplada de **tres capas**:

1.  **Capa de Presentación (UI):**

      * Interfaz gráfica compuesta por formularios y controles para la interacción del usuario (ej. `FormReservas`, `FormHuespedes`).

2.  **Capa Modelo (Clases):**

      * Contiene las clases que representan las entidades de la base de datos (ej. `Empleado`, `Huesped`, `Habitacion`, `Reserva`). Las propiedades de estas clases coinciden exactamente con los campos de la base de datos.

3.  **Capa de Datos:**

      * Funciones encargadas de la comunicación directa con la base de datos **SQL Server**. Implementa las operaciones **CRUD** (*Create, Read, Update, Delete*) mediante la ejecución de consultas SQL.

-----

## 💻 Tecnologías Utilizadas

  * **Lenguaje:** C\#
  * **IDE:** Visual Studio Community
  * **Base de Datos:** SQL Server
  * **Generación de Reportes:** Librerías compatibles con C\# para generar documentos **PDF**.
  * **Control de Versiones:** Git / GitHub

-----

## 💾 Base de Datos (SQL Server)

El sistema utiliza **SQL Server** para el almacenamiento de datos. La estructura incluye las siguientes tablas, las cuales mantienen **integridad referencial** para una gestión coherente:

| Categoría | Tablas |
| :--- | :--- |
| **Estructura Hotel** | `Hotel`, `Habitaciones`, `Tipo_de_habitaciones` |
| **Gestión de Personas** | `Huespedes`, `Empleado`, `Roles`, `Permisos`, `Horario_empleados` |
| **Gestión de Reservas** | `Reservas`, `Estado_de_la_reserva`, `Forma_de_pago` |
| **Gestión de Servicios** | `Servicios`, `Consumos_servicios`, `Detalle_de_habitaciones`, `Detalle_de_servicios` |

-----

## 🚀 Instalación y Uso

Sigue estos pasos para poner en marcha el proyecto:

1.  **Clonar el repositorio:**

    ```bash
    git clone https://github.com/rogelio888/Sistema-Hotelero.git
    ```

2.  **Abrir el Proyecto:**

      * Abre la solución (`.sln`) dentro de **Visual Studio Community**.

3.  **Configurar la Base de Datos:**

      * Configura la cadena de conexión a tu instancia de **SQL Server** en el archivo de configuración (`App.config` o similar) del proyecto para asegurar la comunicación con la base de datos.

4.  **Ejecutar:**

      * Ejecuta la aplicación.
      * Navega por los formularios para comenzar a gestionar hoteles, habitaciones, reservas, huéspedes, empleados y servicios.

-----

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas\! Si deseas mejorar el proyecto, sigue estos pasos:

1.  Haz un **Fork** del repositorio.
2.  Crea una nueva rama para tu funcionalidad o corrección:
    ```bash
    git checkout -b nueva-funcionalidad
    ```
3.  Realiza tus cambios y **commits**.
4.  Envía un **Pull Request** al repositorio principal.

-----

## 📜 Licencia

Este proyecto es de **uso personal y académico**. Eres libre de modificarlo y adaptarlo a tus necesidades, siempre y cuando se mencione al autor original.

-----

## 🧑 Autor

**Rogelio Vladimir Hinojosa Navia**

  * **GitHub:** [https://github.com/rogelio888](https://github.com/rogelio888)
