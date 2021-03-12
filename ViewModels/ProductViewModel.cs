using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp1.Models;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
   public  class ProductViewModel : BaseViewModel
    {

        private ProductModel product;
        public ProductViewModel()
        {
            product = new ProductModel();
            UpdateTotal =new DelegateCommand(async (object x)=> {
                System.Diagnostics.Debug.WriteLine("fuck");
                var page1 = new Page1();

            });
        }
        public ICommand UpdateTotal { get; set; }
        public string ProductName
        {
            get { return product.Name; }
            set
            {
                product.Name = value;
                OnPropertyChanged();
            }
        }
        public int ProductAmount
        {
            get { return product.Amount; }
            set
            {
                product.Amount = value;
                OnPropertyChanged();
            }
        }
        public int ProductCost
        {
            get { return product.Cost; }
            set
            {
                product.Cost = value;
                OnPropertyChanged();
            }
        }
        public int ProductTotal
        {
            get { return product.Total; }
            set
            {
                product.Total = value;
                OnPropertyChanged();
            }
        }
        public void CalcTotal()
        {
            ProductTotal = ProductCost * ProductAmount;
        }
        public bool CanExecute()
        {
            return true;
        }
    }
}
