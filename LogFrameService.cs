using HumanitarianProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public class LogFrameService
    {
        #region Outcome CRUD
        public async Task<List<Outcome>> GetOutcomesByProjectIdAsync(int projectId)
        {
            List<Outcome> outcomes = new List<Outcome>();
            string query = "SELECT OutcomeID, ProjectID, OutcomeDescription FROM Outcome WHERE ProjectID = @ProjectID"; // Changed

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
                                outcomes.Add(new Outcome
                                {
                                    OutcomeID = (int)reader["OutcomeID"],
                                    ProjectID = (int)reader["ProjectID"],
                                    OutcomeDescription = reader["OutcomeDescription"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetOutcomesByProjectIdAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in GetOutcomesByProjectIdAsync: {ex.Message}");
            }
            return outcomes;
        }

        public async Task<int> AddOutcomeAsync(Outcome outcome)
        {
            if (outcome == null) throw new ArgumentNullException(nameof(outcome));
            if (string.IsNullOrWhiteSpace(outcome.OutcomeDescription)) throw new ArgumentException("OutcomeDescription cannot be empty.");

            string query = @"INSERT INTO Outcome (ProjectID, OutcomeDescription)
                             VALUES (@ProjectID, @OutcomeDescription);
                             SELECT CAST(SCOPE_IDENTITY() as int);"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectID", outcome.ProjectID);
                        command.Parameters.AddWithValue("@OutcomeDescription", outcome.OutcomeDescription);

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
                Console.WriteLine($"SQL Error in AddOutcomeAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in AddOutcomeAsync: {ex.Message}");
            }
            return 0;
        }

        public async Task<bool> UpdateOutcomeAsync(Outcome outcome)
        {
            if (outcome == null) throw new ArgumentNullException(nameof(outcome));
            if (string.IsNullOrWhiteSpace(outcome.OutcomeDescription)) throw new ArgumentException("OutcomeDescription cannot be empty.");

            string query = @"UPDATE Outcome SET
                                OutcomeDescription = @OutcomeDescription,
                                ProjectID = @ProjectID
                             WHERE OutcomeID = @OutcomeID;"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutcomeDescription", outcome.OutcomeDescription);
                        command.Parameters.AddWithValue("@ProjectID", outcome.ProjectID);
                        command.Parameters.AddWithValue("@OutcomeID", outcome.OutcomeID);

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in UpdateOutcomeAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in UpdateOutcomeAsync: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> DeleteOutcomeAsync(int outcomeId)
        {
            string query = "DELETE FROM Outcome WHERE OutcomeID = @OutcomeID;"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutcomeID", outcomeId);
                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in DeleteOutcomeAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in DeleteOutcomeAsync: {ex.Message}");
            }
            return false;
        }
        #endregion

        #region Output CRUD
        public async Task<List<Output>> GetOutputsByOutcomeIdAsync(int outcomeId)
        {
            List<Output> outputs = new List<Output>();
            string query = "SELECT OutputID, OutcomeID, OutputDescription FROM Output WHERE OutcomeID = @OutcomeID"; // Changed

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutcomeID", outcomeId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                outputs.Add(new Output
                                {
                                    OutputID = (int)reader["OutputID"],
                                    OutcomeID = (int)reader["OutcomeID"],
                                    OutputDescription = reader["OutputDescription"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetOutputsByOutcomeIdAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in GetOutputsByOutcomeIdAsync: {ex.Message}");
            }
            return outputs;
        }

        public async Task<int> AddOutputAsync(Output output)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (string.IsNullOrWhiteSpace(output.OutputDescription)) throw new ArgumentException("OutputDescription cannot be empty.");

            string query = @"INSERT INTO Output (OutcomeID, OutputDescription)
                             VALUES (@OutcomeID, @OutputDescription);
                             SELECT CAST(SCOPE_IDENTITY() as int);"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutcomeID", output.OutcomeID);
                        command.Parameters.AddWithValue("@OutputDescription", output.OutputDescription);

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
                Console.WriteLine($"SQL Error in AddOutputAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in AddOutputAsync: {ex.Message}");
            }
            return 0;
        }

        public async Task<bool> UpdateOutputAsync(Output output)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (string.IsNullOrWhiteSpace(output.OutputDescription)) throw new ArgumentException("OutputDescription cannot be empty.");

            string query = @"UPDATE Output SET
                                OutputDescription = @OutputDescription,
                                OutcomeID = @OutcomeID
                             WHERE OutputID = @OutputID;"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutputDescription", output.OutputDescription);
                        command.Parameters.AddWithValue("@OutcomeID", output.OutcomeID);
                        command.Parameters.AddWithValue("@OutputID", output.OutputID);

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in UpdateOutputAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in UpdateOutputAsync: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> DeleteOutputAsync(int outputId)
        {
            string query = "DELETE FROM Output WHERE OutputID = @OutputID;"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutputID", outputId);
                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in DeleteOutputAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in DeleteOutputAsync: {ex.Message}");
            }
            return false;
        }
        #endregion

        #region Activity CRUD
        public async Task<List<Activity>> GetActivitiesByOutputIdAsync(int outputId)
        {
            List<Activity> activities = new List<Activity>();
            string query = "SELECT ActivityID, OutputID, ActivityDescription, PlannedMonths FROM Activity WHERE OutputID = @OutputID"; // Changed

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutputID", outputId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                activities.Add(new Activity
                                {
                                    ActivityID = (int)reader["ActivityID"],
                                    OutputID = (int)reader["OutputID"],
                                    ActivityDescription = reader["ActivityDescription"].ToString(),
                                    PlannedMonths = reader["PlannedMonths"] != DBNull.Value ? reader["PlannedMonths"].ToString() : null
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetActivitiesByOutputIdAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in GetActivitiesByOutputIdAsync: {ex.Message}");
            }
            return activities;
        }

        public async Task<int> AddActivityAsync(Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));
            if (string.IsNullOrWhiteSpace(activity.ActivityDescription)) throw new ArgumentException("ActivityDescription cannot be empty.");

            string query = @"INSERT INTO Activity (OutputID, ActivityDescription, PlannedMonths)
                             VALUES (@OutputID, @ActivityDescription, @PlannedMonths);
                             SELECT CAST(SCOPE_IDENTITY() as int);"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutputID", activity.OutputID);
                        command.Parameters.AddWithValue("@ActivityDescription", activity.ActivityDescription);
                        command.Parameters.AddWithValue("@PlannedMonths", (object)activity.PlannedMonths ?? DBNull.Value);

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
                Console.WriteLine($"SQL Error in AddActivityAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in AddActivityAsync: {ex.Message}");
            }
            return 0;
        }

        public async Task<bool> UpdateActivityAsync(Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));
            if (string.IsNullOrWhiteSpace(activity.ActivityDescription)) throw new ArgumentException("ActivityDescription cannot be empty.");

            string query = @"UPDATE Activity SET
                                ActivityDescription = @ActivityDescription,
                                OutputID = @OutputID,
                                PlannedMonths = @PlannedMonths
                             WHERE ActivityID = @ActivityID;"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ActivityDescription", activity.ActivityDescription);
                        command.Parameters.AddWithValue("@OutputID", activity.OutputID);
                        command.Parameters.AddWithValue("@PlannedMonths", (object)activity.PlannedMonths ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActivityID", activity.ActivityID);

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in UpdateActivityAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in UpdateActivityAsync: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> DeleteActivityAsync(int activityId)
        {
            string query = "DELETE FROM Activity WHERE ActivityID = @ActivityID;"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ActivityID", activityId);
                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in DeleteActivityAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in DeleteActivityAsync: {ex.Message}");
            }
            return false;
        }
        #endregion

        #region ProjectIndicator CRUD (related to Output)
        public async Task<List<ProjectIndicator>> GetProjectIndicatorsByOutputIdAsync(int outputId)
        {
            List<ProjectIndicator> indicators = new List<ProjectIndicator>();
            string query = @"SELECT ProjectIndicatorID, ProjectID, OutputID, IndicatorName, Description,
                                    TargetValue, ActualValue, UnitOfMeasure, BaselineValue,
                                    StartDate, EndDate, IsKeyIndicator,
                                    TargetMen, TargetWomen, TargetBoys, TargetGirls, TargetTotal, MeansOfVerification
                             FROM ProjectIndicator
                             WHERE OutputID = @OutputID"; // Changed

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OutputID", outputId);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                indicators.Add(new ProjectIndicator
                                {
                                    ProjectIndicatorID = (int)reader["ProjectIndicatorID"],
                                    ProjectID = (int)reader["ProjectID"],
                                    OutputID = reader["OutputID"] != DBNull.Value ? (int?)reader["OutputID"] : null,
                                    IndicatorName = reader["IndicatorName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                    TargetValue = reader["TargetValue"] != DBNull.Value ? reader["TargetValue"].ToString() : null,
                                    ActualValue = reader["ActualValue"] != DBNull.Value ? reader["ActualValue"].ToString() : null,
                                    UnitOfMeasure = reader["UnitOfMeasure"] != DBNull.Value ? reader["UnitOfMeasure"].ToString() : null,
                                    BaselineValue = reader["BaselineValue"] != DBNull.Value ? reader["BaselineValue"].ToString() : null,
                                    StartDate = reader["StartDate"] != DBNull.Value ? (DateTime?)reader["StartDate"] : null,
                                    EndDate = reader["EndDate"] != DBNull.Value ? (DateTime?)reader["EndDate"] : null,
                                    IsKeyIndicator = (bool)reader["IsKeyIndicator"],
                                    TargetMen = reader["TargetMen"] != DBNull.Value ? (int)reader["TargetMen"] : 0,
                                    TargetWomen = reader["TargetWomen"] != DBNull.Value ? (int)reader["TargetWomen"] : 0,
                                    TargetBoys = reader["TargetBoys"] != DBNull.Value ? (int)reader["TargetBoys"] : 0,
                                    TargetGirls = reader["TargetGirls"] != DBNull.Value ? (int)reader["TargetGirls"] : 0,
                                    TargetTotal = reader["TargetTotal"] != DBNull.Value ? (int)reader["TargetTotal"] : 0,
                                    MeansOfVerification = reader["MeansOfVerification"] != DBNull.Value ? reader["MeansOfVerification"].ToString() : null
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in GetProjectIndicatorsByOutputIdAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in GetProjectIndicatorsByOutputIdAsync: {ex.Message}");
            }
            return indicators;
        }

        public async Task<int> AddProjectIndicatorToOutputAsync(ProjectIndicator indicator)
        {
            if (indicator == null) throw new ArgumentNullException(nameof(indicator));
            if (string.IsNullOrWhiteSpace(indicator.IndicatorName)) throw new ArgumentException("IndicatorName cannot be empty.");
            if (!indicator.OutputID.HasValue) throw new ArgumentException("OutputID must be set for the indicator.");

            string query = @"INSERT INTO ProjectIndicator
                                (ProjectID, OutputID, IndicatorName, Description, TargetValue, ActualValue, UnitOfMeasure, BaselineValue, StartDate, EndDate, IsKeyIndicator, TargetMen, TargetWomen, TargetBoys, TargetGirls, TargetTotal, MeansOfVerification)
                             VALUES
                                (@ProjectID, @OutputID, @IndicatorName, @Description, @TargetValue, @ActualValue, @UnitOfMeasure, @BaselineValue, @StartDate, @EndDate, @IsKeyIndicator, @TargetMen, @TargetWomen, @TargetBoys, @TargetGirls, @TargetTotal, @MeansOfVerification);
                             SELECT CAST(SCOPE_IDENTITY() as int);"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectID", indicator.ProjectID);
                        command.Parameters.AddWithValue("@OutputID", indicator.OutputID.Value);
                        command.Parameters.AddWithValue("@IndicatorName", indicator.IndicatorName);
                        command.Parameters.AddWithValue("@Description", (object)indicator.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TargetValue", (object)indicator.TargetValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActualValue", (object)indicator.ActualValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UnitOfMeasure", (object)indicator.UnitOfMeasure ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BaselineValue", (object)indicator.BaselineValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartDate", (object)indicator.StartDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EndDate", (object)indicator.EndDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsKeyIndicator", indicator.IsKeyIndicator);
                        command.Parameters.AddWithValue("@TargetMen", indicator.TargetMen);
                        command.Parameters.AddWithValue("@TargetWomen", indicator.TargetWomen);
                        command.Parameters.AddWithValue("@TargetBoys", indicator.TargetBoys);
                        command.Parameters.AddWithValue("@TargetGirls", indicator.TargetGirls);
                        command.Parameters.AddWithValue("@TargetTotal", indicator.TargetTotal);
                        command.Parameters.AddWithValue("@MeansOfVerification", (object)indicator.MeansOfVerification ?? DBNull.Value);

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
                Console.WriteLine($"SQL Error in AddProjectIndicatorToOutputAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in AddProjectIndicatorToOutputAsync: {ex.Message}");
            }
            return 0;
        }

        public async Task<bool> UpdateProjectIndicatorAsync(ProjectIndicator indicator)
        {
            if (indicator == null) throw new ArgumentNullException(nameof(indicator));
            if (string.IsNullOrWhiteSpace(indicator.IndicatorName)) throw new ArgumentException("IndicatorName cannot be empty.");

            string query = @"UPDATE ProjectIndicator SET
                                ProjectID = @ProjectID,
                                OutputID = @OutputID,
                                IndicatorName = @IndicatorName,
                                Description = @Description,
                                TargetValue = @TargetValue,
                                ActualValue = @ActualValue,
                                UnitOfMeasure = @UnitOfMeasure,
                                BaselineValue = @BaselineValue,
                                StartDate = @StartDate,
                                EndDate = @EndDate,
                                IsKeyIndicator = @IsKeyIndicator,
                                TargetMen = @TargetMen,
                                TargetWomen = @TargetWomen,
                                TargetBoys = @TargetBoys,
                                TargetGirls = @TargetGirls,
                                TargetTotal = @TargetTotal,
                                MeansOfVerification = @MeansOfVerification
                             WHERE ProjectIndicatorID = @ProjectIndicatorID;"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectID", indicator.ProjectID);
                        command.Parameters.AddWithValue("@OutputID", (object)indicator.OutputID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IndicatorName", indicator.IndicatorName);
                        command.Parameters.AddWithValue("@Description", (object)indicator.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TargetValue", (object)indicator.TargetValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActualValue", (object)indicator.ActualValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UnitOfMeasure", (object)indicator.UnitOfMeasure ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BaselineValue", (object)indicator.BaselineValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartDate", (object)indicator.StartDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EndDate", (object)indicator.EndDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsKeyIndicator", indicator.IsKeyIndicator);
                        command.Parameters.AddWithValue("@TargetMen", indicator.TargetMen);
                        command.Parameters.AddWithValue("@TargetWomen", indicator.TargetWomen);
                        command.Parameters.AddWithValue("@TargetBoys", indicator.TargetBoys);
                        command.Parameters.AddWithValue("@TargetGirls", indicator.TargetGirls);
                        command.Parameters.AddWithValue("@TargetTotal", indicator.TargetTotal);
                        command.Parameters.AddWithValue("@MeansOfVerification", (object)indicator.MeansOfVerification ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ProjectIndicatorID", indicator.ProjectIndicatorID);

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in UpdateProjectIndicatorAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in UpdateProjectIndicatorAsync: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> DeleteProjectIndicatorAsync(int projectIndicatorId)
        {
            string query = "DELETE FROM ProjectIndicator WHERE ProjectIndicatorID = @ProjectIndicatorID;"; // Changed
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectIndicatorID", projectIndicatorId);
                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error in DeleteProjectIndicatorAsync: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error in DeleteProjectIndicatorAsync: {ex.Message}");
            }
            return false;
        }
        #endregion
    }
}
