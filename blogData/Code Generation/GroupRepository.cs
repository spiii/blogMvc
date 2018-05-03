                
using blogData;
              
public class GroupRepository : Repository<group>, IGroupRepository
{
    private blogDbEntities _context;

    public GroupRepository(blogDbEntities context) : base(context)
    {
        _context = context;
    }

    //Override any generic method for your own custom implemention, add new repository methods to the IGroupRepository.cs file
}
