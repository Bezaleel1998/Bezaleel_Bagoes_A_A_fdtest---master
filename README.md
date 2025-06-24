📘 Book Management App — Razor Pages (.NET)

A web-based book management system with full authentication, user registration, password reset, and CRUD functionality for books. Includes:

      👤 Auth (Register, Login, Forgot/Reset Password, Email Verification)
      📚 Public Book Viewer & Private Book Manager
      🌙 Dark/Light Theme with Toggle
      ✅ Responsive Razor Pages

⚙️ Prerequisites

Before starting, make sure you have:

  ♾️ Visual Studio 2022 or newer (Community or Code is fine ✅)
  
  </> ASP.NET and Web Development (choose between .NET SDK 6.0 to .Net SDK 9.0 in installation is OK) 
  
  This project using net8.0
  
  🛢️ MySQL Server installed and running
  
  Optional: HeidiSQL or MariaDB Workbench for managing DB (is ok too).

🧰 Visual Studio Setup

When installing or modifying Visual Studio (Community):

  ✅ Select these Workloads:
  
      ASP.NET and web development
      .NET Desktop Development

  ✅ Optional: 
  
      IntelliCode
      all .Net SDK
      .Net Framework 4.8.1 development tools

   ![{D42B49EB-0022-4DD4-88D8-F5F8FDADB186}](https://github.com/user-attachments/assets/538fcf6c-fcf4-49e3-bcd0-937dba7a799d)


📌 Also check:
     Razor Pages support
     Entity Framework Core tooling

🧾 Installation Steps
1. 📦 Clone the project using git bash terminal / windows powershells.

        git clone https://github.com/Bezaleel1998/Bezaleel_Bagoes_A_A_fdtest.git

   now open the folder location of the cloned project.

2. 🗃️ Setup the MySQL Database
   
   Import the provided SQL file:
   
   sql file name : bezaleel_bagoes_a_a_fdtest.sql
   
   Open your Xampp Control Panel and check list this services :

   ![{35537B35-56B0-4F2C-BF42-FABBE1D76B49}](https://github.com/user-attachments/assets/94f213d2-6179-449b-b2bd-930d2f2731a8)

   and start the services for both of them
   
   after that go to your browser and put this link :
   
       http://localhost/phpmyadmin/index.php?route=/server/databases

   Choose Import, and input the .sql file in this section :

   ![{000E4B5A-A5D4-43E1-99A5-D79C18168918}](https://github.com/user-attachments/assets/67343a81-1d1f-42de-9b55-4550d9012b82)

   Then press Import button.
   
   Make sure you have a user and database set up after all process completed with out error. You can use default root with empty password for development.

4. ⚙️ Configure appsettings.json
   
        {
          "ConnectionStrings": {
            "DefaultConnection": "server=localhost;port=3306;database=your_db_name;user=root;password="
          }
        }
   
    Update your_db_name with the imported database name. Make sure your MySQL user has access.

5. 💻 Run the App
   
    Use Visual Studio:
   
    Open the .sln file
   
    Set launchSettings.json to use https://localhost:xxxx

    Press F5 or click ▶ Run with Https

    Or use CLI:

        dotnet run

Then open in your browser (for me always auto open in browser when Run pressed):

👉 https://localhost:7285/ or similar


🎨 Features Highlight

    🔐 Secure authentication (email verification, reset)
    📖 Book listing with filtering, rating, pagination
    🌓 Toggleable dark/light mode

📂 Folder Structure

    Data/                    # Models of the tables and AppDBContext
    Helpers/                 # All Useful function class.
    Filters/                 # Require Login Attributes
    Shared/                  # Main Webview where i put link to css and js in _Layout.cshtml
    Pages/
     ├── Auth/               # Login, Register, Forgot, Verify
     ├── Home/               # Index, UserList
     ├── BookList/           # Landing + Authenticated Book CRUD
    wwwroot/
     ├── css/BookPageStyle.css
     ├── css/LoginStyle.css
     ├── css/main.css
     ├── css/site.css
     ├── js/theme-toggle.js
   
🙏 Credits

Developed by Bezaleel Bagoes A.A

For demo, learning, or starter template projects.
