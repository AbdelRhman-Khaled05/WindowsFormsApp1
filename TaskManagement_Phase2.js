// ========================================================================
// MongoDB Script for Task Management System - Phase 2
// Database: TaskManagmentDB
// ========================================================================

// 1. DATABASE & COLLECTION CREATION
// ========================================================================

use TaskManagmentDB;

// Drop existing collections for clean setup (optional)
db.Users.drop();
db.Tasks.drop();
db.AuditLogs.drop();

// Create collections
db.createCollection("Users");
db.createCollection("Tasks");
db.createCollection("AuditLogs");

print("Collections created successfully.");

// ========================================================================
// 2. SCHEMA VALIDATION
// ========================================================================

// Apply JSON Schema Validation on Tasks Collection
db.runCommand({
    collMod: "Tasks",
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["TaskID", "UserID", "Title", "TaskStatus", "Steps", "CreatedDate"],
            properties: {
                TaskID: {
                    bsonType: "string",
                    description: "Task ID must be a string and is required"
                },
                UserID: {
                    bsonType: "objectId",
                    description: "UserID must be an ObjectId referencing Users collection"
                },
                Title: {
                    bsonType: "string",
                    minLength: 5,
                    description: "Title must be a string with minimum 5 characters"
                },
                Description: {
                    bsonType: "string",
                    description: "Description must be a string"
                },
                TaskStatus: {
                    enum: ["Pending", "In-Progress", "Completed"],
                    description: "TaskStatus must be one of: Pending, In-Progress, or Completed"
                },
                Steps: {
                    bsonType: "array",
                    description: "Steps must be an array of step objects",
                    items: {
                        bsonType: "object",
                        required: ["StepID", "StepDescription", "StepStatus"],
                        properties: {
                            StepID: {
                                bsonType: "string"
                            },
                            StepDescription: {
                                bsonType: "string"
                            },
                            StepStatus: {
                                enum: ["Pending", "Completed"]
                            },
                            SignedOff: {
                                bsonType: "object",
                                properties: {
                                    Status: {
                                        enum: ["Signed", "Not-Signed"]
                                    },
                                    Date: {
                                        bsonType: "date"
                                    }
                                }
                            }
                        }
                    }
                },
                CreatedDate: {
                    bsonType: "date",
                    description: "CreatedDate must be a date"
                },
                DueDate: {
                    bsonType: "date",
                    description: "DueDate must be a date"
                }
            }
        }
    },
    validationLevel: "moderate"
});

print("Schema validation applied on Tasks collection.");

// ========================================================================
// 3. INDEX CREATION
// ========================================================================

// Create indexes for performance optimization
db.Users.createIndex({ "Username": 1 }, { unique: true });
db.Users.createIndex({ "Role": 1 });

db.Tasks.createIndex({ "TaskID": 1 }, { unique: true });
db.Tasks.createIndex({ "UserID": 1 });
db.Tasks.createIndex({ "TaskStatus": 1 });
db.Tasks.createIndex({ "DueDate": 1 });

db.AuditLogs.createIndex({ "Username": 1 });
db.AuditLogs.createIndex({ "Timestamp": -1 });

print("Indexes created successfully.");

// ========================================================================
// 4. DATA INSERTION (CRUD - CREATE)
// ========================================================================

// Insert Users (10+ documents distributed across collections)
db.Users.insertMany([
    {
        Username: "Seif_Tamer",
        Password: "123",
        Role: "User"
    },
    {
        Username: "Ali_Ashraf",
        Password: "123",
        Role: "User"
    },
    {
        Username: "Asaad_Ramzy",
        Password: "123",
        Role: "User"
    },
    {
        Username: "Adel_Waheed",
        Password: "123",
        Role: "User"
    },
    {
        Username: "Abdelrahman_Khaled",
        Password: "123",
        Role: "Admin"
    },
    {
        Username: "testt",
        Password: "123",
        Role: "User"
    }
]);

print("Users inserted successfully.");

// Get User IDs for task assignment
var user1 = db.Users.findOne({ Username: "Seif_Tamer" })._id;
var user2 = db.Users.findOne({ Username: "Ali_Ashraf" })._id;
var user3 = db.Users.findOne({ Username: "Asaad_Ramzy" })._id;
var user4 = db.Users.findOne({ Username: "Adel_Waheed" })._id;
var admin = db.Users.findOne({ Username: "Abdelrahman_Khaled" })._id;

