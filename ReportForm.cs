using System;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Collections.Generic;

namespace TaskManagementApp
{
    public partial class ReportForm : Form
    {
        private IMongoDatabase _db;
        private IMongoCollection<BsonDocument> _tasks;
        private IMongoCollection<BsonDocument> _reports;
        private IMongoCollection<BsonDocument> _users;
        private IMongoCollection<BsonDocument> _auditLogs;

        public ReportForm()
        {
            InitializeComponent();

            try
            {
                _db = MongoConnection.GetDatabase();
                _tasks = _db.GetCollection<BsonDocument>("Tasks");
                _reports = _db.GetCollection<BsonDocument>("Reports");
                _users = _db.GetCollection<BsonDocument>("Users");
                _auditLogs = _db.GetCollection<BsonDocument>("AuditLogs");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate all 4 aggregation reports
                string report1 = GenerateUserTaskSummary();
                string report2 = GenerateTaskProgressByStatus();
                string report3 = GenerateStepCompletionAnalysis();
                string report4 = GenerateOverdueTasksAlert();

                // Combine all reports
                StringBuilder fullReport = new StringBuilder();
                fullReport.AppendLine(report1);
                fullReport.AppendLine("\n\n");
                fullReport.AppendLine(report2);
                fullReport.AppendLine("\n\n");
                fullReport.AppendLine(report3);
                fullReport.AppendLine("\n\n");
                fullReport.AppendLine(report4);

                txtReport.Text = fullReport.ToString();

                SaveReport("All 4 Aggregation Reports", fullReport.ToString());
                LogAudit(LoginForm.LoggedInUserID, "Generate All Reports", "Generated all 4 aggregation pipeline reports");

                MessageBox.Show("All 4 aggregation reports generated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating reports: " + ex.Message);
            }
        }

        // ============================================
        // AGGREGATION 1: User Task Summary Report
        // ============================================
        private string GenerateUserTaskSummary()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            report.AppendLine("║         AGGREGATION 1: USER TASK SUMMARY REPORT                ║");
            report.AppendLine("║   Purpose: Show total tasks per user with completion status    ║");
            report.AppendLine("╚════════════════════════════════════════════════════════════════╝");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

