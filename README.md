# TheSimpleBank

A simple application to represent an ATM.

## Rules

- The ATM cannot dispense more money than it holds.
- The customer cannot withdraw more funds then they have access to.
- The ATM should not dispense funds if the pin is incorrect.
- The ATM should not expose the customer balance if the pin is incorrect.
- The ATM should only dispense the exact amounts requested.

## Commands

Open the ATM with the provided balance.
```
8000
```

Load the customer account using the account number, accepted pin and provided pin.
```
12345678 1234 1234
```

Assign balance and overdraft to customer account.
```
500 100
```

View the customer balance.
```
B
```

Withdraw funds from customer account.
```
W 100
```

A blank line marks the end of a customers session.

## Errors

Unable to validate account details.
```
ACCOUNT_ERR
```

Funds not available for withdrawal.
```
FUNDS_ERR
```

ATM does not have any funds.
```
ATM_ERR
```

## Example

Given the example input:

```
8000

12345678 1234 1234
500 100
B
W 100

87654321 4321 4321
100 0
W 10

87654321 4321 4321
0 0
W 10
B
```

you should expect the following output:

```
500
400
90
FUNDS_ERR
0
```

## Getting started

Change directory to the `src` folder, you can build and then run the CLI project with the following.

```
dotnet build
dotnet run --project  .\TheSimpleBank.Cli\TheSimpleBank.Cli.csproj
```

You can run the unit tests with the following commands.

```
dotnet test
```
