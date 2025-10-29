﻿namespace MyProject.WebUI.Models.AdminModel.DashboardModel
{
    public class DashboardViewModel
    {
        public int TotalProduct { get; set; }
        public int TotalOrder { get; set; }

        public decimal TotalAmountOrder { get; set; }

        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
