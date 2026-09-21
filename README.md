# ASP.NET Core MVC Identity Authentication

A simple **ASP.NET Core MVC Authentication & User Management** project built using **ASP.NET Core Identity, Entity Framework Core, and SQL Server**.

This project demonstrates how to implement user registration, login, logout, password validation, authentication state, and form validation in an ASP.NET Core MVC application.

## 🚀 Features

* User Registration
* User Login
* User Logout
* ASP.NET Core Identity integration
* Password hashing through ASP.NET Core Identity
* Email validation
* Unique email validation
* Confirm Password validation
* Remember Me functionality
* Login state handling
* Authentication middleware
* Server-side form validation
* Custom password requirements
* SQL Server database integration
* Entity Framework Core Identity Store
* Bootstrap-based authentication UI

## 🛠️ Technologies Used

* **C#**
* **ASP.NET Core MVC**
* **ASP.NET Core Identity**
* **Entity Framework Core**
* **SQL Server**
* **Bootstrap**
* **Razor Views**
* **Data Annotations**

## 📂 Project Structure

```text
Identity
│
├── Controllers
│   ├── HomeController.cs
│   └── LoginController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Models
│   ├── Users.cs
│   └── ErrorViewModel.cs
│
├── ViewModel
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
│
├── Views
│   ├── Home
│   ├── Login
│   │   ├── Login.cshtml
│   │   └── Register.cshtml
│   └── Shared
│
├── Program.cs
└── appsettings.json
```

## 🔐 Authentication Flow

### 1. Registration

The user enters:

* Name
* Email
* Password
* Confirm Password

The `RegisterViewModel` validates the submitted data.

The `LoginController` creates a `Users` object and uses:

```csharp
userManager.CreateAsync(user, password);
```

ASP.NET Core Identity handles password hashing and stores the user information in the Identity database.

### 2. Login

The user provides their email and password.

The application uses:

```csharp
signInManager.PasswordSignInAsync(
    model.Email,
    model.Password,
    model.Rememberme,
    false
);
```

If authentication succeeds, the user is redirected to the Home page.

### 3. Logout

The application checks whether the user is currently signed in and then uses:

```csharp
await signInManager.SignOutAsync();
```

The user is then redirected to the Login page.

## 👤 UserManager

`UserManager<Users>` is used for managing application users.

In this project it is mainly used during registration:

```csharp
var result = await userManager.CreateAsync(u, model.Password);
```

ASP.NET Core Identity takes care of password hashing and user creation.

## 🔑 SignInManager

`SignInManager<Users>` is responsible for authentication-related operations.

This project uses it for:

* Login
* Logout
* Checking whether a user is signed in

Example:

```csharp
signInManager.IsSignedIn(User)
```

## ⚙️ Identity Configuration

The project configures ASP.NET Core Identity with custom password requirements:

```csharp
option.Password.RequiredLength = 8;
option.Password.RequireNonAlphanumeric = true;
option.Password.RequireUppercase = true;
option.Password.RequireLowercase = true;
option.Password.RequireDigit = true;
```

The project also requires unique email addresses:

```csharp
option.User.RequireUniqueEmail = true;
```

## 🔄 Authentication Middleware

Authentication and authorization are configured in `Program.cs`:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

`UseAuthentication()` identifies the currently logged-in user.

`UseAuthorization()` handles access permissions for protected resources.

## 📝 Model Validation

The project uses Data Annotation attributes for validation.

Example:

```csharp
[Required]
[EmailAddress]
public string Email { get; set; }
```

The registration form also validates password confirmation:

```csharp
[Compare("Password")]
public string ConfirmPassword { get; set; }
```

## 🗄️ Database

The project uses **SQL Server** with **Entity Framework Core**.

ASP.NET Core Identity creates and manages the required Identity tables through the configured `AppDbContext`.

Typical Identity tables include:

* AspNetUsers
* AspNetRoles
* AspNetUserRoles
* AspNetUserClaims
* AspNetUserLogins
* AspNetUserTokens
* AspNetRoleClaims

## ▶️ How to Run

### 1. Clone the repository

```bash
git clone https://github.com/Shreyashmoon123/ASP.NET-Core-MVC-Identity-Authentication.git
```

### 2. Open the project

Open the project in **Visual Studio**.

### 3. Configure SQL Server

Update the connection string in:

```text
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "constr": "Server=YOUR_SERVER;Database=IdentityDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 4. Apply migrations

Run the following commands in Package Manager Console:

```powershell
Add-Migration InitialCreate
Update-Database
```

### 5. Run the application

Press:

```text
Ctrl + F5
```

or run the project from Visual Studio.

## 📚 Concepts Practiced

This project helped practice the following ASP.NET Core MVC and Identity concepts:

* ASP.NET Core MVC
* Controllers
* Razor Views
* ViewModels
* Data Annotations
* Model Validation
* Entity Framework Core
* SQL Server
* ASP.NET Core Identity
* UserManager
* SignInManager
* Authentication
* Authorization
* Password Hashing
* Remember Me
* Authentication Middleware
* Dependency Injection
* Identity Database

## 🎯 Learning Objective

The main objective of this project is to understand how **ASP.NET Core Identity can be integrated with an MVC application to implement a secure user authentication system** without manually handling password storage and authentication logic.

## 👨‍💻 Author

**Shreyash Katiyar**

GitHub: `Shreyashmoon123`

---

⭐ If you find this project useful, feel free to explore the code and learn from it.
