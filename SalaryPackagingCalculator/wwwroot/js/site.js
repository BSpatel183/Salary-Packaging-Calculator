// Function to toggle the visibility of the 'Hours Worked' input field based on employer and employment type
function toggleHoursWorkedField() {
    const employerType = document.getElementById('employerType').value;
    const employmentType = document.getElementById('employmentType').value;
    const hoursWorkedContainer = document.getElementById('hoursWorkedContainer');

    // Show the 'Hours Worked' field for Corporate and Part-time
    if (employerType === 'Corporate' && employmentType === 'Part-time') {
        hoursWorkedContainer.style.display = 'block';
    } else {
        hoursWorkedContainer.style.display = 'none';
    }
}

// Function to toggle the visibility of the 'Educated' field based on the employer type
function toggleEducatedField() {
    const employerType = document.getElementById('employerType').value;
    const educatedContainer = document.getElementById('educatedContainer');

    // Show the 'Educated' field for Hospital and PBI employer types
    if (employerType === 'Hospital' || employerType === 'PBI') {
        educatedContainer.style.display = 'block';
    } else {
        educatedContainer.style.display = 'none';
    }
}

// Function to handle the salary package calculation and form submission
async function calculateSalaryPackage() {
    const annualSalary = parseFloat(document.getElementById('salary').value);
    const employerType = document.getElementById('employerType').value;
    const employmentType = document.getElementById('employmentType').value;
    const hoursWorked = parseFloat(document.getElementById('hoursWorked').value) || 0;
    const educated = document.getElementById('educated').value === 'Yes';

    // Validate the form inputs
    if (!annualSalary || !employerType || !employmentType) {
        document.getElementById('result').textContent = 'Please fill out all required fields.';
        return;
    }

    const requestData = {
        annualSalary: annualSalary,
        employerType: employerType,
        employmentType: employmentType,
        hoursWorked: hoursWorked,
        educated: educated,
    };

    try {
        // Call the backend API using fetch to calculate the salary package
        const response = await fetch('/api/SalaryPackage', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(requestData),
        });

        // Check if the response is successful
        if (!response.ok) {
            throw new Error('Failed to calculate salary package');
        }

        // Parse the result and display it
        const result = await response.json();
        document.getElementById('result').textContent = `Your salary packaging limit is: $${result}`;
    } catch (error) {
        // Display an error message if the fetch fails
        document.getElementById('result').textContent = `Error: ${error.message}`;
    }
}
