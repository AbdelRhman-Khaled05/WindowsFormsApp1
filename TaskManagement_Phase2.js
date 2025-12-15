// ========================================
// Task Management System - MongoDB Script
// Phase 2 Requirements - CORRECTED
// For MongoDB Atlas
// ========================================

// 1. USE YOUR EXISTING DATABASE
use TaskManagmentDB;

print("=== Connected to Database: TaskManagmentDB ===\n");

// 2. Check existing collections
print("=== Current Collections ===");
show collections;
print("\n");

// ========================================
// 3. INSERT OPERATIONS (10+ documents)
// ========================================

print("=== INSERTING SAMPLE USERS (Phase 2 Data) ===");

// Get existing user IDs to use for foreign keys
var existingUsers = db.Users.find().toArray();
var userMap = {};
existingUsers.forEach(function (user) {
    userMap[user.UserID] = user._id;
});

// Insert Phase 2 sample users
db.Users.insertMany([
    {
        UserID: "USR009",
        Username: "emily_johnson",
        Password: "emily123",
        Role: "Agent"
    },
    {
        UserID: "USR010",
        Username: "david_lee",
        Password: "david123",
        Role: "Manager"
    },
    {
        UserID: "USR011",
        Username: "lisa_martinez",
        Password: "lisa123",
        Role: "Supervisor"
    }
]);

print("✓ 3 additional users inserted for Phase 2\n");

// Fetch new user IDs
var U7 = db.Users.findOne({ UserID: "USR009" })._id;
var U8 = db.Users.findOne({ UserID: "USR010" })._id;
var U9 = db.Users.findOne({ UserID: "USR011" })._id;

print("=== INSERTING SAMPLE TASKS (Phase 2 Data) ===");

// Insert Phase 2 sample tasks with correct format
db.Tasks.insertMany([
    {
        TaskID: "TASK007",
        UserID: U7,
        Title: "Database Backup and Maintenance",
        Description: "Perform weekly database backup and optimize queries",
        TaskStatus: "In-Progress",
        CreatedDate: new Date(),
        DueDate: new Date("2025-01-20"),
        Steps: [
            {
                StepID: "STEP017",
                StepDescription: "Create full database backup",
                StepStatus: "Completed",
                SignedOff: { Status: "Signed", Date: new Date() }
            },
            {
                StepID: "STEP018",
                StepDescription: "Analyze slow queries",
                StepStatus: "In-Progress",
                SignedOff: { Status: "Not-Signed", Date: new Date() }
            },
            {
                StepID: "STEP019",
                StepDescription: "Implement query optimizations",
                StepStatus: "Pending",
                SignedOff: { Status: "Not-Signed", Date: new Date() }
            }
        ]
    },
    {
        TaskID: "TASK008",
        UserID: U8,
        Title: "Quarterly Budget Planning",
        Description: "Prepare budget forecast for Q1 2025",
        TaskStatus: "Pending",
        CreatedDate: new Date(),
        DueDate: new Date("2025-02-01"),
        Steps: [
            {
                StepID: "STEP020",
                StepDescription: "Gather department budget requests",
                StepStatus: "Pending",
                SignedOff: { Status: "Not-Signed", Date: new Date() }
            },
            {
                StepID: "STEP021",
                StepDescription: "Review historical spending",
                StepStatus: "Pending",
                SignedOff: { Status: "Not-Signed", Date: new Date() }
            },
            {
                StepID: "STEP022",
                StepDescription: "Create budget proposal",
                StepStatus: "Pending",
                SignedOff: { Status: "Not-Signed", Date: new Date() }
            }
        ]
    },
    {
        TaskID: "TASK009",
        UserID: U9,
        Title: "Employee Training Session",
        Description: "Conduct training on new software tools",
        TaskStatus: "Completed",
        CreatedDate: new Date(),
        DueDate: new Date("2025-01-10"),
        Steps: [
            {
                StepID: "STEP023",
                StepDescription: "Prepare training materials",
                StepStatus: "Completed",
                SignedOff: { Status: "Signed", Date: new Date() }
            },
            {
                StepID: "STEP024",
                StepDescription: "Schedule training sessions",
                StepStatus: "Completed",
                SignedOff: { Status: "Signed", Date: new Date() }
            },
            {
                StepID: "STEP025",
                StepDescription: "Conduct training and collect feedback",
                StepStatus: "Completed",
                SignedOff: { Status: "Signed", Date: new Date() }
            }
        ]
    },
    {
        TaskID: "TASK010",
        UserID: U7,
        Title: "Security Audit",
        Description: "Review system security and update policies",
        TaskStatus: "In-Progress",
        CreatedDate: new Date(),
        DueDate: new Date("2025-01-30"),
        Steps: [
            {
                StepID: "STEP026",
                StepDescription: "Run security vulnerability scan",
                StepStatus: "Completed",
                SignedOff: { Status: "Signed", Date: new Date() }
            },
            {
                StepID: "STEP027",
                StepDescription: "Review access permissions",
                StepStatus: "In-Progress",
                SignedOff: { Status: "Not-Signed", Date: new Date() }
            }
        ]
    }
]);

