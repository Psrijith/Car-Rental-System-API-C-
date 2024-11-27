# 🚗 Car Rental System API

This is a **Car Rental System API** built with **C#**, **Entity Framework (EF)**, and follows RESTful principles. The API provides functionalities for managing a fleet of cars, user registration, car rentals, and authentication.

---

## 📖 Features
- **Car Management**:
  - Add, update, and delete cars (Admin only).
  - View available cars.
- **User Management**:
  - User registration and login.
  - Role-based authorization (Admin/User).
- **Car Rentals**:
  - Rent cars and check availability.
  - Calculate rental prices based on duration.
- **Authentication**:
  - JWT-based authentication for securing endpoints.
- **Email Notifications**:
  - Sends a booking confirmation email upon successful car rental.

---

## 🛠️ Tech Stack
- **Backend**: C#, ASP.NET Core
- **Database**: Entity Framework Core with SQL Server
- **Authentication**: JWT (JSON Web Tokens)
- **Email Service**: SendGrid (for notifications)
- **Testing**: Postman

---

## 📂 Folder Structure
![image](https://github.com/user-attachments/assets/aaeb896e-d8fe-4989-ad2e-26cbc2a3d887)  

## Project Flow
![image](https://github.com/user-attachments/assets/e4a66288-f632-40bd-894d-5d12bfbc093c)



# Testing and Outputs

## Swagger UI
- Here is an image of the Swagger UI showing the available API endpoints:
![image](https://github.com/user-attachments/assets/ef5a6e8e-ba5d-4d4c-b66d-13c768eb84bf)


## 1. Registering with User Role
   - Here is the first screenshot showing the user registration process with the user role.

   ![Registering with User Role](https://github.com/user-attachments/assets/608ce06b-6c86-43e6-9cb9-43c5d3bc288e)

   - The following image shows the successful Login and generates a token.

   ![Registration Success](https://github.com/user-attachments/assets/1dbf45ed-4538-471f-827a-fd1cacaa85aa)

   - Another image displaying that User can not Add Cars

   ![User Role Confirmation](https://github.com/user-attachments/assets/beb6fffa-3885-4c6d-b484-f0358644d48f)

---

## 2. Registering with Admin Role
   - Now, the registration with the **Admin Role** is shown below.

   ![Registering with Admin Role](https://github.com/user-attachments/assets/f72dc861-8cb0-41c5-b80a-cfff70ca9b6d)

---

## 3. Logging in Using Admin Credentials
   - The following image shows the **Login** process using the admin credentials, which results in the generation of a **JWT Token**.

   ![Admin Login and Token Generation](https://github.com/user-attachments/assets/5f2e12ad-e4ea-4896-a83a-fe5519a0bac9)

---

## 4. Testing POST Method with Authorization Header
   - Once the token is generated, we use the **POST** method in **Postman** to send a request with the authorization token in the header.
   - Below is the image displaying the proper header setup in Postman:

   ![POST Method with Header](https://github.com/user-attachments/assets/2aadc63e-104c-4983-b49c-aa19cee65ad7)

   - This shows a response confirming the request was successful.

   ![Response from POST Request](https://github.com/user-attachments/assets/0de21ff7-bd44-406e-925f-c465bbaf5fc2)

---

## 5. Renting a Car and Getting Notifications
   - Now, we move on to the functionality of **renting a car**. The following images show the process:
   
   - **Car Renting Process** which includes availability checking :

   ![Renting a Car and Getting Notification](https://github.com/user-attachments/assets/594bf941-316a-44df-9dd6-e2e765340a14)

   - The **Car Rental Confirmation** is shown in the next image.

   ![Car Rental Confirmation](https://github.com/user-attachments/assets/891ad3ca-7a49-454c-9da5-b7ebf6018a84)

   - This image displays a **successful notification** after renting a car.

   ![Success Notification](https://github.com/user-attachments/assets/1df81a21-913d-4bef-9340-df771747db1c)

   - Another **Confirmation Notification** via Email appears, confirming the car rental.

   ![Confirmation Notification](https://github.com/user-attachments/assets/51e2218f-afad-40da-a5fe-fc972eb050bc)

---







