# Tienda de Ordenadores

Este repositorio contiene una aplicación web encargada de gestionar una tienda de ordenadores. La solución, desarrolada en .NET 6, está compuesta por tres proyectos principales y sus respectivos proyectos de pruebas MSTest. A continuación, se detallan los componentes principales del proyecto y los patrones de diseño utilizados.

## Proyectos Principales

### 1. TiendaOrdenadores

Este proyecto es el núcleo de la aplicación y se utiliza para aplicar varios patrones de diseño, incluyendo Strategy, Factory Method y Builder. Aquí se gestionan los objetos componentes que pueden ser guardadores, memorizadores y procesadores. Un ordenador se compone de estos componentes.

- **Strategy Pattern**: Se utiliza para crear dos tipos de objetos en la clase Ordenador. Uno es un ordenador con un procesador, memorizador y guardador, y el otro es un ordenador con estos componentes más una lista de guardadores secundarios.

- **Factory Method Pattern**: Se utiliza para fabricar los componentes que se ensamblarán en los ordenadores.

- **Builder Pattern**: Se utiliza para construir objetos complejos de tipo Ordenador de manera flexible y escalable.

### 2. TiendaOrdenadoresAPI

Este proyecto es una API web que se utiliza en conjunto con el proyecto TiendaOrdenadoresDB. Ofrece endpoints para interactuar con la tienda de ordenadores y se encarga de consumir una API externa que proporciona información adicional sobre los productos.

### 3. TiendaOrdenadoresDB

Este proyecto gestiona la persistencia de datos en una base de datos. Proporciona tres servicios distintos:

- **Fakes**: Este servicio se utiliza en los proyectos de pruebas para simular el funcionamiento del controlador de la tienda de ordenadores.

- **DB**: Este servicio utiliza Entity Framework para interactuar con la base de datos y gestionar los datos de la tienda.

- **API**: Este servicio se utiliza para consumir la API creada en el proyecto TiendaOrdenadoresAPI, lo que permite obtener información externa relacionada con los productos.

## Proyectos de Pruebas

- **TiendaOrdenadores.Test**: Proyecto de pruebas unitarias para el proyecto TiendaOrdenadores.

- **TiendaOrdenadoresAPI.Test**: Proyecto de pruebas de integración para el proyecto TiendaOrdenadoresAPI.

- **TiendaOrdenadoresDB.Test**: Proyecto de pruebas unitarias y de integración para el proyecto TiendaOrdenadoresDB.

## Cómo empezar

1. Clona este repositorio en tu máquina local.
2. Asegúrate de tener instalado .NET 6 Core en tu entorno de desarrollo.
3. Abre la solución en tu IDE preferido (visual studio o visual studio code).
4. Puedes ejecutar las pruebas unitarias en los proyectos de pruebas para verificar la integridad del código.
5. Para iniciar la aplicación, puedes utilizar el proyecto TiendaOrdenadoresDB como punto de entrada y configurar la base de datos según sea necesario.

