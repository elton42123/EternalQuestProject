# Eternal Quest Program

## Overview

The Eternal Quest program is a console application designed to help users track and gamify their personal goals. Inspired by principles of goal-setting in eternal and everyday contexts, this program allows users to create different types of goals, record their progress, and earn points that contribute to an overall score.

## Features

- **Goal Types:**
  - **Simple Goals:** One-time goals that can be marked complete to earn points.
  - **Eternal Goals:** Repeatable goals that never complete but award points each time recorded.
  - **Checklist Goals:** Goals requiring multiple completions; each completion awards points and a bonus is awarded upon full completion.

- **Gamification:**
  - Points awarded for progress on goals.
  - Levels unlocked based on total points (every 1000 points), with fun titles.

- **User Interactions:**
  - Create new goals with custom parameters.
  - List all goals with progress and completion status.
  - Record events to mark progress and gain points.
  - Save and load goals and scores from a file.

- **OOP Design:**
  - Uses abstraction, encapsulation, inheritance, and polymorphism.
  - Each goal type is a class derived from a base Goal class.
  - Clean separation of concerns with each class in its own file.

## Setup Instructions

1. Clone or download this repository.
2. Open the project in Visual Studio or Visual Studio Code.
3. Build the solution to restore dependencies and compile the code.
4. Run the program.

## How to Use

- Upon running, you will be presented with a menu to create goals, list them, record progress, save/load your data, and exit.
- Create goals by selecting a type and entering the required information.
- Record events when you make progress on a goal to gain points.
- Save your progress to a file (`goals.txt`) to load it later.
- Your total score and current level are displayed to encourage continued growth.

## Creative Feature

This program includes a leveling system where users "level up" every 1000 points and earn a fun title (e.g., Apprentice, Warrior, Champion) as an extra motivator to stay engaged with their goals.

## File Structure

- `Program.cs` - Main program with menu and logic.
- `Goal.cs` - Abstract base class defining shared properties and methods.
- `SimpleGoal.cs` - Derived class for one-time goals.
- `EternalGoal.cs` - Derived class for repeatable goals.
- `ChecklistGoal.cs` - Derived class for multi-step checklist goals.
- `goals.txt` - File where goal data and score are saved and loaded.

## Requirements

- .NET SDK installed (recommended version .NET 6.0 or later)
- Console environment to run the program.

## License

This project is created as a school assignment and is free to use for educational purposes.

---


