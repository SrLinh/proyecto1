DBStoreEntityFramework

Proyecto de consola en C# usando Entity Framework Core con PostgreSQL.

Pasos:
1. Crear la base de datos DBStore en pgAdmin.
2. Ejecutar database.sql.
3. Ejecutar insert_data.sql.
4. Abrir el proyecto en VS Code.
5. Revisar la cadena de conexión en Context/DbStoreContext.cs.
   Por defecto está así:
   Host=localhost;Port=5433;Database=DBStore;Username=postgres;Password=1234
6. Si tu PostgreSQL usa puerto 5432, cambia Port=5433 por Port=5432.
7. Ejecutar:
   dotnet restore
   dotnet run