// Insert Tasks with embedded Steps documents
db.Tasks.insertMany([
    {
        TaskID: "TSK003",
        UserID: user1,
        Title: "API Documentation Update",
        Description: "Update and review API documentation for v2.0 release.",
        TaskStatus: "Pending",
        Steps: [
            {
                StepID: "STP003-1",
                StepDescription: "Review existing API documentation",
                StepStatus: "Pending",
                SignedOff: {
                    Status: "Not-Signed",
                    Date: new Date()
                }
            },
            {
                StepID: "STP003-2",
                StepDescription: "Update documentation with new endpoints",
                StepStatus: "Pending",
                SignedOff: {
                    Status: "Not-Signed",
                    Date: new Date()
                }
            }
        ],
        CreatedDate: new Date("2025-12-15"),
        DueDate: new Date("2025-01-10")
    },
    {
        TaskID: "TSK004",
        UserID: user2,
        Title: "Code Review Sprint",
        Description: "Conduct code review for Q1 development sprint.",
        TaskStatus: "Completed",
        Steps: [
            {
                StepID: "STP004-1",
                StepDescription: "Review frontend code",
                StepStatus: "Completed",
                SignedOff: {
                    Status: "Signed",
                    Date: new Date("2025-12-08")
                }
            },
            {
                StepID: "STP004-2",
                StepDescription: "Review backend code",
                StepStatus: "Completed",
                SignedOff: {
                    Status: "Signed",
                    Date: new Date("2025-12-09")
                }
            },
            {
                StepID: "STP004-3",
                StepDescription: "Document findings and recommendations",
                StepStatus: "Completed",
                SignedOff: {
                    Status: "Signed",
                    Date: new Date("2025-12-10")
                }
            }
        ],
        CreatedDate: new Date("2025-12-15"),
        DueDate: new Date("2025-12-10")
    },
    {
        TaskID: "TSK005",
        UserID: user3,
        Title: "Client Presentation",
        Description: "Prepare and deliver quarterly progress presentation to stakeholders.",
        TaskStatus: "In-Progress",
        Steps: [
            {
                StepID: "STP005-1",
                StepDescription: "Gather project metrics and data",
                StepStatus: "Completed",
                SignedOff: {
                    Status: "Signed",
                    Date: new Date("2025-12-12")
                }
            },
            {
                StepID: "STP005-2",
                StepDescription: "Create presentation slides",
                StepStatus: "Completed",
                SignedOff: {
                    Status: "Not-Signed",
                    Date: new Date()
                }
            },
            {
                StepID: "STP005-3",
                StepDescription: "Rehearse and deliver presentation",
                StepStatus: "Pending",
                SignedOff: {
                    Status: "Not-Signed",
                    Date: new Date()
                }
            }
        ],
        CreatedDate: new Date("2025-12-15"),
        DueDate: new Date("2025-01-08")
    },
    {
        TaskID: "TSK006",
        UserID: user4,
        Title: "Database Migration",
        Description: "Migrate legacy database to MongoDB Atlas.",
        TaskStatus: "Pending",
        Steps: [
            {
                StepID: "STP006-1",
                StepDescription: "Analyze current database schema",
                StepStatus: "Pending",
                SignedOff: {
                    Status: "Not-Signed",
                    Date: new Date()
                }
            },
            {
                StepID: "STP006-2",
                StepDescription: "Design MongoDB schema",
                StepStatus: "Pending",
                SignedOff: {
                    Status: "Not-Signed",
                    Date: new Date()
                }
            },
            {
                StepID: "STP006-3",
                StepDescription: "Execute migration scripts",
                StepStatus: "Pending",
                SignedOff: {
                    Status: "Not-Signed",
                    Date: new Date()
                }
            }
        ],
        CreatedDate: new Date("2025-12-16"),
        DueDate: new Date("2025-01-20")
    },
    {
        TaskID: "TSK007",
        UserID: admin,
        Title: "Security Audit",
        Description: "Perform comprehensive security audit of the application.",
        TaskStatus: "In-Progress",
        Steps: [
            {
                StepID: "STP007-1",
                StepDescription: "Review authentication mechanisms",
                StepStatus: "Completed",
                SignedOff: {
                    Status: "Signed",
                    Date: new Date("2025-12-14")
                }
            },
            {
                StepID: "STP007-2",
                StepDescription: "Test for SQL injection vulnerabilities",
                StepStatus: "Pending",
                SignedOff: {
                    Status: "Not-Signed",
                    Date: new Date()
                }
            }
        ],
        CreatedDate: new Date("2025-12-13"),
        DueDate: new Date("2025-12-25")
    }
]);

print("Tasks inserted successfully.");

