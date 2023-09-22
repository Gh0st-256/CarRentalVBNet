
---

# Car Rental Application

This Car Rental application allows users to select a car from a list, specify the rental period, and generate an invoice for the rental period chosen. The application also includes functionalities to display and print the generated invoice.

## Features:

1. **Car Selection** - The user can choose a car from a dropdown list that includes:
    - Subaru
    - Fuso
    - Noah
    - Corolla
2. **Rental Period Specification** - The user can specify the start and end date for the rental period using date pickers.
3. **Dynamic Pricing Display** - Based on the car type selected, the application displays the corresponding rental rate.
4. **Invoice Generation** - Clicking on the "Rent" button generates a unique invoice, displaying:
    - Invoice number
    - User's name
    - User's ID
    - Car type
    - Rental period
    - Total Amount
5. **Printing Feature** - Users have the option to print the generated invoice.

## Code Structure:

- **Form Initialization (`Form1_Load`)**:
  - Initializes the car types dropdown list.
  - Sets a default car type and updates the corresponding rental rate.

- **Rental Rate Retrieval (`GetRentalRate`)**:
  - Determines the rental rate based on the car type.

- **Rental Rate Display Update (`UpdatePriceTextbox` and `ComboBox1_SelectedIndexChanged`)**:
  - Updates the rental rate displayed on the form based on the car type selected.

- **Invoice Generation (`btnInvoice_Click`)**:
  - Validates user input.
  - Computes the number of days for the rental period.
  - Generates an invoice with a unique invoice number.
  - Displays the invoice.
  - Provides an option to print the invoice.

- **Printing Feature (`PrintDocument_PrintPage`, `GetInvoiceText`, and `btnPrint_Click`)**:
  - Handles the layout and content of the printed invoice.

## How to Run:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio (or your preferred VB.NET IDE).
3. Build and run the application.
4. Use the features described above to test the application.

## Future Enhancements:

1. Integration with a database to save rental records and user information.
2. More detailed reports on car rental statistics.
3. Features for returning cars and handling damages/penalties.

---
