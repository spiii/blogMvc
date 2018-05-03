            using System;

public interface IUnitOfWork : IDisposable
{
    IProseRepository proses { get; }
    IPostRepository posts { get; }
    IPictureRepository pictures { get; }
    ILinkRepository links { get; }
    IRatingRepository ratings { get; }
    void Save();
}
