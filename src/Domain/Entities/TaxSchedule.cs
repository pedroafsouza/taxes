using Taxes.Domain.Common;
using System;
using Taxes.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxes.Domain.Entities
{
    public class TaxSchedule : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Municipality Municipality { get; set; }

        public DateTime StartDate { get; set; }

        public TimePeriod TimePeriod { get; set; }
    }
}
