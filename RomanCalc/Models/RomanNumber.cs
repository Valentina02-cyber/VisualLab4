using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalc.Models
{
	public class RomanNumber : ICloneable, IComparable
	{
		private ushort num;
		private static int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
		private static string[] numerals = new string[]
		{ "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

		//Конструктор получает представление числа n в римской записи
		public RomanNumber(ushort n)
		{
			if (n <= 0) throw new RomanNumberException($"Число{n} меньше либо равно 0");
			else this.num = n;
		}
		//Сложение римских чисел
		public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
		{
			int number = n1.num + n2.num;
			if(number <= 0)throw new RomanNumberException("Сложение невозможно");
			else
			{
				return new RomanNumber((ushort)number);
			}
		}
		//Вычитание римских чисел
		public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
		{
			int number = n1.num - n2.num;
			if(number <= 0)throw new RomanNumberException("Вычитание не удалось");
			else
			{
				return new RomanNumber((ushort)number);
			}
		}
		//Умножение римских чисел
		public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
		{
			int number = n1.num * n2.num;
			if(number <= 0)throw new RomanNumberException("Умножение безуспешно");
			else
			{
				return new RomanNumber((ushort)number);
			}
		}
		//Целочисленное деление римских чисел
		public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
		{
			if(n2.num == 0) throw new RomanNumberException("Деление невозможно");
			else
			{
				int number = n1.num / n2.num;
				if (number == 0) throw new RomanNumberException("Деление невозможно");
				else
				{
					return new RomanNumber((ushort)number);
				}
			}
		}
		//Возвращает строковое представление римского числа
		public override string ToString()
		{
			int temp = num;
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < 13; i++)
			{
				while (temp >= values[i])
				{
					temp -= (ushort)values[i];
					result.Append(numerals[i]);
				}
			}
			if (result.ToString() == "")
				throw new RomanNumberException("Конвертер невозможен");
			else
				return result.ToString();

		}
		public object Clone()
		{
			return new RomanNumber(num);
		}

		public int CompareTo(object obj)
		{
			if (obj is RomanNumber roman)
				return num.CompareTo(roman.num);
			else
				throw new RomanNumberException("Не является римским числом");
		}
	}
}
