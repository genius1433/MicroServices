using Moq;
using Npgsql;
using prac6_1000.Pages;
using Xunit;

namespace prac6_1000.Tests
{
    public class Page5ModelTests
    {
        [Fact]
        public void OnPost_UpdatesClientIdForTicket_Successfully()
        {
            // Arrange
            var mockConnection = new Mock<NpgsqlConnection>();
            var mockCommand = new Mock<NpgsqlCommand>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteNonQuery()).Returns(1); 

            var pageModel = new Page5Model
            {
                TicketId = "123",
                ClientId = "456",
                ResultMessage = string.Empty
            };

            
            pageModel.OnPost();

            
            Assert.Equal("Successfully updated 1 row(s) in BuyTicket table.", pageModel.ResultMessage);
        }
    }
}
