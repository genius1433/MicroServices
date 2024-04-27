using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
using System.Collections.Generic;

namespace prac6_1000.Pages
{
    public class Page1Model : PageModel
    {
        public List<BuyTicket> Tickets { get; set; }

        public void OnGet()
        {
            string connString = "Host=db;Port=5432;Username=root;Password=root;Database=postgres;";

            Tickets = new List<BuyTicket>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT * FROM BuyTicket";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ticket = new BuyTicket
                            {
                                id = reader["id"].ToString(),
                                film = reader["film"].ToString(),
                                places = reader["places"].ToString(),
                                date = reader["date"].ToString(),
                                status = reader["status"].ToString(),
                                clientID = reader["clientID"].ToString()
                            };

                            Tickets.Add(ticket);
                        }
                    }
                }
            }
        }
    }
}
