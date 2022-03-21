/******************************************
 * Автор: Венгржиновская А. С.            *
 * Дата: 28.02.2022                       *
 * Название: Перегрузка операций          *
*******************************************/

using System;

namespace lab3 {

	class Program {

		static void Main(string[] args) {

			//MatrixCalculator.GetInstance.Calculator();

			var left = new SquareMatrixClone(2, "A");
			var right = new SquareMatrixClone(2, "B");

			left.PrintMatrix();
			right.PrintMatrix();

			Console.WriteLine(left.Determinant());
		}
	}
}