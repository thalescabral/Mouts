namespace Ambev.DeveloperEvaluation.Domain.Enums;

public enum SaleStatus
{
    Unknown = 0,     // Estado padrão para inicialização
    Pending = 1,     // Venda pendente, não finalizada
    Completed = 2,   // Venda finalizada/completa
    Cancelled = 3,   // Venda cancelada
    Returned = 4     // Venda com devolução
}
