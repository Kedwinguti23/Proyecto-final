 ## Gestión de Farmacia – Proyecto Final POO 
Este es un proyecto de consola desarrollado en C# (.NET 8) como parte del curso de Programación Orientada a Objetos (POO).
Simula el funcionamiento básico de una farmacia, permitiendo gestionar medicamentos, recetas médicas y pedidos de manera
ordenada, modular y con pruebas automatizadas. 


## Tecnologías Utilizadas 
 C# (.NET 8)
 Paradigmas de POO: Encapsulamiento, Herencia, Composición
 Arquitectura modular (carpetas organizadas por capas)
 Testing con NUnit
Interfaz basada en consola (CLI) 


##  Estructura del Proyecto 
ProyectoFinal/
├── GestionDeFarmacia/ # Proyecto principal (consola)
│ ├── Core/ # Lógica del sistema
│ ├── Interfaces/ # Interfaces generales
│ ├── Program.cs # Punto de entrada
│ └── GestionDeFarmacia.csproj
├── GestionDeFarmacia.Tests/ # Proyecto de pruebas
│ ├── MedicamentoTests.cs
│ ├── RecetaMedicaTests.cs
│ ├── PedidoTests.cs
│ └── GestionDeFarmacia.Tests.csproj
└── GestionDeFarmacia.sln # Solución del proyecto

## Funcionalidades Principales 
 Medicamentos 
Crear, listar, actualizar y eliminar medicamentos
Validación de stock, precio y entrada de datos
Impresión ordenada en consola 
 
 Recetas Médicas 
Crear recetas asociadas a múltiples medicamentos
Actualizar datos del paciente
Eliminar y listar recetas 
 
Pedidos 
Crear pedidos desde recetas existentes
Marcar pedidos como procesados
Listar y eliminar pedidos 

  ## Pruebas Unitarias 
Se incluyen pruebas automáticas utilizando NUnit para garantizar la correcta funcionalidad de: 
Medicamento.cs
RecetaMedica.cs
Pedido.cs 

##  Herramientas usadas para testing: 
NUnit
NUnit3TestAdapter
Microsoft.NET.Test.Sdk 


## Ejecutar los tests: 
dotnet test
Todos los tests están automatizados y verificados. El sistema pasa 100% de las pruebas actualmente. 
 
 ## Cómo Ejecutar el Proyecto 
Requisitos: 
Tener instalado .NET SDK 8+ 
Pasos: 
Clonar o descargar este repositorio
Abrir terminal en la raíz del proyecto
Ejecutar los comandos: 
dotnet build
dotnet run --project GestionDeFarmacia
Otro método es ir a la carpeta "Gestion de Farmacia" y ejecutar dotnet run allí 
