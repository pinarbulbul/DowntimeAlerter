# DowntimeAlerter
A web application to monitor target applications’ health

To Start
1.  @appsetting.json Change ConnectionStrings and  MSSqlServer connectionString for Serilog if you want
```
  "ConnectionStrings": {
    "DatabaseConnection": "Server=(localdb)\\mssqllocaldb;Database=DowntimeAlerterDB;Trusted_Connection=True;MultipleActiveResultSets=true",
    "HangfireConnection": "Server=(localdb)\\mssqllocaldb;Database=DowntimeAlerterDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
 ```
 
 ```
  "Serilog": {
    "Using": [],
    "MinimumLevel": {
      "Default": "Warning",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning",
        "Hangfire": "Warning"
      }
    },
    "Enrich": [
      "FromLogContext",
      "WithMachineName",
      "WithProcessId",
      "WithThreadId"
    ],
    "WriteTo": [
      {
        "Name": "MSSqlServer",
        "Args": {
          "connectionString": "Server=(localdb)\\mssqllocaldb;Database=DowntimeAlerterDB;Trusted_Connection=True;MultipleActiveResultSets=true",
          "tableName": "Log",
          "autoCreateSqlTable": true
        }
      }
    ]
  }
  ```
  
2.  @appsetting.json Configure SmtpUser and SmtpPass attributes NotificationSettings  
Make sure to enable IMAP for GMail email addresses

```
"NotificationSettings": {
    "SmtpHost": "smtp.gmail.com",
    "SmtpPort": "587",
    "SmtpUser": "admn.downtimealerter@gmail.com",
    "SmtpPass": "******"
  }
  
```

3. Create migrations for database
```
dotnet ef migrations add "init" --context ApplicationIdentityDbContext --startup-project DowntimeAlerter.Web --project DowntimeAlerter.EntityFrameworkCore --output-dir ApplicationIdentityDb\Migrations

dotnet ef migrations add "init" --context TargetDbContext --startup-project DowntimeAlerter.Web --project DowntimeAlerter.EntityFrameworkCore --output-dir TargetDb\Migrations
```

4. Update database
```
dotnet ef database update --context ApplicationIdentityDbContext --startup-project DowntimeAlerter.Web --project DowntimeAlerter.EntityFrameworkCore

dotnet ef database update --context TargetDbContext --startup-project DowntimeAlerter.Web --project DowntimeAlerter.EntityFrameworkCore
```

5. Admin user is created with migration:
```
Admin: admn.downtimealerter@gmail.com
Password: Admin12*
```
**Logs and Hangfire Links are shown only to Administrator role.
