# 🌱 AgriIntel Advisory System

## 📌 Overview

**AgriIntel Advisory System is a multi-user, API-driven web application built using ASP.NET Core that enables seamless interaction between farmers and agricultural experts.

The system is designed with a layered architecture and provides secure, role-based access for different users including Admin, Expert, Farmer, Staff, and Kisaan Kendra.

It exposes RESTful APIs for handling core functionalities such as query management, expert consultation, soil test requests, and government scheme applications, with JWT-based authentication ensuring secure communication.

The backend is developed using C# (.NET Core), Entity Framework, and SQL Server, while the frontend is built using HTML, CSS, Bootstrap, and JavaScript.**.

---

## 🎯 Objectives

- Design and develop a scalable, multi-user web application using ASP.NET Core
- Implement RESTful APIs to handle core functionalities like query management, consultation, and scheme applications
- Enable real-time interaction between farmers and experts through structured API endpoints
- Integrate database-driven modules for soil testing, user management, and application tracking
- Implement JWT-based authentication and role-based authorization for secure access control
- Build a system capable of handling multiple user roles and workflows efficiently
- Ensure clean architecture and separation of concerns using layered design patterns

---

## 🚜 Key Features

### 👨‍🌾 Farmer Services
- Consumes RESTful APIs for expert consultation, query submission, and soil test requests
- Tracks applications for Crop Insurance (PMFBY) and PM Kisan Samman Nidhi Scheme
- Accesses content and tips through API-driven endpoints


---

### 👨‍🔬 Expert Services
- Manages queries, soil tests, and advice via role-based API endpoints
- Publishes articles and participates in field visits using secure API calls
- Supports multi-role access and workflow management


---

### 🏢 Kisaan Sewa Kendra
- Register farmers  
- Assist farmers in using the system  
- Check application status  
- Act as a bridge between farmers and the system  

---

### 🛠️ Admin Panel
- Manage farmers, experts, and staff  
- Assign experts for field visits  
- Monitor system activities  
- Manage articles and soil test records  
- Handle user issues and requests  

---

## 🏗️ Project Architecture

The project follows a **layered architecture**:

- **Controller Layer** – Handles HTTP requests  
- **Service Layer** – Business logic  
- **Repository Layer** – Database operations  
- **Interface Layer** – Abstraction for services/repositories  
- **Middleware** – Handles HTTP session & security  

---

## 🔐 Security Features

- JWT-based authentication for all users to ensure secure access to APIs
- Role-based access control (Admin, Expert, Farmer, Staff, Kisaan Kendra)  
- Middleware for HTTP session validation  
- Prevents unauthorized access via direct URL entry  
- Secure login system for all users  

---

## 🧪 Technologies Used

### 🔙 Backend
- C# (.NET Core / ASP.NET Web API) – RESTful API development, JWT authentication, multi-user role management
- Layered Architecture (Controller–Service–Repository–Interface) – Separation of concerns and clean code structure
- Entity Framework Core – ORM for database integration
- Visual Studio – Development and debugging
  
### 🎨 Frontend

- HTML5, CSS3, Bootstrap, JavaScript – Responsive UI for multiple user roles
  
### 🗄️ Database
- SQL Server – Relational database with stored procedures and data integrity
  
### 🔧 Tools & Utilities
- GitHub – Version control and project management
- Swagger – API documentation and testing

  
---

### 📊 Future Enhancements

- 📱 Mobile app integration  
- 🤖 AI-based crop recommendation system  
- 🌦️ Weather API integration  
- 🌐 Multi-language support  
- 💬 Real-time chat with experts  
- 🌱 IoT-based soil monitoring
  
---
🖥️ User Interface (UI)

### 🏠 Home Page
<img width="1893" height="799" alt="image" src="https://github.com/user-attachments/assets/6ad4f370-20f0-482d-8f21-32c19d24c174" />
<img width="1802" height="810" alt="image" src="https://github.com/user-attachments/assets/20ecead6-e157-46f0-87ce-0fd9eda5a86c" />
<img width="1798" height="619" alt="image" src="https://github.com/user-attachments/assets/e0a16a8d-9099-4ec2-bc4d-721812049587" />

---
### Our Services
<img width="1763" height="822" alt="image" src="https://github.com/user-attachments/assets/c4aa0c35-a2fa-41b7-974c-45809608e623" />
<img width="1762" height="805" alt="image" src="https://github.com/user-attachments/assets/50b813e9-c0d4-45b7-937c-577240aee77a" />

---
### Article
<img width="1793" height="799" alt="image" src="https://github.com/user-attachments/assets/8cb1476b-247a-47b8-be89-2c2967a83a1d" />
<img width="1705" height="679" alt="image" src="https://github.com/user-attachments/assets/19907b0f-6b9a-4fce-b763-90ae8033cb88" />

---
### Registeration
---
### Farmer Registeration

**Personal Details**
<img width="1533" height="825" alt="image" src="https://github.com/user-attachments/assets/ae7cf164-8508-426c-a0a9-94fd586c2828" />

**Other Details**
<img width="1646" height="806" alt="image" src="https://github.com/user-attachments/assets/b487f43e-f0aa-4317-a3d5-3de3b352ad1b" />

---
### Expert Registeration

**Personal Details**
<img width="1614" height="804" alt="image" src="https://github.com/user-attachments/assets/7065db89-93f8-41a8-89c2-468e15ec4e94" />

**Other Details**
<img width="1612" height="835" alt="image" src="https://github.com/user-attachments/assets/340fe9d2-a2b9-4a95-bcb4-e3f302f7c64d" />

---
### Login Page
<img width="1908" height="609" alt="image" src="https://github.com/user-attachments/assets/7e516c7f-0ead-4983-af28-afb0b8115cc9" />

---
### Admin Login
<img width="1874" height="804" alt="image" src="https://github.com/user-attachments/assets/20dabf0d-5df2-4360-a996-ca3e25414c6f" />

** Admin Panel**
<img width="1911" height="805" alt="image" src="https://github.com/user-attachments/assets/c0829c9e-e3ce-407c-b5d1-982959bfc351" />

---
### Farmer Panel
<img width="1910" height="741" alt="image" src="https://github.com/user-attachments/assets/93432eba-94b3-488c-8865-5c087de2990a" />

---
### Expert Panel
<img width="1850" height="793" alt="image" src="https://github.com/user-attachments/assets/c9a4296a-b08a-432c-a493-5dd61cb0cb4e" />

--- 
### Staff Panel
<img width="1870" height="812" alt="image" src="https://github.com/user-attachments/assets/c8c6cfec-5d50-453c-bab5-25e15536dd02" />

---
### Kisan Kendra Panel
<img width="1873" height="808" alt="image" src="https://github.com/user-attachments/assets/1806fbde-197d-4fb7-bb2c-1543c10a745f" />

---
🙌 Acknowledgement

This system aims to empower farmers by providing accessible agricultural knowledge and expert support, contributing to smarter and more sustainable farming practices.
