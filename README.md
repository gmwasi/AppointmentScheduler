# Appointments

## Visual Studio and Postgres

#### Prerequisites

- PostgreSQL
- [Visual Studio .NET Core SDK 3.1.0](https://www.microsoft.com/net/download/all)

#### Steps to run

- Update the connection string in appsettings.json in AppointmentScheduler
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
- on Postgres create a database with the name matching the one on the appsettings.json
- In the terminal, navigate to the root directory type "dotnet build" and hit "Enter".
- In the terminal, navigate to the "AppointmentScheduler" type "dotnet run" and hit "Enter".

## Client

1.  Clone the repo `git clone [git url]]`
2.  Go to your project folder from your terminal
3.  Run: `npm install` or `yarn install`
4.  After install, run: `npm run start` or `yarn start`
5.  It will open your browser(http://localhost:3000)

### Note

To enable basic Google Analytics page tracking, you can add "REACT_APP_GOOGLE_ANALYTICS" variable in .env(or create env.production) file. For example, `REACT_APP_GOOGLE_ANALYTICS=xxxxxx` like this.

## Technologies and frameworks used:

- dotnet core 3.1
- React
- Postgres

## Deploy on azure
For the api follow this [instructions](https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core-ef-step-05?view=vs-2019)
For the client follow this [instructions](https://azure.microsoft.com/en-in/resources/videos/build-and-deply-nodejs-and-react-apps-with-vscode-appservice-and-cosmosdb/)