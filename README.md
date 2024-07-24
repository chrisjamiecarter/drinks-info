# Drinks Info

![drinks info logo](./_resources/drinks-info-logo.png){ width="100px" }

Welcome to the **Drinks Info** App!

This is a C# project designed to demonstrate using HTTP requests on an external API to retrieve and display data.

## Requirements

- [x] Allows a resturant employee (user) to pull drink data from the company database, via an external API.
- [x] Display the returned data in a user-friendly way.
- [x] When the user opens the application they must be presented with the Drink Category Menu.
- [x] The user must be able to choose a category.
- [x] The user must then be able to choose a drink from that category.
- [x] The drink information must then be visualised, without any empty or null values.

### Additional Requirements

- [x] Allow the user the option to choose a random drink.

## Features

- **API Calls**

    Uses an external API to retrive data.

- **Data Presentation**

    All data is presented in a user friendly way.

## Getting Started

### Prerequisites

- .NET 8 SDK installed on your system.
- A code editor like Visual Studio or Visual Studio Code

### Installation

1. Clone the repository:
    - `git clone https://github.com/cjc-sweatbox/drinks-info.git`

2. Build the application:
    - `dotnet build`

### Running the Application

1. Run the application using the .NET CLI in the ConsoleApp project directory:
    - `dotnet run`

### Usage

- **Main Menu**: A main menu is presented and contains a list of options to perform.
- **Select Drink By Category**: Displays a list of categories, when a category is selected the associated drinks are displayed. And finally, when a drink is selected, the associated drink information is displayed/
- **Random Drink**: Displays the information for a random drink.

## How It Works

- **Console Application**: The [Spectre Console](https://spectreconsole.net/) library is used to aid in displaying data through the console terminal.
- **Menu Navigation**: Navigate the application through the Selection Prompts class provided by Spectre to perform actions.
- **Data Access**: The [TheCocktailDB](https://www.thecocktaildb.com/api.php) free public API is used for accessing the required data.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.

## Contact

For any questions or feedback, please open an issue.

---
***Happy Drinks Infoing!***
