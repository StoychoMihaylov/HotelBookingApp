namespace HotelBooking.App.Controllers
{
    using HotelBooking.Models.ViewModels.Gallery;
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.Cookies["Cookie"].Value = "Like every other website we use cookies. By using our site you acknowledge that you have read and understand our Cookie Policy, Privacy Policy, and our Terms of Service. Learn more";
            Response.Cookies["Cookie"].Expires = DateTime.Now.AddDays(1);

            return View();
        }

        [Route("gallery/{id}")]
        public ActionResult Gallery(int ?id)
        {
            string[] picturePaths1 = new string[]
            {
                "~/Content/Images/1 Barbecue.1.1.jpg",          //1
                "~/Content/Images/3 Swimming pool 3.1.1.jpg",   //2
                "~/Content/Images/4 Swimming pool 1.1.1.1.jpg", //3
                "~/Content/Images/5 Swimming pool.jpg",         //4
                "~/Content/Images/6 Swimming pool 2.4.1.jpg",   //5
                "~/Content/Images/7 Swimming pool 4.jpg",       //6
                "~/Content/Images/2 Swimming pool.2.jpg",       //7
                "~/Content/Images/28 Pool at night.jpg",        //8
                "~/Content/Images/27 Pool at night.1.jpg",      //9
            };

            string[] picturePaths2 = new string[]
            {
                "~/Content/Images/26 Pool at night.jpg",        //10                    
                "~/Content/Images/8 Outdoor 2.1.jpg",           //11
                "~/Content/Images/9 Outdoor 4.1.jpg",           //12
                "~/Content/Images/outside.jpg",                 //13
                "~/Content/Images/10 Baebecue 2.1.jpg",         //14
                "~/Content/Images/11 Living.1.jpg",             //15
                "~/Content/Images/12 Dining 1.jpg",             //16
                "~/Content/Images/12 Dining 2.jpg",             //17
                "~/Content/Images/13 Kitchen 1.jpg",            //18                       
            };

            string[] picturePaths3 = new string[] 
            {
                "~/Content/Images/14 Kitchen 2.jpg",            //19
                "~/Content/Images/15 Family room.jpg",          //20
                "~/Content/Images/pokertable.jpg",              //21
                "~/Content/Images/16 Balcony.jpg",              //22
                "~/Content/Images/20 Loft.1.1.jpg",             //23
                "~/Content/Images/17 Master.jpg",               //24
                "~/Content/Images/18  Master.jpg",              //25
                "~/Content/Images/19 Master bathroom.jpg",      //26
                "~/Content/Images/bed.jpg",                     //27
            };

            string[] picturePaths4 = new string[]
            {
                "~/Content/Images/21 Bedroom 2.jpg",            //28
                "~/Content/Images/bed2.jpg",                    //29
                "~/Content/Images/22 Bedroom 3.jpg",            //30
                "~/Content/Images/23 Bathroom 2.jpg",           //31
                "~/Content/Images/25 Bathroom 3.jpg",           //32
                "~/Content/Images/bed3.jpg",                    //34
                "~/Content/Images/bed4.jpg"                     //35
            };

            if (id == 1)
            {
                PaginViewModel paths = new PaginViewModel();
                paths.picturePaths = picturePaths1;
                paths.page = 1;

                return View(paths);
            }
            else if (id == 2)
            {
                PaginViewModel paths = new PaginViewModel();
                paths.picturePaths = picturePaths2;
                paths.page = 2;

                return View(paths);
            }
            else if (id == 3)
            {
                PaginViewModel paths = new PaginViewModel();
                paths.picturePaths = picturePaths3;
                paths.page = 3;

                return View(paths);
            }
            else if (id == 4)
            {
                PaginViewModel paths = new PaginViewModel();
                paths.picturePaths = picturePaths4;
                paths.page = 4;

                return View(paths);
            }
            else
            {
                return HttpNotFound();
            } 
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}