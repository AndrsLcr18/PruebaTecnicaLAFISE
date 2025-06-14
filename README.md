# Prueba Técnica LAFISE

Este proyecto es una API RESTful desarrollada con ASP.NET Core (.NET 8), como parte de una prueba técnica para una aplicación bancaria. Permite la gestión de clientes, cuentas bancarias y transacciones.

## Funcionalidades

La API permite:

- Crear perfiles de clientes
- Crear cuentas bancarias
- Consultar saldo de cuentas
- Registrar depósitos y retiros
- Consultar historial de transacciones

## Tecnologías Utilizadas

- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQLite
- xUnit (pruebas unitarias)
- Inyección de dependencias
- Principios SOLID

## Estructura del Proyecto

/PruebaTecnicaLAFISE
├── Controllers/
├── Data/
├── DTO/
├── Mapping/
├── Migration/
├── Models/
├── Services/
└── Program.cs

/TestPruebaTecnicaLAFISE
├── appsettings.json
├── ClientesTest.cs
└── CuentasTest.cs

## Instalación y Ejecución

### Requisitos previos

- .NET 8 SDK
- SQLite
- Visual Studio o Visual Studio Code

### Pasos para ejecutar

1. Clonar el repositorio:

```bash
git clone https://github.com/AndrsLcr18/PruebaTecnicaLAFISE.git
cd PruebaTecnicaLAFISE
