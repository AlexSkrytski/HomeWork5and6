namespace HomeWork5and6.Contracts.Responses
{
    // Используем record для неизменяемых данных (DTO)
    public record ProductResponse(
        Guid Id,
        string Name,
        decimal Price
    );
}
