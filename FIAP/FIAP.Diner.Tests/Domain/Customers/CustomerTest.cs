using FIAP.Diner.Domain.Customers;

namespace FIAP.Diner.Tests.Domain.Customers;

public class CustomerTest
{
    [Fact]
    public void ShouldCreateCustomer()
    {
        //Arrange
        var registration = DateTime.Now;
        var cpf = "12345678909";
        var name = PersonName.From("Customer", "Name");
        var email = new Email("customer.email@fiap.com");

        //Act
        var customer = new Customer(cpf, name, email);

        //Assert
        customer.Id.Should().NotBeNull();
        customer.Id.Value.Should().NotBe(Guid.Empty);
        customer.CPF.Number.Should().Be(cpf);
        customer.Name.Should().Be(name);
        customer.Email.Value.Should().Be(email);
        customer.RegistrationDate.Should().BeAfter(registration);
        customer.LastUpdated.Should().Be(customer.RegistrationDate);
    }

    [Fact]
    public void ShouldChangeCustomer()
    {
        //Arrange
        var cpf = "12345678909";
        var registration = DateTime.Now;
        var name = PersonName.From("Name", "Changed");
        var email = new Email("customer@changed.com");

        var customer = new Customer(cpf, PersonName.From("Old", "Name"), "customer@old.com");

        //Act
        customer.Change(name, email);

        //Assert
        customer.Id.Should().NotBeNull();
        customer.Id.Value.Should().NotBe(Guid.Empty);
        customer.CPF.Number.Should().Be(cpf);
        customer.Name.Should().Be(name);
        customer.Email.Value.Should().Be(email);
        customer.RegistrationDate.Should().BeAfter(registration);
        customer.LastUpdated.Should().BeAfter(customer.RegistrationDate);
    }
}