<h1>🎓 ASP.NET Core Master-Detail Student Information</h1>

<p>This project demonstrates the implementation of a Master-Detail relationship in ASP.NET Core for managing student information, including their courses and details using Entity Framework Core and MVC pattern.</p>

<h2>📑 Table of Contents</h2>
<ul>
  <li><a href="#features">Features</a></li>
  <li><a href="#technologies">Technologies</a></li>
  <li><a href="#getting-started">Getting Started</a></li>
  <li><a href="#database-setup">Database Setup</a></li>
  <li><a href="#configuration">Configuration</a></li>
  <li><a href="#usage">Usage</a></li>
  <li><a href="#screenshots">Screenshots</a></li>
  <li><a href="#contributing">Contributing</a></li>
  <li><a href="#license">License</a></li>
</ul>

<h2 id="features">🚀 Features</h2>
<ul>
  <li>Manage Student and Course records with a master-detail interface.</li>
  <li>RESTful API endpoints for CRUD operations.</li>
  <li>Entity Framework Core Code First approach for database handling.</li>
  <li>Responsive design using Bootstrap.</li>
</ul>

<h2 id="technologies">🛠️ Technologies</h2>
<ul>
  <li><strong>Frontend:</strong> ASP.NET Core MVC, Razor Pages, Bootstrap</li>
  <li><strong>Backend:</strong> ASP.NET Core Web API</li>
  <li><strong>Database:</strong> SQL Server</li>
  <li><strong>ORM:</strong> Entity Framework Core</li>
</ul>

<h2 id="getting-started">⚙️ Getting Started</h2>

<h3>🔧 Prerequisites</h3>
<ul>
  <li><a href="https://visualstudio.microsoft.com/" target="_blank">Visual Studio 2019 or later</a></li>
  <li><a href="https://dotnet.microsoft.com/download/dotnet/5.0" target="_blank">.NET 5.0 or later</a></li>
  <li><a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads" target="_blank">SQL Server or SQL Server Express</a></li>
</ul>

<h2 id="database-setup">📂 Database Setup</h2>
<ol>
  <li>Clone the repository:</li>
  <pre><code>https://github.com/MdAshikur-Rahman-Ashik/ASP.Net_CoreMasterDetails_Student_Information</code></pre>
  
  <li>Navigate to the project directory:</li>
  <pre><code>cd ASP.Net_CoreMasterDetails_Student_Information</code></pre>
  
  <li>Update the connection string in <code>appsettings.json</code> to point to your SQL Server instance.</li>
  
  <li>Run the following commands to create the database and seed initial data:</li>
  <pre><code>
  dotnet ef migrations add Init
  dotnet ef database update
  </code></pre>
</ol>
<h3>📦 NuGet Packages</h3>
<p>The following packages need to be installed via NuGet:</p>
<ul>
  <li><code>Microsoft.EntityFrameworkCore</code> (Version: 8.0.8)</li>
  <li><code>Microsoft.EntityFrameworkCore.SqlServer</code> (Version: 8.0.8)</li>
  <li><code>Microsoft.EntityFrameworkCore.Tools</code> (Version: 8.0.8)</li>
 
 
</ul>
<h2 id="configuration">🔧 Configuration</h2>
<p>The following files and folders are key to the configuration of the application:</p>
<ul>
  <li><strong>Startup.cs:</strong> Configures services, middleware, and routing.</li>
  <li><strong>appsettings.json:</strong> Holds the database connection string and other application settings.</li>
</ul>

<h2 id="usage">💻 Usage</h2>
<ul>
  <li>Create, read, update, and delete student and course records.</li>
  <li>Navigate to the <code>Students</code> or <code>Courses</code> section from the navigation bar to manage data.</li>
</ul>



<h2 id="contributing">🤝 Contributing</h2>
<p>Contributions are welcome! If you have suggestions for improvements or find issues, feel free to create an issue or submit a pull request.</p>

<h2 id="license">📝 License</h2>
<p>This project is licensed under the MIT License. See the <a href="LICENSE" target="_blank">LICENSE</a> file for more details.</p>

<h2>📧 Contact</h2>
<p>For any questions or suggestions, please contact:</p>
<ul>
  <li><strong>Name:</strong> Md Ashikur Rahman Ashik</li>
  <li><strong>Email:</strong> <a href="mailto:mohammadashikidb@gmail.com">mohammadashikidb@gmail.com</a></li>
</ul>

![Screenshot 1](https://github.com/user-attachments/assets/b9271e9c-37f5-4ba1-aeeb-681519892be9)
![Screenshot 2](https://github.com/user-attachments/assets/5fb1a00c-5286-41ac-be93-908a2197c917)
![Screenshot3](https://github.com/user-attachments/assets/7f31e0fb-3f12-4958-90d5-06ccf98e8508)
