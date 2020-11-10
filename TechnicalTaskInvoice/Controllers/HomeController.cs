using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TechnicalTaskInvoice.Models;

namespace TechnicalTaskInvoice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IInvoiceHeaderRepository _invoiceHeaderRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IUiteRepository _uiteRepository;

        public static List<InvoiceDetail> Details = new List<InvoiceDetail>();
       
        public HomeController(ILogger<HomeController> logger,
                              IInvoiceDetailRepository invoiceDetailRepository,
                              IInvoiceHeaderRepository invoiceHeaderRepository,
                              IItemRepository itemRepository,
                              IStoreRepository storeRepository,
                              IUiteRepository uiteRepository)
        {
            _logger = logger;
            _storeRepository = storeRepository;
            _uiteRepository = uiteRepository;
            _itemRepository = itemRepository;
            _invoiceHeaderRepository = invoiceHeaderRepository;
            _invoiceDetailRepository = invoiceDetailRepository;



        }

        public IActionResult Index()
        {
            ViewBag.Invoice = _invoiceHeaderRepository.GetAllInvoiceHeader().ToList();
            return View();
        }
        
       public JsonResult CreateDetails(string Item, string Unit, string Price, 
                                          string Quantity, string Discount, 
                                          string Total, string Net)
        {
            Details.Add(new InvoiceDetail() {
            
                ItemID = Int32.Parse(Item),
                UnitID = Int32.Parse(Unit),
                Price = double.Parse(Price),
                quntity = Int32.Parse(Quantity),
                Discount = double.Parse(Discount),
                Total = double.Parse(Total),
                Net= double.Parse(Net)
            });

            if (Details.Count() != 0)
            {
                return Json("Success");
            }
            else
            {
                return Json("NoData");
            }
        }
        public IActionResult ViewInvoice(int Id)
        {
            ViewBag.InvoiceHeader = _invoiceHeaderRepository.GetInvoiceHeader(Id);
            ViewBag.InvoiceDetails = _invoiceDetailRepository.GetByInvoiceHeaderID(Id).ToList();
          
            return View();
        }
       

        public IActionResult Create()
        {
            ViewBag.Units =new SelectList(_uiteRepository.GetAllUite(), "ID", "Name") ;
            ViewBag.Items = new SelectList(_itemRepository.GetAllItem(), "ID", "Name");
            ViewBag.Stores = new SelectList(_storeRepository.GetAllStore(), "ID", "Name");

            return View();
        }

        public IActionResult createAllInvoic(string Invoice_NO ,int StoreID , string date, double Taxes)
        {

           
               // var net = Taxes + total;
                InvoiceHeader newInvoiceHeader = new InvoiceHeader
                {
                    Invoice_NO = Invoice_NO,
                    IvoiceDate = DateTime.Parse(date),
                    StoreID = StoreID,
                    Taxes = Taxes,
                    Total = 0,// total
                    Net =0 ,//total + taxes
                    
                };
                _invoiceHeaderRepository.Add(newInvoiceHeader);

                var InvoiceHeaderID = _invoiceHeaderRepository.GetAllInvoiceHeader().LastOrDefault();

                foreach (var item in Details)
                {
                    InvoiceDetail newInvoiceDetail = new InvoiceDetail
                    {
                        
                      ItemID = item.ItemID ,
                      UnitID = item.UnitID,
                      InvoiceHeaderID = InvoiceHeaderID.ID,
                      Discount = item.Discount,
                      Net = item.Net,
                      Price =item.Price,
                      quntity = item.quntity,
                      Total = item.Total

                    };
                    _invoiceDetailRepository.Add(newInvoiceDetail);


                }


           
                return View("Index");
        }
        public IActionResult Delete( int Id)
        {
          var detailsList =   _invoiceDetailRepository.GetByInvoiceHeaderID(Id);
            foreach (var item in detailsList)
            {
                _invoiceDetailRepository.Delete(item.ID);
            }
            _invoiceHeaderRepository.Delete(Id);


            return View("Index");
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
