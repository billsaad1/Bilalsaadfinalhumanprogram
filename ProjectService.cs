using HumanitarianProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public class ProjectService
    {
        private readonly LogFrameService _logFrameService;

        public ProjectService()
        {
            _logFrameService = new LogFrameService();
        }

        #region Transactional Get Overloads for DetailedBudgetLine
        // Fetches flat list of lines, including ParentDetailedBudgetLineID
        private async Task<List<DetailedBudgetLine>> GetFlatDetailedBudgetLinesByProjectIdAsync(int projectId, SqlConnection connection, SqlTransaction transaction)
        {
            List<DetailedBudgetLine> budgetLines = new List<DetailedBudgetLine>();
            // Added ParentDetailedBudgetLineID, removed BudgetSubCategoryID
            string query = "SELECT DetailedBudgetLineID, ProjectID, ParentDetailedBudgetLineID, Category, Code, Description, Unit, Quantity, UnitCost, Duration, PercentageChargedToCBPF, TotalCost FROM DetailedBudgetLine WHERE ProjectID = @ProjectID";
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@ProjectID", projectId);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            budgetLines.Add(new DetailedBudgetLine
                            {
                                DetailedBudgetLineID = reader["DetailedBudgetLineID"] != DBNull.Value ? (Guid)reader["DetailedBudgetLineID"] : Guid.Empty,
                                ProjectId = (int)reader["ProjectID"],
                                ParentDetailedBudgetLineID = reader["ParentDetailedBudgetLineID"] != DBNull.Value ? (Guid?)reader["ParentDetailedBudgetLineID"] : null,
                                Category = (BudgetCategoriesEnum)Convert.ToInt32(reader["Category"]),
                                Code = reader["Code"] != DBNull.Value ? reader["Code"].ToString() : string.Empty,
                                Description = reader["Description"].ToString(),
                                Unit = reader["Unit"] != DBNull.Value ? reader["Unit"].ToString() : null,
                                Quantity = Convert.ToDecimal(reader["Quantity"]),
                                UnitCost = (decimal)reader["UnitCost"],
                                Duration = Convert.ToDecimal(reader["Duration"]),
                                PercentageChargedToCBPF = (decimal)reader["PercentageChargedToCBPF"],
                                TotalCost = (decimal)reader["TotalCost"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in transactional GetFlatDetailedBudgetLinesByProjectIdAsync: {ex.Message}"); throw; }
            return budgetLines;
        }

        private async Task<List<DetailedBudgetLine>> GetChildDetailedBudgetLinesByParentIdAsync(Guid parentDetailedBudgetLineId, SqlConnection connection, SqlTransaction transaction)
        {
            List<DetailedBudgetLine> childLines = new List<DetailedBudgetLine>();
            string query = "SELECT DetailedBudgetLineID, ProjectId, ParentDetailedBudgetLineID, Category, Code, Description, Unit, Quantity, UnitCost, Duration, PercentageChargedToCBPF, TotalCost FROM DetailedBudgetLine WHERE ParentDetailedBudgetLineID = @ParentDetailedBudgetLineID";
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@ParentDetailedBudgetLineID", parentDetailedBudgetLineId);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            childLines.Add(new DetailedBudgetLine
                            {
                                DetailedBudgetLineID = reader["DetailedBudgetLineID"] != DBNull.Value ? (Guid)reader["DetailedBudgetLineID"] : Guid.Empty,
                                ProjectId = (int)reader["ProjectID"],
                                ParentDetailedBudgetLineID = reader["ParentDetailedBudgetLineID"] != DBNull.Value ? (Guid?)reader["ParentDetailedBudgetLineID"] : null,
                                Category = (BudgetCategoriesEnum)Convert.ToInt32(reader["Category"]),
                                Code = reader["Code"] != DBNull.Value ? reader["Code"].ToString() : string.Empty,
                                Description = reader["Description"].ToString(),
                                Unit = reader["Unit"] != DBNull.Value ? reader["Unit"].ToString() : null,
                                Quantity = Convert.ToDecimal(reader["Quantity"]),
                                UnitCost = (decimal)reader["UnitCost"],
                                Duration = Convert.ToDecimal(reader["Duration"]),
                                PercentageChargedToCBPF = (decimal)reader["PercentageChargedToCBPF"],
                                TotalCost = (decimal)reader["TotalCost"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error fetching child budget lines for line {parentDetailedBudgetLineId}: {ex.Message}"); throw; }
            return childLines;
        }

        public async Task<List<ItemizedBudgetDetail>> GetItemizedBudgetDetailsByParentIdAsync(Guid parentBudgetLineId, SqlConnection connection, SqlTransaction transaction)
        {
            List<ItemizedBudgetDetail> items = new List<ItemizedBudgetDetail>();
            string query = "SELECT ItemizedBudgetDetailID, ParentBudgetLineID, Description, Quantity, UnitPrice, TotalCost FROM ItemizedBudgetDetail WHERE ParentBudgetLineID = @ParentBudgetLineID";
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@ParentBudgetLineID", parentBudgetLineId);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ItemizedBudgetDetail item = new ItemizedBudgetDetail
                            {
                                ItemizedBudgetDetailID = (Guid)reader["ItemizedBudgetDetailID"],
                                ParentBudgetLineID = (Guid)reader["ParentBudgetLineID"],
                                Description = reader["Description"].ToString(),
                                Quantity = Convert.ToDecimal(reader["Quantity"]),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                            };
                            item.UpdateTotalCost(); items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in transactional GetItemizedBudgetDetailsByParentIdAsync: {ex.Message}"); throw; }
            return items;
        }
        #endregion

        #region Standard Get Methods (Non-Transactional) for DetailedBudgetLine
        public async Task<List<DetailedBudgetLine>> GetDetailedBudgetLinesByProjectIdAsync(int projectId)
        {
            List<DetailedBudgetLine> allLines;
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                await conn.OpenAsync();
                allLines = await GetFlatDetailedBudgetLinesByProjectIdAsync(projectId, conn, null);

                foreach (var line in allLines)
                {
                    if (line.ItemizedDetails == null) line.ItemizedDetails = new List<ItemizedBudgetDetail>();
                    var itemizedDetails = await GetItemizedBudgetDetailsByParentIdAsync(line.DetailedBudgetLineID, conn, null);
                    foreach (var idetail in itemizedDetails) line.ItemizedDetails.Add(idetail);
                }
                conn.Close();
            }
            return ReconstructLineHierarchy(allLines);
        }

        private List<DetailedBudgetLine> ReconstructLineHierarchy(List<DetailedBudgetLine> allLines)
        {
            var lineMap = allLines.ToDictionary(line => line.DetailedBudgetLineID);
            List<DetailedBudgetLine> topLevelLines = new List<DetailedBudgetLine>();

            foreach (var line in allLines)
            {
                if (line.ChildDetailedBudgetLines == null) line.ChildDetailedBudgetLines = new HashSet<DetailedBudgetLine>();
                else line.ChildDetailedBudgetLines.Clear();

                if (line.ParentDetailedBudgetLineID.HasValue && lineMap.TryGetValue(line.ParentDetailedBudgetLineID.Value, out DetailedBudgetLine parentLine))
                {
                    if (parentLine.ChildDetailedBudgetLines == null) parentLine.ChildDetailedBudgetLines = new HashSet<DetailedBudgetLine>();
                    parentLine.ChildDetailedBudgetLines.Add(line);
                    line.ParentDetailedBudgetLine = parentLine;
                }
                else
                {
                    topLevelLines.Add(line);
                }
            }
            return topLevelLines;
        }

        public async Task<List<ItemizedBudgetDetail>> GetItemizedBudgetDetailsByParentIdAsync(Guid parentBudgetLineId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                await conn.OpenAsync();
                var result = await GetItemizedBudgetDetailsByParentIdAsync(parentBudgetLineId, conn, null);
                conn.Close();
                return result;
            }
        }
        #endregion

        #region DetailedBudgetLine CRUD (Transactional)
        public async Task<bool> AddDetailedBudgetLineWithDetailsAsync(DetailedBudgetLine budgetLine, SqlTransaction transaction = null)
        {
            if (budgetLine == null) throw new ArgumentNullException(nameof(budgetLine));
            if (budgetLine.DetailedBudgetLineID == Guid.Empty) budgetLine.DetailedBudgetLineID = Guid.NewGuid();

            string query = @"INSERT INTO DetailedBudgetLine (DetailedBudgetLineID, ProjectId, ParentDetailedBudgetLineID, Category, Code, Description, Unit, Quantity, UnitCost, Duration, PercentageChargedToCBPF, TotalCost) VALUES (@DetailedBudgetLineID, @ProjectID, @ParentDetailedBudgetLineID, @Category, @Code, @Description, @Unit, @Quantity, @UnitCost, @Duration, @PercentageChargedToCBPF, @TotalCost);";
            SqlConnection conn = null; bool manageConnection = false;
            try
            {
                if (transaction != null) conn = transaction.Connection;
                else { conn = DatabaseHelper.GetConnection(); await conn.OpenAsync(); manageConnection = true; }
                using (SqlCommand command = new SqlCommand(query, conn, transaction))
                {
                    command.Parameters.AddWithValue("@DetailedBudgetLineID", budgetLine.DetailedBudgetLineID);
                    command.Parameters.AddWithValue("@ProjectID", budgetLine.ProjectId); // This will now be correct for new projects
                    command.Parameters.AddWithValue("@ParentDetailedBudgetLineID", (object)budgetLine.ParentDetailedBudgetLineID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Category", (int)budgetLine.Category);
                    command.Parameters.AddWithValue("@Code", (object)budgetLine.Code ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Description", budgetLine.Description);
                    command.Parameters.AddWithValue("@Unit", (object)budgetLine.Unit ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Quantity", budgetLine.Quantity);
                    command.Parameters.AddWithValue("@UnitCost", budgetLine.UnitCost);
                    command.Parameters.AddWithValue("@Duration", budgetLine.Duration);
                    command.Parameters.AddWithValue("@PercentageChargedToCBPF", budgetLine.PercentageChargedToCBPF);
                    command.Parameters.AddWithValue("@TotalCost", budgetLine.TotalCost);
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        if (budgetLine.ItemizedDetails != null)
                        {
                            foreach (var itemDetail in budgetLine.ItemizedDetails)
                            {
                                itemDetail.ParentBudgetLineID = budgetLine.DetailedBudgetLineID;
                                await AddItemizedBudgetDetailAsync(itemDetail, transaction);
                            }
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in AddDetailedBudgetLineWithDetailsAsync: {ex.Message}"); if (transaction == null) throw; }
            finally { if (manageConnection && conn?.State == ConnectionState.Open) conn.Close(); }
            return false;
        }

        public async Task<bool> UpdateDetailedBudgetLineWithDetailsAsync(DetailedBudgetLine budgetLine, SqlTransaction transaction = null)
        {
            if (budgetLine == null) throw new ArgumentNullException(nameof(budgetLine));
            if (budgetLine.DetailedBudgetLineID == Guid.Empty) return false;
            string query = @"UPDATE DetailedBudgetLine SET ProjectID = @ProjectID, ParentDetailedBudgetLineID = @ParentDetailedBudgetLineID, Category = @Category, Code = @Code, Description = @Description, Unit = @Unit, Quantity = @Quantity, UnitCost = @UnitCost, Duration = @Duration, PercentageChargedToCBPF = @PercentageChargedToCBPF, TotalCost = @TotalCost WHERE DetailedBudgetLineID = @DetailedBudgetLineID;";
            SqlConnection conn = null; bool manageConnection = false;
            try
            {
                if (transaction != null) conn = transaction.Connection;
                else { conn = DatabaseHelper.GetConnection(); await conn.OpenAsync(); manageConnection = true; }
                using (SqlCommand command = new SqlCommand(query, conn, transaction))
                {
                    command.Parameters.AddWithValue("@ProjectID", budgetLine.ProjectId); // Ensure this is correct
                    command.Parameters.AddWithValue("@ParentDetailedBudgetLineID", (object)budgetLine.ParentDetailedBudgetLineID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Category", (int)budgetLine.Category);
                    command.Parameters.AddWithValue("@Code", (object)budgetLine.Code ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Description", budgetLine.Description);
                    command.Parameters.AddWithValue("@Unit", (object)budgetLine.Unit ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Quantity", budgetLine.Quantity);
                    command.Parameters.AddWithValue("@UnitCost", budgetLine.UnitCost);
                    command.Parameters.AddWithValue("@Duration", budgetLine.Duration);
                    command.Parameters.AddWithValue("@PercentageChargedToCBPF", budgetLine.PercentageChargedToCBPF);
                    command.Parameters.AddWithValue("@TotalCost", budgetLine.TotalCost);
                    command.Parameters.AddWithValue("@DetailedBudgetLineID", budgetLine.DetailedBudgetLineID);
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    // Itemized details sync logic (remains the same)
                    List<ItemizedBudgetDetail> dbItems = await GetItemizedBudgetDetailsByParentIdAsync(budgetLine.DetailedBudgetLineID, conn, transaction);
                    HashSet<Guid> incomingItemIds = new HashSet<Guid>(budgetLine.ItemizedDetails?.Select(i => i.ItemizedBudgetDetailID) ?? Enumerable.Empty<Guid>());
                    foreach (var dbItem in dbItems) { if (!incomingItemIds.Contains(dbItem.ItemizedBudgetDetailID)) await DeleteItemizedBudgetDetailAsync(dbItem.ItemizedBudgetDetailID, transaction); }
                    if (budgetLine.ItemizedDetails != null)
                    {
                        foreach (var itemDetail in budgetLine.ItemizedDetails)
                        {
                            itemDetail.ParentBudgetLineID = budgetLine.DetailedBudgetLineID;
                            var existingDbItem = dbItems.FirstOrDefault(db => db.ItemizedBudgetDetailID == itemDetail.ItemizedBudgetDetailID && itemDetail.ItemizedBudgetDetailID != Guid.Empty);
                            if (existingDbItem != null) await UpdateItemizedBudgetDetailAsync(itemDetail, transaction);
                            else if (itemDetail.ItemizedBudgetDetailID == Guid.Empty) { itemDetail.ItemizedBudgetDetailID = Guid.NewGuid(); await AddItemizedBudgetDetailAsync(itemDetail, transaction); }
                        }
                    }
                    return true; // Return true if update was attempted, even if 0 rows if no error
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in UpdateDetailedBudgetLineWithDetailsAsync: {ex.Message}"); if (transaction == null) throw; }
            finally { if (manageConnection && conn?.State == ConnectionState.Open) conn.Close(); }
            return false;
        }

        public async Task<bool> DeleteDetailedBudgetLineAsync(Guid detailedBudgetLineId, SqlTransaction transaction = null)
        {
            SqlConnection conn = null; bool manageConnection = false;
            try
            {
                if (transaction != null) conn = transaction.Connection;
                else { conn = DatabaseHelper.GetConnection(); await conn.OpenAsync(); manageConnection = true; }

                var childLines = await GetChildDetailedBudgetLinesByParentIdAsync(detailedBudgetLineId, conn, transaction);
                foreach (var childLine in childLines)
                {
                    await DeleteDetailedBudgetLineAsync(childLine.DetailedBudgetLineID, transaction);
                }

                await DeleteAllItemizedDetailsByParentIdAsync(detailedBudgetLineId, transaction);

                string query = "DELETE FROM DetailedBudgetLine WHERE DetailedBudgetLineID = @DetailedBudgetLineID;";
                using (SqlCommand command = new SqlCommand(query, conn, transaction))
                {
                    command.Parameters.AddWithValue("@DetailedBudgetLineID", detailedBudgetLineId);
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in DeleteDetailedBudgetLineAsync for ID {detailedBudgetLineId}: {ex.Message}"); if (transaction == null) throw; return false; }
            finally { if (manageConnection && conn?.State == ConnectionState.Open) conn.Close(); }
        }
        #endregion

        #region ItemizedBudgetDetail CRUD (Transactional)
        public async Task<bool> AddItemizedBudgetDetailAsync(ItemizedBudgetDetail itemDetail, SqlTransaction transaction = null)
        {
            if (itemDetail == null) throw new ArgumentNullException(nameof(itemDetail));
            if (itemDetail.ItemizedBudgetDetailID == Guid.Empty) itemDetail.ItemizedBudgetDetailID = Guid.NewGuid();
            itemDetail.UpdateTotalCost();
            string query = @"INSERT INTO ItemizedBudgetDetail (ItemizedBudgetDetailID, ParentBudgetLineID, Description, Quantity, UnitPrice, TotalCost) VALUES (@ItemizedBudgetDetailID, @ParentBudgetLineID, @Description, @Quantity, @UnitPrice, @TotalCost);";
            SqlConnection conn = null; bool manageConnection = false;
            try
            {
                if (transaction != null) conn = transaction.Connection;
                else { conn = DatabaseHelper.GetConnection(); await conn.OpenAsync(); manageConnection = true; }
                using (SqlCommand command = new SqlCommand(query, conn, transaction))
                {
                    command.Parameters.AddWithValue("@ItemizedBudgetDetailID", itemDetail.ItemizedBudgetDetailID);
                    command.Parameters.AddWithValue("@ParentBudgetLineID", itemDetail.ParentBudgetLineID);
                    command.Parameters.AddWithValue("@Description", (object)itemDetail.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Quantity", itemDetail.Quantity);
                    command.Parameters.AddWithValue("@UnitPrice", itemDetail.UnitPrice);
                    command.Parameters.AddWithValue("@TotalCost", itemDetail.TotalCost);
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in AddItemizedBudgetDetailAsync: {ex.Message}"); if (transaction == null) throw; return false; }
            finally { if (manageConnection && conn?.State == ConnectionState.Open) conn.Close(); }
        }

        public async Task<bool> UpdateItemizedBudgetDetailAsync(ItemizedBudgetDetail itemDetail, SqlTransaction transaction = null)
        {
            if (itemDetail == null) throw new ArgumentNullException(nameof(itemDetail));
            itemDetail.UpdateTotalCost();
            string query = @"UPDATE ItemizedBudgetDetail SET ParentBudgetLineID = @ParentBudgetLineID, Description = @Description, Quantity = @Quantity, UnitPrice = @UnitPrice, TotalCost = @TotalCost WHERE ItemizedBudgetDetailID = @ItemizedBudgetDetailID;";
            SqlConnection conn = null; bool manageConnection = false;
            try
            {
                if (transaction != null) conn = transaction.Connection;
                else { conn = DatabaseHelper.GetConnection(); await conn.OpenAsync(); manageConnection = true; }
                using (SqlCommand command = new SqlCommand(query, conn, transaction))
                {
                    command.Parameters.AddWithValue("@ParentBudgetLineID", itemDetail.ParentBudgetLineID);
                    command.Parameters.AddWithValue("@Description", (object)itemDetail.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Quantity", itemDetail.Quantity);
                    command.Parameters.AddWithValue("@UnitPrice", itemDetail.UnitPrice);
                    command.Parameters.AddWithValue("@TotalCost", itemDetail.TotalCost);
                    command.Parameters.AddWithValue("@ItemizedBudgetDetailID", itemDetail.ItemizedBudgetDetailID);
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in UpdateItemizedBudgetDetailAsync: {ex.Message}"); if (transaction == null) throw; return false; }
            finally { if (manageConnection && conn?.State == ConnectionState.Open) conn.Close(); }
        }

        public async Task<bool> DeleteAllItemizedDetailsByParentIdAsync(Guid parentBudgetLineId, SqlTransaction transaction = null)
        {
            string query = "DELETE FROM ItemizedBudgetDetail WHERE ParentBudgetLineID = @ParentBudgetLineID;";
            SqlConnection conn = null; bool manageConnection = false;
            try
            {
                if (transaction != null) conn = transaction.Connection;
                else { conn = DatabaseHelper.GetConnection(); await conn.OpenAsync(); manageConnection = true; }
                using (SqlCommand command = new SqlCommand(query, conn, transaction))
                {
                    command.Parameters.AddWithValue("@ParentBudgetLineID", parentBudgetLineId);
                    await command.ExecuteNonQueryAsync(); return true;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in DeleteAllItemizedDetailsByParentIdAsync for Parent ID {parentBudgetLineId}: {ex.Message}"); if (transaction == null) throw; return false; }
            finally { if (manageConnection && conn?.State == ConnectionState.Open) conn.Close(); }
        }

        public async Task<bool> DeleteItemizedBudgetDetailAsync(Guid itemizedBudgetDetailId, SqlTransaction transaction = null)
        {
            string query = "DELETE FROM ItemizedBudgetDetail WHERE ItemizedBudgetDetailID = @ItemizedBudgetDetailID;";
            SqlConnection conn = null; bool manageConnection = false;
            try
            {
                if (transaction != null) conn = transaction.Connection;
                else { conn = DatabaseHelper.GetConnection(); await conn.OpenAsync(); manageConnection = true; }
                using (SqlCommand command = new SqlCommand(query, conn, transaction))
                {
                    command.Parameters.AddWithValue("@ItemizedBudgetDetailID", itemizedBudgetDetailId);
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in DeleteItemizedBudgetDetailAsync for ID {itemizedBudgetDetailId}: {ex.Message}"); if (transaction == null) throw; return false; }
            finally { if (manageConnection && conn?.State == ConnectionState.Open) conn.Close(); }
        }
        #endregion

        // BudgetSubCategory CRUD methods are removed.

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            List<Project> projects = new List<Project>();
            string query = @"
                SELECT ProjectID, ProjectName, ProjectCode, SectionID, StartDate, EndDate, 
                       Status, TotalBudget, Donor, CreatedAt, UpdatedAt, ManagerUserID, 
                       Location, OverallObjective 
                FROM Projects 
                ORDER BY ProjectName;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Project project = new Project
                                {
                                    ProjectID = (int)reader["ProjectID"],
                                    ProjectName = reader["ProjectName"].ToString(),
                                    ProjectCode = reader["ProjectCode"] != DBNull.Value ? reader["ProjectCode"].ToString() : null,
                                    SectionID = reader["SectionID"] != DBNull.Value ? (int?)reader["SectionID"] : null,
                                    StartDate = reader["StartDate"] != DBNull.Value ? (DateTime?)reader["StartDate"] : null,
                                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime?)reader["EndDate"] : null,
                                    Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null,
                                    TotalBudget = reader["TotalBudget"] != DBNull.Value ? (decimal?)reader["TotalBudget"] : null,
                                    Donor = reader["Donor"] != DBNull.Value ? reader["Donor"].ToString() : null,
                                    CreatedAt = reader["CreatedAt"] != DBNull.Value ? (DateTime)reader["CreatedAt"] : DateTime.MinValue,
                                    UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime?)reader["UpdatedAt"] : null,
                                    ManagerUserID = reader["ManagerUserID"] != DBNull.Value ? (int?)reader["ManagerUserID"] : null,
                                    Location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : null,
                                    OverallObjective = reader["OverallObjective"] != DBNull.Value ? reader["OverallObjective"].ToString() : null,

                                    // Initialize collections to empty for a summary view
                                    Outcomes = new BindingList<Outcome>(),
                                    DetailedBudgetLines = new BindingList<DetailedBudgetLine>(),
                                    BeneficiaryLists = new BindingList<BeneficiaryList>(),
                                    ProjectIndicators = new BindingList<ProjectIndicator>(),
                                    // Budgets = new BindingList<Budget>(), // If Budget model exists and is needed
                                    PurchaseOrders = new BindingList<PurchaseOrder>(),
                                    ProjectReports = new BindingList<ProjectReport>(),
                                    StockTransactions = new BindingList<StockTransaction>(),
                                    Feedbacks = new BindingList<Feedback>(),
                                    FollowUpVisits = new BindingList<FollowUpVisit>()
                                };
                                projects.Add(project);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., to a logging framework or console)
                Console.WriteLine($"Error in GetAllProjectsAsync: {ex.Message}");
                // Optionally, rethrow or handle as per application's error handling strategy
                // For now, we'll return an empty list or a list potentially partially filled before error
            }
            return projects;
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            Project project = null;
            string projectQuery = "SELECT ProjectID, ProjectName, ProjectCode, SectionID, StartDate, EndDate, Location, OverallObjective, ManagerUserID, Status, TotalBudget, Donor, CreatedAt, UpdatedAt FROM Projects WHERE ProjectID = @ProjectID";
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(projectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectID", projectId);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                project = new Project
                                {
                                    ProjectID = (int)reader["ProjectID"],
                                    ProjectName = reader["ProjectName"].ToString(),
                                    ProjectCode = reader["ProjectCode"] != DBNull.Value ? reader["ProjectCode"].ToString() : null,
                                    SectionID = reader["SectionID"] != DBNull.Value ? (int?)reader["SectionID"] : null,
                                    StartDate = reader["StartDate"] != DBNull.Value ? (DateTime?)reader["StartDate"] : null,
                                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime?)reader["EndDate"] : null,
                                    Location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : null,
                                    OverallObjective = reader["OverallObjective"] != DBNull.Value ? reader["OverallObjective"].ToString() : null,
                                    ManagerUserID = reader["ManagerUserID"] != DBNull.Value ? (int?)reader["ManagerUserID"] : null,
                                    Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null,
                                    TotalBudget = reader["TotalBudget"] != DBNull.Value ? (decimal?)reader["TotalBudget"] : null,
                                    Donor = reader["Donor"] != DBNull.Value ? reader["Donor"].ToString() : null,
                                    CreatedAt = (DateTime)reader["CreatedAt"],
                                    UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime?)reader["UpdatedAt"] : null,
                                    Outcomes = new BindingList<Outcome>(),
                                    DetailedBudgetLines = new BindingList<DetailedBudgetLine>()
                                };
                            }
                        }
                    }
                    if (project == null) return null;

                    var outcomes = await _logFrameService.GetOutcomesByProjectIdAsync(projectId);
                    foreach (var outcome in outcomes)
                    {
                        outcome.Outputs = await _logFrameService.GetOutputsByOutcomeIdAsync(outcome.OutcomeID);
                        foreach (var output in outcome.Outputs)
                        {
                            output.Activities = await _logFrameService.GetActivitiesByOutputIdAsync(output.OutputID);
                            output.ProjectIndicators = await _logFrameService.GetProjectIndicatorsByOutputIdAsync(output.OutputID);
                        }
                        project.Outcomes.Add(outcome);
                    }

                    var allLinesFlat = await GetFlatDetailedBudgetLinesByProjectIdAsync(projectId, connection, null);
                    foreach (var line in allLinesFlat)
                    {
                        if (line.ItemizedDetails == null) line.ItemizedDetails = new List<ItemizedBudgetDetail>();
                        var itemizedDetails = await GetItemizedBudgetDetailsByParentIdAsync(line.DetailedBudgetLineID, connection, null);
                        foreach (var idetail in itemizedDetails) line.ItemizedDetails.Add(idetail);
                    }

                    project.DetailedBudgetLines = new BindingList<DetailedBudgetLine>(allLinesFlat);
                    ReconstructLineHierarchy(project.DetailedBudgetLines.ToList());

                    connection.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in GetProjectByIdAsync for ProjectID {projectId}: {ex.Message}"); }
            return project;
        }

        public async Task<List<Project>> GetProjectsBySectionIdAsync(int sectionId)
        {
            List<Project> projects = new List<Project>();
            string query = @"
                SELECT ProjectID, ProjectName, ProjectCode, SectionID, StartDate, EndDate, 
                       Status, TotalBudget, Donor, CreatedAt, UpdatedAt, ManagerUserID, 
                       Location, OverallObjective 
                FROM Projects 
                WHERE SectionID = @SectionID 
                ORDER BY ProjectName;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SectionID", sectionId);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Project project = new Project
                                {
                                    ProjectID = (int)reader["ProjectID"],
                                    ProjectName = reader["ProjectName"].ToString(),
                                    ProjectCode = reader["ProjectCode"] != DBNull.Value ? reader["ProjectCode"].ToString() : null,
                                    SectionID = reader["SectionID"] != DBNull.Value ? (int?)reader["SectionID"] : null,
                                    StartDate = reader["StartDate"] != DBNull.Value ? (DateTime?)reader["StartDate"] : null,
                                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime?)reader["EndDate"] : null,
                                    Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null,
                                    TotalBudget = reader["TotalBudget"] != DBNull.Value ? (decimal?)reader["TotalBudget"] : null,
                                    Donor = reader["Donor"] != DBNull.Value ? reader["Donor"].ToString() : null,
                                    CreatedAt = reader["CreatedAt"] != DBNull.Value ? (DateTime)reader["CreatedAt"] : DateTime.MinValue,
                                    UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime?)reader["UpdatedAt"] : null,
                                    ManagerUserID = reader["ManagerUserID"] != DBNull.Value ? (int?)reader["ManagerUserID"] : null,
                                    Location = reader["Location"] != DBNull.Value ? reader["Location"].ToString() : null,
                                    OverallObjective = reader["OverallObjective"] != DBNull.Value ? reader["OverallObjective"].ToString() : null,

                                    // Initialize collections to empty for a summary view
                                    Outcomes = new BindingList<Outcome>(),
                                    DetailedBudgetLines = new BindingList<DetailedBudgetLine>(),
                                    BeneficiaryLists = new BindingList<BeneficiaryList>(),
                                    ProjectIndicators = new BindingList<ProjectIndicator>(),
                                    PurchaseOrders = new BindingList<PurchaseOrder>(),
                                    ProjectReports = new BindingList<ProjectReport>(),
                                    StockTransactions = new BindingList<StockTransaction>(),
                                    Feedbacks = new BindingList<Feedback>(),
                                    FollowUpVisits = new BindingList<FollowUpVisit>()
                                };
                                projects.Add(project);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetProjectsBySectionIdAsync (SectionID: {sectionId}): {ex.Message}");
            }
            return projects;
        }

        public async Task<bool> SaveProjectAsync(Project project)
        {
            bool mainProjectSavedSuccessfully = false;
            bool isNewProjectInstance = project.ProjectID == 0; // Capture if it's a new project before its ID changes

            if (project.StartDate.HasValue && project.StartDate.Value < SqlDateTime.MinValue.Value) project.StartDate = SqlDateTime.MinValue.Value;
            if (project.EndDate.HasValue && project.EndDate.Value < SqlDateTime.MinValue.Value) project.EndDate = SqlDateTime.MinValue.Value;
            if (project.CreatedAt < SqlDateTime.MinValue.Value) project.CreatedAt = SqlDateTime.MinValue.Value;
            if (project.UpdatedAt.HasValue && project.UpdatedAt.Value < SqlDateTime.MinValue.Value) project.UpdatedAt = SqlDateTime.MinValue.Value;

            SqlConnection mainConn = null;
            try
            {
                mainConn = DatabaseHelper.GetConnection(); await mainConn.OpenAsync();
                SqlCommand command;
                if (isNewProjectInstance) // Use the flag captured before any DB operation
                {
                    string insertQuery = @"INSERT INTO Projects (ProjectName, ProjectCode, SectionID, StartDate, EndDate, Location, OverallObjective, ManagerUserID, Status, TotalBudget, Donor, CreatedAt, UpdatedAt) VALUES (@ProjectName, @ProjectCode, @SectionID, @StartDate, @EndDate, @Location, @OverallObjective, @ManagerUserID, @Status, @TotalBudget, @Donor, @CreatedAt, @UpdatedAt); SELECT CAST(SCOPE_IDENTITY() as int);";
                    command = new SqlCommand(insertQuery, mainConn);
                    command.Parameters.AddWithValue("@CreatedAt", project.CreatedAt == DateTime.MinValue ? DateTime.UtcNow : project.CreatedAt);
                }
                else
                {
                    string updateQuery = @"UPDATE Projects SET ProjectName = @ProjectName, ProjectCode = @ProjectCode, SectionID = @SectionID, StartDate = @StartDate, EndDate = @EndDate, Location = @Location, OverallObjective = @OverallObjective, ManagerUserID = @ManagerUserID, Status = @Status, TotalBudget = @TotalBudget, Donor = @Donor, UpdatedAt = @UpdatedAt WHERE ProjectID = @ProjectID";
                    command = new SqlCommand(updateQuery, mainConn);
                    command.Parameters.AddWithValue("@ProjectID", project.ProjectID);
                }
                command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                command.Parameters.AddWithValue("@ProjectCode", (object)project.ProjectCode ?? DBNull.Value);
                command.Parameters.AddWithValue("@SectionID", (object)project.SectionID ?? DBNull.Value);
                command.Parameters.AddWithValue("@StartDate", (object)project.StartDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@EndDate", (object)project.EndDate ?? DBNull.Value);
                command.Parameters.AddWithValue("@Location", (object)project.Location ?? DBNull.Value);
                command.Parameters.AddWithValue("@OverallObjective", (object)project.OverallObjective ?? DBNull.Value);
                command.Parameters.AddWithValue("@ManagerUserID", (object)project.ManagerUserID ?? DBNull.Value);
                command.Parameters.AddWithValue("@Status", (object)project.Status ?? DBNull.Value);
                command.Parameters.AddWithValue("@TotalBudget", (object)project.TotalBudget ?? DBNull.Value);
                command.Parameters.AddWithValue("@Donor", (object)project.Donor ?? DBNull.Value);
                command.Parameters.AddWithValue("@UpdatedAt", (object)project.UpdatedAt ?? DateTime.UtcNow);

                // Execute command and update ProjectID if new
                if (isNewProjectInstance)
                {
                    object newId = await command.ExecuteScalarAsync();
                    if (newId != null && newId != DBNull.Value)
                    {
                        project.ProjectID = Convert.ToInt32(newId);
                        mainProjectSavedSuccessfully = true;
                    }
                }
                else
                {
                    mainProjectSavedSuccessfully = await command.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error saving main project details: {ex.Message}"); return false; }
            finally { if (mainConn?.State == ConnectionState.Open) mainConn.Close(); }

            if (!mainProjectSavedSuccessfully) { Console.WriteLine("Main project save failed. Aborting child entity sync."); return false; }

            // If it *was* a new project instance, its ProjectID is now populated.
            // Update ProjectID for child collections that might have been populated in the UI with the old (e.g., 0) ProjectID.
            if (isNewProjectInstance && project.ProjectID != 0) // Ensure ProjectID is valid
            {
                if (project.Outcomes != null)
                {
                    foreach (var outcome in project.Outcomes)
                    {
                        outcome.ProjectID = project.ProjectID;
                        if (outcome.Outputs != null)
                        {
                            foreach (var output in outcome.Outputs)
                            {
                                if (output.ProjectIndicators != null)
                                {
                                    foreach (var indicator in output.ProjectIndicators)
                                    {
                                        indicator.ProjectID = project.ProjectID;
                                    }
                                }
                            }
                        }
                    }
                }

                if (project.DetailedBudgetLines != null)
                {
                    foreach (var budgetLine in project.DetailedBudgetLines)
                    {
                        budgetLine.ProjectId = project.ProjectID;
                    }
                }
            }

            // Save LogFrame (Outcomes, Outputs, Activities, Indicators)
            // This logic will now use the correctly set ProjectID on children if it was a new project.
            if (project.Outcomes != null)
            {
                foreach (var outcome in project.Outcomes)
                {
                    // outcome.ProjectID is already updated if it was a new project by the block above.
                    if (outcome.OutcomeID == 0) { outcome.OutcomeID = await _logFrameService.AddOutcomeAsync(outcome); if (outcome.OutcomeID == 0) { Console.WriteLine($"Failed to add outcome: {outcome.OutcomeDescription}"); continue; } }
                    else { await _logFrameService.UpdateOutcomeAsync(outcome); }

                    if (outcome.OutcomeID > 0 && outcome.Outputs != null)
                    {
                        foreach (var output in outcome.Outputs)
                        {
                            output.OutcomeID = outcome.OutcomeID; // Ensure OutcomeID is set for the output.
                            if (output.OutputID == 0) { output.OutputID = await _logFrameService.AddOutputAsync(output); if (output.OutputID == 0) { Console.WriteLine($"Failed to add output: {output.OutputDescription}"); continue; } }
                            else { await _logFrameService.UpdateOutputAsync(output); }

                            if (output.OutputID > 0 && output.Activities != null)
                            {
                                foreach (var activity in output.Activities)
                                {
                                    activity.OutputID = output.OutputID;
                                    if (activity.ActivityID == 0) activity.ActivityID = await _logFrameService.AddActivityAsync(activity);
                                    else await _logFrameService.UpdateActivityAsync(activity);
                                }
                            }
                            if (output.OutputID > 0 && output.ProjectIndicators != null)
                            {
                                foreach (var indicator in output.ProjectIndicators)
                                {
                                    indicator.OutputID = output.OutputID;
                                    // indicator.ProjectID is already updated if it was a new project by the block above.
                                    if (indicator.ProjectIndicatorID == 0) indicator.ProjectIndicatorID = await _logFrameService.AddProjectIndicatorToOutputAsync(indicator);
                                    else await _logFrameService.UpdateProjectIndicatorAsync(indicator);
                                }
                            }
                        }
                    }
                }
            }

            // Save Budget Lines
            SqlConnection budgetConn = null;
            try
            {
                budgetConn = DatabaseHelper.GetConnection();
                await budgetConn.OpenAsync();
                using (SqlTransaction budgetTransaction = budgetConn.BeginTransaction())
                {
                    try
                    {
                        // Existing budget lines from DB for this project
                        var dbLines = await GetFlatDetailedBudgetLinesByProjectIdAsync(project.ProjectID, budgetConn, budgetTransaction);

                        // In-memory budget lines (already have ProjectId updated if it was a new project due to the block above)
                        var memoryLines = project.DetailedBudgetLines?.ToList() ?? new List<DetailedBudgetLine>();

                        // Lines to delete: in DB but not in memory
                        var linesToDelete = dbLines.Where(dbL => !memoryLines.Any(mL => mL.DetailedBudgetLineID == dbL.DetailedBudgetLineID)).ToList();
                        foreach (var dbLineToDelete in linesToDelete)
                        {
                            await DeleteDetailedBudgetLineAsync(dbLineToDelete.DetailedBudgetLineID, budgetTransaction);
                        }

                        // Process lines hierarchically for adds/updates
                        // This existing hierarchical processing logic should now work correctly
                        // as `memLine.ProjectId` will be correct before calling Add/Update.
                        List<DetailedBudgetLine> linesToSave = new List<DetailedBudgetLine>();
                        Stack<DetailedBudgetLine> processingStack = new Stack<DetailedBudgetLine>(memoryLines.Where(l => !l.ParentDetailedBudgetLineID.HasValue || !memoryLines.Any(p => p.DetailedBudgetLineID == l.ParentDetailedBudgetLineID.Value))); // Start with top-level lines from memory

                        HashSet<Guid> processedLineGuids = new HashSet<Guid>();

                        while (processingStack.Any())
                        {
                            var currentLine = processingStack.Pop();
                            if (currentLine.DetailedBudgetLineID != Guid.Empty && processedLineGuids.Contains(currentLine.DetailedBudgetLineID))
                            {
                                continue; // Already processed this line via another path (e.g. child of another processed line)
                            }

                            linesToSave.Add(currentLine);
                            if (currentLine.DetailedBudgetLineID != Guid.Empty) processedLineGuids.Add(currentLine.DetailedBudgetLineID);

                            if (currentLine.ChildDetailedBudgetLines != null)
                            {
                                foreach (var child in currentLine.ChildDetailedBudgetLines.Reverse()) // Reverse to maintain order when popping
                                {
                                    if (child.DetailedBudgetLineID == Guid.Empty || !processedLineGuids.Contains(child.DetailedBudgetLineID))
                                    {
                                        processingStack.Push(child);
                                    }
                                }
                            }
                        }

                        // Add any lines in memory that were not picked up by hierarchical traversal (e.g. orphans, if any)
                        // This ensures all lines in memoryLines are considered if not part of the explicit ChildDetailedBudgetLines collections
                        // of other lines in memoryLines.
                        foreach (var memLine in memoryLines)
                        {
                            if (memLine.DetailedBudgetLineID == Guid.Empty || !processedLineGuids.Contains(memLine.DetailedBudgetLineID))
                            {
                                // Check if it's already in linesToSave to avoid duplicates from different processing paths.
                                if (!linesToSave.Any(lts => lts.DetailedBudgetLineID != Guid.Empty && lts.DetailedBudgetLineID == memLine.DetailedBudgetLineID) || memLine.DetailedBudgetLineID == Guid.Empty)
                                {
                                    linesToSave.Add(memLine); // Add if not already processed or added
                                    if (memLine.DetailedBudgetLineID != Guid.Empty) processedLineGuids.Add(memLine.DetailedBudgetLineID); // Mark as processed
                                }
                            }
                        }


                        foreach (var memLine in linesToSave)
                        {
                            // memLine.ProjectId is already updated for new projects by the block above.
                            var existingDbLine = dbLines.FirstOrDefault(dbL => dbL.DetailedBudgetLineID == memLine.DetailedBudgetLineID && memLine.DetailedBudgetLineID != Guid.Empty);
                            if (memLine.DetailedBudgetLineID == Guid.Empty || existingDbLine == null) // It's a new line
                            {
                                if (memLine.DetailedBudgetLineID == Guid.Empty) memLine.DetailedBudgetLineID = Guid.NewGuid();
                                await AddDetailedBudgetLineWithDetailsAsync(memLine, budgetTransaction);
                            }
                            else // It's an existing line, update it
                            {
                                await UpdateDetailedBudgetLineWithDetailsAsync(memLine, budgetTransaction);
                            }
                        }
                        budgetTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        budgetTransaction.Rollback();
                        Console.WriteLine($"Error in budget synchronization transaction: {ex.Message}. Transaction rolled back.");
                        return false; // Propagate failure
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error establishing budget connection/transaction: {ex.Message}"); return false; }
            finally { if (budgetConn?.State == ConnectionState.Open) budgetConn.Close(); }

            return mainProjectSavedSuccessfully;
        }

        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            try
            {
                var outcomes = await _logFrameService.GetOutcomesByProjectIdAsync(projectId);
                foreach (var outcome in outcomes) await _logFrameService.DeleteOutcomeAsync(outcome.OutcomeID);

                List<DetailedBudgetLine> allLinesForProject;
                using (var conn = DatabaseHelper.GetConnection())
                {
                    await conn.OpenAsync();
                    allLinesForProject = await GetFlatDetailedBudgetLinesByProjectIdAsync(projectId, conn, null);
                }
                var topLevelLines = ReconstructLineHierarchy(allLinesForProject).Where(l => !l.ParentDetailedBudgetLineID.HasValue).ToList(); // Ensure we get top level from reconstructed
                foreach (var line in topLevelLines) await DeleteDetailedBudgetLineAsync(line.DetailedBudgetLineID);

                string sql = "DELETE FROM Projects WHERE ProjectID = @ProjectID";
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProjectID", projectId); await conn.OpenAsync(); return await cmd.ExecuteNonQueryAsync() > 0;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error in DeleteProjectAsync for ProjectID {projectId}: {ex.Message}"); return false; }
        }
    }
}
