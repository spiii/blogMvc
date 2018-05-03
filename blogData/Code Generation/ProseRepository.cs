
    
using blogData;
              
public class ProseRepository : Repository<prose>, IProseRepository
{
    private blogDbEntities _context;

    public ProseRepository(blogDbEntities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IProseRepository.cs file
}
