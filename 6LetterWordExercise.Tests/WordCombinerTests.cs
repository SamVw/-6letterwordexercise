using FluentAssertions;
using Xunit.Sdk;

public class WordCombinerTests
{
    [Fact]
    public void FindCombinations_GivenNoInput_ShouldReturnEmptyResult()
    {
        // Arrange
        var sut = new WordsCombiner([]);

        // Act
        var result = sut.FindCombinations();

        // Assert
        result.Should().BeEmpty();
    }

    [Theory]
    [MemberData(nameof(TwoWordsCombinations))]
    public void FindCombinations_GivenInputOfTwoWordsCombinations_ShouldReturnCombinationIfWordAlreadyexists(string[] input, string output)
    {
        // Arrange
        var sut = new WordsCombiner(input);

        // Act
        var result = sut.FindCombinations();

        // Assert
        result.Should().HaveCount(1);
        result[0].Combination.Should().Be(output);
    }

    public static IEnumerable<object[]> TwoWordsCombinations =>
        new List<object[]>
        {
            new object[] { new string[] { "fo", "obar", "foobar" }, "foobar" },
            new object[] { new string[] { "f", "oobar", "foobar" }, "foobar" },
            new object[] { new string[] { "fo", "foobar", "obar" }, "foobar" },
            new object[] { new string[] { "f", "foobar", "oobar" }, "foobar" },
            new object[] { new string[] { "foobar", "fo", "obar" }, "foobar" },
            new object[] { new string[] { "foobar", "f", "oobar" }, "foobar" },
        };
}