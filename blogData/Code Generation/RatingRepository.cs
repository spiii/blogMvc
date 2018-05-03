                
using blogData;
              
public class RatingRepository : Repository<rating>, IRatingRepository
{
    private blogDbEntities _context;

    public RatingRepository(blogDbEntities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IRatingRepository.cs file
}
