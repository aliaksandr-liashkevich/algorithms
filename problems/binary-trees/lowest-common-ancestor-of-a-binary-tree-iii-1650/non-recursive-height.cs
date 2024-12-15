/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution
{
    // Time: O(h)
    // Space: O(1)
    public Node LowestCommonAncestor(Node p, Node q)
    {
        if (p is null || q is null)
        {
            return null;
        }

        int pDepth = FindDepth(p);
        int qDepth = FindDepth(q);

        if (qDepth > pDepth)
        {
            (p, q) = (q, p);
            (pDepth, qDepth) = (qDepth, pDepth);
        }

        while (pDepth > qDepth)
        {
            p = p.parent;
            pDepth--;
        }

        int depth = pDepth;

        while ((p != q) && (p is not null) && (q is not null))
        {
            p = p.parent;
            q = q.parent;
        }

        return p;
    }

    private int FindDepth(Node node)
    {
        int depth = 0;

        while (node is not null)
        {
            depth++;
            node = node.parent;
        }

        return depth;
    }
}
