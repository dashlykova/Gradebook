using System;
using Xunit;

namespace GradeBook.Test
{
  public delegate string WriteLogDelegate(string logMessage);

  public class TypeTest
  {
    int count = 0;

    [Fact]
    public void WriteDelegateCanPointToMethod()
    {
      WriteLogDelegate log = ReturnMessage;

      log += ReturnMessage;
      log += IncrementCount;

      var result = log("Hello");
      Assert.Equal(3, count);
    }
    string IncrementCount(string message)
    {
      count++;
      return message;
    }
    string ReturnMessage(string message)
    {
      count++;
      return message;
    }
    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
      string name = "Dash";
      var upper = MakeUppercase(name);

      Assert.Equal("Dash", name);
      Assert.Equal("DASH", upper);
    }

    private string MakeUppercase(string parameter)
    {
      return parameter.ToUpper();
    }

    [Fact]
    public void Test1()
    {
      var x = GetAnInt();
      SetInt(ref x);

      Assert.Equal(42, x);
    }

    private void SetInt(ref int x)
    {
      x = 42;
    }

    private int GetAnInt()
    {
      return 3;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {

      var book1 = GetBook("Book 1");
      GetBookSetName(ref book1, "New Name");

      Assert.Equal("New Name", book1.Name);

    }
    private void GetBookSetName(ref Book book, string name)
    {
      book = new Book(name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {

      var book1 = GetBook("Book 1");
      SetName(book1, "New Name");

      Assert.Equal("New Name", book1.Name);

    }

    private void SetName(Book book, string name)
    {
      book.Name = name;
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {

      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
      Assert.NotSame(book1, book2);


    }

    [Fact]
    public void TwoVariablesCanReferenceSameObject()
    {

      var book1 = GetBook("Book 1");
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));


    }

    Book GetBook(string name)
    {
      return new Book(name);
    }
  }
}
