using Newtonsoft.Json;
using SitecoreDiscover.GenerateCategoryFeed.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SitecoreDiscover.GenerateCategoryFeed
{
    /// <summary>
    /// This sample code converts the /me/categories call from Sitecore OrderCloud into a TAB file as per the specficiations given at
    /// https://doc.sitecore.com/discover/en/developers/discover-developer-guide/category-data-feed-specifications.html
    /// The TAB file can then be used to send data to Sitecore Discover for initial bulk upload
    /// 
    /// The JSON file is generated from the PLAY!Shop demo instance by calling /me/categories API call and copying the generated output.
    /// 
    /// The code is provided as-is without any warranty. This is a starting point, you will have to adjust the code and data models as per the
    /// JSON output/response for your own shop.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //read from the local json file from data/category_data.json location and convert to internal objects
            var data = Read(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\category_data.json"));
            //convert the file to TAB format
            ConvertToTabFile(data);
        }
        /// <summary>
        /// Reads the JSON file from specific path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CategoryDataItems Read(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                try
                {
                    string json = file.ReadToEnd();

                    return JsonConvert.DeserializeObject<CategoryDataItems>(json);
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem reading file");

                    return null;
                }
            }
        }
        /// <summary>
        /// Converts the category data object into TAB delimited file, ready to bulk upload into Sitecore Discover
        /// </summary>
        /// <param name="data"></param>
        public static void ConvertToTabFile(CategoryDataItems data)
        {
            try
            {
                //delimiter character for tab
                string tab = "\t";
                //We are only adding required fields, you can additional optional values in the headers, for more details see https://doc.sitecore.com/discover/en/developers/discover-developer-guide/category-data-feed-specifications.html
                string[] headerList = {
                                        CategoryFeedHeaders.ccid.ToString(),
                                        CategoryFeedHeaders.name.ToString(),
                                        CategoryFeedHeaders.url_path.ToString(),
                                        CategoryFeedHeaders.parent_ccid.ToString(),
                                        CategoryFeedHeaders.seo_name.ToString()
                                        
                                        
                                    };
                string detail = "";
                string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\category_data_tab_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
                using (var sw = new StreamWriter(fileName, false))
                {

                    string header = string.Join(tab, headerList);
                    foreach (var category in data.Items)
                    {
                        
                        string[] lineList =
                        {
                            category.ID,
                            category.Name,
                            category.URLPath,
                            category.ParentID ?? string.Empty,
                            category.SEOName
                          
                        };
                    

                        string line = string.Join(tab, lineList);

                        detail += Environment.NewLine + line;
                    }

                    sw.Write(header + detail);
                    sw.Close();
                    Console.WriteLine("File Created:" + fileName);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem converting file" + ex.Message);

            }
        }
    }
}
