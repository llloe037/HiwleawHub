# HiwleawHub (หิวแล้วฮับ) 🍔

HiwleawHub is a comprehensive restaurant discovery and management platform. The project is designed with a separate interface architecture to provide tailored experiences for both customers and restaurant owners, all connected through a centralized backend server.

## 🏗️ Project Architecture (Monorepo)

This repository contains the complete ecosystem of the HiwleawHub platform, divided into three main components:

1. HiwleawHubServer (Backend): The core API and logic server handling data processing, database connections, and communication between the customer and admin applications.
2. HiwleawHubAdminApp (Restaurant Interface): A dedicated application for restaurant owners to manage their operations.
3. HiwleawHubCustomerApp (Customer Interface): A user-friendly application for everyday customers to browse menus and review restaurants.

## ✨ Features

### 🍽️ For Customers (CustomerApp)
* Browse available restaurants and view detailed menus.
* Write and read restaurant reviews.

### 🏪 For Restaurants (AdminApp)
* Menu Management: Add, edit, or remove menu items with images.
* Review Dashboard: View customer feedback and ratings.

## 💻 Tech Stack
* Language: C#
* Framework: .NET / ASP.NET (Server) / Windows Forms (Client Apps)
* Architecture: Client-Server Architecture
* Database: PostgreSQL
* Version Control: Git & GitHub

## 🚀 Getting Started

### Prerequisites
* Visual Studio 2022 (or compatible IDE)
* .NET SDK installed
* PostgreSQL Database installed locally

### Installation & Run
1. Clone this repository using command: git clone https://github.com/llloe037/HiwleawHub.git
2. Set up the Database: Create a new database in PostgreSQL, then restore or execute the script from the `HiwleawHubDb.sql` file (located in the Database/Scripts folder) to initialize the required tables and sample data.
3. Open the solution files (.sln) in Visual Studio.
4. Start the Server first: Open HiwleawHubServer.sln, configure your PostgreSQL database connection string in appsettings.json, and run the project.
5. Run the Client Apps: Once the server is running, you can open and run HiwleawHubAdminApp.sln or HiwleawHubCustomerApp.sln to interact with the platform.

## 👨‍💻 Author
Natthanon Limlek - Computer Science Student at Srinakharinwirot University (GitHub: llloe037)
