# DREAD Risk Assessment Matrix

**Formula:** Risk Score = (Damage + Reproducibility + Exploitability + Affected Users + Discovery) / 5

| Threat Scenario | Damage (1-10) | Reproducibility | Exploitability | Affected Users | Discovery | Risk Score | Status |
|---|---|---|---|---|---|---|---|
| **SQL Injection** | 9 | 8 | 2 | 10 | 8 | **7.4 (High)** | **Mitigated:** Using Entity Framework Core (Parameterized Queries). |
| **XSS (Cross-Site Scripting)** | 7 | 8 | 5 | 10 | 9 | **7.8 (High)** | **Mitigated:** Input validation using HtmlSanitizer & CSP Headers. |
| **Man-in-the-Middle Attack** | 8 | 3 | 4 | 10 | 4 | **5.8 (Medium)** | **Mitigated:** Enforced HTTPS and HSTS headers. |
| **Brute Force Password Attack** | 6 | 9 | 8 | 10 | 9 | **8.4 (High)** | **Mitigated:** BCrypt Hashing (Work Factor 11). |
| **Session Hijacking** | 8 | 5 | 4 | 10 | 4 | **6.2 (Medium)** | **Mitigated:** Secure, HttpOnly, SameSite Cookies. |