# State Design Pattern Overview

## Introduction
The State design pattern is a behavioral design pattern that allows an object to alter its behavior when its internal state changes. This pattern is particularly useful when you have an object with multiple states, and you want to encapsulate the transitions and behaviors associated with each state. The State pattern promotes cleaner, more maintainable code by isolating the state-specific logic into separate classes.

## Key Concepts
- **Context**: This is the class that maintains an instance of the current state and delegates state-specific behavior to that instance.
- **State**: The State interface defines a set of methods that concrete state classes must implement. These methods represent the actions or behaviors associated with a particular state.
- **Concrete State**: These are the classes that implement the State interface. Each concrete state class represents a specific state of the context and provides the implementation for state-specific behavior.

## ATM State Machine Project

This project implements an ATM (Automated Teller Machine) using the State design pattern. It defines various states such as CardInserted, CashWithdrawal, NoCard, and PinEntered, each with specific behaviors. The State pattern allows the ATM to transition between these states based on user interactions.
![STatediagram](https://github.com/Sreelaxme/StateDesignPattern/blob/master/state.jpg)

