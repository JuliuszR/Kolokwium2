namespace Kolokwium2.Models.Dtos;

public class NewBatchDto
{
    public int Quantity { get; set; }
    public string Species { get; set; }
    public string Nursery { get; set; }
    public List<ResponsibleDto> Responsible { get; set; }
}

public class ResponsibleDto
{
    public int EmployeeId { get; set; }
    public string Role { get; set; }
}