using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpetoTex.ModelFromDB;

[Table("job_requests")]
public partial class JobRequest
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("job_uid")]
    [StringLength(100)]
    public string JobUid { get; set; } = null!;

    [Column("original_filename")]
    [StringLength(255)]
    public string? OriginalFilename { get; set; }

    [Column("file_path")]
    [StringLength(500)]
    public string? FilePath { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string? Status { get; set; }

    [Column("full_text")]
    public string? FullText { get; set; }

    [Column("summary")]
    public string? Summary { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("completed_at", TypeName = "datetime")]
    public DateTime? CompletedAt { get; set; }
}
