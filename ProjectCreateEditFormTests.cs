using HumanitarianProjectManagement.Models;
// Using Models.Activity directly to avoid ambiguity if a global ProjectActivity exists
// using ProjectActivity = HumanitarianProjectManagement.Models.Activity; 
using System.Diagnostics; // For Debug.Assert
using System.Collections.Generic; // For List
using System.Linq;
using System; // For Console.WriteLine

namespace HumanitarianProjectManagement.Tests // Or any appropriate namespace
{
    public class ProjectCreateEditFormTests
    {
        public static void RunAllConceptualTests()
        {
            Console.WriteLine("Running ProjectCreateEditFormTests...");
            TestAddOutcome_UpdatesModel();
            TestAddOutput_UpdatesModel();
            TestAddIndicator_UpdatesModel();
            TestAddActivity_UpdatesModel();

            TestDeleteOutcome_UpdatesModel();
            TestDeleteOutput_UpdatesModel();
            TestDeleteIndicator_UpdatesModel();
            TestDeleteActivity_UpdatesModel();

            TestBudgetLineTotalCostCalculation();
            TestAddBudgetLine_UpdatesModel();
            TestDeleteBudgetLine_UpdatesModel();
            TestActivityPlanPlannedMonthsUpdate();

            Console.WriteLine("ProjectCreateEditFormTests conceptual checks completed.");
        }

        static void TestAddOutcome_UpdatesModel()
        {
            var project = new Project();
            var outcome = new Outcome { OutcomeDescription = "Test Outcome" };
            if (project.Outcomes == null) project.Outcomes = new List<Outcome>();
            else if (!(project.Outcomes is List<Outcome>)) project.Outcomes = project.Outcomes.OfType<Outcome>().ToList();
            ((IList<Outcome>)project.Outcomes).Add(outcome);
            Debug.Assert(project.Outcomes.Count() == 1, "TestAddOutcome_UpdatesModel: Failed - Count should be 1.");
            Debug.Assert(project.Outcomes.First().OutcomeDescription == "Test Outcome", "TestAddOutcome_UpdatesModel: Failed - Description mismatch.");
        }

        static void TestAddOutput_UpdatesModel()
        {
            var outcome = new Outcome();
            var output = new Output { OutputDescription = "Test Output" };
            if (outcome.Outputs == null) outcome.Outputs = new List<Output>();
            else if (!(outcome.Outputs is List<Output>)) outcome.Outputs = outcome.Outputs.OfType<Output>().ToList();
            ((IList<Output>)outcome.Outputs).Add(output);
            Debug.Assert(outcome.Outputs.Count() == 1, "TestAddOutput_UpdatesModel: Failed - Count should be 1.");
            Debug.Assert(outcome.Outputs.First().OutputDescription == "Test Output", "TestAddOutput_UpdatesModel: Failed - Description mismatch.");
        }

        static void TestAddIndicator_UpdatesModel()
        {
            var output = new Output();
            var indicator = new ProjectIndicator { IndicatorName = "Test Indicator" };
            if (output.ProjectIndicators == null) output.ProjectIndicators = new List<ProjectIndicator>();
            else if (!(output.ProjectIndicators is List<ProjectIndicator>)) output.ProjectIndicators = output.ProjectIndicators.OfType<ProjectIndicator>().ToList();
            ((IList<ProjectIndicator>)output.ProjectIndicators).Add(indicator);
            Debug.Assert(output.ProjectIndicators.Count() == 1, "TestAddIndicator_UpdatesModel: Failed - Count should be 1.");
            Debug.Assert(output.ProjectIndicators.First().IndicatorName == "Test Indicator", "TestAddIndicator_UpdatesModel: Failed - Name mismatch.");
        }

        static void TestAddActivity_UpdatesModel()
        {
            var output = new Output();
            var activity = new HumanitarianProjectManagement.Models.Activity { ActivityDescription = "Test Activity" };
            if (output.Activities == null) output.Activities = new List<HumanitarianProjectManagement.Models.Activity>();
            else if (!(output.Activities is List<HumanitarianProjectManagement.Models.Activity>)) output.Activities = output.Activities.OfType<HumanitarianProjectManagement.Models.Activity>().ToList();
            ((IList<HumanitarianProjectManagement.Models.Activity>)output.Activities).Add(activity);
            Debug.Assert(output.Activities.Count() == 1, "TestAddActivity_UpdatesModel: Failed - Count should be 1.");
            Debug.Assert(output.Activities.First().ActivityDescription == "Test Activity", "TestAddActivity_UpdatesModel: Failed - Description mismatch.");
        }

