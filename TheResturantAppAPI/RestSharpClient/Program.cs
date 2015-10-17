using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using TheResturantApp.Models.DTO;
using System.IO;

namespace RestSharpClient
{
   public  class Program
    {

        public void GetReservations()
        {
            string phone = "0220778677";
            const string BaseAddress = "http://khanzzirfan.com/WApp/";
            var client = new RestClient(BaseAddress);
            string accessToken = "";
            var tokenRequest = new RestRequest("token", Method.POST);
            tokenRequest.AddParameter("grant_type", "password");
            tokenRequest.AddParameter("username", "irfank");
            tokenRequest.AddParameter("password", "Green0987");

            Console.WriteLine("Call to access token");
            var tokenResponse = client.Execute(tokenRequest);

            if (tokenResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var datatoken = tokenResponse.Content;

                var jObject = Newtonsoft.Json.Linq.JObject.Parse(datatoken);
                var token = jObject.SelectToken("access_token");
                accessToken = string.Format("Bearer {0}", token.ToString());
                Console.WriteLine(accessToken);
                Console.WriteLine(datatoken);

            }
            else
            {
                Console.WriteLine("Connection Failed");
                return;
            }

            var request = new RestRequest(String.Format("api/Reservations?phone={0}", phone));
            request.AddParameter("Authorization", accessToken, ParameterType.HttpHeader);

            // execute the request
            var response2 = client.Execute(request);
            var content = response2.Content; // raw content as string
            var jobject = JsonConvert.DeserializeObject<ReservationDTO>(response2.Content);
           
            //var jsonObject2 = JsonConvert.DeserializeObject<List<ReservationDTO>>(response2.Content);

            client.ExecuteAsync(request, response => {

                //Console.WriteLine(response.Content);

                var jsonObject = JsonConvert.DeserializeObject<List<ReservationDTO>>(response.Content);
                foreach (var item in jsonObject)
                {
                    Console.WriteLine(item.Name);
                }
            });

        }

        static void Main(string[] args)
        {

            Program p = new Program();
            // p.GetReservations();
            var date = new DateTime(2015, 10, 5);
            var currentDate = DateTime.Now;
            var timeDiff = (date - currentDate);
            Console.WriteLine(string.Format("time differece {0} ", timeDiff));
            Console.WriteLine(string.Format("In {0:00} Days : {1}hrs : {2}mins", timeDiff.Days, timeDiff.Hours, timeDiff.Minutes));
            Console.WriteLine(string.Format("In {0}", currentDate.ToString("MMM")));



            /***
            const string BaseAddress = "http://khanzzirfan.com/WApp/";
            var client = new RestClient(BaseAddress);
            var request = new RestRequest(String.Format("api/Reservations"));
            var accessToken = "";
            // execute the request
            var response2 = client.Execute(request);
            var content = response2.Content; // raw content as string
            var jsonObject2 = JsonConvert.DeserializeObject<List<ReservationDTO>>(response2.Content);

            client.ExecuteAsync(request, response => {

                //Console.WriteLine(response.Content);

                var jsonObject = JsonConvert.DeserializeObject<List<ReservationDTO>>(response.Content);
                foreach (var item in jsonObject)
                {
                    Console.WriteLine(item.Name);
                }
            });

            var restoObject = new ReservationDTO() {
                Comment = "RestoAdded",
                Date = DateTime.Now,
                Email = "irfan@gmail.com",
                Guests = 3,
                ID = 1.0m,
                Name = "Mark",
                Phone = "0220887887",
                Time = "11:10AM",
            };

           // var jsonPost = JsonConvert.SerializeObject(restoObject);
            var sendRequest = new RestRequest(String.Format("api/ReservationDTO"), Method.POST);
            //request.AddParameter("application/json", jsonPost);
            //var response = client.Execute(sendRequest);

            sendRequest.RequestFormat = DataFormat.Json;
            sendRequest.AddBody(restoObject);
            Console.WriteLine("Call to request reservation data");
            var response3 = client.Execute<ReservationDTO>(sendRequest);

            switch (response3.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                case System.Net.HttpStatusCode.Created:
                    var responseData = response3.Data;
                    Console.Write("name", responseData.Name);
                    break;

                default:
                    // NOK
                    Console.Write("ERROR: {0}", response3.Content);
                    break;
            }
            Console.WriteLine("EOF Call to request reservation data");

            var tokenRequest = new RestRequest("token", Method.POST);
            tokenRequest.AddParameter("grant_type", "password");
            tokenRequest.AddParameter("username", "irfank");
            tokenRequest.AddParameter("password", "Green0987");

            Console.WriteLine("Call to access token");
            var tokenResponse = client.Execute(tokenRequest);

            if (tokenResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var datatoken = tokenResponse.Content;

                var jObject = Newtonsoft.Json.Linq.JObject.Parse(datatoken);
                var token = jObject.SelectToken("access_token");
                accessToken = string.Format("Bearer {0}", token.ToString());
                Console.WriteLine(accessToken);

                Console.WriteLine(datatoken);
               
            }

            var dOrderRequest = new RestRequest("api/DOrders");
            dOrderRequest.AddParameter("Authorization", accessToken, ParameterType.HttpHeader);
            Console.WriteLine("call to account order with token supplied");
            var orderResponse = client.Execute(dOrderRequest);
            if (orderResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = orderResponse.Content;
                Console.WriteLine(data);

                //foreach (var d in data)
                //{
                //    Console.WriteLine(d);
                //}
            }
            Console.WriteLine("End of call to account orders");



            Console.WriteLine("EOF call to access token");

            //End of Main
            Console.ReadLine();
    ********/


        }
    }
}
