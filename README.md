# Salary Packaging Calculator

A web-based **Salary Packaging Calculator** designed to help users calculate their salary packaging limits based on their annual salary, employer type, employment type, and work hours. This application is intended for use by employees looking to determine their salary packaging eligibility and limits in a simple and intuitive way.

## Folder Structure:
```bash
BreadcrumbsSalaryPackagingCalculator/
│
├── Controllers/                # Contains the backend API files   
│
├── wwwroot/                    # Contains the frontend files
│   ├── css/                    # CSS stylesheets
│   │   ├── site.css            # Main stylesheet for styling the form
│   ├── js/                     # JavaScript files
│   │   ├── site.js             # Logic for handling form and API calls
│   ├── index.html              # Main HTML file with the salary packaging form
│
└── README.md                   # Project documentation
```

## Key Features:
- **User Input Fields**:
  - Annual salary
  - Employer type (Corporate, Hospital, PBI)
  - Employment type (Full-time, Part-time, Casual)
  - Hours worked per week (for part-time employees)
  - Education level (Bachelor's degree or higher, for hospital/PBI employers)
  
- **Dynamic Form Behavior**:
  - Displays or hides certain fields based on the user’s input (e.g., hours worked or education level).
  
- **Salary Calculation Logic**:
  - Calculates the packaging limit based on salary ranges and adjusts the limit based on hours worked per week.

## Technologies Used:
- **Frontend**:
  - HTML, CSS, JavaScript
- **Backend** (if applicable):
  - C# .NET Core for API logic (calculating the packaging limit)
- **Responsive Design**: Ensures the application works seamlessly on both desktop and mobile devices.

## Installation and Setup:

### 1. Clone the repository
```bash
git clone https://github.com/BSpatel183/SalaryPackagingCalculator.git
