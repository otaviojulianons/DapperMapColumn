# DapperMapColumn

Este repositório mostra um exemplo de mapeamento de colunas onde a consulta executada possui nome diferente da classe espelho.

## Mapeamento de Classe
```csharp
static void MapearEntidades()
{
    DapperMapper.Mapper<ClienteDominio>();
}
```

## Inicialização

```csharp
public class ClienteDominio
{
    public string Id { get; set; }
    
    [Description("Nome")]
    public string NomeCliente { get; set; }
}
```

## Script SQL do exemplo

```SQL
USE [master]

CREATE DATABASE [LojaDB]

USE [LojaDB]

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY ,
	[Nome] [nvarchar](max) NULL
)
```