            try
            {
                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$group", new BsonDocument
                    {
                        { "_id", "$UserID" },
                        { "TotalTasks", new BsonDocument("$sum", 1) },
                        { "CompletedTasks", new BsonDocument("$sum",
                            new BsonDocument("$cond", new BsonArray {
                                new BsonDocument("$eq", new BsonArray { "$TaskStatus", "Completed" }),
                                1, 0
                            })
                        )},
                        { "InProgressTasks", new BsonDocument("$sum",
                            new BsonDocument("$cond", new BsonArray {
                                new BsonDocument("$eq", new BsonArray { "$TaskStatus", "In-Progress" }),
                                1, 0
                            })
                        )},
                        { "PendingTasks", new BsonDocument("$sum",
                            new BsonDocument("$cond", new BsonArray {
                                new BsonDocument("$eq", new BsonArray { "$TaskStatus", "Pending" }),
                                1, 0
                            })
                        )}
                    }),
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "Users" },
                        { "localField", "_id" },
                        { "foreignField", "_id" },
                        { "as", "UserInfo" }
                    }),
                    new BsonDocument("$unwind", "$UserInfo"),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "_id", 0 },
                        { "Username", "$UserInfo.Username" },
                        { "TotalTasks", 1 },
                        { "CompletedTasks", 1 },
                        { "InProgressTasks", 1 },
                        { "PendingTasks", 1 },
                        { "CompletionRate", new BsonDocument("$round", new BsonArray {
                            new BsonDocument("$multiply", new BsonArray {
                                new BsonDocument("$divide", new BsonArray { "$CompletedTasks", "$TotalTasks" }),
                                100
                            }),
                            2
                        })}
                    }),
                    new BsonDocument("$sort", new BsonDocument("CompletionRate", -1))
                };

                var results = _tasks.Aggregate<BsonDocument>(pipeline).ToList();

                report.AppendLine("USER PERFORMANCE METRICS:");
                report.AppendLine("────────────────────────────────────────────────────────────────");
                report.AppendLine($"{"Username",-20} {"Total",-8} {"Done",-8} {"Progress",-10} {"Pending",-10} {"Rate %",-8}");
                report.AppendLine("────────────────────────────────────────────────────────────────");

                foreach (var result in results)
                {
                    string username = result.GetValue("Username", "N/A").ToString();
                    int total = result.GetValue("TotalTasks", 0).AsInt32;
                    int completed = result.GetValue("CompletedTasks", 0).AsInt32;
                    int inProgress = result.GetValue("InProgressTasks", 0).AsInt32;
                    int pending = result.GetValue("PendingTasks", 0).AsInt32;
                    double rate = result.GetValue("CompletionRate", 0).AsDouble;

                    report.AppendLine($"{username,-20} {total,-8} {completed,-8} {inProgress,-10} {pending,-10} {rate,-8:F2}%");
                }

                report.AppendLine("────────────────────────────────────────────────────────────────");
            }
            catch (Exception ex)
            {
                report.AppendLine($"ERROR: {ex.Message}");
            }

            return report.ToString();
        }

        // ============================================
        // AGGREGATION 2: Task Progress by Status
        // ============================================
        private string GenerateTaskProgressByStatus()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            report.AppendLine("║      AGGREGATION 2: TASK PROGRESS BY STATUS REPORT             ║");
            report.AppendLine("║   Purpose: Overview of all tasks grouped by status dashboard   ║");
            report.AppendLine("╚════════════════════════════════════════════════════════════════╝");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

            try
            {
                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$group", new BsonDocument
                    {
                        { "_id", "$TaskStatus" },
                        { "Count", new BsonDocument("$sum", 1) },
                        { "Tasks", new BsonDocument("$push", new BsonDocument
                        {
                            { "TaskID", "$TaskID" },
                            { "Title", "$Title" },
                            { "UserID", "$UserID" },
                            { "DueDate", "$DueDate" }
                        })}
                    }),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "_id", 0 },
                        { "Status", "$_id" },
                        { "TaskCount", "$Count" },
                        { "Tasks", "$Tasks" }
                    }),
                    new BsonDocument("$sort", new BsonDocument("Status", 1))
                };

                var results = _tasks.Aggregate<BsonDocument>(pipeline).ToList();

                int totalTasks = results.Sum(r => r.GetValue("TaskCount", 0).AsInt32);
                report.AppendLine($"TOTAL TASKS: {totalTasks}");
                report.AppendLine("────────────────────────────────────────────────────────────────\n");

                foreach (var result in results)
                {
                    string status = result.GetValue("Status", "Unknown").ToString();
                    int count = result.GetValue("TaskCount", 0).AsInt32;

                    report.AppendLine($"[{status}] - {count} Task(s)");
                    report.AppendLine("───────────────────────────────────────────────────────────────");

                    var tasks = result["Tasks"].AsBsonArray;
                    foreach (var task in tasks)
                    {
                        string taskID = task.AsBsonDocument.GetValue("TaskID", "N/A").ToString();
                        string title = task.AsBsonDocument.GetValue("Title", "N/A").ToString();
                        report.AppendLine($"  • {taskID}: {title}");
                    }

                    report.AppendLine();
                }

                report.AppendLine("────────────────────────────────────────────────────────────────");
            }
            catch (Exception ex)
            {
                report.AppendLine($"ERROR: {ex.Message}");
            }

            return report.ToString();
        }

        // ============================================
        // AGGREGATION 3: Step Completion Analysis
        // ============================================
        private string GenerateStepCompletionAnalysis()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            report.AppendLine("║      AGGREGATION 3: STEP COMPLETION ANALYSIS REPORT            ║");
            report.AppendLine("║   Purpose: Identify which steps are blocking progress          ║");
            report.AppendLine("╚════════════════════════════════════════════════════════════════╝");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

            try
            {
                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$match", new BsonDocument("TaskStatus", new BsonDocument("$ne", "Completed"))),
                    new BsonDocument("$unwind", "$Steps"),
                    new BsonDocument("$group", new BsonDocument
                    {
                        { "_id", new BsonDocument
                        {
                            { "StepDescription", "$Steps.StepDescription" },
                            { "StepStatus", "$Steps.StepStatus" }
                        }},
                        { "OccurrenceCount", new BsonDocument("$sum", 1) },
                        { "TasksAffected", new BsonDocument("$push", new BsonDocument
                        {
                            { "TaskID", "$TaskID" },
                            { "TaskTitle", "$Title" }
                        })}
                    }),
                    new BsonDocument("$match", new BsonDocument("_id.StepStatus", "Pending")),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "_id", 0 },
                        { "StepDescription", "$_id.StepDescription" },
                        { "PendingCount", "$OccurrenceCount" },
                        { "BlockingTasks", "$TasksAffected" }
                    }),
                    new BsonDocument("$sort", new BsonDocument("PendingCount", -1))
                };

                var results = _tasks.Aggregate<BsonDocument>(pipeline).ToList();

                if (results.Count == 0)
                {
                    report.AppendLine("✓ No blocking steps found! All pending tasks are progressing.");
                }
                else
                {
                    report.AppendLine("BLOCKING STEPS (Preventing Task Completion):");
                    report.AppendLine("────────────────────────────────────────────────────────────────\n");

                    int blockageIndex = 1;
                    foreach (var result in results)
                    {
                        string stepDesc = result.GetValue("StepDescription", "N/A").ToString();
                        int count = result.GetValue("PendingCount", 0).AsInt32;

                        report.AppendLine($"{blockageIndex}. STEP: {stepDesc}");
                        report.AppendLine($"   Blocking: {count} task(s)");
                        report.AppendLine("   Affected Tasks:");

                        var tasks = result["BlockingTasks"].AsBsonArray;
                        foreach (var task in tasks)
                        {
                            string taskID = task.AsBsonDocument.GetValue("TaskID", "N/A").ToString();
                            string title = task.AsBsonDocument.GetValue("TaskTitle", "N/A").ToString();
                            report.AppendLine($"     - {taskID}: {title}");
                        }

                        report.AppendLine();
                        blockageIndex++;
                    }
                }

                report.AppendLine("────────────────────────────────────────────────────────────────");
            }
            catch (Exception ex)
            {
                report.AppendLine($"ERROR: {ex.Message}");
            }

            return report.ToString();
        }

        // ============================================
        // AGGREGATION 4: Overdue Tasks Alert
        // ============================================
        private string GenerateOverdueTasksAlert()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            report.AppendLine("║        AGGREGATION 4: OVERDUE TASKS ALERT REPORT              ║");
            report.AppendLine("║   Purpose: Identify tasks that are overdue or due soon         ║");
            report.AppendLine("╚════════════════════════════════════════════════════════════════╝");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

            try
            {
                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$match", new BsonDocument
                    {
                        { "TaskStatus", new BsonDocument("$ne", "Completed") },
                        { "DueDate", new BsonDocument("$exists", true) }
                    }),
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "Users" },
                        { "localField", "UserID" },
                        { "foreignField", "_id" },
                        { "as", "AssignedTo" }
                    }),
                    new BsonDocument("$unwind", "$AssignedTo"),
                    new BsonDocument("$addFields", new BsonDocument
                    {
                        { "DaysUntilDue", new BsonDocument("$divide", new BsonArray {
                            new BsonDocument("$subtract", new BsonArray { "$DueDate", new BsonDateTime(DateTime.UtcNow) }),
                            86400000
                        })},
                        { "OverdueStatus", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$lt", new BsonArray { "$DueDate", new BsonDateTime(DateTime.UtcNow) }),
                            "OVERDUE",
                            new BsonDocument("$cond", new BsonArray {
                                new BsonDocument("$lte", new BsonArray {
                                    new BsonDocument("$divide", new BsonArray {
                                        new BsonDocument("$subtract", new BsonArray { "$DueDate", new BsonDateTime(DateTime.UtcNow) }),
                                        86400000
                                    }),
                                    3
                                }),
                                "DUE_SOON",
                                "OK"
                            })
                        })}
                    }),
                    new BsonDocument("$match", new BsonDocument("OverdueStatus", new BsonDocument("$in", new BsonArray { "OVERDUE", "DUE_SOON" }))),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "_id", 0 },
                        { "TaskID", 1 },
                        { "Title", 1 },
                        { "AssignedTo", "$AssignedTo.Username" },
                        { "TaskStatus", 1 },
                        { "DueDate", new BsonDocument("$dateToString", new BsonDocument
                        {
                            { "format", "%Y-%m-%d" },
                            { "date", "$DueDate" }
                        })},
                        { "DaysUntilDue", new BsonDocument("$round", new BsonArray { "$DaysUntilDue", 0 }) },
                        { "Alert", "$OverdueStatus" }
                    }),
                    new BsonDocument("$sort", new BsonDocument("DaysUntilDue", 1))
                };

                var results = _tasks.Aggregate<BsonDocument>(pipeline).ToList();

                if (results.Count == 0)
                {
                    report.AppendLine("✓ Great! No overdue or soon-due tasks found.");
                }
                else
                {
                    int overdueCount = results.Count(r => r.GetValue("Alert", "").ToString() == "OVERDUE");
                    int dueSoonCount = results.Count(r => r.GetValue("Alert", "").ToString() == "DUE_SOON");

                    report.AppendLine($"⚠ ALERTS: {overdueCount} OVERDUE | {dueSoonCount} DUE SOON");
                    report.AppendLine("────────────────────────────────────────────────────────────────\n");

                    foreach (var result in results)
                    {
                        string alert = result.GetValue("Alert", "").ToString();
                        string alertIcon = alert == "OVERDUE" ? "🔴" : "🟡";
                        string taskID = result.GetValue("TaskID", "N/A").ToString();
                        string title = result.GetValue("Title", "N/A").ToString();
                        string assignedTo = result.GetValue("AssignedTo", "N/A").ToString();
                        string dueDate = result.GetValue("DueDate", "N/A").ToString();

                        // Handle both Int64 and Double types
                        long daysUntil = 0;
                        var daysValue = result.GetValue("DaysUntilDue", 0);
                        if (daysValue.IsInt64)
                            daysUntil = daysValue.AsInt64;
                        else if (daysValue.IsDouble)
                            daysUntil = (long)daysValue.AsDouble;

                        report.AppendLine($"{alertIcon} [{alert}] {taskID}: {title}");
                        report.AppendLine($"   Assigned to: {assignedTo}");
                        report.AppendLine($"   Due Date: {dueDate} ({daysUntil} days)");
                        report.AppendLine();
                    }
                }

                report.AppendLine("────────────────────────────────────────────────────────────────");
            }
            catch (Exception ex)
            {
                report.AppendLine($"ERROR: {ex.Message}");
            }

            return report.ToString();
        }

        // ============================================
        // AGGREGATION 5: Team Performance Scorecard
        // ============================================
        private string GenerateTeamPerformanceScorecard()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            report.AppendLine("║      AGGREGATION 5: TEAM PERFORMANCE SCORECARD                ║");
            report.AppendLine("║   Purpose: Rank users by efficiency and productivity metrics  ║");
            report.AppendLine("╚════════════════════════════════════════════════════════════════╝");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

            try
            {
                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "Users" },
                        { "localField", "UserID" },
                        { "foreignField", "_id" },
                        { "as", "UserInfo" }
                    }),
                    new BsonDocument("$unwind", "$UserInfo"),
                    new BsonDocument("$group", new BsonDocument
                    {
                        { "_id", new BsonDocument
                        {
                            { "UserID", "$UserID" },
                            { "Username", "$UserInfo.Username" },
                            { "Role", "$UserInfo.Role" }
                        }},
                        { "TotalTasksAssigned", new BsonDocument("$sum", 1) },
                        { "CompletedCount", new BsonDocument("$sum",
                            new BsonDocument("$cond", new BsonArray {
                                new BsonDocument("$eq", new BsonArray { "$TaskStatus", "Completed" }), 1, 0
                            })
                        )},
                        { "TotalStepsCreated", new BsonDocument("$sum",
                            new BsonDocument("$cond", new BsonArray {
                                new BsonDocument("$isArray", "$Steps"),
                                new BsonDocument("$size", "$Steps"), 0
                            })
                        )},
                        { "StepsCompleted", new BsonDocument("$sum",
                            new BsonDocument("$cond", new BsonArray {
                                new BsonDocument("$isArray", "$Steps"),
                                new BsonDocument("$size", new BsonDocument("$filter", new BsonDocument
                                {
                                    { "input", "$Steps" },
                                    { "as", "step" },
                                    { "cond", new BsonDocument("$eq", new BsonArray { "$$step.StepStatus", "Completed" }) }
                                })),
                                0
                            })
                        )}
                    }),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "_id", 0 },
                        { "Username", "$_id.Username" },
                        { "Role", "$_id.Role" },
                        { "TotalTasks", "$TotalTasksAssigned" },
                        { "CompletedTasks", "$CompletedCount" },
                        { "TaskCompletionRate", new BsonDocument("$round", new BsonArray {
                            new BsonDocument("$multiply", new BsonArray {
                                new BsonDocument("$divide", new BsonArray { "$CompletedCount", "$TotalTasksAssigned" }),
                                100
                            }),
                            2
                        })},
                        { "StepsCompleted", 1 },
                        { "StepsAssigned", "$TotalStepsCreated" },
                        { "StepCompletionRate", new BsonDocument("$round", new BsonArray {
                            new BsonDocument("$multiply", new BsonArray {
                                new BsonDocument("$divide", new BsonArray { "$StepsCompleted", new BsonDocument("$max", new BsonArray { "$TotalStepsCreated", 1 }) }),
                                100
                            }),
                            2
                        })},
                        { "PerformanceScore", new BsonDocument("$round", new BsonArray {
                            new BsonDocument("$add", new BsonArray {
                                new BsonDocument("$multiply", new BsonArray { new BsonDocument("$divide", new BsonArray { "$CompletedCount", "$TotalTasksAssigned" }), 50 }),
                                new BsonDocument("$multiply", new BsonArray { new BsonDocument("$divide", new BsonArray { "$StepsCompleted", new BsonDocument("$max", new BsonArray { "$TotalStepsCreated", 1 }) }), 50 })
                            }),
                            2
                        })}
                    }),
                    new BsonDocument("$sort", new BsonDocument("PerformanceScore", -1))
                };

                var results = _tasks.Aggregate<BsonDocument>(pipeline).ToList();

                report.AppendLine("PERFORMANCE RANKINGS:");
                report.AppendLine("────────────────────────────────────────────────────────────────");
                report.AppendLine($"{"Rank",-6} {"Username",-18} {"Tasks",-8} {"Steps",-8} {"Task%",-8} {"Step%",-8} {"Score",-8}");
                report.AppendLine("────────────────────────────────────────────────────────────────");

                int rank = 1;
                foreach (var result in results)
                {
                    string username = result.GetValue("Username", "N/A").ToString();
                    int tasks = result.GetValue("CompletedTasks", 0).AsInt32;
                    int steps = result.GetValue("StepsCompleted", 0).AsInt32;
                    double taskRate = result.GetValue("TaskCompletionRate", 0).AsDouble;
                    double stepRate = result.GetValue("StepCompletionRate", 0).AsDouble;
                    double score = result.GetValue("PerformanceScore", 0).AsDouble;

                    report.AppendLine($"{rank,-6} {username,-18} {tasks,-8} {steps,-8} {taskRate,-8:F1}% {stepRate,-8:F1}% {score,-8:F2}");
                    rank++;
                }

                report.AppendLine("────────────────────────────────────────────────────────────────");
            }
            catch (Exception ex)
            {
                report.AppendLine($"ERROR: {ex.Message}");
            }

            return report.ToString();
        }

        // ============================================
        // AGGREGATION 6: Task Details with User Context
        // ============================================
        private string GenerateTaskDetailsWithUserContext()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            report.AppendLine("║   AGGREGATION 6: TASK DETAILS WITH USER CONTEXT               ║");
            report.AppendLine("║   Purpose: Comprehensive task view with assignee info         ║");
            report.AppendLine("╚════════════════════════════════════════════════════════════════╝");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

            try
            {
                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "Users" },
                        { "localField", "UserID" },
                        { "foreignField", "_id" },
                        { "as", "AssigneeInfo" }
                    }),
                    new BsonDocument("$unwind", "$AssigneeInfo"),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "_id", 0 },
                        { "TaskID", 1 },
                        { "Title", 1 },
                        { "Description", 1 },
                        { "Status", "$TaskStatus" },
                        { "AssignedTo", "$AssigneeInfo.Username" },
                        { "Role", "$AssigneeInfo.Role" },
                        { "CreatedDate", new BsonDocument("$dateToString", new BsonDocument
                        {
                            { "format", "%Y-%m-%d" },
                            { "date", "$CreatedDate" }
                        })},
                        { "DueDate", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$ne", new BsonArray { "$DueDate", null }),
                            new BsonDocument("$dateToString", new BsonDocument
                            {
                                { "format", "%Y-%m-%d" },
                                { "date", "$DueDate" }
                            }),
                            "No Due Date"
                        })},
                        { "TotalSteps", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$isArray", "$Steps"),
                            new BsonDocument("$size", "$Steps"), 0
                        })},
                        { "CompletedSteps", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$isArray", "$Steps"),
                            new BsonDocument("$size", new BsonDocument("$filter", new BsonDocument
                            {
                                { "input", "$Steps" },
                                { "as", "step" },
                                { "cond", new BsonDocument("$eq", new BsonArray { "$$step.StepStatus", "Completed" }) }
                            })),
                            0
                        })},
                        { "SignedOffSteps", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$isArray", "$Steps"),
                            new BsonDocument("$size", new BsonDocument("$filter", new BsonDocument
                            {
                                { "input", "$Steps" },
                                { "as", "step" },
                                { "cond", new BsonDocument("$eq", new BsonArray { "$$step.SignedOff.Status", "Signed" }) }
                            })),
                            0
                        })},
                        { "ProgressPercentage", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$eq", new BsonArray { new BsonDocument("$size", "$Steps"), 0 }),
                            0,
                            new BsonDocument("$round", new BsonArray {
                                new BsonDocument("$multiply", new BsonArray {
                                    new BsonDocument("$divide", new BsonArray {
                                        new BsonDocument("$size", new BsonDocument("$filter", new BsonDocument
                                        {
                                            { "input", "$Steps" },
                                            { "as", "step" },
                                            { "cond", new BsonDocument("$eq", new BsonArray { "$step.StepStatus", "Completed" }) }
                                        })),
                                        new BsonDocument("$size", "$Steps")
                                    }),
                                    100
                                }),
                                0
                            })
                        })}
                    }),
                    new BsonDocument("$sort", new BsonDocument("Status", 1))
                };

                var results = _tasks.Aggregate<BsonDocument>(pipeline).ToList();

                report.AppendLine("COMPREHENSIVE TASK LIST:");
                report.AppendLine("────────────────────────────────────────────────────────────────");

                foreach (var result in results)
                {
                    string taskID = result.GetValue("TaskID", "N/A").ToString();
                    string title = result.GetValue("Title", "N/A").ToString();
                    string desc = result.GetValue("Description", "N/A").ToString();
                    string status = result.GetValue("Status", "N/A").ToString();
                    string assignedTo = result.GetValue("AssignedTo", "N/A").ToString();
                    string created = result.GetValue("CreatedDate", "N/A").ToString();
                    string dueDate = result.GetValue("DueDate", "N/A").ToString();
                    int completed = result.GetValue("CompletedSteps", 0).AsInt32;
                    int total = result.GetValue("TotalSteps", 0).AsInt32;
                    int progress = result.GetValue("ProgressPercentage", 0).AsInt32;

                    report.AppendLine($"Task ID: {taskID}");
                    report.AppendLine($"Title: {title}");
                    report.AppendLine($"Description: {desc}");
                    report.AppendLine($"Status: {status}");
                    report.AppendLine($"Assigned to: {assignedTo}");
                    report.AppendLine($"Created: {created} | Due: {dueDate}");
                    report.AppendLine($"Progress: {completed}/{total} steps completed ({progress}%)");
                    report.AppendLine();
                }

                report.AppendLine("────────────────────────────────────────────────────────────────");
            }
            catch (Exception ex)
            {
                report.AppendLine($"ERROR: {ex.Message}");
            }

            return report.ToString();
        }

        // ============================================
        // AGGREGATION 7: Critical Path Analysis
        // ============================================
        private string GenerateCriticalPathAnalysis()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            report.AppendLine("║       AGGREGATION 7: CRITICAL PATH ANALYSIS                   ║");
            report.AppendLine("║   Purpose: Identify blocked and bottleneck tasks              ║");
            report.AppendLine("╚════════════════════════════════════════════════════════════════╝");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

            try
            {
                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$match", new BsonDocument("TaskStatus", new BsonDocument("$ne", "Completed"))),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "TaskID", 1 },
                        { "Title", 1 },
                        { "TaskStatus", 1 },
                        { "Steps", 1 },
                        { "StepCount", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$isArray", "$Steps"),
                            new BsonDocument("$size", "$Steps"), 0
                        })},
                        { "PendingStepCount", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$isArray", "$Steps"),
                            new BsonDocument("$size", new BsonDocument("$filter", new BsonDocument
                            {
                                { "input", "$Steps" },
                                { "as", "step" },
                                { "cond", new BsonDocument("$eq", new BsonArray { "$step.StepStatus", "Pending" }) }
                            })),
                            0
                        })},
                        { "BlockedStepCount", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$isArray", "$Steps"),
                            new BsonDocument("$size", new BsonDocument("$filter", new BsonDocument
                            {
                                { "input", "$Steps" },
                                { "as", "step" },
                                { "cond", new BsonDocument("$and", new BsonArray {
                                    new BsonDocument("$eq", new BsonArray { "$step.StepStatus", "Pending" }),
                                    new BsonDocument("$ne", new BsonArray { "$step.SignedOff.Status", "Signed" })
                                })}
                            })),
                            0
                        })}
                    }),
                    new BsonDocument("$addFields", new BsonDocument
                    {
                        { "PathComplexity", new BsonDocument("$round", new BsonArray {
                            new BsonDocument("$multiply", new BsonArray {
                                new BsonDocument("$divide", new BsonArray { "$PendingStepCount", new BsonDocument("$max", new BsonArray { "$StepCount", 1 }) }),
                                100
                            }),
                            0
                        })},
                        { "BlockageLevel", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$gt", new BsonArray { "$BlockedStepCount", 0 }),
                            "BLOCKED",
                            new BsonDocument("$cond", new BsonArray {
                                new BsonDocument("$gt", new BsonArray { "$PendingStepCount", 0 }),
                                "IN_PROGRESS",
                                "CLEAR"
                            })
                        })}
                    }),
                    new BsonDocument("$match", new BsonDocument("BlockageLevel", new BsonDocument("$in", new BsonArray { "BLOCKED", "IN_PROGRESS" }))),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "_id", 0 },
                        { "TaskID", 1 },
                        { "Title", 1 },
                        { "Status", "$TaskStatus" },
                        { "TotalSteps", "$StepCount" },
                        { "PendingSteps", 1 },
                        { "BlockedSteps", 1 },
                        { "PathComplexity", 1 },
                        { "BlockageLevel", 1 }
                    }),
                    new BsonDocument("$sort", new BsonDocument("BlockedStepCount", -1))
                };

                var results = _tasks.Aggregate<BsonDocument>(pipeline).ToList();

                if (results.Count == 0)
                {
                    report.AppendLine("✓ No critical path issues detected!");
                }
                else
                {
                    report.AppendLine("CRITICAL TASKS NEEDING ATTENTION:");
                    report.AppendLine("────────────────────────────────────────────────────────────────\n");

                    foreach (var result in results)
                    {
                        string taskID = result.GetValue("TaskID", "N/A").ToString();
                        string title = result.GetValue("Title", "N/A").ToString();
                        string status = result.GetValue("Status", "N/A").ToString();
                        int blocked = result.GetValue("BlockedSteps", 0).AsInt32;
                        int pending = result.GetValue("PendingSteps", 0).AsInt32;
                        int complexity = result.GetValue("PathComplexity", 0).AsInt32;
                        string level = result.GetValue("BlockageLevel", "N/A").ToString();

                        string icon = level == "BLOCKED" ? "🔴" : "🟡";
                        report.AppendLine($"{icon} {taskID}: {title}");
                        report.AppendLine($"   Status: {status}");
                        report.AppendLine($"   Blocked: {blocked} steps | Pending: {pending} steps");
                        report.AppendLine($"   Complexity: {complexity}% | Level: {level}");
                        report.AppendLine();
                    }
                }

                report.AppendLine("────────────────────────────────────────────────────────────────");
            }
            catch (Exception ex)
            {
                report.AppendLine($"ERROR: {ex.Message}");
            }

            return report.ToString();
        }

        // ============================================
        // AGGREGATION 8: Task History & Activity Log
        // ============================================
        private string GenerateTaskHistoryActivityLog()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            report.AppendLine("║     AGGREGATION 8: TASK HISTORY & ACTIVITY LOG                ║");
            report.AppendLine("║   Purpose: Track task lifecycle and recent activities         ║");
            report.AppendLine("╚════════════════════════════════════════════════════════════════╝");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

            try
            {
                var pipeline = new BsonDocument[]
                {
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "Users" },
                        { "localField", "UserID" },
                        { "foreignField", "_id" },
                        { "as", "UserInfo" }
                    }),
                    new BsonDocument("$unwind", "$UserInfo"),
                    new BsonDocument("$project", new BsonDocument
                    {
                        { "_id", 0 },
                        { "TaskID", 1 },
                        { "TaskTitle", "$Title" },
                        { "AssignedTo", "$UserInfo.Username" },
                        { "CurrentStatus", "$TaskStatus" },
                        { "CreatedDate", new BsonDocument("$dateToString", new BsonDocument
                        {
                            { "format", "%Y-%m-%d %H:%M" },
                            { "date", "$CreatedDate" }
                        })},
                        { "DaysActive", new BsonDocument("$round", new BsonArray {
                            new BsonDocument("$divide", new BsonArray {
                                new BsonDocument("$subtract", new BsonArray { new BsonDateTime(DateTime.UtcNow), "$CreatedDate" }),
                                86400000
                            }),
                            1
                        })},
                        { "TotalStepsProcessed", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$isArray", "$Steps"),
                            new BsonDocument("$size", "$Steps"), 0
                        })},
                        { "StepsCompleted", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$isArray", "$Steps"),
                            new BsonDocument("$size", new BsonDocument("$filter", new BsonDocument
                            {
                                { "input", "$Steps" },
                                { "as", "step" },
                                { "cond", new BsonDocument("$eq", new BsonArray { "$step.StepStatus", "Completed" }) }
                            })),
                            0
                        })},
                        { "ActivityLevel", new BsonDocument("$cond", new BsonArray {
                            new BsonDocument("$gt", new BsonArray {
                                new BsonDocument("$cond", new BsonArray {
                                    new BsonDocument("$isArray", "$Steps"),
                                    new BsonDocument("$size", new BsonDocument("$filter", new BsonDocument
                                    {
                                        { "input", "$Steps" },
                                        { "as", "step" },
                                        { "cond", new BsonDocument("$eq", new BsonArray { "$step.StepStatus", "Completed" }) }
                                    })),
                                    0
                                }),
                                0
                            }),
                            "ACTIVE",
                            "IDLE"
                        })}
                    }),
                    new BsonDocument("$sort", new BsonDocument("CreatedDate", -1))
                };

                var results = _tasks.Aggregate<BsonDocument>(pipeline).ToList();

                report.AppendLine("TASK ACTIVITY LOG:");
                report.AppendLine("────────────────────────────────────────────────────────────────");
                report.AppendLine($"{"TaskID",-10} {"Status",-12} {"Days Active",-12} {"Steps",-12} {"Activity",-10}");
                report.AppendLine("────────────────────────────────────────────────────────────────");

                foreach (var result in results)
                {
                    string taskID = result.GetValue("TaskID", "N/A").ToString();
                    string status = result.GetValue("CurrentStatus", "N/A").ToString();
                    double daysActive = result.GetValue("DaysActive", 0).AsDouble;
                    int totalSteps = result.GetValue("TotalStepsProcessed", 0).AsInt32;
                    int completed = result.GetValue("StepsCompleted", 0).AsInt32;
                    string activity = result.GetValue("ActivityLevel", "N/A").ToString();

                    report.AppendLine($"{taskID,-10} {status,-12} {daysActive,-12:F1} {completed}/{totalSteps,-9} {activity,-10}");
                }

                report.AppendLine("────────────────────────────────────────────────────────────────");
                report.AppendLine($"\nTotal Tasks Tracked: {results.Count}");
            }
            catch (Exception ex)
            {
                report.AppendLine($"ERROR: {ex.Message}");
            }

            return report.ToString();
        }

        private void SaveReport(string userFilter, string reportContent)
        {
            try
            {
                var report = new BsonDocument
                {
                    { "ReportID", "RPT" + DateTime.Now.ToString("yyyyMMddHHmmss") },
                    { "ReportType", "Aggregation Pipelines" },
                    { "UserFilter", userFilter },
                    { "ReportContent", reportContent },
                    { "GeneratedDate", DateTime.Now }
                };

                _reports.InsertOne(report);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving report: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReport.Text))
            {
                MessageBox.Show("Please generate a report first.");
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text Files (*.txt)|*.txt";
                saveDialog.FileName = $"AggregationReport_{DateTime.Now:yyyyMMddHHmmss}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveDialog.FileName, txtReport.Text);
                    MessageBox.Show("Report exported successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting report: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogAudit(string userID, string action, string details)
        {
            try
            {
                var log = new BsonDocument
                {
                    { "LogID", Guid.NewGuid().ToString() },
                    { "UserID", userID },
                    { "Action", action },
                    { "Details", details },
                    { "Timestamp", DateTime.UtcNow }
                };

                _auditLogs.InsertOne(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit log error: " + ex.Message);
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}