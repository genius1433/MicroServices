using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;
using System.Collections.Generic;

namespace prac6_1000.Pages
{
    public class page2Model : PageModel
    {
        public List<Client> Clients { get; set; }

        public void OnGet()
        {
            string connString = "Host=db;Port=5432;Username=root;Password=root;Database=postgres;";

            Clients = new List<Client>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT * FROM Client";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var client = new Client
                            {
                                id = reader["id"].ToString(),
                                name = reader["name"].ToString(),
                            };

                            Clients.Add(client);
                        }
                    }
                }
            }
        }
    }
}
