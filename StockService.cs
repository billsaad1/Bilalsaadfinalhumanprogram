using HumanitarianProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public class StockService
    {
        public async Task<List<StockItem>> GetAllStockItemsAsync(string searchTerm = null)
        {
            List<StockItem> items = new List<StockItem>();
            StringBuilder queryBuilder = new StringBuilder("SELECT StockItemID, ItemName, Description, UnitOfMeasure, CurrentQuantity, MinStockLevel, MaxStockLevel, LastStockUpdate, Notes FROM StockItems");

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                queryBuilder.Append(" WHERE (ItemName LIKE @SearchPattern OR Description LIKE @SearchPattern)");
            }
            queryBuilder.Append(" ORDER BY ItemName;");

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                    {
                        if (!string.IsNullOrWhiteSpace(searchTerm))
                        {
                            command.Parameters.AddWithValue("@SearchPattern", $"%{searchTerm}%");
                        }

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                StockItem item = new StockItem
                                {
                                    StockItemID = (int)reader["StockItemID"],
                                    ItemName = reader["ItemName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                    UnitOfMeasure = reader["UnitOfMeasure"] != DBNull.Value ? reader["UnitOfMeasure"].ToString() : null,
                                    CurrentQuantity = (int)reader["CurrentQuantity"],
                                    MinStockLevel = reader["MinStockLevel"] != DBNull.Value ? (int)reader["MinStockLevel"] : 0, // Default to 0 if null from DB, as model int is not nullable
                                    MaxStockLevel = reader["MaxStockLevel"] != DBNull.Value ? (int?)reader["MaxStockLevel"] : null,
                                    LastStockUpdate = reader["LastStockUpdate"] != DBNull.Value ? (DateTime)reader["LastStockUpdate"] : default(DateTime), // Default to minvalue if null from DB, as model DateTime is not nullable
                                    Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null
                                };
                                // Adjust default values if they were set due to non-nullable model properties
                                if (item.MinStockLevel == 0 && reader["MinStockLevel"] == DBNull.Value) item.MinStockLevel = 0; // Explicitly ensure 0 if DB was null
                                if (item.LastStockUpdate == default(DateTime) && reader["LastStockUpdate"] == DBNull.Value) item.LastStockUpdate = default(DateTime);


                                items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetAllStockItemsAsync: {ex.Message}");
            }
            return items;
        }

        public async Task<StockItem> GetStockItemByIdAsync(int stockItemId)
        {
            StockItem item = null;
            string query = "SELECT StockItemID, ItemName, Description, UnitOfMeasure, CurrentQuantity, MinStockLevel, MaxStockLevel, LastStockUpdate, Notes FROM StockItems WHERE StockItemID = @StockItemID;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StockItemID", stockItemId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                item = new StockItem
                                {
                                    StockItemID = (int)reader["StockItemID"],
                                    ItemName = reader["ItemName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                    UnitOfMeasure = reader["UnitOfMeasure"] != DBNull.Value ? reader["UnitOfMeasure"].ToString() : null,
                                    CurrentQuantity = (int)reader["CurrentQuantity"],
                                    MinStockLevel = reader["MinStockLevel"] != DBNull.Value ? (int)reader["MinStockLevel"] : 0,
                                    MaxStockLevel = reader["MaxStockLevel"] != DBNull.Value ? (int?)reader["MaxStockLevel"] : null,
                                    LastStockUpdate = reader["LastStockUpdate"] != DBNull.Value ? (DateTime)reader["LastStockUpdate"] : default(DateTime),
                                    Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null
                                };
                                if (item.MinStockLevel == 0 && reader["MinStockLevel"] == DBNull.Value) item.MinStockLevel = 0;
                                if (item.LastStockUpdate == default(DateTime) && reader["LastStockUpdate"] == DBNull.Value) item.LastStockUpdate = default(DateTime);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetStockItemByIdAsync: {ex.Message}");
            }
            return item;
        }

        public async Task<bool> SaveStockItemAsync(StockItem stockItem)
        {
            stockItem.LastStockUpdate = DateTime.UtcNow;
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    SqlCommand command;
                    if (stockItem.StockItemID == 0) // New item
                    {
                        string insertQuery = @"
                            INSERT INTO StockItems (ItemName, Description, UnitOfMeasure, CurrentQuantity, MinStockLevel, MaxStockLevel, LastStockUpdate, Notes) 
                            VALUES (@ItemName, @Description, @UnitOfMeasure, @CurrentQuantity, @MinStockLevel, @MaxStockLevel, @LastStockUpdate, @Notes); 
                            SELECT CAST(SCOPE_IDENTITY() as int);";
                        command = new SqlCommand(insertQuery, connection);
                    }
                    else // Existing item
                    {
                        string updateQuery = @"
                            UPDATE StockItems SET 
                                ItemName = @ItemName, Description = @Description, UnitOfMeasure = @UnitOfMeasure, CurrentQuantity = @CurrentQuantity, 
                                MinStockLevel = @MinStockLevel, MaxStockLevel = @MaxStockLevel, LastStockUpdate = @LastStockUpdate, Notes = @Notes 
                            WHERE StockItemID = @StockItemID;";
                        command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@StockItemID", stockItem.StockItemID);
                    }

                    command.Parameters.AddWithValue("@ItemName", stockItem.ItemName);
                    command.Parameters.AddWithValue("@Description", (object)stockItem.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@UnitOfMeasure", (object)stockItem.UnitOfMeasure ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CurrentQuantity", stockItem.CurrentQuantity);
                    command.Parameters.AddWithValue("@MinStockLevel", stockItem.MinStockLevel); // Model is int, not nullable
                    command.Parameters.AddWithValue("@MaxStockLevel", (object)stockItem.MaxStockLevel ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastStockUpdate", stockItem.LastStockUpdate); // Model is DateTime, not nullable
                    command.Parameters.AddWithValue("@Notes", (object)stockItem.Notes ?? DBNull.Value);

                    await connection.OpenAsync();
                    if (stockItem.StockItemID == 0)
                    {
                        object newId = await command.ExecuteScalarAsync();
                        if (newId != null && newId != DBNull.Value)
                        {
                            stockItem.StockItemID = Convert.ToInt32(newId);
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
                Console.WriteLine($"SQL Error in SaveStockItemAsync: {ex.Message}");
                return false;
            }
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteStockItemAsync(int stockItemId)
        {
            string sql = "DELETE FROM StockItems WHERE StockItemID = @StockItemID;";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StockItemID", stockItemId);
                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in DeleteStockItemAsync: {ex.Message}");
                        // Consider specific error handling for FK violations if needed
                        return false;
                    }
                }
            }
        }

        // New methods for StockTransactions
        public async Task<List<StockTransaction>> GetTransactionsForItemAsync(int stockItemId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            List<StockTransaction> transactions = new List<StockTransaction>();
            StringBuilder queryBuilder = new StringBuilder(
                "SELECT TransactionID, StockItemID, TransactionType, Quantity, TransactionDate, ProjectID, PurchaseOrderID, ActivityID, BeneficiaryID, DistributedTo, Reason, RecordedByUserID, Notes FROM StockTransactions WHERE StockItemID = @StockItemID");

            if (fromDate.HasValue)
            {
                queryBuilder.Append(" AND TransactionDate >= @FromDate");
            }
            if (toDate.HasValue)
            {
                queryBuilder.Append(" AND TransactionDate <= @ToDate");
            }
            queryBuilder.Append(" ORDER BY TransactionDate DESC;");

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                    {
                        command.Parameters.AddWithValue("@StockItemID", stockItemId);
                        if (fromDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@FromDate", fromDate.Value);
                        }
                        if (toDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@ToDate", toDate.Value);
                        }

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                StockTransaction transaction = new StockTransaction
                                {
                                    TransactionID = (int)reader["TransactionID"],
                                    StockItemID = (int)reader["StockItemID"],
                                    TransactionType = reader["TransactionType"].ToString(),
                                    Quantity = (int)reader["Quantity"],
                                    TransactionDate = (DateTime)reader["TransactionDate"],
                                    ProjectID = reader["ProjectID"] != DBNull.Value ? (int?)reader["ProjectID"] : null,
                                    PurchaseOrderID = reader["PurchaseOrderID"] != DBNull.Value ? (int?)reader["PurchaseOrderID"] : null,
                                    ActivityID = reader["ActivityID"] != DBNull.Value ? (int?)reader["ActivityID"] : null,
                                    BeneficiaryID = reader["BeneficiaryID"] != DBNull.Value ? (int?)reader["BeneficiaryID"] : null,
                                    DistributedTo = reader["DistributedTo"] != DBNull.Value ? reader["DistributedTo"].ToString() : null,
                                    Reason = reader["Reason"] != DBNull.Value ? reader["Reason"].ToString() : null,
                                    RecordedByUserID = reader["RecordedByUserID"] != DBNull.Value ? (int?)reader["RecordedByUserID"] : null,
                                    Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null
                                };
                                transactions.Add(transaction);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetTransactionsForItemAsync: {ex.Message}");
            }
            return transactions;
        }

        public async Task<bool> AddStockTransactionAsync(StockTransaction transaction)
        {
            // TODO: Implement true database transaction (BEGIN TRAN/COMMIT/ROLLBACK or TransactionScope) here to ensure atomicity of inserting transaction and updating stock item quantity.

            if (transaction.Quantity <= 0)
            {
                // Or throw new ArgumentOutOfRangeException(nameof(transaction.Quantity), "Transaction quantity must be greater than zero.");
                Console.WriteLine("Transaction quantity must be greater than zero.");
                return false;
            }

            if (transaction.TransactionDate == DateTime.MinValue || transaction.TransactionDate == default(DateTime))
            {
                transaction.TransactionDate = DateTime.UtcNow;
            }

            int quantityChange;
            string transactionTypeUpper = transaction.TransactionType.ToUpper();

            if (transactionTypeUpper == "OUT")
            {
                quantityChange = -transaction.Quantity;
            }
            else if (transactionTypeUpper == "IN" || transactionTypeUpper == "ADJUSTMENT") // Assuming ADJUSTMENT adds the quantity
            {
                quantityChange = transaction.Quantity;
            }
            else
            {
                Console.WriteLine($"Unknown transaction type: {transaction.TransactionType}");
                return false; // Or throw new ArgumentException("Unknown transaction type.", nameof(transaction.TransactionType));
            }

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                await connection.OpenAsync();
                // Note: Ideally, use a SqlTransaction here if not using TransactionScope
                // SqlTransaction sqlTran = connection.BeginTransaction();
                // SqlCommand command = connection.CreateCommand();
                // command.Transaction = sqlTran;

                try
                {
                    // Step A: Insert StockTransaction record
                    string insertTransactionQuery = @"
                        INSERT INTO StockTransactions (StockItemID, TransactionType, Quantity, TransactionDate, ProjectID, PurchaseOrderID, ActivityID, BeneficiaryID, DistributedTo, Reason, RecordedByUserID, Notes) 
                        VALUES (@StockItemID, @TransactionType, @Quantity, @TransactionDate, @ProjectID, @PurchaseOrderID, @ActivityID, @BeneficiaryID, @DistributedTo, @Reason, @RecordedByUserID, @Notes); 
                        SELECT CAST(SCOPE_IDENTITY() as int);";

                    using (SqlCommand cmdInsertTransaction = new SqlCommand(insertTransactionQuery, connection /*, sqlTran*/))
                    {
                        cmdInsertTransaction.Parameters.AddWithValue("@StockItemID", transaction.StockItemID);
                        cmdInsertTransaction.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
                        cmdInsertTransaction.Parameters.AddWithValue("@Quantity", transaction.Quantity);
                        cmdInsertTransaction.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                        cmdInsertTransaction.Parameters.AddWithValue("@ProjectID", (object)transaction.ProjectID ?? DBNull.Value);
                        cmdInsertTransaction.Parameters.AddWithValue("@PurchaseOrderID", (object)transaction.PurchaseOrderID ?? DBNull.Value);
                        cmdInsertTransaction.Parameters.AddWithValue("@ActivityID", (object)transaction.ActivityID ?? DBNull.Value);
                        cmdInsertTransaction.Parameters.AddWithValue("@BeneficiaryID", (object)transaction.BeneficiaryID ?? DBNull.Value);
                        cmdInsertTransaction.Parameters.AddWithValue("@DistributedTo", (object)transaction.DistributedTo ?? DBNull.Value);
                        cmdInsertTransaction.Parameters.AddWithValue("@Reason", (object)transaction.Reason ?? DBNull.Value);
                        cmdInsertTransaction.Parameters.AddWithValue("@RecordedByUserID", (object)transaction.RecordedByUserID ?? DBNull.Value);
                        cmdInsertTransaction.Parameters.AddWithValue("@Notes", (object)transaction.Notes ?? DBNull.Value);

                        object newId = await cmdInsertTransaction.ExecuteScalarAsync();
                        if (newId == null || newId == DBNull.Value || Convert.ToInt32(newId) == 0)
                        {
                            // sqlTran.Rollback();
                            Console.WriteLine("Failed to insert stock transaction record.");
                            return false;
                        }
                        transaction.TransactionID = Convert.ToInt32(newId);
                    }

                    // Step B: Update StockItem.CurrentQuantity
                    string updateStockItemQuery = @"
                        UPDATE StockItems SET 
                            CurrentQuantity = CurrentQuantity + @QuantityChange, 
                            LastStockUpdate = @TransactionDate 
                        WHERE StockItemID = @StockItemID;";

                    using (SqlCommand cmdUpdateStockItem = new SqlCommand(updateStockItemQuery, connection /*, sqlTran*/))
                    {
                        cmdUpdateStockItem.Parameters.AddWithValue("@QuantityChange", quantityChange);
                        cmdUpdateStockItem.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                        cmdUpdateStockItem.Parameters.AddWithValue("@StockItemID", transaction.StockItemID);

                        int rowsAffected = await cmdUpdateStockItem.ExecuteNonQueryAsync();
                        if (rowsAffected == 0)
                        {
                            // sqlTran.Rollback();
                            Console.WriteLine("Failed to update stock item quantity. Stock item might not exist or concurrency issue.");
                            // This indicates a more serious issue as the transaction is recorded but stock not updated.
                            return false;
                        }
                    }

                    // sqlTran.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    // sqlTran.Rollback();
                    Console.WriteLine($"SQL Error in AddStockTransactionAsync: {ex.Message}");
                    return false;
                }
                catch (Exception ex) // Catch any other exceptions during the process
                {
                    // sqlTran.Rollback();
                    Console.WriteLine($"Generic Error in AddStockTransactionAsync: {ex.Message}");
                    return false;
                }
                // No finally block needed for connection.Close() if using `using` for connection
            }
        }
    }
}
