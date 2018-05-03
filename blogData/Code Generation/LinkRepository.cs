                
using blogData;
              
public class LinkRepository : Repository<link>, ILinkRepository
{
    private blogDbEntities _context;

    public LinkRepository(blogDbEntities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the ILinkRepository.cs file
}
