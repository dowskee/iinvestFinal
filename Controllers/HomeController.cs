using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iinvest.Models;

namespace iinvest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Strategy()
        {
            return View();
        }
        public ActionResult Watson()
        {
            return View();
        }
        public ActionResult Why()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Analyze(string Risks, string Values1, string Values2)
        {
            //shows page where products can be selected
            //if/else statements to determine ViewBag displaying applicable risk selection
            //return View to Trade

            iinvestEntities StocksList = new iinvestEntities();
            List<StockProduct> AllStocks = StocksList.StockProducts.Where(x => x.risk == Risks && (x.value== Values1||x.value== Values2)).ToList(); 
            //&& x.value == Values1 || x.value == Values2).ToList();
           

            ViewBag.Products = AllStocks;
            return View("Trade");

        }

        public ActionResult Cart(string AddProduct, int Quantity)// PaymentChoice Upayment)
        {
            //Creates List Called Shopping Bag - allows multiple items
            List<StockProduct> PortfolioCart; // reference to null 

            if (Session["Cart"] == null)// the cart is empty! 
            {

                Session.Add("Cart", new List<StockProduct>());

                PortfolioCart = new List<StockProduct>();
            }

            else// user has items in the cart, so go and retrive it!
            {
                PortfolioCart = (List<StockProduct>)Session["Cart"];
                
            }
            //foreach outside for PortfolioCart to save to DB (display in Portfolio)

            ////////////// Adds items from database selected by user to list Shopping bag
            iinvestEntities StocksList = new iinvestEntities();

            StockProduct Option = StocksList.StockProducts.Find(AddProduct);


            Option.quantity = Quantity;
            
           // if (PortfolioCart.Where(x=>x.name)
            PortfolioCart.Add(Option);

            //ViewBag.Quantity = Quantity;

            //adds shoping bag array to hashtable that saves the list
            Session["Cart"] = PortfolioCart;// save changes you made to your cart! 

            ViewBag.Cart = PortfolioCart;

            /// Show totals and 


            double? stotal = 0;
            double? gtotal = 0;
             

            for (int i = 0; i < PortfolioCart.Count; i++)
            {
                stotal = stotal + PortfolioCart[i].price;
                gtotal = stotal * Quantity;
             
               
            }


            ViewBag.gtotal = gtotal;
           

            Session["GrandTotal"] = gtotal;





            ///Show's list of products again and allows user to add more products
            iinvestEntities StocksList2 = new iinvestEntities();
            List<StockProduct> AllProducts = StocksList2.StockProducts.ToList();
            ViewBag.Products = AllProducts;



            return View();



        }

        public ActionResult Invest()
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            var GrandTotal = (double)Session["GrandTotal"];
            ViewBag.gtotal = GrandTotal;

           // Session["Name"] = UserName;


            return View();
        }

        public ActionResult PaymentMade(string UserName)
        {

            ViewBag.Name = UserName;
            //var Name = (string)Session["Name"];
            //ViewBag.Name = Name;

            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

    }
}