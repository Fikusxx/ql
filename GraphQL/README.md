# How to use:


### 1. Run docker-compose up -d

### 2. Run /seed request to seed data 

### 3. Proceed to localhost/graphql

### 4. Tests
- initial snapshot is created in "__snapshots__" folder
- each subsequent snapshot <b>IF THERE ARE ANY CHANGES</b> is placed in "__snapshots__/__MISMATCH__" folder
- thus should be copied to root folder and override previous schema to apply changes

### 5. Schema
- go to /graphql and check "Schema Definition"
- run "dotnet run -- schema export --output ./schema.graphql"


#### docs https://github.com/ChilliCream/graphql-platform/tree/main/website/src/docs/hotchocolate/v14