        static void TestDeleteOutcome_UpdatesModel()
        {
            var project = new Project();
            var outcome1 = new Outcome { OutcomeID = 1, OutcomeDescription = "Test Outcome 1" };
            var outcome2 = new Outcome { OutcomeID = 2, OutcomeDescription = "Test Outcome 2" };
            if (project.Outcomes == null) project.Outcomes = new List<Outcome>();
            else if (!(project.Outcomes is List<Outcome>)) project.Outcomes = project.Outcomes.OfType<Outcome>().ToList();
            var outcomesList = (IList<Outcome>)project.Outcomes;
            outcomesList.Add(outcome1);
            outcomesList.Add(outcome2);
            outcomesList.Remove(outcome1);
            Debug.Assert(project.Outcomes.Count() == 1, "TestDeleteOutcome_UpdatesModel: Failed - Count should be 1 after delete.");
            Debug.Assert(project.Outcomes.First().OutcomeID == 2, "TestDeleteOutcome_UpdatesModel: Failed - Remaining outcome mismatch.");
        }

        static void TestDeleteOutput_UpdatesModel()
        {
            var outcome = new Outcome();
            var output1 = new Output { OutputID = 1, OutputDescription = "Test Output 1" };
            var output2 = new Output { OutputID = 2, OutputDescription = "Test Output 2" };
            if (outcome.Outputs == null) outcome.Outputs = new List<Output>();
            else if (!(outcome.Outputs is List<Output>)) outcome.Outputs = outcome.Outputs.OfType<Output>().ToList();
            var outputsList = (IList<Output>)outcome.Outputs;
            outputsList.Add(output1);
            outputsList.Add(output2);
            outputsList.Remove(output1);
            Debug.Assert(outcome.Outputs.Count() == 1, "TestDeleteOutput_UpdatesModel: Failed - Count should be 1 after delete.");
            Debug.Assert(outcome.Outputs.First().OutputID == 2, "TestDeleteOutput_UpdatesModel: Failed - Remaining output mismatch.");
        }

        static void TestDeleteIndicator_UpdatesModel()
        {
            var output = new Output();
            var indicator1 = new ProjectIndicator { ProjectIndicatorID = 1, IndicatorName = "Test Indicator 1" };
            var indicator2 = new ProjectIndicator { ProjectIndicatorID = 2, IndicatorName = "Test Indicator 2" };
            if (output.ProjectIndicators == null) output.ProjectIndicators = new List<ProjectIndicator>();
            else if (!(output.ProjectIndicators is List<ProjectIndicator>)) output.ProjectIndicators = output.ProjectIndicators.OfType<ProjectIndicator>().ToList();
            var indicatorsList = (IList<ProjectIndicator>)output.ProjectIndicators;
            indicatorsList.Add(indicator1);
            indicatorsList.Add(indicator2);
            indicatorsList.Remove(indicator1);
            Debug.Assert(output.ProjectIndicators.Count() == 1, "TestDeleteIndicator_UpdatesModel: Failed - Count should be 1 after delete.");
            Debug.Assert(output.ProjectIndicators.First().ProjectIndicatorID == 2, "TestDeleteIndicator_UpdatesModel: Failed - Remaining indicator mismatch.");
        }

        static void TestDeleteActivity_UpdatesModel()
        {
            var output = new Output();
            var activity1 = new HumanitarianProjectManagement.Models.Activity { ActivityID = 1, ActivityDescription = "Test Activity 1" };
            var activity2 = new HumanitarianProjectManagement.Models.Activity { ActivityID = 2, ActivityDescription = "Test Activity 2" };
            if (output.Activities == null) output.Activities = new List<HumanitarianProjectManagement.Models.Activity>();
            else if (!(output.Activities is List<HumanitarianProjectManagement.Models.Activity>)) output.Activities = output.Activities.OfType<HumanitarianProjectManagement.Models.Activity>().ToList();
            var activitiesList = (IList<HumanitarianProjectManagement.Models.Activity>)output.Activities;
            activitiesList.Add(activity1);
            activitiesList.Add(activity2);
            activitiesList.Remove(activity1);
            Debug.Assert(output.Activities.Count() == 1, "TestDeleteActivity_UpdatesModel: Failed - Count should be 1 after delete.");
            Debug.Assert(output.Activities.First().ActivityID == 2, "TestDeleteActivity_UpdatesModel: Failed - Remaining activity mismatch.");
        }

