# CSC 350H Homework 2C - Game Menu Console Application

## Description
A simple console-based game menu application created for CSC 350H under Professor Hao Tang's guidance.

## Features
- **Clean Menu Interface**: Professional game-style menu with decorative borders
- **4 Menu Options**:
  1. **New Game** - Starts a new game session
  2. **Load Game** - Loads a previously saved game
  3. **Options** - Displays game settings and preferences
  4. **Quit** - Exits the application gracefully

## Menu Layout
```
**************

Menu:

1 - New Game

2 - Load Game

3 - Options

4 - Quit

**************
```

## Functionality
- **Input Validation**: Handles invalid menu choices with error messages
- **User-Friendly Navigation**: Clear prompts and "Press any key" continuations
- **Professional Presentation**: Consistent formatting with decorative separators
- **Loop-Based Menu**: Returns to main menu after each operation
- **Clean Exit**: Graceful goodbye message when quitting

## Technical Implementation
- **C# Console Application** using .NET
- **Switch-Case Logic** for menu option handling
- **While Loop** for continuous menu display
- **Console.Clear()** for clean screen transitions
- **Input Validation** with default case handling
- **String Comparison** for menu choice processing

## Usage
1. Run the application: `dotnet run`
2. Select menu options by entering numbers 1-4
3. Follow on-screen prompts
4. Press any key to return to menu after each operation
5. Select option 4 to quit

## Requirements
- .NET Core/Framework
- Visual Studio Code
- C# language support

## Project Structure
```
├── Program.cs          # Main application code
├── README.md           # This documentation
├── .gitignore         # Git ignore file
└── HW2C.csproj        # Project configuration
```

## Author
Student submission for CSC 350H  
Professor: Hao Tang  
Simple but effective console menu demonstration