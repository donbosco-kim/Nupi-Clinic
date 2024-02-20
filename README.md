# Nupi-Clinic
Nupi-Clinic is a clinic management application built using WPF, SQL database, and Entity Framework, following the MVVM design pattern.

## Features:
- CRUD Operations: Admin can perform Create, Read, Update, and Delete operations for different entities such as Patients and Doctors

- Authentication Check: Secure login mechanism for Admin users with authentication checks.

- Password Hashing: Utilizes the SHA256 algorithm to hash passwords before storing them in the database for enhanced security.

- SQL Database Interaction: Repositories are implemented to communicate with the SQL database for easier data management.

## Features to be Implemented
As of now, the Nupi-Clinic project includes essential features for clinic management. However, there are plans to enhance the application with the following features:

- Appointment Management: Implement a feature for scheduling and managing appointments between patients and doctors.

- Enhanced Admin Login Security: Implement character checking and length validation for admin usernames and passwords to ensure they meet the necessary criteria. Enhance the login process with informative error messages for users attempting to log in with invalid credentials.

- Enhance Admin: Enhance the admin login functionality to display a welcome message after a successful login. The welcome message will greet the admin by their name.

- Data Validation Rule: Implement a data validation to replace MessageBox.Show for displaying error messages. The rule will validate input fields for all entities (Admin, Patients, Doctors) and provide user-friendly messages to guide users in correcting any issues.