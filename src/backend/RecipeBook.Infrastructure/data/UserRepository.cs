using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.model;
using RecipeBook.Domain.repository;

namespace RecipeBook.Infrastructure.data;

public class UserRepository : IUserWriteRepository, IUserReadRepository
{
    private readonly RecipeBookContext _context;

    public UserRepository(RecipeBookContext context)
    {
        _context = context;
    }

    public async Task<bool> IsRegistered(string email)
    {
        return await _context.tab_user.AnyAsync(x => x.Email == email);
    }

    public async Task Save(User user)
    {
        await _context.tab_user.AddAsync(user);
    }
}
