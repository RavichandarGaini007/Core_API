using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer.IServices
{
    public interface ITreeService
    {
        public List<TreeNode> BuildTree(List<RawData> data);
    }
}
