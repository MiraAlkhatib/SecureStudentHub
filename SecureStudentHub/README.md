# Secure Student Hub

A secure web application developed for the **Application Security** course. This project demonstrates secure software development lifecycle (SSDLC) principles.

## 🛠 Tech Stack
- **Framework:** ASP.NET Core 8 MVC
- **Language:** C#
- **Database:** SQL Server (LocalDB)
- **Security Tools:** BCrypt.Net, HtmlSanitizer, NetEscapades.SecurityHeaders

## 🔒 Security Features Implemented
1.  **Authentication:** Secure Cookie Authentication with `HttpOnly` and `Secure` flags.
2.  **Authorization:** Role-Based Access Control (Admin vs. User).
3.  **Cryptography:**
    * **Hashing:** Passwords hashed using BCrypt (Work Factor 11).
    * **Encryption:** Sensitive data (SSN) encrypted at rest using AES-256.
4.  **Input Validation:** All user inputs are sanitized to prevent XSS.
5.  **Headers:** Security headers (CSP, HSTS, X-Frame-Options) configured.

## 📂 Documentation
* [Threat Modeling (STRIDE)](docs/STRIDE_Threat_Model.md)
* [Risk Assessment (DREAD)](docs/DREAD_Risk_Assessment.md)

## 🚀 Setup Instructions
1.  Clone the repository.
2.  Open in Visual Studio.
3.  Run `Update-Database` in the Package Manager Console.
4.  Run the application (F5).