# Mvc test
the project was created in dotnet core 3.1 and need installed docker to run


# Create migration database
```
dotnet ef migrations add Initial --context ApplicationDbContext
```

# Create a SQL Server instance using docker
```
docker-compose up --build
```

# Build the docker file and make sure it run

```
docker build -t mvctest .
docker run -p 8008:80 mvctest
```

# run application
```
http://localhost:8008/
```