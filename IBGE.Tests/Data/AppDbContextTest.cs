using IBGE.Data;

namespace IBGE.Tests.Data
{
    [ExcludeFromCodeCoverage]
    public class AppDbContextTest
    {
        [Fact]
        public void Testa_Conexao_Com_SqlServer()
        {
            // Arrange 
            var context = new AppDbContext();
            bool connected;

            // Act
            try
            {
                connected = context.Database.CanConnect();
            }
            catch (Exception)
            {
                throw new Exception("Unable to connect to database");
            }

            // Assert
            Assert.True(connected);
        }
    }
}
