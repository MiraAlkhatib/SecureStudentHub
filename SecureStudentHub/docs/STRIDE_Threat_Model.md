# STRIDE Threat Model

**Project:** Secure Student Hub
**Date:** 2026-01-14

| Threat Category | Description of Threat | Component Affected | Mitigation Strategy Implemented |
|---|---|---|---|
| **S - Spoofing** | An attacker tries to log in as another user or Admin. | Login Page | Implemented robust session management with HttpOnly cookies. Passwords are never sent in plain text. |
| **T - Tampering** | An attacker modifies data in the database (e.g., changing their role to Admin). | Database / API | Role-Based Access Control (RBAC) ensures only Admins can perform sensitive actions. |
| **R - Repudiation** | A user denies performing a malicious action (like deleting data). | Logging | System logs all critical actions (Login, Registration) to trace user activity. |
| **I - Information Disclosure** | Leaking sensitive data like SSNs or Passwords. | Database | Passwords are hashed with BCrypt. SSNs are encrypted with AES-256 at rest. |
| **D - Denial of Service** | Flooding the login page with requests to crash the server. | Web Server | Rate Limiting (Bonus Feature) and secure hosting configuration. |
| **E - Elevation of Privilege** | A standard user accessing Admin-only pages. | Admin Controller | The `[Authorize(Roles = "Admin")]` attribute protects all administrative routes. |