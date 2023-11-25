using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Simple Console Calculator");
        Console.WriteLine("-------------------------");

        while (true)
        {
            Console.Write("Enter an expression (or 'exit' to quit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the calculator. Goodbye!");
                break;
            }

            try
            {
                double result = EvaluateExpression(input);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
        }
    }

    static double EvaluateExpression(string expression)
    {
        // Split the expression into operands and operator
        string[] elements = expression.Split(' ');
        if (elements.Length != 3)
        {
            throw new ArgumentException("Invalid expression. Please enter a valid expression with two operands and an operator.");
        }

        double operand1 = Convert.ToDouble(elements[0]);
        double operand2 = Convert.ToDouble(elements[2]);
        string operation = elements[1];

        // Perform the calculation based on the operator
        switch (operation)
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                if (operand2 == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                return operand1 / operand2;
            default:
                throw new ArgumentException($"Invalid operator: {operation}. Please enter a valid operator (+, -, *, /).");
        }
    }
}
