using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TaskManagementApp.Models
{
    // User Collection
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userID")]
        public string UserID { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }
    }

    // Embedded Step within Task
    public class Step
    {
        [BsonElement("stepID")]
        public string StepID { get; set; }

        [BsonElement("stepDescription")]
        public string StepDescription { get; set; }

        [BsonElement("stepStatus")]
        public string StepStatus { get; set; } // Pending, Completed

        [BsonElement("signedOff")]
        public SignedOff SignedOff { get; set; }
    }

    // Embedded SignedOff within Step
    public class SignedOff
    {
        [BsonElement("userID")]
        public string UserID { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("date")]
        public DateTime? Date { get; set; }
    }

    // Task Collection (with embedded Steps)
    public class TaskItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("taskID")]
        public string TaskID { get; set; }

        [BsonElement("userID")]
        public string UserID { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("task_status")]
        public string Task_Status { get; set; } // Pending, In Progress, Completed

        [BsonElement("steps")]
        public List<Step> Steps { get; set; } = new List<Step>();

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("dueDate")]
        public DateTime? DueDate { get; set; }
    }

    // Report Collection
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("reportID")]
        public string ReportID { get; set; }

        [BsonElement("taskID")]
        public string TaskID { get; set; }

        [BsonElement("progressData")]
        public string ProgressData { get; set; }

        [BsonElement("generatedDate")]
        public DateTime GeneratedDate { get; set; }
    }

    // AuditLog Collection
    public class AuditLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("logID")]
        public string LogID { get; set; }

        [BsonElement("userID")]
        public string UserID { get; set; }

        [BsonElement("taskID")]
        public string TaskID { get; set; }

        [BsonElement("stepID")]
        public string StepID { get; set; }

        [BsonElement("action")]
        public string Action { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}