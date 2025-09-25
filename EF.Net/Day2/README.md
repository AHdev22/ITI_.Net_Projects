# WinForms EF Core CRUD (Visual Studio)

This is a minimal Visual Studio WinForms solution scaffold demonstrating:
- EF Core (DbContext + Student entity)
- Generic repository pattern
- WinForms UI with DataGridView and CRUD operations

## Notes
1. Open the `WinForms_EF_CRUD.sln` in Visual Studio 2022/2023.
2. Edit the connection string inside `Models/UniversityContext.cs` to match your SQL Server instance.
3. Restore NuGet packages and build.
4. Run the app. The first run requires that the `Students` table exists in the configured database. You can create it using migrations or create the table manually.

## Files included
- `Program.cs`
- `WinFormsEfCrud.csproj`
- `Models/Student.cs`
- `Models/UniversityContext.cs`
- `Repositories/GenericRepository.cs`
- `Repositories/IRepository.cs`
- `Forms/MainForm.cs`
- `Forms/MainForm.Designer.cs`

This scaffold is intentionally simple; you can replace the `Student` and `UniversityContext` with your scaffolded models from `Scaffold-DbContext` if you prefer DB-first.

