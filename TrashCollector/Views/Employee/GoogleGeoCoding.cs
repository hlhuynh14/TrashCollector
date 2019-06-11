using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using TrashCollector.Models;

namespace TrashCollector.Views.Employee
{
    public class GoogleGeoCoding
    {
        public static float[] GetLatLong(Customer customer)
        {
            GoogleMap myMap = new GoogleMap();
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + customer.address + ",+" + customer.city + ",+" + customer.state + "&key=" + APIKeys.apiKeys;
            WebRequest requestObject = WebRequest.Create(url);
            requestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();

            string urlResult = null;
            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                urlResult = sr.ReadToEnd();
                sr.Close();
            }

            float lat;
            float longitutde;

            myMap = JsonConvert.DeserializeObject<GoogleMap>(urlResult);
            try
            {
                lat = myMap.results[0].geometry.location.lat;
                longitutde = myMap.results[0].geometry.location.lng;
            }
            catch
            {
                return null;
            }
            float[] coords = new float[2];
            coords[0] = lat;
            coords[1] = longitutde;
            return coords;

        }
    }

    public class GoogleMap
    {
        public Result[] results { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }
}
