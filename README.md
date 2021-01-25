# Appointments

## Visual Studio and Postgres

#### Prerequisites

- PostgreSQL
- [Visual Studio .NET Core SDK 3.1.0](https://www.microsoft.com/net/download/all)
- Node js

#### Steps to run

- Update the connection string in appsettings.json in AppointmentScheduler
- Update the ValidAudience with the address of the client app including the port in the appsettings.json(Default is http://localhost:3000)
- Update the ValidIssuer with the address of the client app including the port in the appsettings.json(Default is https://localhost:5001)
- under AppointmentScheduler\Properties\launchsettings.json update the applicationUrl with the backend app http and https addresses if both exist or either
- Build whole solution.
- In Solution Explorer, make sure that AppointmentScheduler is selected as the Startup Project
- on Postgres create a database with the name matching the one on the appsettings.json
- In Visual Studio, press "Control + F5".

## Mac/Linux with PostgreSQL

#### Prerequisite

- PostgreSQL
- [Visual Studio .NET Core SDK 3.1.0](https://www.microsoft.com/net/download/all)

#### Steps to run

- Update the connection string in appsettings.json in AppointmentScheduler
- Update the ValidAudience with the address of the client app including the port in the appsettings.json(Default is http://localhost:3000)
- Update the ValidIssuer with the address of the client app including the port in the appsettings.json(Default is https://localhost:5001)
- under AppointmentScheduler\Properties\launchsettings.json update the applicationUrl with the backend app http and https addresses if both exist or either
- on Postgres create a database with the name matching the one on the appsettings.json
- In the terminal, navigate to the root directory type "dotnet build" and hit "Enter".
- In the terminal, navigate to the "AppointmentScheduler" type "dotnet run" and hit "Enter".

## Client

1.  Clone the repo `git clone [git url]]`
2.  Go to your project folder from your terminal
3.  Run: `npm install` or `yarn install`
4.  Update the `REACT_APP_URL` in the .env file with the valid backend API endpoint
5.  After install, run: `npm run start` or `yarn start`
6.  It will open your browser(http://localhost:3000)

### Note

To enable basic Google Analytics page tracking, you can add "REACT_APP_GOOGLE_ANALYTICS" variable in .env(or create env.production) file. For example, `REACT_APP_GOOGLE_ANALYTICS=xxxxxx` like this.

## Technologies and frameworks used:

- dotnet core 3.1
- React
- Postgres

## Deploy on azure
For the api follow this [instructions](https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core-ef-step-05?view=vs-2019)
For the client follow this [instructions](https://azure.microsoft.com/en-in/resources/videos/build-and-deply-nodejs-and-react-apps-with-vscode-appservice-and-cosmosdb/)