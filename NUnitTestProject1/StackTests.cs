using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace Tests
{
	[TestFixture]
	public class StackTests
	{
		Stack<string> stack;

		[SetUp]
		public void SetUp()
		{
			stack = new Stack<string>();
		}

		[Test]
		public void Count_EmptyStack_ReturnZero()
		{
			Assert.That(stack.Count, Is.EqualTo(0));
		}

		[Test]
		public void Push_ValidArg_AddTheObjectToTheStack()
		{			
			stack.Push("hola");
			Assert.That(stack.Count, Is.EqualTo(1));
		}

		[Test]
		public void Push_ArgIsNull_ThrowArgNullException()
		{
			Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
		}

		[Test]
		public void Peek_StackWithObjects_ReturnsObjectOnTheTop()
		{
			stack.Push("1");
			stack.Push("2");
			stack.Push("3");
			Assert.That(stack.Peek(), Is.EqualTo("3"));
		}

		[Test]
		public void Peek_StackWithObjects_DoesNotRemoveObjectOnTheTop()
		{
			stack.Push("hola");
			stack.Peek();
			Assert.That(stack.Count, Is.EqualTo(1));
		}

		[Test]
		public void Peek_EmptyStack_ThrowInvalidOperationException()
		{
			Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
		}

		[Test]
		public void Pop_StackWithAFewObjects_ReturnsObjectOnTheTop()
		{
			stack.Push("1");
			stack.Push("2");
			stack.Push("3");
			Assert.That(stack.Pop(), Is.EqualTo("3"));
		}

		[Test]
		public void Pop_StackWithAFewObjects_RemovesObjectOnTheTop()
		{
			stack.Push("hola");
			stack.Pop();
			Assert.That(stack.Count, Is.EqualTo(0));
		}

		[Test]
		public void Pop_EmptyStack_ThrowInvalidOperationException()
		{
			Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
		}
	}
}
