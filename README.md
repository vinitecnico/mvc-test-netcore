# Mvc test
the project was created in dotnet core 3.1 and need installed docker to run


# Create migration database
```
dotnet ef migrations add Initial --context ApplicationDbContext
```

# Create docker build and run application
```
docker-compose up --build
```

# run application
```
http://localhost:8090
```