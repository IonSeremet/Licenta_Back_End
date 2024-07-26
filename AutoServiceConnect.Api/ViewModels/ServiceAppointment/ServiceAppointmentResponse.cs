namespace AutoServiceConnect.Api.ViewModels.ServiceAppointment;

public class ServiceAppointmentResponse
{
    public int Id { get; set; }
    public string CustomerNotes { get; set; }
    public string MechanicNotes { get; set; }
    public DateTime AppointmentTime { get; set; }
    public int PaymentMethod { get; set; }
    public decimal EstimatedCost { get; set; }
}