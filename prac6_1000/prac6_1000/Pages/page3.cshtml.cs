using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace prac6_1000.Pages
{
    public class Page3Model : PageModel
    {
        [BindProperty]
        public string TicketId { get; set; }

        public string ResultMessage { get; set; }

        public void OnGet()
        {
            
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

                        
                        cmd.CommandText = $"UPDATE BuyTicket SET status = 'Done' WHERE id = '{TicketId}';";

                        int rowsAffected = cmd.ExecuteNonQuery();

                        ResultMessage = $"Successfully updated {rowsAffected} row(s) in BuyTicket table.";
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                ResultMessage = "Error updating status in BuyTicket table: " + ex.Message;
            }
        }
    }
}
