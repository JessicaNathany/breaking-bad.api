# Breaking Bad API <br>

![image](https://github.com/JessicaNathany/breaking-bad.api/assets/11943572/be267a2f-adf1-4957-bb7f-97fac2cde1e5)

<br/>

<p align="center">
  <img src="https://img.shields.io/badge/Framework-dotnet-blue"/> 
  <img src="https://img.shields.io/badge/Framework%20version-dotnet%207-blue"/>
  <img src="https://img.shields.io/badge/Language-C%23-blue"/> 
  <img src="https://img.shields.io/badge/Status-development-green"/>  
   <img src=" https://img.shields.io/badge/Status-development-green"/>  
</p>

[🇧🇷 Portuguese version](/README.pt-BR.md)

 <h4 align="center"> 
	🚧  Project 🚀 under construction...  🚧
 </h4>

This is a .NET 7 Web API that provides endpoints to access and manage data related to the TV show Breaking Bad. <br/>
The API allows users to retrieve information about characters, episodes, and quotes from the show. <br/><br/>

## API Documentation 📝 <br/>
The API endpoints are documented using Swagger

Open a web browser and navigate to http://localhost:5000/swagger.
This will display the Swagger UI, which provides a user-friendly interface for exploring the API 
endpoints. The API provides the following endpoints:<br/>

- `GET /characters` - retrieves a list of all characters in Breaking Bad.
- `GET /characters/{id}` - retrieves a specific character by ID.
- `GET /episodes` - retrieves a list of all episodes in Breaking Bad.
- `GET /episodes/{id}` - retrieves a specific episode by ID.
- `GET /quotes/characters/{id}` - retrieves a list of all better frases for specific character in Breaking Bad.<br/><br/>


1. **Presentation Layer**
  - Name: breaking-bad.api<br/>
  - Description: This layer is responsible for exposing the API to the outside world, i.e. it receives HTTP requests, <br/>
    processes them and returns the responses. It is in this layer that most of the API configurations are done. <br/>
    
2. **Application Layer**
  - Name: breaking-bad.application<br/>
  - Description: The layer is responsible for housing the application's business rules, <br/>
    it uses the services provided by the other layers to perform the required operations. It is in this layer <br/>
    that the application use cases are implemented. <br/>
    
3. **Domain Layer**
  - Name: breaking-bad.domain<br/>
  - Description: The layer is responsible for defining the application's business concepts and rules. <br/>
    It is in this layer that the entities and object values that the application uses are defined.<br/>
    
4. **Infrastructure Layer**
  - Name: breaking-bad.infrastructure<br/>
  - Description: The layer is responsible for access database. <br/>
    It is in this layer that the configuration database, context class, migrations and repositories.<br/>
    
 

##  Getting Started 🚀<br/>
To get started with the API, clone this repository to your local machine and run the following <br/>
command to start the application: <br/>

To get started with the API, follow these steps: <br/>

## Installation :wrench: <br/>

1. Install .NET 7 if you haven't already. You can download it from [here](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0).
2. Clone this repository to your local machine.`https://github.com/JessicaNathany/breaking-bad.api.git`
3. Next, navigate to the project directory and run the following command to restore the dependencies:
`dotnet restore`
4. Finally, run the following command to start the API:
`dotnet run`
5. The application will start listening on http://localhost:5000 <br/><br/>


## Current features :clipboard: <br/>
- `GET /characters` - retrieves a list of all characters in Breaking Bad.
- `GET /characters/{id}` - retrieves a specific character by ID.
- `GET /episodes` - retrieves a list of all episodes in Breaking Bad.
- `GET /episodes/{id}` - retrieves a specific episode by ID.
- `GET /quotes/characters/{id}` - retrieves a list of all better frases for specific character in Breaking Bad

## Next  features :dart: <br/>
- `GET /gifs` - retrieves a list of all gifs in Breaking Bad.
- `GET /images` - retrieves a list of all iamges in Breaking Bad.
- `GET /images/character/{id}` - retrieves of all iamges in specific character in Breaking Bad. <br/>


Project status
This project is currently at version 1.0.0. Below is a list of currently available features and those that will<br/> 
be added in future updates.<br/>

 ## Libraries and Backages 🛠️
- [Moq](https://www.nuget.org/packages/Moq)
- [AutoMoq](https://www.nuget.org/packages/AutoMoq)
- [Newtonsoft](https://www.nuget.org/packages/Newtonsoft.Json)
- [FluentValidation](https://www.nuget.org/packages/fluentvalidation/)
- [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/8.0.0-preview.3.23174.2)
- [AutoMapper](https://www.nuget.org/packages/automapper/)
- [NBuilder](https://www.nuget.org/packages/NBuilder)
<br/><br/>


##  Contributing 🤝<br/>
Contributions are welcome! <br>
To contribute to this project, please fork this repository and submit a pull request.<br/><br/>

## License 📄
This project is licensed under the MIT License - see the LICENSE.md file for details.<br/><br/>

📧 Contact

Made with ♥ by **Jéssica Natahny** 👋: [Get in touch!](https://www.linkedin.com/in/jessica-nathany-38260868/)

By the way, guess who suggested this readme?... You're welcome 🥰


This is a .NET 7 Web API that provides endpoints to access and manage data related to the TV show Breaking Bad. <br/>
The API allows users to retrieve information about characters, episodes, and quotes from the show. <br/><br/>


## Onion Architecture 📝 <br/>

The term 'Onion Architecture' was coined by Jeffrey Palermo in 2008. This architecture offers alternatives for creating 
applications that are more testable, meaningful, with clear sepration of responsabilities, reduce coupling, and robust 
database infrastructure.


Fonts: 
- [The Onion Architecture part1 Jeffrey Parlermo](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/)