// Insert Audit Logs
db.AuditLogs.insertMany([
    {
        LogID: "LOG001",
        Username: "Abdelrahman_Khaled",
        Action: "Login",
        Details: "Admin logged into the system",
        Timestamp: new Date("2025-12-15T08:00:00Z")
    },
    {
        LogID: "LOG002",
        Username: "Seif_Tamer",
        Action: "Create Task",
        Details: "Created task: API Documentation Update",
        Timestamp: new Date("2025-12-15T09:15:00Z")
    },
    {
        LogID: "LOG003",
        Username: "Ali_Ashraf",
        Action: "Update Task",
        Details: "Completed task: Code Review Sprint",
        Timestamp: new Date("2025-12-15T14:30:00Z")
    },
    {
        LogID: "LOG004",
        Username: "Abdelrahman_Khaled",
        Action: "Update User",
        Details: "Updated user role for testt",
        Timestamp: new Date("2025-12-16T10:00:00Z")
    },
    {
        LogID: "LOG005",
        Username: "Asaad_Ramzy",
        Action: "Update Step",
        Details: "Updated Step STP005-1 in Task TSK005",
        Timestamp: new Date("2025-12-16T11:20:00Z")
    }
]);

print("Audit logs inserted successfully.");

// ========================================================================
// 5. READ OPERATIONS (CRUD - READ)
// ========================================================================

print("\n=== READ OPERATIONS ===\n");

// Read all users
print("All Users:");
printjson(db.Users.find().toArray());

// Find tasks by status
print("\nPending Tasks:");
printjson(db.Tasks.find({ TaskStatus: "Pending" }).toArray());

// Find tasks for a specific user
print("\nTasks for Seif_Tamer:");
printjson(db.Tasks.find({ UserID: user1 }).toArray());

// Find tasks with due date before Jan 15, 2025
print("\nTasks due before Jan 15, 2025:");
printjson(db.Tasks.find({ DueDate: { $lt: new Date("2025-01-15") } }).toArray());

// Find admin users
print("\nAdmin Users:");
printjson(db.Users.find({ Role: "Admin" }).toArray());

// ========================================================================
// 6. UPDATE OPERATIONS (CRUD - UPDATE)
// ========================================================================

print("\n=== UPDATE OPERATIONS ===\n");

// Update a user's password
db.Users.updateOne(
    { Username: "testt" },
    { $set: { Password: "newpassword123" } }
);
print("Updated password for user 'testt'");

// Update task status
db.Tasks.updateOne(
    { TaskID: "TSK003" },
    { $set: { TaskStatus: "In-Progress" } }
);
print("Updated TaskStatus for TSK003 to In-Progress");

// Update a step status within a task
db.Tasks.updateOne(
    { TaskID: "TSK006", "Steps.StepID": "STP006-1" },
    {
        $set: {
            "Steps.$.StepStatus": "Completed",
            "Steps.$.SignedOff.Status": "Signed",
            "Steps.$.SignedOff.Date": new Date()
        }
    }
);
print("Updated step STP006-1 in TSK006 to Completed");

// Update multiple users' role
db.Users.updateMany(
    { Role: "User" },
    { $set: { LastModified: new Date() } }
);
print("Added LastModified field to all User role accounts");

// ========================================================================
// 7. DELETE OPERATIONS (CRUD - DELETE)
// ========================================================================

print("\n=== DELETE OPERATIONS ===\n");

// Delete old audit logs (example: logs older than 30 days)
var thirtyDaysAgo = new Date();
thirtyDaysAgo.setDate(thirtyDaysAgo.getDate() - 30);

var deleteResult = db.AuditLogs.deleteMany({
    Timestamp: { $lt: thirtyDaysAgo }
});
print("Deleted " + deleteResult.deletedCount + " old audit logs");

// Delete a specific task
db.Tasks.deleteOne({ TaskID: "TSK_TO_DELETE" });
print("Attempted to delete task TSK_TO_DELETE");

// Delete completed tasks older than 60 days
var sixtyDaysAgo = new Date();
sixtyDaysAgo.setDate(sixtyDaysAgo.getDate() - 60);

var oldCompletedTasks = db.Tasks.deleteMany({
    TaskStatus: "Completed",
    CreatedDate: { $lt: sixtyDaysAgo }
});
print("Deleted " + oldCompletedTasks.deletedCount + " old completed tasks");

// ========================================================================
// 8. AGGREGATION PIPELINES (4 REQUIRED REPORTS)
// ========================================================================

print("\n=== AGGREGATION REPORTS ===\n");

