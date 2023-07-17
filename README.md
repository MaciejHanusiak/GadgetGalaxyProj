# Gadget Galaxy - Database Management Application for Electronics Store

![logo](https://github.com/MaciejHanusiak/GadgetGalaxyProj/assets/116427057/c4d0c98f-e19f-44e8-aaa5-456c267ee363)


Gadget Galaxy is a C# WPF application designed to serve as a Database Management tool for an electronics store. It utilizes SQLite as its backend database, enabling users to manage tables for Customers, Users, Orders, and Products efficiently. With a user-friendly interface and powerful functionalities, Gadget Galaxy simplifies the process of handling various aspects of the electronics store's database.

## Features

- Manage Customers: Add, edit, and remove customer records from the database.
- Manage Users: Control user access, add or remove user profiles, and update user information.
- Manage Orders: Keep track of orders, order details, and order statuses.
- Manage Products: Organize the store's inventory, add new products, and update existing ones.

## Installation and Setup

1. **Clone the Repository:**

   ```bash
   https://github.com/MaciejHanusiak/GadgetGalaxyProj.git
   ```

2. **Open the Project:**

   Open the Gadget Galaxy solution in Visual Studio or your preferred C# IDE.

3. **Install Dependencies:**

   Ensure you have the required NuGet packages installed, including SQLite.

4. **Build and Run:**

   Build the solution and run the application to start using Gadget Galaxy.

## Screenshots
Login view.

![image](https://github.com/MaciejHanusiak/GadgetGalaxyProj/assets/116427057/515a782e-835a-4b51-947f-c449f15a3f91)
 
Main window view.

![image](https://github.com/MaciejHanusiak/GadgetGalaxyProj/assets/116427057/e6b0cc48-b7cf-435c-9bf0-451815c7f974)

Orders managing view.

![image](https://github.com/MaciejHanusiak/GadgetGalaxyProj/assets/116427057/d78702f4-cf6d-4da6-9d26-56187bcd7937)

Users managin view.

![image](https://github.com/MaciejHanusiak/GadgetGalaxyProj/assets/116427057/f93f49f2-1589-4fb5-9037-dcce0742e97a)

Customers managing view.

![image](https://github.com/MaciejHanusiak/GadgetGalaxyProj/assets/116427057/bb7f9864-7346-4651-be10-74130295bbc8)

Products managing view.

![image](https://github.com/MaciejHanusiak/GadgetGalaxyProj/assets/116427057/45e788be-51d7-4be2-880b-e4b8bedbdc76)



## Database Schema

The application utilizes an SQLite database with the following schema:

### Customers Table

| Column Name | Data Type | Description |
| ----------- | --------- | ----------- |
| CustomerID  | INTEGER   | Primary Key |
| Name   | TEXT      | First name of the customer |
| Email       | TEXT      | Email address of the customer |
| Phone | TEXT      | Phone number of the customer |

### Users Table

| Column Name | Data Type | Description |
| ----------- | --------- | ----------- |
| UserID      | INTEGER   | Primary Key |
| Username    | TEXT      | Username for login |
| Password    | TEXT      | Password for login (hashed and salted) |

### Orders Table

| Column Name | Data Type | Description |
| ----------- | --------- | ----------- |
| OrderID     | INTEGER   | Primary Key |
| UserID      | INTEGER   | Foreign Key, referencing Users table |
| OrderDate   | TEXT      | Date of the order |

### Products Table

| Column Name  | Data Type | Description |
| ------------ | --------- | ----------- |
| ID    | INTEGER   | Primary Key |
| Name  | TEXT      | Name of the product |
| Price        | DECIMAL      | Product price |
| CategoryId  | TEXT      | Product description |

### Category Table

| Column Name | Data Type | Description |
| ----------- | --------- | ----------- |
| CategoryId     | INTEGER   | Primary Key |
| Name   | TEXT      | Date of the order |


## How to Use

1. **Launch the Application:**

   After successfully running the application, you will be presented with the main dashboard.
   Sample login and password for logging in:
   
        Username = "User1", Password = "password1"
   
        Username = "JohnDoe", Password = "pass123"
   
        Username = "JaneSmith", Password = "secret456"

3. **Manage Customers:**

   Click on the "Customers" tab to view, add, edit, or remove customer records.

4. **Manage Users:**

   Click on the "Users" tab to manage user accounts and their permissions.

5. **Manage Orders:**

   Access the "Orders" tab to handle orders and their statuses.

6. **Manage Products:**

   Use the "Products" tab to manage the electronics store's inventory.


