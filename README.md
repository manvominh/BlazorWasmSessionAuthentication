# Summary information about BlazorWasmSessionAuthentication web application
1. This web application desmontrates the way to authorize and authenticate user in blazor web assembly with Clean Architecture.
2. This web application use some Nuget Packages as following:
   - Microsoft.EntityFrameworkCore
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools
   - Microsoft.AspNetCore.Authentication.JwtBearer
   - MediatR
   - System.IdentityModel.Tokens.Jwt
   - Blazored.SessionStorage
   - Microsoft.AspNetCore.Components.Authorization
3. Main behaviour of this web application:
   - Home page: all users can see this page.
   - Users have 2 records in database with roles : Administrator + User.
   - Login page for user to authorize.
   - Based on login information, logged user can have role Administrator or User or both will see the pages:
       . Administrator or User will see and access Counter page
       . Administrator role will see and access Weather page
