namespace xUnitTestPrime
{
    public class PrimeNumberTest
    {
        [Fact]
        public void TestPrime()
        {
            //Arrange
            var _primenumber = 10;
            var expectedvalue = true;
            //Act
            expectedvalue = Enumerable.Range(1, _primenumber).Where(x => _primenumber % x == 0)
                                 .SequenceEqual(new[] { 1, _primenumber });

            //Assert  
            Assert.True(expectedvalue);
        }
    }
}