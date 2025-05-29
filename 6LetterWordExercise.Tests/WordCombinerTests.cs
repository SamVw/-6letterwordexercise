using FluentAssertions;
using Xunit.Sdk;

public class WordCombinerTests
{
    [Fact]
    public void FindCombinations_GivenNoInput_ShouldReturnEmptyResult()
    {
        // Arrange
        var sut = GetSut();

        // Act
        var result = sut.FindCombinations([]);

        // Assert
        result.Should().BeEmpty();
    }

    [Theory]
    [MemberData(nameof(TwoWordsCombinations))]
    [MemberData(nameof(MultipleWordsCombinations))]
    public void FindCombinations_GivenInputOfCombinations_ShouldReturnCombinationIfWordAlreadyexists(string[] input, string output)
    {
        // Arrange
        var sut = GetSut();

        // Act
        var result = sut.FindCombinations(input);

        // Assert
        result.Should().HaveCount(1);
        result[0].Combination.Should().Be(output);
    }

    [Fact]
    public void FindCombinations_GivenDuplicateInputValues_ShouldReturnDistinctCombinations()
    {
        // Arrange
        string[] words = [
            "foo", "bar", "foo", "bar", "foobar"
        ];
        var sut = GetSut();

        // Act
        var result = sut.FindCombinations(words);

        // Assert
        result.Count().Should().Be(1);
        result[0].Combination.Should().Be("foobar");
    }


    private static WordsCombiner GetSut()
    {
        return new WordsCombiner();
    }

    public static IEnumerable<object[]> TwoWordsCombinations =>
        new List<object[]>
        {
            // two word combinations
            new object[] { new string[] { "fo", "obar", "foobar" }, "foobar" },
            new object[] { new string[] { "f", "oobar", "foobar" }, "foobar" },
            new object[] { new string[] { "fo", "foobar", "obar" }, "foobar" },
            new object[] { new string[] { "f", "foobar", "oobar" }, "foobar" },
            new object[] { new string[] { "foobar", "fo", "obar" }, "foobar" },
            new object[] { new string[] { "foobar", "f", "oobar" }, "foobar" },
            new object[] { new string[] {  "obar","fo", "foobar" }, "foobar" },
            new object[] { new string[] {  "oobar","f", "foobar" }, "foobar" },
            new object[] { new string[] { "obar", "fo", "foobar" }, "foobar" },
            new object[] { new string[] { "oobar", "foobar", "f" }, "foobar" },
            new object[] { new string[] { "foobar", "obar", "fo" }, "foobar" },
            new object[] { new string[] { "foobar", "oobar", "f" }, "foobar" },
            new object[] { new string[] { "lol", "fo", "obar", "foobar" }, "foobar" },
        };

    public static IEnumerable<object[]> MultipleWordsCombinations =>
        new List<object[]>
        {
            // two word combinations
            new object[] { new string[] { "f", "o", "obar", "foobar" }, "foobar" },
            new object[] { new string[] { "f", "o", "o", "bar", "foobar" }, "foobar" },
            new object[] { new string[] { "o", "f", "o", "bar", "foobar" }, "foobar" },
            new object[] { new string[] { "zam", "bia", "ted", "zambia" }, "zambia" },

        };
}