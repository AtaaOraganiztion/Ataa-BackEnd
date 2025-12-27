using System.ComponentModel;

namespace Domain.Models.ContactForm.Enums;

public enum RequestType
{   [Description("طلب استفسار عام")]
    Inquiry,  
    [Description("طلب شراكة")]
    Partner,  
    [Description("طلب خدمة")]
    Service
}
