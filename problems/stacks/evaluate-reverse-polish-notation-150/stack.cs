public class Solution
{
    // Time: O(n)
    // Space: O(n)
    public int EvalRPN(string[] tokens)
    {
        Stack<int> operandStack = new();

        for (int i = 0; i < tokens.Length; i++)
        {
            string token = tokens[i];

            if (IsOperator(token))
            {
                ArithmeticOperator arithmeticOperator = (ArithmeticOperator)token[0];
                int rightOperand = operandStack.Pop();
                int leftOperand = operandStack.Pop();

                int result = ExecuteOperation(leftOperand, rightOperand, arithmeticOperator);

                operandStack.Push(result);
            }
            else
            {
                operandStack.Push(int.Parse(token));
            }
        }

        return operandStack.Pop();

        bool IsOperator(string token)
        {
            return token.Length == 1 && Enum.IsDefined(typeof(ArithmeticOperator), (int)token[0]);
        }

        int ExecuteOperation(int leftOperand, int rightOperand, ArithmeticOperator arithmeticOperator)
        {
            switch (arithmeticOperator)
            {
                case ArithmeticOperator.Addition:
                    return leftOperand + rightOperand;
                    break;
                case ArithmeticOperator.Subtraction:
                    return leftOperand - rightOperand;
                    break;
                case ArithmeticOperator.Multiplication:
                    return leftOperand * rightOperand;
                    break;
                case ArithmeticOperator.Division:
                    return leftOperand / rightOperand;
                    break;
                default:
                    throw new InvalidOperationException($"The '{arithmeticOperator}' operator is not recognized.");
                    break;
            }
        }
    }

    private enum ArithmeticOperator
    {
        Addition = '+',
        Subtraction = '-',
        Multiplication = '*',
        Division = '/'
    }
}
