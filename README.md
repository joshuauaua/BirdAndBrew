🍽️ BirdAndBrew – Restaurant Reservation & Menu API

BirdAndBrew is a restaurant management system built with ASP.NET Core Web API and Entity Framework Core using a code-first approach.

The project provides a backend API that handles reservations, tables, customers, administrators, and menus with JWT authentication for secure access.


📌 Features

🪑 Tables
	•	Store restaurant tables with capacity and table numbers.
	•	Check if a table is available before creating a reservation.

👤 Customers
	•	Store basic contact info (e.g. name, phone number) for people making reservations.

📅 Reservations
	•	Create reservations linked to both tables and customers.
	•	Each reservation includes date, time, number of guests.
	•	A reservation automatically blocks a table for 2 hours.
	•	Prevent overlapping reservations.
	•	Retrieve available tables for a specific date, time, and number of guests.

⏰ Example:
If a table is booked at 18:00, it is unavailable between 16:01 and 19:59. It becomes free again at 20:00.

📖 Menu
	•	Manage dishes with:
	•	Name
	•	Price
	•	Description
	•	IsPopular (bool)
	•	BildUrl (string URL to dish image)

🔑 Authentication (Administrators)
	•	Admins can log in with username + password.
	•	Successful login returns a JWT token.
	•	Only authenticated admins can manage:
	•	Reservations
	•	Tables
	•	Menu items

⚡ Performance
	•	Optimized EF Core queries.
	•	Asynchronous API methods for better scalability.


🚀 Getting Started

Follow these steps to run the project locally.

1️⃣ Clone the repository
2️⃣ Install dependencies

Make sure you have the following installed:
	•	.NET 8 SDK
	•	[SQL Server / SQLite / PostgreSQL] (depending on your setup)
3️⃣ Configure the database

Update appsettings.json with your database connection string.
4️⃣ Run the application
5️⃣ Explore the API
🔐 Authentication in Swagger
	1.	Log in with an admin user (POST /login) to receive a JWT token.
	2.	In Swagger, click Authorize (padlock button).
	3.	Enter your token in this format:
          Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
	4.	Now you can test protected endpoints.

⸻

🛠️ Tech Stack
	•	ASP.NET Core 8.0 Web API
	•	Entity Framework Core (Code-First Migrations)
	•	JWT Authentication
	•	Swagger / OpenAPI
	•	SQL Database (configurable)

⸻

🤝 Contributions are welcome!
If you’d like to improve the project, feel free to fork the repo and submit a PR.

