using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer
{
    public class TreeService
    {
        public List<TreeNode> BuildTree(List<RawData> data)
        {
            var root = new List<TreeNode>();
            var lookup = new Dictionary<string, TreeNode>(); // 🔥 performance boost

            foreach (var item in data)
            {
                var parts = item.lvl.Split('/');
                string currentPath = "";

                for (int i = 0; i < parts.Length; i++)
                {
                    currentPath = string.IsNullOrEmpty(currentPath)
                        ? parts[i]
                        : currentPath + "/" + parts[i];

                    if (!lookup.ContainsKey(currentPath))
                    {
                        var node = new TreeNode
                        {
                            FullPath = currentPath,
                            Name = parts[i]
                        };

                        lookup[currentPath] = node;

                        // Attach to parent
                        if (i == 0)
                        {
                            root.Add(node);
                        }
                        else
                        {
                            var parentPath = currentPath.Substring(0, currentPath.LastIndexOf('/'));
                            lookup[parentPath].Children.Add(node);
                        }
                    }

                    var currentNode = lookup[currentPath];

                    // ✅ Assign DB data if exists (IMPORTANT FIX)
                    if (i == parts.Length - 1)
                    {
                        currentNode.Id = item.ID;
                        currentNode.Name = item.name ?? currentNode.Name;
                        currentNode.Desg = item.Desg;

                        currentNode.MSR = item.MSR;
                        currentNode.TYS = item.TYS;
                        currentNode.TGT = item.TGT;
                        currentNode.LYS = item.LYS;
                        currentNode.VAR = item.VAR;
                        currentNode.ACH = item.ACH;
                        currentNode.GTH = item.GTH;

                        currentNode.CTYS = item.CTYS;
                        currentNode.CTGT = item.CTGT;
                        currentNode.CVAR = item.CVAR;
                        currentNode.CLYS = item.CLYS;
                        currentNode.CAH = item.CAH;
                        currentNode.CGTH = item.CGTH;
                    }
                }
            }

            return root;
        }
    }

    public class RawData
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string Desg { get; set; }
        public decimal? MSR { get; set; }
        public decimal? TYS { get; set; }
        public decimal? TGT { get; set; }
        public decimal? LYS { get; set; }
        public decimal? VAR { get; set; }
        public decimal? ACH { get; set; }
        public decimal? GTH { get; set; }
        public decimal? CTYS { get; set; }
        public decimal? CTGT { get; set; }
        public decimal? CVAR { get; set; }
        public decimal? CLYS { get; set; }
        public decimal? CAH { get; set; }
        public decimal? CGTH { get; set; }
        public string lvl { get; set; }
    }

    public class TreeNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desg { get; set; }

        public decimal? MSR { get; set; }
        public decimal? TYS { get; set; }
        public decimal? TGT { get; set; }
        public decimal? LYS { get; set; }
        public decimal? VAR { get; set; }
        public decimal? ACH { get; set; }
        public decimal? GTH { get; set; }

        public decimal? CTYS { get; set; }
        public decimal? CTGT { get; set; }
        public decimal? CVAR { get; set; }
        public decimal? CLYS { get; set; }
        public decimal? CAH { get; set; }
        public decimal? CGTH { get; set; }

        public string FullPath { get; set; }

        public List<TreeNode> Children { get; set; } = new List<TreeNode>();

        // Helps React UI
        public bool HasData => Id > 0;
    }
}
