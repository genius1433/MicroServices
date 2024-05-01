using Moq;
using Npgsql;
using prac6_1000.Pages;
using Xunit;

namespace prac6_1000.Tests
{
    public class Page3ModelTests
    {
        [Fact]
        public void OnPost_UpdatesTicketStatus_Successfully()
        {
            
            var mockConnection = new Mock<NpgsqlConnection>();
            var mockCommand = new Mock<NpgsqlCommand>();
            mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteNonQuery()).Returns(1); // Simulate updating 1 row

            var pageModel = new Page3Model
            {
                TicketId = "123",
                ResultMessage = string.Empty
            };

            
            pageModel.OnPost();

            
            Assert.Equal("Successfully updated 1 row(s) in BuyTicket table.", pageModel.ResultMessage);
        }
    }
}
