# DJT.Vertical

As of v8.5, DJT.Vertical is not restricted to Web APIs, but can be used in any .NET application.  For Web APIs, there is an additional library: DJT.Vertical.AspNetCore

This library consists of tools dependency injection and error handling across 'verticals'.

## Service Attributes

I assume you know all about Dependency Injection in .NET, so I won't go into detail about that.  However, DJT.Vertical provides a set of attributes to make it easier to register services with dependency injection.

Include the `DJT.Vertical.Attributes` namespace and start registering your dependency injected classes
using the lifetime-named attributes.  Each attribute also allows an optional key to be defined, therefore registering
the class as a keyed service.  The `ImplementsType` interface (or base type) can also be specified in the attribute
constructor.  For example:

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
be scanned for these attributes (the 'Calling Assembly').

## Registering services

To register your attributed services, in your application, include `using DJT.Vertical` and call the following:

```c#
builder.Services.AddVerticalComponents();
```

For a custom DI container, you can use it like so:

```c#
ServiceCollection myServices = new ServiceCollection();
myServices.AddVerticalComponents();
```

If you are using DJT.Vertical.AspNetCore, you can also include the following to use the components in your application:

```c#
builder.Services.AddVerticalHttpComponents();

var app = builder.Build();

app.UseVerticalHttpComponents();
```

This also adds the error handling middleware and auth service, discussed below, to the pipeline.

## Request Handlers

This feature exists for creating a mediation layer for your Web API endpoints.  There is no mediation service defined in this library and there are no plans to add one yet.
All implementations of the `IRequestHandler<>` interface will be automatically registered with dependency injection.

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

### Async

Added in v8.1 are abstract classes for `AsyncRequestHandler<>`.  These are just the same as the `IRequestHandler<>` interfaces, but with an `async` method signature.  Use these if you want to use `async`/`await` in your request handlers.

## Exceptions

To avoid wrapping errors in bulky response wrappers which need to be passed down through the call stack, DJT.Vertical provides a set of exceptions which can be thrown from your request handlers.

These exceptions will be caught by the middleware and converted into appropriate HTTP responses.  The `DJT.Vertical.AspNetCore` library includes middleware to handle these exceptions automatically.

To return erroneous responses, use the included `Exception`s, such as `BadRequestException` for a HTTP 400
response.

Custom response codes can be supplied using `CustomStatusException`.

> Future plans:
> Responses in the next version will all derive from a `CustomStatusException` or similar, to make catching them easier.

## Auth Service (DJT.Vertical.AspNetCore)

A simple auth service for getting user claim information is included.

> In future versions this may be expanded upon.

