# CRUD Application with Clean Architecture in ASP.NET Core

This project is a simple CRUD application built with ASP.NET Core, following Clean Architecture principles and implementing patterns such as CQRS, DDD, and TDD.

---

## **Project Structure**

The solution is structured as follows:

1. **Core Layer**: Contains domain models, repository interfaces, and application logic.
2. **Infrastructure Layer**: Handles database interactions and external services.
3. **API Layer**: Serves as the presentation layer, exposing endpoints and integrating Swagger for API documentation.
4. **Tests Layer**: Includes unit and integration tests to support TDD and BDD practices.

---

## **Implementation Steps**

### **1. Core Layer**

#### **Domain Model**

Define the `Customer` entity with the specified properties:

```csharp
public class Customer
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}
```

### Validation
Implement validation rules using FluentValidation:

```csharp
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Firstname).NotEmpty();
        RuleFor(c => c.Lastname).NotEmpty();
        RuleFor(c => c.DateOfBirth).LessThan(DateTime.Now);
        RuleFor(c => c.PhoneNumber).Must(IsValidPhoneNumber).WithMessage("Invalid phone number.");
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.BankAccountNumber).Matches(@"^\d{10,18}$").WithMessage("Invalid bank account number.");
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {
        var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
        try
        {
            var parsedPhone = phoneUtil.Parse(phoneNumber, "US");
            return phoneUtil.IsValidNumberForRegion(parsedPhone, "US");
        }
        catch
        {
            return false;
        }
    }
}
```

### **2. Infrastructure Layer**
#### **Database Configuration**
Utilize Entity Framework Core to configure the database schema, ensuring uniqueness constraints:

```csharp
modelBuilder.Entity<Customer>()
    .HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth })
    .IsUnique();

modelBuilder.Entity<Customer>()
    .HasIndex(c => c.Email)
    .IsUnique();
```

Data Storage Optimization
Store PhoneNumber as varchar(15) to minimize storage space.
Apply appropriate database constraints through migrations.

## **3. API Layer**
CQRS Implementation
Implement the CQRS pattern using MediatR:

Commands: Handle Create, Update, and Delete operations.
Queries: Handle data retrieval operations.
Controller Example

```csharp
[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(id));
        return Ok(result);
    }
}
```

Swagger Integration
Add Swagger for API documentation:

```csharp
services.AddSwaggerGen();
```

## **4. Docker Configuration**
Create a docker-compose.yml file to set up the PostgreSQL database service:

```yaml
version: '3.4'

services:
  database:
    image: postgres:latest
    environment:
      POSTGRES_USER: user
      POSTGRES_PASSWORD: password
      POSTGRES_DB: customersdb
    ports:
      - "5432:5432"
    volumes:
      - db_data:/var/lib/postgresql/data

volumes:
  db_data:
```

## **5. Testing**
Unit Tests: Use xUnit to test validations and domain services.
Integration Tests: Utilize TestServer for API endpoint testing.

## **6. Git Workflow**
Maintain clean and descriptive commit messages to reflect your work progress:

```bash
git commit -m "feat: add customer entity and validation rules"
git commit -m "test: add unit tests for customer validation"
git commit -m "chore: add Swagger and update API documentation"
```

## **7. Delivery**
Repository Setup
Clone the existing repository and retain commit history:

``` bash
git clone --mirror https://github.com/mohrmz/crud-test-csharp.git
cd crud-test-csharp
git remote add origin https://github.com/your-username/your-repo.git
git push -u origin --all
```

Pull Request
After implementing the features, create a pull request for code review.

