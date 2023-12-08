
namespace adventofcode2023
{
    public class Solution
    {
        public string SolutionOfFirstPart(string[] lines)
        {
            Dictionary<string, MyNode> nodes = new();
            string currentNode;
            MyNode start = new("");
            // Hier kommt die Logik für den ersten Teil hin
            for (int line = 2; line < lines.Length; line++)
            {
                currentNode = lines[line].Split(" ")[0];
                nodes.Add(currentNode, new(currentNode));
                if (currentNode == "AAA")
                    start = nodes["AAA"];
            }
            for (int line = 2; line < lines.Length; line++)
            {
                currentNode = lines[line].Split(" ")[0];
                nodes[currentNode].SetDirections(nodes[lines[line].Substring(7, 3)], nodes[lines[line].Substring(12, 3)]);
            }
            int steps = 0;
            if (start.Name == "") throw new Exception("start wasnt found!");
            MyNode current = start;
            while (current.Name != "ZZZ")
            {
                switch (lines[0][steps % lines[0].Length])
                {
                    case 'R':
                        current = current.Right;
                        break;
                    case 'L':
                        current = current.Left;
                        break;
                }
                steps++;
            }

            return steps.ToString();
        }

        public string SolutionOfSecondPart(string[] lines)
        {
            Dictionary<string, MyNode> nodes = new();
            string currentNode;
            List<MyNode> start = new();
            for (int line = 2; line < lines.Length; line++)
            {
                currentNode = lines[line].Split(" ")[0];
                nodes.Add(currentNode, new(currentNode));
                if (currentNode[2] == 'A')
                    start.Add(nodes[currentNode]);
            }
            for (int line = 2; line < lines.Length; line++)
            {
                currentNode = lines[line].Split(" ")[0];
                nodes[currentNode].SetDirections(nodes[lines[line].Substring(7, 3)], nodes[lines[line].Substring(12, 3)]);
            }
            long steps = 0;
            int dir = 0;
            string directions = lines[0];
            MyNode[] nodesPerRound = start.ToArray();
            int i = 0;
            int nodesCount = nodesPerRound.Length;
            while (!AllEndNodes(nodesPerRound))
            {
                for (i = 0; i < nodesCount; i++)
                {
                    switch (directions[dir])
                    {
                        case 'R':
                            nodesPerRound[i] = nodesPerRound[i].Right;
                            break;
                        case 'L':
                            nodesPerRound[i] = nodesPerRound[i].Left;
                            break;
                    }
                }
                steps++;
                dir++;
                if (dir == directions.Length) dir = 0;
            }
            return steps.ToString();
        }

        private bool AllEndNodes(MyNode[] nodes)
        {
            foreach (MyNode node in nodes)
            {
                if (node.Name[2] != 'Z')
                    return false;
            }
            return true;
        }
    }

    internal class MyNode
    {
        public MyNode(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public MyNode Left { get; set; }
        public MyNode Right { get; set; }

        internal void SetDirections(MyNode left, MyNode right)
        {
            Left = left;
            Right = right;
        }
    }
}
