                
using blogData;
              
public class VoteRepository : Repository<vote>, IVoteRepository
{
    private blogDbEntities _context;

    public VoteRepository(blogDbEntities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IVoteRepository.cs file
}
