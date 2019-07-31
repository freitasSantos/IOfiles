namespace InputOutputProdutos.Entities {
    class TotalProduct {
        public string Product { get; set; }
        public double TotalPrice { get; set; }

        public TotalProduct(string product,double totalPrice) {
            Product = product;
            TotalPrice = totalPrice;
        }
    }
}
