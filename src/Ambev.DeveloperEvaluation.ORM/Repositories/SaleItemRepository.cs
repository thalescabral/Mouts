using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleItemRepository using Entity Framework Core
/// </summary>
public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new sale item in the database
    /// </summary>
    /// <param name="item">The sale item to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale item</returns>
    public async Task<SaleItem> CreateAsync(SaleItem item, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems.AddAsync(item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return item;
    }

    /// <summary>
    /// Retrieves a sale item by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale item if found, null otherwise</returns>
    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a sale item from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale item to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the item was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await GetByIdAsync(id, cancellationToken);
        if (item == null)
            return false;

        _context.SaleItems.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
