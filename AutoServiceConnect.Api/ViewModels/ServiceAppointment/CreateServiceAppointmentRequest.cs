namespace AutoServiceConnect.Api.ViewModels.ServiceAppointment;

public class CreateServiceAppointmentRequest
{
    public string CustomerNotes { get; set; }
    public string MechanicNotes { get; set; }
    public DateTime AppointmentTime { get; set; }
}