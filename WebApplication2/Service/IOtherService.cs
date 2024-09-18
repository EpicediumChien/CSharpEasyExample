using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyExample.Models;

namespace EasyExample.Service
{
    public interface IOtherService
    {
        Node MoveNextUnvisitedNode(Node currentNode);
    }
}