// AGGREGATION 1: User Task Summary Report
// Purpose: Show how many tasks each user has and their completion rate
print("\n--- Report 1: User Task Summary ---");
db.Tasks.aggregate([
    {
        $group: {
            _id: "$UserID",
            TotalTasks: { $sum: 1 },
            CompletedTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "Completed"] }, 1, 0] }
            },
            InProgressTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "In-Progress"] }, 1, 0] }
            },
            PendingTasks: {
                $sum: { $cond: [{ $eq: ["$TaskStatus", "Pending"] }, 1, 0] }
            }
        }
    },
    {
        $lookup: {
            from: "Users",
            localField: "_id",
            foreignField: "_id",
            as: "UserDetails"
        }
    },
    {
        $unwind: "$UserDetails"
    },
    {
        $project: {
            _id: 0,
            Username: "$UserDetails.Username",
            Role: "$UserDetails.Role",
            TotalTasks: 1,
            CompletedTasks: 1,
            InProgressTasks: 1,
            PendingTasks: 1,
            CompletionRate: {
                $concat: [
                    { $toString: { $round: [{ $multiply: [{ $divide: ["$CompletedTasks", "$TotalTasks"] }, 100] }, 2] } },
                    "%"
                ]
            }
        }
    },
    {
        $sort: { TotalTasks: -1 }
    }
]).forEach(printjson);

// AGGREGATION 2: Overdue Tasks Report
// Purpose: Identify tasks that are past their due date
print("\n--- Report 2: Overdue Tasks ---");
db.Tasks.aggregate([
    {
        $match: {
            DueDate: { $lt: new Date() },
            TaskStatus: { $ne: "Completed" }
        }
    },
    {
        $lookup: {
            from: "Users",
            localField: "UserID",
            foreignField: "_id",
            as: "AssignedUser"
        }
    },
    {
        $unwind: "$AssignedUser"
    },
    {
        $project: {
            _id: 0,
            TaskID: 1,
            Title: 1,
            AssignedTo: "$AssignedUser.Username",
            DueDate: 1,
            CurrentStatus: "$TaskStatus",
            DaysOverdue: {
                $dateDiff: {
                    startDate: "$DueDate",
                    endDate: new Date(),
                    unit: "day"
                }
            }
        }
    },
    {
        $sort: { DaysOverdue: -1 }
    }
]).forEach(printjson);

// AGGREGATION 3: Step Completion Analysis
// Purpose: Analyze step completion across all tasks
print("\n--- Report 3: Step Completion Analysis ---");
db.Tasks.aggregate([
    {
        $unwind: "$Steps"
    },
    {
        $group: {
            _id: "$Steps.StepStatus",
            TotalSteps: { $sum: 1 },
            SignedOffSteps: {
                $sum: { $cond: [{ $eq: ["$Steps.SignedOff.Status", "Signed"] }, 1, 0] }
            }
        }
    },
    {
        $project: {
            _id: 0,
            StepStatus: "$_id",
            TotalSteps: 1,
            SignedOffSteps: 1,
            SignOffRate: {
                $concat: [
                    { $toString: { $round: [{ $multiply: [{ $divide: ["$SignedOffSteps", "$TotalSteps"] }, 100] }, 2] } },
                    "%"
                ]
            }
        }
    }
]).forEach(printjson);

// AGGREGATION 4: Monthly Activity Report (Audit Logs)
// Purpose: Summarize system activity by action type
print("\n--- Report 4: System Activity Summary ---");
db.AuditLogs.aggregate([
    {
        $group: {
            _id: "$Action",
            ActionCount: { $sum: 1 },
            UniqueUsers: { $addToSet: "$Username" },
            LatestActivity: { $max: "$Timestamp" }
        }
    },
    {
        $project: {
            _id: 0,
            ActionType: "$_id",
            TotalOccurrences: "$ActionCount",
            UniqueUsersCount: { $size: "$UniqueUsers" },
            MostRecentActivity: "$LatestActivity"
        }
    },
    {
        $sort: { TotalOccurrences: -1 }
    }
]).forEach(printjson);

// ========================================================================
// 9. VERIFICATION QUERIES
// ========================================================================

print("\n=== DATABASE STATISTICS ===\n");

print("Total Users: " + db.Users.countDocuments());
print("Total Tasks: " + db.Tasks.countDocuments());
print("Total Audit Logs: " + db.AuditLogs.countDocuments());

print("\nTask Status Distribution:");
printjson(db.Tasks.aggregate([
    {
        $group: {
            _id: "$TaskStatus",
            Count: { $sum: 1 }
        }
    }
]).toArray());

print("\n=== Script Execution Completed Successfully ===");