# Battleship

Recruitment exercise

## The most important nuget packages

- MediatR
- Automapper
- EntityFramework

## About application architecture

In my project I have used "Clean Architecture" and I have divided into four parts.

- Api
- Core
- Infrastructure
- Domain

I chose it because project is more susceptible to change and easier to develop. Other reason of my chose is easier bugs finding, because we know which part of code where is it.

## About layers

### Api
 
 This layer has one task - to make the data available to our frontend in an important format.

### Core

Core include our business logic divided into services. Here are located all profile mappings, commands and queries and also all necessary models. Interfaces allow to call with services and repositories by DI.

### Infrastructure

Infrastructure contain generic repository, which makes that my code is shorter, and dedicate repositories if we need spcial access to data base. In infrastructure are all migration and db configurations.

### Domain

In domain is only our entity. I decided on this layer because I dont like to keep entity in core layer and I think, this way makes our solution more clearly.

## About application

In my application I have used Sqlite because I didnt want to waste my time configuring sql server, and with a small project, sql server is triumph of form over substance.

In project is used CQRS pattern. I wanted to my application was more scalable and commands were separated from queries. The most necessary function is mapping entity to model and vice versa into commands or queries. For faster code writing I created BaseRequestHandler, who contains generic methods for getting or manipulating data. If our base methods are not enough, then using UnitOfWork we can use dedicate repositories and manipulate data how we want.

Now all ships are generated for computer and player automatic

## ToDo

Player should set his ships how he wants.
After game player and all data related with him should be removed