print("✓ 4 additional tasks inserted for Phase 2\n");

// ========================================
// 4. READ OPERATIONS
// ========================================

print("\n=== READ OPERATIONS ===\n");

print("--- Total Users in Database ---");
print("Count: " + db.Users.countDocuments());

print("\n--- Total Tasks in Database ---");
print("Count: " + db.Tasks.countDocuments());

print("\n--- Sample: First 3 Users ---");
db.Users.find().limit(3).pretty();

print("\n--- Sample: First 3 Tasks ---");
db.Tasks.find().limit(3).pretty();

print("\n--- Tasks with Status 'Completed' ---");
db.Tasks.find({ TaskStatus: "Completed" }).pretty();

print("\n--- Tasks assigned to Specific User ---");
db.Tasks.find({ UserID: U7 }).pretty();

// ========================================
// 5. UPDATE OPERATIONS
// ========================================

print("\n=== UPDATE OPERATIONS ===\n");

// Update user role
print("--- Updating user USR009 role to 'Senior Agent' ---");
db.Users.updateOne(
    { UserID: "USR009" },
    { $set: { Role: "Senior Agent" } }
);
print("✓ User updated successfully\n");

// Update task status
print("--- Updating TASK008 status to 'In-Progress' ---");
db.Tasks.updateOne(
    { TaskID: "TASK008" },
    { $set: { TaskStatus: "In-Progress" } }
);
print("✓ Task updated successfully\n");

// Update step status
print("--- Updating step status in TASK007 ---");
db.Tasks.updateOne(
    { TaskID: "TASK007", "Steps.StepID": "STEP018" },
    { $set: { "Steps.$.StepStatus": "Completed", "Steps.$.SignedOff": { Status: "Signed", Date: new Date() } } }
);
print("✓ Step updated successfully\n");

// Update multiple tasks (add due date)
print("--- Adding DueDate to pending tasks ---");
db.Tasks.updateMany(
    { TaskStatus: "Pending" },
    { $set: { DueDate: new Date("2025-01-15") } }
);
print("✓ Multiple tasks updated\n");

// ========================================
// 6. DELETE OPERATIONS
// ========================================

print("\n=== DELETE OPERATIONS ===\n");

// Insert a test task to delete
print("--- Inserting test task for deletion ---");
var testUser = db.Users.findOne({ UserID: "USR009" });
db.Tasks.insertOne({
    TaskID: "TASK_DELETE_TEST",
    UserID: testUser._id,
    Title: "Test Task - To Be Deleted",
    Description: "This task will be deleted",
    TaskStatus: "Pending",
    CreatedDate: new Date(),
    Steps: [
        {
            StepID: "TEMP_STEP",
            StepDescription: "Temporary step",
            StepStatus: "Pending",
            SignedOff: { Status: "Not-Signed", Date: new Date() }
        }
    ]
});
print("✓ Test task inserted\n");

// Delete the test task
print("--- Deleting the test task ---");
db.Tasks.deleteOne({ TaskID: "TASK_DELETE_TEST" });
print("✓ Task deleted successfully\n");

// ========================================
// 7. AGGREGATION PIPELINES (4 Required)
// ========================================

print("\n=== AGGREGATION PIPELINES - REPORTS ===\n");

// AGGREGATION 1: Tasks Summary by Status
print("╔════════════════════════════════════════════════╗");
print("║  REPORT 1: Tasks Summary by Status            ║");
print("╚════════════════════════════════════════════════╝\n");
db.Tasks.aggregate([
    {
        $group: {
            _id: "$TaskStatus",
            count: { $sum: 1 },
            taskTitles: { $push: "$Title" }
        }
    },
    {
        $sort: { count: -1 }
    },
    {
        $project: {
            _id: 0,
            Status: "$_id",
            TotalTasks: "$count",
            TaskTitles: "$taskTitles"
        }
    }
]).pretty();

// AGGREGATION 2: User Task Workload with Details
print("\n╔════════════════════════════════════════════════╗");
print("║  REPORT 2: User Workload Analysis             ║");
print("╚════════════════════════════════════════════════╝\n");
db.Tasks.aggregate([
    {
        $group: {
            _id: "$UserID",
            totalTasks: { $sum: 1 },
            completedTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "Completed"] }, 1, 0] }
            },
            inProgressTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "In-Progress"] }, 1, 0] }
            },
            pendingTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "Pending"] }, 1, 0] }
            }
        }
    },
    {
        $lookup: {
            from: "Users",
            localField: "_id",
            foreignField: "_id",
            as: "userInfo"
        }
    },
    {
        $unwind: "$userInfo"
    },
    {
        $project: {
            _id: 0,
            UserID: "$_id",
            Username: "$userInfo.Username",
            Role: "$userInfo.Role",
            TotalTasks: "$totalTasks",
            Completed: "$completedTasks",
            InProgress: "$inProgressTasks",
            Pending: "$pendingTasks",
            CompletionRate: {
                $round: [
                    { $multiply: [{ $divide: ["$completedTasks", "$totalTasks"] }, 100] },
                    2
                ]
            }
        }
    },
    {
        $sort: { TotalTasks: -1 }
    }
]).pretty();

