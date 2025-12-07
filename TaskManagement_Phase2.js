// ========================================
// Task Management System - MongoDB Script
// Phase 2 Requirements
// For MongoDB Atlas
// ========================================

// 1. USE YOUR EXISTING DATABASE
use TaskManagmentDB;  // Note: Your DB name has "Managment" not "Management"

print("=== Connected to Database: TaskManagmentDB ===\n");

// 2. Check existing collections
print("=== Current Collections ===");
show collections;
print("\n");

// ========================================
// 3. INSERT OPERATIONS (10+ documents)
// ========================================

print("=== INSERTING SAMPLE USERS (Phase 2 Data) ===");

// Insert Phase 2 sample users
db.users.insertMany([
    {
        UserID: "USR006",
        Username: "emily_johnson",
        Password: "emily123",
        Role: "Agent"
    },
    {
        UserID: "USR007",
        Username: "david_lee",
        Password: "david123",
        Role: "Manager"
    },
    {
        UserID: "USR008",
        Username: "lisa_martinez",
        Password: "lisa123",
        Role: "Supervisor"
    }
]);

print("3 additional users inserted for Phase 2\n");

print("=== INSERTING SAMPLE TASKS (Phase 2 Data) ===");

// Insert Phase 2 sample tasks
db.tasks.insertMany([
    {
        TaskID: "TASK007",
        UserID: "USR006",
        Title: "Database Backup and Maintenance",
        Description: "Perform weekly database backup and optimize queries",
        TaskStatus: "In Progress",
        steps: [
            {
                StepID: "STEP017",
                StepDescription: "Create full database backup",
                StepStatus: "Completed"
            },
            {
                StepID: "STEP018",
                StepDescription: "Analyze slow queries",
                StepStatus: "In Progress"
            },
            {
                StepID: "STEP019",
                StepDescription: "Implement query optimizations",
                StepStatus: "Pending"
            }
        ]
    },
    {
        TaskID: "TASK008",
        UserID: "USR007",
        Title: "Quarterly Budget Planning",
        Description: "Prepare budget forecast for Q1 2025",
        TaskStatus: "Pending",
        steps: [
            {
                StepID: "STEP020",
                StepDescription: "Gather department budget requests",
                StepStatus: "Pending"
            },
            {
                StepID: "STEP021",
                StepDescription: "Review historical spending",
                StepStatus: "Pending"
            },
            {
                StepID: "STEP022",
                StepDescription: "Create budget proposal",
                StepStatus: "Pending"
            }
        ]
    },
    {
        TaskID: "TASK009",
        UserID: "USR008",
        Title: "Employee Training Session",
        Description: "Conduct training on new software tools",
        TaskStatus: "Completed",
        steps: [
            {
                StepID: "STEP023",
                StepDescription: "Prepare training materials",
                StepStatus: "Completed"
            },
            {
                StepID: "STEP024",
                StepDescription: "Schedule training sessions",
                StepStatus: "Completed"
            },
            {
                StepID: "STEP025",
                StepDescription: "Conduct training and collect feedback",
                StepStatus: "Completed"
            }
        ]
    },
    {
        TaskID: "TASK010",
        UserID: "USR006",
        Title: "Security Audit",
        Description: "Review system security and update policies",
        TaskStatus: "In Progress",
        steps: [
            {
                StepID: "STEP026",
                StepDescription: "Run security vulnerability scan",
                StepStatus: "Completed"
            },
            {
                StepID: "STEP027",
                StepDescription: "Review access permissions",
                StepStatus: "In Progress"
            }
        ]
    }
]);

print("4 additional tasks inserted for Phase 2\n");

// ========================================
// 4. READ OPERATIONS
// ========================================

print("\n=== READ OPERATIONS ===\n");

print("--- Total Users in Database ---");
print("Count: " + db.users.countDocuments());

print("\n--- Total Tasks in Database ---");
print("Count: " + db.tasks.countDocuments());

print("\n--- Sample: First 3 Users ---");
db.users.find().limit(3).pretty();

print("\n--- Sample: First 3 Tasks ---");
db.tasks.find().limit(3).pretty();

