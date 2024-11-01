# STACodingChallenge
 # TfL Journey Planner Automation Framework

## Project Overview
This repository contains an automation framework for testing the "Journey Planner" widget on the Transport for London (TfL) website. The framework is built using C# in Visual Studio, with tests written in Gherkin syntax and executed via the SpecFlow extension. Selenium Webdriver is used for UI automation, providing flexibility in navigating and validating key functionalities of the Journey Planner.

## Key Technologies
- **C#** & **Visual Studio**: Core development environment.
- **SpecFlow (Gherkin Syntax)**: For writing clear and readable test scenarios.
- **Playwright / Selenium Webdriver**: UI automation tools for effective website interaction.
- **ChromeDriver**: Used to automate testing in Chrome.

## Development Decisions
1. **Test Scenarios**: Focus on validating core functions of the Journey Planner widget, including journey search, input validation, and UI responsiveness.
2. **Framework Design**:
   - **Modular Structure**: Used Page Object Model (POM) to create reusable, scalable classes.
   - **Reusable Components**: Helper functions and constants reduce redundancy.
3. **Test Data Management**: Data-driven testing minimizes hardcoded values, allowing flexible test scenarios.
4. **Error Handling & Logging**: Custom error messages and logging support better debugging and traceability.
5. **Browser Configuration**: Tests run in headless mode for efficiency, with ChromeDriver configured for easier debugging.

## Repository Structure
The repository includes:
- **Tests**: All test scenarios and feature files.
- **Page Objects**: Class files representing the web page elements.
- **Utilities**: Helper functions and custom utilities for data handling.

## Running the Tests
1. Clone this repository.
2. Open in Visual Studio.
3. Install required NuGet packages (SpecFlow, ChromeDriver).
4. Execute tests via Visual Studio's Test Explorer.

## Future Enhancements
- **CI/CD Integration**: Add CI pipelines for continuous testing.
- **Extended Coverage**: Cover more edge cases and error handling.

This README outlines my development approach for a maintainable, scalable automation framework for TfL's Journey Planner widget.

---

