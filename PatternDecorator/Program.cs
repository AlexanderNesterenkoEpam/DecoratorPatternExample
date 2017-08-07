using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator
{
	class Program
	{
		public static void Main(string[] args)
		{
			IPrinter printer = new QuotesDecorator(new LeftBracketDecorator(new RightBracketDecorator(new Printer())));
			printer.print();
			Console.WriteLine();
		}

		public interface IPrinter
		{
			void print();
		}

		public class Printer : IPrinter
		{
			public void print()
			{
				Console.Write("Hello");
			}
		}

		public abstract class Decorator : IPrinter
		{
			protected IPrinter instance;
			public Decorator(IPrinter instance)
			{
				this.instance = instance;
			}

			public abstract void print();
		}

		public class QuotesDecorator : Decorator
		{
			public QuotesDecorator(IPrinter instance) : base(instance)
			{
			}

			public override void print()
			{
				Console.Write("\"");
				instance.print();
				Console.Write("\"");		
			}
		}

		public class LeftBracketDecorator : Decorator
		{
			public LeftBracketDecorator(IPrinter instance) : base(instance)
			{
				this.instance = instance;
			}

			public override void print()
			{
				Console.Write("[");
				instance.print();
			}
		}

		public class RightBracketDecorator : Decorator
		{
			public RightBracketDecorator(IPrinter instance) : base(instance)
			{
				this.instance = instance;
			}

			public override void print()
			{
				instance.print();
				Console.Write("]");
			}
		}

	}
}
