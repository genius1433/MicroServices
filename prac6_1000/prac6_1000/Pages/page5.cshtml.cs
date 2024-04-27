using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace prac6_1000.Pages
{
    public class Page5Model : PageModel
    {
        [BindProperty]
        public string TicketId { get; set; }

        [BindProperty]
        public string ClientId { get; set; }

        public string ResultMessage { get; set; }

        public void OnGet()
        {
            // Метод OnGet остается без изменений
        }

        public void OnPost()
        {
            string connString = "Host=db;Port=5432;Username=root;Password=root;Database=postgres;";

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        // Update ClientID for a specific record in BuyTicket table based on TicketId
                        cmd.CommandText = $"UPDATE BuyTicket SET clientID = '{ClientId}' WHERE id = '{TicketId}';";

                        int rowsAffected = cmd.ExecuteNonQuery();

                        ResultMessage = $"Successfully updated {rowsAffected} row(s) in BuyTicket table.";
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                ResultMessage = "Error updating clientID in BuyTicket table: " + ex.Message;
            }
        }
    }
}
