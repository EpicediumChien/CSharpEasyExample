using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebAPITest1.Models.infrastructure;
using EasyExample.Models;
using EasyExample.Service;
using EasyExample.Repository;

namespace EasyExample.APIController
{
    public class CustomersController : Controller
    {
        private readonly DBConnect _dBConnect;
        public readonly ICustomerService _customerService;
        public readonly IOtherService _otherService;

        public CustomersController()
        {
            _dBConnect = new DBConnect();
            _customerService = new CustomerService(new CustomerRepository());
            _otherService = new OtherService();
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            List<Customer> customers = _dBConnect.Select();
            string jsonresult = JsonConvert.SerializeObject(customers);
            return Content(jsonresult);
        }

        [HttpPost]
        public ActionResult InsertCustomers()
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader(Request.InputStream)) {
                jsonString = sr.ReadToEnd();
            }
            if (String.IsNullOrEmpty(jsonString)) { return Json(true); }
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            //For Insert customers
            foreach (var customer in customers)
            {
                _dBConnect.Insert(customer);
            }

            return Json(true);
            //return await Task.FromResult(Ok(_customerService.InsertCustomers(customers)));
        }

        [HttpDelete]
        public ActionResult DeleteCustomers()
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                jsonString = sr.ReadToEnd();
            }
            if (String.IsNullOrEmpty(jsonString)) { return Json(true); }
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            //For Delete customers
            foreach (var customer in customers)
            {
                _dBConnect.Delete(customer);
            }

            return Json(true);
            //return await Task.FromResult(Ok(_customerService.DeleteCustomers(customers)));
        }

        [HttpPut]
        public ActionResult UpdateCustomers()
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                jsonString = sr.ReadToEnd();
            }
            if (String.IsNullOrEmpty(jsonString)) { return Json(true); }
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            //For Update customers
            foreach (var customer in customers)
            {
                _dBConnect.Update(customer);
            }

            return Json(true);
            //return await Task.FromResult(Ok(_customerService.UpdateCustomers(customers)));
        }

        [HttpPost]
        public ActionResult BFSTest(List<Node> nodes, string target)
        {
            List<Node> queue = new List<Node>();
            Node cursor = nodes[0];
            cursor.Visit();
            cursor.Route = cursor.Id.ToString();
            queue.Add(cursor);
            while (queue!=null && queue.Count!=0)
            {
                if (cursor.Value == target)
                { break; }
                else if (queue.FirstOrDefault().nextNodes.Where(node => node.Visited == false).Any())
                {
                    cursor = _otherService.MoveNextUnvisitedNode(queue.FirstOrDefault());
                    cursor.Visit();
                    cursor.Route = queue.FirstOrDefault().Route + " => " + cursor.Id.ToString();
                    queue.Add(cursor);
                }
                else {
                    if (queue.FirstOrDefault().nextNodes.Any())
                    { 
                        cursor = queue.FirstOrDefault().nextNodes.FirstOrDefault(); 
                        queue.RemoveAt(0);
                    }
                }
            }

            if (queue.Count == 0)
            { return new HttpNotFoundResult(); }
            else 
            { 
                return Json(new { cursor.Id, cursor.Route});
            }
        }

        [HttpPost]
        public ActionResult DFSTest(List<Node> nodes, string target)
        {
            List<Node> stack = new List<Node>();
            Node cursor = nodes[0];
            cursor.Visit();
            cursor.Route = cursor.Id.ToString();
            stack.Add(cursor);
            while (stack != null && stack.Count != 0)
            {
                if (cursor.Value == target)
                { break; }
                else if (stack.LastOrDefault().nextNodes.Any())
                {
                    cursor = _otherService.MoveNextUnvisitedNode(cursor);
                    cursor.Visit();
                    cursor.Route = stack.LastOrDefault() + " => " + cursor.Id.ToString();
                    stack.Add(cursor);
                }
                else
                {
                    if (stack.LastOrDefault().nextNodes.Where(node => node.Visited == false).Any())
                    {
                        cursor = _otherService.MoveNextUnvisitedNode(stack.LastOrDefault());
                        stack.Add(cursor);
                        stack.RemoveAt(stack.Count - 1);
                    }
                }
            }

            if (stack.Count == 0)
            { return new HttpNotFoundResult(); }
            else
            {
                return Json(new { cursor.Id, cursor.Route });
            }
        }
    }
}