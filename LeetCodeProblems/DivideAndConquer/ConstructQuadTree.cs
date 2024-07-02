namespace LeetCodeProblems.DivideAndConquer;
public class ConstructQuadTree

{    
    // intuition
    // so a quad tree essentially represents a pyramid?
    // with a node that represents the entire tree
    // that has four children, each representing a quater of the tree
    // that each have four children and so on?

    // I think that we can solve this with divide and conquer
    // we will recursively call our function on each quarter of the nodes
    // until we reach a leaf node
    // then we will return the node
    // if all four leaf nodes have the same value, we set the node's value to that value and leave all the children null
    // only if the children have different values do we preserce them
    // so if an entire quadrant of the matrix has the same values, it can be represented by a single node

    // this solution will be relatively slow with a call for every item in the grid and log n calls per item to subdivide the grid

    // I think this is O(n log n), but even if it is, in practice it seems to be much slower than the O(n^2 log n) solution below
    // I believe that this is because in most cases test cases don't actually need to be subdivided
    // meaning that while the worst case complexity is worse, the average complexity is likely better
    
    public static Node ConstructA(int[][] grid) {
        if (grid == null || grid.Length < 1 || grid[0].Length < 1)
        {
            return null;
        }

        return QuadifyGrid(grid.Length, 0, 0);
        
        // quad helper function
        Node QuadifyGrid(int n, int row, int column)
        {
            // if leaf node
            if (n == 1)
            {
                return new Node((grid[row][column] == 1? true : false), true);
            }

            // get the four children
            n /= 2;

            Node topLeft = QuadifyGrid(n, row, column);
            Node topRight = QuadifyGrid(n, row, column + n);
            Node bottomLeft = QuadifyGrid(n, row + n, column);
            Node bottomRight = QuadifyGrid(n, row + n, column + n);

            // check if equal - prune and treat as leaf node
            if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf 
                && topLeft.val == topRight.val && topLeft.val == bottomLeft.val && topLeft.val == bottomRight.val)
            {
                return new Node(topLeft.val, true);
            }

            Node node = new();

            node.topLeft = topLeft;
            node.topRight = topRight;
            node.bottomLeft = bottomLeft;
            node.bottomRight = bottomRight;

            return node;
        }
    }


    // O(n^2 * log n) solution   
    public static Node Construct(int[][] grid) {
        if (grid == null || grid.Length < 1 || grid[0].Length < 1)
        {
            return null;
        }

        return QuadifyGrid(grid.Length, 0, 0);
        
        // quad helper function
        Node QuadifyGrid(int n, int row, int column)
        {
            bool allSame = true;

            for (int i = 0; i  < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[row][column] != grid[row + i][column + j])
                    {
                        allSame = false;
                        break;
                    }
                }
            }

            Node node = new();

            if (allSame)
            {
                node.val = grid[row][column] == 1? true : false;
                node.isLeaf = true;
                return node;
            }

            n /= 2;

            node.topLeft = QuadifyGrid(n, row, column);
            node.topRight = QuadifyGrid(n, row, column + n);
            node.bottomLeft = QuadifyGrid(n, row + n, column);
            node.bottomRight = QuadifyGrid(n, row + n, column + n);

            return node;
        }
    }
}


// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node? topLeft;
    public Node? topRight;
    public Node? bottomLeft;
    public Node? bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}


