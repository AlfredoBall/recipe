terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.28.0"
    }
  }
  backend "azurerm" {
    key                  = "terraform.tfstate"
    container_name       = "tfstate"
    resource_group_name  = "tf-rg-tfstate"
    storage_account_name = "recipetfstorage"
    use_azuread_auth     = "true"
    use_oidc             = "true"
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "recipe" {
  name     = "tf-rg-tfstate"
  location = var.location
}

resource "azurerm_storage_account" "recipe" {
  name                     = "recipetfstorage"
  resource_group_name      = azurerm_resource_group.recipe.name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "GRS"
}

resource "azurerm_storage_container" "tfstate" {
  name                  = "tfstate"
  storage_account_name    = azurerm_storage_account.recipe.name
  container_access_type = "private"
}

resource "azurerm_mssql_server" "recipe-sql-server" {
  name                         = "recipe-azuresql-server-124703172"
  location                     = azurerm_resource_group.recipe.location
  administrator_login_password = "Pa294w0rD-124703172" # TODO: This should come from the DevOps secret as a var
  administrator_login          = "azureuser"
  version                      = "12.0"
  resource_group_name          = azurerm_resource_group.recipe.name
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

# Create the Linux App Service Plan
resource "azurerm_service_plan" "appserviceplan" {
  name                = "recipe-web-app-plan"
  location            = azurerm_resource_group.recipe.location
  resource_group_name = azurerm_resource_group.recipe.name
  os_type             = "Linux"
  sku_name            = "B3"
}

# Create the web app, pass in the App Service Plan ID
resource "azurerm_linux_web_app" "webapp" {
  name                = "recipe-web-app"
  location            = azurerm_resource_group.recipe.location
  resource_group_name = azurerm_resource_group.recipe.name
  service_plan_id     = azurerm_service_plan.appserviceplan.id
  https_only          = true
  site_config {
    application_stack {
      dotnet_version = "6.0"
    }
    minimum_tls_version = "1.2"
  }
}

output "webappurl" {
  value = "${azurerm_linux_web_app.webapp.name}.azurewebsites.net"
}
