using System.Collections.Generic;
using GitInfo.Domain.Models;

namespace GitInfo.Domain.Services.Interfaces
{
    public interface IContentService
    {
        IEnumerable<Content> MakeContents(IEnumerable<string> routes);
    }
}