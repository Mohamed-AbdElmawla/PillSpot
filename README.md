# 🏥 Pill-Spot

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![React](https://img.shields.io/badge/React-18.3.1-blue.svg)](https://reactjs.org/)
[![TypeScript](https://img.shields.io/badge/TypeScript-5.6.2-blue.svg)](https://www.typescriptlang.org/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0+-orange.svg)](https://www.mysql.com/)
[![Status](https://img.shields.io/badge/Status-Graduation%20Project-brightgreen.svg)](https://github.com/Mohamed-AbdElmawla/Pill-Spot)

> **A Location-Based Pharmacy Medicine Search Platform** - Find medicines in nearby pharmacies with real-time location services and comprehensive pharmacy management.

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Technology Stack](#-technology-stack)
- [Architecture](#-architecture)
- [Getting Started](#-getting-started)
- [API Documentation](#-api-documentation)
- [Security Features](#-security-features)
- [Performance Optimizations](#-performance-optimizations)
- [Rate Limiting](#-rate-limiting)
- [Testing](#-testing)
- [Project Timeline](#-project-timeline)
- [Team](#-team)

## 🎯 Overview

Pill-Spot is a comprehensive web platform designed to bridge the gap between patients and pharmacies by providing real-time location-based medicine search capabilities. The platform enables users to find specific medicines in nearby pharmacies, view availability, and get directions to pharmacies. **Medicine prices are fixed and set by the system administrators.**

### Key Benefits

- **For Users**: Save time by finding medicines quickly and get directions to pharmacies
- **For Pharmacies**: Increase visibility, manage inventory digitally, and streamline operations
- **For Healthcare**: Improve medicine accessibility and reduce travel time for patients

## ✨ Features

### 🔍 For End Users
- **Smart Medicine Search**: Search by medicine name with autocomplete and filters
- **Location-Based Results**: GPS-powered pharmacy discovery with distance calculation
- **Interactive Maps**: Visual pharmacy locations with directions using Google Maps
- **Real-Time Availability**: Live stock information with fixed pricing
- **User Authentication**: Secure registration and login with JWT tokens
- **User Profiles**: Manage personal information and preferences
- **Multi-language Support**: Internationalization with i18next

### 🏪 For Pharmacy Owners
- **Pharmacy Registration**: Multi-step onboarding with admin approval workflow
- **Inventory Management**: Add, update, and manage medicine stock
- **Staff Management**: Add employees with role-based permissions
- **Pharmacy Dashboard**: View pharmacy information and basic analytics
- **Profile Management**: Update pharmacy details and contact information

### 👨‍💼 For Administrators
- **System Management**: User and pharmacy oversight
- **Content Management**: Categories, products, and system settings
- **Price Management**: Set and manage fixed medicine prices
- **Approval Workflows**: Pharmacy and employee request processing
- **User Management**: Manage system users and roles

## 🛠 Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0
- **Database**: MySQL 8.0+ with spatial data support
- **ORM**: Entity Framework Core 8.0
- **Authentication**: JWT with refresh tokens
- **Logging**: Serilog with structured logging
- **API Documentation**: Swagger/OpenAPI
- **Rate Limiting**: Built-in ASP.NET Core rate limiting

### Frontend
- **Framework**: React 18 with TypeScript
- **State Management**: Redux Toolkit
- **UI Libraries**: Ant Design, Material-UI, Tailwind CSS
- **Maps**: Google Maps API, Leaflet
- **Internationalization**: React i18next
- **Build Tool**: Vite
- **Package Manager**: npm/yarn

### DevOps & Tools
- **Version Control**: Git
- **Database**: MySQL with spatial extensions
- **Development**: Visual Studio 2022 / VS Code
- **API Testing**: Swagger UI, Postman

## 🏗 Architecture

### Backend Architecture (Clean Architecture)
```
Back/
├── Pill-Spot/                    # Main API Project
├── PillSpot.Presentation/        # API Controllers & Filters
├── Service/                      # Business Logic Layer
├── Service.Contracts/            # Service Interfaces
├── Repository/                   # Data Access Layer
├── Contracts/                    # Repository Interfaces
├── Entities/                     # Domain Models & Configuration
└── Shared/                       # DTOs & Request Features
```

### Frontend Architecture
```
Front/pill-spot/
├── src/
│   ├── components/              # Reusable UI Components
│   ├── pages/                   # Page Components
│   ├── features/                # Feature-based Redux Slices
│   ├── hooks/                   # Custom React Hooks
│   ├── UI/                      # UI Components Library
│   ├── layouts/                 # Layout Components
│   └── Router/                  # Application Routing
```

## 🚀 Getting Started

### Prerequisites

- **.NET 8.0 SDK** or later
- **Node.js 18+** and npm/yarn
- **MySQL 8.0+** with spatial extensions
- **Visual Studio 2022** or **VS Code**
- **Google Maps API Key** (for map functionality)

### Backend Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/Mohamed-AbdElmawla/Pill-Spot.git
   cd Pill-Spot
   ```

2. **Configure Database**
   ```bash
   # Create MySQL database
   CREATE DATABASE pillspot_db;
   
   # Update connection string in appsettings.json
   ```

3. **Install Dependencies**
   ```bash
   cd Back/Pill-Spot
   dotnet restore
   ```

4. **Run Migrations**
   ```bash
   dotnet ef database update
   ```

5. **Configure Environment Variables**
   ```json
   {
     "ConnectionStrings": {
       "MySqlConnection": "Server=localhost;Database=pillspot_db;Uid=root;Pwd=your_password;"
     },
     "JwtSettings": {
       "SecretKey": "your-secret-key-here",
       "ValidIssuer": "https://localhost:7298",
       "ValidAudience": "https://localhost:7298",
       "Expires": "60"
     },
     "CorsSettings": {
       "AllowedOrigins": ["http://localhost:3000", "https://localhost:3000"]
     },
     "RateLimiting": {
       "GeneralLimit": 100,
       "AuthenticationLimit": 10,
       "SearchLimit": 30,
       "UploadLimit": 20,
       "WindowMinutes": 1
     }
   }
   ```

6. **Run the API**
   ```bash
   dotnet run
   ```
   API will be available at: `https://localhost:7298`

### Frontend Setup

1. **Install Dependencies**
   ```bash
   cd Front/pill-spot
   npm install
   # or
   yarn install
   ```

2. **Configure Environment Variables**
   Create `.env` file:
   ```env
   VITE_API_BASE_URL=https://localhost:7298
   VITE_GOOGLE_MAPS_API_KEY=your-google-maps-api-key
   ```

3. **Run Development Server**
   ```bash
   npm run dev
   # or
   yarn dev
   ```
   Frontend will be available at: `http://localhost:3000`

## 📚 API Documentation

### Authentication Endpoints
- `POST /api/authentication` - User registration
- `POST /api/authentication/login` - User login
- `POST /api/authentication/logout` - User logout
- `POST /api/authentication/refresh` - Refresh JWT token

### Pharmacy Endpoints
- `GET /api/pharmacies` - Get all pharmacies
- `GET /api/pharmacies/{id}` - Get pharmacy by ID
- `POST /api/pharmacyrequests` - Submit pharmacy registration
- `PUT /api/pharmacyrequests/{id}/approve` - Approve pharmacy request

### Medicine Search Endpoints
- `GET /api/pharmacyproducts` - Search medicines in pharmacies
- `GET /api/products` - Get all products
- `GET /api/categories` - Get product categories

### User Management Endpoints
- `GET /api/users/{userName}` - Get user profile
- `PUT /api/users/{userName}` - Update user profile
- `DELETE /api/users/{userName}` - Delete user account

**Full API Documentation**: Visit `https://localhost:7298` when the API is running.

## 🔒 Security Features

### Authentication & Authorization
- **JWT Token Authentication**: Secure token-based authentication with refresh tokens
- **Role-Based Access Control**: SuperAdmin, Admin, User, and Pharmacy roles
- **Permission-Based Authorization**: Granular permissions for different operations
- **Password Security**: ASP.NET Core Identity with secure password hashing
- **Token Refresh**: Automatic token refresh mechanism with secure cookie storage

### CSRF Protection
- **Built-in Anti-Forgery**: ASP.NET Core's built-in CSRF protection
- **Token Validation**: Automatic CSRF token validation for state-changing operations
- **Secure Headers**: X-CSRF-Token header implementation
- **Cookie Security**: HttpOnly, Secure, and SameSite cookie policies

### Data Protection
- **Input Validation**: Comprehensive input validation and sanitization
- **SQL Injection Prevention**: Entity Framework Core with parameterized queries
- **XSS Protection**: Content Security Policy and input encoding
- **File Upload Security**: File type validation and size restrictions

### API Security
- **Rate Limiting**: Multi-tier rate limiting for different endpoints
- **CORS Configuration**: Strict CORS policy with allowed origins
- **HTTPS Enforcement**: Automatic HTTPS redirection in production
- **Request Validation**: Model validation and custom validation filters

## ⚡ Performance Optimizations

### Database Optimizations
- **Spatial Indexing**: MySQL spatial indexes for location-based queries
- **Query Optimization**: Efficient LINQ queries with proper includes
- **Pagination**: Server-side pagination for large datasets
- **Soft Deletes**: Logical deletion with query filters
- **Database Indexing**: Strategic indexes on frequently queried columns

### Caching Strategy
- **Memory Caching**: In-memory caching for frequently accessed data
- **Query Result Caching**: Cached database query results
- **Rate Limit Caching**: Efficient rate limiting with memory cache
- **Session Management**: Optimized session handling

### Frontend Optimizations
- **Code Splitting**: Dynamic imports for better loading performance
- **Bundle Optimization**: Vite build optimization
- **Image Optimization**: Compressed images and lazy loading
- **State Management**: Efficient Redux state updates

### API Optimizations
- **Async/Await**: Non-blocking asynchronous operations
- **Connection Pooling**: Database connection pooling
- **Response Compression**: Gzip compression for API responses
- **Efficient Serialization**: Optimized JSON serialization

## 🚦 Rate Limiting

### Rate Limit Policies

| Policy | Limit | Window | Description |
|--------|-------|--------|-------------|
| **GlobalPolicy** | 100 requests | 1 minute | General API access |
| **AuthenticationPolicy** | 10 requests | 1 minute | Login/Register endpoints |
| **SearchPolicy** | 30 requests | 1 minute | Search and query endpoints |
| **UploadPolicy** | 20 requests | 1 minute | File upload endpoints |
| **CsrfTokenPolicy** | 100 requests | 1 minute | CSRF token generation |

### Rate Limit Implementation
- **Sliding Window**: For general API access
- **Token Bucket**: For authentication endpoints
- **Fixed Window**: For search and upload operations
- **Adaptive Window**: For CSRF token generation

### Rate Limit Response
```json
{
  "error": "Too many requests. Please try again later.",
  "retryAfter": 60
}
```

## 🧪 Testing

### Testing Environment
- **API Testing**: Postman for endpoint testing and validation
- **Database Testing**: MySQL Workbench for database operations
- **Frontend Testing**: Browser developer tools and React DevTools
- **Integration Testing**: Manual testing of complete user workflows

### Test Coverage Areas
- **Authentication Flow**: Login, registration, token refresh
- **API Endpoints**: All CRUD operations and business logic
- **Database Operations**: Query performance and data integrity
- **Frontend Components**: UI interactions and state management
- **Security Features**: Authorization and validation

### Testing Tools
- **Postman Collections**: Organized API test suites
- **Swagger UI**: Interactive API documentation and testing
- **Browser DevTools**: Frontend debugging and performance analysis
- **MySQL Workbench**: Database query testing and optimization

## 📅 Project Timeline

### Phase 1: Foundation (Completed)
- **Duration**: 2-3 months
- **Achievements**:
  - ✅ Project architecture setup
  - ✅ Database design and implementation
  - ✅ Basic authentication system
  - ✅ Core API development
  - ✅ Frontend foundation

### Phase 2: Core Features (Completed)
- **Duration**: 2-3 months
- **Achievements**:
  - ✅ User management system
  - ✅ Pharmacy registration and management
  - ✅ Medicine search functionality
  - ✅ Location-based services
  - ✅ Admin dashboard
  - ✅ Fixed pricing system

### Phase 3: Advanced Features (Completed)
- **Duration**: 2-3 months
- **Achievements**:
  - ✅ Security implementation
  - ✅ Performance optimizations
  - ✅ Rate limiting
  - ✅ Multi-language support
  - ✅ Responsive design

### Future Enhancements (Planned)
- **Mobile Application**: Native iOS/Android apps
- **AI Integration**: Medicine recommendation system
- **Telemedicine**: Doctor consultation features
- **Advanced Analytics**: Comprehensive reporting and insights

## 🗄 Database Schema

### Core Entities

```sql
-- Users and Authentication
Users (Id, UserName, Email, PhoneNumber, ProfilePictureUrl, ...)
AspNetRoles (Id, Name, NormalizedName)
AspNetUserRoles (UserId, RoleId)

-- Pharmacy Management
Pharmacies (PharmacyId, Name, LocationId, LicenseId, ContactNumber, ...)
PharmacyRequests (RequestId, UserId, Name, Status, ...)
PharmacyEmployees (EmployeeId, PharmacyId, UserId, ...)

-- Product Management
Products (ProductId, Name, Description, Price, SubCategoryId, ...)
Categories (CategoryId, Name)
SubCategories (SubCategoryId, Name, CategoryId)

-- Inventory Management
PharmacyProducts (PharmacyId, ProductId, Quantity, IsAvailable, ...)

-- Location and Spatial Data
Locations (LocationId, Latitude, Longitude, AdditionalInfo, CityId, ...)
Cities (CityId, Name, GovernmentId)
Governments (GovernmentId, Name)
```

### Spatial Features
- Geographic coordinates for pharmacy locations
- Distance calculations using MySQL spatial functions
- Location-based queries and filtering

## 👥 Team

### 🎓 Students
- **[Mohamed AbdElmawla](https://github.com/Mohamed-AbdElmawla)** - ACPC Finalist | Software Engineer | Codeforces Expert | Problem Solving Coach | .NET & C# Developer
- **[Mohamed Ramadan Elaraby](https://github.com/Elaraby218)** - Software Engineering Student
- **[Khaled Ibrahem](https://github.com/uukh22)** - Computer Science Student
- **[Shahd Medhat](https://github.com/shahdmedhat35)** - Software Engineering Student

### 👨‍🏫 Teaching Assistant
- **[Omnia Bakr](https://github.com/OmniaBakr)** - Teaching Assistant

### 🏫 Academic Institution
- **Assiut University** - Faculty of Computer and Information Sciences

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- **ASP.NET Core Team** for the excellent framework
- **React Team** for the powerful frontend library
- **MySQL Team** for spatial data support
- **Open Source Community** for various libraries and tools
- **Assiut University** for academic support and guidance

## 📞 Support

- **Repository**: [https://github.com/Mohamed-AbdElmawla/Pill-Spot](https://github.com/Mohamed-AbdElmawla/Pill-Spot)
- **Issues**: [GitHub Issues](https://github.com/Mohamed-AbdElmawla/Pill-Spot/issues)
- **Discussions**: [GitHub Discussions](https://github.com/Mohamed-AbdElmawla/Pill-Spot/discussions)

---

<div align="center">
  <p>Made with ❤️ for better healthcare accessibility</p>
  <p>⭐ Star this repository if you find it helpful!</p>
  <p><strong>Academic Project:</strong> Developed as part of the Software Engineering curriculum at Assiut University</p>
</div>
