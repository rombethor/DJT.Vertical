# DJT.Vertical

Vertical Slice architecture for Web APIs is an alternative to using controllers.

## Using components

In your web application, include `using DJT.Vertical.Http` and call the following:

```c#

builder.Services.AddVerticalComponents();

var app = builder.Build();

app.UseVerticalComponents();

```

## Request Handlers

Use the `IRequestHandler<>` interfaces to define the functionality of the API, using dependency injection
for dependencies.  I.e.

```c#
public class GetEmployeesHandler(MyDbContext db) : IRequestHandler<IEnumerably<Employees>>
{
	public IEnumerable<Employees> Execute()
	{
		return db.Employees.ToList();
	}
}
```

## Exceptions

To return erroneous responses, use the included `Exception`s, such as `BadRequestException` for a HTTP 400
response.

Custom response codes can be supplied using `CustomStatusException`.

## Auth Service

A simple auth service for getting user claim information is included.
