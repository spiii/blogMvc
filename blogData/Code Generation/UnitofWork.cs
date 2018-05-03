using System;
using blogData;

public class UnitOfWork : IUnitOfWork
{
    private blogDbEntities _context;

    public UnitOfWork(blogDbEntities context)
    {
        _context = context;
    }

	//Delete this default constructor if using an IoC container
	public UnitOfWork()
	{
		_context = new blogDbEntities();
	}
	
    public IProseRepository proses
    {
        get { return new ProseRepository(_context); }
    }

    public IPostRepository posts
    {
        get { return new PostRepository(_context); }
    }

    public IPictureRepository pictures
    {
        get { return new PictureRepository(_context); }
    }

    public ILinkRepository links
    {
        get { return new LinkRepository(_context); }
    }

    public IRatingRepository ratings
    {
        get { return new RatingRepository(_context); }
    }

    public IGroupRepository groups
    {
        get { return new GroupRepository(_context); }
    }

    
    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
