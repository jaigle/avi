﻿using System;
using System.Text;

namespace ApiLayer.Library
{
    public class Tools
    {
        public static string Base64Encode(string plainText)
        {
            //var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            //return Convert.ToBase64String(plainTextBytes);
            return plainText;
        }
        public static string Base64Decode(string base64EncodedData)
        {
            //var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            //return Encoding.UTF8.GetString(base64EncodedBytes);
            return base64EncodedData;
        }
    }
}