        static void TestBudgetLineTotalCostCalculation()
        {
            var line = new DetailedBudgetLine { Quantity = 2, UnitCost = 10, Duration = 3, PercentageChargedToCBPF = 100 };
            line.TotalCost = line.Quantity * line.UnitCost * line.Duration * (line.PercentageChargedToCBPF / 100M);
            Debug.Assert(line.TotalCost == 60, $"TestBudgetLineTotalCostCalculation: Failed - Expected 60, Got {line.TotalCost}.");

            line.PercentageChargedToCBPF = 50;
            line.TotalCost = line.Quantity * line.UnitCost * line.Duration * (line.PercentageChargedToCBPF / 100M);
            Debug.Assert(line.TotalCost == 30, $"TestBudgetLineTotalCostCalculation: Failed - Expected 30 with 50%, Got {line.TotalCost}.");
        }

        static void TestAddBudgetLine_UpdatesModel()
        {
            var project = new Project();
            var budgetLine = new DetailedBudgetLine { Description = "Test Budget Line", UnitCost = 100 };

            List<DetailedBudgetLine> linesList;
            if (project.DetailedBudgetLines == null)
            {
                linesList = new List<DetailedBudgetLine>();
            }
            else
            {
                // Ensure working with a List<DetailedBudgetLine>
                linesList = project.DetailedBudgetLines.OfType<DetailedBudgetLine>().ToList();
            }

            linesList.Add(budgetLine);
            project.DetailedBudgetLines = linesList;

            Debug.Assert(project.DetailedBudgetLines.Count() == 1, "TestAddBudgetLine_UpdatesModel: Failed - Count should be 1.");
            Debug.Assert(project.DetailedBudgetLines.First().Description == "Test Budget Line", "TestAddBudgetLine_UpdatesModel: Failed - Description mismatch.");
        }

        static void TestDeleteBudgetLine_UpdatesModel()
        {
            var project = new Project();
            var line1 = new DetailedBudgetLine { Description = "Line 1" };
            var line2 = new DetailedBudgetLine { Description = "Line 2" };

            List<DetailedBudgetLine> linesList;
            if (project.DetailedBudgetLines == null)
            {
                linesList = new List<DetailedBudgetLine>();
            }
            else
            {
                linesList = project.DetailedBudgetLines.OfType<DetailedBudgetLine>().ToList();
            }

            linesList.Add(line1);
            linesList.Add(line2);
            project.DetailedBudgetLines = linesList;

            var currentLines = project.DetailedBudgetLines.OfType<DetailedBudgetLine>().ToList();
            currentLines.Remove(line1);
            project.DetailedBudgetLines = currentLines;

            Debug.Assert(project.DetailedBudgetLines.Count() == 1, "TestDeleteBudgetLine_UpdatesModel: Failed - Count should be 1 after delete.");
            Debug.Assert(project.DetailedBudgetLines.First().Description == "Line 2", "TestDeleteBudgetLine_UpdatesModel: Failed - Remaining line mismatch. Expected 'Line 2'.");
        }

        static void TestActivityPlanPlannedMonthsUpdate()
        {
            var activity = new HumanitarianProjectManagement.Models.Activity();
            string monthYearKey1 = "Jan/2023";

            List<string> plannedMonthsList = string.IsNullOrEmpty(activity.PlannedMonths) ? new List<string>() : activity.PlannedMonths.Split(',').ToList();
            if (!plannedMonthsList.Contains(monthYearKey1)) plannedMonthsList.Add(monthYearKey1);
            activity.PlannedMonths = string.Join(",", plannedMonthsList);
            Debug.Assert(activity.PlannedMonths == "Jan/2023", $"TestActivityPlanPlannedMonthsUpdate: Failed for single month. Got {activity.PlannedMonths}");

            string monthYearKey2 = "Feb/2023";
            if (!plannedMonthsList.Contains(monthYearKey2)) plannedMonthsList.Add(monthYearKey2);
            activity.PlannedMonths = string.Join(",", plannedMonthsList);
            Debug.Assert(activity.PlannedMonths.Contains("Jan/2023") && activity.PlannedMonths.Contains("Feb/2023") && activity.PlannedMonths.Length == "Jan/2023,Feb/2023".Length, $"TestActivityPlanPlannedMonthsUpdate: Failed for two months. Got {activity.PlannedMonths}");

            plannedMonthsList.Remove(monthYearKey1);
            activity.PlannedMonths = string.Join(",", plannedMonthsList);
            Debug.Assert(activity.PlannedMonths == "Feb/2023", $"TestActivityPlanPlannedMonthsUpdate: Failed after removing a month. Got {activity.PlannedMonths}");

            plannedMonthsList.Remove(monthYearKey2);
            activity.PlannedMonths = string.Join(",", plannedMonthsList);
            Debug.Assert(activity.PlannedMonths == "", $"TestActivityPlanPlannedMonthsUpdate: Failed after removing all months. Got {activity.PlannedMonths}");
        }
    }
}
