namespace barber.CodeGen.Test
{
    public class UpdateStatementBuilderTests
    {
        [Xunit.Fact]
        public void TestUpdate()
        {
            // Arrange
            var options = new Models.StatementBuilderOptions()
            {
                StatementType = Core.Enum.StatementType.Update,
                SchemaName = "foo",
                TableName = "bar",
                Parameters =
                [
                    new() { DbType = System.Data.DbType.AnsiString, IsFilter = false, Name = "col1", Value = "val1" },
                    new() { DbType = System.Data.DbType.AnsiString, IsFilter = true, Name = "col2", Value = "val2" }
                ]
            };
            var builder = new Builders.UpdateStatementBuilder();

            // Act
            var value = builder.Build(options);

            // Assert
            Xunit.Assert.Equal("UPDATE foo.bar\r\n    SET col1 = 'val1'\r\n    WHERE col2 = 'val2';", value);

        }
    }
}