namespace MyProject.WebUI.Models.AdminModel.OrderModel
{
    public class OrderListModel
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public string AppUserNameSurname { get; set; }
    }
}
