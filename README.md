# About the project
Functional project for library catalogue web app, created as one of the projects during informatics bachelor's studies (6th semester). This project included the market reserach, Figma design prototype, Blazor App creation and user testing - all described in the final report (in polish). I also decided to publish the project in Azure (using my student's access).

The Blazor project focuses on the library catalog's interface, aiming to make the student's experience as engaging and user-friendly as possible. The catalog features a simple and clean UI, which also aims to facilitate daily work with the system.

Catalog users will be able to browse books, add them to their 'virtual shelf,' and check them out (if available). The catalog also features a section for library recommendations, as well as separate subpages for required reading (lektury) and textbooks.

Additionally, users will have access to options that facilitate site navigation, including accessibility features (font size and contrast adjustments), a site map, a catalog user guide, and an AI bot assistant (not implemented in this project).

## Technologies
The project was planned as a web application on the **ASP.NET Core 9** platform, which enables the creation of modern, cloud-supported, internet-connected applications. The application's frontend was implemented using **Blazor WebAssembly** - a .NET framework for building interactive, client-side web apps that run in the browser using C# and HTML, eliminating the need for JavaScript.

The database was created in **Azure SQL Database**, a managed cloud service from Microsoft that offers the creation, maintenance, and scaling of relational databases without the need to manage server infrastructure.

To connect the database with the interface, an API based on ASP.NET Core 9 controllers was used. This enabled effective communication between the frontend and the database, providing support for CRUD operations in a structured and scalable manner.

The AI chat feature will be implemented in the future (other project) using Azure OpenAI, a managed cloud service from Microsoft. It offers access to advanced OpenAI language models, enabling the creation of intelligent conversational systems that process user queries and generate relevant, natural-language responses.

## Project documentation
**Partial project documentation** in polish is available in the file [Katalog_raport-końcowy_docs_PL.pdf](https://github.com/iguanaiza/KatalogPrototyp/blob/master/Katalog_raport-ko%C5%84cowy_docs_PL.pdf).
Full version can be sent on request for job recruitment process.

## Live Azure project
The project was published on Azure: [Link here](https://katalogprototyp20250707094604.azurewebsites.net/). Sometimes it needs to reload a few times, as the site is not 'on live' 24/7.

(if it's not working at all it means my student's account is no longer valid).

The chatbot implemented is not AI one!
