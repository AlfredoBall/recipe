terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.16.0"
    }
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
  version = "3.16.0"
}

resource "azurerm_resource_group" "recipe-sql" {
  name     = "recipe-azuresql-rg-124703172"
  location = "North Central US"
}

resource "azurerm_mssql_server" "recipe-sql-server" {
    name = "recipe-azuresql-server-124703172"
    location = azurerm_resource_group.recipe-sql.location
    administrator_login_password = "Pa294w0rD-124703172" # This should come from the DevOps secret as a var
    administrator_login = "azureuser"
    version = "12.0"
    resource_group_name = azurerm_resource_group.recipe-sql.name
}

resource "azurerm_mssql_firewall_rule" "recipe-sql-firewall-rule" {
  name             = "recipe-azuresql-server-firewall-rule"
  server_id        = azurerm_mssql_server.recipe-sql-server.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}

resource "azurerm_mssql_database" "recipe-sql-database" {
  name           = "Recipe"
  server_id      = azurerm_mssql_server.recipe-sql-server.id
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  read_scale     = false
  sku_name       = "S0"
  zone_redundant = false

  tags = {
  }
}