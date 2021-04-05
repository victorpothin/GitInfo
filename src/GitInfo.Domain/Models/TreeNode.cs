using System.Collections.Generic;

namespace GitInfo.Domain.Models
{
    public class TreeNode
    {
        public IEnumerable<string> Nodes { get; set; }

        public TreeNode(IEnumerable<string> nodes)
        {
            this.Nodes = nodes;
        }
    }
}