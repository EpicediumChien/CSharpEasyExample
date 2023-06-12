using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
	public class Node
	{
		public int Id { get; set; }
		public string Value { get; set; }
		public string Route { get; set; }
		public List<Node> nextNodes { get; set; }
		public bool Visited { get; private set; } = false;
		public void Visit() {
			Visited = true;
		}
	}
}
