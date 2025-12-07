namespace MyProject.WebUI.Models.OrderModel
{
    public class StateOrderModel
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public string OrderStatusName { get; set; }
        public string AppUserNameSurname { get; set; }
    }
}
