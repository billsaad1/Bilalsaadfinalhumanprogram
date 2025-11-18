using HumanitarianProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using HumanitarianProjectManagement.Utilities; // Added

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public class UserService
    {
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            User user = null;
            // Changed SQL to fetch user by username first, then verify password
            string query = "SELECT UserID, Username, PasswordHash, Email, FullName, PhoneNumber, IsActive, LastLogin, CreatedAt FROM Users WHERE Username = @Username;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                bool isActive = (bool)reader["IsActive"];
                                string storedPasswordHash = reader["PasswordHash"].ToString();

                                if (isActive && !string.IsNullOrEmpty(storedPasswordHash))
                                {
                                    bool isValidPassword = PasswordHelper.VerifyPassword(password, storedPasswordHash);
                                    if (isValidPassword)
                                    {
                                        user = new User
                                        {
                                            UserID = (int)reader["UserID"],
                                            Username = reader["Username"].ToString(),
                                            PasswordHash = storedPasswordHash, // Keep the hash
                                            Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                            FullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : null,
                                            PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                                            IsActive = isActive,
                                            LastLogin = reader["LastLogin"] != DBNull.Value ? (DateTime?)reader["LastLogin"] : null,
                                            CreatedAt = (DateTime)reader["CreatedAt"]
                                        };
                                        // Optionally, update LastLogin here
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in AuthenticateUserAsync: {ex.Message}");
                return null;
            }
            return user;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            User user = null;
            string query = "SELECT UserID, Username, Email, FullName, PhoneNumber, IsActive, LastLogin, CreatedAt FROM Users WHERE UserID = @UserID;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                user = new User
                                {
                                    UserID = (int)reader["UserID"],
                                    Username = reader["Username"].ToString(),
                                    Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                    FullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : null,
                                    PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                                    IsActive = (bool)reader["IsActive"],
                                    LastLogin = reader["LastLogin"] != DBNull.Value ? (DateTime?)reader["LastLogin"] : null,
                                    CreatedAt = (DateTime)reader["CreatedAt"]
                                    // PasswordHash is intentionally excluded
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetUserByIdAsync: {ex.Message}");
            }
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync() // Added from previous task for PurchaseOrderCreateEditForm
        {
            List<User> users = new List<User>();
            string query = "SELECT UserID, Username, FullName, Email, IsActive FROM Users WHERE IsActive = 1 ORDER BY FullName;";

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
                                User user = new User
                                {
                                    UserID = (int)reader["UserID"],
                                    Username = reader["Username"].ToString(),
                                    FullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : null,
                                    Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                    IsActive = (bool)reader["IsActive"]
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetAllUsersAsync: {ex.Message}");
            }
            return users;
        }


        public async Task<List<Role>> GetAllRolesAsync()
        {
            List<Role> roles = new List<Role>();
            string query = "SELECT RoleID, RoleName, Description FROM Roles ORDER BY RoleName;";

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
                                Role role = new Role
                                {
                                    RoleID = (int)reader["RoleID"],
                                    RoleName = reader["RoleName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null
                                };
                                roles.Add(role);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetAllRolesAsync: {ex.Message}");
            }
            return roles;
        }

        public async Task<List<int>> GetRoleIdsForUserAsync(int userId)
        {
            List<int> roleIds = new List<int>();
            string query = "SELECT RoleID FROM UserRoles WHERE UserID = @UserID;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                roleIds.Add((int)reader["RoleID"]);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetRoleIdsForUserAsync: {ex.Message}");
            }
            return roleIds;
        }

        public async Task<bool> SaveUserAsync(User user, string plainTextPassword, List<int> roleIds)
        {
            // TODO: Wrap User save and UserRoles update in a database transaction for atomicity.
            int rowsAffected = 0;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                await connection.OpenAsync();
                // SqlTransaction transaction = connection.BeginTransaction(); // Start transaction

                try
                {
                    SqlCommand command;
                    if (user.UserID == 0) // New User
                    {
                        if (string.IsNullOrWhiteSpace(plainTextPassword))
                        {
                            // transaction.Rollback();
                            throw new ArgumentException("Password is required for new users.", nameof(plainTextPassword));
                        }
                        user.PasswordHash = PasswordHelper.HashPassword(plainTextPassword);
                        user.CreatedAt = DateTime.UtcNow;

                        string insertQuery = @"
                            INSERT INTO Users (Username, PasswordHash, Email, FullName, PhoneNumber, IsActive, CreatedAt) 
                            VALUES (@Username, @PasswordHash, @Email, @FullName, @PhoneNumber, @IsActive, @CreatedAt); 
                            SELECT CAST(SCOPE_IDENTITY() as int);";
                        command = new SqlCommand(insertQuery, connection /*, transaction*/);
                        command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                        command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);
                    }
                    else // Existing User
                    {
                        // Note: Password update should be a separate dedicated method for security (e.g., ChangePasswordAsync)
                        // This SaveUserAsync will not update password for existing users.
                        string updateQuery = @"
                            UPDATE Users SET 
                                Username = @Username, Email = @Email, FullName = @FullName, 
                                PhoneNumber = @PhoneNumber, IsActive = @IsActive 
                            WHERE UserID = @UserID;";
                        command = new SqlCommand(updateQuery, connection /*, transaction*/);
                        command.Parameters.AddWithValue("@UserID", user.UserID);
                    }

                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FullName", (object)user.FullName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PhoneNumber", (object)user.PhoneNumber ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);

                    if (user.UserID == 0)
                    {
                        object newId = await command.ExecuteScalarAsync();
                        if (newId != null && newId != DBNull.Value)
                        {
                            user.UserID = Convert.ToInt32(newId);
                            rowsAffected = 1;
                        }
                        else
                        {
                            // transaction.Rollback();
                            return false; // Insert failed or ID not retrieved
                        }
                    }
                    else
                    {
                        rowsAffected = await command.ExecuteNonQueryAsync();
                        if (rowsAffected == 0)
                        {
                            // transaction.Rollback();
                            return false; // Update failed (user not found or no data changed)
                        }
                    }

                    // Manage UserRoles
                    if (user.UserID > 0) // Ensure UserID is valid
                    {
                        string deleteRolesQuery = "DELETE FROM UserRoles WHERE UserID = @UserID;";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteRolesQuery, connection /*, transaction*/))
                        {
                            deleteCmd.Parameters.AddWithValue("@UserID", user.UserID);
                            await deleteCmd.ExecuteNonQueryAsync();
                        }

                        if (roleIds != null && roleIds.Count > 0)
                        {
                            string insertRoleQuery = "INSERT INTO UserRoles (UserID, RoleID) VALUES (@UserID, @RoleID);";
                            foreach (int roleId in roleIds)
                            {
                                using (SqlCommand insertRoleCmd = new SqlCommand(insertRoleQuery, connection /*, transaction*/))
                                {
                                    insertRoleCmd.Parameters.AddWithValue("@UserID", user.UserID);
                                    insertRoleCmd.Parameters.AddWithValue("@RoleID", roleId);
                                    try
                                    {
                                        await insertRoleCmd.ExecuteNonQueryAsync();
                                    }
                                    catch (SqlException ex)
                                    {
                                        // Log this specific role insert failure, but continue for others
                                        Console.WriteLine($"SQL Error inserting role ID {roleId} for user ID {user.UserID}: {ex.Message}");
                                        // Depending on policy, might decide to rollback here or just log and continue
                                    }
                                }
                            }
                        }
                    }
                    // transaction.Commit();
                    return true; // User save part was successful
                }
                catch (SqlException ex)
                {
                    // if (transaction.Connection != null) transaction.Rollback(); // Ensure transaction is rolled back
                    Console.WriteLine($"SQL Error in SaveUserAsync: {ex.Message}");
                    return false;
                }
                catch (ArgumentException ex)
                {
                    // if (transaction.Connection != null) transaction.Rollback();
                    Console.WriteLine($"Argument Error in SaveUserAsync: {ex.Message}");
                    throw; // Re-throw argument exceptions as they indicate bad input
                }
                catch (Exception ex)
                {
                    // if (transaction.Connection != null) transaction.Rollback();
                    Console.WriteLine($"Generic Error in SaveUserAsync: {ex.Message}");
                    return false;
                }
            }
        }

        public async Task<bool> DeactivateUserAsync(int userId)
        {
            string sql = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID;";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in DeactivateUserAsync: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public async Task<bool> ActivateUserAsync(int userId)
        {
            string sql = "UPDATE Users SET IsActive = 1 WHERE UserID = @UserID;";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in ActivateUserAsync: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        internal object GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
