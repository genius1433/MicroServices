using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace prac6_1000.Tests
{
    public class Page3ModelComponentTests
    {
        [Fact]
        public async Task UpdateStatusToDone_DisplaysSuccessMessage()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://localhost:62997/Page3"); // Replace with your Razor Page URL

            // Simulate user interaction
            await page.FillAsync("input[asp-for='TicketId']", "123"); // Assuming the input has an asp-for attribute for TicketId
            await page.ClickAsync("button[type='submit']"); // Click the submit button

            // Verify the result message is displayed
            var resultMessage = await page.TextContentAsync("p"); // Assuming the result message is displayed in a <p> tag
            Assert.Contains("Successfully updated", resultMessage);
        }
    }
}