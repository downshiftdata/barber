# Barber

This application provides a secure, centralized platform for managing SQL queries and database connections, tailored for enterprise use. It allows users to store, execute, and audit SQL queries, ensuring complete tracking of query creation, edits, approvals, and executions, along with detailed user and timestamp information. The app supports both automated query generation based on predefined criteria and custom query creation, enhancing flexibility for support staff handling data manipulation tasks (DML). It's designed specifically for making occasional, audited data changes within databases, not for deploying schema changes (DDL). This tool is essential for businesses seeking a controlled, transparent method for database adjustments.

## Pre-v1.0 Issues

- Only custom queries supported.
- User interface needs a lot of work.
- No authentication yet.
- Still working on authorization.

## Deployment

- Requires .Net 8 and a SQL Server database.
- All configuration settings are in appsettings.json.
- Run sql\deploy.ps1 to deploy the database components.

## About the Name

The name is both an homage to Barber Motorsports Park, a host of the IndyCar Series since 2010, and a reference to the "trimming" work that it is intended to facilitate.
