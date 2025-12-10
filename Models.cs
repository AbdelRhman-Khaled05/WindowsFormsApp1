using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TaskManagementApp.Models
{
    // USER
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

    // SignedOff subdocument used inside Step
    public class SignedOff
    {
        [BsonElement("Status")]
        public string Status { get; set; } = "Not-Signed"; // "Signed" or "Not-Signed"

        [BsonElement("Date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }

    // Step inside Steps array (matches MongoDB schema)
    public class Step
    {
        [BsonElement("StepID")]
        public string StepID { get; set; }

        [BsonElement("StepDescription")]
        public string StepDescription { get; set; }

        [BsonElement("StepStatus")]
        public string StepStatus { get; set; } = "Pending"; // "Pending" or "Completed"

        [BsonElement("SignedOff")]
        public SignedOff SignedOff { get; set; } = new SignedOff();
    }

    // Task document
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

        [BsonElement("TaskStatus")]
        public string TaskStatus { get; set; } = "Pending"; // "Pending", "In-Progress", "Completed"

        [BsonElement("Steps")]
        public List<Step> Steps { get; set; } = new List<Step>();

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [BsonElement("DueDate")]
        public DateTime? DueDate { get; set; }
    }

    // Audit log
    public class AuditLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("LogID")]
        public string LogID { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Action")]
        public string Action { get; set; }

        [BsonElement("Details")]
        public string Details { get; set; }

        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
