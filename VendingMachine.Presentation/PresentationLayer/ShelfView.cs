using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.Presentation.PresentationLayer;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.DataAccess.Domaine;

namespace iQuest.VendingMachine.Presentation
{
    public class ShelfView:DisplayBase, IShelfView
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void DisplayProducts(IEnumerable<Product> products)
        {
            if (products == null)
            {
                log.Error(new ArgumentNullException());
                throw new ArgumentNullException();
            }
                
            else
                 foreach (Product p in products)
                      Display($"{p.ColumnId} {p.Name} {p.Price} {p.Quantity}\n", ConsoleColor.Cyan);    
        }

        public void DisplayAvailableProducts(IEnumerable<Product> allProducts, List<Product>displayProducts)
        {
            foreach (Product product in allProducts)
            {
                if (product.Quantity > 0)
                {
                    displayProducts.Add(product);
                    Display(product.ColumnId + " " + product.Name + " " + product.Price + " " + product.Quantity + "\n", ConsoleColor.DarkCyan);
                }

                else
                {
                    log.Error(new InsufficentStockException());
                    throw new InsufficentStockException();
                }
                  
            }

        }
    }
}