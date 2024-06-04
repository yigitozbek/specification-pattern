using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Common.Entities;

namespace API.Entities;

/// <summary>
///     The task entity.
/// </summary>
[Table(nameof(Task), Schema = "todo")]
public sealed class Task : Entity<Guid>
{
    /// <summary>
    ///     Başlık
    /// </summary>
    [StringLength(255)]
    public required string Title { get; set; } = string.Empty;


    /// <summary>
    ///     Açıklama
    /// </summary>
    [StringLength(2048)]
    public required string? Description { get; set; }


    /// <summary>
    ///     Durum
    /// </summary>
    public bool IsDone { get; set; }


    /// <summary>
    ///    Tamamlanma tarihi
    /// </summary>
    public DateTimeOffset? DoneDateTime { get; set; }


    /// <summary>
    ///     Öncelik
    /// </summary>
    public short? Priority { get; set; }


    /// <summary>
    ///     Bitiş tarihi
    /// </summary>
    public DateTimeOffset? DueDate { get; set; }


    /// <summary>
    ///     Başlangıç tarihi
    /// </summary>
    public DateTimeOffset? StartDateTime { get; set; }


    /// <summary>
    ///     Bitiş tarihi
    /// </summary>
    public DateTimeOffset? EndDateTime { get; set; }


    /// <summary>
    ///     Hatırlatma
    /// </summary>
    public DateTimeOffset? Reminder { get; set; }


    /// <summary>
    ///     Bağlı olduğu görev
    /// </summary>
    public Guid? ParentId { get; set; }

    [ForeignKey(nameof(ParentId))] public Task? Parent { get; set; }
}