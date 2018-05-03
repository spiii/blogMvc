                
using blogData;
              
public class PostRepository : Repository<Post>, IPostRepository
{
    private blogDbEntities _context;

    public PostRepository(blogDbEntities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IPostRepository.cs file
}
