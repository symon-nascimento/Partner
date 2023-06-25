using System;
using System.Collections.Generic;

namespace Partner.Entities;

public partial class Contract
{
    public int Id { get; set; }

    public DateTime? ContractStart { get; set; }

    public DateTime? ContractEnd { get; set; }

    public string? MonthlyFees { get; set; }

    public int? Clients { get; set; }

    public DateTime? EmailSendDate { get; set; }

    public string? Email { get; set; }

    public string? TelephoneNumber { get; set; }

    public string? WhatsappNumber { get; set; }

    public string? Manager { get; set; }

    public string? ServiceDescription { get; set; }

    public virtual Client? ClientsNavigation { get; set; }
}