// AGGREGATION 3: Step Completion Statistics
print("\n╔════════════════════════════════════════════════╗");
print("║  REPORT 3: Step Completion Analysis           ║");
print("╚════════════════════════════════════════════════╝\n");
db.Tasks.aggregate([
    {
        $unwind: "$Steps"
    },
    {
        $group: {
            _id: "$Steps.StepStatus",
            totalSteps: { $sum: 1 },
            sampleSteps: { $push: "$Steps.StepDescription" }
        }
    },
    {
        $project: {
            _id: 0,
            StepStatus: "$_id",
            TotalSteps: "$totalSteps",
            SampleDescriptions: { $slice: ["$sampleSteps", 3] }
        }
    },
    {
        $sort: { TotalSteps: -1 }
    }
]).pretty();

// AGGREGATION 4: Detailed Task Progress Report
print("\n╔════════════════════════════════════════════════╗");
print("║  REPORT 4: Task Progress with Completion %    ║");
print("╚════════════════════════════════════════════════╝\n");
db.Tasks.aggregate([
    {
        $project: {
            _id: 0,
            TaskID: 1,
            UserID: 1,
            Title: 1,
            TaskStatus: 1,
            TotalSteps: { $size: "$Steps" },
            CompletedSteps: {
                $size: {
                    $filter: {
                        input: "$Steps",
                        as: "step",
                        cond: { $eq: ["$$step.StepStatus", "Completed"] }
                    }
                }
            }
        }
    },
    {
        $addFields: {
            CompletionPercentage: {
                $round: [
                    {
                        $multiply: [
                            { $divide: ["$CompletedSteps", "$TotalSteps"] },
                            100
                        ]
                    },
                    1
                ]
            },
            ProgressStatus: {
                $cond: [
                    { $eq: ["$CompletedSteps", "$TotalSteps"] },
                    "✓ Complete",
                    { $cond: [{ $gt: ["$CompletedSteps", 0] }, "⏳ In Progress", "⊗ Not Started"] }
                ]
            }
        }
    },
    {
        $sort: { CompletionPercentage: -1 }
    }
]).pretty();

// ========================================
// 8. INDEXES
// ========================================

print("\n╔════════════════════════════════════════════════╗");
print("║  CREATING INDEXES                              ║");
print("╚════════════════════════════════════════════════╝\n");

// Index 1: UserID for faster task queries
print("--- Creating index on Tasks.UserID ---");
db.Tasks.createIndex({ UserID: 1 });
print("✓ Index created on UserID\n");

// Index 2: Compound index on TaskStatus and UserID
print("--- Creating compound index ---");
db.Tasks.createIndex({ TaskStatus: 1, UserID: 1 });
print("✓ Compound index created on TaskStatus + UserID\n");

// Index 3: Text index for searching
print("--- Creating text index for search ---");
db.Tasks.createIndex({ Title: "text", Description: "text" });
print("✓ Text index created for full-text search\n");

// Index 4: Unique index on Username
print("--- Creating unique index on Users.Username ---");
db.Users.createIndex({ Username: 1 }, { unique: true });
print("✓ Unique index created on Username\n");

// Index 5: DueDate index
print("--- Creating index on Tasks.DueDate ---");
db.Tasks.createIndex({ DueDate: 1 });
print("✓ Index created on DueDate\n");

// Show all indexes
print("\n--- All Indexes on 'Tasks' Collection ---");
printjson(db.Tasks.getIndexes());

print("\n--- All Indexes on 'Users' Collection ---");
printjson(db.Users.getIndexes());

// ========================================
// 9. FINAL SUMMARY
// ========================================

print("\n╔════════════════════════════════════════════════╗");
print("║  SCRIPT EXECUTION COMPLETED                    ║");
print("╚════════════════════════════════════════════════╝\n");

print("Database: TaskManagmentDB");
print("─────────────────────────────────────────────────");
print("Collections:");
print("  • Users: " + db.Users.countDocuments() + " documents");
print("  • Tasks: " + db.Tasks.countDocuments() + " documents");
print("  • AuditLogs: " + db.AuditLogs.countDocuments() + " documents");
print("\nIndexes Created: 5 total");
print("Aggregation Reports: 4 completed");
print("CRUD Operations: ✓ All tested");
print("\n✓ All Phase 2 Requirements Met!");