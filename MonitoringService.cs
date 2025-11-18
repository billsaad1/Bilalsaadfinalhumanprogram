using HumanitarianProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using HumanitarianProjectManagement; // For AppContext

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public class MonitoringService
    {
        public async Task<List<ProjectIndicator>> GetIndicatorsForProjectAsync(int projectId)
        {
            List<ProjectIndicator> indicators = new List<ProjectIndicator>();
            string query = "SELECT IndicatorID, ProjectID, IndicatorName, Description, TargetValue, ActualValue, UnitOfMeasure, BaselineValue, StartDate, EndDate, IsKeyIndicator FROM ProjectIndicators WHERE ProjectID = @ProjectID ORDER BY IndicatorName;";

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
                                ProjectIndicator indicator = new ProjectIndicator
                                {
                                    ProjectIndicatorID = (int)reader["IndicatorID"], // Changed to ProjectIndicatorID
                                    ProjectID = (int)reader["ProjectID"],
                                    IndicatorName = reader["IndicatorName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                    TargetValue = reader["TargetValue"] != DBNull.Value ? reader["TargetValue"].ToString() : null,
                                    ActualValue = reader["ActualValue"] != DBNull.Value ? reader["ActualValue"].ToString() : null,
                                    UnitOfMeasure = reader["UnitOfMeasure"] != DBNull.Value ? reader["UnitOfMeasure"].ToString() : null,
                                    BaselineValue = reader["BaselineValue"] != DBNull.Value ? reader["BaselineValue"].ToString() : null,
                                    StartDate = reader["StartDate"] != DBNull.Value ? (DateTime?)reader["StartDate"] : null,
                                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime?)reader["EndDate"] : null,
                                    IsKeyIndicator = (bool)reader["IsKeyIndicator"]
                                };
                                indicators.Add(indicator);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetIndicatorsForProjectAsync: {ex.Message}");
                // Return empty list or rethrow as appropriate
            }
            return indicators;
        }

        public async Task<ProjectIndicator> GetIndicatorByIdAsync(int indicatorId)
        {
            ProjectIndicator indicator = null;
            string query = "SELECT IndicatorID, ProjectID, IndicatorName, Description, TargetValue, ActualValue, UnitOfMeasure, BaselineValue, StartDate, EndDate, IsKeyIndicator FROM ProjectIndicators WHERE IndicatorID = @IndicatorID;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IndicatorID", indicatorId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                indicator = new ProjectIndicator
                                {
                                    ProjectIndicatorID = (int)reader["IndicatorID"], // Changed to ProjectIndicatorID
                                    ProjectID = (int)reader["ProjectID"],
                                    IndicatorName = reader["IndicatorName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                    TargetValue = reader["TargetValue"] != DBNull.Value ? reader["TargetValue"].ToString() : null,
                                    ActualValue = reader["ActualValue"] != DBNull.Value ? reader["ActualValue"].ToString() : null,
                                    UnitOfMeasure = reader["UnitOfMeasure"] != DBNull.Value ? reader["UnitOfMeasure"].ToString() : null,
                                    BaselineValue = reader["BaselineValue"] != DBNull.Value ? reader["BaselineValue"].ToString() : null,
                                    StartDate = reader["StartDate"] != DBNull.Value ? (DateTime?)reader["StartDate"] : null,
                                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime?)reader["EndDate"] : null,
                                    IsKeyIndicator = (bool)reader["IsKeyIndicator"]
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetIndicatorByIdAsync: {ex.Message}");
            }
            return indicator;
        }

        public async Task<bool> SaveProjectIndicatorAsync(ProjectIndicator indicator)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    SqlCommand command;
                    if (indicator.ProjectIndicatorID == 0) // New indicator - Changed to ProjectIndicatorID
                    {
                        string insertQuery = @"
                            INSERT INTO ProjectIndicators (ProjectID, IndicatorName, Description, TargetValue, ActualValue, UnitOfMeasure, BaselineValue, StartDate, EndDate, IsKeyIndicator) 
                            VALUES (@ProjectID, @IndicatorName, @Description, @TargetValue, @ActualValue, @UnitOfMeasure, @BaselineValue, @StartDate, @EndDate, @IsKeyIndicator); 
                            SELECT CAST(SCOPE_IDENTITY() as int);";
                        command = new SqlCommand(insertQuery, connection);
                    }
                    else // Existing indicator
                    {
                        string updateQuery = @"
                            UPDATE ProjectIndicators SET 
                                ProjectID = @ProjectID, IndicatorName = @IndicatorName, Description = @Description, 
                                TargetValue = @TargetValue, ActualValue = @ActualValue, UnitOfMeasure = @UnitOfMeasure, 
                                BaselineValue = @BaselineValue, StartDate = @StartDate, EndDate = @EndDate, 
                                IsKeyIndicator = @IsKeyIndicator 
                            WHERE IndicatorID = @IndicatorID;"; // SQL still uses @IndicatorID matching the WHERE clause
                        command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@IndicatorID", indicator.ProjectIndicatorID); // Value from model's ProjectIndicatorID
                    }

                    command.Parameters.AddWithValue("@ProjectID", indicator.ProjectID);
                    command.Parameters.AddWithValue("@IndicatorName", indicator.IndicatorName);
                    command.Parameters.AddWithValue("@Description", (object)indicator.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TargetValue", (object)indicator.TargetValue ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ActualValue", (object)indicator.ActualValue ?? DBNull.Value);
                    command.Parameters.AddWithValue("@UnitOfMeasure", (object)indicator.UnitOfMeasure ?? DBNull.Value);
                    command.Parameters.AddWithValue("@BaselineValue", (object)indicator.BaselineValue ?? DBNull.Value);
                    command.Parameters.AddWithValue("@StartDate", (object)indicator.StartDate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@EndDate", (object)indicator.EndDate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IsKeyIndicator", indicator.IsKeyIndicator);

                    await connection.OpenAsync();
                    if (indicator.ProjectIndicatorID == 0) // Changed to ProjectIndicatorID
                    {
                        object newId = await command.ExecuteScalarAsync();
                        if (newId != null && newId != DBNull.Value)
                        {
                            indicator.ProjectIndicatorID = Convert.ToInt32(newId); // Changed to ProjectIndicatorID
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
                Console.WriteLine($"SQL Error in SaveProjectIndicatorAsync: {ex.Message}");
                return false;
            }
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteProjectIndicatorAsync(int indicatorId)
        {
            string sql = "DELETE FROM ProjectIndicators WHERE IndicatorID = @IndicatorID;";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IndicatorID", indicatorId);
                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in DeleteProjectIndicatorAsync: {ex.Message}");
                        // Consider specific error handling for FK violations (e.g., related VerificationMeans)
                        return false;
                    }
                }
            }
        }

        // New methods for FollowUpVisit records
        public async Task<List<FollowUpVisit>> GetFollowUpVisitsForProjectAsync(int projectId)
        {
            List<FollowUpVisit> visits = new List<FollowUpVisit>();
            string query = "SELECT VisitID, ProjectID, BeneficiaryID, VisitDate, VisitedByUserID, VisitPurpose, Observations, ActionItems, NextFollowUpDate, Notes FROM FollowUpVisits WHERE ProjectID = @ProjectID ORDER BY VisitDate DESC;";

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
                                FollowUpVisit visit = new FollowUpVisit
                                {
                                    VisitID = (int)reader["VisitID"],
                                    ProjectID = (int)reader["ProjectID"],
                                    BeneficiaryID = reader["BeneficiaryID"] != DBNull.Value ? (int?)reader["BeneficiaryID"] : null,
                                    VisitDate = (DateTime)reader["VisitDate"],
                                    VisitedByUserID = reader["VisitedByUserID"] != DBNull.Value ? (int?)reader["VisitedByUserID"] : null,
                                    VisitPurpose = reader["VisitPurpose"] != DBNull.Value ? reader["VisitPurpose"].ToString() : null,
                                    Observations = reader["Observations"] != DBNull.Value ? reader["Observations"].ToString() : null,
                                    ActionItems = reader["ActionItems"] != DBNull.Value ? reader["ActionItems"].ToString() : null,
                                    NextFollowUpDate = reader["NextFollowUpDate"] != DBNull.Value ? (DateTime?)reader["NextFollowUpDate"] : null,
                                    Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null
                                };
                                visits.Add(visit);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetFollowUpVisitsForProjectAsync: {ex.Message}");
            }
            return visits;
        }

        public async Task<FollowUpVisit> GetFollowUpVisitByIdAsync(int visitId)
        {
            FollowUpVisit visit = null;
            string query = "SELECT VisitID, ProjectID, BeneficiaryID, VisitDate, VisitedByUserID, VisitPurpose, Observations, ActionItems, NextFollowUpDate, Notes FROM FollowUpVisits WHERE VisitID = @VisitID;";

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VisitID", visitId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                visit = new FollowUpVisit
                                {
                                    VisitID = (int)reader["VisitID"],
                                    ProjectID = (int)reader["ProjectID"],
                                    BeneficiaryID = reader["BeneficiaryID"] != DBNull.Value ? (int?)reader["BeneficiaryID"] : null,
                                    VisitDate = (DateTime)reader["VisitDate"],
                                    VisitedByUserID = reader["VisitedByUserID"] != DBNull.Value ? (int?)reader["VisitedByUserID"] : null,
                                    VisitPurpose = reader["VisitPurpose"] != DBNull.Value ? reader["VisitPurpose"].ToString() : null,
                                    Observations = reader["Observations"] != DBNull.Value ? reader["Observations"].ToString() : null,
                                    ActionItems = reader["ActionItems"] != DBNull.Value ? reader["ActionItems"].ToString() : null,
                                    NextFollowUpDate = reader["NextFollowUpDate"] != DBNull.Value ? (DateTime?)reader["NextFollowUpDate"] : null,
                                    Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetFollowUpVisitByIdAsync: {ex.Message}");
            }
            return visit;
        }

        public async Task<bool> SaveFollowUpVisitAsync(FollowUpVisit visit)
        {
            if (visit.ProjectID <= 0)
            {
                Console.WriteLine("Error in SaveFollowUpVisitAsync: ProjectID must be greater than 0.");
                return false;
            }

            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    SqlCommand command;
                    if (visit.VisitID == 0) // New visit
                    {
                        // Use ApplicationState for CurrentUser
                        visit.VisitedByUserID = visit.VisitedByUserID ?? ApplicationState.CurrentUser?.UserID;
                        visit.VisitDate = (visit.VisitDate == DateTime.MinValue) ? DateTime.Now : visit.VisitDate;

                        string insertQuery = @"
                            INSERT INTO FollowUpVisits (ProjectID, BeneficiaryID, VisitDate, VisitedByUserID, VisitPurpose, Observations, ActionItems, NextFollowUpDate, Notes) 
                            VALUES (@ProjectID, @BeneficiaryID, @VisitDate, @VisitedByUserID, @VisitPurpose, @Observations, @ActionItems, @NextFollowUpDate, @Notes); 
                            SELECT CAST(SCOPE_IDENTITY() as int);";
                        command = new SqlCommand(insertQuery, connection);
                    }
                    else // Existing visit
                    {
                        string updateQuery = @"
                            UPDATE FollowUpVisits SET 
                                ProjectID = @ProjectID, BeneficiaryID = @BeneficiaryID, VisitDate = @VisitDate, 
                                VisitedByUserID = @VisitedByUserID, VisitPurpose = @VisitPurpose, Observations = @Observations, 
                                ActionItems = @ActionItems, NextFollowUpDate = @NextFollowUpDate, Notes = @Notes 
                            WHERE VisitID = @VisitID;";
                        command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@VisitID", visit.VisitID);
                    }

                    command.Parameters.AddWithValue("@ProjectID", visit.ProjectID);
                    command.Parameters.AddWithValue("@BeneficiaryID", (object)visit.BeneficiaryID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@VisitDate", visit.VisitDate);
                    command.Parameters.AddWithValue("@VisitedByUserID", (object)visit.VisitedByUserID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@VisitPurpose", (object)visit.VisitPurpose ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Observations", (object)visit.Observations ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ActionItems", (object)visit.ActionItems ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NextFollowUpDate", (object)visit.NextFollowUpDate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Notes", (object)visit.Notes ?? DBNull.Value);

                    await connection.OpenAsync();
                    if (visit.VisitID == 0)
                    {
                        object newId = await command.ExecuteScalarAsync();
                        if (newId != null && newId != DBNull.Value)
                        {
                            visit.VisitID = Convert.ToInt32(newId);
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
                Console.WriteLine($"SQL Error in SaveFollowUpVisitAsync: {ex.Message}");
                return false;
            }
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteFollowUpVisitAsync(int visitId)
        {
            string sql = "DELETE FROM FollowUpVisits WHERE VisitID = @VisitID;";
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@VisitID", visitId);
                    try
                    {
                        await conn.OpenAsync();
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error in DeleteFollowUpVisitAsync: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
