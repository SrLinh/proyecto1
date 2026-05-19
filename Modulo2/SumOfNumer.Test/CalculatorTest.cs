using Xunit;
public class CalculatorTest
{
[Fact]
public void SumOf1And3()
{
var calculator = new Calculator();
var result = calculator.Sum(4, 6);
Assert.Equal(10, result);
}

}