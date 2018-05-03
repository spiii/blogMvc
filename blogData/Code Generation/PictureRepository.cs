                
using blogData;
              
public class PictureRepository : Repository<picture>, IPictureRepository
{
    private blogDbEntities _context;

    public PictureRepository(blogDbEntities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPictureRepository.cs file
}
