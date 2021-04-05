using System.Collections.Generic;
using GitInfo.Domain.Models;

namespace GitInfo.Domain.Services.Interfaces
{
    public interface IFileInfoService
    {
        IEnumerable<Content> GetInfo(string route);
    }
}