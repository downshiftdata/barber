namespace barber.CodeGen.Test
{
    public class DeleteStatementBuilderTests
    {
        [Xunit.Fact]
        public void TestDelete()
        {
            // Arrange
            var options = new Models.StatementBuilderOptions()
            {
                StatementType = Core.Enum.StatementType.Delete,
                SchemaName = "foo",
                TableName = "bar",
                Parameters =
                [
                    new() { DbType = System.Data.DbType.AnsiString, IsFilter = true, Name = "col1", Value = "val1" }
                ]
            };
            var builder = new Builders.DeleteStatementBuilder();

            // Act
            var value = builder.Build(options);

            // Assert
            Xunit.Assert.Equal("DELETE\r\n    FROM foo.bar\r\n    WHERE col1 = 'val1';", value);

        }
    }
}