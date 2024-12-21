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

### 1️⃣ Habit Management
- View all habit records.
- Add new habit records with validation.
- Update existing records.
- Delete records securely.

### 2️⃣ SQLite Integration
- Connection handling with `using` statements.
- Parameterized queries for SQL injection prevention.
- CRUD operations implementation.

### 3️⃣ Modular Design
- Entity, service, and UI layers for clear separation of concerns.
- Interface-driven service layer.

### 4️⃣ Learning Highlights
Each code file includes comments highlighting:
- Principles learned.
- Challenges faced.
- Solutions implemented.

---

## 🛠️ Setup Instructions

### ✅ Prerequisites
- .NET 6.0 or later installed on your system.
- SQLite database engine.

### 🚀 Steps to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/learningcsharp-learning-journey.git
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
