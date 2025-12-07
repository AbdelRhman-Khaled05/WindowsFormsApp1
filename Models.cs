using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TaskManagementApp.Models
{
    // ===========================
    // USER COLLECTION
    // ===========================

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // MATCH InsertForm: "UserID"
        [BsonElement("UserID")]
        public string UserID { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Role")]
        public string Role { get; set; }
    }

    // ===========================
    // STEP (EMBEDDED IN TASK)
    // ===========================

    public class Step
    {
        [BsonElement("StepID")]
        public string StepID { get; set; }

        [BsonElement("StepDescription")]
        public string StepDescription { get; set; }

        [BsonElement("StepStatus")]
        public string StepStatus { get; set; }

        [BsonElement("SignedOff")]
        public SignedOff SignedOff { get; set; }
    }

    // ===========================
    // SIGNEDOFF (EMBEDDED IN STEP)
    // ===========================

    public class SignedOff
    {
        [BsonElement("UserID")]
        public string UserID { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        // Allow nullable dates
        [BsonElement("Date")]
        public DateTime? Date { get; set; }
    }

    // ===========================
    // TASK COLLECTION
    // ===========================

    public class TaskItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // MATCH InsertForm fields:
        [BsonElement("TaskID")]
        public string TaskID { get; set; }

        [BsonElement("UserID")]
        public string UserID { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        // MATCH InsertForm: "TaskStatus"
        [BsonElement("TaskStatus")]
        public string TaskStatus { get; set; }

        [BsonElement("steps")]
        public List<Step> Steps { get; set; } = new List<Step>();

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("DueDate")]
        public DateTime? DueDate { get; set; }
    }

    // ===========================
    // REPORT COLLECTION
    // ===========================

    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ReportID")]
        public string ReportID { get; set; }

        [BsonElement("TaskID")]
        public string TaskID { get; set; }

        [BsonElement("ProgressData")]
        public string ProgressData { get; set; }

        [BsonElement("GeneratedDate")]
        public DateTime GeneratedDate { get; set; }
    }

    // ===========================
    // AUDIT LOG COLLECTION
    // ===========================

    public class AuditLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("LogID")]
        public string LogID { get; set; }

        [BsonElement("UserID")]
        public string UserID { get; set; }

        [BsonElement("TaskID")]
        public string TaskID { get; set; }

        [BsonElement("StepID")]
        public string StepID { get; set; }

        [BsonElement("Action")]
        public string Action { get; set; }

        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
