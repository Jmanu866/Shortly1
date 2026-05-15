using Microsoft.EntityFrameworkCore;
using Shortly.Domain.Entities;
using Shortly.Infrastructure.Persistence;

namespace Shortly.Infrastructure.Repositories;

public sealed class LinkRepository
{
    private readonly AppDbContext _context;

    public LinkRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Link> Create(Link link)
    {
        _context.Links.Add(link);
        await _context.SaveChangesAsync();

        return link;
    }

    public async Task<Link?> GetByShortUrl(string shortUrl)
    {
        return await _context.Links
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.ShortUrl == shortUrl);
    }

    public async Task<List<Link>> GetAll()
    {
        return await _context.Links
            .AsNoTracking()
            .Include(l => l.User)
            .ToListAsync();
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}