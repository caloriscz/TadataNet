# TadataNet

Bookmark manager with many features written in .NET6

## TadataNet.Api

JWT Web Api with role authorization

### Managing user secrets

Showing secrets.json file is being done by selecting project by right clicking and then selecting Manage User Secrets. Every project has its own secrets.json file for it to work.

#### Set the secrets

```
cd TadataNet.Api
dotnet user-secrets init
dotnet user-secrets set "AppSettings:SmtpUser" "your@email"
dotnet user-secrets set "AppSettings:SmtpPass" "yourpassword"
dotnet user-secrets set "AppSettings:SmtpHost" "yourhost"
dotnet user-secrets set "AppSettings:SmtpPort" "587"
dotnet user-secrets set "AppSetttings:RefreshTokenTTL" "yourrefreshsecret"
dotnet user-secrets set "AppSettings:EmailFrom" "your@email"
dotnet user-secrets set "ConnectionStrings:WebAPiDatabase" "yourconnectionstring"
```

```

```

#### List the secrets

```

dotnet user-secrets list

```

## TadataNet.Common

Class library for other projects in solution

```

```
