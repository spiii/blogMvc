            using System;

public interface IUnitOfWork : IDisposable
{
    IRatingRepository ratings { get; }
    IProseRepository proses { get; }
    IPostRepository posts { get; }
    ILinkRepository links { get; }
    IPictureRepository pictures { get; }
    void Save();
}
