using HumanitarianProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.DataAccessLayer // Corrected namespace
{
    public class SectionService
    {
        /// <summary>
        /// Retrieves all sections from the database.
        /// </summary>
        /// <returns>A list of Section objects.</returns>
        public async Task<List<Section>> GetSectionsAsync()
        {
            List<Section> sections = new List<Section>();
            string query = "SELECT SectionID, SectionName, Description FROM Sections";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Section section = new Section
                                {
                                    SectionID = reader.GetInt32(reader.GetOrdinal("SectionID")),
                                    SectionName = reader.GetString(reader.GetOrdinal("SectionName")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
                                };
                                sections.Add(section);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception (e.g., using a logging framework)
                Console.WriteLine($"SQL Error in GetSectionsAsync: {ex.Message}");
                // Depending on policy, either return empty list or re-throw
                // For now, returning an empty list for resilience
            }
            catch (Exception ex)
            {
                // Log other types of exceptions
                Console.WriteLine($"General Error in GetSectionsAsync: {ex.Message}");
            }
            return sections;
        }

        /// <summary>
        /// Adds a new section to the database.
        /// </summary>
        /// <param name="section">The Section object to add. SectionID is ignored.</param>
        /// <returns>The SectionID of the newly added section, or 0 if insertion fails.</returns>
        public async Task<int> AddSectionAsync(Section section)
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            // Ensure SectionName is provided, as it\'s required by the model
            if (string.IsNullOrWhiteSpace(section.SectionName))
                throw new ArgumentException("SectionName cannot be empty or whitespace.", nameof(section.SectionName));

            string query = @"
                INSERT INTO Sections (SectionName, Description)
                VALUES (@SectionName, @Description);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SectionName", section.SectionName);
                        command.Parameters.AddWithValue("@Description", (object)section.Description ?? DBNull.Value);

                        await connection.OpenAsync();
                        object newId = await command.ExecuteScalarAsync();
                        if (newId != null && newId != DBNull.Value)
                        {
                            return Convert.ToInt32(newId);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in AddSectionAsync: {ex.Message}");
                // Check for specific SQL errors if needed, e.g., unique constraint violation
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in AddSectionAsync: {ex.Message}");
            }
            return 0; // Return 0 to indicate failure
        }
    }
}

