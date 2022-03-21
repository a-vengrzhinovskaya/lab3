using System;

namespace lab3
{
    public class MatrixCalculator
    {

        private static MatrixCalculator instance;

        private MatrixCalculator() {

        }

        public static MatrixCalculator GetInstance {

            get {

                if (instance == null) {

                    instance = new MatrixCalculator();
                }

                return instance;
            }
        }

        private SquareMatrixClone CreateSquareMatrix() {

            var notSet = true;

            Console.WriteLine("Enter matrix name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Generate random matrix?\n");
            Console.WriteLine("no         0");
            Console.WriteLine("yes        1");
            while (notSet) {

                switch (Console.ReadLine()) {

                    case "0":
                        notSet = false;
                        break;
                    case "1":
                        return new SquareMatrixClone(name);
                    default:
                        Console.WriteLine("Incorrect option. Try again.");
                        break;
                }
            }

            notSet = true;

            var size = 0;
            while (notSet) {

                Console.WriteLine("Enter matrix size: ");

                if (!int.TryParse(Console.ReadLine(), out size) || size <= 1) {

                    Console.WriteLine("Incorrect value. Try again.");
                } else {

                    notSet = false;
                }
            }

            notSet = true;

            Console.WriteLine("Generate random elements?\n");
            Console.WriteLine("no         0");
            Console.WriteLine("yes        1");
            while (notSet) {

                switch (Console.ReadLine()) {

                    case "0":
                        notSet = false;
                        break;
                    case "1":
                        return new SquareMatrixClone(size, name);
                    default:
                        Console.WriteLine("Incorrect option. Try again.");
                        break;
                }
            }

            var elements = new double[size, size];
            int currentElement;
            for (var rowIndex = 0; rowIndex < size; ++rowIndex) {

                for (var columnIndex = 0; columnIndex < size; ++columnIndex) {

                    while (notSet) {

                        Console.WriteLine($"Enter element {rowIndex}{columnIndex}: ");

                        if (!int.TryParse(Console.ReadLine(), out currentElement)) {

                            elements[rowIndex, columnIndex] = currentElement;

                            notSet = false;
                        } else {

                            Console.WriteLine("Incorrect value. Try again.");
                        }
                    }
                }
            }

            return new SquareMatrixClone(size, name, elements);
        }

        private void GetMatrixInfo(SquareMatrixClone matrix) {

            Console.WriteLine($"Determinant: {matrix.Determinant()}");
            Console.WriteLine($"Hash code: {matrix.GetHashCode}");
            Console.WriteLine($"As string: {matrix.ToString}");
        }

        public void Calculator() {

            Console.WriteLine("Create 1st matrix:\n");
            var left = CreateSquareMatrix();

            Console.Clear();

            Console.WriteLine("Create 2st matrix:\n");
            var right = CreateSquareMatrix();

            Console.Clear();

            left.PrintMatrix();
            Console.WriteLine("\n");
            right.PrintMatrix();
            Console.WriteLine("\n");

            Console.WriteLine("add           0");
            Console.WriteLine("substract     1");
            Console.WriteLine("multiply      2");
            Console.WriteLine("compare       3");
            Console.WriteLine("info          4");
            var option = true;
            while (option) {

                switch (Console.ReadLine()) {

                    case "0":
                        try {
                            var result = left + right;

                            result.PrintMatrix();
                        }
                        catch (SquareMatrixSizeException exception){
                            Console.WriteLine(exception.Message);

                            break;
                        }
                        option = false;
                        break;
                    case "1":
                        try {
                            var result = left - right;

                            result.PrintMatrix();
                        }
                        catch (SquareMatrixSizeException exception) {
                            Console.WriteLine(exception.Message);

                            break;
                        }
                        option = false;
                        break;
                    case "2":
                        try {
                            var result = left * right;

                            result.PrintMatrix();
                        }
                        catch (SquareMatrixSizeException exception) {
                            Console.WriteLine(exception.Message);

                            break;
                        }
                        option = false;
                        break;
                    case "3":
                        option = false;
                        break;
                    case "4":
                        option = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect option. Try again.");
                        break;
                }
            }
        }
    }
}
