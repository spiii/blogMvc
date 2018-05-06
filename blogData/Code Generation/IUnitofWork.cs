            using System;

public interface IUnitOfWork : IDisposable
{
    IProseRepository proses { get; }
    IPostRepository posts { get; }
    IPictureRepository pictures { get; }
    IGroupRepository groups { get; }
    ILinkRepository links { get; }
    IRatingRepository ratings { get; }
    IVoteRepository votes { get; }
    void Save();
}
