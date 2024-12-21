## 📚 Repository Structure

### 🧩 **Entity Layer**
- Contains the `HabitRecord` class that encapsulates the core data structure used throughout the project.
- Demonstrates:
  - Creating immutable properties with private setters.
  - Constructor parameter validation.
  - Overriding `ToString()` for custom string representation.

### 📜 **Interfaces Layer**
- Includes the contract definitions for `IDatabaseService` and `IHabitService`.
- Demonstrates:
  - Interface-based design for separation of concerns.
  - Preparing for dependency injection.

### 🛠️ **Services Layer**
- Contains the business logic and database interaction.
- Demonstrates:
  - Using SQLite for database operations.
  - Implementing CRUD operations with parameterized queries for security.
  - Layered architecture with encapsulated logic.

### 🖥️ **Console Application Layer**
- Implements a user-friendly console menu to interact with the application.
- Demonstrates:
  - Console UI design.
  - Handling user inputs with validation and error handling.
  - Using LINQ for querying and displaying data.

---

## ✨ Key Features

### 1️⃣ Comprehensive Habit Management
- View, add, update, and delete habit records with validation and security.
- Ensure data integrity through robust error handling and validations.

### 2️⃣ Advanced SQLite Integration
- Efficient database connection handling with `using` statements.
- Secure parameterized queries to prevent SQL injection attacks.
- Full implementation of CRUD operations for data persistence.

### 3️⃣ Modular and Scalable Design
- Clear separation of concerns with distinct entity, service, and UI layers.
- Interface-driven architecture to facilitate dependency injection and testing.


---

## 🛠️ Setup Instructions

### ✅ Prerequisites
- .NET 6.0 or later installed on your system.
- SQLite database engine.

### 🚀 Steps to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/ignjatradojicic/csharp-learning-journey/HabitTracker.git
   ```
2. Navigate to the project directory:
   ```bash
   cd learningcsharp-learning-journey
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

---

## 🌟 Future Enhancements
- Add unit tests for service and database layers.
- Implement a graphical user interface (GUI).
- Expand database features (e.g., reporting and analytics).
- Optimize performance for large datasets.

---

## 🤝 Contributing
Contributions are welcome! If you'd like to add features or improve existing implementations, feel free to fork the repository and submit a pull request.

---

## 📜 License
This project is licensed under the MIT License. See the `LICENSE` file for details.

---

## 🙌 Acknowledgments
- Thanks to the .NET and C# community for resources and guidance.
- SQLite documentation for comprehensive examples.
