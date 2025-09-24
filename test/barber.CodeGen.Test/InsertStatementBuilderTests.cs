namespace barber.CodeGen.Test
{
    public class InsertStatementBuilderTests
    {
        [Xunit.Fact]
        public void TestInsert()
        {
            // Arrange
            var options = new Models.StatementBuilderOptions()
            {
                StatementType = Core.Enum.StatementType.Insert,
                SchemaName = "foo",
                TableName = "bar",
                Parameters =
                [
                    new() { DbType = System.Data.DbType.AnsiString, Name = "col1", Value = "val1" }
                ]
            };
            var builder = new Builders.InsertStatementBuilder();

            // Act
            var value = builder.Build(options);

            // Assert
            Xunit.Assert.Equal("INSERT INTO foo.bar (col1)\r\n    SELECT 'val1';", value);

        }
    }
}