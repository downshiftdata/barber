# Barber

## Background

In an ideal situation, changes to databases should occur in one of two ways:

- The applications that are associated with the database, through the normal functions of those applications.
- An automated CI/CD pipeline, deploying changes originating from a version control system (such as a Git repository).

However, there often exist situations in which data must be manipulated outside of these two mechanisms (typically to correct an exceptional data condition). What often occurs is that a user executes ad hoc SQL scripts directly against the database, using a general purpose tool such as SQL Server Management Studio (SSMS).

This method is typically insufficient in several areas, especially proper auditing and controls. This is the problem that Barber was created to solve.

## Usage

With Barber, you:

1. Create and maintain a list of **Users**, granting those users specific authorization to **Edit**, **Approve**, and **Execute** SQL statements.
1. Create and maintain a list of **Databases** as targets for those SQL statements.
1. Create the SQL **Statements** themselves, including both normal **Insert**/**Update**/**Delete** statements and - if necessary - **Custom** statements that do not fit in the normal format.
1. **Validate** those SQL statements against representative databases.
1. **Approve** those SQL statements for execution.
1. **Execute** those SQL statements against those database connections.
1. **View** the full history of execution, including who authored, validated, approved, and executed the statements, when they did this, and against what databases.

Note that Barber is intended for targeted data manipulation tasks (DML), not for schema changes (DDL).

## Requirements
- One or more suitable ASP.NET host servers with .Net 8
- A SQL Server database (the **Control** database)

## Deployment

1. Run sql\deploy.ps1 to deploy the database components to the **Control** database. All database components will exist in a schema named "barber".
1. Build and deploy the Barber app to one or more ASP.NET host server.
1. Update the appsettings.json on each Barber server (see **Configuration** below).
1. Authenticate in the app as "*default*" with "*password*" as the password. Create the appropriate additional **Users**. Ensure that at least one **User** has **Admin** authorization, and then remove the *default* account.

## Configuration

In the appsettings.json files:

- Set the "barber-main" connection string to match the **Control** database.
- Set the AES Key and Initialization Vector (IV) to secure values.
- Set logging as desired. See https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/.

## Notes

### Security

- **User** passwords are one-way encrypted using SHA-256 and stored in the **Control** database.
- Passwords for **Database** connections are two-way encrypted using AES encryption and stored in the **Control** database.
- The appsettings.json file contains critical security information and should be protected.

### Known Issues (still pre-1.0)

- Only custom queries work so far.
- A LOT of fit-and-finish of the UX.

## About the Name

The original author is a racing nut. So the name is both an homage to [Barber Motorsports Park](https://barberracingevents.com/) and a reference to the "trimming" work that this app is intended to facilitate.
