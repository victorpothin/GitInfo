using GitInfo.Domain.Models;

namespace GitInfo.Domain.Services.Interfaces
{
    public interface ITreeNodeService
    {
        TreeNode MakeTreeNodes(string page);
    }
}