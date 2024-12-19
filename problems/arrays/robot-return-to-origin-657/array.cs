public class Solution
{
    private const char UP = 'U';
    private const char DOWN = 'D';
    private const char LEFT = 'L';
    private const char RIGHT = 'R';

    // Time: O(n)
    // Space: O(1)
    public bool JudgeCircle(string moves)
    {
        int x = 0;
        int y = 0;

        foreach (char move in moves)
        {
            switch (move)
            {
                case UP:
                    y++;
                    break;
                case DOWN:
                    y--;
                    break;
                case LEFT:
                    x--;
                    break;
                case RIGHT:
                    x++;
                    break;
                default:
                    return false;
            }
        }

        return x == 0 && y == 0;
    }
}
