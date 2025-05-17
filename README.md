# Task And Team Management

A cleanly structured Task and Team Management system built using **ASP.NET Core Web API**, following **Clean Architecture** principles. It uses **FluentValidation** for validating DTOs and **Entity Framework Core** for database operations with **SQL Server** as the backend database.

---

## 🛠️ Tech Stack

- **Backend Framework:** ASP.NET Core Web API
- **Architecture:** Clean Architecture
- **Validation:** FluentValidation
- **ORM:** Entity Framework Core
- **Database:** Microsoft SQL Server

---

## 🔐 Feature: Authentication

### ✅ User Registration
- Accepts user registration via DTO.
- Validates input using FluentValidation.
- Stores user data securely in the database.

### 🔐 JWT Token-based Login
- Authenticates user credentials.
- Generates and returns JWT access tokens upon successful login.
- Secure token-based authorization.

---

## 👤 Feature: User Management

### ➕ Add User with Role
- Adds new users along with their associated roles.
- Ensures role existence and valid assignment.

### ✏️ Update User Information
- Update fields like name, email, and role.
- Validates DTO before processing.

### ❌ Delete User by ID
- Deletes user record by provided ID.
- Handles user not found scenarios gracefully.

### 🔍 Get User by ID
- Retrieves specific user information based on ID.

### 📄 Get All Users
- Returns a list of users with the following features:
  - 🔎 Searching by name or email
  - 🔃 Sorting by fields (e.g., name, created date)
  - 📄 Pagination for large datasets

---

## 📦 Folder Structure

