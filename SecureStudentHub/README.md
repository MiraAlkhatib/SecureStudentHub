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



## 🕵️‍♂️ Security Scans & Compliance

The codebase has been scanned using industry-standard tools to ensure security compliance.

* **GitHub CodeQL:** Automated security analysis ran via GitHub Actions.
    * *Result:* Passed (See screenshots in `scans/` folder).
* **Snyk:** Dependency and vulnerability scanning.
    * *Result:* Analysis of 3rd-party libraries (See screenshots in `scans/` folder).

> **Note on Findings:** The scanner identified a dependency warning in the default `jquery.validate.js` library. This risk is mitigated via our strict **Server-Side Validation** in the `AuthController`.


## 🚀 Setup Instructions
1.  Clone the repository.
2.  Open in Visual Studio.
3.  Run `Update-Database` in the Package Manager Console.
4.  Run the application (F5).

---
### ⚠️ Note on Configuration & Secrets
For the purpose of this academic submission, the **Database Connection String** and **Encryption Keys** have been included directly in the source code (`Program.cs` / `EncryptionService.cs`).

This was done to ensure the application runs immediately on the instructor's machine using **LocalDB** without requiring additional environment configuration.

**Production Security Disclosure:**
In a real-world production environment, we would **NEVER** commit secrets to source control. Instead, we would:
1.  Store secrets in **Environment Variables** or **Azure Key Vault**.
2.  Use a `.env` file listed in `.gitignore`.
3.  Inject secrets at runtime to prevent Information Disclosure.
---