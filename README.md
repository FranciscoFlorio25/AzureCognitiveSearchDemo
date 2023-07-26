In app.settings:

{
  "ConnectionStrings": {
    "Default": "{Put here connection string of the database}"
  },
  "SearchClient": {
    "SearchUri": "https://ciscocognitivesearch.search.windows.net {Url of the cognitive search}",
    "IndexName": "azuresql-index {name of the index}",
    "SearchKey": "{Place here the key of the cognitive searche service}"
  },
  //Regular stuff of the app.settings
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
