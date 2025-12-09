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

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }  // "Pending" or "Completed"
    }

    // ===========================
    // TASK COLLECTION
    // ===========================
    public class TaskItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("TaskID")]
        public string TaskID { get; set; }

        [BsonElement("UserID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserID { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }  // "Not Started", "In Progress", "Finished"

        [BsonElement("Steps")]
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

        [BsonElement("Username")]
        public string Username { get; set; }  // Changed from UserID to Username

        [BsonElement("Action")]
        public string Action { get; set; }

        [BsonElement("Details")]
        public string Details { get; set; }

        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}