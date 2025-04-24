MyWinApp
A Windows desktop application that calculates the longest consecutive sequence from a list of integers.

Overview
MyWinApp implements two calculation methods for finding the longest consecutive sequence:

Sorting Method: Sorts the input numbers and finds the longest consecutive run.

Hashing Method: Uses a hash set to efficiently find the longest consecutive sequence without sorting.

The app separates concerns with:

Services: Contain the core calculation logic for both methods.

View: Contains the UI components, including the splash screen and main page where users input data and see results.

Controller: Handles input validation (IsValid function), manages button click events, triggers the appropriate calculation method, and displays results.

Features
Input validation for empty or malformed input.

Two buttons to select which calculation method to use.

Results displayed on the main page after calculation.

Splash screen shown at startup before main window loads.

Project Structure
Services

SequenceService: Implements the sorting-based calculation.

SequenceService2: Implements the hashing-based calculation.

View

SplashScreen: Initial loading screen.

MainPage: Main interface with input box, buttons, and result display.

Controller

Validates input strings.

Handles button events:

Checks for empty input and shows error if invalid.

Calls the corresponding service method based on the button clicked.

Updates UI with the result.

Usage
Run the app, see the splash screen, then the main window appears.

Enter a comma-separated list of integers in the input box.

Click Solution 1 or Solution 2 button to calculate using the respective method.

The result will appear on the main page.

