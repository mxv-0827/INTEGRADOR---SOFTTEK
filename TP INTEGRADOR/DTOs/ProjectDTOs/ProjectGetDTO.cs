namespace TP_INTEGRADOR.DTOs.ProjectDTOs
{
    public class ProjectGetDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public int State { get; set; }
        public DateTime? LeavingDate { get; set; }
    }
}
