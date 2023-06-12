using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class OtherService : IOtherService
    {
        public Node MoveNextUnvisitedNode(Node currentNode)
        {
            return currentNode.nextNodes.FirstOrDefault(node => node.Visited == false);
        }
    }
}
