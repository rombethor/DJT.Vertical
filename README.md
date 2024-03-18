# DJT.Vertical

Vertical Slice architecture for Web APIs is an alternative to using controllers.

## Using components

In your web application, include `using DJT.Vertical.Http` and call the following:

```c#

builder.Services.AddVerticalComponents();

var app = builder.Build();

app.UseVerticalComponents();

```

## Service Attributes

Include the `DJT.Vertical.Attributes` namespace and start registering your dependency injected classes
using the lifetime-named attributes.  Each attribute also allows an optional key to be defined, therefore registering
the class as a keyed service.  For example:

```c#
[SingletonService(ImplementsType = typeof(IMyInterface),Key = "for_science")]
public class MySingletonService : IMyInterface
{
	public void DoSomething() 
	{
	}
}

[ScopedService]
public class MyScopedService ([FromKeyedServices("for_science")] IMyInterface singleton)
{
	public void DoSomethingElse()
	{
		singleton.DoSomething();
	}
}
```

Similarly, there is also a `[TransientService]` attribute.

> Note: It is the assembly which calls directly `AddVerticalComponents()` which will
be scanned for these attributes.

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

## Async

Included in v8.1 are abstract classes for `AsyncRequestHandler<>` which require a cancellation token and
obligate the return value wrapped in a `Task<TRes>`.

## Exceptions

To return erroneous responses, use the included `Exception`s, such as `BadRequestException` for a HTTP 400
response.

Custom response codes can be supplied using `CustomStatusException`.

## Auth Service

A simple auth service for getting user claim information is included.
