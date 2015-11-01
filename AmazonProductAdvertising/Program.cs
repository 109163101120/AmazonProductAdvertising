using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonProductAdvertising
{
    class Program
    {
        static void Main(string[] args)
        {
            AmazonQuery search = new AmazonQuery();

            /*
            *****   Get details by ASIN (Amazon's product number) *****
            Use this method if you want to get Amazon's information on a specific product(s).

            Response Groups: http://docs.aws.amazon.com/AWSECommerceService/latest/DG/CHAP_ResponseGroupsList.html
            ASINs: enter one or more in the string array: 
            */
            string[] LookupResponseGroup = new string[] { "Small" };
            string[] ASINs = new string[] { "B00DVDMRX6", "B00YZ63JJ4" };

            //Response is a ItemLookupResponse object.
            var response = search.LookupByASIN(ASINs, LookupResponseGroup);

            /*
            Work your magic here with the response Example:
            */
            Console.WriteLine("ITEM LOOKUP INFO EXAMPLE FROM AMAZON:");
            for (int i = 0; i < response.Items[0].Item.Count(); i++)
            {
                Console.WriteLine(response.Items[0].Item[i].ItemAttributes.Title);
            }
            Console.WriteLine();
            Console.WriteLine();



            /*
            *****   Amazon Product Search *****
            Use this method if you want to get search Amazon's products
            SearchIndex: http://docs.aws.amazon.com/AWSECommerceService/latest/DG/SearchIndices.html
            Keywords: What you're searching for.
            Response Groups: http://docs.aws.amazon.com/AWSECommerceService/latest/DG/CHAP_ResponseGroupsList.html

            */
            string SearchIndex = "All";
            string[] SearchResponseGroup = new string[] { "Medium" };
            string Keywords = "grumpy cat";

            //Response is a ItemLookupResponse object.
            var searchResponse = search.ItemSearch(SearchIndex, SearchResponseGroup, Keywords);

            /*
            Work your magic here with the searchResponse. Example:
            */
            Console.WriteLine("ITEM SEARCH INFO EXAMPLE FROM AMAZON:");
            for (int i = 0; i < searchResponse.Items[0].Item.Count(); i++)
            {
                Console.WriteLine(searchResponse.Items[0].Item[i].ItemAttributes.Title);
            }

        }
    }
}
