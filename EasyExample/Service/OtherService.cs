using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyExample.Models;

namespace EasyExample.Service
{
    public class OtherService : IOtherService
    {
        public Node MoveNextUnvisitedNode(Node currentNode)
        {
            return currentNode.nextNodes.FirstOrDefault(node => node.Visited == false);
        }
    }
}
