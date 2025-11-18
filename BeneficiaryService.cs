using HumanitarianProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public class BeneficiaryService
    {
        public async Task<List<BeneficiaryList>> GetBeneficiaryListsAsync(int projectId)
        {
            List<BeneficiaryList> lists = new List<BeneficiaryList>();
            string query = "SELECT BeneficiaryListID, ProjectID, ListName, Description, CreationDate FROM BeneficiaryLists WHERE ProjectID = @ProjectID ORDER BY ListName;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectID", projectId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                BeneficiaryList list = new BeneficiaryList
                                {
                                    BeneficiaryListID = (int)reader["BeneficiaryListID"],
                                    ProjectID = (int)reader["ProjectID"],
                                    ListName = reader["ListName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                    CreationDate = (DateTime)reader["CreationDate"]
                                };
                                lists.Add(list);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetBeneficiaryListsAsync: {ex.Message}");
                // Return empty list or rethrow as appropriate
            }
            return lists;
        }

        public async Task<BeneficiaryList> GetBeneficiaryListByIdAsync(int listId)
        {
            BeneficiaryList list = null;
            string query = "SELECT BeneficiaryListID, ProjectID, ListName, Description, CreationDate FROM BeneficiaryLists WHERE BeneficiaryListID = @BeneficiaryListID;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BeneficiaryListID", listId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                list = new BeneficiaryList
                                {
                                    BeneficiaryListID = (int)reader["BeneficiaryListID"],
                                    ProjectID = (int)reader["ProjectID"],
                                    ListName = reader["ListName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                    CreationDate = (DateTime)reader["CreationDate"]
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetBeneficiaryListByIdAsync: {ex.Message}");
            }
            return list;
        }

        public async Task<bool> SaveBeneficiaryListAsync(BeneficiaryList list)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    SqlCommand command;
                    if (list.BeneficiaryListID == 0) // New list
                    {
                        string insertQuery = @"
                            INSERT INTO BeneficiaryLists (ProjectID, ListName, Description, CreationDate)
                            VALUES (@ProjectID, @ListName, @Description, @CreationDate);
                            SELECT CAST(SCOPE_IDENTITY() as int);"; // To get the new BeneficiaryListID
                        command = new SqlCommand(insertQuery, connection);

                        // Default CreationDate if not set or set to min value
                        DateTime creationDateToSave = (list.CreationDate <= DateTime.MinValue || list.CreationDate == default(DateTime))
                            ? DateTime.UtcNow
                            : list.CreationDate;
                        command.Parameters.AddWithValue("@CreationDate", creationDateToSave);
                    }
                    else // Existing list
                    {
                        string updateQuery = @"
                            UPDATE BeneficiaryLists SET 
                                ProjectID = @ProjectID, 
                                ListName = @ListName, 
                                Description = @Description 
                            WHERE BeneficiaryListID = @BeneficiaryListID;";
                        command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@BeneficiaryListID", list.BeneficiaryListID);
                    }

                    command.Parameters.AddWithValue("@ProjectID", list.ProjectID);
                    command.Parameters.AddWithValue("@ListName", list.ListName);
                    command.Parameters.AddWithValue("@Description", (object)list.Description ?? DBNull.Value);

                    await connection.OpenAsync();
                    if (list.BeneficiaryListID == 0)
                    {
                        object newId = await command.ExecuteScalarAsync();
                        if (newId != null && newId != DBNull.Value)
                        {
                            list.BeneficiaryListID = Convert.ToInt32(newId);
                            rowsAffected = 1; // SCOPE_IDENTITY() returning a value means 1 row was inserted.
                        }
                        else
                        {
                            rowsAffected = 0;
                        }
                    }
                    else
                    {
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in SaveBeneficiaryListAsync: {ex.Message}");
                return false;
            }
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteBeneficiaryListAsync(int listId)
        {
            string sql = "DELETE FROM BeneficiaryLists WHERE BeneficiaryListID = @BeneficiaryListID;";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@BeneficiaryListID", listId);
                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in DeleteBeneficiaryListAsync: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        // Methods for individual Beneficiary records
        public async Task<List<Beneficiary>> GetBeneficiariesByListIdAsync(int beneficiaryListId)
        {
            List<Beneficiary> beneficiaries = new List<Beneficiary>();
            string query = "SELECT BeneficiaryID, BeneficiaryListID, FirstName, LastName, DateOfBirth, Gender, NationalID, Address, ContactNumber, HouseholdSize, VulnerabilityCriteria, RegistrationDate FROM Beneficiaries WHERE BeneficiaryListID = @BeneficiaryListID ORDER BY LastName, FirstName;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BeneficiaryListID", beneficiaryListId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Beneficiary beneficiary = new Beneficiary
                                {
                                    BeneficiaryID = (int)reader["BeneficiaryID"],
                                    BeneficiaryListID = (int)reader["BeneficiaryListID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null,
                                    DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime?)reader["DateOfBirth"] : null,
                                    Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : null,
                                    NationalID = reader["NationalID"] != DBNull.Value ? reader["NationalID"].ToString() : null,
                                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                                    ContactNumber = reader["ContactNumber"] != DBNull.Value ? reader["ContactNumber"].ToString() : null,
                                    HouseholdSize = reader["HouseholdSize"] != DBNull.Value ? (int?)reader["HouseholdSize"] : null,
                                    VulnerabilityCriteria = reader["VulnerabilityCriteria"] != DBNull.Value ? reader["VulnerabilityCriteria"].ToString() : null,
                                    RegistrationDate = (DateTime)reader["RegistrationDate"]
                                };
                                beneficiaries.Add(beneficiary);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetBeneficiariesByListIdAsync: {ex.Message}");
            }
            return beneficiaries;
        }

        public async Task<Beneficiary> GetBeneficiaryByIdAsync(int beneficiaryId)
        {
            Beneficiary beneficiary = null;
            string query = "SELECT BeneficiaryID, BeneficiaryListID, FirstName, LastName, DateOfBirth, Gender, NationalID, Address, ContactNumber, HouseholdSize, VulnerabilityCriteria, RegistrationDate FROM Beneficiaries WHERE BeneficiaryID = @BeneficiaryID;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BeneficiaryID", beneficiaryId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                beneficiary = new Beneficiary
                                {
                                    BeneficiaryID = (int)reader["BeneficiaryID"],
                                    BeneficiaryListID = (int)reader["BeneficiaryListID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null,
                                    DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime?)reader["DateOfBirth"] : null,
                                    Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : null,
                                    NationalID = reader["NationalID"] != DBNull.Value ? reader["NationalID"].ToString() : null,
                                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                                    ContactNumber = reader["ContactNumber"] != DBNull.Value ? reader["ContactNumber"].ToString() : null,
                                    HouseholdSize = reader["HouseholdSize"] != DBNull.Value ? (int?)reader["HouseholdSize"] : null,
                                    VulnerabilityCriteria = reader["VulnerabilityCriteria"] != DBNull.Value ? reader["VulnerabilityCriteria"].ToString() : null,
                                    RegistrationDate = (DateTime)reader["RegistrationDate"]
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetBeneficiaryByIdAsync: {ex.Message}");
            }
            return beneficiary;
        }

        public async Task<bool> SaveBeneficiaryAsync(Beneficiary beneficiary)
        {
            if (beneficiary.BeneficiaryListID <= 0)
            {
                // Or throw new ArgumentException("BeneficiaryListID must be greater than 0.");
                Console.WriteLine("Error in SaveBeneficiaryAsync: BeneficiaryListID must be greater than 0.");
                return false;
            }

            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    SqlCommand command;
                    if (beneficiary.BeneficiaryID == 0) // New beneficiary
                    {
                        string insertQuery = @"
                            INSERT INTO Beneficiaries (BeneficiaryListID, FirstName, LastName, DateOfBirth, Gender, NationalID, Address, ContactNumber, HouseholdSize, VulnerabilityCriteria, RegistrationDate) 
                            VALUES (@BeneficiaryListID, @FirstName, @LastName, @DateOfBirth, @Gender, @NationalID, @Address, @ContactNumber, @HouseholdSize, @VulnerabilityCriteria, @RegistrationDate); 
                            SELECT CAST(SCOPE_IDENTITY() as int);";
                        command = new SqlCommand(insertQuery, connection);

                        DateTime registrationDateToSave = (beneficiary.RegistrationDate <= DateTime.MinValue || beneficiary.RegistrationDate == default(DateTime))
                            ? DateTime.UtcNow
                            : beneficiary.RegistrationDate;
                        command.Parameters.AddWithValue("@RegistrationDate", registrationDateToSave);
                    }
                    else // Existing beneficiary
                    {
                        string updateQuery = @"
                            UPDATE Beneficiaries SET 
                                BeneficiaryListID = @BeneficiaryListID, FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Gender = @Gender, 
                                NationalID = @NationalID, Address = @Address, ContactNumber = @ContactNumber, HouseholdSize = @HouseholdSize, 
                                VulnerabilityCriteria = @VulnerabilityCriteria, RegistrationDate = @RegistrationDate 
                            WHERE BeneficiaryID = @BeneficiaryID;";
                        command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@BeneficiaryID", beneficiary.BeneficiaryID);
                        command.Parameters.AddWithValue("@RegistrationDate", beneficiary.RegistrationDate); // Use existing for updates
                    }

                    command.Parameters.AddWithValue("@BeneficiaryListID", beneficiary.BeneficiaryListID);
                    command.Parameters.AddWithValue("@FirstName", beneficiary.FirstName);
                    command.Parameters.AddWithValue("@LastName", (object)beneficiary.LastName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DateOfBirth", (object)beneficiary.DateOfBirth ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Gender", (object)beneficiary.Gender ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NationalID", (object)beneficiary.NationalID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Address", (object)beneficiary.Address ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ContactNumber", (object)beneficiary.ContactNumber ?? DBNull.Value);
                    command.Parameters.AddWithValue("@HouseholdSize", (object)beneficiary.HouseholdSize ?? DBNull.Value);
                    command.Parameters.AddWithValue("@VulnerabilityCriteria", (object)beneficiary.VulnerabilityCriteria ?? DBNull.Value);

                    await connection.OpenAsync();
                    if (beneficiary.BeneficiaryID == 0)
                    {
                        object newId = await command.ExecuteScalarAsync();
                        if (newId != null && newId != DBNull.Value)
                        {
                            beneficiary.BeneficiaryID = Convert.ToInt32(newId);
                            rowsAffected = 1;
                        }
                    }
                    else
                    {
                        rowsAffected = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in SaveBeneficiaryAsync: {ex.Message}");
                return false;
            }
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteBeneficiaryAsync(int beneficiaryId)
        {
            string sql = "DELETE FROM Beneficiaries WHERE BeneficiaryID = @BeneficiaryID;";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@BeneficiaryID", beneficiaryId);
                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in DeleteBeneficiaryAsync: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public async Task<List<Beneficiary>> SearchBeneficiariesAsync(string searchTerm, int? beneficiaryListId = null)
        {
            List<Beneficiary> beneficiaries = new List<Beneficiary>();
            StringBuilder queryBuilder = new StringBuilder(
                "SELECT BeneficiaryID, BeneficiaryListID, FirstName, LastName, DateOfBirth, Gender, NationalID, Address, ContactNumber, HouseholdSize, VulnerabilityCriteria, RegistrationDate FROM Beneficiaries WHERE (FirstName LIKE @SearchPattern OR LastName LIKE @SearchPattern OR NationalID LIKE @SearchPattern)");

            if (beneficiaryListId.HasValue)
            {
                queryBuilder.Append(" AND BeneficiaryListID = @BeneficiaryListID");
            }
            queryBuilder.Append(" ORDER BY LastName, FirstName;");

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                    {
                        command.Parameters.AddWithValue("@SearchPattern", $"%{searchTerm}%");
                        if (beneficiaryListId.HasValue)
                        {
                            command.Parameters.AddWithValue("@BeneficiaryListID", beneficiaryListId.Value);
                        }

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Beneficiary beneficiary = new Beneficiary
                                {
                                    BeneficiaryID = (int)reader["BeneficiaryID"],
                                    BeneficiaryListID = (int)reader["BeneficiaryListID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null,
                                    DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime?)reader["DateOfBirth"] : null,
                                    Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : null,
                                    NationalID = reader["NationalID"] != DBNull.Value ? reader["NationalID"].ToString() : null,
                                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                                    ContactNumber = reader["ContactNumber"] != DBNull.Value ? reader["ContactNumber"].ToString() : null,
                                    HouseholdSize = reader["HouseholdSize"] != DBNull.Value ? (int?)reader["HouseholdSize"] : null,
                                    VulnerabilityCriteria = reader["VulnerabilityCriteria"] != DBNull.Value ? reader["VulnerabilityCriteria"].ToString() : null,
                                    RegistrationDate = (DateTime)reader["RegistrationDate"]
                                };
                                beneficiaries.Add(beneficiary);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in SearchBeneficiariesAsync: {ex.Message}");
            }
            return beneficiaries;
        }
    }
}