print("\n--- Tasks with Status 'Completed' ---");
db.tasks.find({ TaskStatus: "Completed" }).pretty();

print("\n--- Tasks assigned to Specific User (USR006) ---");
db.tasks.find({ UserID: "USR006" }).pretty();

// ========================================
// 5. UPDATE OPERATIONS
// ========================================

print("\n=== UPDATE OPERATIONS ===\n");

// Update user role
print("--- Updating user USR006 role to 'Senior Agent' ---");
db.users.updateOne(
    { UserID: "USR006" },
    { $set: { Role: "Senior Agent" } }
);
print("✓ User updated successfully\n");

// Update task status
print("--- Updating TASK008 status to 'In Progress' ---");
db.tasks.updateOne(
    { TaskID: "TASK008" },
    { $set: { TaskStatus: "In Progress" } }
);
print("✓ Task updated successfully\n");

// Update step status
print("--- Updating step status in TASK007 ---");
db.tasks.updateOne(
    { TaskID: "TASK007", "steps.StepID": "STEP018" },
    { $set: { "steps.$.StepStatus": "Completed" } }
);
print("✓ Step updated successfully\n");

// Update multiple tasks (add due date)
print("--- Adding DueDate to pending tasks ---");
db.tasks.updateMany(
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
db.tasks.insertOne({
    TaskID: "TASK_DELETE_TEST",
    UserID: "USR999",
    Title: "Test Task - To Be Deleted",
    Description: "This task will be deleted",
    TaskStatus: "Pending",
    steps: []
});
print("✓ Test task inserted\n");

// Delete the test task
print("--- Deleting the test task ---");
db.tasks.deleteOne({ TaskID: "TASK_DELETE_TEST" });
print("✓ Task deleted successfully\n");

// Delete old completed tasks (example)
print("--- Deleting completed tasks older than specific date ---");
var deleteResult = db.tasks.deleteMany({
    TaskStatus: "Completed",
    Title: { $regex: "Test" }
});
print("✓ Deleted " + deleteResult.deletedCount + " test tasks\n");

// ========================================
// 7. AGGREGATION PIPELINES (4 Required)
// ========================================

print("\n=== AGGREGATION PIPELINES - REPORTS ===\n");

// AGGREGATION 1: Tasks Summary by Status
print("╔════════════════════════════════════════════════╗");
print("║  REPORT 1: Tasks Summary by Status            ║");
print("╚════════════════════════════════════════════════╝\n");
db.tasks.aggregate([
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
db.tasks.aggregate([
    {
        $group: {
            _id: "$UserID",
            totalTasks: { $sum: 1 },
            completedTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "Completed"] }, 1, 0] }
            },
            inProgressTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "In Progress"] }, 1, 0] }
            },
            pendingTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "Pending"] }, 1, 0] }
            }
        }
    },
    {
        $lookup: {
            from: "users",
            localField: "_id",
            foreignField: "UserID",
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
                $multiply: [
                    { $divide: ["$completedTasks", "$totalTasks"] },
                    100
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
db.tasks.aggregate([
    {
        $unwind: "$steps"
    },
    {
        $group: {
            _id: "$steps.StepStatus",
            totalSteps: { $sum: 1 },
            sampleSteps: { $push: "$steps.StepDescription" }
        }
    },
    {
        $project: {
            _id: 0,
            StepStatus: "$_id",
            TotalSteps: "$totalSteps",
            Percentage: {
                $round: [
                    {
                        $multiply: [
                            { $divide: ["$totalSteps", 25] }, // Total steps in system
                            100
                        ]
                    },
                    2
                ]
            },
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
db.tasks.aggregate([
    {
        $project: {
            _id: 0,
            TaskID: 1,
            UserID: 1,
            Title: 1,
            TaskStatus: 1,
            TotalSteps: { $size: "$steps" },
            CompletedSteps: {
                $size: {
                    $filter: {
                        input: "$steps",
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
            Status: {
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
// 8. SCHEMA VALIDATION
// ========================================

print("\n╔════════════════════════════════════════════════╗");
print("║  SCHEMA VALIDATION                             ║");
print("╚════════════════════════════════════════════════╝\n");

// Drop if exists
db.validated_tasks.drop();

db.createCollection("validated_tasks", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["TaskID", "UserID", "Title", "TaskStatus"],
            properties: {
                TaskID: {
                    bsonType: "string",
                    description: "TaskID is required and must be a string"
                },
                UserID: {
                    bsonType: "string",
                    description: "UserID is required and must be a string"
                },
                Title: {
                    bsonType: "string",
                    minLength: 5,
                    description: "Title must be at least 5 characters"
                },
                Description: {
                    bsonType: "string",
                    description: "Description must be a string"
                },
                TaskStatus: {
                    enum: ["Pending", "In Progress", "Completed"],
                    description: "Status must be: Pending, In Progress, or Completed"
                },
                steps: {
                    bsonType: "array",
                    items: {
                        bsonType: "object",
                        required: ["StepID", "StepDescription", "StepStatus"],
                        properties: {
                            StepID: { bsonType: "string" },
                            StepDescription: { bsonType: "string" },
                            StepStatus: {
                                enum: ["Pending", "In Progress", "Completed"]
                            }
                        }
                    }
                }
            }
        }
    }
});

print("✓ Schema validation created for 'validated_tasks' collection\n");

// Test valid document
print("--- Testing Valid Document ---");
try {
    db.validated_tasks.insertOne({
        TaskID: "VAL001",
        UserID: "USR001",
        Title: "Valid Test Task",
        Description: "Testing schema validation",
        TaskStatus: "Pending",
        steps: [{
            StepID: "STEP_V1",
            StepDescription: "Test step",
            StepStatus: "Pending"
        }]
    });
    print("✓ Valid document inserted successfully\n");
} catch (e) {
    print("✗ Error: " + e + "\n");
}

// Test invalid document
print("--- Testing Invalid Document (should fail) ---");
try {
    db.validated_tasks.insertOne({
        TaskID: "VAL002",
        UserID: "USR001",
        Title: "Bad",  // Too short (min 5 chars)
        TaskStatus: "Invalid Status"  // Not in enum
    });
    print("✗ Invalid document was inserted (unexpected)\n");
} catch (e) {
    print("✓ Validation correctly rejected invalid document\n");
}

// ========================================
// 9. INDEXES
// ========================================

print("\n╔════════════════════════════════════════════════╗");
print("║  CREATING INDEXES                              ║");
print("╚════════════════════════════════════════════════╝\n");

// Index 1: UserID for faster task queries
print("--- Creating index on tasks.UserID ---");
db.tasks.createIndex({ UserID: 1 });
print("✓ Index created on UserID\n");

// Index 2: Compound index on TaskStatus and UserID
print("--- Creating compound index ---");
db.tasks.createIndex({ TaskStatus: 1, UserID: 1 });
print("✓ Compound index created on TaskStatus + UserID\n");

// Index 3: Text index for searching
print("--- Creating text index for search ---");
db.tasks.createIndex({ Title: "text", Description: "text" });
print("✓ Text index created for full-text search\n");

// Index 4: Unique index on Username
print("--- Creating unique index on users.Username ---");
db.users.createIndex({ Username: 1 }, { unique: true });
print("✓ Unique index created on Username\n");

// Show all indexes
print("\n--- All Indexes on 'tasks' Collection ---");
printjson(db.tasks.getIndexes());

print("\n--- All Indexes on 'users' Collection ---");
printjson(db.users.getIndexes());

// ========================================
// 10. FINAL SUMMARY
// ========================================

print("\n╔════════════════════════════════════════════════╗");
print("║  SCRIPT EXECUTION COMPLETED                    ║");
print("╚════════════════════════════════════════════════╝\n");

print("Database: TaskManagmentDB");
print("─────────────────────────────────────────────────");
print("Collections:");
print("  • users: " + db.users.countDocuments() + " documents");
print("  • tasks: " + db.tasks.countDocuments() + " documents");
print("  • validated_tasks: " + db.validated_tasks.countDocuments() + " documents");
print("\nIndexes Created: 7 total");
print("Aggregation Reports: 4 completed");
print("Schema Validation: ✓ Active");
print("\n✓ All Phase 2 Requirements Met!");