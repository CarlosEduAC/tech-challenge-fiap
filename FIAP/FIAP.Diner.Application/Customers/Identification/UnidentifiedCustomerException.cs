using FIAP.Diner.Domain.Abstractions;

namespace FIAP.Diner.Application.Customers.Identification;

public class UnidentifiedCustomerException : DomainException
{
    public const string error = "Não existe nenhum cliente cadastrado com o CPF {0}";

    public UnidentifiedCustomerException(string cpf) : base(string.Format(error, cpf)) { }
}